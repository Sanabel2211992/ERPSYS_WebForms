using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Data;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.settings
{
    public partial class LocationAssignment : System.Web.UI.Page
    {

        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                GetLookupTables();
                GetLocationAssignment();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLookupTables()
        {
            try
            {
                LookupBLL lookup = new LookupBLL();
                DataTable dtLocation = lookup.GetLocation();

                ddlRawMaterialStore.DataTextField = "Name";
                ddlRawMaterialStore.DataValueField = "LocationId";
                ddlRawMaterialStore.DataSource = dtLocation;
                ddlRawMaterialStore.DataBind();

                ddlProductionStore.DataTextField = "Name";
                ddlProductionStore.DataValueField = "LocationId";
                ddlProductionStore.DataSource = dtLocation;
                ddlProductionStore.DataBind();

                ddlFinishMaterial.DataTextField = "Name";
                ddlFinishMaterial.DataValueField = "LocationId";
                ddlFinishMaterial.DataSource = dtLocation;
                ddlFinishMaterial.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLocationAssignment()
        {
            MainLocation location = _setting.LocationAssignment();

            ddlRawMaterialStore.SelectedValue = location.RawMaterialLocationId.ToString();
            ddlProductionStore.SelectedValue = location.ProductionLocationId.ToString();
            ddlFinishMaterial.SelectedValue = location.FinishMaterialLocationId.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int rawMaterialLocationId = ddlRawMaterialStore.SelectedValue.ToInt();
                int productionLocationId = ddlProductionStore.SelectedValue.ToInt();
                int finishMaterialLocationId = ddlFinishMaterial.SelectedValue.ToInt();

                string rMessage;
                _setting.UpdateLocationsAssignment(rawMaterialLocationId, productionLocationId, finishMaterialLocationId, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("Location_assign_update_success"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}