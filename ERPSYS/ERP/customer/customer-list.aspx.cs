using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Data;

namespace ERPSYS.ERP.customer
{
    public partial class CustomerList : System.Web.UI.Page
    {
        readonly CustomerBLL _customer = new CustomerBLL();

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
                if (Request.QueryString["e"] == "1") 
                {
                    AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("customer_id_not_exist"));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgCustomerList.Rebind();
        }

        private DataTable GetCustomerList()
        {
            try
            {
                return _customer.GetCustomerList(CustomerName, ContactName, Country, City);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }


        protected void rgCustomerList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgCustomerList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgCustomerList.DataSource = GetCustomerList();
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
                    Response.Redirect("~/ERP/customer/customer-details.aspx", false);
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetCustomerList();

                dt.Columns.Remove("CustomerId");
                dt.Columns.Remove("Discount");
                dt.Columns.Remove("IsActive");
                dt.Columns.Remove("DefaultPaymentTermsId");

                dt.Columns["NameAr"].ColumnName = "Arabic Name";
                dt.Columns["ContactName"].ColumnName = "Contact Name";
                dt.Columns["PostalCode"].ColumnName = "Postal Code";

                excel.ExportExcel(dt, ExcelType.Xls, "Customer List", "Customer_List");
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
                CustomerName = txtName.Text.ToTrimString();
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

        //protected void lnkbtnAdd_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ERP/customer/customer-details.aspx", false);
        //}

        //************************************** Properties ************************************//
        public string CustomerName
        {
            get { return ViewState["CustomerName"] != null ? ViewState["CustomerName"].ToString() : ""; }
            set { ViewState["CustomerName"] = value; }
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