using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Controls.HierarchyItems.SM.DeliveryReceipt;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.sm
{
    public partial class DeliveryReceiptAdjustment : Page
    {
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(gvDeliveryReceipt, (UCNotification)Master.FindControl("NotificationBox"));
                raManager.AjaxSettings.AddAjaxSetting(gvDeliveryReceipt, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetDeliveryReceipt(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
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

        protected void GetDeliveryReceipt(int receiptId)
        {
            DeliveryReceipt deliveryRcpt = _delivery.GetDeliveryReceiptHeader(receiptId);

            if (deliveryRcpt.ReceiptId <= 0)
            {
                Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
            }

            ReceiptId = receiptId;
            lblReceiptNumber.Text = deliveryRcpt.ReceiptNumber.ReplaceWhenNullOrEmpty("N/A");
            lblReceiptStatus.Text = deliveryRcpt.Status.ReplaceWhenNullOrEmpty("N/A");
            lblCustomerPO.Text = deliveryRcpt.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = deliveryRcpt.CustomerName;
            if (deliveryRcpt.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", deliveryRcpt.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblLocation.Text = deliveryRcpt.Location;
            lblReceiptDate.Text = deliveryRcpt.ReceiptDate.ReplaceDateWhenNullOrEmpty("N/A");

            hlnkSalesOrderNumber.Text = deliveryRcpt.SalesOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (deliveryRcpt.SalesOrderId > 0)
            {
                hlnkSalesOrderNumber.NavigateUrl = string.Format("sales-order-preview.aspx?id={0}", deliveryRcpt.SalesOrderId);
                hlnkSalesOrderNumber.Enabled = true;
            }

            hlnkSalesInvoiceNumber.Text = deliveryRcpt.SalesInvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            if (deliveryRcpt.SalesInvoiceId > 0)
            {
                hlnkSalesInvoiceNumber.NavigateUrl = string.Format("sales-invoice-preview.aspx?id={0}", deliveryRcpt.SalesInvoiceId);
                hlnkSalesInvoiceNumber.Enabled = true;
            }

            lblRemarks.Text = deliveryRcpt.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = deliveryRcpt.ProjectName.ReplaceWhenNullOrEmpty("N/A");
        }

        protected List<DeliveryReceiptLine> GetDeliveryReceiptLines(int orderId)
        {
            List<DeliveryReceiptLine> salesOrderItems = _delivery.GetDeliveryReceiptMainLines(orderId);
            return salesOrderItems;
        }

        protected void gvDeliveryReceipt_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in gvDeliveryReceipt.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();
                    if (itemId != -1) continue;
                    item.Cells[15].Enabled = false;
                    item.Cells[15].Text = string.Empty;
                }
            }
        }

        protected void gvDeliveryReceipt_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && ReceiptId > 0)
            {
                gvDeliveryReceipt.DataSource = GetDeliveryReceiptLines(ReceiptId);
            }
        }

        protected void gvDeliveryReceipt_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int orderLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _delivery.GetDeliveryReceiptSubLine(ReceiptId, orderLineId);
                        break;
                    }
            }
        }

        protected void gvDeliveryReceipt_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "MainItem")
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item["ItemId"].Text.ToInt() == -1)
                {
                    //item.Font.Bold = true;
                }
                else if (item.GetDataKeyValue("ItemId").ToInt() > 0)
                {
                    TableCell cell = (e.Item as GridDataItem)["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                }
            }
        }

        protected void gvDeliveryReceipt_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.Item.OwnerTableView.Name)
            {
                case "MainItem":
                    switch (e.CommandName)
                    {
                        case RadGrid.ExpandCollapseCommandName:
                            foreach (GridItem item in e.Item.OwnerTableView.Items)
                            {
                                if (item.Expanded && item != e.Item)
                                {
                                    item.Expanded = false;
                                }
                            }
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/DeliveryReceipt/UCMainItemAdjust.ascx";
                            break;
                    }
                    break;
                case "SubItems":
                    switch (e.CommandName)
                    {
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/DeliveryReceipt/UCSubItemAdjust.ascx";
                            break;
                    }
                    break;
            }
        }

        protected void gvDeliveryReceipt_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                    int locationId = ((UCMainItemAdjust)uc).LocationId;

                    UpdateDeliveryReceiptLine(lineId, itemId, locationId);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                    int locationId = ((UCSubItemAdjust)uc).LocationId;

                    UpdateDeliveryReceiptLine(lineId, itemId, locationId);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void gvDeliveryReceipt_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();

                    DeleteDeliveryMainLine(lineId);
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateDeliveryReceiptLine(int lineId, int itemId, int locationId)
        {
            DeliveryReceiptLine line = new DeliveryReceiptLine();

            line.ReceiptId = ReceiptId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.LocationId = locationId;

            string rMessage;
            _delivery.UpdateDeliveryReceiptLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                //AppNotification.MessageBoxFailed(rMessage);
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                //AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"));
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteDeliveryMainLine(int lineId)
        {
            DeliveryReceiptLine line = new DeliveryReceiptLine();

            line.ReceiptId = ReceiptId;
            line.LineId = lineId;

            string rMessage;
            _delivery.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                //AppNotification.MessageBoxFailed(rMessage);
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
               // AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"));
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");

            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("delivery-receipt-preview.aspx?id={0}", ReceiptId), false);
        }

        //************************************** Properties ************************************//

        public int ReceiptId
        {
            get { return ViewState["ReceiptId"] != null ? ViewState["ReceiptId"].ToInt() : -1; }
            set { ViewState["ReceiptId"] = value; }
        }
    }
}