using ERPSYS.DAL;
using System.Data;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class CRMBLL
    {
        private readonly CRMDB _crm = new CRMDB();

        //******************************************************************************************//SELECT
        public DataTable GetClientItemSearchBox(string search)
        {
            return _crm.GetClientItemSearchBox(search);
        }

        public DataTable GetContactItemSearchBox(string search, int clientId)
        {
            return _crm.GetContactItemSearchBox(search, clientId);
        }
    
        public DataTable GetClientList(string clientName)
        {
            return _crm.GetClientList(clientName);
        }

        public DataTable GetContactList(int clientId, string name)
        {
            return _crm.GetContactList(clientId, name);
        }

        public Client GetClient(int clientId)
        {
            DataTable dt = _crm.GetClient(clientId);

            Client client = new Client();

            if (dt.Rows.Count == 0)
            {
                client.ClientId = -1;
                return client;
            }

            DataRow dr = dt.Rows[0];

            client.ClientId = clientId;
            client.Name = dr["Name"].ToString();
            client.Remarks = dr["Remarks"].ToString();
            client.Address = dr["Address"].ToString();
            client.City = dr["City"].ToString();
            client.Country = dr["Country"].ToString();
            client.PostalCode = dr["PostalCode"].ToString();
            client.Mobile = dr["Mobile"].ToString();
            client.Phone = dr["Phone"].ToString();
            client.Fax = dr["Fax"].ToString();
            client.Email = dr["Email"].ToString();
            client.WebSite = dr["WebSite"].ToString();
            client.IsActive = (bool)dr["IsActive"];

            return client;
        }

        public Contact GetContact(int contactId)
        {
            DataTable dt = _crm.GetContact(contactId);

            Contact contact = new Contact();

            if (dt.Rows.Count == 0)
            {
                contact.ContactId = -1;
                return contact;
            }

            DataRow dr = dt.Rows[0];

            contact.ContactId = contactId;
            contact.ClientId = dr["ClientId"].ToInt();
            contact.ContactTypeId = dr["ContactTypeId"].ToInt();
            contact.Name = dr["Name"].ToString();
            contact.NameTitle = dr["NameTitle"].ToString();
            contact.JobTitle = dr["JobTitle"].ToString();
            contact.Remarks = dr["Remarks"].ToString();
            contact.Address = dr["Address"].ToString();
            contact.City = dr["City"].ToString();
            contact.Country = dr["Country"].ToString();
            contact.PostalCode = dr["PostalCode"].ToString();
            contact.Mobile = dr["Mobile"].ToString();
            contact.Phone = dr["Phone"].ToString();
            contact.Fax = dr["Fax"].ToString();
            contact.Email1 = dr["Email1"].ToString();
            contact.Email2 = dr["Email2"].ToString();
            contact.IsActive = (bool)dr["IsActive"];

            return contact;
        }

        //******************************************************************************************//INSERT

        public int AddClient(Client client, out string rMsg)
        {
            return _crm.AddClient(client, out rMsg);
        }

        public int AddContact(Contact client, out string rMsg)
        {
            return _crm.AddContact(client, out rMsg);
        }

        //*********************************************************************************************//UPDATE

        public void UpdateClient(Client client, out string rMsg)
        {
            _crm.UpdateClient(client, out rMsg);
        }

        public void UpdateContact(Contact contact, out string rMsg)
        {
            _crm.UpdateContact(contact, out rMsg);
        }

        //*********************************************************************************************//DELETE
        public void DeleteClient(int clientId, out string rMessage, out int rMessageId)
        {
            _crm.DeleteClient(clientId, out rMessage, out rMessageId);
        }

        public void DeleteContact(int clientId, out string rMessage)
        {
            _crm.DeleteContact(clientId, out rMessage);
        }
    }
}