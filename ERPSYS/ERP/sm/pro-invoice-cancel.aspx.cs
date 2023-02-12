using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class ProformaInvoiceCancel : System.Web.UI.Page
    {
        readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            CancelProformaInvoice();
        }

        protected void CancelProformaInvoice()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int invoiceId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _invoice.CancelProformaInvoice(invoiceId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("pro-invoice-preview.aspx?id={0}&e={1}", invoiceId, rMessageId));
                    }

                    Response.Redirect(string.Format("pro-invoice-preview.aspx?id=" + invoiceId + "&o=2"), false);
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