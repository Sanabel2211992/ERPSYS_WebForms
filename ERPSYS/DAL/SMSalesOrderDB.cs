using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class SalesOrderDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetSalesOrderList(DateTime dateStart, DateTime dateEnd, string customerName, string orderNumber, int orderStatusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@OrderStatusId", orderStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetOpenSalesOrderList()
        {
            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Open_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderHeader(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderMainLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderSubLine(int orderId, int orderLineId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderLineId", orderLineId, DbType.Int32)); 

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderDeliveredLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Lines_Delivered_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderLinesStatus(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Lines_Status_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderMasterLinesStatus(int orderId) // parent is null only
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Lines_Master_Status_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderLinesCombinedStatus(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_Lines_Combined_Status_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderDeliveryReceipts(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesOrder_DeliveryReceipt_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesOrder(SalesOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CustomerId", order.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", order.PurchaseOrder));
            paramCollection.Add(new DBParameter("@ProjectName", order.ProjectName));
            paramCollection.Add(new DBParameter("@OrderDate", order.OrderDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Tax", order.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_ADD", paramCollection, CommandType.StoredProcedure);
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

        public int CreateSalesOrderFromSalesQuotation(SalesOrder order, int quoteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", order.PurchaseOrder));
            paramCollection.Add(new DBParameter("@ProjectName", order.ProjectName));
            paramCollection.Add(new DBParameter("@OrderDate", order.OrderDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_SalesQuote_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_create_from_quote_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_create_from_quote_failed");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_create_from_quote_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CloneSalesOrder(int salesOrderId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", salesOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_CLONE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_clone_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesOrderHeader(SalesOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.OrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", order.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", order.PurchaseOrder));
            paramCollection.Add(new DBParameter("@ProjectName", order.ProjectName));
            paramCollection.Add(new DBParameter("@OrderDate", order.OrderDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdateSalesOrderSummary(int orderId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Expenses", expenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Tax", tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostSalesOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_group_empty");
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_add_joborder_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_delete_failed");
                    rMsgId = 5;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(SalesOrderLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_MainLine_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_master_item_exist");
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

        public void UpdateMainLine(SalesOrderLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_MainLine_Update", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_master_item_exist");
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

        public void DeleteMainLine(SalesOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_MainLine_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_delete_failed_inactive");
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

        public int AddSubLine(SalesOrderLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_SubLine_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_sub_item_exist");
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

        public void UpdateSubLine(SalesOrderLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_SubLine_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_sub_item_exist");
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

        public void DeleteSubLine(SalesOrderLine line, out string rMsg)
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

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_SubLine_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_delete_failed_inactive");
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

        public void MoveLineUp(SalesOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineSeqId", line.LineSeqId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_Lines_Move_UP", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_inactive");
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

        public void MoveLineDown(SalesOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineSeqId", line.LineSeqId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesOrder_Lines_Move_DOWN", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_inactive");
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

        public void ExcludeLineFromGroup(SalesOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.OrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("INV_SalesOrder_Lines_Exclude", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_exclude_failed");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_exclude_failed");
                        break;
                    case 4:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_exclude_failed");
                        break;
                    case 5:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_exclude_failed");
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