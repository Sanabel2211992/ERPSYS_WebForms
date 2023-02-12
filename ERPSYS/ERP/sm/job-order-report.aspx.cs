using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportDataBind();
            }
        }

        protected void rblReportView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDataBind();
        }

        protected void ReportDataBind()
        {

            if (Request["id"] != null && Request["id"] != string.Empty)
            {
                int jobOrderId = Request["id"].ToInt();
                if (jobOrderId > 0)
                {
                    if (rblReportView.SelectedValue == "Group")
                    {
                        Reports.SM.JobOrderGroup report = new Reports.SM.JobOrderGroup();
                        report.ReportParameters[0].Value = jobOrderId;
                        reportViewer.ReportSource = report;
                    }
                    else
                    {
                        Reports.SM.JobOrderCopmact report = new Reports.SM.JobOrderCopmact();
                        report.ReportParameters[0].Value = jobOrderId;
                        reportViewer.ReportSource = report;
                    }
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
                }
            }
        }
    }
}