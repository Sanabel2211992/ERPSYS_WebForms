using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.settings
{
    public partial class MailSettingsList : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("mail_settings_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("mail_settings_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("mail_settings_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("mail_settings_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("mail_settings_delete_failed"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgMailSettingsList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgMailSettingsList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEmailSetting();
        }

        private void GetEmailSetting()
        {
            try
            {
                rgMailSettingsList.DataSource = _mail.GetMailSettingsList();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ERP/settings/mail-settings-form.aspx");
        }
    }
}