using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.Helpers
{
    public class EmailMessageHandleX
    {
        readonly MailBLL _mail = new MailBLL();

        private readonly List<string> _mailcc; // get list from settings
        private readonly List<string> _mailbcc;  // get list from settings
        private readonly string _smtpServer;
        private readonly bool _smtpRequiresAuthentication;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _attachmentFolderPath = CommonMember.AttachmentEmailUploadFolderPath;

        public EmailMessageHandleX()
        {
            try
            {
                //MailSettings settings = _mail.GetDefaultMailSettings();

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

        public EmailMessageHandleX(int typeId)
        {
            try
            {
                //MailSettings settings = _mail.GetMailSettings(typeId);

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

        public string SendMessage(string senderEmail, string senderName, List<string> mailTo, string subject, string body, MailMessagePriority priority = MailMessagePriority.Normal, List<string> mailCc = null, List<string> mailBcc = null, bool hasAttachment = false, List<string> mailAttachments = null, bool deleteAttachmentAfterSend = true)
        {
            mailTo = mailTo ?? new List<String>();
            mailCc = mailCc ?? new List<String>();
            mailBcc = mailBcc ?? new List<String>();
            mailAttachments = mailAttachments ?? new List<String>();

            return SendEmailMessage(senderEmail, senderName, mailTo, subject, body, priority, mailCc, mailBcc, hasAttachment, mailAttachments, deleteAttachmentAfterSend);
        }

        public string SendMessage(List<string> mailTo, string subject, string body, MailMessagePriority priority = MailMessagePriority.Normal, List<string> mailCc = null, List<string> mailBcc = null, bool hasAttachment = false, List<string> mailAttachments = null, bool deleteAttachmentAfterSend = true)
        {
            string senderEmail = UserSession.EmailAddress;
            string senderName = UserSession.UserDisplayName;
            mailTo = mailTo ?? new List<String>();
            mailCc = mailCc ?? new List<String>();
            mailBcc = mailBcc ?? new List<String>();
            mailAttachments = mailAttachments ?? new List<String>();

            return SendEmailMessage(senderEmail, senderName, mailTo, subject, body, priority, mailCc, mailBcc, hasAttachment, mailAttachments, deleteAttachmentAfterSend);
        }

        protected string SendEmailMessage(string senderEmail, string senderName, List<string> mailTo, string subject, string body, MailMessagePriority priority, List<string> mailCc, List<string> mailBcc, bool hasAttachment, List<string> mailAttachments, bool deleteAttachmentAfterSend)
        {
            string erMsg = "";
            if (senderEmail == string.Empty)
            {
                erMsg = string.Format("Invalid Email Address : {0}", senderEmail);
                return erMsg;
            }

            List<string> mailcclist = mailCc.Union(_mailcc).ToList(); // merge to cc list one from user and other from settings to one list
            List<string> mailbcclist = mailBcc.Union(_mailbcc).ToList(); // merge to cc list one from user and other from settings to one list

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(senderEmail, senderName);

            // To
            foreach (string email in mailTo.Where(email => !string.IsNullOrEmpty(email)))
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

            msg.Subject = subject;
            msg.Body = body;// Body.Replace(Constants.vbCrLf, "<BR>");
            msg.Priority = (MailPriority)priority;
            msg.IsBodyHtml = true;

            if (hasAttachment && mailAttachments != null)
            {
                foreach (var attach in from attachment in mailAttachments where !string.IsNullOrEmpty(attachment) select HttpContext.Current.Server.MapPath(_attachmentFolderPath + attachment) into attachmentPath select new FileInfo(attachmentPath) into atcchPath where atcchPath.Exists select new Attachment(atcchPath.FullName))
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

                if (hasAttachment && mailAttachments != null && deleteAttachmentAfterSend)
                {
                    foreach (FileInfo atcchPath in from attachment in mailAttachments where !string.IsNullOrEmpty(attachment) select HttpContext.Current.Server.MapPath(_attachmentFolderPath + attachment) into attachmentPath select new FileInfo(attachmentPath) into atcchPath where atcchPath.Exists select atcchPath)
                    {
                        atcchPath.Delete();
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



