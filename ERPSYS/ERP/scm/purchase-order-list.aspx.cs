using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderList : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

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
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_po_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(Notifications.GetMessage("scm_po_id_not_exist"));
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

                ddlOrderStatus.DataTextField = "Name";
                ddlOrderStatus.DataValueField = "StatusId";
                ddlOrderStatus.DataSource = lookup.GetPurchseOrderHeaderStatus();
                ddlOrderStatus.DataBind();
                ddlOrderStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgPurchaseOrderList.Rebind();
        }

        private DataTable GetPurchaseOrderList()
        {
            try
            {
                return _scm.GetPurchaseOrderList(DateStart, DateEnd, SupplierName, OrderNumber, Remarks, OrderStatusId, ItemSearch);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgPurchaseOrderList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgPurchaseOrderList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPurchaseOrderList.DataSource = GetPurchaseOrderList();
        }

        protected void rgPurchaseOrderList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                imgStatus.ToolTip = dataItem["OrderStatus"].Text;

                int statusId = dataItem["StatusId"].Text.ToInt();

                switch (statusId)
                {
                    case 1: //Draft
                        imgStatus.ImageUrl = "../resources/images/status/draft.png";
                        break;
                    case 2: //Open
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 3: //Partially Delivered
                        imgStatus.ImageUrl = "../resources/images/status/pdlvrd.png";
                        break;
                    case 5: //Canceled
                        imgStatus.ImageUrl = "../resources/images/status/canceled.png";
                        break;
                    case 6: //Closed
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
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
                    Response.Redirect("~/ERP/scm/purchase-order-create.aspx");
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetPurchaseOrderList();

                dt.Columns.Remove("PurchaseOrderId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("StatusId1");
                dt.Columns.Remove("SupplierId");
                dt.Columns.Remove("PaymentTermsId");
                dt.Columns.Remove("CurrencyId");

                dt.Columns["OrderDate"].ColumnName = "Order Date";
                dt.Columns["OrderStatus"].ColumnName = "Order Status";
                dt.Columns["SupplierName"].ColumnName = "Supplier Name";
                dt.Columns["ContactName"].ColumnName = "Contact Name";
                dt.Columns["Username"].ColumnName = "Prepared By";
                dt.Columns["CurrencyCode"].ColumnName = "CUR";
                dt.Columns["OrderNumber"].ColumnName = "Order Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Purchase Orders", "Purchase_Orders");
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
                SupplierName = txtSupplierName.Text.ToTrimString();
                OrderNumber = txtOrderNumber.Text.ToTrimString();
                Remarks = txtRemarks.Text.ToTrimString();
                OrderStatusId = ddlOrderStatus.SelectedValue.ToInt();
                ItemSearch = txtItemSearch.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ERP/scm/purchase-order-create.aspx");
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

        public string SupplierName
        {
            get { return ViewState["SupplierName"] != null ? ViewState["SupplierName"].ToString() : ""; }
            set { ViewState["SupplierName"] = value; }
        }

        public string OrderNumber
        {
            get { return ViewState["OrderNumber"] != null ? ViewState["OrderNumber"].ToString() : ""; }
            set { ViewState["OrderNumber"] = value; }
        }

        public string Remarks
        {
            get { return ViewState["Remarks"] != null ? ViewState["Remarks"].ToString() : ""; }
            set { ViewState["Remarks"] = value; }
        }

        public int OrderStatusId
        {
            get { return ViewState["OrderStatusId"] != null ? ViewState["OrderStatusId"].ToInt() : -1; }
            set { ViewState["OrderStatusId"] = value; }
        }

        public string ItemSearch
        {
            get { return ViewState["ItemSearch"] != null ? ViewState["ItemSearch"].ToString() : ""; }
            set { ViewState["ItemSearch"] = value; }
        }
    }
}