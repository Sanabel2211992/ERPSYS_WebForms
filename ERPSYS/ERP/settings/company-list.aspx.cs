using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class CompanyList : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

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
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("company_id_not_exist"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);                
            }
        }

        protected void rgCompanyList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgCompanyList.DataSource = _setting.GetCompanyList();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }

        }
    }
}