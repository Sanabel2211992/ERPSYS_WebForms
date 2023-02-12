using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class CustomerDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT


        public DataTable GetCustomerList(string customerName, string contactName, string country, string city)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Name", customerName));
            paramCollection.Add(new DBParameter("@ContactName", contactName));
            paramCollection.Add(new DBParameter("@Country", country));
            paramCollection.Add(new DBParameter("@City", city));

            return Dbhelper.ExecuteDataTable("BASE_Customer_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCustomerListDialog(string customerName)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Name", customerName));

            return Dbhelper.ExecuteDataTable("BASE_CustomerList_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCustomer(int customerId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@customerId", customerId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Customer_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCustomerSearchBox(string name)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@name", name));

            return Dbhelper.ExecuteDataTable("BASE_Customer_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCustomerAdvancedSearchBox(string customerName)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CustomerName", customerName));

            return Dbhelper.ExecuteDataTable("BASE_Customer_Advanced_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int AddCustomer(Customer customer, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", customer.Name));
                paramCollection.Add(new DBParameter("@NameAr", customer.NameAr));
                paramCollection.Add(new DBParameter("@Remarks", customer.Remarks));
                paramCollection.Add(new DBParameter("@DefaultPaymentMethodId", customer.DefaultPaymentMethodId, DbType.Int32));
                paramCollection.Add(new DBParameter("@DefaultPaymentTermsId", customer.DefaultPaymentTermsId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Address1", customer.Address1));
                paramCollection.Add(new DBParameter("@Address2", customer.Address2));
                paramCollection.Add(new DBParameter("@City", customer.City));
                paramCollection.Add(new DBParameter("@State", customer.State));
                paramCollection.Add(new DBParameter("@Country", customer.Country));
                paramCollection.Add(new DBParameter("@PostalCode", customer.PostalCode));
                paramCollection.Add(new DBParameter("@ContactName", customer.ContactName));
                paramCollection.Add(new DBParameter("@Phone", customer.Phone));
                paramCollection.Add(new DBParameter("@Fax", customer.Fax));
                paramCollection.Add(new DBParameter("@Email", customer.Email));
                paramCollection.Add(new DBParameter("@IsActive", customer.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("BASE_Customer_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("customer_add_duplicate");
                        break;
                    case -1:
                        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                        break;
                }
            }
            catch (Exception ex)
            {
                rMsg = ex.Message;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public void UpdateCustomer(Customer customer, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@customerId", customer.CustomerId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Name", customer.Name));
                paramCollection.Add(new DBParameter("@NameAr", customer.NameAr));
                paramCollection.Add(new DBParameter("@Remarks", customer.Remarks));
                paramCollection.Add(new DBParameter("@DefaultPaymentMethodId", customer.DefaultPaymentMethodId, DbType.Int32));
                paramCollection.Add(new DBParameter("@DefaultPaymentTermsId", customer.DefaultPaymentTermsId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Address1", customer.Address1));
                paramCollection.Add(new DBParameter("@Address2", customer.Address2));
                paramCollection.Add(new DBParameter("@City", customer.City));
                paramCollection.Add(new DBParameter("@State", customer.State));
                paramCollection.Add(new DBParameter("@Country", customer.Country));
                paramCollection.Add(new DBParameter("@PostalCode", customer.PostalCode));
                paramCollection.Add(new DBParameter("@ContactName", customer.ContactName));
                paramCollection.Add(new DBParameter("@Phone", customer.Phone));
                paramCollection.Add(new DBParameter("@Fax", customer.Fax));
                paramCollection.Add(new DBParameter("@Email", customer.Email));
                paramCollection.Add(new DBParameter("@IsActive", customer.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("BASE_Customer_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("customer_update_duplicate");
                        break;
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

        //**************************************************************************************************************************//IMPORT

        public DataTable ImportCustomer(string xmlCustomer)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@xmlCustomer", xmlCustomer));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Customer_Import", paramCollection, CommandType.StoredProcedure);
        }

    }
}