using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoiceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.SCM.PurchaseInvoice report = new Reports.SCM.PurchaseInvoice();
                //var instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                //instanceReportSource.ReportDocument = report;

                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int purchaseInvoiceId = Request["id"].ToInt();
                    if (purchaseInvoiceId > 0)
                    {
                        report.ReportParameters[0].Value = purchaseInvoiceId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}