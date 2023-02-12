using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.est
{
    public partial class QuoteList : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetLookupTables();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["o"])
                {
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_quote_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_id_not_exist"));
                        break;
                      case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_quote_inactive"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlQuoteStatus.DataTextField = "Name";
            ddlQuoteStatus.DataValueField = "QuoteStatusId";
            ddlQuoteStatus.DataSource = lookup.GetSalesQuoteSHeaderStatus();
            ddlQuoteStatus.DataBind();
            ddlQuoteStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgQuoteList.Rebind();
        }

        private DataTable GetQuoteList()
        {
            try
            {
                return _quote.GetSalesQuoteList(DateStart, DateEnd, CustomerName, QuoteNumber, QuoteStatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgQuoteList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgQuoteList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgQuoteList.DataSource = GetQuoteList();
        }

        protected void rgQuoteList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["StatusQuote"].Text;

                switch (statusId)
                {
                    case 1: //Draft
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //Pending
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 3: //revised
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
                        break;
                    case 4: //Canceled
                        imgStatus.ImageUrl = "../resources/images/status/canceled.png";
                        break;
                    case 5: //Closed
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
                        break;
                    case 6: //Lost
                        imgStatus.ImageUrl = "../resources/images/status/lost.png";
                        break;
                }
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "export":
                    ExportToExcelFile();
                    break;
                case "add":
                    Response.Redirect("quote-create.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetQuoteList();

                dt.Columns.Remove("QuoteId");
                dt.Columns.Remove("StatusId");

                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["ProjectName"].ColumnName = "Project Name";
                dt.Columns["QuoteDate"].ColumnName = "Date";
                dt.Columns["SalesEngineer"].ColumnName = "Engineer Name";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["StatusQuote"].ColumnName = "Status";
                dt.Columns["QuoteNumber"].ColumnName = "Quote Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Quotation List ", "Quotation_List ");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;
                CustomerName = txtCustomerName.Text.ToTrimString();
                QuoteNumber = txtQuoteNumber.Text.ToTrimString();
                QuoteStatusId = ddlQuoteStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("quote-create.aspx", false);
        //}

        //************************************** Properties ************************************//

        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : "1/1/2900".ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

        public string CustomerName
        {
            get { return ViewState["CustomerName"] != null ? ViewState["CustomerName"].ToString() : ""; }
            set { ViewState["CustomerName"] = value; }
        }

        public string QuoteNumber
        {
            get { return ViewState["QuoteNumber"] != null ? ViewState["QuoteNumber"].ToString() : ""; }
            set { ViewState["QuoteNumber"] = value; }
        }

        public int QuoteStatusId
        {
            get { return ViewState["QuoteStatusId"] != null ? ViewState["QuoteStatusId"].ToInt() : -1; }
            set { ViewState["QuoteStatusId"] = value; }
        }
    }
}