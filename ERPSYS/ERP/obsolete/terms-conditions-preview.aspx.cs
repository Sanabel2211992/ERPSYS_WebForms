using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.obsolete
{
    public partial class terms_conditions_preview : System.Web.UI.Page
    {
        readonly QuoteBLL _quote = new QuoteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetSalesQuoteRemarks(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("quote-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetSalesQuoteRemarks(int quoteId)
        {
            DocumentTemplateClass quoteRemark = _quote.GetSalesQuoteRemarks(quoteId);

            QuoteId = quoteId;
            txtRemark1.Text = quoteRemark.Remark1;
            txtRemark2.Text = quoteRemark.Remark2;
        }

        //************************************** Properties ************************************//
        private int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }
    }
}