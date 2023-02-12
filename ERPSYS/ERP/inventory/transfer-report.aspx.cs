using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.inventory
{
    public partial class TransferReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.Inventory.LocationTransfer report = new Reports.Inventory.LocationTransfer();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int trasnferId = Request["id"].ToInt();
                    if (trasnferId > 0)
                    {
                        report.ReportParameters[0].Value = trasnferId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}