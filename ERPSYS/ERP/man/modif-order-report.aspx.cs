using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class ModificationOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.Man.ModificationOrderRpt report = new Reports.Man.ModificationOrderRpt();
                if (Request["id"] != null)
                {
                    int orderId = Request["id"].ToInt();
                    if (orderId > 0)
                    {
                        report.ReportParameters[0].Value = orderId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("modif-order-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}