using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class LocationList : System.Web.UI.Page
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("location_id_not_exist"));
                        break;
                }
                 switch (Request.QueryString["o"])
                 {
                     case "1":
                         AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("location_add_success"));
                         break;
                     case "2":
                         AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("location_update_success"));
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
            GetLocationList();
        }

        private void GetLocationList()
        {
            try
            {
                rgLocationList.DataSource = _setting.GetLocationList();
                rgLocationList.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("location-form.aspx", false);
        }
    }
}