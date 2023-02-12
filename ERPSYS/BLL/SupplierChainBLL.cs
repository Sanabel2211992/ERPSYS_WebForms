using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SupplierChainBLL
    {
        private readonly SupplierChainDB _scm = new SupplierChainDB();

        //**************************************************************************************************************************//Settings

        public int DefaultPaymentTermsId
        {
            get { return 1; }
        }

        public int DefaultGoodsReceivedLocationId
        {
            get { return 4; } // predefined location
        }

        public int DefaultGoodsConsignedLocationId
        {
            get { return 5; } // predefined location
        }

        //**************************************************************************************************************************//SELECT

        public DataTable GetPurchaseOrderList(DateTime dateStart, DateTime dateEnd, string supplierName, string orderNumber, string remarks, int orderStatusId, string itemSearch)
        {
            return _scm.GetPurchaseOrderList(dateStart, dateEnd, supplierName, orderNumber, remarks, orderStatusId, itemSearch);
        }

        public PurchaseOrder GetPurchaseOrderHeader(int purchaseOrderId)
        {
            DataTable dt = _scm.GetPurchaseOrderHeader(purchaseOrderId);


            PurchaseOrder purchaseOrder = new PurchaseOrder();

            if (dt.Rows.Count == 0)
            {
                purchaseOrder.PurchaseOrderId = -1;
                return purchaseOrder;
            }

            DataRow dr = dt.Rows[0];

            purchaseOrder.PurchaseOrderId = dr["PurchaseOrderId"].ToInt();
            purchaseOrder.StatusId = dr["StatusId"].ToInt();
            purchaseOrder.Status = dr["OrderStatus"].ToString();
            purchaseOrder.OrderNumber = dr["OrderNumber"].ToString();
            purchaseOrder.OrderDate = dr["OrderDate"].ToDate();
            purchaseOrder.SupplierId = dr["SupplierId"].ToInt();
            purchaseOrder.SupplierName = dr["SupplierName"].ToString();
            purchaseOrder.ContactName = dr["ContactName"].ToString();
            purchaseOrder.Phone = dr["Phone"].ToString();
            purchaseOrder.SupplierAddress = dr["SupplierAddress"].ToString();
            purchaseOrder.ShipToCompany = dr["ShipToCompanyName"].ToString();
            purchaseOrder.ShipToAddress = dr["ShipToAddress"].ToString();
            purchaseOrder.PaymentTermsId = dr["PaymentTermsId"].ToInt();
            purchaseOrder.SubTotal = dr["SubTotal"].ToDecimal(3);
            purchaseOrder.Discount = dr["Discount"].ToDecimal(3);
            purchaseOrder.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            purchaseOrder.Tax = dr["Tax"].ToDecimal(3);
            purchaseOrder.GrandTotal = dr["Total"].ToDecimal(3);
            purchaseOrder.CurrencyId = dr["CurrencyId"].ToInt();
            purchaseOrder.CurrencyCode = dr["CurrencyCode"].ToString();
            purchaseOrder.ExchangeRate = dr["ExchangeRate"].ToDecimal(3);
            purchaseOrder.Remarks = dr["Remarks"].ToString();
            purchaseOrder.PreparedBy = dr["PreparedBy"].ToString();
            purchaseOrder.PostedBy = dr["PostedBy"].ToString();
            purchaseOrder.CanceledBy = dr["CanceledBy"].ToString();
            purchaseOrder.CanceledDate = dr["CanceledDate"].ToDate();

            return purchaseOrder;
        }

        public List<PurchaseOrderLine> GetPurchaseOrderLines(int purchaseOrderId)
        {
            DataTable dtLines = _scm.GetPurchaseOrderLines(purchaseOrderId);

            List<PurchaseOrderLine> lstLines = new List<PurchaseOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new PurchaseOrderLine();

                line.LineId = drLine["PurchaseOrderLineId"].ToInt();
                line.PurchaseOrderId = drLine["PurchaseOrderId"].ToInt();
                line.SeqId = drLine["SeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["Description"].ToString();
                line.PurchaseUomId = drLine["PurchaseUomId"].ToInt();
                line.PurchaseUom = drLine["PurchaseUom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal(3);
                line.Discount = drLine["Discount"].ToDecimal(3);
                line.NetPrice = drLine["NetPrice"].ToDecimal(3);
                line.TotalPrice = drLine["TotalPrice"].ToDecimal(3);
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<PurchaseOrderLine> GetPurchaseOrderLinesToGoodsReceipt(int purchaseOrderId)
        {
            DataTable dtLines = _scm.GetPurchaseOrderLinesToGoodsReceipt(purchaseOrderId);

            List<PurchaseOrderLine> lstLines = new List<PurchaseOrderLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new PurchaseOrderLine();

                line.LineId = drLine["PurchaseOrderLineId"].ToInt();
                line.SeqId = drLine["SeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["Description"].ToString();
                line.PurchaseUomId = drLine["PurchaseUomId"].ToInt();
                line.PurchaseUom = drLine["PurchaseUom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();
                line.ReceivedQuantity = drLine["ReceivedQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetOpenPurchaseOrderList()
        {
            return _scm.GetOpenPurchaseOrderList();
        }

        public DataTable GetGoodsReceiptNoteList(DateTime dateStart, DateTime dateEnd, string supplierName, string goodsReceiptNumber, string orderNumber, string remarks, int statusId, int locationId, string itemSearch)
        {
            return _scm.GetGoodsReceiptNoteList(dateStart, dateEnd, supplierName, goodsReceiptNumber, orderNumber, remarks, statusId, locationId, itemSearch);
        }

        public GoodsReceipt GetGoodsReceiptNoteHeader(int goodsReceiptId)
        {
            DataTable dt = _scm.GetGoodsReceiptNoteHeader(goodsReceiptId);

            GoodsReceipt goodsReceipt = new GoodsReceipt();

            if (dt.Rows.Count == 0)
            {
                goodsReceipt.GoodsReceiptId = -1;
                return goodsReceipt;
            }

            DataRow dr = dt.Rows[0];

            goodsReceipt.GoodsReceiptId = dr["GoodsReceiptId"].ToInt();
            goodsReceipt.StatusId = dr["StatusId"].ToInt();
            goodsReceipt.Status = dr["ReceiptStatus"].ToString();
            goodsReceipt.ReceiptNumber = dr["ReceiptNumber"].ToString();
            goodsReceipt.ReceiptDate = dr["ReceiptDate"].ToDate();
            goodsReceipt.SupplierId = dr["SupplierId"].ToInt();
            goodsReceipt.SupplierName = dr["SupplierName"].ToString();
            //goodsReceipt.SupplierInvoiceNumber = dr["InvoiceNumber"].ToString();
            goodsReceipt.PurchaseOrderId = dr["PurchaseOrderId"].ToInt();
            goodsReceipt.PurchaseOrderNumber = dr["PurchaseOrderNumber"].ToString();
            goodsReceipt.LocationId = dr["LocationId"].ToInt();
            goodsReceipt.Location = dr["Location"].ToString();
            goodsReceipt.Remarks = dr["Remarks"].ToString();
            goodsReceipt.CancelRemarks = dr["CancelRemarks"].ToString();
            goodsReceipt.IsConsignedGoods = dr["IsConsignedGoods"].ToBool();
            goodsReceipt.PreparedBy = dr["PreparedBy"].ToString();
            goodsReceipt.PostedBy = dr["PostedBy"].ToString();
            goodsReceipt.CanceledBy = dr["CanceledBy"].ToString();
            goodsReceipt.CanceledDate = dr["CanceledDate"].ToDate();

            return goodsReceipt;
        }

        public List<GoodsReceiptLine> GetGoodsReceiptNoteLines(int goodsReceiptId)
        {
            DataTable dtLines = _scm.GetGoodsReceiptNoteLines(goodsReceiptId);

            List<GoodsReceiptLine> lstLines = new List<GoodsReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new GoodsReceiptLine();

                line.LineId = drLine["LineId"].ToInt();
                line.GoodsReceiptId = drLine["GoodsReceiptId"].ToInt();
                line.SeqId = drLine["SeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["Description"].ToString();
                line.UomId = drLine["UomId"].ToInt();
                line.Uom = drLine["Uom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();
                line.Status = drLine["Status"].ToString();
                line.Remarks = drLine["Remarks"].ToString();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<GoodsReceiptLine> GetGoodsReceiptLinesToPurchaseInvoice(int goodsReceiptId)
        {
            DataTable dtLines = _scm.GetGoodsReceiptLinesToPurchaseInvoice(goodsReceiptId);

            List<GoodsReceiptLine> lstLines = new List<GoodsReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new GoodsReceiptLine();

                line.LineId = drLine["GoodsReceiptLineId"].ToInt();
                line.SeqId = drLine["SeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["Description"].ToString();
                line.UomId = drLine["UomId"].ToInt();
                line.Uom = drLine["Uom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                line.UnitPrice = drLine["UnitPrice"].ToDecimal(3);
                line.Discount = drLine["Discount"].ToDecimal(3);
                line.IsPercentDiscount = drLine["IsPercentDiscount"].ToBool();
                line.NetPrice = drLine["NetPrice"].ToDecimal(3);
                line.BilledQuantity = drLine["BilledQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetGoodsReceiptNoteOpen()
        {
            return _scm.GetGoodsReceiptNoteOpen();
        }

        public DataTable GetPurchaseInvoiceList(DateTime dateStart, DateTime dateEnd, string supplierName, string invoiceNumber, string receiptNumber, string supplierInvoiceNumber, string remarks, int statusId, string itemSearch)
        {
            return _scm.GetPurchaseInvoiceList(dateStart, dateEnd, supplierName, invoiceNumber, receiptNumber, supplierInvoiceNumber, remarks, statusId, itemSearch);
        }

        public PurchaseInvoice GetPurchaseInvoiceHeader(int purchaseInvoiceId)
        {
            DataTable dt = _scm.GetPurchaseInvoiceHeader(purchaseInvoiceId);

            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

            if (dt.Rows.Count == 0)
            {
                purchaseInvoice.PurchaseInvoiceId = -1;
                return purchaseInvoice;
            }

            DataRow dr = dt.Rows[0];

            purchaseInvoice.PurchaseInvoiceId = dr["PurchaseInvoiceId"].ToInt();
            purchaseInvoice.StatusId = dr["StatusId"].ToInt();
            purchaseInvoice.Status = dr["InvoiceStatus"].ToString();
            purchaseInvoice.InvoiceNumber = dr["InvoiceNumber"].ToString();
            purchaseInvoice.InvoiceDate = dr["InvoiceDate"].ToDate();
            purchaseInvoice.SupplierId = dr["SupplierId"].ToInt();
            purchaseInvoice.SupplierName = dr["SupplierName"].ToString();
            purchaseInvoice.SupplierInvoiceNumber = dr["SupplierInvoiceNumber"].ToString();
            purchaseInvoice.SubTotal = dr["SubTotal"].ToDecimal(3);
            purchaseInvoice.Discount = dr["Discount"].ToDecimal(3);
            purchaseInvoice.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            purchaseInvoice.GrandTotal = dr["GrandTotal"].ToDecimal(3);
            purchaseInvoice.CurrencyId = dr["CurrencyId"].ToInt();
            purchaseInvoice.CurrencyCode = dr["CurrencyCode"].ToString();
            purchaseInvoice.LocalCurrencyId = dr["LocalCurrencyId"].ToInt();
            purchaseInvoice.LocalCurrencyCode = dr["LocalCurrencyCode"].ToString();
            purchaseInvoice.LocationId = dr["LocationId"].ToInt();
            purchaseInvoice.Location = dr["Location"].ToString();
            purchaseInvoice.ExchangeRate = dr["ExchangeRate"].ToDecimal(5);
            purchaseInvoice.Remarks = dr["Remarks"].ToString();
            purchaseInvoice.FreightExpenses = dr["FreightExpenses"].ToDecimal(3);
            purchaseInvoice.ClearanceExpenses = dr["ClearanceExpenses"].ToDecimal(3);
            purchaseInvoice.OtherExpenses = dr["OtherExpenses"].ToDecimal(3);
            purchaseInvoice.OtherExpensesLocalCurrency = dr["OtherExpensesLocalCurrency"].ToDecimal(3);
            purchaseInvoice.PreparedBy = dr["PreparedBy"].ToString();
            purchaseInvoice.PostedBy = dr["PostedBy"].ToString();
            purchaseInvoice.PurchaseOrderId = dr["PurchaseOrderId"].ToInt();
            purchaseInvoice.PurchaseOrderNumber = dr["PurchaseOrderNumber"].ToString();
            purchaseInvoice.GoodsReceiptId = dr["GoodsReceiptId"].ToInt();
            purchaseInvoice.GoodsReceiptNumber = dr["GoodsReceiptNumber"].ToString();

            return purchaseInvoice;
        }

        public List<PurchaseInvoiceLine> GetPurchaseInvoiceLines(int purchaseInvoiceId)
        {
            DataTable dtLines = _scm.GetPurchaseInvoiceLines(purchaseInvoiceId);

            List<PurchaseInvoiceLine> lstLines = new List<PurchaseInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new PurchaseInvoiceLine();

                line.LineId = drLine["LineId"].ToInt();
                line.PurchaseInvoiceId = drLine["PurchaseInvoiceId"].ToInt();
                line.SeqId = drLine["SeqId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.Description = drLine["Description"].ToString();
                line.PurchaseUomId = drLine["PurchaseUomId"].ToInt();
                line.PurchaseUom = drLine["PurchaseUom"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal(3);
                line.Discount = drLine["Discount"].ToDecimal(3);
                line.NetPrice = drLine["NetPrice"].ToDecimal(3);
                line.TotalPrice = drLine["TotalPrice"].ToDecimal(3);
                line.UnitCost = drLine["UnitCost"].ToDecimal(3);
                line.TotalCost = drLine["TotalCost"].ToDecimal(3);
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetPurchaseGoodsReceipts(int orderId)
        {
            return _scm.GetPurchaseGoodsReceipts(orderId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreatePurchaseOrder(PurchaseOrder purchaseOrder, out string rMsg)
        {
            return _scm.CreatePurchaseOrder(purchaseOrder, out rMsg);
        }

        public int CreateGoodsReceiptNote(GoodsReceipt goodsReceipt, out string rMsg)
        {
            return _scm.CreateGoodsReceiptNote(goodsReceipt, out rMsg);
        }

        public int CreateGoodsReceiptNoteFromPurchaseOrder(GoodsReceipt goodsReceipt, string xmlLines, out string rMsg)
        {
            return _scm.CreateGoodsReceiptNoteFromPurchaseOrder(goodsReceipt, xmlLines, out rMsg);
        }

        public int CreatePurchaseInvoice(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            return _scm.CreatePurchaseInvoice(purchaseInvoice, out rMsg);
        }

        public int CreatePurchaseInvoiceFromGoodsReceiptNote(PurchaseInvoice purchaseInvoice, string xmlLines, out string rMsg)
        {
            return _scm.CreatePurchaseInvoiceFromGoodsReceiptNote(purchaseInvoice, xmlLines, out rMsg);
        }


        //**************************************************************************************************************************//UPDATE

        public int UpdatePurchaseOrderHeader(PurchaseOrder purchaseOrder, out string rMsg)
        {
            return _scm.UpdatePurchaseOrderHeader(purchaseOrder, out rMsg);
        }

        public int UpdatePurchaseOrderSummary(int purchaseOrderId, decimal discount, decimal tax, out string rMsg)
        {
            return _scm.UpdatePurchaseOrderSummary(purchaseOrderId, discount, tax, out rMsg);
        }

        public int PostPurchaseOrder(int purchaseOrderId, out string rMsg, out int rMsgId)
        {
            return _scm.PostPurchaseOrder(purchaseOrderId, out rMsg, out rMsgId);
        }

        public int CancelPurchaseOrder(int purchaseOrderId, out string rMsg, out int rMsgId)
        {
            return _scm.CancelPurchaseOrder(purchaseOrderId, out rMsg, out rMsgId);
        }

        public int UpdateGoodsReceiptNoteHeader(GoodsReceipt goodsReceipt, out string rMsg)
        {
            return _scm.UpdateGoodsReceiptNoteHeader(goodsReceipt, out rMsg);
        }

        public int PostGoodsReceiptNote(int goodsReceiptId, out string rMsg, out int rMsgId)
        {
            return _scm.PostGoodsReceiptNote(goodsReceiptId, out rMsg, out rMsgId);
        }

        public int CancelGoodsReceiptNote(int goodsReceiptId, bool updatePurchaseOrderStatus, string cancelRemarks, out string rMsg, out int rMsgId)
        {
            return _scm.CancelGoodsReceiptNote(goodsReceiptId, updatePurchaseOrderStatus, cancelRemarks, out rMsg, out rMsgId);
        }

        public int UpdatePurchaseInvoiceHeader(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            return _scm.UpdatePurchaseInvoiceHeader(purchaseInvoice, out rMsg);
        }

        public int UpdatePurchaseInvoiceSummary(int purchaseInvoiceId, decimal discount, out string rMsg)
        {
            return _scm.UpdatePurchaseInvoiceSummary(purchaseInvoiceId, discount, out rMsg);
        }

        public int UpdatePurchaseInvoicePricing(PurchaseInvoice purchaseInvoice, out string rMsg)
        {
            return _scm.UpdatePurchaseInvoicePricing(purchaseInvoice, out rMsg);
        }

        public int PostPurchaseInvoice(int purchaseInvoiceId, out string rMsg, out int rMsgId)
        {
            return _scm.PostPurchaseInvoice(purchaseInvoiceId, out rMsg, out rMsgId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeletePurchaseOrder(int purchaseOrderId, out string rMsg, out int rMessageId)
        {
            _scm.DeletePurchaseOrder(purchaseOrderId, out rMsg, out rMessageId);
        }

        public void DeleteGoodsReceiptNote(int goodsReceiptId, out string rMsg, out int rMessageId)
        {
            _scm.DeleteGoodsReceiptNote(goodsReceiptId, out rMsg, out rMessageId);
        }

        public void DeletePurchaseInvoice(int purchaseInvoiceId, out string rMsg, out int rMessageId)
        {
            _scm.DeletePurchaseInvoice(purchaseInvoiceId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddPurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            return _scm.AddPurchaseOrderLine(line, out rMsg);
        }

        public void UpdatePurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            _scm.UpdatePurchaseOrderLine(line, out rMsg);
        }

        public void DeletePurchaseOrderLine(PurchaseOrderLine line, out string rMsg)
        {
            _scm.DeletePurchaseOrderLine(line, out rMsg);
        }

        public int AddGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            return _scm.AddGoodsReceiptLine(line, out rMsg);
        }

        public void UpdateGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            _scm.UpdateGoodsReceiptLine(line, out rMsg);
        }

        public void DeleteGoodsReceiptLine(GoodsReceiptLine line, out string rMsg)
        {
            _scm.DeleteGoodsReceiptLine(line, out rMsg);
        }

        public int AddPurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            return _scm.AddPurchaseInvoiceLine(line, out rMsg);
        }

        public void UpdatePurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            _scm.UpdatePurchaseInvoiceLine(line, out rMsg);
        }

        public void DeletePurchaseInvoiceLine(PurchaseInvoiceLine line, out string rMsg)
        {
            _scm.DeletePurchaseInvoiceLine(line, out rMsg);
        }

        //**************************************************************************************************************************//REPORTS

        public DataTable GetReport1(DateTime dateStart, DateTime dateEnd)
        {
            return _scm.GetReport1(dateStart, dateEnd);
        }

        public Tuple<List<GoodsReceipt>, List<PurchaseInvoice>> GetReport2(DateTime dateStart, DateTime dateEnd)
        {
            DataSet ds = _scm.GetReport2(dateStart, dateEnd);

            DataTable dtGoodsReceipt = ds.Tables[0];
            DataTable dtPurchaseInvoice = ds.Tables[1];

            List<GoodsReceipt> lstGoodsReceipt = new List<GoodsReceipt>();
            List<PurchaseInvoice> lstPurchaseInvoice = new List<PurchaseInvoice>();

            foreach (DataRow dr in dtGoodsReceipt.Rows)
            {
                var goodsReceipt = new GoodsReceipt();
                goodsReceipt.GoodsReceiptId = dr["GoodsReceiptId"].ToInt();
                goodsReceipt.ReceiptNumber = dr["ReceiptNumber"].ToString();
                goodsReceipt.ReceiptDate = dr["ReceiptDate"].ToDate();
                goodsReceipt.SupplierName = dr["SupplierName"].ToString();
                goodsReceipt.ProductsQuantity = dr["MRQTY"].ToDecimal();

                lstGoodsReceipt.Add(goodsReceipt);
            }

            foreach (DataRow dr in dtPurchaseInvoice.Rows)
            {
                var purchaseInvoice = new PurchaseInvoice();
                purchaseInvoice.GoodsReceiptId = dr["GoodsReceiptId"].ToInt();
                purchaseInvoice.PurchaseInvoiceId = dr["PurchaseInvoiceId"].ToInt();
                purchaseInvoice.InvoiceNumber = dr["InvoiceNumber"].ToString();
                purchaseInvoice.SupplierName = dr["SupplierName"].ToString();
                purchaseInvoice.InvoiceDate = dr["InvoiceDate"].ToDate();
                purchaseInvoice.ProductsQuantity = dr["InvoiceProductsQuantity"].ToDecimal();

                lstPurchaseInvoice.Add(purchaseInvoice);
            }

            return Tuple.Create(lstGoodsReceipt, lstPurchaseInvoice);
        }
    }
}