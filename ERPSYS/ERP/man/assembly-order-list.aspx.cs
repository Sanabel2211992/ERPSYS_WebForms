using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderList : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _assembly = new AssemblyOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLookupTables();
            }
        }

        protected void GetLookupTables()
        {
            try
            {
                LookupBLL lookup = new LookupBLL();

                ddlStatus.DataTextField = "Name";
                ddlStatus.DataValueField = "StatusId";
                ddlStatus.DataSource = lookup.GetAssemblyOrderHeaderStatus();
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
            rgAssemblyOrderList.Rebind();
        }

        private DataTable GetAssemblyOrderList()
        {
            try
            {
                return _assembly.GetAssemblyOrderListX(DateStart, DateEnd, JobOrderNumber, StatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgAssemblyOrderList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgAssemblyOrderList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgAssemblyOrderList.DataSource = GetAssemblyOrderList();
        }

        protected void rgAssemblyOrderList_ItemDataBound(object sender, GridItemEventArgs e)
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
                    case 2: //POSTED
                        imgStatus.ImageUrl = "../resources/images/status/posted.png";
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
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetAssemblyOrderList();

                dt.Columns.Remove("AssemblyOrderId");
                dt.Columns.Remove("StatusId");

                dt.Columns["AssemblyOrderNumber"].ColumnName = "Production Number";
                dt.Columns["JobOrderNumber"].ColumnName = "Job Order Number";
                dt.Columns["ProjectName"].ColumnName = "Project Name";
                dt.Columns["OrderDate"].ColumnName = "Date";
                dt.Columns["Preparedby"].ColumnName = "Prepared by";
                dt.Columns["OrderStatus"].ColumnName = "Status";

                excel.ExportExcel(dt, ExcelType.Xls, "Assembly Orders", "Assembly_Orders");
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
                JobOrderNumber = txtJobOrderNumber.Text.ToTrimString();
                StatusId = ddlStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public DateTime DateStart
        {
            get { return ViewState["StartDate"] != null ? ViewState["StartDate"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["StartDate"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["EndDate"] != null ? ViewState["EndDate"].ToDate() : "1/1/2900".ToDate(); }
            set { ViewState["EndDate"] = value; }
        }

        public string JobOrderNumber
        {
            get { return ViewState["JobOrderNumber"] != null ? ViewState["JobOrderNumber"].ToString() : ""; }
            set { ViewState["JobOrderNumber"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
    }
}