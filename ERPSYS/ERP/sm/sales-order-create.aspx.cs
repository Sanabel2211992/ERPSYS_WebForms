using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderCreate : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                UCDatePicker.DateValue = DateTime.Today;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void CreateSalesOrder()
        {
            SalesOrder order = new SalesOrder();

            order.CustomerId = UCCustomer.CustomerId;
            order.PurchaseOrder = txtCustomerPO.Text.ToTrimString();
            order.ProjectName = txtProjectName.Text.ToTrimString();
            order.OrderDate = UCDatePicker.DateValue;
            order.Tax = SystemProperties.SalesTaxValue;
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var orderId = _order.CreateSalesOrder(order, out rMessage);

            if (rMessage != string.Empty || orderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-order-form.aspx?id={0}", orderId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateSalesOrder();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-order-list.aspx"), false);
        }
    }
}