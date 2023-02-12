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
    public partial class PurchaseInvoiceList : System.Web.UI.Page
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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_pi_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(Notifications.GetMessage("scm_pi_id_not_exist"));
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

                ddlInvoiceStatus.DataTextField = "Name";
                ddlInvoiceStatus.DataValueField = "StatusId";
                ddlInvoiceStatus.DataSource = lookup.GetPurchseInvoiceHeaderStatus();
                ddlInvoiceStatus.DataBind();
                ddlInvoiceStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgPurchaseInvoiceList.Rebind();
        }

        private DataTable GetPurchaseInvoiceList()
        {
            try
            {
                return _scm.GetPurchaseInvoiceList(DateStart, DateEnd, SupplierName, InvoiceNumber, ReceiptNumber, SupplierInvoiceNumber, Remarks, StatusId, ItemSearch);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgPurchaseInvoiceList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgPurchaseInvoiceList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPurchaseInvoiceList.DataSource = GetPurchaseInvoiceList();
        }

        protected void rgPurchaseInvoiceList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();
                imgStatus.ToolTip = dataItem["InvoiceStatus"].Text;

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
                case "add":
                    Response.Redirect("~/ERP/scm/purchase-invoice-create.aspx");
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetPurchaseInvoiceList();

                dt.Columns.Remove("PurchaseInvoiceId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("StatusId1");
                dt.Columns.Remove("GrandTotal1");
                dt.Columns.Remove("CurrencyId");

                dt.Columns["InvoiceDate"].ColumnName = "Invoice Date";
                dt.Columns["InvoiceStatus"].ColumnName = "Invoice Status";
                dt.Columns["SupplierName"].ColumnName = "Supplier Name";
                dt.Columns["SupplierInvoiceNumber"].ColumnName = "Supplier Invoice Number";
                dt.Columns["Username"].ColumnName = "Prepared By";
                dt.Columns["GrandTotal"].ColumnName = "Grand Total";
                dt.Columns["InvoiceNumber"].ColumnName = "Invoice Number";
                dt.Columns["CurrencyCode"].ColumnName = "CUR";

                excel.ExportExcel(dt, ExcelType.Xls, "Purchase Invoices", "Purchase_Invoices");
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
                InvoiceNumber = txtInvoiceNumber.Text.ToTrimString();
                ReceiptNumber = txtReceiptNumber.Text.ToTrimString();
                SupplierInvoiceNumber = txtSupplierInvoiceNumber.Text.ToTrimString();
                Remarks = txtRemarks.Text.ToTrimString();
                StatusId = ddlInvoiceStatus.SelectedValue.ToInt();
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
        //    Response.Redirect("~/ERP/scm/purchase-invoice-create.aspx");
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

        public string InvoiceNumber
        {
            get { return ViewState["InvoiceNumber"] != null ? ViewState["InvoiceNumber"].ToString() : ""; }
            set { ViewState["InvoiceNumber"] = value; }
        }

        public string ReceiptNumber
        {
            get { return ViewState["ReceiptNumber"] != null ? ViewState["ReceiptNumber"].ToString() : ""; }
            set { ViewState["ReceiptNumber"] = value; }
        }

        public string SupplierInvoiceNumber
        {
            get { return ViewState["SupplierInvoiceNumber"] != null ? ViewState["SupplierInvoiceNumber"].ToString() : ""; }
            set { ViewState["SupplierInvoiceNumber"] = value; }
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

        public string ItemSearch
        {
            get { return ViewState["ItemSearch"] != null ? ViewState["ItemSearch"].ToString() : ""; }
            set { ViewState["ItemSearch"] = value; }
        }
    }
}