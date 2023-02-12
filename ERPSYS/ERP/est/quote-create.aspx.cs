using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.est
{
    public partial class QuoteCreate : System.Web.UI.Page
    {

        readonly QuoteBLL _quote = new QuoteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
                GetItemLookupTables();
            }
        }

        private void InitializeComponent()
        {
            try
            {
                UCDatePicker.DateValue = DateTime.Today;
                UCInquiryDate.DateValue = DateTime.Today;

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCurrencyView.DataTextField = "Description";
            ddlCurrencyView.DataValueField = "CurrencyId";
            ddlCurrencyView.DataSource = lookup.GetCurrency();
            ddlCurrencyView.DataBind();
            ddlCurrencyView.SelectedValue = UserSession.CurrencyId.ToString();

            ddlSalesEngineer.DataTextField = "DisplayName";
            ddlSalesEngineer.DataValueField = "UserId";
            ddlSalesEngineer.DataSource = lookup.GetSalesEngineerList();
            ddlSalesEngineer.DataBind();
            ddlSalesEngineer.Items.Insert(0, new ListItem("Not Assigned", "-1"));

            ddlCompanyCode.DataTextField = "Code";
            ddlCompanyCode.DataValueField = "CompanyId";
            ddlCompanyCode.DataSource = lookup.GetSystemCompanyCode();
            ddlCompanyCode.DataBind();

            ddlCompanyCode.SelectedValue = UserSession.CompanyId.ToString();
        }

        protected void CreateQuote()
        {
            Quote quote = new Quote();

            quote.CustomerId = UCCustomerList.CustomerId;
            quote.ProjectName = txtProjectName.Text.ToTrimString();
            quote.QuoteDate = UCDatePicker.DateValue;
            quote.SalesEngineerId = ddlSalesEngineer.SelectedValue.ToInt();
            quote.CurrencyIdView = ddlCurrencyView.SelectedValue.ToInt();
            quote.InquiryNumber = txtInquiryNumber.Text.ToTrimString();
            quote.InquiryDate = UCInquiryDate.DateValue;
            quote.CompanyIdView = ddlCompanyCode.SelectedValue.ToInt();
            quote.Tax = SystemProperties.SalesTaxValue;
            quote.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var quoteId = _quote.CreateSalesQuote(quote, out rMessage);

            if (rMessage != string.Empty || quoteId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("quote-form.aspx?id={0}", quoteId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateQuote();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("quote-list.aspx"), false);
        }
    }
}