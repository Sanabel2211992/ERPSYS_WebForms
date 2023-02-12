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
    public partial class SalesInvoiceReportList : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeForm();
                GetLookupTables();
            }
        }

        protected void InitializeForm()
        {
            UCDateRange.StartDate = DateTime.Now.AddMonths(-1).ToDate();
            UCDateRange.EndDate = DateTime.Now.ToDate();
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetLocation();
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();
            ddlPaymentMethod.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgInvoiceList.Rebind();
        }

        private DataTable GetSalesInvoiceReportList()
        {
            try
            {
              return _invoice.GetSalesInvoiceReportList(DateStart, DateEnd, LocationId, PaymentMethodId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgInvoiceList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgInvoiceList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgInvoiceList.DataSource = GetSalesInvoiceReportList();
        }

        protected void rgInvoiceList_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["InvoiceStatus"].Text;

                switch (statusId)
                {
                    case 2: //POSTED
                        imgStatus.ImageUrl = "../resources/images/status/posted.png";
                        break;
                    case 3: //REFUNDED
                        imgStatus.ImageUrl = "../resources/images/status/refunded.png";
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
                DataTable dt = GetSalesInvoiceReportList();

                dt.Columns.Remove("InvoiceId");
                dt.Columns.Remove("StatusId");

                dt.Columns["InvoiceNumber"].ColumnName = "Invoice Number";
                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["PaymentMethod"].ColumnName = "Payment Method";
                dt.Columns["InvoiceDate"].ColumnName = "Date";
                dt.Columns["PreparedBy"].ColumnName = "Prepared By";
                dt.Columns["InvoiceStatus"].ColumnName = "Status";
                dt.Columns["GrandTotal"].ColumnName = "Total";

                excel.ExportExcel(dt, ExcelType.Xls, "Sales Invoices Report", "Sales_Invoices_Report");
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
                LocationId = ddlLocation.SelectedValue.ToInt();
                PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();

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
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : DateTime.Now.AddMonths(-1).ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : DateTime.Now.ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : -1; }
            set { ViewState["LocationId"] = value; }
        }

        public int PaymentMethodId
        {
            get { return ViewState["PaymentMethodId"] != null ? ViewState["PaymentMethodId"].ToInt() : -1; }
            set { ViewState["PaymentMethodId"] = value; }
        }
    }
}