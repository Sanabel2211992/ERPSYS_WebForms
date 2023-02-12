using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class SupplierChainDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetPurchaseOrderList(DateTime dateStart, DateTime dateEnd, string supplierName, string orderNumber, string remarks, int statusId, string itemSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierName", supplierName));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@Remarks", remarks));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemSearch", itemSearch));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseOrderHeader(int purchaseOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseOrderLines(int purchaseOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseOrderLinesToGoodsReceipt(int purchaseOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_GoodsReceipt_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetOpenPurchaseOrderList()
        {
            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_Open_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptNoteList(DateTime dateStart, DateTime dateEnd, string supplierName, string receiptNumber, string orderNumber, string remarks, int statusId, int locationId, string itemSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierName", supplierName));
            paramCollection.Add(new DBParameter("@ReceiptNumber", receiptNumber));
            paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
            paramCollection.Add(new DBParameter("@Remarks", remarks));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemSearch", itemSearch));

            return Dbhelper.ExecuteDataTable("SCM_GoodsReceipt_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptNoteHeader(int goodsReceiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_GoodsReceipt_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptNoteLines(int goodsReceiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_GoodsReceipt_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptLinesToPurchaseInvoice(int goodsReceiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@goodsReceiptId", goodsReceiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_GoodsReceipt_PurchaseInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptNoteOpen()
        {
            return Dbhelper.ExecuteDataTable("SCM_GoodsReceipt_Open_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceList(DateTime dateStart, DateTime dateEnd, string supplierName, string invoiceNumber, string receiptNumber, string supplierInvoiceNumber, string remarks, int statusId, string itemSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierName", supplierName));
            paramCollection.Add(new DBParameter("@InvoiceNumber", invoiceNumber));
            paramCollection.Add(new DBParameter("@ReceiptNumber", receiptNumber));
            paramCollection.Add(new DBParameter("@SupplierInvoiceNumber", supplierInvoiceNumber));
            paramCollection.Add(new DBParameter("@Remarks", remarks));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemSearch", itemSearch));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseInvoice_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceHeader(int purchaseInvoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseInvoice_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceLines(int purchaseInvoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseGoodsReceipts(int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SCM_PurchaseOrder_GoodsReceipt_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreatePurchaseOrder(PurchaseOrder purchaseOrder, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OrderDate", purchaseOrder.OrderDate));
            paramCollection.Add(new DBParameter("@SupplierId", purchaseOrder.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", purchaseOrder.SupplierName));
            paramCollection.Add(new DBParameter("@ContactName", purchaseOrder.ContactName));
            paramCollection.Add(new DBParameter("@Phone", purchaseOrder.Phone));
            paramCollection.Add(new DBParameter("@SupplierAddress", purchaseOrder.SupplierAddress));
            paramCollection.Add(new DBParameter("@ShipToCompany", purchaseOrder.ShipToCompany));
            paramCollection.Add(new DBParameter("@ShipToAddress", purchaseOrder.ShipToAddress));
            paramCollection.Add(new DBParameter("@PaymentTermsId", purchaseOrder.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", purchaseOrder.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Tax", purchaseOrder.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Remarks", purchaseOrder.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateGoodsReceiptNote(GoodsReceipt goodsReceipt, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptDate", goodsReceipt.ReceiptDate, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierId", goodsReceipt.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", goodsReceipt.SupplierName));
            paramCollection.Add(new DBParameter("@LocationId", goodsReceipt.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsConsignedGoods", goodsReceipt.IsConsignedGoods, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Remarks", goodsReceipt.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateGoodsReceiptNoteFromPurchaseOrder(GoodsReceipt goodsReceipt, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptDate", goodsReceipt.ReceiptDate, DbType.Date));
            paramCollection.Add(new DBParameter("@LocationId", goodsReceipt.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", goodsReceipt.Remarks));
            paramCollection.Add(new DBParameter("@PurchaseOrderId", goodsReceipt.PurchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@XMLLines", xmlLines));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_PurchaseOrder_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreatePurchaseInvoice(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceDate", purchaseInvoice.InvoiceDate));
            paramCollection.Add(new DBParameter("@SupplierId", purchaseInvoice.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", purchaseInvoice.SupplierName));
            paramCollection.Add(new DBParameter("@PurchaseOrderNumber", purchaseInvoice.PurchaseOrderNumber));
            paramCollection.Add(new DBParameter("@SupplierInvoiceNumber", purchaseInvoice.SupplierInvoiceNumber));
            paramCollection.Add(new DBParameter("@LocationId", purchaseInvoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", purchaseInvoice.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocalCurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", purchaseInvoice.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreatePurchaseInvoiceFromGoodsReceiptNote(PurchaseInvoice purchaseInvoice, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceDate", purchaseInvoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@GoodsReceiptId", purchaseInvoice.GoodsReceiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierInvoiceNumber", purchaseInvoice.SupplierInvoiceNumber));
            paramCollection.Add(new DBParameter("@LocationId", purchaseInvoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", purchaseInvoice.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocalCurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", purchaseInvoice.Remarks));
            paramCollection.Add(new DBParameter("@FreightExpenses", purchaseInvoice.FreightExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ClearanceExpenses", purchaseInvoice.ClearanceExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@OtherExpenses", purchaseInvoice.OtherExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@OtherExpensesLocalCurrency", purchaseInvoice.OtherExpensesLocalCurrency, DbType.Decimal));
            paramCollection.Add(new DBParameter("@XMLLines", xmlLines));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_GoodsReceipt_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_grn_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdatePurchaseOrderHeader(PurchaseOrder purchaseOrder, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrder.PurchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderDate", purchaseOrder.OrderDate));
            paramCollection.Add(new DBParameter("@SupplierId", purchaseOrder.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", purchaseOrder.SupplierName));
            paramCollection.Add(new DBParameter("@ContactName", purchaseOrder.ContactName));
            paramCollection.Add(new DBParameter("@Phone", purchaseOrder.Phone));
            paramCollection.Add(new DBParameter("@SupplierAddress", purchaseOrder.SupplierAddress));
            paramCollection.Add(new DBParameter("@ShipToCompany", purchaseOrder.ShipToCompany));
            paramCollection.Add(new DBParameter("@ShipToAddress", purchaseOrder.ShipToAddress));
            paramCollection.Add(new DBParameter("@PaymentTermsId", purchaseOrder.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", purchaseOrder.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", purchaseOrder.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_invalid_status");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdatePurchaseOrderSummary(int purchaseOrderId, decimal discount, decimal tax, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Tax", tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_update_summary_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostPurchaseOrder(int purchaseOrderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_invalid_status");
                    rMsgId = 3;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_no_records");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }//

        public int CancelPurchaseOrder(int purchaseOrderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_invalid_status");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdateGoodsReceiptNoteHeader(GoodsReceipt goodsReceipt, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceipt.GoodsReceiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ReceiptDate", goodsReceipt.ReceiptDate, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierId", goodsReceipt.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", goodsReceipt.SupplierName));
            paramCollection.Add(new DBParameter("@LocationId", goodsReceipt.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", goodsReceipt.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_invalid_status");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostGoodsReceiptNote(int goodsReceiptId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_invalid_status");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_po_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int CancelGoodsReceiptNote(int goodsReceiptId, bool updatePurchaseOrderStatus, string cancelRemarks, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UpdatePurchaseOrderStatus", updatePurchaseOrderStatus, DbType.Boolean));
            paramCollection.Add(new DBParameter("@CancelRemarks", cancelRemarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_cancel_failed");
                    rMsgId = 5;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_cancel_insufficient_quantity");
                    rMsgId = 6;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdatePurchaseInvoiceHeader(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoice.PurchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceDate", purchaseInvoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@SupplierId", purchaseInvoice.SupplierId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SupplierName", purchaseInvoice.SupplierName));
            paramCollection.Add(new DBParameter("@PurchaseOrderNumber", purchaseInvoice.PurchaseOrderNumber));
            paramCollection.Add(new DBParameter("@SupplierInvoiceNumber", purchaseInvoice.SupplierInvoiceNumber));
            paramCollection.Add(new DBParameter("@CurrencyId", purchaseInvoice.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocationId", purchaseInvoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", purchaseInvoice.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_update_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdatePurchaseInvoiceSummary(int purchaseInvoiceId, decimal discount, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("scm_pi_update_summary_failed");
            }
            else if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return i;
        }

        public int UpdatePurchaseInvoicePricing(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoice.PurchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@FreightExpenses", purchaseInvoice.FreightExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ClearanceExpenses", purchaseInvoice.ClearanceExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@OtherExpenses", purchaseInvoice.OtherExpenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@OtherExpensesLocalCurrency", purchaseInvoice.OtherExpensesLocalCurrency, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Pricing_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("scm_pi_update_pricing_failed");
            }
            else if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return i;
        }

        public int PostPurchaseInvoice(int purchaseInvoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            rMsgId = 0;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_post_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_grn_inactive");
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_grn_qty_invalid");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeletePurchaseOrder(int purchaseOrderId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_po_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteGoodsReceiptNote(int goodsReceiptId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@GoodsReceiptId", goodsReceiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_grn_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeletePurchaseInvoice(int purchaseInvoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PurchaseInvoiceId", purchaseInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("scm_pi_delete_failed");
                    rMsgId = 5;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddPurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseOrderId", line.PurchaseOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.PurchaseUomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_Line_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_item_exist");
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

        public void UpdatePurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseOrderId", line.PurchaseOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.PurchaseUomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_item_exist");
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

        public void DeletePurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseOrderId", line.PurchaseOrderId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseOrder_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
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

        public int AddGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GoodsReceiptId", line.GoodsReceiptId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.UomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Remarks", line.Remarks));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_Line_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_grn_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_grn_item_exist");
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

        public void UpdateGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GoodsReceiptId", line.GoodsReceiptId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.UomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Remarks", line.Remarks));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_grn_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_grn_item_exist");
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

        public void DeleteGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GoodsReceiptId", line.GoodsReceiptId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_GoodsReceipt_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_grn_status_invalid");
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

        public int AddPurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseInvoiceId", line.PurchaseInvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.Description));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.PurchaseUomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Line_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_item_exist");
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

        public void UpdatePurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseInvoiceId", line.PurchaseInvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UomId", line.PurchaseUomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_item_exist");
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

        public void DeletePurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseInvoiceId", line.PurchaseInvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SCM_PurchaseInvoice_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("scm_po_status_invalid");
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

        //**************************************************************************************************************************//REPORTS

        public DataTable GetReport1(DateTime dateStart, DateTime dateEnd)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateFrom", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateTo", dateEnd, DbType.Date));

            return Dbhelper.ExecuteDataTable("SCM_REPORT_Report1", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetReport2(DateTime dateStart, DateTime dateEnd)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateFrom", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateTo", dateEnd, DbType.Date));

            return Dbhelper.ExecuteDataSet("SCM_REPORT_Report2", paramCollection, CommandType.StoredProcedure);
        }
    }
}