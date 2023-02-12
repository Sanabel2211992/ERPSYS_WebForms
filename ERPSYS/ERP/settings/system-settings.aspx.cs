using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class SystemSettingsForm : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSystemSettings();
            }
        }

        protected void cbEnableSalesTax_CheckedChanged(object sender, EventArgs e)
        {
            txtSalesTaxValue.Enabled = cbEnableSalesTax.Checked;
        }

        protected void GetSystemSettings()
        {
            try
            {
                SystemSettings preferences = _setting.GetSystemSettings();

                if (preferences.CompanyId <= 0)
                {
                    Response.Redirect(string.Format("company-list.aspx?e={0}", 1));
                }

                cbEnableSalesTax.Checked = preferences.EnableSalesTax;
                txtSalesTaxValue.Text = preferences.EnableSalesTax ? preferences.SalesTaxValue.ToDecimalFormat() : 0.ToString();
                cbSalesInvoiceHeader.Checked = preferences.ShowSalesInvoicePrintTemplate;
                cbProInvoiceHeader.Checked = preferences.ShowProInvoicePrintTemplate;
                cbDeliveryReceiptHeader.Checked = preferences.ShowDeliveryReceiptPrintTemplate;
                cbAddExpensesValueToTotal.Checked = preferences.AddExpensesValueToTotal;
                cbHidePOQuantityInMR.Checked = preferences.HidePOQuantityInMR;
                cbShowWatermarkInReports.Checked = preferences.ShowWatermarkInReports;
                cbJobOrderSalesOrderPost.Checked = preferences.CreateJobOrderWhenSalesOrderPost;
                cbJobOrderSalesInvoicePost.Checked = preferences.CreateJobOrderWhenSalesInvoicePost;
                cbSalesInvoiceSetReferenceManually.Checked = preferences.SetSalesInvoiceReferenceManually;
                cbShowOnlyRetailUserLocationInvoices.Checked = preferences.ShowOnlyRetailUserLocationInvoices;

                txtMinPasswordLength.Value = preferences.MinPasswordLength.ToInt();
                txtMinPasswordAge.Value = preferences.MinPasswordAge.ToInt();
                txtMaxPasswordAge.Value = preferences.MaxPasswordAge.ToInt();
                cbEnableComplexPassword.Checked = preferences.EnableComplexPassword;

            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateSystemGeneralSettings()
        {
            SystemSettings settings = new SystemSettings();

            settings.CompanyId = UserSession.CompanyId;
            settings.EnableSalesTax = cbEnableSalesTax.Checked;
            settings.SalesTaxValue = cbEnableSalesTax.Checked ? txtSalesTaxValue.Value.ToDecimal() : 0;
            settings.ShowSalesInvoicePrintTemplate = cbSalesInvoiceHeader.Checked;
            settings.ShowProInvoicePrintTemplate = cbProInvoiceHeader.Checked;
            settings.ShowDeliveryReceiptPrintTemplate = cbDeliveryReceiptHeader.Checked;
            settings.AddExpensesValueToTotal = cbAddExpensesValueToTotal.Checked;
            settings.HidePOQuantityInMR = cbHidePOQuantityInMR.Checked;
            settings.ShowWatermarkInReports = cbShowWatermarkInReports.Checked;
            settings.CreateJobOrderWhenSalesOrderPost = cbJobOrderSalesOrderPost.Checked;
            settings.CreateJobOrderWhenSalesInvoicePost = cbJobOrderSalesInvoicePost.Checked;
            settings.SetSalesInvoiceReferenceManually = cbSalesInvoiceSetReferenceManually.Checked;
            settings.ShowOnlyRetailUserLocationInvoices = cbShowOnlyRetailUserLocationInvoices.Checked;

            string rMessage;
            int paymentTermsId = _setting.UpdateSystemGeneralSettings(settings, out rMessage);

            if (rMessage != string.Empty || paymentTermsId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("system_settings_update_success"));
        }

        protected void UpdateSystemSecuritySettings()
        {
            SystemSettings password = new SystemSettings();

            password.CompanyId = UserSession.CompanyId;
            password.EnableComplexPassword = cbEnableComplexPassword.Checked;
            password.MinPasswordLength = txtMinPasswordLength.Text.ToInt();
            password.MinPasswordAge = txtMinPasswordAge.Text.ToInt();
            password.MaxPasswordAge = txtMaxPasswordAge.Text.ToInt();

            string rMessage;
            int paymentTermsId = _setting.UpdateSystemSecuritySettings(password, out rMessage);

            if (rMessage != string.Empty || paymentTermsId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("system_settings_update_success"));
        }

        protected void btnGeneralSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateSystemGeneralSettings();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSecuritySettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateSystemSecuritySettings();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}