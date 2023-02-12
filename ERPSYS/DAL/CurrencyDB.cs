using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class CurrencyDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetCurrency(int currencyId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@currencyId", currencyId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Currency_Get", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCurrencyProperties(int currencyId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CurrencyId", currencyId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_CurrencyProperties_Get", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCurrencyList(string code)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Code", code));
            return Dbhelper.ExecuteDataTable("GLOBAL_CurrencyList_Get", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCurrencyConversion()
        {   
            return Dbhelper.ExecuteDataTable("GLOBAL_CurrencyConversion_GET", CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//UPDATE

        public void UpdateCurrency(Currency currency, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@CurrencyId", currency.CurrencyId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Code", currency.Code));
                paramCollection.Add(new DBParameter("@Description", currency.Description));
                paramCollection.Add(new DBParameter("@Symbol", currency.Symbol));
                paramCollection.Add(new DBParameter("@Status", currency.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@DecimalPlaces", currency.DecimalPlaces, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("GLOBAL_Currency_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }
        }

        public void UpdateCurrencyRate(Currency currency, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@currencyId", currency.CurrencyId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ExchangeRate", currency.ExchangeRate, DbType.Decimal));     
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("GLOBAL_Currency_ExchangeRate_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }
        }
    }
}