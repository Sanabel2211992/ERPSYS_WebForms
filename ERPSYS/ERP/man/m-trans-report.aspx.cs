using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class MaterialTransferReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.Man.MaterialTransferRpt report = new Reports.Man.MaterialTransferRpt();
                if (Request["id"] != null)
                {
                    int transferId = Request["id"].ToInt();
                    if (transferId > 0)
                    {
                        report.ReportParameters[0].Value = transferId;
                    }
                    else
                    {
                        //Response.Redirect(string.Format("prod-order-preview.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}