using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.est
{
    public partial class QuoteRemark : System.Web.UI.Page
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
                    GetSalesQuote(Request.QueryString["id"].ToInt());
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

        protected void GetSalesQuote(int quoteId)
        {
            Quote quote = _quote.GetSalesQuoteHeader(quoteId);

            QuoteId = quote.QuoteId;
            lblQuoteNumber.Text = quote.QuoteNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = quote.CustomerName.ReplaceWhenNullOrEmpty("N/A");
            if (quote.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", quote.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

    
            lblProjectName.Text = quote.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblDate.Text = quote.QuoteDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = quote.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = quote.Status.ReplaceWhenNullOrEmpty("N/A");
            lblSalesEngineer.Text = quote.SalesEngineerName.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryNumber.Text = quote.InquiryNumber.ReplaceWhenNullOrEmpty("N/A");
            lblInquiryDate.Text = quote.InquiryDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblTemplate.Text = quote.CompanyCode.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = quote.CurrencyViewCode;
            lblPreparedBy.Text = quote.UserName;
        }

        protected void GetSalesQuoteRemarks(int quoteId)
        {
            DocumentTemplateClass quoteRemark = _quote.GetSalesQuoteRemarks(quoteId);

            QuoteId = quoteId;
            lblQuoteNumber.Text = quoteRemark.DocNumber;
            txtRemark1.Text = quoteRemark.Remark1;
            txtRemark2.Text = quoteRemark.Remark2;
        }

        protected void UpdateSalesQuoteRemarks()
        {
            DocumentTemplateClass quoteRemark = new DocumentTemplateClass();

            quoteRemark.DocId = QuoteId;
            quoteRemark.Remark1 = txtRemark1.Text.ToTrimString();
            quoteRemark.Remark2 = txtRemark2.Text.ToTrimString();

            string rMessage;
            _quote.UpdateSalesQuoteRemarks(quoteRemark, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                AppNotification.MessageBoxSuccess("Opertaion updated successfully");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateSalesQuoteRemarks();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-form.aspx?id={0}", QuoteId), false);
        }

        //************************************** Properties ************************************//

        private int QuoteId
        {
            get { return ViewState["QuoteId"] != null ? ViewState["QuoteId"].ToInt() : -1; }
            set { ViewState["QuoteId"] = value; }
        }
    }
}