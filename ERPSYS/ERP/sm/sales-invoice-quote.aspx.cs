using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceQuote : System.Web.UI.Page
    {
        readonly QuoteBLL _quote = new QuoteBLL();
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        private List<QuoteLine> _lstLines = new List<QuoteLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                UCDatePicker.DateValue = DateTime.Today;
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesQuote(Request.QueryString["id"].ToInt());
                    GetItemLookupTables();
                }
                else
                {
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1), false);
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

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetLocation();
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

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

        protected void GetSalesQuote(int quoteId)
        {
            Quote quote = _quote.GetSalesQuoteHeader(quoteId);

            if (quote.QuoteId <= 0)
            {
                Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
            }

            QuoteId = quote.QuoteId;
            lblQuoteNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = quote.CustomerName;
            if (quote.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", quote.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblProjectName.Text = quote.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblDate.Text = quote.QuoteDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = quote.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = quote.Status.ReplaceWhenNullOrEmpty("N/A");
            lblSalesEngineer.Text = quote.SalesEngineerName.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = quote.CurrencyViewCode;
            lblPreparedBy.Text = quote.UserName.ReplaceWhenNullOrEmpty("N/A");

            lblSubTotal.Text = quote.SubTotal.ToDecimalFormat();
            lblExpenses.Text = quote.Expenses.ToDecimalFormat();
            lblDiscount.Text = quote.Discount.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(quote.SubTotal, 0, quote.Discount, quote.IsPercentDiscount, quote.Tax).ToDecimalFormat();
            lblGrandTotal.Text = quote.GrandTotal.ToDecimalFormat();

            if (SystemProperties.HasSalesTax || quote.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            if (quote.StatusId != 2)
            {
                Response.Redirect(string.Format("../est/quote-list.aspx?e={0}", 7));            
            }
        }

        protected void GetSalesQuoteLines()
        {
            _lstLines = _quote.GetSalesQuoteLines(QuoteId);
        }

        public List<QuoteLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<QuoteLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgQuoteGroup_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (_lstLines.Count == 0)
            {
                GetSalesQuoteLines();
            }

            if (!e.IsFromDetailTable)
            {
                rgQuoteGroup.DataSource = GetMainLines();
            }
        }

        protected void rgQuoteGroup_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgQuoteGroup_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgQuoteGroup.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    if (itemId == -1)
                    {
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void CreateSalesInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            invoice.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var invoiceId = _invoice.CreateSalesInvoiceFromSalesQuotation(invoice, QuoteId, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", invoiceId, 4));
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../est/quote-preview.aspx?id={0}", QuoteId), false);
        }

        //************************************** Properties ************************************//

        public int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }
    }
}