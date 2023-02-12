using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class AssemblyOrderDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetAssemblyOrderList(DateTime dateStart, DateTime dateEnd, string orderNumber, string assemblyItem, int orderStatusId)
        {
            var paramCollection = new DBParameterCollection();  
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@AssemblyItem", assemblyItem));
            paramCollection.Add(new DBParameter("@OrderStatusId", orderStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PRD_AssemblyOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderHeader(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PRD_AssemblyOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderBomLines(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PRD_AssemblyOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderBomLinesStatus(int orderId) 
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("PRD_AssemblyOrder_Lines_Status_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateAssemblyOrder(AssemblyOrder order,  out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@JobOrderId", order.JobOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@JobOrderNumber", order.JobOrderNumber));
            paramCollection.Add(new DBParameter("@ItemLocationId", order.ItemLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemBOMLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@ItemId", order.ItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Quantity", order.Quantity, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_ADD", paramCollection, CommandType.StoredProcedure);
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

        public int UpdateAssemblyOrderHeader(AssemblyOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", order.AssemblyOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemLocationId", order.ItemLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Quantity", order.Quantity, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_assembly_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostAssemblyOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_assembly_update_inactive");
                    rMsgId = 53;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("prod_assembly_order_no_records");
                    rMsgId = 54;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("prod_assembly_order_insufficient_quantity");
                    rMsgId = 55;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }
      
        //**************************************************************************************************************************//DELETE

        public void DeleteAssemblyOrder(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("prod_assembly_order_delete_failed");
                    rMsgId = 3;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddBomLine(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_BOM_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_item_bom_exists");
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

        public void UpdateBomLine(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_BOM_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_item_bom_not_exists");
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

        public void DeleteBomLine(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("PRD_AssemblyOrder_BOM_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_item_bom_not_exists");
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

        //**************************************************************************************************************************//SELECT
        public DataTable GetAssemblyOrderListX(DateTime dateStart, DateTime dateEnd, string orderNumber, int orderStatusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@OrderStatusId", orderStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_AssemblyOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }
        public DataTable GetAssemblyOrderLineX(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_AssemblyOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderHeaderX(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_AssemblyOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderBomLinesQuantityCheckX(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_AssemblyOrder_BOM_Lines_QuantityCheck_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderBomLinesX(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("MAN_AssemblyOrder_BOM_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateAssemblyOrderX(AssemblyOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@JobOrderId", order.JobOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", order.ItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Quantity", order.Quantity, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemLocationId", order.ItemLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_ADD", paramCollection, CommandType.StoredProcedure);
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

        public void AddAssemblyOrderProductMaterialsX(int orderId, int itemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_Product_Materials_ADD", paramCollection, CommandType.StoredProcedure); // SL Single line
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_bom_not_empty");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateAssemblyOrderHeaderX(AssemblyOrder order, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", order.AssemblyOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemLocationId", order.ItemLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomLocationId", order.BomLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", order.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_header_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostAssemblyOrderX(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_no_records");
                    rMsgId = 54;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_insufficient_quantity");
                    rMsgId = 55;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteAssemblyOrderX(int orderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AssemblyOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_delete_failed");
                    rMsgId = 52;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteAssemblyOrderProductMaterialsX(int orderId, int itemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_Product_Materials_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("man_assembly_order_inactive");
                    break;

                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public void UpdateOrderLineX(AssemblyOrder line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("prod_assembly_update_inactive");
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

        public int AddBomLineX(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_BOM_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_item_bom_exists");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_main_item_exists");
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

        public void UpdateBomLineX(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_BOM_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_item_bom_not_exists");
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

        public void DeleteBomLineX(AssemblyBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssemblyOrderId", line.AssemblyOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("MAN_AssemblyOrder_BOM_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("man_assembly_order_item_bom_not_exists");
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