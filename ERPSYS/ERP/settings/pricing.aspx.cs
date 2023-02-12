using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class Pricing : System.Web.UI.Page
    {
        readonly CurrencyBLL _currency = new CurrencyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowMessages();
                BindData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("currency_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("currency_rate_update_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            GetDefaultCurrency();
        }

        private void GetDefaultCurrency()
        {
            try
            {
                Currency currency = _currency.GetCurrency(UserSession.CurrencyId);

                if (currency.CurrencyId <= 0)
                {
                    Response.Redirect(string.Format("currency-list.aspx?e={0}", 1));
                }

                lblDefaultCurrency.Text = currency.Description;
            }
            catch (ThreadAbortException)
            {
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgCurrencyRate_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgCurrencyRate.DataSource = _currency.GetCurrencyConversion();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}