using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceDelievryReceipt : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();
        private List<DeliveryReceiptLine> _lstLines = new List<DeliveryReceiptLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNotBilledDeliveryReceipt();
            }
        }

        protected void GetNotBilledDeliveryReceipt()
        {
            try
            {
                ddlDeliveryReceiptList.DataTextField = "ReceiptNumber";
                ddlDeliveryReceiptList.DataValueField = "ReceiptId";
                ddlDeliveryReceiptList.DataSource = _delivery.GetNotBilledDeliveryReceipt();
                ddlDeliveryReceiptList.DataBind();

                ddlDeliveryReceiptList.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnDeliveryReceipt_Click(object sender, EventArgs e)
        {
            int receiptId = ddlDeliveryReceiptList.SelectedValue.ToInt();

            if (receiptId > 0)
            {
                pnlSalesInvoice.Visible = true;
                InitializeComponent(receiptId);
            }
        }

        private void InitializeComponent(int receiptId)
        {
            try
            {
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
                GetDeliveryReceipt(receiptId);
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

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();
            ddlPaymentMethod.SelectedValue = _invoice.DefaultPaymentMethodId.ToString();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
            ddlPaymentTerms.SelectedValue = _invoice.DefaultPaymentTermsId.ToString();
        }

        protected void GetDeliveryReceipt(int receiptId)
        {
            DeliveryReceipt deliveryRcpt = _delivery.GetDeliveryReceiptHeader(receiptId);

            ReceiptId = receiptId;
            lblReceiptNumber.Text = deliveryRcpt.ReceiptNumber.ReplaceWhenNullOrEmpty("N/A");
            lblReceiptStatus.Text = deliveryRcpt.Status.ReplaceWhenNullOrEmpty("N/A");
            lblCustomerName.Text = deliveryRcpt.CustomerName;
            lblCustomerPO.Text = deliveryRcpt.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");
            lblSalesOrderNumber.Text = deliveryRcpt.SalesOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblJobOrderNumber.Text = deliveryRcpt.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            if (SystemProperties.HasSalesTax || deliveryRcpt.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = deliveryRcpt.Tax.ToDecimalFormat();
            }

            txtSubTotal.Text = deliveryRcpt.SubTotal.ToDecimalFormat();
            txtDiscount.Text = deliveryRcpt.Discount.ToDecimalFormat();
            Tax = deliveryRcpt.Tax;
            txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
            txtGrandTotal.Text = deliveryRcpt.GrandTotal.ToDecimalFormat();

            if (deliveryRcpt.OrderDiscount > 0)
            {
                lblIndividualDiscount.Text = deliveryRcpt.OrderDiscount.ToDecimalFormat();
                pnlIndividualDiscount.Visible = true;
            }

            _lstLines = _delivery.GetDeliveryReceiptSalesInvoiceLines(ReceiptId);                                

            if (_lstLines.Where(s => s.ParentId == -1).ToList().Count == 0)
            {
                pnlSalesInvoice.Visible = false;
                AppNotification.MessageBoxWarning("No available items in The Delivery Receipt");
                return;
            }

            rgSalesInvoice.Rebind();
        }

        public List<DeliveryReceiptLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<DeliveryReceiptLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgSalesInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgSalesInvoice.DataSource = GetMainLines();
            }
        }

        protected void rgSalesInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgSalesInvoice_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgSalesInvoice.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    //item.Enabled = false;

                    //if (itemId == -1)
                    //{
                    //    item.Expanded = true;
                    //}
                    //else
                    //{
                    //    item.Cells[0].Controls[0].Visible = false;
                    //}

                    if (itemId != -1)
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgSalesInvoice_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        void UpdateTotalSummary()
        {
            try
            {
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                
                AppNotification.MessageBoxSuccess("Operation done successfully");
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

            UpdateTotalSummary();
        }

        protected void CreateSalesInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceDate = UCDate.DateValue;
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.CurrencyIdView = ddlCurrencyView.SelectedValue.ToInt();

            invoice.SubTotal = txtSubTotal.Value.ToDecimal();
            invoice.Discount = txtDiscount.Value.ToDecimal();
            invoice.IsPercentDiscount = false;
            invoice.Tax = Tax;
            invoice.GrandTotal = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax);

            string rMessage;
            var invoiceId = _invoice.CreateSalesInvoiceFromDeliveryReceiptNote(invoice, ReceiptId, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", invoiceId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateSalesInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int ReceiptId
        {
            get { return ViewState["ReceiptId"] != null ? ViewState["ReceiptId"].ToInt() : -1; }
            set { ViewState["ReceiptId"] = value; }
        }

        private decimal Tax
        {
            get { return ViewState["Tax"] != null ? ViewState["Tax"].ToDecimal() : 0; }
            set { ViewState["Tax"] = value; }
        }
    }
}