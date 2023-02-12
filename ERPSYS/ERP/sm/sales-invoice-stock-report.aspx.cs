using System;
using System.Threading;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceStockReport : System.Web.UI.Page
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
            try
            {
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int invoiceId = Request["id"].ToInt();
                    if (invoiceId > 0)
                    {
                        if (rblReportView.SelectedValue == "Group")
                        {
                            Reports.SM.StockReceiptGroup report = new Reports.SM.StockReceiptGroup();
                            report.ReportParameters[0].Value = invoiceId;
                            reportViewer.ReportSource = report;
                        }
                        else
                        {
                            Reports.SM.StockReceiptCompact report = new Reports.SM.StockReceiptCompact();
                            report.ReportParameters[0].Value = invoiceId;
                            reportViewer.ReportSource = report;
                        }
                    }
                    else
                    {
                        Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
                    }
                }
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