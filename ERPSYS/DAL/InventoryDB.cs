using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class InventoryDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

         public DataTable GetStoreItemList(string description, string itemCode, string partNumber, int locationId, bool isZero)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsZero", isZero, DbType.Boolean));

            return Dbhelper.ExecuteDataTable("INV_Item_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItemHistoryList(DateTime dateStart, DateTime dateEnd, string description, string itemCode, string partNumber, int locationId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("INV_Item_History_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItemTransactionList(DateTime dateStart, DateTime dateEnd, string description, string itemCode, string partNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));

            return Dbhelper.ExecuteDataTable("INV_Item_Transaction_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItemListCost(string description, string itemCode, string partNumber, int locationId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("INV_Item_Cost_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreHistory(DateTime logDate, string description, string itemCode, string partNumber, int locationId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@LogDate", logDate, DbType.DateTime));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("INV_Inventory_History_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItem(string description, string itemCode, string partNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));

            return Dbhelper.ExecuteDataTable("INV_Inventory_Item_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItemTransaction(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("INV_Inventory_Item_Transaction_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceivedStoreItems(string description, string itemCode, string partNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));

            return Dbhelper.ExecuteDataTable("INV_Goods_Received_Store_Item_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceivedStoreItemDetails(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId));

            return Dbhelper.ExecuteDataTable("INV_Goods_Received_Store_Item_Details_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsConsignedStoreItems(string description, string itemCode, string partNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));

            return Dbhelper.ExecuteDataTable("INV_Goods_Consigned_Store_Item_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsConsignedStoreItemDetails(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId));

            return Dbhelper.ExecuteDataTable("INV_Goods_Consigned_Store_Item_Details_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockTransferList(string transferNumber, string jobOrderNumber, int transferStatusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferNumber", transferNumber));
            paramCollection.Add(new DBParameter("@JobOrderNumber", jobOrderNumber));
            paramCollection.Add(new DBParameter("@TransferStatusId", transferStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("INV_StockTransfer_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockTransferHeader(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId));

            return Dbhelper.ExecuteDataTable("INV_StockTransfer_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockTransferLines(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId));

            return Dbhelper.ExecuteDataTable("INV_StockTransfer_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockTransferLinesStatus(int transferId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TransferId", transferId));

            return Dbhelper.ExecuteDataTable("INV_StockTransfer_Lines_Status_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsProductionStoreItems(string description, string itemCode, string partNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));

            return Dbhelper.ExecuteDataTable("INV_Goods_Production_Store_Item_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsProductionStoreItemDetails(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId));

            return Dbhelper.ExecuteDataTable("INV_Goods_Production_Store_Item_Details_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateStockTransfer(StockTransfer transfer, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferDescription", transfer.TransferDescription));
            paramCollection.Add(new DBParameter("@TransferDate", transfer.TransferDate, DbType.DateTime));
            paramCollection.Add(new DBParameter("@JobOrderNumber", transfer.JobOrderNumber));
            paramCollection.Add(new DBParameter("@FromLocationId", transfer.FromLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ToLocationId", transfer.ToLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", transfer.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateStockTransfer(StockTransfer transfer, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferId", transfer.TransferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@TransferDescription", transfer.TransferDescription));
            paramCollection.Add(new DBParameter("@TransferDate", transfer.TransferDate, DbType.Date));
            paramCollection.Add(new DBParameter("@JobOrderNumber", transfer.JobOrderNumber));
            paramCollection.Add(new DBParameter("@FromLocationId", transfer.FromLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ToLocationId", transfer.ToLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", transfer.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("inv_transfer_status_invalid");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostStockTransfer(int transferId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("inv_transfer_status_invalid");
                    rMsgId = 3;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("inv_transfer_insufficient_quantity");
                    rMsgId = 4;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("inv_transfer_empty");
                    rMsgId = 5;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteTransfer(int transferId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@TransferId", transferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("inv_transfer_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddStockTransferLine(StockTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.TransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_Line_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("inv_transfer_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("inv_transfer_item_exist");
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

        public void UpdateStockTransferLine(StockTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.TransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_Line_Update", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("inv_transfer_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("inv_transfer_item_exist");
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

        public void DeleteStockTransferLine(StockTransferLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TransferId", line.TransferId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("INV_StockTransfer_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("inv_transfer_status_invalid");
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