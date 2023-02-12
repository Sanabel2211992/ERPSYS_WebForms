using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class CurrencyForm : System.Web.UI.Page
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
                Response.Redirect(string.Format("currency-list.aspx?e={0}", 1));
            }

            CurrencyId = currencyId;
            txtCurrencyCode.Text = currencyRate.Code;
            txtDescription.Text = currencyRate.Description;
            txtSymbol.Text = currencyRate.Symbol;
            txtDecimalPlaces.Text = currencyRate.DecimalPlaces.ToString();
            cbIsActive.Checked = currencyRate.IsActive;
        }

        protected void UpdateCurrency()
        {
            Currency currency = new Currency();

            currency.CurrencyId = CurrencyId;
            currency.Code = txtCurrencyCode.Text;
            currency.Description = txtDescription.Text;
            currency.Symbol = txtSymbol.Text;
            currency.IsActive = cbIsActive.Checked;
            currency.DecimalPlaces = txtDecimalPlaces.Text.ToInt();

            string rMessage;
            _currency.UpdateCurrency(currency, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("currency-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "edit" && CurrencyId > 0)
                {
                    UpdateCurrency();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("currency-list.aspx"), false);
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
