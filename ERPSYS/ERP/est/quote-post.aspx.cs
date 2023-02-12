using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.est
{
    public partial class QuotePost : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostQuote();
        }

        protected void PostQuote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int quoteId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _quote.PostSalesQuote(quoteId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("quote-preview.aspx?id={0}&e={1}", quoteId, rMessageId));
                    }

                    Response.Redirect(string.Format("quote-preview.aspx?id={0}&o=2", quoteId), false);
                }
                else
                {
                    Response.Redirect(string.Format("quote-preview.aspx?e={0}", 1), false);
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}