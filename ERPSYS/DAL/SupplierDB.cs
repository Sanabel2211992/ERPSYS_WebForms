using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class SupplierDB :CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetSupplierList(string supplierName, string contactName, string country, string city)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Name", supplierName));
            paramCollection.Add(new DBParameter("@ContactName", contactName));
            paramCollection.Add(new DBParameter("@Country", country));
            paramCollection.Add(new DBParameter("@City", city));

            return Dbhelper.ExecuteDataTable("BASE_Supplier_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSupplier(int supplierId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@supplierId", supplierId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Supplier_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSupplierSearchBox(string name)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@name", name));

            return Dbhelper.ExecuteDataTable("BASE_Supplier_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int AddSupplier(Supplier supplier, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", supplier.Name));
            paramCollection.Add(new DBParameter("@NameAr", supplier.NameAr));
            paramCollection.Add(new DBParameter("@Remarks", supplier.Remarks));
            paramCollection.Add(new DBParameter("@DefaultPaymentTermsId", supplier.DefaultPaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Address1", supplier.Address1));
            paramCollection.Add(new DBParameter("@Address2", supplier.Address2));
            paramCollection.Add(new DBParameter("@City", supplier.City));
            paramCollection.Add(new DBParameter("@State", supplier.State));
            paramCollection.Add(new DBParameter("@Country", supplier.Country));
            paramCollection.Add(new DBParameter("@PostalCode", supplier.PostalCode));
            paramCollection.Add(new DBParameter("@ContactName", supplier.ContactName));
            paramCollection.Add(new DBParameter("@Phone", supplier.Phone));
            paramCollection.Add(new DBParameter("@Fax", supplier.Fax));
            paramCollection.Add(new DBParameter("@Email", supplier.Email));
            paramCollection.Add(new DBParameter("@IsActive", supplier.IsActive,DbType.Boolean));
            paramCollection.Add(new DBParameter("@CurrencyId", supplier.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Supplier_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() -2, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("supplier_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSupplier(Supplier supplier, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@SupplierId", supplier.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", supplier.Name));
            paramCollection.Add(new DBParameter("@NameAr", supplier.NameAr));
            paramCollection.Add(new DBParameter("@Remarks", supplier.Remarks));
            paramCollection.Add(new DBParameter("@DefaultPaymentTermsId", supplier.DefaultPaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Address1", supplier.Address1));
            paramCollection.Add(new DBParameter("@Address2", supplier.Address2));
            paramCollection.Add(new DBParameter("@City", supplier.City));
            paramCollection.Add(new DBParameter("@State", supplier.State));
            paramCollection.Add(new DBParameter("@Country", supplier.Country));
            paramCollection.Add(new DBParameter("@PostalCode", supplier.PostalCode));
            paramCollection.Add(new DBParameter("@ContactName", supplier.ContactName));
            paramCollection.Add(new DBParameter("@Phone", supplier.Phone));
            paramCollection.Add(new DBParameter("@Fax", supplier.Fax));
            paramCollection.Add(new DBParameter("@Email", supplier.Email));
            paramCollection.Add(new DBParameter("@IsActive", supplier.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@CurrencyId", supplier.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Supplier_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("supplier_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSupplier(int supplierId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@SupplierId", supplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Supplier_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("supplier_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//IMPORT

        public DataTable ImportSupplier(string xmlSupplier)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@xmlSupplier", xmlSupplier));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Supplier_Import", paramCollection, CommandType.StoredProcedure);
        }
    }
}