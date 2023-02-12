using System;
using System.Threading;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.SCM.GoodsReceipt;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptForm : Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();
        readonly LookupBLL _lookup = new LookupBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                radAjaxManager.AjaxSettings.AddAjaxSetting(rgGoodReceipt, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetGoodsReceiptNote(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
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

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = _lookup.GetLocation();
            ddlLocation.DataBind();
        }

        protected void GetGoodsReceiptNote(int goodsReceiptId)
        {
            GoodsReceipt goodsReceipt = _scm.GetGoodsReceiptNoteHeader(goodsReceiptId);

            if (goodsReceipt.GoodsReceiptId <= 0)
            {
                Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
            }

            GoodsReceiptId = goodsReceipt.GoodsReceiptId;
            lblGoodsReceiptStatus.Text = goodsReceipt.Status;
            lblGoodsReceiptNumber.Text = goodsReceipt.ReceiptNumber.ReplaceWhenNullOrEmpty("N/A"); 
            UCDate.DateValue = goodsReceipt.ReceiptDate;
            UCSupplier.SupplierId = goodsReceipt.SupplierId;
            UCSupplier.SupplierName = goodsReceipt.SupplierName;
            //txtSupplierInvoice.Text = goodsReceipt.SupplierInvoiceNumber;
            ddlLocation.SelectedValue = goodsReceipt.LocationId.ToString();
            cbConsignedGoods.Checked = goodsReceipt.IsConsignedGoods;
            txtRemarks.Text = goodsReceipt.Remarks;

            if (goodsReceipt.IsConsignedGoods)
            {
                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = _lookup.GetGoodsConsignedLocation();
                ddlLocation.DataBind();

                ddlLocation.SelectedValue = goodsReceipt.LocationId.ToString();
            }
        }

        protected void rgGoodReceipt_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgGoodReceipt.DataSource = _scm.GetGoodsReceiptNoteLines(GoodsReceiptId);
        }

        protected void rgGoodReceipt_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgGoodReceipt.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/GoodsReceipt/UCItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/GoodsReceipt/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgGoodReceipt_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int itemId = ((UCItemAdd)uc).ItemId;
                decimal quantity = ((UCItemAdd)uc).Quantity;
                int uomId = ((UCItemAdd)uc).UomId;
                string remarks = ((UCItemAdd)uc).Remarks;

                AddLine(itemId, quantity, uomId, remarks);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgGoodReceipt_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;
                int uomId = ((UCItemEdit)uc).UomId;
                string remarks = ((UCItemEdit)uc).Remarks;

                UpdateLine(lineId, itemId, quantity, uomId, remarks);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgGoodReceipt_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                DeleteLine(lineId, itemId);
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddLine(int itemId, decimal quantity, int uomId, string remarks)
        {
            GoodsReceiptLine line = new GoodsReceiptLine();

            line.GoodsReceiptId = GoodsReceiptId;
            line.ItemId = itemId;
            line.Quantity = quantity;
            line.UomId = uomId;
            line.Remarks = remarks;

            string rMessage;
            _scm.AddGoodsReceiptLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
            }
        }

        protected void UpdateLine(int lineId, int itemId, decimal quantity, int uomId, string remarks)
        {
            GoodsReceiptLine line = new GoodsReceiptLine();

            line.GoodsReceiptId = GoodsReceiptId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.Quantity = quantity;
            line.UomId = uomId;
            line.Remarks = remarks;

            string rMessage;
            _scm.UpdateGoodsReceiptLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteLine(int lineId, int itemId)
        {
            GoodsReceiptLine line = new GoodsReceiptLine();

            line.GoodsReceiptId = GoodsReceiptId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _scm.DeleteGoodsReceiptLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
            }
        }

        protected void UpdateGoodsReceiptNote()
        {
            GoodsReceipt goodsReceipt = new GoodsReceipt();

            goodsReceipt.GoodsReceiptId = GoodsReceiptId;
            goodsReceipt.ReceiptDate = UCDate.DateValue;
            goodsReceipt.SupplierId = UCSupplier.SupplierId;
            goodsReceipt.SupplierName = UCSupplier.SupplierName.ToTrimString();
            //goodsReceipt.SupplierInvoiceNumber = txtSupplierInvoice.Text.ToTrimString();
            goodsReceipt.LocationId = ddlLocation.SelectedValue.ToInt();
            goodsReceipt.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _scm.UpdateGoodsReceiptNoteHeader(goodsReceipt, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Material Receipt information has been updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateGoodsReceiptNote();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("goods-Receipt-preview.aspx?id={0}", GoodsReceiptId), false);
        }

        //************************************** Properties ************************************//

        private int GoodsReceiptId
        {
            get { return ViewState["GoodsReceiptId"] != null ? ViewState["GoodsReceiptId"].ToInt() : -1; }
            set { ViewState["GoodsReceiptId"] = value; }
        }
    }
}