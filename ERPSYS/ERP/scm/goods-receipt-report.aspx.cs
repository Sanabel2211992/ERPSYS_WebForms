using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reports.SCM.GoodsReceipt report = new Reports.SCM.GoodsReceipt();
                if (Request["id"] != null && Request["id"] != string.Empty)
                {
                    int goodsReceiptId = Request["id"].ToInt();
                    if (goodsReceiptId > 0)
                    {
                        report.ReportParameters[0].Value = goodsReceiptId;
                    }
                    else
                    {
                        Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
                    }
                }
                reportViewer.ReportSource = report;
            }
        }
    }
}