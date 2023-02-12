using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.mail
{
    public partial class MailSend : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }
      
        private void InitializeComponent()
        {
            try
            {
                //txtMailBody.ToolsFile = CommonMember.EditorToolBarFilePath;
                //txtMailBody.CssFiles.Add(CommonMember.EditorCSSFilePath);

                //MailSettings settings = _mail.GetDefaultMailSettings();

                //ddlEmailFrom.Items.Clear();
                //ddlEmailFrom.Items.Insert(0, new ListItem(string.Format("{0} ({1})", settings.SenderName, settings.SenderAddress), string.Format("{0},{1}", settings.SenderName, settings.SenderAddress)));
                //ddlEmailFrom.Items.Insert(0, new ListItem(string.Format("{0} ({1})", UserSession.UserDisplayName, UserSession.EmailAddress), string.Format("{0},{1}", UserSession.UserDisplayName, UserSession.EmailAddress)));
                //txtMailSubject.Text = settings.Subject;
                //txtMailBody.Content = settings.Body;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            try
            {
                List<string> mailAttachments = new List<string>();
                string attachmentFolderPath = CommonMember.AttachmentEmailUploadFolderPath;

                if (fuMailAttatchment1.HasFile || fuMailAttatchment1.HasFile)
                {
                    mailAttachments = new List<string>();

                    FileHandle file = new FileHandle();

                    file.FileAllowedSize = 20;

                    if (fuMailAttatchment1.HasFile)
                    {
                        file.SaveFileToTempFolder(fuMailAttatchment1, attachmentFolderPath);
                        mailAttachments.Add(fuMailAttatchment1.FileName);
                    }
                    if (fuMailAttatchment2.HasFile)
                    {
                        file.SaveFileToTempFolder(fuMailAttatchment2, attachmentFolderPath);
                        mailAttachments.Add(fuMailAttatchment2.FileName);
                    }
                }

                EmailMessageHandle message = new EmailMessageHandle();

                message.SenderEmail = ddlEmailFrom.SelectedValue.Split(',')[1];
                message.SenderName = ddlEmailFrom.SelectedValue.Split(',')[0];
                message.MailTo = txtMailTo.Text.ToTrimString().Replace(",", ";").Split(';').ToList();
                message.MailCc = txtMailCc.Text.ToTrimString().Replace(",", ";").Split(';').ToList();
                message.MailBcc = new List<string>();
                message.Subject = txtMailSubject.Text.ToTrimString();
                message.Body = txtMailBody.Content.ToTrimString();
                message.Priority = message.GetMailPriority(ddlPriority.SelectedValue.ToInt());
                message.MailAttachments = mailAttachments;

                string rMessage = message.SendMessage();

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }
               
                AppNotification.MessageBoxSuccess(Notifications.GetMessage("email_sent_successfully"));
              
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void btSend_Click(object sender, EventArgs e)
        //{
        //    if (!IsValid)
        //        return;

        //    try
        //    {
        //        EmailMessageHandle message = new EmailMessageHandle();

        //        string senderAddress = ddlEmailFrom.SelectedValue.Split(',')[1];                
        //        string senderName = ddlEmailFrom.SelectedValue.Split(',')[0];
        //        List<string> mailTo = txtMailTo.Text.ToTrimString().Replace(",", ";").Split(';').ToList();
        //        List<string> mailCc = txtMailCc.Text.ToTrimString().Replace(",", ";").Split(';').ToList();
        //        MailMessagePriority mailPriority = (MailMessagePriority) ddlPriority.SelectedValue.ToInt();
        //        string mailSubject = txtMailSubject.Text.ToTrimString();
        //        string mailBody = txtMailBody.Content.ToTrimString();
        //        bool hasAttachmnets = false;
        //        const bool deleteAttachmentAfterSend = true;
        //        List<string> mailAttachments = null;
        //        string attachmentFolderPath = CommonMember.AttachmentEmailUploadFolderPath;

        //        if (fuMailAttatchment1.HasFile || fuMailAttatchment1.HasFile)
        //        {
        //            hasAttachmnets = true;
        //            mailAttachments = new List<string>();

        //            FileHandle file = new FileHandle();

        //            file.FileAllowedSize = 20;

        //            if (fuMailAttatchment1.HasFile)
        //            {
        //                file.SaveFileToTempFolder(fuMailAttatchment1, attachmentFolderPath);
        //                mailAttachments.Add(fuMailAttatchment1.FileName);
        //            }
        //            if (fuMailAttatchment2.HasFile)
        //            {
        //                file.SaveFileToTempFolder(fuMailAttatchment2, attachmentFolderPath);
        //                mailAttachments.Add(fuMailAttatchment2.FileName);
        //            }
        //        }

        //        string rMessage = message.SendMessage(senderAddress, senderName, mailTo, mailSubject, mailBody, mailPriority, mailCc, null, hasAttachmnets, mailAttachments, deleteAttachmentAfterSend);

        //        if (rMessage != string.Empty)
        //        {
        //            AppNotification.MessageBoxFailed(rMessage);
        //            return;
        //        }

        //        AppNotification.MessageBoxSuccess(Notifications.GetMessage("email_sent_successfully"));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void AddMail()
        //{

        //    Ticket mailSend = new Ticket();

        //    mailSend.UserId = UserSession.UserId;
        //    mailSend.From = ddlEmailFrom.SelectedValue.ToTrimString();
        //    mailSend.To = txtMailTo.Text.ToTrimString();
        //    mailSend.Cc = txtMailCc.Text.ToTrimString();
        //    mailSend.Priority = ddlPriority.SelectedValue.ToTrimString();
        //    mailSend.Subject = txtMailSubject.Text.ToTrimString();
        //    mailSend.Description = txtMailBody.Text.ToTrimString();

        //    FileImage fileAtt1 = new FileImage();
        //    FileImage fileAtt2 = new FileImage();

        //    if (fuMailAttatchment1.HasFile)
        //    {
        //        string ext = Path.GetExtension(fuMailAttatchment1.FileName);
        //        string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;
        //        HttpPostedFile postimg = fuMailAttatchment1.PostedFile;

        //        fileAtt1.IsUpdated = true;
        //        fileAtt1.ImageData = CommonHelper.ImageToByte(fuMailAttatchment1.PostedFile);
        //        fileAtt1.ImageType = Path.GetExtension(postimg.FileName);
        //    }
        //    mailSend.FileAtt1 = fileAtt1;

        //    if (fuMailAttatchment2.HasFile)
        //    {
        //        string ext = Path.GetExtension(fuMailAttatchment2.FileName);
        //        string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;
        //        HttpPostedFile postimg = fuMailAttatchment2.PostedFile;

        //        fileAtt2.IsUpdated = true;
        //        fileAtt2.ImageData = CommonHelper.ImageToByte(fuMailAttatchment2.PostedFile);
        //        fileAtt2.ImageType = Path.GetExtension(postimg.FileName);
        //    }
        //    mailSend.FileAtt2 = fileAtt2;

        //    string rMessage;
        //    _mailsend.AddTicket(mailSend, out rMessage);

        //}
    }
}