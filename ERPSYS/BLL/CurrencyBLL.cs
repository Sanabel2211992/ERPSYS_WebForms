using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class CurrencyBLL
    {
        private readonly CurrencyDB _currency = new CurrencyDB();

        //**************************************************************************************************************************//SELECT

        public Currency GetCurrency(int currencyId)
        {
            DataTable dt = _currency.GetCurrency(currencyId);

            Currency currency = new Currency();

            if (dt.Rows.Count == 0)
            {
                currency.CurrencyId = -1;
                return currency;
            }

            DataRow dr = dt.Rows[0];

            currency.CurrencyId = currencyId;
            currency.Code = dr["Code"].ToString();
            currency.Description = dr["Description"].ToString();
            currency.Symbol = dr["Symbol"].ToString();
            currency.IsActive = dr["IsActive"].ToBool();
            currency.DecimalPlaces = dr["DecimalPlaces"].ToInt();
            currency.DecimalSeparator = dr["DecimalSeparator"].ToString();
            currency.ThousandsSeparator = dr["ThousandsSeparator"].ToString();
            currency.CrCurrencyPositionType = dr["CRCurrencyPositionType"].ToInt();
            currency.CrNegativeType = dr["CRNegativeType"].ToInt();
            currency.ExchangeRate = dr["ExchangeRate"].ToDecimal();

            return currency;
        }

        public CurrencyProperties GetCurrencyProperties(int currencyId)
        {
            DataTable dt = _currency.GetCurrencyProperties(currencyId);

            CurrencyProperties currency = new CurrencyProperties();

            if (dt.Rows.Count == 0)
            {
                currency.CurrencyId = -1;
                return currency;
            }

            DataRow dr = dt.Rows[0];

            currency.CurrencyId = currencyId;
            currency.Code = dr["Code"].ToString();
            currency.Name = dr["Name"].ToString();
            currency.FractionName = dr["FractionName"].ToString();
            currency.FractionDigit = dr["FractionDigit"].ToInt();
            currency.FractionValue = dr["FractionValue"].ToInt();

            return currency;

        }

        public DataTable GetCurrencyList(string code)
        {
            return _currency.GetCurrencyList(code);
        }

        public DataTable GetCurrencyConversion()
        {
            return _currency.GetCurrencyConversion();
        }

        //**************************************************************************************************************************//UPDATE

        public void UpdateCurrency(Currency currency, out string rMsg)
        {
            _currency.UpdateCurrency(currency, out rMsg);
        }

        public void UpdateCurrencyRate(Currency currency, out string rMsg)
        {
            _currency.UpdateCurrencyRate(currency, out rMsg);
        }

    }
}