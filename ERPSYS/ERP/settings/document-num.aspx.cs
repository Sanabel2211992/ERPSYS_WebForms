using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class DocumentNum : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                BindData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("document_type_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("document_type_update_success"));
                        break;
                }
            }
               catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgDocumentsFormat.Rebind();
        }

        protected void rgDocumentsFormat_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GetDocumentFormatList();
        }

        private void GetDocumentFormatList()
        {
            try
            {
                rgDocumentsFormat.DataSource = _setting.GetDocumentFormatList();
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}