using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;
using System;

namespace ERPSYS.DAL
{
    public class ProjDB : CommonDB
    {

        //***************************************************************************************************//SELECT

        public DataTable GetProjectList(DateTime dateStart, DateTime dateEnd, string projectName, int projectStatusId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@ProjectName", projectName));
            paramCollection.Add(new DBParameter("@ProjectStatusId", projectStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PROJ_Project_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetProject(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PROJ_ProjectDetails_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProjectItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("PROJ_ProjectItem_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        //***************************************************************************************************//INSERT

        public int CreateProject(Proj proj, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@StartDate", proj.StartDate));
            //paramCollection.Add(new DBParameter("@EndDate", proj.EndDate));
            paramCollection.Add(new DBParameter("@CustomerId", proj.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerName", proj.CustomerName));
            paramCollection.Add(new DBParameter("@ProjectName", proj.ProjectName));
            paramCollection.Add(new DBParameter("@Remarks", proj.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PROJ_Project_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("proj_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //***************************************************************************************************//UPDATE
        public int UpdateProjectHeader(Proj proj, out string rMsg)
          {
              rMsg = string.Empty;
              var paramCollection = new DBParameterCollection();

              paramCollection.Add(new DBParameter("@ProjectId", proj.ProjectId));
              paramCollection.Add(new DBParameter("@StartDate", proj.StartDate));
              //paramCollection.Add(new DBParameter("@EndDate", proj.EndDate));
              paramCollection.Add(new DBParameter("@CustomerId", proj.CustomerId, DbType.Int32));
              paramCollection.Add(new DBParameter("@CustomerName", proj.CustomerName));
              paramCollection.Add(new DBParameter("@ProjectName", proj.ProjectName));
              paramCollection.Add(new DBParameter("@Remarks", proj.Remarks));
              paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
              paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
              paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

              IDbCommand command = Dbhelper.GetCommand("PROJ_Project_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
              int i = command.ExecuteNonQuery();
              int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
              command.Dispose();

              switch (errorId)
              {
                  case 1:
                      rMsg = GeneralResources.GetStringFromResources("proj_inactive");
                      break;
                  case -1:
                      rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                      break;
              }

              return i;
        }

        //***************************************************************************************************//DELETE



        //***************************************************************************************************//PARCHASELINES  
        public DataTable GetPurchaseInvoiceList(string invoiceNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceNumber", invoiceNumber));

            return Dbhelper.ExecuteDataTable("PROJ_Project_PurchaseInvoice_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetProjectPurchaseList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("PROJ_ProjectPurchase_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int AddPurchaseLine(ProjPurchase line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectPurchase_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("proj_expense_add_duplicate");
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

        public void UpdatePurchaseLine(ProjPurchase line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@PurchaseId", line.PurchaseId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectPurchase_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void DeletePurchaseLine(ProjPurchase line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@PurchaseId", line.PurchaseId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectPurchase_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public int CreatePurchaseFromPurchaseInvoice(int projectId, int purchaseInvoiceId, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@XMLLines", xmlLines));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectPurchase_PurchaseInvoice_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    //rMsg = GeneralResources.GetStringFromResources("scm_pi_grn_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //***************************************************************************************************//PARCHASELINES  

        public DataTable GetSalesInvoiceList(string invoiceNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceNumber", invoiceNumber));

            return Dbhelper.ExecuteDataTable("PROJ_Project_SalesInvoice_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetProjectSalesList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("PROJ_ProjectSales_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int AddSalesLine(ProjSales line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSales_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("proj_expense_add_duplicate");
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

        public void UpdateSalesLine(ProjSales line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@SalesId", line.SalesId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSales_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void DeleteSalesLine(ProjSales line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@SalesId", line.SalesId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSales_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public int CreateSalesFromSalesInvoice(int projectId, int SalesInvoiceId, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SalesInvoiceId", SalesInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@XMLLines", xmlLines));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSales_SalesInvoice_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    //rMsg = GeneralResources.GetStringFromResources("scm_pi_grn_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //***************************************************************************************************//SALESLINES
        internal DataTable GetProjectSaleList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("PROJ_ProjectSale_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int AddSaleLine(ProjSaleLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Amount", line.Amount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSale_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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


        public void UpdateSaleLine(ProjSaleLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@SaleId", line.SaleId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Amount", line.Amount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSale_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void DeleteSaleLine(ProjSaleLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@SaleId", line.SaleId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectSale_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        //***************************************************************************************************//EXPENSESLINES

        internal DataTable GetProjectExpensesList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("PROJ_ProjectExpense_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int AddExpenseLine(ProjExpense line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Amount", line.Amount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectExpense_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void UpdateExpenseLine(ProjExpense line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ExpenseId", line.ExpenseId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Amount", line.Amount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectExpense_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void DeleteExpenseLine(ProjExpense line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ExpenseId", line.ExpenseId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectExpense_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        //***************************************************************************************************//VISITLINES
        internal DataTable GetProjectVisitList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("PROJ_ProjectVisit_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int AddVisitLine(ProjVisitLine line, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Date", line.Date));
            paramCollection.Add(new DBParameter("@EmployeeName", line.EmployeeName));
            paramCollection.Add(new DBParameter("@Remarks", line.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectVisitLine_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("proj_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public void UpdateVisitLine(ProjVisitLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@VisitId", line.VisitId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Date", line.Date));
                paramCollection.Add(new DBParameter("@EmployeeName", line.EmployeeName));
                paramCollection.Add(new DBParameter("@Remarks", line.Remarks));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectVisit_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

        public void DeleteVisitLine(ProjVisitLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ProjectId", line.ProjectId, DbType.Int32));
                paramCollection.Add(new DBParameter("@VisitId", line.VisitId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PROJ_ProjectVisit_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("proj_inactive");
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

    }
}