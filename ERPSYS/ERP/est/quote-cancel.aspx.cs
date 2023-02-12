using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.est
{
    public partial class QuoteCancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CancelSalesQuote();
        }

        protected void CancelSalesQuote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int quoteId = Request.QueryString["id"].ToInt();

                    QuoteBLL quote = new QuoteBLL();

                    string rMessage;
                    quote.CancelSalesQuote(quoteId, out rMessage);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("quote-preview.aspx?e=6"));
                    }

                    Response.Redirect(string.Format("quote-preview.aspx?o=4&id={0}", quoteId));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}