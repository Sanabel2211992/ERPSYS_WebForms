using System.Web;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Reports.Proj
{
    using System;

    public partial class ProjDetailsRpt : Telerik.Reporting.Report
    {
        public ProjDetailsRpt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ProjDetailsRpt_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;

            int currencyId = UserSession.CurrencyId;
            decimal netprofit = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtNetprofit", true)[0]).Value.ToDecimal();

            txtTotalWords.Value = NumberToWords.GetAmountInWords(netprofit, currencyId);
            string CurrencyCode = UserSession.CurrencyCode;
            txtPurchasesCurrency.Value = CurrencyCode;
            txtExpenseCurrency.Value = CurrencyCode;
            txtSalesCurrency.Value = CurrencyCode;
            txtNetProfitCurrency.Value = CurrencyCode;
            
            SetReportTemplate(UserSession.CompanyId);           
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
        }

        private void ProjSummaryRpt_ItemDataBound(object sender, EventArgs e)
        {

        }
    }
}