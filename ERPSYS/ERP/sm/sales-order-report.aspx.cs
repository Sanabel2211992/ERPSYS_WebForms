using System;
using System.Threading;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderReport : System.Web.UI.Page
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
                Reports.SM.SalesOrder report = new Reports.SM.SalesOrder();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int orderId = Request["id"].ToInt();
                    if (orderId > 0)
                    {
                        report.ReportParameters[0].Value = orderId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1));
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