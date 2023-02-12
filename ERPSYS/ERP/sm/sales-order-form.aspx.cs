using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.SM.SalesOrder;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderForm : Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

        public SalesOrderForm()
        {
            GetMaster = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgSalesOrder, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(btnApplyChanges, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1), false);
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

        protected void GetSalesOrder(int orderId)
        {
            SalesOrder order = _order.GetSalesOrderHeader(orderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1));
            }

            SalesOrderId = orderId;
            lblOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = order.OrderDate;
            UCCustomer.CustomerId = order.CustomerId;
            UCCustomer.CustomerName = order.CustomerName;
            txtCustomerPO.Text = order.PurchaseOrder;
            txtProjectName.Text = order.ProjectName;
            txtRemarks.Text = order.Remarks;

            txtDiscount.Text = order.Discount.ToDecimalFormat();
            Tax = order.Tax;
            cbIgnoreTax.Checked = order.Tax == 0;

            if (SystemProperties.HasSalesTax || order.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = order.Tax.ToDecimalFormat();
            }
        }

        protected List<SalesOrderLine> GetSalesOrderLines(int orderId)
        {
            List<SalesOrderLine> salesOrderItems = _order.GetSalesOrderMainLines(orderId);
            SubTotal = salesOrderItems.Where(s => s.ParentId == -1).Sum(s => s.TotalPrice).ToDecimal(); 
            return salesOrderItems;
        }

        protected void rgSalesOrder_PreRender(object sender, EventArgs e)
        {
            if (GetMaster)
            {
                BindData();
            }

            if (NewMainLineId > 0)
            {
                foreach (GridDataItem item in rgSalesOrder.MasterTableView.Items)
                {
                    if (item["ParentId"].Text.ToInt() == -1 && item.GetDataKeyValue("ItemId").ToInt() == -1 && item.GetDataKeyValue("LineId").ToInt() == NewMainLineId)
                    {
                        item.Expanded = true;
                        NewMainLineId = -1;
                    }
                }
            }
        }

        protected void rgSalesOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && SalesOrderId > 0)
            {
                rgSalesOrder.DataSource = GetSalesOrderLines(SalesOrderId);
                txtSubTotal.Text = SubTotal.ToDecimalFormat();

                UpdateTotalSummary();
            }
        }

        protected void rgSalesOrder_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int orderLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _order.GetSalesOrderSubLine(SalesOrderId, orderLineId);
                        break;
                    }
            }
        }

        protected void rgSalesOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "MainItem")
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item.GetDataKeyValue("ItemId").ToInt() > 0)
                {
                    TableCell cell = (e.Item as GridDataItem)["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                }
            }
        }

        protected void rgSalesOrder_ItemCommand(object sender, GridCommandEventArgs e)
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
                        case RadGrid.InitInsertCommandName:
                            e.Canceled = true;
                            rgSalesOrder.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesOrder/UCMainItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesOrder/UCMainItemEdit.ascx";
                            break;
                        case "Up":
                            MoveUp(((GridDataItem)(e.Item)).GetDataKeyValue("LineId").ToInt(), ((GridDataItem)(e.Item)).GetDataKeyValue("LineSeqId").ToInt());
                            break;
                        case "Down":
                            MoveDown(((GridDataItem)(e.Item)).GetDataKeyValue("LineId").ToInt(), ((GridDataItem)(e.Item)).GetDataKeyValue("LineSeqId").ToInt());
                            break;
                    }
                    break;
                case "SubItems":
                    switch (e.CommandName)
                    {
                        case RadGrid.InitInsertCommandName:
                            e.Canceled = true;
                            rgSalesOrder.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesOrder/UCSubItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesOrder/UCSubItemEdit.ascx";
                            break;
                    }
                    break;
            }
        }

        protected void rgSalesOrder_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void rgSalesOrder_InsertCommand(object sender, GridCommandEventArgs e)
        {
            //GridEditableItem iItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int itemId = ((UCMainItemAdd)uc).ItemId;
                    string itemCode = ((UCMainItemAdd)uc).ItemCode;
                    string partNumber = ((UCMainItemAdd)uc).PartNumber;
                    string description = ((UCMainItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemAdd)uc).Quantity;
                    decimal unitPrice = ((UCMainItemAdd)uc).UnitPrice;
                    decimal profit = ((UCMainItemAdd)uc).Profit;
                    decimal discount = ((UCMainItemAdd)uc).Discount;
                    bool isPercentDiscount = ((UCMainItemAdd)uc).IsPercentDiscount;

                    AddOrderMainLine(itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

                    int itemId = ((UCSubItemAdd)uc).ItemId;
                    string itemCode = ((UCSubItemAdd)uc).ItemCode;
                    string partNumber = ((UCSubItemAdd)uc).PartNumber;
                    string description = ((UCSubItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCSubItemAdd)uc).Quantity;
                    decimal unitPrice = ((UCSubItemAdd)uc).UnitPrice;
                    decimal profit = ((UCSubItemAdd)uc).Profit;
                    decimal discount = ((UCSubItemAdd)uc).Discount;
                    bool isPercentDiscount = ((UCSubItemAdd)uc).IsPercentDiscount;

                    AddOrderSubLine(parentId, itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesOrder_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = ((UCMainItemEdit)uc).ItemId;
                    string description = ((UCMainItemEdit)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemEdit)uc).Quantity;
                    decimal unitPrice = ((UCMainItemEdit)uc).UnitPrice;
                    decimal profit = ((UCMainItemEdit)uc).Profit;
                    decimal discount = ((UCMainItemEdit)uc).Discount;
                    bool isPercentDiscount = ((UCMainItemEdit)uc).IsPercentDiscount;

                    UpdateOrderMainLine(lineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                    string description = ((UCSubItemEdit)uc).DescriptionAs;
                    decimal quantity = ((UCSubItemEdit)uc).Quantity;
                    decimal unitPrice = ((UCSubItemEdit)uc).UnitPrice;
                    decimal profit = ((UCSubItemEdit)uc).Profit;
                    decimal discount = ((UCSubItemEdit)uc).Discount;
                    bool isPercentDiscount = ((UCSubItemEdit)uc).IsPercentDiscount;

                    UpdateOrderSubLine(parentId, lineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesOrder_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();

                    DeleteOrderMainLine(lineId);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                    DeleteOrderSubLine(parentId, lineId, itemId);
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddOrderMainLine(int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            NewMainLineId = _order.AddMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");

            }
        }

        protected void UpdateOrderMainLine(int lineId, int itemId, string description, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.DescriptionAs = description;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _order.UpdateMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");

            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteOrderMainLine(int lineId)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.LineId = lineId;

            string rMessage;
            _order.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Product");
            }
        }

        protected void AddOrderSubLine(int parentId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.ParentId = parentId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _order.AddSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
                GetMaster = true;
            }
        }

        protected void UpdateOrderSubLine(int parentId, int lineId, int itemId, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {

            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _order.UpdateSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
                GetMaster = true;
            }
        } 

        protected void DeleteOrderSubLine(int parentId, int lineId, int itemId)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _order.DeleteSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
                GetMaster = true;
            }
        }

        protected void MoveUp(int lineId, int lineSeqId)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.LineId = lineId;
            line.LineSeqId = lineSeqId;

            string rMessage;
            _order.MoveLineUp(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }

            GetMaster = true;
        }

        protected void MoveDown(int lineId, int lineSeqId)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.LineId = lineId;
            line.LineSeqId = lineSeqId;

            string rMessage;
            _order.MoveLineDown(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }

            GetMaster = true;
        }

        private void BindData()
        {
            rgSalesOrder.Rebind();
        }

        protected void cbIgnoreTax_CheckedChanged(object sender, EventArgs e)
        {
            Tax = cbIgnoreTax.Checked ? 0 : SystemProperties.SalesTaxValue.ToDecimal();
            lblSalesTaxValue.Text = Tax.ToDecimalFormat();

            UpdateTotalSummary();
        }

        void UpdateTotalSummary()
        {
            try
            {
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                //txtSubTotal.Text = SubTotal.ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
            }
            catch (Exception ex)
            {
                AppNotification.MessagePanelFailed(ex.ToString(), "Failed");
            }
        }

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            string rMessage;
            _order.UpdateSalesOrderSummary(SalesOrderId, 0, txtDiscount.Text.ToDecimal(), Tax, out rMessage);

            if (rMessage != string.Empty || SalesOrderId <= 0)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            BindData();

            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdateSalesOrderHeader()
        {
            SalesOrder order = new SalesOrder();

            order.OrderId = SalesOrderId;
            order.CustomerId = UCCustomer.CustomerId;
            order.PurchaseOrder = txtCustomerPO.Text.ToTrimString();
            order.ProjectName = txtProjectName.Text.ToTrimString();
            order.OrderDate = UCDatePicker.DateValue;
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _order.UpdateSalesOrderHeader(order, out rMessage);

            if (rMessage != string.Empty || SalesOrderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_update_success"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateSalesOrderHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-order-preview.aspx?id={0}", SalesOrderId), false);
        }

        //************************************** Properties ************************************//

        private int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }

        private bool GetMaster { get; set; }

        private decimal SubTotal { get; set; }

        private int NewMainLineId
        {
            get { return ViewState["NewMainItemId"] != null ? ViewState["NewMainItemId"].ToInt() : -1; }
            set { ViewState["NewMainItemId"] = value; }
        }

        private decimal Tax
        {
            get { return ViewState["Tax"] != null ? ViewState["Tax"].ToDecimal() : 0; }
            set { ViewState["Tax"] = value; }
        }
    }
}