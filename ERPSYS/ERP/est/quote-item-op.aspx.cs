using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.est
{
    public partial class QuoteItemOp : System.Web.UI.Page
    {
        readonly QuoteBLL _quote = new QuoteBLL();
        private List<QuoteLine> _salesQuoteItems = new List<QuoteLine>();

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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["op"] != null && Request.QueryString["op"] != string.Empty)
                {
                    GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetSalesQuote(int quoteId, int operationId)
        {
            Quote quote = _quote.GetSalesQuote(quoteId);

            if (quote.QuoteId <= 0)
            {
                Response.Redirect("quote-list.aspx?e=1", false);
            }
            else if (quote.StatusId > 2) 
            {
                Response.Redirect("quote-list.aspx?e=2", false);
            }

            QuoteId = quote.QuoteId;
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
            lblInquiryNumber.Text = quote.InquiryNumber.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryDate.Text = quote.InquiryDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblTemplate.Text = quote.CompanyCode.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = quote.CurrencyViewCode;
            lblPreparedBy.Text = quote.UserName;


            lblSubTotal.Text = quote.SubTotal.ToDecimalFormat();
            lblExpenses.Text = quote.Expenses.ToDecimalFormat();
            lblDiscount.Text = quote.Discount.ToDecimalFormat();
            lblGrandTotal.Text = quote.GrandTotal.ToDecimalFormat();

            _salesQuoteItems = quote.QuoteLines;

            rgQuotes.Rebind();

            if (operationId == 1)
            {
                pnlGroupItemMargin.Visible = true;
            }
        }

        public List<QuoteLine> GetMainLines()
        {
            return _salesQuoteItems.Where(s => s.ParentId == -1).ToList();
        }

        public List<QuoteLine> GetSubLines(int parentId)
        {
            return _salesQuoteItems.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgQuote_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgQuotes.DataSource = GetMainLines();
            }
        }

        protected void rgQuote_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgQuote_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgQuotes.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    //item.Enabled = false;

                    if (itemId == -1)
                    {
                        // item.Expanded = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgQuote_ItemDataBound(object sender, GridItemEventArgs e)
        {

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

        private void UpdateItemMargin()
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.Profit = UCItemMarginItem.Profit;
            line.IsPercentDiscount = UCItemMarginItem.IsPercentDiscount;
            line.Discount = UCItemMarginItem.Discount;

            string rMessage;
            _quote.UpdateItemMargin(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                UCItemMarginItem.ClearFields();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"));
                GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
            }
        }

        protected void btnUpdateMargin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateItemMargin();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-form.aspx?id={0}", QuoteId), false);

        }

        //************************************** Properties ************************************//

        public int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }

    }
}