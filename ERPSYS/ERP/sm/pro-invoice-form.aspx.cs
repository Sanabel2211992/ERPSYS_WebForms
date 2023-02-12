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
using ERPSYS.Controls.HierarchyItems.SM.ProformaInvoice;

namespace ERPSYS.ERP.sm
{
    public partial class ProformaInvoiceForm : Page
    {
        readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();

        public ProformaInvoiceForm()
        {
            GetMaster = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgProInvoice, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetProformaInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
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

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
        }

        protected void GetProformaInvoice(int invoiceId)
        {
            ProformaInvoice invoice = _invoice.GetProformaInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoiceId;
            lblStatus.Text = invoice.Status.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = invoice.InvoiceDate;
            UCCustomerList.CustomerId = invoice.CustomerId;
            UCCustomerList.CustomerName = invoice.CustomerName;
            txtProjectName.Text = invoice.ProjectName;
            lblInvoiceNumber.Text = invoice.InvoiceNumber;
            ddlPaymentMethod.SelectedValue = invoice.PaymentMethodId.ToString();
            ddlPaymentTerms.SelectedValue = invoice.PaymentTermsId.ToString();
            txtRemarks.Text = invoice.Remarks;

            txtDiscount.Text = invoice.Discount.ToDecimalFormat();
            Tax = invoice.Tax;
            cbIgnoreTax.Checked = invoice.Tax == 0;

            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = invoice.Tax.ToDecimalFormat();
            }
        }

        protected List<ProformaInvoiceLine> GetProInvoiceLines(int invoiceId)
        {
            List<ProformaInvoiceLine> proInvoiceItems = _invoice.GetProformaInvoiceMainLines(invoiceId);
            SubTotal = proInvoiceItems.Where(s => s.ParentId == -1).Sum(s => s.TotalPrice).ToDecimal();
            return proInvoiceItems;
        }

        protected void rgProInvoice_PreRender(object sender, EventArgs e)
        {
            if (GetMaster)
            {
                BindData();
            }

            if (NewMainLineId > 0)
            {
                foreach (GridDataItem item in rgProInvoice.MasterTableView.Items)
                {
                    if (item["ParentId"].Text.ToInt() == -1 && item.GetDataKeyValue("ItemId").ToInt() == -1 && item.GetDataKeyValue("LineId").ToInt() == NewMainLineId)
                    {
                        item.Expanded = true;
                        NewMainLineId = -1;
                    }
                }
            }
        }

        protected void rgProInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && InvoiceId > 0)
            {
                rgProInvoice.DataSource = GetProInvoiceLines(InvoiceId);
                txtSubTotal.Text = SubTotal.ToDecimalFormat();

                UpdateTotalSummary();
            }
        }

        protected void rgProInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int invoiceLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _invoice.GetProformaInvoiceSubLine(InvoiceId, invoiceLineId);
                        break;
                    }
            }
        }

        protected void rgProInvoice_ItemDataBound(object sender, GridItemEventArgs e)
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

        protected void rgProInvoice_ItemCommand(object sender, GridCommandEventArgs e)
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
                            rgProInvoice.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/ProformaInvoice/UCMainItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/ProformaInvoice/UCMainItemEdit.ascx";
                            break;
                    }
                    break;
                case "SubItems":
                    switch (e.CommandName)
                    {
                        case RadGrid.InitInsertCommandName:
                            e.Canceled = true;
                            rgProInvoice.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/ProformaInvoice/UCSubItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/ProformaInvoice/UCSubItemEdit.ascx";
                            break;
                    }
                    break;
            }
        }

        protected void rgProInvoice_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void rgProInvoice_InsertCommand(object sender, GridCommandEventArgs e)
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

                    AddInvoiceMainLine(itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
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

                    AddInvoiceSubLine(parentId, itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProInvoice_UpdateCommand(object sender, GridCommandEventArgs e)
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

                    UpdateInvoiceSubLine(parentId, lineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgProInvoice_DeleteCommand(object sender, GridCommandEventArgs e)
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

        protected void AddInvoiceMainLine(int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            ProformaInvoiceLine line = new ProformaInvoiceLine();

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

            string rMessage;
            NewMainLineId = _invoice.AddMainLine(line, out rMessage);

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
            ProformaInvoiceLine line = new ProformaInvoiceLine();

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

            string rMessage;
            _invoice.UpdateMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteInvoiceMainLine(int lineId)
        {
            ProformaInvoiceLine line = new ProformaInvoiceLine();

            line.InvoiceId = InvoiceId;
            line.LineId = lineId;

            string rMessage;
            _invoice.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Product");
            }
        }

        protected void AddInvoiceSubLine(int parentId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            ProformaInvoiceLine line = new ProformaInvoiceLine();

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

            string rMessage;
            _invoice.AddSubLine(line, out rMessage);

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

        protected void UpdateInvoiceSubLine(int parentId, int lineId, int itemId, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            ProformaInvoiceLine line = new ProformaInvoiceLine();

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

            string rMessage;
            _invoice.UpdateSubLine(line, out rMessage);

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

        protected void DeleteInvoiceSubLine(int parentId, int lineId, int itemId)
        {
            ProformaInvoiceLine line = new ProformaInvoiceLine();

            line.InvoiceId = InvoiceId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _invoice.DeleteSubLine(line, out rMessage);

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

        private void BindData()
        {
            rgProInvoice.Rebind();
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
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            string rMessage;
            _invoice.UpdateProformaInvoiceSummary(InvoiceId, 0, txtDiscount.Text.ToDecimal(), Tax, out rMessage);

            if (rMessage != string.Empty || InvoiceId <= 0)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }

            BindData();

            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdateProformaInvoice()
        {
            ProformaInvoice invoice = new ProformaInvoice();

            invoice.InvoiceId = InvoiceId;
            invoice.CustomerId = UCCustomerList.CustomerId;
            invoice.ProjectName = txtProjectName.Text.ToTrimString();
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();

            string rMessage;
            _invoice.UpdateProformaInvoiceHeader(invoice, out rMessage);

            if (rMessage != string.Empty || InvoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Proforma Invoice updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateProformaInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("pro-invoice-preview.aspx?id={0}", InvoiceId), false);
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