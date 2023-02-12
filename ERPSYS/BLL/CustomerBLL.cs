using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDB _customer = new CustomerDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetCustomerList(string customerName, string contactName, string country, string city)
        {
            return _customer.GetCustomerList(customerName, contactName, country, city);
        }
        public DataTable GetCustomerListDialog(string customerName)
        {
            return _customer.GetCustomerListDialog(customerName);
        }

        public Customer GetCustomer(int customerId)
        {
            DataTable dt = _customer.GetCustomer(customerId);

            Customer customer = new Customer();

            if (dt.Rows.Count == 0)
            {
                customer.CustomerId = -1;
                return customer;
            }

            DataRow dr = dt.Rows[0];

            customer.CustomerId = customerId;
            customer.Name = dr["Name"].ToString();
            customer.NameAr = dr["NameAr"].ToString();
            customer.Remarks = dr["Remarks"].ToString();
            customer.DefaultPaymentMethodId = dr["DefaultPaymentMethodId"].ToInt();
            customer.DefaultPaymentMethod = dr["DefaultPaymentMethod"].ToString();
            customer.DefaultPaymentTermsId = dr["DefaultPaymentTermsId"].ToInt();
            customer.DefaultPaymentTerms = dr["DefaultPaymentTerms"].ToString();
            customer.Address1 = dr["Address1"].ToString();
            customer.Address2 = dr["Address2"].ToString();
            customer.City = dr["City"].ToString();
            customer.State = dr["State"].ToString();
            customer.Country = dr["Country"].ToString();
            customer.PostalCode = dr["PostalCode"].ToString();
            customer.ContactName = dr["ContactName"].ToString();
            customer.Phone = dr["Phone"].ToString();
            customer.Fax = dr["Fax"].ToString();
            customer.Email = dr["Email"].ToString();
            customer.IsActive = (bool)dr["IsActive"];

            return customer;
        }

        public DataTable GetCustomerSearchBox(string name)
        {
            return _customer.GetCustomerSearchBox(name);
        }

        public DataTable GetCustomerAdvancedSearchBox(string customerName)
        {
            return _customer.GetCustomerAdvancedSearchBox(customerName);
        }

        //**************************************************************************************************************************//INSERT

        public int AddCustomer(Customer customer, out string rMsg)
        {
            return _customer.AddCustomer(customer, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public void UpdateCustomer(Customer customer, out string rMsg)
        {
            _customer.UpdateCustomer(customer, out rMsg);
        }

        //**************************************************************************************************************************//IMPORT
      
        public DataTable ImportCustomer(string xmlCustomer)
        {
            return _customer.ImportCustomer(xmlCustomer);
        }
    }
}