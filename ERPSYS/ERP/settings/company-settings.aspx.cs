using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class CompanySettings : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSystemSettings();
            }
        }

        protected void GetSystemSettings()
        {
            try
            {
                SystemSettings preferences = _setting.GetSystemSettings();

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
                rblEnableComplexPassword.SelectedValue = preferences.EnableComplexPassword ? "true" : "false";
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void SaveGeneralSettings()
        {
            SystemSettings preferences = new SystemSettings();

            preferences.CompanyId = UserSession.CompanyId;
            preferences.EnableSalesTax = cbEnableSalesTax.Checked;
            preferences.SalesTaxValue = cbEnableSalesTax.Checked ? txtSalesTaxValue.Value.ToDecimal() : 0;
            preferences.ShowSalesInvoicePrintTemplate = cbSalesInvoiceHeader.Checked;
            preferences.ShowProInvoicePrintTemplate = cbProInvoiceHeader.Checked;
            preferences.ShowDeliveryReceiptPrintTemplate = cbDeliveryReceiptHeader.Checked;
            preferences.AddExpensesValueToTotal = cbAddExpensesValueToTotal.Checked;
            preferences.HidePOQuantityInMR = cbHidePOQuantityInMR.Checked;
            preferences.ShowWatermarkInReports = cbShowWatermarkInReports.Checked;
            preferences.CreateJobOrderWhenSalesOrderPost = cbJobOrderSalesOrderPost.Checked;
            preferences.CreateJobOrderWhenSalesInvoicePost = cbJobOrderSalesInvoicePost.Checked;
            preferences.SetSalesInvoiceReferenceManually = cbSalesInvoiceSetReferenceManually.Checked;
            preferences.ShowOnlyRetailUserLocationInvoices = cbShowOnlyRetailUserLocationInvoices.Checked;

            string rMessage;
            int paymentTermsId = _setting.UpdateSystemGeneralSettings(preferences, out rMessage);

            if (rMessage != string.Empty || paymentTermsId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("system_settings_update_success"));
        }

        protected void SaveSecuritySettings()
        {
            SystemSettings preferences = new SystemSettings();

            preferences.CompanyId = UserSession.CompanyId;
            preferences.EnableComplexPassword = rblEnableComplexPassword.SelectedValue == "true";
            preferences.MinPasswordLength = txtMinPasswordLength.Text.ToInt();
            preferences.MinPasswordAge = txtMinPasswordAge.Text.ToInt();
            preferences.MaxPasswordAge = txtMaxPasswordAge.Text.ToInt();

            string rMessage;
            int paymentTermsId = _setting.UpdateSystemSecuritySettings(preferences, out rMessage);

            if (rMessage != string.Empty || paymentTermsId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("settings_operation_success"));
        }

        protected void cbEnableSalesTax_CheckedChanged(object sender, EventArgs e)
        {
            txtSalesTaxValue.Enabled = cbEnableSalesTax.Checked;
        }

        protected void btnSysSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                SaveGeneralSettings();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnPasswordSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                SaveSecuritySettings();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}