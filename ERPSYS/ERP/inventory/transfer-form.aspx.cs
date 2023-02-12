using System;
using System.Data;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.INV.StockTransfer;

namespace ERPSYS.ERP.inventory
{
    public partial class TransferForm : System.Web.UI.Page
    {
        readonly InventoryBLL _inventory = new InventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                ramInvoice.AjaxSettings.AddAjaxSetting(rgStockTransfer, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                ramInvoice.AjaxSettings.AddAjaxSetting(btnAddItem, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
            }

            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            try
            {
                GetItemLookupTables();

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetStockTransfer(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
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

        protected void GetStockTransfer(int transferId)
        {
            StockTransfer transfer = _inventory.GetStockTransferHeader(transferId);

            if (transfer.TransferId <= 0)
            {
                Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
            }

            TransferId = transferId;
            lblTransferNumber.Text = transfer.TransferNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = transfer.Status;
            txtTransferDescription.Text = transfer.TransferDescription;
            UCDatePicker.DateValue = transfer.TransferDate;
            txtJobOrderNumber.Text = transfer.JobOrderNumber;
            ddlFromLocation.SelectedValue = transfer.FromLocationId.ToString();
            ddlToLocation.SelectedValue = transfer.ToLocationId.ToString();
            txtRemarks.Text = transfer.Remarks;
        }

        protected void rgStockTransfer_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgStockTransfer.DataSource = _inventory.GetStockTransferLines(TransferId);
        }

        protected void UpdateStockTransfer()
        {

            if (ddlFromLocation.SelectedValue.ToInt() == ddlToLocation.SelectedValue.ToInt())
            {
                AppNotification.MessageBoxFailed("Please select a valid Stock and try again");
                return;
            }

            StockTransfer transfer = new StockTransfer();

            transfer.TransferId = TransferId;
            transfer.TransferDescription = txtTransferDescription.Text.ToTrimString();
            transfer.TransferDate = UCDatePicker.DateValue;
            transfer.JobOrderNumber = txtJobOrderNumber.Text.ToTrimString();
            transfer.FromLocationId = ddlFromLocation.SelectedValue.ToInt();
            transfer.ToLocationId = ddlToLocation.SelectedValue.ToInt();
            transfer.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _inventory.UpdateStockTransfer(transfer, out rMessage);

            if (rMessage != string.Empty || TransferId <= 0)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessageBoxSuccess("Information updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateStockTransfer();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                {
                    return;
                }

                int itemId = UCStockItem.ItemId;
                decimal quantity = UCStockItem.Quantity;

                if (itemId <= 0)
                {
                    AppNotification.MessagePanelWarning("Please select a valid Product", "Warning");
                    return;
                }

                AddLine(itemId, quantity);
                UCStockItem.ClearFields();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgStockTransfer_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            System.Web.UI.UserControl uc = (System.Web.UI.UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            int lineId = eItem.GetDataKeyValue("LineId").ToInt();
            int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
            decimal quantity = ((UCItemEdit)uc).Quantity;

            UpdateLine(lineId, itemId, quantity);
        }

        protected void rgStockTransfer_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));

            int lineId = eItem.GetDataKeyValue("LineId").ToInt();
            int itemId = eItem.GetDataKeyValue("ItemId").ToInt();

            DeleteLine(lineId, itemId);
        }

        protected void AddLine(int itemId, decimal quantity)
        {
            StockTransferLine line = new StockTransferLine();

            line.TransferId = TransferId;
            line.ItemId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _inventory.AddStockTransferLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("item_add_success"), "Add Product");
                rgStockTransfer.Rebind();
            }
        }

        protected void UpdateLine(int lineId, int itemId, decimal quantity)
        {
            StockTransferLine line = new StockTransferLine();

            line.TransferId = TransferId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _inventory.UpdateStockTransferLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("item_update_success"), "Update Product");
            }
        }

        protected void DeleteLine(int lineId,  int itemId)
        {
            StockTransferLine line = new StockTransferLine();

            line.TransferId = TransferId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _inventory.DeleteStockTransferLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("items_delete_success"), "Delete Product ");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("transfer-preview.aspx?id={0}", TransferId), false);
        }

        //************************************** Properties ************************************//

        private int TransferId
        {
            get { return ViewState["TransferId"] != null ? ViewState["TransferId"].ToInt() : -1; }
            set { ViewState["TransferId"] = value; }
        }
    }
}