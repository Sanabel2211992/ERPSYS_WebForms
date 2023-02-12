using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class DeliveryReceiptReport : System.Web.UI.Page
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
                int receiptId = Request["id"].ToInt();
                if (receiptId > 0)
                {
                    if (rblReportView.SelectedValue == "Group")
                    {
                        Reports.SM.DeliveryReceiptGroup report = new Reports.SM.DeliveryReceiptGroup();
                        report.ReportParameters[0].Value = receiptId;
                        reportViewer.ReportSource = report;
                    }
                    else
                    {
                        Reports.SM.DeliveryReceipt report = new Reports.SM.DeliveryReceipt();
                        report.ReportParameters[0].Value = receiptId;
                        reportViewer.ReportSource = report;
                    }
                }
                else
                {
                    Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
                }
            }
        }
    }
}