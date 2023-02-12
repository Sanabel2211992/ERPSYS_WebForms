using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.SCM.PurchaseOrder;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderForm : Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                radAjaxManager.AjaxSettings.AddAjaxSetting(rgPurchaseOrder, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetPurchaseOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
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

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();
        }

        protected void GetPurchaseOrder(int purchaseOrderId)
        {
            PurchaseOrder purchaseOrder = _scm.GetPurchaseOrderHeader(purchaseOrderId);

            if (purchaseOrder.PurchaseOrderId <= 0)
            {
                Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
            }

            PurchaseOrderId = purchaseOrder.PurchaseOrderId;
            lblPurchaseOrderStatus.Text = purchaseOrder.Status;
            lblPurchaseOrderNumber.Text = purchaseOrder.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            UCOrderDate.DateValue = purchaseOrder.OrderDate;
            UCSupplier.SupplierId = purchaseOrder.SupplierId;
            UCSupplier.SupplierName = purchaseOrder.SupplierName;
            ddlPaymentTerms.SelectedValue = purchaseOrder.PaymentTermsId.ToString();
            UCSupplier.ContactName = purchaseOrder.ContactName;
            UCSupplier.Phone = purchaseOrder.Phone;
            UCSupplier.Address = purchaseOrder.SupplierAddress;
            txtShippingTo.Text = purchaseOrder.ShipToCompany;
            txtShippingToAddress.Text = purchaseOrder.ShipToAddress;
            txtSubTotal.Text = purchaseOrder.SubTotal.ToDecimalFormat(3);
            txtDiscount.Text = purchaseOrder.Discount.ToDecimalFormat(3);
            Tax = purchaseOrder.Tax;
            cbIgnoreTax.Checked = purchaseOrder.Tax == 0;
            //purchaseOrder.IsPercentDiscount = purchaseOrder.IsPercentDiscount;
            //purchaseOrder.GrandTotal = Calculation.GetGrandTotal(purchaseOrder.SubTotal, purchaseOrder.Discount, purchaseOrder.IsPercentDiscount).ToDecimal(); 
            ddlCurrency.SelectedValue = purchaseOrder.CurrencyId.ToString();
            txtRemarks.Text = purchaseOrder.Remarks;

            if (SystemProperties.HasSalesTax || purchaseOrder.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = purchaseOrder.Tax.ToDecimalFormat(3);
            }
        }

        protected void rgPurchaseOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<PurchaseOrderLine> purchaseOrderLines = _scm.GetPurchaseOrderLines(PurchaseOrderId);
            SubTotal = purchaseOrderLines.Sum(s => s.TotalPrice).ToDecimal(3);
            rgPurchaseOrder.DataSource = purchaseOrderLines;

            txtSubTotal.Text = SubTotal.ToDecimalFormat(3);
            UpdateTotalSummary();
        }

        protected void rgPurchaseOrder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgPurchaseOrder.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/PurchaseOrder/UCItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SCM/PurchaseOrder/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgPurchaseOrder_InsertCommand(object sender, GridCommandEventArgs e)
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
 
        protected void rgPurchaseOrder_UpdateCommand(object sender, GridCommandEventArgs e)
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

        protected void rgPurchaseOrder_DeleteCommand(object sender, GridCommandEventArgs e)
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
            PurchaseOrderLine line = new PurchaseOrderLine();

            line.PurchaseOrderId = PurchaseOrderId;
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
            _scm.AddPurchaseOrderLine(line, out rMessage);

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
            PurchaseOrderLine line = new PurchaseOrderLine();

            line.PurchaseOrderId = PurchaseOrderId;
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
            _scm.UpdatePurchaseOrderLine(line, out rMessage);

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
            PurchaseOrderLine line = new PurchaseOrderLine();

            line.PurchaseOrderId = PurchaseOrderId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _scm.DeletePurchaseOrderLine(line, out rMessage);

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
            rgPurchaseOrder.Rebind();
        }

        protected void cbIgnoreTax_CheckedChanged(object sender, EventArgs e)
        {
            Tax = cbIgnoreTax.Checked ? 0 : SystemProperties.SalesTaxValue.ToDecimal(3);
            lblSalesTaxValue.Text = Tax.ToDecimalFormat(3);

            UpdateTotalSummary();
        }

        protected void UpdateTotalSummary() 
        {
            try
            {
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(3), 0, txtDiscount.Text.ToDecimal(3), false, Tax).ToDecimalFormat(3);
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(3), 0, txtDiscount.Text.ToDecimal(3), false, Tax).ToDecimalFormat(3);
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
            _scm.UpdatePurchaseOrderSummary(PurchaseOrderId, txtDiscount.Text.ToDecimal(3), Tax, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            BindData();
            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdatePurchaseOrder()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();

            purchaseOrder.PurchaseOrderId = PurchaseOrderId;
            purchaseOrder.OrderDate = UCOrderDate.DateValue;
            purchaseOrder.SupplierId = UCSupplier.SupplierId;
            purchaseOrder.SupplierName = UCSupplier.SupplierName.ToTrimString();
            purchaseOrder.ContactName = UCSupplier.ContactName.ToTrimString();
            purchaseOrder.Phone = UCSupplier.Phone.ToTrimString();
            purchaseOrder.SupplierAddress = UCSupplier.Address.ToTrimString();
            purchaseOrder.ShipToCompany = txtShippingTo.Text.ToTrimString();
            purchaseOrder.ShipToAddress = txtShippingToAddress.Text.ToTrimString();
            purchaseOrder.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            purchaseOrder.CurrencyId = ddlCurrency.SelectedValue.ToInt();
            purchaseOrder.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _scm.UpdatePurchaseOrderHeader(purchaseOrder, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess("Purchase order information has been updated successfully");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;
                UpdatePurchaseOrder();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("purchase-order-preview.aspx?id={0}", PurchaseOrderId), false);
        }

        //************************************** Properties ************************************//

        private int PurchaseOrderId
        {
            get { return ViewState["PurchaseOrderId"] != null ? ViewState["PurchaseOrderId"].ToInt() : -1; }
            set { ViewState["PurchaseOrderId"] = value; }
        }

        private decimal SubTotal { get; set; }

        private decimal Tax
        {
            get { return ViewState["Tax"] != null ? ViewState["Tax"].ToDecimal(3) : 0; }
            set { ViewState["Tax"] = value; }
        }
    }
}