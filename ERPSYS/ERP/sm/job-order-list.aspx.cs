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
    public partial class JobOrderList : System.Web.UI.Page
    {
        readonly JobOrderBLL _jorder = new JobOrderBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_id_not_exist"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_inactive"));
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
            try
            {
                LookupBLL lookup = new LookupBLL();

                ddlStatus.DataTextField = "Name";
                ddlStatus.DataValueField = "StatusId";
                ddlStatus.DataSource = lookup.GetJobOrderHeaderStatus();
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgJobOrderList.Rebind();
        }

        private DataTable GetJobOrderList()
        {
            try
            {
                return _jorder.GetJobOrderList(DateStart, DateEnd, CustomerName, OrderNumber, StatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgJobOrderList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgJobOrderList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgJobOrderList.DataSource = GetJobOrderList();
        }

        protected void rgJobOrderList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["OrderStatus"].Text;

                switch (statusId)
                {
                    case 1: //Draft
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //Open
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 3: //Closed
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
                        break;
                    case 4: //Canceled
                        imgStatus.ImageUrl = "../resources/images/status/canceled.png";
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
                    Response.Redirect("job-order-create.aspx", false); break;
            }
        }

        protected void ExportToExcelFile()           

        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetJobOrderList();

                dt.Columns.Remove("JobOrderId");
                dt.Columns.Remove("StatusId");

                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["ProjectName"].ColumnName = "Project Name";
                dt.Columns["OrderDate"].ColumnName = "Date";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["OrderStatus"].ColumnName = "Status";
                dt.Columns["OrderNumber"].ColumnName = "Order Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Job Orders List ", "Job_Orders");
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
                OrderNumber = txtJobOrderNumber.Text.ToTrimString();
                StatusId = ddlStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("job-order-create.aspx", false);
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

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
    }
}