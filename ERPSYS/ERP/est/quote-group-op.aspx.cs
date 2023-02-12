using System;
using System.Collections.Generic;
using System.Linq;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.est
{
    public partial class QuoteGroupOp : System.Web.UI.Page
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
            else if (quote.StatusId != 1 && quote.StatusId != 2) 
            {
                Response.Redirect("quote-list.aspx?e=2", false);
            }

            QuoteId = quote.QuoteId;
            lblQuoteNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");
            lblDate.Text = quote.QuoteDate.ToShortDateString();

            hlnkCustomerName.Text = quote.CustomerName.ReplaceWhenNullOrEmpty("N/A");
            if (quote.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", quote.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblStatus.Text = quote.Status.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = quote.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = quote.CurrencyViewCode;
            lblTemplate.Text = quote.CompanyCode.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = quote.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblSalesEngineer.Text = quote.SalesEngineerName.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryNumber.Text = quote.InquiryNumber.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryDate.Text = quote.InquiryDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblPreparedBy.Text = quote.UserName;

            _salesQuoteItems = quote.QuoteLines;

            rgSalesQuote.Rebind();

            switch (operationId)
            {
                case 1:
                    pnlGroupItemAdd.Visible = true;
                    break;
                case 2:
                    pnlGroupItemUpdate.Visible = true;
                    break;
                case 3:
                    pnlGroupItemReplace.Visible = true;
                    break;
                case 4:
                    pnlGroupItemDelete.Visible = true;
                    break;
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

        protected void rgSalesQuote_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgSalesQuote.DataSource = GetMainLines();
            }
        }

        protected void rgSalesQuote_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgSalesQuote_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgSalesQuote.MasterTableView.Items)
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

        protected void rgSalesQuote_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        private void AddGroupItem()
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ItemId = UCGroupItemAdd.ItemId;
            line.PartNumber = UCGroupItemAdd.PartNumber;
            line.ItemCode = UCGroupItemAdd.ItemCode;
            line.DescriptionAs = UCGroupItemAdd.DescriptionAs;
            line.Quantity = UCGroupItemAdd.Quantity;
            line.UnitPrice = UCGroupItemAdd.UnitPrice;
            line.Profit = UCGroupItemAdd.Profit;
            line.IsPercentDiscount = UCGroupItemAdd.IsPercentDiscount;
            line.Discount = UCGroupItemAdd.Discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _quote.AddGroupLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                UCGroupItemAdd.ClearFields();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"));
                GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
            }
        }

        private void UpdateGroupItem()
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ItemId = UCGroupItemUpdate.ItemId;
            line.UnitPrice = UCGroupItemUpdate.UnitPrice;
            line.Profit = UCGroupItemUpdate.Profit;
            line.IsPercentDiscount = UCGroupItemUpdate.IsPercentDiscount;
            line.Discount = UCGroupItemUpdate.Discount;
       
            string rMessage;
            _quote.UpdateGroupLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                UCGroupItemUpdate.ClearFields();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"));
                GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
            }
        }

        private void ReplaceGroupItem()
        {
            QuoteLine oldLine = new QuoteLine();
            QuoteLine newLine = new QuoteLine();

            oldLine.QuoteId = QuoteId;
            oldLine.ItemId = UCGroupSubItemReplaceOld.ItemId;

            newLine.QuoteId = QuoteId;
            newLine.ItemId = UCGroupSubItemReplaceNew.ItemId;
            newLine.PartNumber = UCGroupSubItemReplaceNew.PartNumber;
            newLine.ItemCode = UCGroupSubItemReplaceNew.ItemCode;
            newLine.DescriptionAs = UCGroupSubItemReplaceNew.DescriptionAs;
            newLine.Quantity = UCGroupSubItemReplaceNew.Quantity;
            newLine.UnitPrice = UCGroupSubItemReplaceNew.UnitPrice;
            newLine.Profit = UCGroupSubItemReplaceNew.Profit;
            newLine.IsPercentDiscount = UCGroupSubItemReplaceNew.IsPercentDiscount;
            newLine.Discount = UCGroupSubItemReplaceNew.Discount;
            newLine.NetPrice = Calculation.GetNetPrice(newLine.UnitPrice, newLine.Profit, newLine.Discount, true).ToDecimal();
            newLine.TotalPrice = Calculation.GetLineTotal(newLine.NetPrice, newLine.Quantity).ToDecimal();

            string rMessage;
            _quote.ReplaceGroupItem(oldLine, newLine, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                UCGroupSubItemReplaceNew.ClearFields();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_replace_success"));
                GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
            }
        }

        private void DeleteGroupItem()
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ItemId = UCGroupItemDelete.ItemId;

            string rMessage;
            _quote.DeleteGroupLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                UCGroupItemDelete.ClearFields();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"));
                GetSalesQuote(Request.QueryString["id"].ToInt(), Request.QueryString["op"].ToInt());
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (UCGroupItemAdd.ItemId <= 0)
                {
                    AppNotification.MessageBoxWarning("No Item selected");
                    return;
                }

                AddGroupItem();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (UCGroupItemUpdate.ItemId <= 0)
                {
                    AppNotification.MessageBoxWarning("No Item selected");
                    return; 
                }

                UpdateGroupItem();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (UCGroupSubItemReplaceOld.ItemId <= 0 && UCGroupSubItemReplaceNew.ItemId <= 0)
                {
                    AppNotification.MessageBoxWarning("No Item selected");
                    return;
                }

                ReplaceGroupItem();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (UCGroupItemDelete.ItemId <= 0)
                {
                    AppNotification.MessageBoxWarning("No Item selected");
                    return;
                }

                DeleteGroupItem();
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