using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.Production.AssemblyOrder report = new Reports.Production.AssemblyOrder();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int orderId = Request["id"].ToInt();
                    if (orderId > 0)
                    {
                        report.ReportParameters[0].Value = orderId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}