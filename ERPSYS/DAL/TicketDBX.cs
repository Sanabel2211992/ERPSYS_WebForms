using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;
using System;
using System.Data;

namespace ERPSYS.DAL
{
    public class TicketDBx : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetTicketList(DateTime dateStart, DateTime dateEnd, string ticketNumber, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@TicketNumber", ticketNumber));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("HD_Ticket_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetTicket(int ticketId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TicketId", ticketId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("HD_Ticket_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetTicketThread(int ticketId, int threadId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TicketId", ticketId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ThreadId", threadId, DbType.Int32));

            return Dbhelper.ExecuteDataSet("HD_Ticket_Thread_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetTicketThreads(int ticketId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TicketId", ticketId, DbType.Int32));

            return Dbhelper.ExecuteDataSet("HD_Ticket_Threads_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

         
        //**************************************************************************************************************************//UPDATE


        //**************************************************************************************************************************//DELETE


        //**************************************************************************************************************************//SETTING SELECT

        public DataTable GetTicketSettings()
        {
            var paramCollection = new DBParameterCollection();

            return Dbhelper.ExecuteDataTable("HD_Ticket_Settings_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetTicketCategoryList()
        {
            return Dbhelper.ExecuteDataTable("HD_TicketCategory_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCategoryDetails(int categoryId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("HD_TicketCategory_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetTicketDepartmentList()
        {
            return Dbhelper.ExecuteDataTable("HD_TicketDepartment_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDepartmentDetails(int departmentId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DepartmentId", departmentId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("HD_TicketDepartment_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//SETTING INSERT

        public int AddCategory(TicketCategory category, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Description", category.Description));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsActive", category.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("HD_TicketCategory_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("ticket_category_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;
        }

        public int AddDepartment(TicketDepartment department, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", department.Name));
            paramCollection.Add(new DBParameter("@Description", department.Description));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsActive", department.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("HD_TicketDepartment_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("ticket_department_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;
        }

        //**************************************************************************************************************************//SETTING UPDATE

        public int UpdateTicketSettings(TicketSettings settings, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Url", settings.URL));
            paramCollection.Add(new DBParameter("@Title", settings.SiteName));
            paramCollection.Add(new DBParameter("@EmailId", settings.EmailId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ToMail", settings.ToMail));
            paramCollection.Add(new DBParameter("@CcMail", settings.CcMail));
            paramCollection.Add(new DBParameter("@BccMail", settings.BccMail));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("HD_Ticket_Settings_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId != 0)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateCategory(TicketCategory category, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", category.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Description", category.Description));
            paramCollection.Add(new DBParameter("@IsActive", category.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("HD_TicketCategory_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("ticket_category_update_duplicate");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateDepartment(TicketDepartment department, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DepartmentId", department.DepartmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", department.Name));
            paramCollection.Add(new DBParameter("@Description", department.Description));
            paramCollection.Add(new DBParameter("@IsActive", department.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("HD_TicketDepartment_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("ticket_department_update_duplicate");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }


        //**************************************************************************************************************************//SETTING DELETE
    }
}