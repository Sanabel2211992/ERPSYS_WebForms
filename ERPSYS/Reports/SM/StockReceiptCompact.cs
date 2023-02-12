using System.Web;
using ERPSYS.BLL;

namespace ERPSYS.Reports.SM
{
    using System;

    public partial class StockReceiptCompact : Telerik.Reporting.Report
    {
        public StockReceiptCompact()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void StockReceiptCompact_ItemDataBound(object sender, EventArgs e)
        {
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
            if (!companyTemplate.ShowWaterMark)
            {
                PageSettings.Watermarks[0].Opacity = 0;
            }
        }
    }
}