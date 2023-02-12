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
using ERPSYS.Controls.HierarchyItems.EST.Quote;

namespace ERPSYS.ERP.est
{
    public partial class QuoteForm : Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        public QuoteForm()
        {
            GetMaster = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgQuote, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(btnApplyChanges, (UCNotificationPanel)Master.FindControl("NotificationPanel"));        
            }

            if (!IsPostBack)
            {
                GetItemLookupTables();
                GetData();
            }
        }

        private void GetData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetQuoteHeader(Request.QueryString["id"].ToInt());
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

            ddlCurrencyView.DataTextField = "Description";
            ddlCurrencyView.DataValueField = "CurrencyId";
            ddlCurrencyView.DataSource = lookup.GetCurrency();
            ddlCurrencyView.DataBind();
            ddlCurrencyView.Items.Insert(0, new ListItem("Not Assigned", "-1"));

            ddlSalesEngineer.DataTextField = "DisplayName";
            ddlSalesEngineer.DataValueField = "UserId";
            ddlSalesEngineer.DataSource = lookup.GetSalesEngineerList();
            ddlSalesEngineer.DataBind();
            ddlSalesEngineer.Items.Insert(0, new ListItem("Not Assigned", "-1"));

            ddlCompanyCode.DataTextField = "Code";
            ddlCompanyCode.DataValueField = "CompanyId";
            ddlCompanyCode.DataSource = lookup.GetSystemCompanyCode();
            ddlCompanyCode.DataBind();

            ddlCompanyCode.SelectedValue = UserSession.CompanyId.ToString();
        }

        protected void GetQuoteHeader(int quoteId)
        {
            Quote quote = _quote.GetSalesQuoteHeader(quoteId);

            if (quote.QuoteId <= 0)
            {
                Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
            }

            QuoteId = quoteId;
            lblOrderNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = quote.QuoteDate;
            UCCustomer.CustomerId = quote.CustomerId;
            UCCustomer.CustomerName = quote.CustomerName;
            txtProjectName.Text = quote.ProjectName;
            ddlCurrencyView.SelectedValue = quote.CurrencyIdView.ToString();
            ddlSalesEngineer.SelectedValue = quote.SalesEngineerId.ToString();

            txtInquiryNumber.Text = quote.InquiryNumber.ToString();
            UCInquiryDate.DateValue = quote.InquiryDate;
            ddlCompanyCode.SelectedValue = quote.CompanyIdView.ToString();

            txtRemarks.Text = quote.Remarks;
            lblStatus.Text = quote.Status.ReplaceWhenNullOrEmpty("N/A");

            txtDiscount.Text = quote.Discount.ToDecimalFormat();
            Tax = quote.Tax;
            cbIgnoreTax.Checked = quote.Tax == 0;

            if (SystemProperties.HasSalesTax || quote.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = quote.Tax.ToDecimalFormat();
            }

            //if(!quote.IsContainGroup)
            //{
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("addg"));
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("updateg"));
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("replaceg"));
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("deleteg"));
            //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("pd"));
            //}
        }

        protected List<QuoteLine> GetQuoteLines(int quoteId)
        {
            List<QuoteLine> quoteItems = _quote.GetSalesQuoteMainLines(quoteId);
            rtbGroupOperations.Visible = quoteItems.Any(x => x.ItemId == -1);
            SubTotal = quoteItems.Where(s => s.ParentId == -1).Sum(s => s.TotalPrice).ToDecimal();
            return quoteItems;
        }

        protected void rgQuote_PreRender(object sender, EventArgs e)
        {
            if (GetMaster)
            {
                BindData();
            }

            if (NewMainQuoteLineId > 0)
            {
                foreach (GridDataItem item in rgQuote.MasterTableView.Items)
                {
                    if (item["ParentId"].Text.ToInt() == -1 && item.GetDataKeyValue("ItemId").ToInt() == -1 && item.GetDataKeyValue("QuoteLineId").ToInt() == NewMainQuoteLineId)
                    {
                        item.Expanded = true;
                        NewMainQuoteLineId = -1;
                    }
                }
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "remarks":
                    Response.Redirect(string.Format("quote-remark.aspx?id={0}", QuoteId), false);
                    break;
            }
        }

        protected void rtbGroupOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "addg":
                    Response.Redirect(string.Format("quote-group-op.aspx?op=1&id={0}", QuoteId), false);
                    break;
                case "updateg":
                    Response.Redirect(string.Format("quote-group-op.aspx?op=2&id={0}", QuoteId), false);
                    break;
                case "replaceg":
                    Response.Redirect(string.Format("quote-group-op.aspx?op=3&id={0}", QuoteId), false);
                    break;
                case "deleteg":
                    Response.Redirect(string.Format("quote-group-op.aspx?op=4&id={0}", QuoteId), false);
                    break;
                case "pd":
                    Response.Redirect(string.Format("quote-item-op.aspx?op=1&id={0}", QuoteId), false);
                    break;
                //case "arrang":
                //    Response.Redirect(string.Format("quote-arrangement.aspx?id={0}", QuoteId), false);
                //    break;
            }
        }

        protected void rgQuote_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && QuoteId > 0)
            {
                rgQuote.DataSource = GetQuoteLines(QuoteId);
                txtSubTotal.Text = SubTotal.ToDecimalFormat();

                UpdateTotalSummary();
            }
        }

        protected void rgQuote_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int quoteLineId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _quote.GetSalesQuoteSubLine(QuoteId, quoteLineId);
                        break;
                    }
            }
        }

        protected void rgQuote_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "MainItem")
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item.GetDataKeyValue("ItemId").ToInt() > 0)
                {
                    TableCell cell = (e.Item as GridDataItem)["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                }
            }
        }

        protected void rgQuote_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item.OwnerTableView.Name == "MainItem")
            {
                if (e.CommandName == RadGrid.ExpandCollapseCommandName)// only one row expand at the same time (remove it for multi expand rows at same time )
                {
                    foreach (GridItem item in e.Item.OwnerTableView.Items)
                    {
                        if (item.Expanded && item != e.Item)
                        {
                            item.Expanded = false;
                        }
                    }
                }
                if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    rgQuote.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/EST/Quote/UCMainItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                }

                else if (e.CommandName == RadGrid.EditCommandName)
                {
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/EST/Quote/UCMainItemEdit.ascx";
                }
            }

            else if (e.Item.OwnerTableView.Name == "SubItems")
            {
                if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    rgQuote.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/EST/Quote/UCSubItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                }

                else if (e.CommandName == RadGrid.EditCommandName && e.CommandArgument.ToString() != "Replace")
                {
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/EST/Quote/UCSubItemEdit.ascx";
                }

                else if (e.CommandName == "Edit" && e.CommandArgument.ToString() == "Replace")
                {
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/EST/Quote/UCSubItemReplace.ascx";
                }
                else if (e.CommandName == "InitClone" && !e.Item.OwnerTableView.IsItemInserted)
                {
                    GridDataItem dataItem = (e.Item.OwnerTableView.ParentItem);
                    int lineId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

                    CloneLines(lineId);
                }
            }
        }

        protected void rgQuote_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void rgQuote_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int itemId = ((UCMainItemAdd)uc).ItemId;
                    string itemCode = ((UCMainItemAdd)uc).ItemCode;
                    string partNumber = ((UCMainItemAdd)uc).PartNumber;
                    string description = ((UCMainItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemAdd)uc).Quantity;
                    decimal unitPrice = ((UCMainItemAdd)uc).UnitPrice;
                    decimal profit = ((UCMainItemAdd)uc).Profit;
                    decimal discount = ((UCMainItemAdd)uc).Discount;
                    bool isPercentDiscount = ((UCMainItemAdd)uc).IsPercentDiscount;
                    bool isRoundUp = ((UCMainItemAdd)uc).IsRoundUp;

                    AddQuoteMainLine(itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount, isRoundUp);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();

                    int itemId = ((UCSubItemAdd)uc).ItemId;
                    string itemCode = ((UCSubItemAdd)uc).ItemCode;
                    string partNumber = ((UCSubItemAdd)uc).PartNumber;
                    string description = ((UCSubItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCSubItemAdd)uc).Quantity;
                    decimal unitPrice = ((UCSubItemAdd)uc).UnitPrice;
                    decimal profit = ((UCSubItemAdd)uc).Profit;
                    decimal discount = ((UCSubItemAdd)uc).Discount;
                    bool isPercentDiscount = ((UCSubItemAdd)uc).IsPercentDiscount;

                    AddQuoteSubLine(parentId, itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgQuote_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int quoteLineId = eItem.GetDataKeyValue("QuoteLineId").ToInt();
                    int itemId = ((UCMainItemEdit)uc).ItemId;
                    string description = ((UCMainItemEdit)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemEdit)uc).Quantity;
                    decimal unitPrice = ((UCMainItemEdit)uc).UnitPrice;
                    decimal profit = ((UCMainItemEdit)uc).Profit;
                    decimal discount = ((UCMainItemEdit)uc).Discount;
                    bool isPercentDiscount = ((UCMainItemEdit)uc).IsPercentDiscount;
                    bool isRoundUp = ((UCMainItemEdit)uc).IsRoundUp;

                    UpdateQuoteLMainLine(quoteLineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount, isRoundUp);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {

                    if (e.CommandArgument.ToString() == "Replace")
                    {
                        GridDataItem dataItem = (e.Item.OwnerTableView.ParentItem);
                        int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();
                        int lineId = eItem.GetDataKeyValue("QuoteLineId").ToInt();
                        int itemId = ((UCSubItemReplace)uc).ItemId;
                        string itemCode = ((UCSubItemReplace)uc).ItemCode;
                        string partNumber = ((UCSubItemReplace)uc).PartNumber;
                        string description = ((UCSubItemReplace)uc).DescriptionAs;
                        decimal quantity = ((UCSubItemReplace)uc).Quantity;
                        decimal unitPrice = ((UCSubItemReplace)uc).UnitPrice;
                        decimal profit = ((UCSubItemReplace)uc).Profit;
                        decimal discount = ((UCSubItemReplace)uc).Discount;
                        bool isPercentDiscount = ((UCSubItemReplace)uc).IsPercentDiscount;

                        ReplaceQuoteSubLine(parentId, lineId, itemId, partNumber, itemCode, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                    }
                    else
                    {
                        GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                        int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();
                        int quoteLineId = eItem.GetDataKeyValue("QuoteLineId").ToInt();
                        int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                        string description = ((UCSubItemEdit)uc).DescriptionAs;
                        decimal quantity = ((UCSubItemEdit)uc).Quantity;
                        decimal unitPrice = ((UCSubItemEdit)uc).UnitPrice;
                        decimal profit = ((UCSubItemEdit)uc).Profit;
                        decimal discount = ((UCSubItemEdit)uc).Discount;
                        bool isPercentDiscount = ((UCSubItemEdit)uc).IsPercentDiscount;

                        UpdateQuoteSubLine(parentId, quoteLineId, itemId, description, quantity, unitPrice, profit, discount, isPercentDiscount);
                    }

                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgQuote_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int quoteLineId = dItem.GetDataKeyValue("QuoteLineId").ToInt();

                    DeleteQuoteLMainLine(quoteLineId);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = e.Item.OwnerTableView.ParentItem;
                    int parentId = dataItem.GetDataKeyValue("QuoteLineId").ToInt();
                    int quoteLineId = dItem.GetDataKeyValue("QuoteLineId").ToInt();
                    int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                    DeleteQuoteSubLine(parentId, quoteLineId, itemId);
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddQuoteMainLine(int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isRoundUp)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.IsRoundUp = isRoundUp;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            NewMainQuoteLineId = _quote.AddMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
            }
        }

        protected void UpdateQuoteLMainLine(int quoteLineId, int itemId, string description, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount, bool isRoundUp)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.QuoteLineId = quoteLineId;
            line.ItemId = itemId;
            line.DescriptionAs = description;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.IsRoundUp = isRoundUp;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();
            
            string rMessage;
            _quote.UpdateMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteQuoteLMainLine(int quoteLineId)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.QuoteLineId = quoteLineId;

            string rMessage;
            _quote.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Product");
            }
        }

        protected void AddQuoteSubLine(int parentId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ParentId = parentId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _quote.AddSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
                GetMaster = true;
            }
        }

        protected void UpdateQuoteSubLine(int parentId, int quoteLineId, int itemId, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {

            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ParentId = parentId;
            line.QuoteLineId = quoteLineId;
            line.ItemId = itemId;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _quote.UpdateSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
                GetMaster = true;
            }
        }

        protected void ReplaceQuoteSubLine(int parentId, int lineId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity, decimal unitPrice, decimal profit, decimal discount, bool isPercentDiscount)
        {

            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ParentId = parentId;
            line.QuoteLineId = lineId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;
            line.UnitPrice = unitPrice;
            line.Profit = profit;
            line.IsPercentDiscount = isPercentDiscount;
            line.Discount = discount;
            line.NetPrice = Calculation.GetNetPrice(line.UnitPrice, line.Profit, line.Discount, true).ToDecimal();
            line.TotalPrice = Calculation.GetLineTotal(line.NetPrice, line.Quantity).ToDecimal();

            string rMessage;
            _quote.ReplaceSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
                GetMaster = true;
            }
        }

        protected void DeleteQuoteSubLine(int parentId, int quoteLineId, int itemId)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.ParentId = parentId;
            line.QuoteLineId = quoteLineId;
            //line.ItemId = itemId;

            string rMessage;
            _quote.DeleteSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
                GetMaster = true;
            }
        }

        protected void MoveUp(int quoteLineId, int lineSeqId)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.QuoteLineId = quoteLineId;
            line.LineSeqId = lineSeqId;

            string rMessage;
            _quote.MoveLineUp(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }

            GetMaster = true;
        }

        protected void MoveDown(int quoteLineId, int lineSeqId)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.QuoteLineId = quoteLineId;
            line.LineSeqId = lineSeqId;

            string rMessage;
            _quote.MoveLineDown(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }

            GetMaster = true;
        }

        private void BindData()
        {
            rgQuote.Rebind();
        }

        protected void cbIgnoreTax_CheckedChanged(object sender, EventArgs e)
        {
            Tax = cbIgnoreTax.Checked ? 0 : SystemProperties.SalesTaxValue.ToDecimal();
            lblSalesTaxValue.Text = Tax.ToDecimalFormat();

            UpdateTotalSummary();
        }

        protected void UpdateTotalSummary()
        {
            try
            {
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                //txtSubTotal.Text = SubTotal.ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), 0, txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
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
            _quote.UpdateSalesQuoteSummary(QuoteId, 0, txtDiscount.Text.ToDecimal(), Tax, out rMessage);

            if (rMessage != string.Empty || QuoteId <= 0)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            BindData();
            AppNotification.MessagePanelSuccess("Operation done successfully", "Update Total Summary");
        }

        protected void UpdateQuoteHeader()
        {
            Quote quote = new Quote();

            quote.QuoteId = QuoteId;
            quote.CustomerId = UCCustomer.CustomerId;
            quote.ProjectName = txtProjectName.Text.ToTrimString();
            quote.QuoteDate = UCDatePicker.DateValue;
            quote.SalesEngineerId = ddlSalesEngineer.SelectedValue.ToInt();
            quote.CurrencyIdView = ddlCurrencyView.SelectedValue.ToInt();
            quote.InquiryNumber = txtInquiryNumber.Text.ToTrimString();
            quote.InquiryDate = UCInquiryDate.DateValue;
            quote.CompanyIdView = ddlCompanyCode.SelectedValue.ToInt();
            quote.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _quote.UpdateSalesQuoteHeader(quote, out rMessage);

            if (rMessage != string.Empty || QuoteId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_update_success"));
        }

        protected void CloneLines(int lineId)
        {
            QuoteLine line = new QuoteLine();

            line.QuoteId = QuoteId;
            line.QuoteLineId = lineId;

            string rMessage;
            _quote.CloneLines(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_clone_success"), "Clone Product");
                GetMaster = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateQuoteHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-preview.aspx?id={0}", QuoteId), false);
        }

        protected void lnkbtnUpdateRemarks_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-remark.aspx?id={0}", QuoteId));

        }


        //************************************** Properties ************************************//

        private int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }

        private bool GetMaster { get; set; }

        private decimal SubTotal { get; set; }

        private int NewMainQuoteLineId
        {
            get { return ViewState["NewMainItemId"] != null ? ViewState["NewMainItemId"].ToInt() : -1; }
            set { ViewState["NewMainItemId"] = value; }
        }

        private decimal Tax
        {
            get { return ViewState["Tax"] != null ? ViewState["Tax"].ToDecimal() : 0; }
            set { ViewState["Tax"] = value; }
        }
    }
}