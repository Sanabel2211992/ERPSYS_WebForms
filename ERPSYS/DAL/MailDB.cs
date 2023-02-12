using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class MailDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetMailSettingsList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Mail_Settings_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetMailSettings(int emailId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@EmailId", emailId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Mail_Settings_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetEmailTemplateTypeList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Email_TemplateType_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetEmailTemplateList(int typeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TemplateTypeId", typeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Email_Template_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetEmailTemplate(int typeId, int templateId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TemplateTypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@TemplateId", templateId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Email_Template_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public void AddEmailSettings(MailSettings mail, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@EmailName", mail.EmailName));
            paramCollection.Add(new DBParameter("@SenderName", mail.SenderName));
            paramCollection.Add(new DBParameter("@SenderAddress", mail.SenderAddress));
            paramCollection.Add(new DBParameter("@SMTPServer", mail.SMTPServer));
            paramCollection.Add(new DBParameter("@SMTPPort", mail.SMTPPort, DbType.Int32));
            paramCollection.Add(new DBParameter("@Timeout", mail.Timeout, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsUsingSSL", mail.IsUsingSSL, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsUsingTLS", mail.IsUsingTLS, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IgnoreCertificate", mail.IgnoreCertificate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@SMTPAuth", mail.SMTPRequiresAuthentication, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AuthUsername", mail.SMTPUserName));
            paramCollection.Add(new DBParameter("@AuthPassword", mail.SMTPPassword));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Mail_Settings_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("mail_settings_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateMailSettings(MailSettings mail, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@EmailId", mail.EmailId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EmailName", mail.EmailName));
            paramCollection.Add(new DBParameter("@SenderName", mail.SenderName));
            paramCollection.Add(new DBParameter("@SenderAddress", mail.SenderAddress));
            paramCollection.Add(new DBParameter("@SMTPServer", mail.SMTPServer));
            paramCollection.Add(new DBParameter("@SMTPPort", mail.SMTPPort, DbType.Int32));
            paramCollection.Add(new DBParameter("@Timeout", mail.Timeout, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsUsingSSL", mail.IsUsingSSL, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsUsingTLS", mail.IsUsingTLS, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IgnoreCertificate", mail.IgnoreCertificate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@SMTPAuth", mail.SMTPRequiresAuthentication, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AuthUsername", mail.SMTPUserName));
            paramCollection.Add(new DBParameter("@AuthPassword", mail.SMTPPassword));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Mail_Settings_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("mail_settings_update_duplicate");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateEmailTemplate(EmailTemplate template, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TemplateTypeId", template.TemplateTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@TemplateId", template.TemplateId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Subject", template.Subject));
            paramCollection.Add(new DBParameter("@Body", template.Body));
            paramCollection.Add(new DBParameter("@IsActive", template.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Email_Template_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        //****************************************************************************************************************************//Delete

        public void DeleteMailSettings(int emailId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@EmailId", emailId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_MailSettings_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("mail_settings_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}