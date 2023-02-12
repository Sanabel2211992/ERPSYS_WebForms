using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class CRMDB : CommonDB
    {
        //**************************************************************************************************************************//

        public DataTable GetClientItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("CRM_ClientSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetContactItemSearchBox(string search, int clientId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));
            paramCollection.Add(new DBParameter("@ClientId", clientId, DbType.Int16));

            return Dbhelper.ExecuteDataTable("CRM_ContactSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        //******************************************************************************************//SELECT

        public DataTable GetClientList(string clientName)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Name", clientName));

            return Dbhelper.ExecuteDataTable("CRM_Client_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetContactList(int clientId, string name)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ClientId", clientId));
            paramCollection.Add(new DBParameter("@Name", name));

            return Dbhelper.ExecuteDataTable("CRM_Contact_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetClient(int clientId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ClientId", clientId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("CRM_Client_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetContact(int contactId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ContactId", contactId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("CRM_Contact_GET", paramCollection, CommandType.StoredProcedure);
        }

        //******************************************************************************************//INSERT

        public int AddClient(Client client, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Name", client.Name));
                paramCollection.Add(new DBParameter("@Remarks", client.Remarks));
                paramCollection.Add(new DBParameter("@Address", client.Address));
                paramCollection.Add(new DBParameter("@City", client.City));
                paramCollection.Add(new DBParameter("@Country", client.Country));
                paramCollection.Add(new DBParameter("@PostalCode", client.PostalCode));
                paramCollection.Add(new DBParameter("@Phone", client.Phone));
                paramCollection.Add(new DBParameter("@Mobile", client.Mobile));
                paramCollection.Add(new DBParameter("@Fax", client.Fax));
                paramCollection.Add(new DBParameter("@Email", client.Email));
                paramCollection.Add(new DBParameter("@WebSite", client.WebSite));
                paramCollection.Add(new DBParameter("@IsActive", client.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("CRM_Client_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("client_add_duplicate");
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

        public int AddContact(Contact contact, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ClientId", contact.ClientId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Name", contact.Name));
                paramCollection.Add(new DBParameter("@NameTitle", contact.NameTitle));
                paramCollection.Add(new DBParameter("@JobTitle", contact.JobTitle));
                paramCollection.Add(new DBParameter("@ContactTypeId", contact.ContactTypeId, DbType.Int32));
                paramCollection.Add(new DBParameter("@City", contact.City));
                paramCollection.Add(new DBParameter("@Country", contact.Country));
                paramCollection.Add(new DBParameter("@Address", contact.Address));
                paramCollection.Add(new DBParameter("@PostalCode", contact.PostalCode));
                paramCollection.Add(new DBParameter("@Phone", contact.Phone));
                paramCollection.Add(new DBParameter("@Mobile", contact.Mobile));
                paramCollection.Add(new DBParameter("@Fax", contact.Fax));
                paramCollection.Add(new DBParameter("@Email1", contact.Email1));
                paramCollection.Add(new DBParameter("@Email2", contact.Email2));
                paramCollection.Add(new DBParameter("@Remarks", contact.Remarks));
                paramCollection.Add(new DBParameter("@IsActive", contact.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("CRM_Contact_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("contact_add_duplicate");
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

        //*************************************************************************************************//UPDATE

        public void UpdateClient(Client client, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ClientId", client.ClientId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Name", client.Name));
                paramCollection.Add(new DBParameter("@Remarks", client.Remarks));
                paramCollection.Add(new DBParameter("@Address", client.Address));
                paramCollection.Add(new DBParameter("@City", client.City));
                paramCollection.Add(new DBParameter("@Country", client.Country));
                paramCollection.Add(new DBParameter("@PostalCode", client.PostalCode));
                paramCollection.Add(new DBParameter("@Phone", client.Phone));
                paramCollection.Add(new DBParameter("@Mobile", client.Mobile));
                paramCollection.Add(new DBParameter("@Fax", client.Fax));
                paramCollection.Add(new DBParameter("@Email", client.Email));
                paramCollection.Add(new DBParameter("@WebSite", client.WebSite));
                paramCollection.Add(new DBParameter("@IsActive", client.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("CRM_Client_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("client_update_duplicat");
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

        public void UpdateContact(Contact contact, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@ContactId", contact.ContactId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ClientId", contact.ClientId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Name", contact.Name));
                paramCollection.Add(new DBParameter("@NameTitle", contact.NameTitle));
                paramCollection.Add(new DBParameter("@JobTitle", contact.JobTitle));
                paramCollection.Add(new DBParameter("@ContactTypeId", contact.ContactTypeId, DbType.Int32));
                paramCollection.Add(new DBParameter("@City", contact.City));
                paramCollection.Add(new DBParameter("@Country", contact.Country));
                paramCollection.Add(new DBParameter("@Address", contact.Address));
                paramCollection.Add(new DBParameter("@PostalCode", contact.PostalCode));
                paramCollection.Add(new DBParameter("@Phone", contact.Phone));
                paramCollection.Add(new DBParameter("@Mobile", contact.Mobile));
                paramCollection.Add(new DBParameter("@Fax", contact.Fax));
                paramCollection.Add(new DBParameter("@Email1", contact.Email1));
                paramCollection.Add(new DBParameter("@Email2", contact.Email2));
                paramCollection.Add(new DBParameter("@Remarks", contact.Remarks));
                paramCollection.Add(new DBParameter("@IsActive", contact.IsActive, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("CRM_Contact_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("contact_update_duplicat");
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

        //*********************************************************************************************//DELETE

        public void DeleteClient(int clientId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ClientId", clientId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("CRM_Client_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("client_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteContact(int contactId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ContactId", contactId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("CRM_Contact_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("contact_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}