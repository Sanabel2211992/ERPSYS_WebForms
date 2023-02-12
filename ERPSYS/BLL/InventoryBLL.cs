using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class InventoryBLL
    {
        private readonly InventoryDB _inv = new InventoryDB();

        //**************************************************************************************************************************//SELECT
        public DataTable GetStoreItemList(string description, string itemCode, string partNumber, int locationId, bool isZero)
        {
            return _inv.GetStoreItemList(description, itemCode, partNumber, locationId, isZero);
        }

        public DataTable GetStoreItemHistoryList(DateTime dateStart, DateTime dateEnd, string description, string itemCode, string partNumber, int locationId)
        {
            return _inv.GetStoreItemHistoryList(dateStart, dateEnd, description, itemCode, partNumber, locationId);
        }

        public DataTable GetStoreItemTransactionList(DateTime dateStart, DateTime dateEnd, string description, string itemCode, string partNumber)
        {
            return _inv.GetStoreItemTransactionList(dateStart, dateEnd, description, itemCode, partNumber);
        }

        public DataTable GetStoreItemListCost(string description, string itemCode, string partNumber, int locationId)
        {
            return _inv.GetStoreItemListCost(description, itemCode, partNumber, locationId);
        }

        public DataTable GetStoreHistory(DateTime logDate, string description, string itemCode, string partNumber, int locationId)
        {
            return _inv.GetStoreHistory(logDate ,description, itemCode, partNumber, locationId);
        }

        public DataTable GetStoreItem(string description, string itemCode, string partNumber)
        {
            return _inv.GetStoreItem(description,itemCode, partNumber );
        }

        public DataTable GetStoreItemTransaction(int itemId)
        {
            return _inv.GetStoreItemTransaction(itemId);
        }

        public DataTable GetGoodsReceivedStoreItems(string description, string itemCode, string partNumber)
        {
            return _inv.GetGoodsReceivedStoreItems(description, itemCode, partNumber);
        }

        public DataTable GetGoodsReceivedStoreItemDetails(int itemId)
        {
            return _inv.GetGoodsReceivedStoreItemDetails(itemId);
        }

        public DataTable GetGoodsConsignedStoreItems(string description, string itemCode, string partNumber)
        {
            return _inv.GetGoodsConsignedStoreItems(description, itemCode, partNumber);
        }

        public DataTable GetGoodsConsignedStoreItemDetails(int itemId)
        {
            return _inv.GetGoodsConsignedStoreItemDetails(itemId);
        }

        public DataTable GetStockTransferList(string transferNumber, string jobOrderNumber, int transferStatusId)
        {
            return _inv.GetStockTransferList(transferNumber, jobOrderNumber, transferStatusId);
        }

        public StockTransfer GetStockTransferHeader(int transferId)
        {
            DataTable dt = _inv.GetStockTransferHeader(transferId);

            StockTransfer transfer = new StockTransfer();

            if (dt.Rows.Count == 0)
            {
                transfer.TransferId = -1;
                return transfer;
            }

            DataRow dr = dt.Rows[0];

            transfer.TransferId = transferId;
            transfer.TransferNumber = dr["TransferNumber"].ToString();
            transfer.TransferDescription = dr["TransferDescription"].ToString();
            transfer.TransferDate = dr["TransferDate"].ToDate();
            transfer.JobOrderNumber = dr["JobOrderNumber"].ToString();
            transfer.FromLocationId = dr["FromLocationId"].ToInt();
            transfer.FromLocation = dr["FromLocation"].ToString();
            transfer.ToLocationId = dr["ToLocationId"].ToInt();
            transfer.ToLocation = dr["ToLocation"].ToString();
            transfer.StatusId = dr["TransferStatusId"].ToInt();
            transfer.Status = dr["TransferStatus"].ToString();
            transfer.UserId = dr["UserId"].ToInt();
            transfer.UserName = dr["UserName"].ToString();
            transfer.PostedUserId = dr["PostUserId"].ToInt();
            transfer.PostedUserName = dr["PostUserName"].ToString();
            transfer.PostedDate = dr["PostDate"].ToDate();
            transfer.Remarks = dr["Remarks"].ToString();

            return transfer;
        }

        public List<StockTransferLine> GetStockTransferLines(int transferId)
        {
            DataTable dtTransferLines = _inv.GetStockTransferLines(transferId);

            List<StockTransferLine> lines = new List<StockTransferLine>();

            foreach (DataRow drLine in dtTransferLines.Rows)
            {
                var line = new StockTransferLine();

                line.TransferId = drLine["TransferId"].ToInt();
                line.LineId = drLine["TransferLineId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UomId = drLine["UomId"].ToInt();
                line.Uom = drLine["Uom"].ToString();
                line.Remarks = drLine["Remarks"].ToString();

                lines.Add(line);
            }

            return lines;
        }

        public DataTable GetStockTransferLinesStatus(int transferId)
        {
            return _inv.GetStockTransferLinesStatus(transferId);
        }

        public DataTable GetGoodsProductionStoreItems(string description, string itemCode, string partNumber)
        {
            return _inv.GetGoodsProductionStoreItems(description, itemCode, partNumber);
        }

        public DataTable GetGoodsProductionStoreItemDetails(int itemId)
        {
            return _inv.GetGoodsProductionStoreItemDetails(itemId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateStockTransfer(StockTransfer transfer, out string rMsg)
        {
            return _inv.CreateStockTransfer(transfer, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateStockTransfer(StockTransfer transfer, out string rMsg)
        {
            return _inv.UpdateStockTransfer(transfer, out rMsg);
        }

        public int PostStockTransfer(int transferId, out string rMsg, out int rMessageId)
        {
            return _inv.PostStockTransfer(transferId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteTransfer(int transferId, out string rMsg, out int rMessageId)
        {
            _inv.DeleteTransfer(transferId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddStockTransferLine(StockTransferLine line, out string rMsg)
        {
            return _inv.AddStockTransferLine(line, out rMsg);
        }

        public void UpdateStockTransferLine(StockTransferLine line, out string rMsg)
        {
            _inv.UpdateStockTransferLine(line, out rMsg);
        }

        public void DeleteStockTransferLine(StockTransferLine line, out string rMsg)
        {
            _inv.DeleteStockTransferLine(line, out rMsg);
        }

    }
}