using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class MailBLL
    {
        private readonly MailDB _mail = new MailDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetMailSettingsList()
        {
            return _mail.GetMailSettingsList();
        }

        public MailSettings GetMailSettings(int emailId)
        {
            DataTable dt = _mail.GetMailSettings(emailId);

            MailSettings settings = new MailSettings();

            if (dt.Rows.Count == 0)
            {
                settings.EmailId = -1;
                return settings;
            }

            DataRow dr = dt.Rows[0];

            settings.EmailId = emailId;
            settings.EmailName = dr["EmailName"].ToString();
            settings.SenderName = dr["SenderName"].ToString();
            settings.SenderAddress = dr["SenderAddress"].ToString();
            settings.SMTPServer = dr["SMTPServer"].ToString();
            settings.SMTPPort = dr["SMTPPort"].ToInt();
            settings.Timeout = dr["Timeout"].ToInt();
            settings.IsUsingSSL = dr["IsUsingSSL"].ToBool();
            settings.IsUsingTLS = dr["IsUsingTLS"].ToBool();
            settings.IgnoreCertificate = dr["IgnoreCertificate"].ToBool();
            settings.SMTPRequiresAuthentication = dr["SMTPAuth"].ToBool();
            settings.SMTPUserName = dr["AuthUsername"].ToString();
            settings.SMTPPassword = dr["AuthPassword"].ToString();

            return settings;
        }

        public DataTable GetEmailTemplateTypeList()
        {
            return _mail.GetEmailTemplateTypeList();
        }

        public DataTable GetEmailTemplateList(int typeId)
        {
            return _mail.GetEmailTemplateList(typeId);
        }

        public EmailTemplate GetEmailTemplate(int typeId, int templateId)
        {
            DataTable dt = _mail.GetEmailTemplate(typeId, templateId);

            EmailTemplate template = new EmailTemplate();

            if (dt.Rows.Count == 0)
            {
                template.TemplateId = -1;
                return template;
            }

            DataRow dr = dt.Rows[0];
            template.TemplateId = templateId;
            template.TemplateTypeId = typeId;
            template.Name = dr["Name"].ToString();
            template.Description = dr["Description"].ToString();
            template.Subject = dr["Subject"].ToString();
            template.Body = dr["Body"].ToString();
            template.Note = dr["Note"].ToString();
            template.IsActive = dr["IsActive"].ToBool();

            return template;
        }

        //**************************************************************************************************************************//INSERT

        public void AddMailSettings(MailSettings mail, out string rMsg)
        {
            _mail.AddEmailSettings(mail, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public void UpdateMailSettings(MailSettings mail, out string rMessage)
        {
            _mail.UpdateMailSettings(mail, out rMessage);
        }

        public int UpdateEmailTemplate(EmailTemplate template, out string rMsg)
        {
            return _mail.UpdateEmailTemplate(template, out rMsg);
        }

        //************************************************************************************************************************//DELETE

        public void DeleteMailSettings(int settingsId, out string rMsg, out int rMessageId)
        {
            _mail.DeleteMailSettings(settingsId, out rMsg, out rMessageId);
        }
    }
}