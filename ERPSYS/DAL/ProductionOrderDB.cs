using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class ProductionOrderDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetProductionOrderList(DateTime dateStart, DateTime dateEnd, string joborderNumber, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@JobOrderNumber", joborderNumber));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderHeader(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderBomLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_BOM_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderBomLinesQuantityCheck(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_BOM_Lines_QuantityCheck_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderMaterialTransferList(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_MaterialTransfer_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderMaterialTransferLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ProductionOrder_MaterialTransfer_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateProductionOrder(ProductionOrder order, ProductionOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@JobOrderId", order.JobOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_SL_ADD", paramCollection, CommandType.StoredProcedure); // SL Single line
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

        public void AddProductRawMaterials(int orderId, int itemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_ADD", paramCollection, CommandType.StoredProcedure); // SL Single line
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_bom_not_empty");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public int CreateRawMaterialTransfer(MaterialTransfer request, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", request.OrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderTypeId", request.OrderTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@TransferTypeId", request.TransferTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", request.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_Transfer_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public void PostProductionOrder(ProductionOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.ProductionOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EstimatedDays", order.EstimatedDays, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_rm_no_records");                   
                    break;
                case 11:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_rm_insufficient_quantity");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void CancelProductionOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_cancel_failed");
                    rMsgId = 41;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_rm_request_cancel_failed");
                    rMsgId = 42;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void CloseFullyProductionOrder(ProductionOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.ProductionOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CloseDate", order.EndDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.CloseRemarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_Fully_CLOSE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_close_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_close_partially_bofore");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_close_rm_pending");
                    break;
                //case 11:
                //    rMsg = GeneralResources.GetStringFromResources("prod_order_close_order_qty_error");
                //    break;
                case 12:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_close_rm_qty_error");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //****************************************************************************************************************************//DELETE

        public void DeleteProductionOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
                    rMsgId = 5;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteProductRawMaterials(int orderId, int itemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
                    break;

                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public void UpdateOrderLine(ProductionOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ProductionOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_Line_Update", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_item_update_failed_inactive");
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

        public int AddRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ProductionOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ProductionItemId", line.ProductionItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));      
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_main_item_exists");
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

        public void UpdateRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ProductionOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
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

        public void DeleteRawMaterialLine(ProductionOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ProductionOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ProductionOrder_RM_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_order_inactive");
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