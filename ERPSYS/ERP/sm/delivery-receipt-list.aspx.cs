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
    public partial class DeliveryReceiptList : System.Web.UI.Page
    {
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sm_dr_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_id_not_exist"));
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

            ddlReceiptStatus.DataTextField = "Name";
            ddlReceiptStatus.DataValueField = "StatusId";
            ddlReceiptStatus.DataSource = lookup.GetDeliveryReceiptHeaderStatus();
            ddlReceiptStatus.DataBind();
            ddlReceiptStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgDeliveryReceiptList.Rebind();
        }

        protected void rgDeliveryReceiptList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        public DataTable GetDeliveryReceiptList()
        {
            try
            {
                return _delivery.GetDeliveryReceiptList(DateStart, DateEnd, CustomerName, ReceiptNumber, StatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgDeliveryReceiptList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgDeliveryReceiptList.DataSource = GetDeliveryReceiptList();          
        }

        protected void rgDeliveryReceiptList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["ReceiptStatus"].Text;

                switch (statusId)
                {
                    case 1: //DRAFT
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //Not Billed
                        imgStatus.ImageUrl = "../resources/images/status/nbilled.png";
                        break;
                    case 3: //Billed
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
                    Response.Redirect("~/ERP/sm/delivery-receipt-form.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetDeliveryReceiptList();

                dt.Columns.Remove("ReceiptId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("StatusId1");
                dt.Columns.Remove("CustomerId");
                dt.Columns.Remove("CustomerNameAr");
                dt.Columns.Remove("SalesOrderId");
                dt.Columns.Remove("InvoiceId");

                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["ReceiptDate"].ColumnName = "Date";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["ReceiptStatus"].ColumnName = "Status";
                dt.Columns["InvoiceNumber"].ColumnName = "Invoice Number";
                dt.Columns["SalesOrderNumber"].ColumnName = "Sales Order Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Delivery Receipt List", "Delivery_Receipt");
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
                ReceiptNumber = txtDeliveryReceiptNumber.Text.ToTrimString();
                StatusId = ddlReceiptStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ERP/sm/delivery-receipt-form.aspx", false);
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

        public string ReceiptNumber
        {
            get { return ViewState["ReceiptNumber"] != null ? ViewState["ReceiptNumber"].ToString() : ""; }
            set { ViewState["ReceiptNumber"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
    }
}