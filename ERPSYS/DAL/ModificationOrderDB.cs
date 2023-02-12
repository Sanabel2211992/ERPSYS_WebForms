using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class ModificationOrderDB : CommonDB
    {

        //**************************************************************************************************************************//SELECT

        public DataTable GetModificationOrderList(DateTime dateStart, DateTime dateEnd, string joborderNumber, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@JobOrderNumber", joborderNumber));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationOrderHeader(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetInputModificationOrderLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_InputItem_Line_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetOutputModificationOrderLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_OutputItem_Line_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationOrderBomLinesQuantityCheck(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_BOM_Lines_QuantityCheck_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationOrderBomLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_ModificationOrder_BOM_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateModificationOrder(ModificationOrder order, ModificationOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@JobOrderId", order.JobOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderTypeId", order.OrderTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InputLocationId", order.InputLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OutputLocationId", order.OutputLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@InputItemId", line.InputItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InputQuantity", line.InputQuantity, DbType.Decimal));
            paramCollection.Add(new DBParameter("@OutputItemId", line.OutputItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OutputQuantity", line.OutputQuantity, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_ADD", paramCollection, CommandType.StoredProcedure);
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

        //**************************************************************************************************************************//UPDATE

        public int UpdateModificationOrderHeader(ModificationOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ModificationOrderId", order.ModificationOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InputLocationId", order.InputLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OutputLocationId", order.OutputLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_header_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostModificationOrder(ModificationOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.ModificationOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EstimatedDays", order.EstimatedDays, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_rm_no_records");
                    break;
                case 11:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_insufficient_quantity");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        internal void CancelModificationOrder(int orderId, out string rMessage, out int rMessageId)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMessageId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("man_modif_order_cancel_failed");
                    rMessageId = 41;
                    break;
                case 2:
                    rMessage = GeneralResources.GetStringFromResources("man_modif_order_rm_request_cancel_failed");
                    rMessageId = 42;
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void CloseFullyModificationOrder(ModificationOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", order.ModificationOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CloseDate", order.EndDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", order.CloseRemarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_Fully_CLOSE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_close_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_close_partially_bofore");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_close_rm_pending");
                    break;
                case 12:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_close_rm_qty_error");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //****************************************************************************************************************************//DELETE

        public void DeleteModificationOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ModificationOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_modif_order_delete_failed");
                    rMsgId = 52;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public void UpdateInputOrderLine(ModificationOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ModificationOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.InputItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.InputQuantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_InputItem_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_line_update_inactive");
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

        public void UpdateOutputOrderLine(ModificationOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ModificationOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.OutputItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.OutputQuantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_OutputItem_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_line_update_inactive");
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

        public int AddRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ModificationOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ModificationItemId", line.ModificationItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_RM_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_item_bom_exists");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_main_item_exists");
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

        public void UpdateRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ModificationOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_RM_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_inactive");
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

        public void DeleteRawMaterialLine(ModificationOrderBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@OrderId", line.ModificationOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OrderLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_ModificationOrder_RM_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_modif_order_inactive");
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