using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.scm
{
    public partial class SupplierList : System.Web.UI.Page
    {
        readonly SupplierBLL _supplier = new SupplierBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("supplier_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("supplier_delete_failed"));
                        break;
                }

                switch (Request.QueryString["o"])
                {
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("supplier_delete_success"));
                        break;
                }

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgSupplierList.Rebind();
        }

        private DataTable GetSupplierList()
        {
            try
            {
                return _supplier.GetSupplierList(SupplierName, ContactName, Country, City);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgSupplierList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgSupplierList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgSupplierList.DataSource = GetSupplierList();
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
                    Response.Redirect("~/ERP/scm/supplier-details.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetSupplierList();

                dt.Columns.Remove("SupplierId");
                dt.Columns.Remove("CurrencyId");
                dt.Columns.Remove("IsActive");
                dt.Columns.Remove("AddressRemarks");
                dt.Columns.Remove("AddressType");
                dt.Columns.Remove("DefaultPaymentTermsId");
                dt.Columns.Remove("DefaultCarrier");

                dt.Columns["NameAr"].ColumnName = "Arabic Name";
                dt.Columns["PostalCode"].ColumnName = "Postal Code";

                excel.ExportExcel(dt, ExcelType.Xls, "supplier List", "supplier_List");
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
                SupplierName = txtSupplierName.Text.ToTrimString();
                ContactName = txtContactName.Text.ToTrimString();
                Country = txtCountry.Text.ToTrimString();
                City = txtCity.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public string SupplierName
        {
            get { return ViewState["SupplierName"] != null ? ViewState["SupplierName"].ToString() : ""; }
            set { ViewState["SupplierName"] = value; }
        }

        public string ContactName
        {
            get { return ViewState["ContactName"] != null ? ViewState["ContactName"].ToString() : ""; }
            set { ViewState["ContactName"] = value; }
        }

        public string Country
        {
            get { return ViewState["Country"] != null ? ViewState["Country"].ToString() : ""; }
            set { ViewState["Country"] = value; }
        }

        public string City
        {
            get { return ViewState["City"] != null ? ViewState["City"].ToString() : ""; }
            set { ViewState["City"] = value; }
        }
    }
}