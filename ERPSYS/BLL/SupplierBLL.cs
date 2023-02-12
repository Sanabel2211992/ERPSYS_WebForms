using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SupplierBLL
    {
        private readonly SupplierDB _supplier = new SupplierDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetSupplierList(string supplierName, string contactName, string country, string city)
        {
            return _supplier.GetSupplierList(supplierName, contactName, country, city);
        }

        public Supplier GetSupplier(int supplierId)
        {
            DataTable dt = _supplier.GetSupplier(supplierId);

            Supplier supplier = new Supplier();

            if (dt.Rows.Count == 0)
            {
                supplier.SupplierId = -1;
                return supplier;
            }

            DataRow dr = dt.Rows[0];

            supplier.SupplierId = supplierId;
            supplier.Name = dr["Name"].ToString();
            supplier.NameAr = dr["NameAr"].ToString();
            supplier.Remarks = dr["Remarks"].ToString();
            supplier.DefaultPaymentTermsId = dr["DefaultPaymentTermsId"].ToInt();
            supplier.DefaultPaymentTerms = dr["DefaultPaymentTerms"].ToString();
            supplier.Address1 = dr["Address1"].ToString();
            supplier.Address2 = dr["Address2"].ToString();
            supplier.City = dr["City"].ToString();
            supplier.State = dr["State"].ToString();
            supplier.Country = dr["Country"].ToString();
            supplier.PostalCode = dr["PostalCode"].ToString();
            supplier.ContactName = dr["ContactName"].ToString();
            supplier.Phone = dr["Phone"].ToString();
            supplier.Fax = dr["Fax"].ToString();
            supplier.Email = dr["Email"].ToString();
            supplier.IsActive = dr["IsActive"].ToBool();
            supplier.CurrencyId = dr["CurrencyId"].ToInt();
            supplier.CurrencyCode = dr["CurrencyCode"].ToString();
            supplier.Currency = dr["Currency"].ToString();

            return supplier;
        }

        public DataTable GetSupplierSearchBox(string name)
        {
            return _supplier.GetSupplierSearchBox(name);
        }

        //**************************************************************************************************************************//INSERT

        public int AddSupplier(Supplier supplier, out string rMsg)
        {
            return _supplier.AddSupplier(supplier, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSupplier(Supplier supplier, out string rMsg)
        {
            return _supplier.UpdateSupplier(supplier, out rMsg);
        }

        //**************************************************************************************************************************//DELETE
       
        public void DeleteSupplier(int supplierId, out string rMessage, out int rMessageId)
        {
            _supplier.DeleteSupplier(supplierId, out rMessage, out rMessageId);
        }

        //**************************************************************************************************************************//IMPORT
       
        public DataTable ImportSupplier(string xmlSupplier)
        {
            return _supplier.ImportSupplier(xmlSupplier);
        }
    }
}