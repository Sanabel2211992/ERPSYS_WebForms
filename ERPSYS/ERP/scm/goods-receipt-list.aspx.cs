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
    public partial class GoodsReceiptList : System.Web.UI.Page
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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_grn_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(Notifications.GetMessage("scm_grn_id_not_exist"));
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

                ddlLocation.DataTextField = "Name";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataSource = lookup.GetMaterialReceiptLocation();
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlReceiptStatus.DataTextField = "Name";
                ddlReceiptStatus.DataValueField = "StatusId";
                ddlReceiptStatus.DataSource = lookup.GetGoodsReceiptHeaderStatus();
                ddlReceiptStatus.DataBind();
                ddlReceiptStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgGoodsReceiptList.Rebind();
        }

        private DataTable GetGoodsReceipList()
        {
            try
            {
                return _scm.GetGoodsReceiptNoteList(DateStart, DateEnd, SupplierName, ReceiptNumber, OrderNumber, Remarks, StatusId, LocationId, ItemSearch);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgGoodsReceiptList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgGoodsReceiptList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgGoodsReceiptList.DataSource = GetGoodsReceipList();
        }

        protected void rgGoodsReceiptList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["ReceiptStatus"].Text;

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
                    case 4: //Returned
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
                    Response.Redirect("~/ERP/scm/goods-receipt-create.aspx");
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetGoodsReceipList();

                dt.Columns.Remove("PurchaseOrderId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("GoodsReceiptId");
                dt.Columns.Remove("SupplierId");
                dt.Columns.Remove("StatusId1");
                dt.Columns.Remove("InvoiceNumber");

                dt.Columns["ReceiptDate"].ColumnName = "Receipt Date";
                dt.Columns["ReceiptStatus"].ColumnName = "Receipt Status";
                dt.Columns["SupplierName"].ColumnName = "Supplier Name";
                dt.Columns["ReceiptNumber"].ColumnName = "Receipt Number";
                dt.Columns["Username"].ColumnName = "Prepared By";
                dt.Columns["OrderNumber"].ColumnName = "Order Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Material Receipt", "Material_Receipt");
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
                ReceiptNumber = txtReceiptNumber.Text.ToTrimString();
                OrderNumber = txtOrderNumber.Text.ToTrimString();
                Remarks = txtRemarks.Text.ToTrimString();
                StatusId = ddlReceiptStatus.SelectedValue.ToInt();
                LocationId = ddlLocation.SelectedValue.ToInt();
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
        //    Response.Redirect("~/ERP/scm/goods-receipt-create.aspx");
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

        public string ReceiptNumber
        {
            get { return ViewState["ReceiptNumber"] != null ? ViewState["ReceiptNumber"].ToString() : ""; }
            set { ViewState["ReceiptNumber"] = value; }
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

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : -1; }
            set { ViewState["LocationId"] = value; }
        }

        public string ItemSearch
        {
            get { return ViewState["ItemSearch"] != null ? ViewState["ItemSearch"].ToString() : ""; }
            set { ViewState["ItemSearch"] = value; }
        }
    }
}