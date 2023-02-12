using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class DeliveryReceiptBLL
    {

        private readonly DeliveryReceiptDB _delivery = new DeliveryReceiptDB();

        //**************************************************************************************************************************//Settings

        public int DefaultDeliveryReceiptLocationId
        {
            get { return 1; } // predefined location
        }

        //**************************************************************************************************************************//SELECT

        public DataTable GetDeliveryReceiptList(DateTime dateStart, DateTime dateEnd, string customerName, string receiptNumber, int statusId)
        {
            return _delivery.GetDeliveryReceiptList(dateStart, dateEnd, customerName, receiptNumber, statusId);
        }

        public DataTable GetNotBilledDeliveryReceipt()
        {
            return _delivery.GetNotBilledDeliveryReceipt();
        }

        public DataTable GetCustomersListNotBilledDeliveryReceipt()
        {
            return _delivery.GetCustomersListNotBilledDeliveryReceipt();
        }

        public DataTable GetSalesOrderNotBilledDeliveryReceipt(int customerId)
        {
            return _delivery.GetSalesOrderNotBilledDeliveryReceipt(customerId);
        }

        public DataTable GetNotBilledDeliveryReceiptBySalesOrder(int customerId, int orderId)
        {
            return _delivery.GetNotBilledDeliveryReceiptBySalesOrder(customerId, orderId);
        }

        public DeliveryReceipt GetDeliveryReceiptHeader(int receiptId)
        {
            DataTable dt = _delivery.GetDeliveryReceiptHeader(receiptId);

            DeliveryReceipt delivery = new DeliveryReceipt();

            if (dt.Rows.Count == 0)
            {
                delivery.ReceiptId = -1;
                return delivery;
            }

            DataRow dr = dt.Rows[0];
            delivery.ReceiptId = dr["ReceiptId"].ToInt();
            delivery.ReceiptNumber = dr["ReceiptNumber"].ToString();
            delivery.ReceiptDate = dr["ReceiptDate"].ToDate();
            delivery.CustomerId = dr["CustomerId"].ToInt();
            delivery.CustomerName = dr["CustomerName"].ToString();
            delivery.CustomerNameAr = dr["CustomerNameAr"].ToString();
            delivery.LocationId = dr["LocationId"].ToInt();
            delivery.Location = dr["Location"].ToString();
            delivery.PurchaseOrder = dr["PurchaseOrder"].ToString();
            delivery.CurrencyId = dr["CurrencyId"].ToInt();
            delivery.CurrencyCode = dr["CurrencyCode"].ToString();
            delivery.ExchangeRate = dr["ExchangeRate"].ToDecimal();
            delivery.ProjectName = dr["ProjectName"].ToString();
            delivery.CurrencyId = dr["CurrencyId"].ToInt();
            delivery.CurrencyCode = dr["CurrencyCode"].ToString();
            delivery.Remarks = dr["Remarks"].ToString();
            delivery.Expenses = dr["Expenses"].ToDecimal();
            delivery.Discount = dr["Discount"].ToDecimal();
            delivery.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            delivery.SubTotal = dr["SubTotal"].ToDecimal();
            delivery.Tax = dr["Tax"].ToDecimal();
            delivery.GrandTotal = dr["GrandTotal"].ToDecimal();
            delivery.JobOrderId = dr["JobOrderId"].ToInt();
            delivery.JobOrderNumber = dr["JobOrderNumber"].ToString();
            delivery.SalesOrderId = dr["SalesOrderId"].ToInt();
            delivery.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
            delivery.SalesInvoiceId = dr["InvoiceId"].ToInt();
            delivery.SalesInvoiceNumber = dr["InvoiceNumber"].ToString();
            delivery.UserId = dr["UserId"].ToInt();
            delivery.UserName = dr["UserName"].ToString();
            delivery.StatusId = dr["StatusId"].ToInt();
            delivery.Status = dr["ReceiptStatus"].ToString();
            delivery.OrderDiscount = dr["OrderDiscount"].ToDecimal();

            return delivery;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptLines(int receiptId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptLines(receiptId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.IsSpecialRecord = drLine["IsSpecialRecord"].ToBool();
                line.LocationId = drLine["LocationId"].ToInt();
                line.Location = drLine["Location"].ToString();
                line.UomId = drLine["UomId"].ToInt();
                line.Uom = drLine["Uom"].ToString();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptMainLines(int receiptId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptMainLines(receiptId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.IsSpecialRecord = drLine["IsSpecialRecord"].ToBool();
                line.LocationId = drLine["LocationId"].ToInt();
                line.Location = drLine["Location"].ToString();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptSubLine(int receiptId, int receiptLineId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptSubLine(receiptId, receiptLineId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.IsSpecialRecord = drLine["IsSpecialRecord"].ToBool();
                line.LocationId = drLine["LocationId"].ToInt();
                line.Location = drLine["Location"].ToString();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptCompactLines(int receiptId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptCompactLines(receiptId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.IsSpecialRecord = drLine["IsSpecialRecord"].ToBool();
                line.LocationId = drLine["LocationId"].ToInt();
                line.Location = drLine["Location"].ToString();
                line.Uom = drLine["Uom"].ToString();
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptLinesStoreQuantity(int receiptId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptLinesStoreQuantity(receiptId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["Description"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.StoreQuantity = drLine["StoreQuantity"].ToDecimal();
                line.Uom = drLine["Uom"].ToString();
                line.Location = drLine["Location"].ToString();
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetDeliveryReceiptSalesInvoiceLines(int receiptId)
        {
            DataTable dtLines = _delivery.GetDeliveryReceiptSalesInvoiceLines(receiptId);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DeliveryReceipt GetMultipleDeliveryReceiptHeader(int customerId, int orderId, List<int> receiptsIdList)
        {
            DataTable dt = _delivery.GetMultipleDeliveryReceiptHeader(customerId, orderId, receiptsIdList);

            DeliveryReceipt delivery = new DeliveryReceipt();

            if (dt.Rows.Count == 0)
            {
                delivery.ReceiptId = -1;
                return delivery;
            }

            if (dt.Rows.Count > 1)
            {
                delivery.ReceiptId = -2;
                return delivery;
            }


            DataRow dr = dt.Rows[0];
            //delivery.ReceiptId = dr["ReceiptId"].ToInt();
            //delivery.ReceiptNumber = dr["ReceiptNumber"].ToString();
            //delivery.ReceiptDate = dr["ReceiptDate"].ToDate();
            delivery.CustomerId = dr["CustomerId"].ToInt();
            delivery.CustomerName = dr["CustomerName"].ToString();
            delivery.CustomerNameAr = dr["CustomerNameAr"].ToString();
            delivery.PurchaseOrder = dr["PurchaseOrder"].ToString();
            //delivery.LocationId = dr["LocationId"].ToInt();
            //delivery.Location = dr["Location"].ToString();
            delivery.CurrencyId = dr["CurrencyId"].ToInt();
            delivery.CurrencyCode = dr["CurrencyCode"].ToString();
            delivery.ExchangeRate = dr["ExchangeRate"].ToDecimal();
            delivery.ProjectName = dr["ProjectName"].ToString();
            delivery.CurrencyId = dr["CurrencyId"].ToInt();
            delivery.CurrencyCode = dr["CurrencyCode"].ToString();
            //delivery.Remarks = dr["Remarks"].ToString();
            delivery.Expenses = dr["Expenses"].ToDecimal();
            delivery.Discount = dr["Discount"].ToDecimal();
            delivery.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            delivery.SubTotal = dr["SubTotal"].ToDecimal();
            delivery.Tax = dr["Tax"].ToDecimal();
            delivery.GrandTotal = dr["GrandTotal"].ToDecimal();
            delivery.JobOrderId = dr["JobOrderId"].ToInt();
            delivery.JobOrderNumber = dr["JobOrderNumber"].ToString();
            delivery.SalesOrderId = dr["SalesOrderId"].ToInt();
            delivery.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
            //delivery.SalesInvoiceId = dr["InvoiceId"].ToInt();
            //delivery.SalesInvoiceNumber = dr["InvoiceNumber"].ToString();
            //delivery.UserId = dr["UserId"].ToInt();
            //delivery.UserName = dr["UserName"].ToString();
            delivery.StatusId = dr["StatusId"].ToInt();
            delivery.Status = dr["ReceiptStatus"].ToString();

            delivery.OrderDiscount = dr["OrderDiscount"].ToDecimal();

            return delivery;
        }

        public List<DeliveryReceiptLine> GetMultipleDeliveryReceiptSalesInvoiceLines(List<int> receiptsIdList)
        {
            DataTable dtLines = _delivery.GetMultipleDeliveryReceiptSalesInvoiceLines(receiptsIdList);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                //line.LineSeqId = drLine["LineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();
                //line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<DeliveryReceiptLine> GetMultipleDeliveryReceiptSalesInvoiceLinesX(List<int> receiptsIdList)
        {
            DataTable dtLines = _delivery.GetMultipleDeliveryReceiptSalesInvoiceLinesX(receiptsIdList);

            List<DeliveryReceiptLine> lstLines = new List<DeliveryReceiptLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new DeliveryReceiptLine();

                line.ReceiptId = drLine["ReceiptId"].ToInt();
                line.LineId = drLine["ReceiptLineId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        //**************************************************************************************************************************//INSERT

        public int CreateDeliveryReceiptNoteFromSalesOrder(DeliveryReceipt deliveryReceipt, string xmlLines, out string rMsg)
        {
            return _delivery.CreateDeliveryReceiptNoteFromSalesOrder(deliveryReceipt, xmlLines, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int PostDeliveryReceipt(int receiptId, out string rMsg, out int rMessageId)
        {
            return _delivery.PostDeliveryReceipt(receiptId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteDeliveryReceipt(int receiptId, out string rMsg, out int rMessageId)
        {
            _delivery.DeleteDeliveryReceipt(receiptId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public void UpdateDeliveryReceiptLine(DeliveryReceiptLine line, out string rMsg)
        {
            _delivery.UpdateDeliveryReceiptLine(line, out rMsg);
        }

        public void DeleteMainLine(DeliveryReceiptLine line, out string rMsg)
        {
            _delivery.DeleteMainLine(line, out rMsg);
        }
    }
}