using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceRefundType : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    GetSalesInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1), false);
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

        protected void GetSalesInvoice(int invoiceId)
        {
            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(String.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            if (invoice.IsRefund)
            {
                Response.Redirect(String.Format("sales-invoice-preview.aspx?id={0}&e={1}", invoiceId, 1));
            }

            if (invoice.IsRefundBefore)
            {
                Response.Redirect(String.Format("sales-invoice-refund.aspx?id={0}&o={1}", invoiceId, 2)); // Individual refund
            }

            InvoiceId = invoice.InvoiceId;
            lblStatus.Text = invoice.Status.ReplaceWhenNullOrEmpty("N/A");
            lblInvoiceNumber.Text = invoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            lblInvoiceDate.Text = invoice.InvoiceDate.ReplaceDateWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = invoice.CustomerName;
            if (invoice.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", invoice.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblLocation.Text = invoice.Location;
            lblProjectName.Text = invoice.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = invoice.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
            lblExpenses.Text = invoice.Expenses.ToDecimalFormat();
            lblDiscount.Text = invoice.Discount.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(invoice.SubTotal, 0, invoice.Discount, invoice.IsPercentDiscount, invoice.Tax).ToDecimalFormat();
            lblGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();

            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            int refundTypeId = 2;

            switch (rblRefundType.SelectedValue)
            {
                case "Whole":
                    refundTypeId = 1;
                    break;
                case "Individual":
                    refundTypeId = 2;
                    break;
            }

            Response.Redirect(String.Format("sales-invoice-refund.aspx?id={0}&o={1}", InvoiceId, refundTypeId), false);
        }

        //************************************** Properties ************************************//

        public int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}