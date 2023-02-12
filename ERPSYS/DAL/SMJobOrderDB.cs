using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class JobOrderDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetJobOrderList(DateTime dateStart, DateTime dateEnd, string customerName, string orderNumber, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderHeader(int jobOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderLines(int jobOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderMainLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderSubLine(int orderId, int orderLineId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderLineId", orderLineId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderCompactLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_Compact_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetTransactionsList(int jobOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_Transactions_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetManufactureItemsList(int jobOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_ManufactureItems_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetManufactureItem(int jobOrderId, int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@itemId", itemId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_JobOrder_ManufactureItem_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateJobOrder(JobOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CustomerId", order.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderDate", order.OrderDate, DbType.Date));
            paramCollection.Add(new DBParameter("@ProjectName", order.ProjectName));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        public int CreateJobOrderFromSalesOrder(int salesOrderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@SalesOrderId", salesOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@AutoCreate", false, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_SalesOrder_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_add_joborder_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    rMsgId = 4;
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateJobOrderHeader(JobOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.OrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", order.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProjectName", order.ProjectName));
            paramCollection.Add(new DBParameter("@OrderDate", order.OrderDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("job_order_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostJobOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("job_order_post_inactive");
                    rMsgId = 11;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("job_order_no_records");
                    rMsgId = 12;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("job_order_group_empty");
                    rMsgId = 13;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int CancelJobOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("job_order_cancel_failed");
                    rMsgId = 15;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("job_order_trans_cancel_failed");
                    rMsgId = 16;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("job_order_trans_cancel_failed");
                    rMsgId = 16;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int CloseJobOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_CLOSE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("job_order_close_failed");
                    rMsgId = 17;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("job_order_trans_close_failed");
                    rMsgId = 18;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("job_order_trans_close_failed");
                    rMsgId = 18;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteJobOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_DELETE", paramCollection,
                CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("job_order_delete_failed");
                    rMsgId = 33;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_MainLine_ADD", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("job_order_master_item_exist");
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

        public void UpdateMainLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_MainLine_UPDATE", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("job_order_master_item_exist");
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

        public void DeleteMainLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_MainLine_DELETE", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_delete_failed_inactive");
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

        public int AddSubLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_SubLine_ADD", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("job_order_sub_item_exist");
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

        public void UpdateSubLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_SubLine_UPDATE", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("job_order_sub_item_exist");
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

        public void DeleteSubLine(JobOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_JobOrder_SubLine_DELETE", paramCollection,
                    CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("job_order_item_delete_failed_inactive");
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