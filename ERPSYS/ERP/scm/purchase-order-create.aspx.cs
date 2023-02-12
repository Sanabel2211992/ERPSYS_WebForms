using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderCreate : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();
        readonly SettingsBLL _setting = new SettingsBLL();

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
                UCOrderDate.DateValue = DateTime.Today;
                GetItemLookupTables();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
            
            ddlPaymentTerms.SelectedValue = _scm.DefaultPaymentTermsId.ToString();

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();

            ddlCurrency.SelectedValue = UserSession.CurrencyId.ToString();

            CompanyProfile company = _setting.GetCompanyProfile(UserSession.CompanyId);

            txtShippingTo.Text = company.Name;
            txtShippingToAddress.Text = company.Address1;
        }

        void CreatePurchaseOrder()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();

            purchaseOrder.OrderDate = UCOrderDate.DateValue;
            purchaseOrder.SupplierId = UCSupplier.SupplierId;
            purchaseOrder.SupplierName = UCSupplier.SupplierName;
            purchaseOrder.ContactName = UCSupplier.ContactName;
            purchaseOrder.Phone = UCSupplier.Phone;
            purchaseOrder.SupplierAddress = UCSupplier.Address;
            purchaseOrder.ShipToCompany = txtShippingTo.Text;
            purchaseOrder.ShipToAddress = txtShippingToAddress.Text;
            purchaseOrder.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            purchaseOrder.CurrencyId = ddlCurrency.SelectedValue.ToInt();
            purchaseOrder.Tax = SystemProperties.SalesTaxValue;
            purchaseOrder.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var orderId = _scm.CreatePurchaseOrder(purchaseOrder, out rMessage);

            if (rMessage != string.Empty || orderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("purchase-order-form.aspx?id={0}", orderId));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreatePurchaseOrder();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("purchase-order-list.aspx"));
        }
    }
}