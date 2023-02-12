using System.Web;
using ERPSYS.BLL;
using ERPSYS.Members;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Reports.SCM
{
    using System;

    public partial class GoodsReceipt : Telerik.Reporting.Report
    {
        public GoodsReceipt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void GoodsReceipt_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;

            int statusId = ((Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(rpt, "txtStatusId", true)[0]).Value.ToInt();

            pnlCancelRemarks.Visible = statusId == 4;
            pnlStatus.Visible = statusId == 4;

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