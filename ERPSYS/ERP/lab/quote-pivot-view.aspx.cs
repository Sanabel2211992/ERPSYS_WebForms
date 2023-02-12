using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ERPSYS.ERP.lab
{
    public partial class quote_pivot_view : System.Web.UI.Page
    {
        readonly QuoteBLL _quote = new QuoteBLL();

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
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetSalesQuote(int quoteId)
        {
            Quote quote = _quote.GetSalesQuoteHeader(quoteId);

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
        }

        protected void rgSalesQuoteGroupLines_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataTable dt = _quote.GetSalesQuotePivotView(QuoteId);


                if (dt.Rows.Count == 0)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("sales_quote_pivot_not_available"));
                    //rgSalesQuoteGroupLines.DataSource = new string[] { };
                    rgSalesQuoteGroupLines.DataSource = String.Empty;
                }
                else
                {
                    rgSalesQuoteGroupLines.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesQuoteGroupLines_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            switch (e.Column.UniqueName)
            {
                case "PartNumber":
                    //e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100);
                    e.Column.Visible = false;
                    break;
                case "Description":
                    e.Column.HeaderText = @"Description";
                    e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(400);
                    break;
                case "TotalQty":
                    e.Column.HeaderText = @"Qty";
                    e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75);
                    break;
                case "NetPrice":
                    e.Column.HeaderText = @"Price";
                    e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75);
                    break;
                case "TotalPrice":
                    e.Column.HeaderText = @"Total Price";
                    e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(75);
                    break;
                default:
                    e.Column.HeaderStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50);
                    break;
            }
        }

        protected void rgSalesQuoteGroupLines_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (rgSalesQuoteGroupLines.MasterTableView.Items.Count > 0)
            {
                if (e.Item is GridDataItem)
                {
                    //GridDataItem dataItem = (GridDataItem)e.Item;
                    //TotalQty += double.Parse((dataItem["TotalQty"]).Text);
                    //NetPrice += double.Parse((dataItem["NetPrice"]).Text);
                    //TotalPrice += double.Parse((dataItem["TotalPrice"]).Text);
                }
                else if (e.Item is GridFooterItem)
                {
                    GridFooterItem footer = (GridFooterItem)e.Item;
                    footer.Cells[5].Text = TotalQty.ToDecimalFormat(2);
                    footer.Cells[6].Text = NetPrice.ToDecimalFormat(2);
                    footer.Cells[7].Text = TotalPrice.ToDecimalFormat(2);
                }
            }
        }

        protected void rgSalesQuoteGroupLines_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                (rgSalesQuoteGroupLines.MasterTableView.GetColumn("Description") as GridBoundColumn).ReadOnly = true;
                (rgSalesQuoteGroupLines.MasterTableView.GetColumn("TotalPrice") as GridBoundColumn).ReadOnly = true;
                (rgSalesQuoteGroupLines.MasterTableView.GetColumn("TotalQty") as GridBoundColumn).ReadOnly = true;

                GridDataItem dataItem = e.Item as GridDataItem;

                foreach (GridColumn column in rgSalesQuoteGroupLines.MasterTableView.AutoGeneratedColumns)
                {
                    if (column.UniqueName.ToString() != "NetPrice")
                    {
                        if (dataItem[column.UniqueName].Text.ToInt() == -1)
                        {
                            (rgSalesQuoteGroupLines.MasterTableView.GetColumn(column.UniqueName) as GridBoundColumn).ReadOnly = true;
                        }
                    }
                }
                rgSalesQuoteGroupLines.MasterTableView.Rebind();
            }
        }

        protected void rgSalesQuoteGroupLines_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem eeditedItem = e.Item as GridEditableItem;

                string Description = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["Description"].ToString();
                string PartNumber = eeditedItem.OwnerTableView.DataKeyValues[eeditedItem.ItemIndex]["PartNumber"].ToString();

                decimal NetPrice = (eeditedItem["NetPrice"].Controls[0] as RadNumericTextBox).Text.ToDecimal();

                var group = new QuoteLine();

                foreach (GridColumn column in rgSalesQuoteGroupLines.MasterTableView.AutoGeneratedColumns)
                {
                    if (column.UniqueName.ToString() != "Description" && column.UniqueName.ToString() != "TotalPrice" && column.UniqueName.ToString() != "TotalQty" && column.UniqueName.ToString() != "PartNumber" && column.UniqueName.ToString() != "NetPrice")
                    {
                        group.QuoteId = QuoteId;
                        group.Description = column.UniqueName;
                        group.Quantity = (eeditedItem[column.UniqueName].Controls[0] as RadNumericTextBox).Text.ToDecimal();
                        group.NetPrice = NetPrice;
                        group.PartNumber = PartNumber;

                        if (group.Quantity != 0)
                        {
                            string rMessage;
                            _quote.UpdateEstimationView(group, out rMessage);

                            if (rMessage != string.Empty)
                            {
                                AppNotification.MessageBoxFailed(rMessage);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-preview.aspx?id={0}", QuoteId));
        }

        //************************************** Properties ************************************//

        public int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }

        public double TotalPrice { get; set; }

        public double NetPrice { get; set; }

        public double TotalQty { get; set; }
    }
}