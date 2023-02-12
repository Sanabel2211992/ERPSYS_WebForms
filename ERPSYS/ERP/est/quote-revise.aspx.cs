using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.est
{
    public partial class QuoteRevise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReviseSalesQuote();
        }

        protected void ReviseSalesQuote()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int quoteId = Request.QueryString["id"].ToInt();

                    QuoteBLL quote = new QuoteBLL();

                    string rMessage;
                    int newId = quote.ReviseSalesQuote(quoteId, out rMessage);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("quote-preview.aspx?e=4"));
                    }

                    Response.Redirect(string.Format("quote-preview.aspx?o=3&id={0}", newId));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}