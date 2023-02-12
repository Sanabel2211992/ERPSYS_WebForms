using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceDelete : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteSalesInvoice();
        }

        protected void DeleteSalesInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int invoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _invoice.DeleteSalesInvoice(invoiceId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&e={1}", invoiceId, rMessageId));
                    }

                    Response.Redirect(string.Format("sales-invoice-list.aspx?o=1"), false);
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1), false);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}