using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.Reports.Item
{
    using System;
    using System.Web;

    public partial class ItemBOM : Telerik.Reporting.Report
    {
        public ItemBOM()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ItemBOM_ItemDataBound(object sender, EventArgs e)
        {
            SetReportTemplate(UserSession.CompanyId);
        }

        private void SetReportTemplate(int companyId)
        {
            SettingsBLL setting = new SettingsBLL();
            CompanyPrintTemplate companyTemplate = setting.GetCompanyPrintReportTemplate(companyId);

            string fullPath = string.Format(HttpContext.Current.Server.MapPath(CommonMember.SystemPrintFolderPath));
            string relativePath = CommonMember.SystemPrintFolderPath.Replace("~", ".");

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
    }
}