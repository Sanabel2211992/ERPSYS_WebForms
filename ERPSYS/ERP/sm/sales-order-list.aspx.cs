using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrdeList : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_id_not_exist"));
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

            ddlOrderStatus.DataTextField = "Name";
            ddlOrderStatus.DataValueField = "StatusId";
            ddlOrderStatus.DataSource = lookup.GetSalesOrderHeaderStatus();
            ddlOrderStatus.DataBind();
            ddlOrderStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgOrderList.Rebind();
        }

        private DataTable GetSalesOrderList()
        {
            try
            {
                return _order.GetSalesOrderList(DateStart, DateEnd, CustomerName, OrderNumber, OrderStatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgOrderList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgOrderList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
          rgOrderList.DataSource = GetSalesOrderList();
        }

        protected void rgOrderList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["OrderStatus"].Text;

                switch (statusId)
                {
                    case 1: //DRAFT
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //OPEN
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 3: //PRTL DLVRD
                        imgStatus.ImageUrl = "../resources/images/status/pdlvrd.png";
                        break;
                    case 4: //DLVRD
                        imgStatus.ImageUrl = "../resources/images/status/dlvrd.png";
                        break;
                    case 5: //BILLED
                        imgStatus.ImageUrl = "../resources/images/status/billed.png";
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
                    Response.Redirect("sales-order-create.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetSalesOrderList();

                dt.Columns.Remove("OrderId");
                dt.Columns.Remove("StatusId");

                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["ProjectName"].ColumnName = "Project Name";
                dt.Columns["OrderDate"].ColumnName = "Date";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["OrderStatus"].ColumnName = "Status";
                dt.Columns["OrderNumber"].ColumnName = "Order Number";
                dt.Columns["PurchaseOrder"].ColumnName = "Purchase Order Number";
                dt.Columns["GrandTotal"].ColumnName = "Grand Total";

                excel.ExportExcel(dt, ExcelType.Xls, "Sales Orders List ", "Sales_Orders");
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
                OrderNumber = txtOrderNumber.Text.ToTrimString();
                OrderStatusId = ddlOrderStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("sales-order-create.aspx", false);
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

        public string OrderNumber
        {
            get { return ViewState["OrderNumber"] != null ? ViewState["OrderNumber"].ToString() : ""; }
            set { ViewState["OrderNumber"] = value; }
        }

        public int OrderStatusId
        {
            get { return ViewState["OrderStatusId"] != null ? ViewState["OrderStatusId"].ToInt() : -1; }
            set { ViewState["OrderStatusId"] = value; }
        }
    }
}