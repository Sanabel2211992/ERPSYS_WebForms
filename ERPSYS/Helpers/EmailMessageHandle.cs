using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.Helpers
{
    public class EmailMessageHandle
    {
        readonly MailBLL _mail = new MailBLL();

        private string _senderEmail;
        private string _senderName;
        private List<string> _mailTo;
        private string _subject = "";
        private string _body = "";
        private MailPriority _priority;
        private List<string> _mailAttachments;
        private readonly List<string> _mailccsettings; // get list from settings
        private readonly List<string> _mailbccsettings;  // get list from settings
        private List<string> _mailcc;
        private List<string> _mailbcc;
        private readonly string _smtpServer;
        private readonly bool _smtpRequiresAuthentication;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _attachmentFolderPath = CommonMember.AttachmentEmailUploadFolderPath;

        public EmailMessageHandle()
        {
            try
            {
                //MailSettings settings = _mail.GetDefaultMailSettings();

                //_senderEmail = settings.SenderAddress;
                //_senderName = settings.SenderName;
                //_mailccsettings = settings.CcMail.Replace(",", ";").Split(';').ToList();
                //_mailbccsettings = settings.BccMail.Replace(",", ";").Split(';').ToList();
                //_smtpServer = settings.SmtpServer;
                //_smtpRequiresAuthentication = settings.SMTPRequiresAuthentication;
                //_smtpUsername = settings.SMTPUserName;
                //_smtpPassword = settings.SMTPPassword;
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }

        public EmailMessageHandle(int typeId)
        {
            try
            {
                //MailSettings settings = _mail.GetMailSettings(typeId);

                //_senderEmail = settings.SenderAddress;
                //_senderName = settings.SenderName;
                //_mailcc = settings.CcMail.Replace(",", ";").Split(';').ToList();
                //_mailbcc = settings.BccMail.Replace(",", ";").Split(';').ToList();
                //_smtpServer = settings.SmtpServer;
                //_smtpRequiresAuthentication = settings.SMTPRequiresAuthentication;
                //_smtpUsername = settings.SMTPUserName;
                //_smtpPassword = settings.SMTPPassword;
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }

        public string SenderEmail
        {
            get { return _senderEmail; }
            set { _senderEmail = value; }
        }

        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        public List<string> MailTo
        {
            get { return _mailTo; }
            set { _mailTo = value; }
        }

        public List<string> MailCc
        {
            get { return _mailcc; }
            set { _mailcc = value; }
        }

        public List<string> MailBcc
        {
            get { return _mailbcc; }
            set { _mailbcc = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public MailPriority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public List<string> MailAttachments
        {
            get { return _mailAttachments; }
            set { _mailAttachments = value; }
        }

        public string SendMessage()
        {
            return SendEmailMessage();
        }

        public MailPriority GetMailPriority(int priorityId)
        {
            switch (priorityId)
            {
                case 1:
                    return MailPriority.Low;
                case 2:
                    return MailPriority.High;
                default:
                    return MailPriority.Normal;
            }
        }

        protected string SendEmailMessage()
        {
            string erMsg = "";
            if (_senderEmail == string.Empty)
            {
                erMsg = string.Format("Invalid Email Address : {0}", _senderEmail);
                return erMsg;
            }

            List<string> mailcclist = _mailcc.Union(_mailccsettings).ToList(); // merge to cc list one from user and other from settings to one list
            List<string> mailbcclist = _mailbcc.Union(_mailbccsettings).ToList(); // merge to cc list one from user and other from settings to one list

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_senderEmail, _senderName);

            // To
            foreach (string email in _mailTo.Where(email => !string.IsNullOrEmpty(email)))
            {
                msg.To.Add(new MailAddress(email));
            }

            //CC 
            foreach (string email in mailcclist.Where(email => !string.IsNullOrEmpty(email)))
            {
                msg.CC.Add(new MailAddress(email));
            }

            //BCC 
            foreach (string email in mailbcclist.Where(email => !string.IsNullOrEmpty(email)))
            {
                msg.CC.Add(new MailAddress(email));
            }

            msg.Subject = _subject;
            msg.Body = _body;// Body.Replace(Constants.vbCrLf, "<BR>");
            msg.Priority = _priority;
            msg.IsBodyHtml = true;

            if (_mailAttachments.Count > 0)
            {
                foreach (var attach in from attachment in _mailAttachments where !string.IsNullOrEmpty(attachment) select HttpContext.Current.Server.MapPath(_attachmentFolderPath + attachment) into attachmentPath select new FileInfo(attachmentPath) into atcchPath where atcchPath.Exists select new Attachment(atcchPath.FullName))
                {
                    msg.Attachments.Add(attach);
                }
            }

            var smtp = new SmtpClient(_smtpServer);
            if (_smtpRequiresAuthentication)
            {
                //smtp.UseDefaultCredentials = false;
                //smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            }

            try
            {
                smtp.Send(msg);
                msg.Dispose();

                if (_mailAttachments.Count > 0)
                {
                    foreach (FileInfo atcchPath in from attachment in _mailAttachments where !string.IsNullOrEmpty(attachment) select HttpContext.Current.Server.MapPath(_attachmentFolderPath + attachment) into attachmentPath select new FileInfo(attachmentPath) into atcchPath where atcchPath.Exists select atcchPath)
                    {
                        //atcchPath.Delete();
                        string newPath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.TrashEmailFolderPath, atcchPath.Name.AppendTimeStamp()));
                        atcchPath.MoveTo(newPath);
                    }
                }
            }
            catch (Exception ex)
            {
                erMsg = ex.Message;
                AppNotification.WriteExceptionLog(ex);
            }

            return erMsg;
        }
    }
}



