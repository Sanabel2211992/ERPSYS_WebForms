using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.proj
{
    public partial class proj_summary_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.Proj.ProjSummaryRpt report = new Reports.Proj.ProjSummaryRpt();
                if (Request["id"] != null)
                {
                    int projectId = Request["id"].ToInt();
                    if (projectId > 0)
                    {
                        report.ReportParameters[0].Value = projectId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("proj-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}