using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.sm
{
    public partial class ProformaInvoiceCreate : System.Web.UI.Page
    {
        private readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();

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
        }

        private void CreateProformaInvoice()
        {
            ProformaInvoice invoice = new ProformaInvoice();

            invoice.CustomerId = UCCustomerList.CustomerId;
            invoice.ProjectName = txtProjectName.Text.ToTrimString();
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();
            invoice.Tax = SystemProperties.SalesTaxValue;

            string rMessage;
            var invoiceId = _invoice.CreateProformaInvoice(invoice, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("pro-invoice-form.aspx?id={0}", invoiceId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateProformaInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("pro-invoice-list.aspx"), false);
        }
    }
}