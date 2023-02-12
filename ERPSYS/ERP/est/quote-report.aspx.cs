using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.est
{
    public partial class QuoteReport : System.Web.UI.Page
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
                int quoteId = Request["id"].ToInt();
                if (quoteId > 0)
                {
                    if (rblReportView.SelectedValue == "Summary")
                    {
                        Reports.Est.QuoteSummary report = new Reports.Est.QuoteSummary();
                        report.ReportParameters[0].Value = quoteId;
                        reportViewer.ReportSource = report;
                    }
                    else
                    {
                        Reports.Est.QuoteDetails report = new Reports.Est.QuoteDetails();
                        report.ReportParameters[0].Value = quoteId;
                        reportViewer.ReportSource = report;
                    }
                }
                else
                {
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
                }
            }
        }
    }
}