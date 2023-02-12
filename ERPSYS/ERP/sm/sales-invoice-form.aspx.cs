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
using ERPSYS.Controls.HierarchyItems.SM.SalesInvoice;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceForm : Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        public SalesInvoiceForm()
        {
            GetMaster = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgSalesInvoice, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                GetItemLookupTables();

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
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

            ddlCurrencyView.DataTextField = "Description";
            ddlCurrencyView.DataValueField = "CurrencyId";
            ddlCurrencyView.DataSource = lookup.GetCurrency();
            ddlCurrencyView.DataBind();
            ddlCurrencyView.SelectedValue = UserSession.CurrencyId.ToString();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetSalesLocation();
            ddlLocation.DataBind();

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
        }

        protected void GetSalesInvoice(int invoiceId)
        {
            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoiceId;
            lblInvoiceNumber.Text = invoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = invoice.Status.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = invoice.InvoiceDate;
            UCCustomerList.CustomerId = invoice.CustomerId;
            UCCustomerList.CustomerName = invoice.CustomerName;
            txtCustomerPO.Text = invoice.PurchaseOrder;
            txtProjectName.Text = invoice.ProjectName;
            ddlLocation.SelectedValue = invoice.LocationId.ToString();
            ddlPaymentMethod.SelectedValue = invoice.PaymentMethodId.ToString();
            ddlPaymentTerms.SelectedValue = invoice.PaymentTermsId.ToString();
            ddlCurrencyView.SelectedValue = invoice.CurrencyIdView.ToString();
            txtRemarks.Text = invoice.Remarks;

            txtExpenses.Text = invoice.Expenses.ToDecimalFormat();
            txtDiscount.Text = invoice.Discount.ToDecimalFormat();
            Tax = invoice.Tax;
            cbIgnoreTax.Checked = invoice.Tax == 0;

            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = invoice.Tax.ToDecimalFormat();
            }
        }

        protected List<SalesInvoiceLine> GetSalesInvoiceLines(int invoiceId)
        {
            List<SalesInvoiceLine> salesInvoiceItems = _invoice.GetSalesInvoiceMainLines(invoiceId);
            SubTotal = salesInvoiceItems.Where(s => s.ParentId == -1).Sum(s => s.TotalPrice).ToDecimal();
            return salesInvoiceItems;
        }

        protected void rgSalesInvoice_PreRender(object sender, EventArgs e)
        {
            if (GetMaster)
            {
                BindData();
            }

            if (NewMainLineId > 0)
            {
                foreach (GridDataItem item in rgSalesInvoice.MasterTableView.Items)
                {
                    if (item["ParentId"].Text.ToInt() == -1 && item.GetDataKeyValue("ItemId").ToInt() == -1 && item.GetDataKeyValue("LineId").ToInt() == NewMainLineId)
                    {
                        item.Expanded = true;
                        NewMainLineId = -1;
                    }
                }
            }
        }

        protected void rgSalesInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && InvoiceId > 0)
            {
                rgSalesInvoice.DataSource = GetSalesInvoiceLines(InvoiceId);
                txtSubTotal.Text = SubTotal.ToDecimalFormat();

                UpdateTotalSummary();
            }
        }

        protected void rgSalesInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int invoiceLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _invoice.GetSalesInvoiceSubLine(InvoiceId, invoiceLineId);
                        break;
                    }
            }
        }

        protected void rgSalesInvoice_ItemDataBound(object sender, GridItemEventArgs e)
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

            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                if (dataItem["IsLowMinPrice"].Text.ToInt() == 1)
                {
                    dataItem.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void rgSalesInvoice_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item.OwnerTableView.Name == "MainItem")
            {
                if (e.CommandName == RadGrid.ExpandCollapseCommandName)
                // only one row expand at the same time (remove it for multi expand rows at same time )
                {
                    //foreach (GridItem item in e.Item.OwnerTableView.Items)
                    //{
                    //    if (item.Expanded && item != e.Item)
                    //    {
                    //        item.Expanded = false;
                    //    }
                    //}
                }
                else if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    rgSalesInvoice.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesInvoice/UCMainItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                }

                else if (e.CommandName == RadGrid.EditCommandName)
                {
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesInvoice/UCMainItemEdit.ascx";
                }
            }

            else if (e.Item.OwnerTableView.Name == "SubItems")
            {
                if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    rgSalesInvoice.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesInvoice/UCSubItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                }

                else if (e.CommandName == RadGrid.EditCommandName)
                {
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/SalesInvoice/UCSubItemEdit.ascx";
                }
            }
        }

        protected void rgSalesInvoice_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void rgSalesInvoice_InsertCommand(object sender, GridCommandEventArgs e)
        {
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
                    bool isSpecialRecord = ((UCMainItemAdd)uc).IsSpecialRecord;
                    int locationId = ((UCMainItemAdd)uc).LocationId;


                    AddInvoiceMainLine(itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount, isSpecialRecord, locationId);
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
                    bool isSpecialRecord = ((UCSubItemAdd)uc).IsSpecialRecord;
                    int locationId = ((UCSubItemAdd)uc).LocationId;

                    AddInvoiceSubLine(parentId, itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount, isSpecialRecord, locationId);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesInvoice_UpdateCommand(object sender, GridCommandEventArgs e)
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
                    bool isSpecialRecord = ((UCMainItemEdit)uc).IsSpecialRecord;
                    int locationId = ((UCMainItemEdit)uc).LocationId;

                    UpdateOrderMainLine(lineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount, isSpecialRecord, locationId);
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
                    bool isSpecialRecord = ((UCSubItemEdit)uc).IsSpecialRecord;
                    int locationId = ((UCSubItemEdit)uc).LocationId;

                    UpdateInvoiceSubLine(parentId, lineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount, isSpecialRecord, locationId);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesInvoice_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();

                    DeleteInvoiceMainLine(lineId);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                    DeleteInvoiceSubLine(parentId, lineId, itemId);
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddInvoiceMainLine(int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isSpecialRecord, int locationId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
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
            line.IsSpecialRecord = isSpecialRecord;
            line.LocationId = locationId;

            if (!line.IsSpecialRecord)
            {
                line.LocationId = ddlLocation.SelectedValue.ToInt();
            }

            string rMessage;
            NewMainLineId = _invoice.AddMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
        }

        protected void UpdateOrderMainLine(int lineId, int itemId, string description, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isSpecialRecord, int locationId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
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
            line.IsSpecialRecord = isSpecialRecord;
            line.LocationId = locationId;

            if (!line.IsSpecialRecord)
            {
                line.LocationId = ddlLocation.SelectedValue.ToInt();
            }

            string rMessage;
            _invoice.UpdateMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
        }

        protected void DeleteInvoiceMainLine(int lineId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
            line.LineId = lineId;

            string rMessage;
            _invoice.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Product");
        }

        protected void AddInvoiceSubLine(int parentId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isSpecialRecord, int locationId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
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
            line.IsSpecialRecord = isSpecialRecord;
            line.LocationId = locationId;

            if (!line.IsSpecialRecord)
            {
                line.LocationId = ddlLocation.SelectedValue.ToInt();
            }

            string rMessage;
            _invoice.AddSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
            GetMaster = true;
        }

        protected void UpdateInvoiceSubLine(int parentId, int lineId, int itemId, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isSpecialRecord, int locationId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
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
            line.IsSpecialRecord = isSpecialRecord;
            line.LocationId = locationId;

            if (!line.IsSpecialRecord)
            {
                line.LocationId = ddlLocation.SelectedValue.ToInt();
            }

            string rMessage;
            _invoice.UpdateSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            GetMaster = true;
        }

        protected void DeleteInvoiceSubLine(int parentId, int lineId, int itemId)
        {
            SalesInvoiceLine line = new SalesInvoiceLine();

            line.InvoiceId = InvoiceId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _invoice.DeleteSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
            GetMaster = true;
        }

        private void BindData()
        {
            rgSalesInvoice.Rebind();
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
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
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
            _invoice.UpdateSalesInvoiceSummary(InvoiceId, txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), Tax, out rMessage);

            if (rMessage != string.Empty || InvoiceId <= 0)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            BindData();

            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdateSalesInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceId = InvoiceId;
            invoice.CustomerId = UCCustomerList.CustomerId;
            invoice.PurchaseOrder = txtCustomerPO.Text.ToTrimString();
            invoice.ProjectName = txtProjectName.Text.ToTrimString();
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            invoice.CurrencyIdView = ddlCurrencyView.SelectedValue.ToInt();

            string rMessage;
            _invoice.UpdateSalesInvoiceHeader(invoice, out rMessage);

            if (rMessage != string.Empty || InvoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Sales Invoice updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateSalesInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", InvoiceId), false);
        }

        //************************************** Properties ************************************//

        private int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
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