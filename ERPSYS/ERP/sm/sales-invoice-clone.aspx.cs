using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceClone : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            CloneSalesInvoice();
        }

        protected void CloneSalesInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int salesInvoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    var newSalesOrderId = _invoice.CloneSalesInvoice(salesInvoiceId, out rMessage);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-invoice-list.aspx?e=2"));
                    }

                    Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", newSalesOrderId, 5));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}