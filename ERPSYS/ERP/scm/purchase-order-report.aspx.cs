using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.SCM.PurchaseOrder report = new Reports.SCM.PurchaseOrder();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int purchaseOrderId = Request["id"].ToInt();
                    if (purchaseOrderId > 0)
                    {
                        report.ReportParameters[0].Value = purchaseOrderId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}