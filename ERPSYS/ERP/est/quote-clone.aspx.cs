using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.est
{
    public partial class QuoteClone : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            CloneSalesQuote();
        }

        protected void CloneSalesQuote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int quoteId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    var copyQuoteId = _quote.CloneSalesQuote(quoteId, out rMessage);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("quote-list.aspx?e=2"));
                    }
                    Response.Redirect(string.Format("quote-preview.aspx?id={0}&o={1}", copyQuoteId, 5));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}