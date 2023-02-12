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
    public partial class ProformaInvoiceList : System.Web.UI.Page
    {
        readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("pro_invoice_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("pro_invoice_id_not_exist"));
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

            ddlInvoiceStatus.DataTextField = "Name";
            ddlInvoiceStatus.DataValueField = "StatusId";
            ddlInvoiceStatus.DataSource = lookup.GetProInvoiceHeaderStatus();
            ddlInvoiceStatus.DataBind();
            ddlInvoiceStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgInvoiceList.Rebind();
        }

        private DataTable GetProformaInvoiceList()
        {
            try
            {
                return _invoice.GetProformaInvoiceList(DateStart, DateEnd, CustomerName, InvoiceStatusId, ItemSearch);
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
            rgInvoiceList.DataSource = GetProformaInvoiceList();
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
                    case 1: //Open
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 2: //Close
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
                        break;
                    case 3: //Cancel
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
                    Response.Redirect("pro-invoice-create.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetProformaInvoiceList();

                dt.Columns.Remove("InvoiceId");
                dt.Columns.Remove("StatusId");
                dt.Columns.Remove("SubTotal");

                dt.Columns["InvoiceNumber"].ColumnName = "Invoice Number";
                dt.Columns["CustomerName"].ColumnName = "Customer Name";
                dt.Columns["PaymentTerms"].ColumnName = "Payment Terms";
                dt.Columns["InvoiceDate"].ColumnName = "Date";
                dt.Columns["DisplayName"].ColumnName = "Prepared By";
                dt.Columns["InvoiceStatus"].ColumnName = "Status";
                dt.Columns["GrandTotal"].ColumnName = "Grand Total";
                dt.Columns["CurrencyCode"].ColumnName = "Currency Code";

                excel.ExportExcel(dt, ExcelType.Xls, "Proforma Invoices List ", "Proforma_Invoices");
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
                InvoiceStatusId = ddlInvoiceStatus.SelectedValue.ToInt();
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
        //    Response.Redirect("pro-invoice-create.aspx", false);
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

        public int InvoiceStatusId
        {
            get { return ViewState["InvoiceStatusId"] != null ? ViewState["InvoiceStatusId"].ToInt() : -1; }
            set { ViewState["InvoiceStatusId"] = value; }
        }

        public string ItemSearch
        {
            get { return ViewState["ItemSearch"] != null ? ViewState["ItemSearch"].ToString() : ""; }
            set { ViewState["ItemSearch"] = value; }
        }
    }
}