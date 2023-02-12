using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class UnitOfMeasureConversionList : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("uom_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("uom_conversion_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("uom_conversion_update_success"));
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
            GetUnitOfMeasureConversionList();
        }

        private void GetUnitOfMeasureConversionList()
        {
            try
            {
                rgUnitMeasure.DataSource = _setting.GetUnitOfMeasureConversionList();
                rgUnitMeasure.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("uom-conversion-details.aspx", false);
        }
    }
}