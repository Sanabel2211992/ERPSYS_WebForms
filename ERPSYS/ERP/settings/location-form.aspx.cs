using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class LocationForm : System.Web.UI.Page
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
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetLocationDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLocationDetails(int locationId)
        {
            try
            {
                Location location = _setting.GetLocation(locationId);

                if (location.LocationId <= 0)
                {
                    Response.Redirect(string.Format("location-list.aspx?e={0}", 1));
                }

                LocationId = locationId;
                txtLocationName.Text = location.LocationName;
                txtStoreCode.Text = location.StoreCode;
                txtStoreKeeper.Text = location.StoreKeeper;
                cbReceivedGoods.Checked = location.IsReceivedGoods;
                cbSellGoods.Checked = location.IsDeliveryGoods;
                cbConsigned.Checked = location.IsConsigned;
                cbHasCost.Checked = location.HasCost;
                cbIsActive.Checked = location.IsActive;

                if (location.LocationId <= 5) //default locations
                {
                    txtLocationName.Enabled = false;
                    cbReceivedGoods.Enabled = false;
                    cbSellGoods.Enabled = false;
                    cbConsigned.Enabled = false;
                    cbHasCost.Enabled = false;
                    cbIsActive.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddLocation()
        {
            Location location = new Location();

            location.LocationName = txtLocationName.Text.ToTrimString();
            location.StoreCode = txtStoreCode.Text.ToTrimString();
            location.StoreKeeper = txtStoreKeeper.Text.ToTrimString();
            location.IsReceivedGoods = cbReceivedGoods.Checked;
            location.IsDeliveryGoods = cbSellGoods.Checked;
            location.IsConsigned = cbConsigned.Checked;
            location.HasCost = cbHasCost.Checked;
            location.IsActive = cbIsActive.Checked;

            string rMessage;
            int locationId = _setting.AddLocation(location, out rMessage);

            if (rMessage != string.Empty || locationId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("location-list.aspx?o={0}", 1), false);
        }

        protected void UpdateLocation()
        {
            Location location = new Location();

            location.LocationId = LocationId;
            location.LocationName = txtLocationName.Text.ToTrimString();
            location.StoreKeeper = txtStoreKeeper.Text.ToTrimString();
            location.StoreCode = txtStoreCode.Text.ToTrimString();
            location.IsReceivedGoods = cbReceivedGoods.Checked;
            location.IsDeliveryGoods = cbSellGoods.Checked;
            location.IsConsigned = cbConsigned.Checked;
            location.HasCost = cbHasCost.Checked;
            location.IsActive = cbIsActive.Checked;

            string rMessage;
            _setting.UpdateLocation(location, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("location-list.aspx?o={0}", 2), false);

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddLocation();
                }
                else if (Operation == "edit" && LocationId > 0)
                {
                    UpdateLocation();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("location-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : -1; }
            set { ViewState["LocationId"] = value; }
        }
    }
}