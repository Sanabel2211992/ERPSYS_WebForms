using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderIssueMaterialsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportDataBind();
            }
        }
        protected void ReportDataBind()
        {

            if (Request["id"] != null && Request["id"] != string.Empty)
            {
                int jobOrderId = Request["id"].ToInt();
                if (jobOrderId > 0)
                {
                        Reports.Man.IssueMaterials report = new Reports.Man.IssueMaterials();
                        report.ReportParameters[0].Value = jobOrderId;
                        reportViewer.ReportSource = report;
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
                }
            }
        }
    }
}