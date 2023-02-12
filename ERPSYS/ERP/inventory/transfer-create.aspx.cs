using System;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.inventory
{
    public partial class TransferCreate : System.Web.UI.Page
    {
        readonly InventoryBLL _inventory = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                UCDatePicker.DateValue = DateTime.Today;
                GetItemLookupTables();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            DataTable dtLocations = lookup.GetTransferStoreLocation();

            ddlFromLocation.DataTextField = "Name";
            ddlFromLocation.DataValueField = "LocationId";
            ddlFromLocation.DataSource = dtLocations;
            ddlFromLocation.DataBind();
            ddlFromLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlToLocation.DataTextField = "Name";
            ddlToLocation.DataValueField = "LocationId";
            ddlToLocation.DataSource = dtLocations;
            ddlToLocation.DataBind();
            ddlToLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        private void CreateStockTransfer()
        {
            if (ddlFromLocation.SelectedValue.ToInt() == ddlToLocation.SelectedValue.ToInt())
            {
                AppNotification.MessageBoxFailed("Please select a valid Stock and try again");
                return;
            }

            StockTransfer transfer = new StockTransfer();

            transfer.TransferDescription = txtTransferDescription.Text.ToTrimString();
            transfer.TransferDate = UCDatePicker.DateValue;
            transfer.JobOrderNumber = txtJobOrderNumber.Text.ToTrimString();
            transfer.FromLocationId = ddlFromLocation.SelectedValue.ToInt();
            transfer.ToLocationId = ddlToLocation.SelectedValue.ToInt();
            transfer.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var transferId = _inventory.CreateStockTransfer(transfer, out rMessage);

            if (rMessage != string.Empty || transferId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("transfer-form.aspx?id={0}", transferId));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateStockTransfer();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("transfer-list.aspx"));
        }
    }
}