using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.settings
{
    public partial class MailSettingsForm : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {        
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            txtSmtpUserName.Attributes.Add("autocomplete", "off");
            txtSmtpPassword.Attributes.Add("autocomplete", "off");
            txtSmtpPassword.Attributes["value"] = txtSmtpPassword.Text;

            if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                Operation = "edit";
                GetMailSettings(Request.QueryString["id"].ToInt());
            }
            else
            {
                Operation = "new";
            }
        }

        private void GetMailSettings(int emailId)
        {
            try
            {
                MailSettings mail = _mail.GetMailSettings(emailId);

                if (mail.EmailId <= 0)
                {
                    Response.Redirect(string.Format("mail-settings-list.aspx?e={0}", 1));
                }

                EmailId = mail.EmailId;
                txtEmailName.Text = mail.EmailName;
                txtSenderName.Text = mail.SenderName;
                txtSenderAddress.Text = mail.SenderAddress;
                txtSMTPServer.Text = mail.SMTPServer;
                txtSMTPPort.Text = mail.SMTPPort.ToString();
                txtTimeout.Text = (mail.Timeout / 1000).ToString();
                rblSSL.SelectedValue = mail.IsUsingSSL ? "true" : "false";
                rblTLS.SelectedValue = mail.IsUsingTLS ? "true" : "false";
                rblIgnoreCertificate.SelectedValue = mail.IgnoreCertificate ? "true" : "false";
                cbAuthentication.Checked = mail.SMTPRequiresAuthentication;
                pnlAuthentication.Visible = mail.SMTPRequiresAuthentication;
                txtSmtpUserName.Text = mail.SMTPUserName;
                txtSmtpPassword.Text = mail.SMTPPassword;
                txtSmtpPassword.Attributes["value"] = mail.SMTPPassword;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void cbAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            pnlAuthentication.Visible = cbAuthentication.Checked;
        }

        private void AddMailSettings()
        {
            MailSettings mail = new MailSettings();

            mail.EmailName = txtEmailName.Text.ToTrimString();
            mail.SenderName = txtSenderName.Text.ToTrimString();
            mail.SenderAddress = txtSenderAddress.Text.ToTrimString();
            mail.SMTPServer = txtSMTPServer.Text.ToTrimString();
            mail.SMTPPort = txtSMTPPort.Text.ToInt();
            mail.Timeout = (txtTimeout.Text.ToInt() * 1000);
            mail.IsUsingSSL = rblSSL.SelectedValue == "true";
            mail.IsUsingTLS = rblTLS.SelectedValue == "true";
            mail.IgnoreCertificate = rblIgnoreCertificate.SelectedValue == "true";
            mail.SMTPRequiresAuthentication = cbAuthentication.Checked;
            mail.SMTPUserName = txtSmtpUserName.Text.ToTrimString();
            mail.SMTPPassword = txtSmtpPassword.Text.ToTrimString();

            string rMessage;
            _mail.AddMailSettings(mail, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("mail-settings-list.aspx?o={0}", 1));
        }

        private void UpdateMailSettings()
        {
            MailSettings mail = new MailSettings();

            mail.EmailId = EmailId;
            mail.EmailName = txtEmailName.Text.ToTrimString();
            mail.SenderName = txtSenderName.Text.ToTrimString();
            mail.SenderAddress = txtSenderAddress.Text;
            mail.SMTPServer = txtSMTPServer.Text.ToTrimString();
            mail.SMTPPort = txtSMTPPort.Text.ToInt();
            mail.Timeout = (txtTimeout.Text.ToInt() * 1000);
            mail.IsUsingSSL = rblSSL.SelectedValue == "true";
            mail.IsUsingTLS = rblTLS.SelectedValue == "true";
            mail.IgnoreCertificate = rblIgnoreCertificate.SelectedValue == "true";
            mail.SMTPRequiresAuthentication = cbAuthentication.Checked;
            mail.SMTPUserName = txtSmtpUserName.Text.ToTrimString();
            mail.SMTPPassword = txtSmtpPassword.Text.ToTrimString();

            string rMessage;
            _mail.UpdateMailSettings(mail, out rMessage);

            if (rMessage != string.Empty || EmailId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("mail-settings-list.aspx?o={0}", 2));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new" && EmailId == -1)
                {
                    AddMailSettings();
                }
                else if (Operation == "edit" && EmailId > 0)
                {
                    UpdateMailSettings();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("mail-settings-list.aspx");
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int EmailId
        {
            get { return ViewState["EmailId"] != null ? ViewState["EmailId"].ToInt() : -1; }
            set { ViewState["EmailId"] = value; }
        }
    }
}