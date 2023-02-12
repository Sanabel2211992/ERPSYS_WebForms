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

namespace ERPSYS.ERP.est
{
    public partial class QuotePreview : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();
        private List<QuoteLine> _lstLines = new List<QuoteLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                BindData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_update_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_revise_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_cancel_success"));
                        break;
                    case "5":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_clone_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_post_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_no_records"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_group_empty"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_revise_failed"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_delete_failed"));
                        break;
                    case "6":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_cancel_failed"));
                        break;
                    case "7":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_order_create_failed"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesQuote(Request.QueryString["id"].ToInt());
                    hfquoteId.Value = Request.QueryString["id"];
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

        protected void GetSalesQuote(int quoteId)
        {
            Quote quote = _quote.GetSalesQuoteHeader(quoteId);

            if (quote.QuoteId <= 0)
            {
                Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
            }

            QuoteId = quote.QuoteId;
            SalesOrderId = quote.SalesOrderId;
            SalesInvoiceId = quote.SalesInvoiceId;
            lblQuoteNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = quote.CustomerName.ReplaceWhenNullOrEmpty("N/A");
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
            lblTemplate.Text = quote.CompanyCode.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = quote.CurrencyViewCode;
            lblPreparedBy.Text = quote.UserName.ReplaceWhenNullOrEmpty("N/A");

            lblInquiryNumber.Text = quote.InquiryNumber.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryDate.Text = quote.InquiryDate.ReplaceDateWhenNullOrEmpty("N/A");

            lblSubTotal.Text = quote.SubTotal.ToDecimalFormat();
            lblExpenses.Text = quote.Expenses.ToDecimalFormat();
            lblDiscount.Text = quote.Discount.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(quote.SubTotal, 0, quote.Discount, quote.IsPercentDiscount, quote.Tax).ToDecimalFormat();
            lblGrandTotal.Text = quote.GrandTotal.ToDecimalFormat();

            if (SystemProperties.HasSalesTax || quote.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            if (!RegisteredUser.HasCostView)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cost"));
            }

            switch (quote.StatusId)
            {
                case 1: // draft
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("revise"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("clone"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep4"));

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));

                    rtbOperations.FindItemByText("Create").Visible = false;

                    break;

                case 2:// pending
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));

                    break;

                case 3:// revised
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("revise"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep3"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("stock"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep4"));

                    rtbOperations.FindItemByText("Create").Visible = false;

                    if (quote.SalesOrderId <= 0 && quote.SalesInvoiceId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                    }
                    else if (quote.SalesInvoiceId <= 0 && quote.SalesOrderId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }
                    else
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }

                    break;

                case 4:// canceled
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("revise"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep3"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("stock"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep4"));

                    rtbOperations.FindItemByText("Create").Visible = false;

                    if (quote.SalesOrderId <= 0 && quote.SalesInvoiceId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                    }
                    else if (quote.SalesInvoiceId <= 0 && quote.SalesOrderId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }
                    else
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }

                    break;

                case 5:// closed
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("revise"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep3"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("stock"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep4"));

                    rtbOperations.FindItemByText("Create").Visible = false;

                    if (quote.SalesOrderId <= 0 && quote.SalesInvoiceId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                    }
                    else if (quote.SalesInvoiceId <= 0 && quote.SalesOrderId > 0)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }
                    else
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("orderv"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("invoicev"));
                    }

                    break;
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

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("quote-form.aspx?id={0}", QuoteId), false);
                    break;
                case "revise":
                    Response.Redirect(string.Format("quote-revise.aspx?id={0}", QuoteId), false);
                    break;
                case "clone":
                    Response.Redirect(string.Format("quote-clone.aspx?id={0}", QuoteId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("quote-delete.aspx?id={0}", QuoteId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("quote-post.aspx?id={0}", QuoteId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("quote-cancel.aspx?id={0}", QuoteId), false);
                    break;
                case "cost":
                    Response.Redirect(string.Format("quote-cost.aspx?id={0}", QuoteId), false);
                    break;
                case "compact":
                    pnlCompactView.Visible = true;
                    pnlGroupView.Visible = false;
                    pnlStockView.Visible = false;

                    rgQuoteLine.Rebind();
                    break;
                case "groups":
                    pnlCompactView.Visible = false;
                    pnlGroupView.Visible = true;
                    pnlStockView.Visible = false;

                    rgQuoteGroup.Rebind();
                    break;
                case "stock":
                    pnlCompactView.Visible = false;
                    pnlGroupView.Visible = false;
                    pnlStockView.Visible = true;

                    rgQuoteReview.Rebind();
                    break;
                case "pivot":
                    Response.Redirect(string.Format("quote-pivot-view.aspx?id={0}", QuoteId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("quote-report.aspx?id={0}", QuoteId), false);
                    break;
                case "orderc":
                    Response.Redirect(string.Format("../sm/sales-order-quote.aspx?id={0}", QuoteId), false);
                    break;
                case "orderv":
                    Response.Redirect(string.Format("../sm/sales-order-preview.aspx?id={0}", SalesOrderId), false);
                    break;
                case "invoicec":
                    Response.Redirect(string.Format("../sm/sales-invoice-quote.aspx?id={0}", QuoteId), false);
                    break;
                case "invoicev":
                    Response.Redirect(string.Format("../sm/sales-invoice-preview.aspx?id={0}", SalesInvoiceId), false);
                    break;
            }
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

        protected void rgQuoteLine_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgQuoteLine.DataSource = _quote.GetSalesQuoteCompactLines(QuoteId);
        }

        protected void rgQuoteCombinedLineStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                if (dataItem["RemainingQuantity"].Text.ToDecimal() > 0)
                {
                    decimal x = dataItem["StockQuantity"].Text.ToDecimal() - dataItem["Quantity"].Text.ToDecimal();
                    imgStatus.ImageUrl = (x >= 0) ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
                }
                else
                {
                    imgStatus.ImageUrl = "../resources/images/ico_allow_16.png";
                }
            }
        }

        protected void rgQuoteReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgQuoteReview.DataSource = _quote.GetSalesQuoteLinesQuantityCheck(QuoteId);
        }

        protected void rgQuoteReview_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");

                decimal delta = dataItem["AvailableQuantity"].Text.ToDecimal() - dataItem["RequiredQuantity"].Text.ToDecimal();
                imgStatus.ImageUrl = (delta >= 0) ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
            }
        }


        //************************************** Properties ************************************//

        public int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }

        public int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }

        public int SalesInvoiceId
        {
            get { return ViewState["SalesInvoiceId"] != null ? ViewState["SalesInvoiceId"].ToInt() : -1; }
            set { ViewState["SalesInvoiceId"] = value; }
        }
    }
}