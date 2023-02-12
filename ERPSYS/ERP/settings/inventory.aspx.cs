using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class Inventory : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GetLocationList();
        }

        private void GetLocationList()
        {
            try
            {
                rgLocationList.DataSource = _setting.GetLocationList();
                rgLocationList.DataBind();
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}