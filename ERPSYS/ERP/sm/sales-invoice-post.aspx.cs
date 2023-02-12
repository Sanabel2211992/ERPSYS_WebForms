using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoicePost : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostSalesInvoice();
        }

        protected void PostSalesInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int invoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _invoice.PostSalesInvoice(invoiceId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&e={1}", invoiceId, rMessageId));
                    }

                    Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", invoiceId, 2));
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
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