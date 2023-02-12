using System.Web;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Reports.SM
{
    using System;

    public partial class SalesInvoice : Telerik.Reporting.Report
    {
        public SalesInvoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void SalesInvoice_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;

            int currencyId = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtCurrencyId", true)[0]).Value.ToInt();
            decimal grandTotal = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtGrandTotal", true)[0]).Value.ToDecimal();
            bool showTemplate = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtShowTemplate", true)[0]).Value.ToBool();
            bool isRefundInvoice = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtIsRefundInvoice", true)[0]).Value.ToBool();
            decimal taxRatio = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtSalesTaxRatio", true)[0]).Value.ToDecimal();
            decimal tax = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtTax", true)[0]).Value.ToDecimal();

            pnlTax.Visible = SystemProperties.HasSalesTax || tax > 0;
            txtSalesTax.Value = string.Format("Tax {0}% :", (taxRatio * 100).ToDecimalFormat(0));
            txtTotalWords.Value = NumberToWords.GetAmountInWords(grandTotal, currencyId);

            if (showTemplate)
            {
                SetReportTemplate(UserSession.CompanyId);
            }

            if (isRefundInvoice)
            {
                txtInvoiceTitle.Value = @"Refund Invoice";
                txtPaymentTermsTitle.Visible = false;
                txtPaymentTerms.Visible = false;
                pnlSignature.Visible = false;
                pnlRefundSignature.Visible = true;
            }
            else
            {
                pnlSignature.Visible = true;
                pnlRefundSignature.Visible = false;
            }
        }

        private void SetReportTemplate(int companyId)
        {
            SettingsBLL setting = new SettingsBLL();
            Members.CompanyPrintTemplate companyTemplate = setting.GetCompanyPrintReportTemplate(companyId);

            string fullPath = string.Format(HttpContext.Current.Server.MapPath(Members.CommonMember.SystemPrintFolderPath));
            string relativePath = Members.CommonMember.SystemPrintFolderPath.Replace("~", ".");

            if (System.IO.File.Exists(fullPath + companyTemplate.HeaderRightImageName))
            {
                pbHeaderRight.Value = relativePath + companyTemplate.HeaderRightImageName;
            }
            if (System.IO.File.Exists(fullPath + companyTemplate.HeaderCenterImageName))
            {
                pbHeaderCenter.Value = relativePath + companyTemplate.HeaderCenterImageName;
            }
            if (System.IO.File.Exists(fullPath + companyTemplate.HeaderLeftImageName))
            {
                pbHeaderLeft.Value = relativePath + companyTemplate.HeaderLeftImageName;
            }
            if (System.IO.File.Exists(fullPath + companyTemplate.FooterImageName))
            {
                pbFooter.Value = relativePath + companyTemplate.FooterImageName;
            }
            if (!companyTemplate.ShowWaterMark)
            {
                PageSettings.Watermarks[0].Opacity = 0;
            }
        }
    }
}