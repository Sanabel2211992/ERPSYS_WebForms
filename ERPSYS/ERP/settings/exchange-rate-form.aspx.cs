using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ExchangeRateForm : System.Web.UI.Page
    {
        readonly CurrencyBLL _currency = new CurrencyBLL();

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
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetCurrecy(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("pricing.aspx?e={0}", 1), false);
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

        protected void GetCurrecy(int currencyId)
        {
            Currency currencyRate = _currency.GetCurrency(currencyId);

            if (currencyRate.CurrencyId <= 0)
            {
                Response.Redirect(string.Format("pricing.aspx?e={0}", 1));
            }

            CurrencyId = currencyId;
            lblCurrencyCode.Text = currencyRate.Code;
            lblCurrencyDescription.Text = currencyRate.Description;
            txtExchangeRate.Text = currencyRate.ExchangeRate.ToDecimalFormat();
        }

        protected void UpdateCurrencyRate()
        {
            Currency currency = new Currency();

            currency.CurrencyId = CurrencyId;
            if (txtExchangeRate.Value != null) currency.ExchangeRate = (decimal)txtExchangeRate.Value;

            string rMessage;
            _currency.UpdateCurrencyRate(currency, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("pricing.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "edit" && CurrencyId > 0)
                {
                    UpdateCurrencyRate();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("pricing.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int CurrencyId
        {
            get { return ViewState[" CurrencyId"] != null ? ViewState[" CurrencyId"].ToInt() : -1; }
            set { ViewState[" CurrencyId"] = value; }
        }
    }
}