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
using ERPSYS.Controls.HierarchyItems.SCM.PurchaseInvoice;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoiceForm : Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                radAjaxManager.AjaxSettings.AddAjaxSetting(rgPurchaseInvoice, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                radAjaxManager.AjaxSettings.AddAjaxSetting(btnApplyChanges, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetPurchaseInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
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

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();

            ddlCurrency.SelectedValue = UserSession.CurrencyId.ToString();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "Locationid";
            ddlLocation.DataSource = lookup.GetPurchaseInvoiceLocation();
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetPurchaseInvoice(int purchaseInvoiceId)
        {
            PurchaseInvoice purchaseInvoice = _scm.GetPurchaseInvoiceHeader(purchaseInvoiceId);

            if (purchaseInvoice.PurchaseInvoiceId <= 0)
            {
                Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
            }

            PurchaseInvoiceId = purchaseInvoice.PurchaseInvoiceId;
            lblPurchaseInvoiceNumber.Text = purchaseInvoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = purchaseInvoice.Status;
            UCSupplier.SupplierId = purchaseInvoice.SupplierId;
            UCSupplier.SupplierName = purchaseInvoice.SupplierName;
            ddlCurrency.SelectedValue = purchaseInvoice.CurrencyId.ToString();
            ddlLocation.SelectedValue = purchaseInvoice.LocationId.ToString();
            txtPurchaseOrderNumber.Text = purchaseInvoice.PurchaseOrderNumber;
            txtSupplierInvoice.Text = purchaseInvoice.SupplierInvoiceNumber;
            UCOrderDate.DateValue = purchaseInvoice.InvoiceDate;
            txtRemarks.Text = purchaseInvoice.Remarks;

            txtFreightExpenses.Text = purchaseInvoice.FreightExpenses.ToDecimalFormat(3);
            txtClearanceExpenses.Text = purchaseInvoice.ClearanceExpenses.ToDecimalFormat(3);
            txtOtherExpenses.Text = purchaseInvoice.OtherExpenses.ToDecimalFormat(3);
            txtOtherExpensesLocalCurrency.Text = purchaseInvoice.OtherExpensesLocalCurrency.ToDecimalFormat(3);
            txtSubTotal.Text = purchaseInvoice.SubTotal.ToDecimalFormat(3);
            txtDiscount.Text = purchaseInvoice.Discount.ToDecimalFormat(3);
            txtGrandTotal.Text = purchaseInvoice.GrandTotal.ToDecimalFormat(3);

            lblFreightExpensesCurrency.Text = purchaseInvoice.CurrencyCode;
            lblClearanceExpensesCurrency.Text = purchaseInvoice.LocalCurrencyCode;
            lblOtherExpenses.Text = purchaseInvoice.CurrencyCode;
            lblOtherExpensesLocalCurrency.Text = purchaseInvoice.LocalCurrencyCode;

            txtDiscount.Enabled = false;
        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int currencyId = ddlCurrency.SelectedValue.ToInt();
                if (currencyId > 0)
                {
                    CurrencyBLL currencyBll = new CurrencyBLL();
                    Currency currency = currencyBll.GetCurrency(currencyId);

                    lblFreightExpensesCurrency.Text = currency.Code;
                    lblOtherExpenses.Text = currency.Code;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPurchaseInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<PurchaseInvoiceLine> lines = _scm.GetPurchaseInvoiceLines(PurchaseInvoiceId);
            SubTotal = lines.Sum(s => s.TotalPrice).ToDecimal(3);
            rgPurchaseInvoice.DataSource = lines;
            UpdateTotalSummary();
        }

        protected void rgPurchaseInvoice_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgPurchaseInvoice.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/PurchaseInvoice/UCItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/PurchaseInvoice/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgPurchaseInvoice_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int itemId = ((UCItemAdd)uc).ItemId;
                string description = ((UCItemAdd)uc).Description;
                decimal quantity = ((UCItemAdd)uc).Quantity;
                decimal unitPrice = ((UCItemAdd)uc).UnitPrice;
                decimal discount = ((UCItemAdd)uc).Discount;
                bool isPercentDiscount = ((UCItemAdd)uc).IsPercentDiscount;
                int uomId = ((UCItemAdd)uc).UomId;

                AddLine(itemId, description, quantity, unitPrice, discount, isPercentDiscount, uomId);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPurchaseInvoice_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;
                decimal unitPrice = ((UCItemEdit)uc).UnitPrice;
                decimal discount = ((UCItemEdit)uc).Discount;
                bool isPercentDiscount = ((UCItemEdit)uc).IsPercentDiscount;
                int uomId = ((UCItemEdit)uc).UomId;

                UpdateLine(lineId, itemId, quantity, unitPrice, discount, isPercentDiscount, uomId);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPurchaseInvoice_DeleteCommand(object sender, GridCommandEventArgs e)
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

        protected void AddLine(int itemId, string description, decimal quantity, decimal unitPrice, decimal discount, bool isPercentDiscount, int uomId)
        {
            PurchaseInvoiceLine line = new PurchaseInvoiceLine();

            line.PurchaseInvoiceId = PurchaseInvoiceId;
            line.ItemId = itemId;
            line.Description = description;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Discount = discount;
            line.IsPercentDiscount = isPercentDiscount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Discount, line.IsPercentDiscount).ToDecimal(3);
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal(3);
            line.PurchaseUomId = uomId;

            string rMessage;
            _scm.AddPurchaseInvoiceLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
            }
        }

        protected void UpdateLine(int lineId, int itemId, decimal quantity, decimal unitPrice, decimal discount, bool isPercentDiscount, int uomId)
        {
            PurchaseInvoiceLine line = new PurchaseInvoiceLine();

            line.PurchaseInvoiceId = PurchaseInvoiceId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Discount = discount;
            line.IsPercentDiscount = isPercentDiscount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Discount, line.IsPercentDiscount).ToDecimal(3);
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal(3);
            line.PurchaseUomId = uomId;

            string rMessage;
            _scm.UpdatePurchaseInvoiceLine(line, out rMessage);

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
            PurchaseInvoiceLine line = new PurchaseInvoiceLine();

            line.PurchaseInvoiceId = PurchaseInvoiceId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _scm.DeletePurchaseInvoiceLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
            }
        }

        private void BindData()
        {
            rgPurchaseInvoice.Rebind();
        }

        void UpdateTotalSummary()
        {
            try
            {
                txtSubTotal.Text = SubTotal.ToDecimalFormat(3);
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(3), txtDiscount.Text.ToDecimal(3), false).ToDecimalFormat(3);
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
            _scm.UpdatePurchaseInvoiceSummary(PurchaseInvoiceId, txtDiscount.Text.ToDecimal(3), out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            BindData();

            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdatePurchaseInvoice()
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

            purchaseInvoice.PurchaseInvoiceId = PurchaseInvoiceId;
            purchaseInvoice.SupplierId = UCSupplier.SupplierId;
            purchaseInvoice.SupplierName = UCSupplier.SupplierName.ToTrimString();
            purchaseInvoice.CurrencyId = ddlCurrency.SelectedValue.ToInt();
            purchaseInvoice.LocationId = ddlLocation.SelectedValue.ToInt();
            purchaseInvoice.PurchaseOrderNumber = txtPurchaseOrderNumber.Text;
            purchaseInvoice.SupplierInvoiceNumber = txtSupplierInvoice.Text;
            purchaseInvoice.InvoiceDate = UCOrderDate.DateValue;
            purchaseInvoice.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _scm.UpdatePurchaseInvoiceHeader(purchaseInvoice, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Purchase Invoice information has been updated successfully");
        }

        protected void UpdatePurchaseInvoicePricing()
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

            purchaseInvoice.PurchaseInvoiceId = PurchaseInvoiceId;
            purchaseInvoice.FreightExpenses = txtFreightExpenses.Text.ToDecimal(3);
            purchaseInvoice.ClearanceExpenses = txtClearanceExpenses.Text.ToDecimal(3);
            purchaseInvoice.OtherExpenses = txtOtherExpenses.Text.ToDecimal(3);
            purchaseInvoice.OtherExpensesLocalCurrency = txtOtherExpensesLocalCurrency.Text.ToDecimal(3);

            string rMessage;
            _scm.UpdatePurchaseInvoicePricing(purchaseInvoice, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Purchase Invoice information has been updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;
                UpdatePurchaseInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnUpdatePricing_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;
                UpdatePurchaseInvoicePricing();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("purchase-invoice-preview.aspx?id={0}", PurchaseInvoiceId), false);
        }

        //************************************** Properties ************************************//

        private int PurchaseInvoiceId
        {
            get { return ViewState["PurchaseInvoiceId"] != null ? ViewState["PurchaseInvoiceId"].ToInt() : -1; }
            set { ViewState["PurchaseInvoiceId"] = value; }
        }

        private decimal SubTotal { get; set; }
    }
}