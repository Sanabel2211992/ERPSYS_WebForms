using System;
using System.Threading;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class ProformaInvoiceReport : System.Web.UI.Page
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
            try
            {
                Reports.SM.ProInvoice report = new Reports.SM.ProInvoice();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int invoiceId = Request["id"].ToInt();
                    if (invoiceId > 0)
                    {
                        report.ReportParameters[0].Value = invoiceId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}