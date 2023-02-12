using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceCreate : System.Web.UI.Page
    {
        private readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

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

            ddlCurrencyView.DataTextField = "Description";
            ddlCurrencyView.DataValueField = "CurrencyId";
            ddlCurrencyView.DataSource = lookup.GetCurrency();
            ddlCurrencyView.DataBind();
            ddlCurrencyView.SelectedValue = UserSession.CurrencyId.ToString();

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();
            ddlPaymentMethod.SelectedValue = _invoice.DefaultPaymentMethodId.ToString();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
            ddlPaymentTerms.SelectedValue = _invoice.DefaultPaymentTermsId.ToString();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetSalesLocation();
            ddlLocation.DataBind();
            ddlLocation.SelectedValue = _invoice.DefaultLocationId.ToString();
        }

        private void CreateInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.CustomerId = UCCustomerList.CustomerId;
            invoice.PurchaseOrder = txtCustomerPO.Text.ToTrimString();
            invoice.ProjectName = txtProjectName.Text.ToTrimString();
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.CurrencyIdView = ddlCurrencyView.SelectedValue.ToInt();
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            invoice.Tax = SystemProperties.SalesTaxValue;

            string rMessage;
            var invoiceId = _invoice.CreateSalesInvoice(invoice, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-form.aspx?id={0}", invoiceId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-invoice-list.aspx"), false);
        }
    }
}