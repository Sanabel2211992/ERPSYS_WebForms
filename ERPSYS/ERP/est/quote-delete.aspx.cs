using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.est
{
    public partial class QuoteDelete : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteQuote();
        }

        protected void DeleteQuote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int quoteId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _quote.DeleteSalesQuote(quoteId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("quote-list.aspx?id={0}&e={1}", quoteId, rMessageId));
                    }

                    Response.Redirect(string.Format("quote-list.aspx?o={0}", 3), false);
                }
                else
                {
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1), false);
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