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
    public partial class QuoteCost : System.Web.UI.Page
    {
        readonly QuoteBLL _quote = new QuoteBLL();
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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesQuote(Request.QueryString["id"].ToInt());
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
            lblQuoteNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = quote.CustomerName.ReplaceWhenNullOrEmpty("N/A");
            if (quote.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", quote.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblProjectName.Text = quote.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblDate.Text = quote.QuoteDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblStatus.Text = quote.Status.ReplaceWhenNullOrEmpty("N/A");
            lblPreparedBy.Text = quote.UserName.ReplaceWhenNullOrEmpty("N/A");

            lblSubTotal.Text = quote.SubTotal.ToDecimalFormat();
            //lblExpenses.Text = quote.Expenses.ToDecimalFormat();
            lblDiscount.Text = quote.Discount.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(quote.SubTotal, 0, quote.Discount, quote.IsPercentDiscount, quote.Tax).ToDecimalFormat();
            lblGrandTotal.Text = quote.GrandTotal.ToDecimalFormat();

            if (SystemProperties.HasSalesTax || quote.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }
        }

        protected void GetSalesQuoteLines()
        {
            _lstLines = _quote.GetSalesQuoteLines(QuoteId);
            lblTotalCost.Text = (from c in _lstLines where c.ParentId == -1 select (c.TotalCost)).Sum().ToDecimalFormat().ViewCostField();
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

        protected void rgQuoteGroup_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                TableCell totalPriceCell = dataItem["TotalPrice"];
                TableCell costCell = dataItem["UnitCost"];
                TableCell totalCostCell = dataItem["TotalCost"];

                totalCostCell.Text = totalCostCell.Text.ViewCostField();
                costCell.Text = costCell.Text.ViewCostField();

                decimal totalPrice = totalPriceCell.Text.ToDecimal();
                decimal totalCost = totalCostCell.Text.ToDecimal();
                decimal delta = totalPrice - totalCost;

                if (RegisteredUser.HasCostView && delta <= 0)
                {
                    totalCostCell.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
                    Response.Redirect(string.Format("quote-preview.aspx?id={0}", QuoteId), false);
                    break;
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
    }
}