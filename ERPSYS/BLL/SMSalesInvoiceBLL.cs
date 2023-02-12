using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SalesInvoiceBLL
    {
        private readonly SalesInvoiceDB _invoice = new SalesInvoiceDB();

        //**************************************************************************************************************************//Settings

        public int DefaultLocationId
        {
            get { return 1; } //  Main Store
        }

        public int DefaultPaymentMethodId
        {
            get { return 1; } //  Not Specified
        }

        public int DefaultPaymentTermsId
        {
            get { return 1; } //  Not Specified
        }

        //**************************************************************************************************************************//SELECT

        public DataTable GetSalesInvoiceList(DateTime dateStart, DateTime dateEnd, string customerName, string invoiceNumber, int invoiceStatusId, string itemSearch)
        {
            return _invoice.GetSalesInvoiceList(dateStart, dateEnd, customerName, invoiceNumber, invoiceStatusId, itemSearch);
        }

        public DataTable GetSalesInvoiceReportList(DateTime dateStart, DateTime dateEnd, int locationId, int paymentMethodId)
        {
            return _invoice.GetSalesInvoiceReportList(dateStart, dateEnd, locationId, paymentMethodId);
        }

        public int GetSalesInvoiceId(string invoiceNumber)
        {
            return _invoice.GetSalesInvoiceId(invoiceNumber);
        }

        public SalesInvoice GetSalesInvoiceHeader(int invoiceId)
        {
            DataTable dt = _invoice.GetSalesInvoiceHeader(invoiceId);

            SalesInvoice invoice = new SalesInvoice();

            if (dt.Rows.Count == 0)
            {
                invoice.InvoiceId = -1;
                return invoice;
            }

            DataRow dr = dt.Rows[0];

            invoice.InvoiceId = invoiceId;
            invoice.InvoiceNumber = dr["InvoiceNumber"].ToString();
            invoice.InvoiceDate = dr["InvoiceDate"].ToDate();
            invoice.CustomerId = dr["CustomerId"].ToInt();
            invoice.CustomerName = dr["CustomerName"].ToString();
            invoice.CustomerNameAr = dr["CustomerNameAr"].ToString();
            invoice.LocationId = dr["LocationId"].ToInt();
            invoice.Location = dr["Location"].ToString();
            invoice.PurchaseOrder = dr["PurchaseOrder"].ToString();
            invoice.ProjectName = dr["ProjectName"].ToString();
            invoice.PaymentMethodId = dr["PaymentMethodId"].ToInt();
            invoice.PaymentMethod = dr["PaymentMethod"].ToString();
            invoice.PaymentTermsId = dr["PaymentTermsId"].ToInt();
            invoice.PaymentTerms = dr["PaymentTerms"].ToString();
            invoice.CurrencyId = dr["CurrencyId"].ToInt();
            invoice.CurrencyCode = dr["CurrencyCode"].ToString();
            invoice.CurrencyIdView = dr["CurrencyIdView"].ToInt();
            invoice.CurrencyView = dr["CurrencyView"].ToString();
            invoice.SubTotal = dr["SubTotal"].ToDecimal();
            invoice.Discount = dr["Discount"].ToDecimal();
            invoice.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            invoice.Expenses = dr["Expenses"].ToDecimal();
            invoice.Tax = dr["Tax"].ToDecimal();
            invoice.GrandTotal = dr["GrandTotal"].ToDecimal();
            invoice.Remarks = dr["Remarks"].ToString();
            invoice.RefundInvoiceId = dr["RefundInvoiceId"].ToInt();
            invoice.IsRefund = dr["IsRefund"].ToBool();
            invoice.SalesOrderId = dr["SalesOrderId"].ToInt();
            invoice.SalesOrderNumber = dr["SalesOrderNumber"].ToString();
            invoice.JobOrderId = dr["JobOrderId"].ToInt();
            invoice.JobOrderNumber = dr["JobOrderNumber"].ToString();
            invoice.StatusId = dr["StatusId"].ToInt();
            invoice.Status = dr["InvoiceStatus"].ToString();
            invoice.IsRefundBefore = dr["IsRefundBefore"].ToBool(); // for posted invoice

            return invoice;
        }

        public List<SalesInvoiceLine> GetSalesInvoiceLines(int invoiceId)
        {
            DataTable dtLines = _invoice.GetSalesInvoiceLines(invoiceId);

            List<SalesInvoiceLine> lstLines = new List<SalesInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesInvoiceLine();

                line.InvoiceId = drLine["InvoiceId"].ToInt();
                line.LineId = drLine["InvoiceLineId"].ToInt();
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
                line.StatusId = drLine["StatusId"].ToInt();
                line.UnitCost = drLine["UnitCost"].ToDecimal();
                line.TotalCost = drLine["TotalCost"].ToDecimal();
                line.IsLowMinPrice = drLine["IsLowMinPrice"].ToInt();
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesInvoiceLine> GetSalesInvoiceMainLines(int invoiceId)
        {
            DataTable dtLines = _invoice.GetSalesInvoiceMainLines(invoiceId);

            List<SalesInvoiceLine> lstLines = new List<SalesInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesInvoiceLine();

                line.InvoiceId = drLine["InvoiceId"].ToInt();
                line.LineId = drLine["InvoiceLineId"].ToInt();
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
                line.StatusId = drLine["StatusId"].ToInt();
                line.IsLowMinPrice = drLine["IsLowMinPrice"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesInvoiceLine> GetSalesInvoiceSubLine(int invoiceId, int invoiceLineId)
        {
            DataTable dtLines = _invoice.GetSalesInvoiceSubLine(invoiceId, invoiceLineId);

            List<SalesInvoiceLine> lstLines = new List<SalesInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesInvoiceLine();

                line.InvoiceId = drLine["InvoiceId"].ToInt();
                line.LineId = drLine["InvoiceLineId"].ToInt();
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
                line.StatusId = drLine["StatusId"].ToInt();
                line.IsLowMinPrice = drLine["IsLowMinPrice"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<SalesInvoiceLine> GetSalesInvoiceLinesStoreQuantity(int invoiceId)
        {
            DataTable dtLines = _invoice.GetSalesInvoiceLinesStoreQuantity(invoiceId);

            List<SalesInvoiceLine> lstLines = new List<SalesInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesInvoiceLine();

                line.InvoiceId = drLine["InvoiceId"].ToInt();
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

        public DataTable GetSalesInvoiceDeliveryReceipts(int invoiceId)
        {
            return _invoice.GetSalesInvoiceDeliveryReceipts(invoiceId);
        }

        public List<SalesInvoiceLine> GetSalesInvoiceRefundLines(int invoiceId)
        {
            DataTable dtLines = _invoice.GetSalesInvoiceRefundLines(invoiceId);

            List<SalesInvoiceLine> lstLines = new List<SalesInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new SalesInvoiceLine();

                line.InvoiceId = drLine["InvoiceId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.Quantity = drLine["InvoiceQuantity"].ToDecimal();
                line.RefundQuantity = drLine["RefundQuantity"].ToDecimal();
                line.RemainingQuantity = drLine["RemainingQuantity"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesInvoice(SalesInvoice invoice, out string rMsg)
        {
            return _invoice.CreateSalesInvoice(invoice, out rMsg);
        }

        public int CreateSalesInvoiceFromDeliveryReceiptNote(SalesInvoice invoice, int receiptId, out string rMsg)
        {
            return _invoice.CreateSalesInvoiceFromDeliveryReceiptNote(invoice, receiptId, out rMsg);
        }

        public int CreateSalesInvoiceFromMultipleDeliveryReceiptNote(SalesInvoice invoice, string xmlLines, List<int> receiptsIdList,  out string rMsg)
        {
            return _invoice.CreateSalesInvoiceFromMultipleDeliveryReceiptNote(invoice, xmlLines, receiptsIdList, out rMsg);
        }

        public int CreateSalesInvoiceFromProformaInvoice(SalesInvoice invoice, int proInvoiceId, out string rMsg)
        {
            return _invoice.CreateSalesInvoiceFromProformaInvoice(invoice, proInvoiceId, out rMsg);
        }

        public int CreateRefundWholeSalesInvoice(SalesInvoice invoice, out string rMsg)
        {
            return _invoice.CreateRefundWholeSalesInvoice(invoice, out rMsg);
        }

        public int CreateRefundSalesInvoice(int mainInvoiceId, SalesInvoice invoice, string xmlLines, out string rMsg)
        {
            return _invoice.CreateRefundSalesInvoice(mainInvoiceId, invoice, xmlLines, out rMsg);
        }

        public int CreateSalesInvoiceFromSalesQuotation(SalesInvoice order, int quoteId, out string rMsg)
        {
            return _invoice.CreateSalesInvoiceFromSalesQuotation(order, quoteId, out rMsg);
        }

        public int CloneSalesInvoice(int salesInvoiceId, out string rMsg)
        {
            return _invoice.CloneSalesInvoice(salesInvoiceId, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesInvoiceHeader(SalesInvoice invoice, out string rMsg)
        {
            return _invoice.UpdateSalesInvoiceHeader(invoice, out rMsg);
        }

        public int UpdateSalesInvoiceSummary(int invoiceId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            return _invoice.UpdateSalesInvoiceSummary(invoiceId, expenses, discount, tax, out rMsg);
        }

        public int PostSalesInvoice(int invoiceId, out string rMsg, out int rMessageId)
        {
            return _invoice.PostSalesInvoice(invoiceId, out rMsg, out rMessageId);
        }

        public int PostSalesInvoiceAdvanced(int invoiceId, int invoiceSeq, DateTime invoiceDate, out string rMsg, out int rMessageId)
        {
            return _invoice.PostSalesInvoiceAdvanced(invoiceId, invoiceSeq, invoiceDate, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesInvoice(int invoiceId, out string rMsg, out int rMessageId)
        {
            _invoice.DeleteSalesInvoice(invoiceId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(SalesInvoiceLine line, out string rMsg)
        {
            return _invoice.AddMainLine(line, out rMsg);
        }

        public void UpdateMainLine(SalesInvoiceLine line, out string rMsg)
        {
            _invoice.UpdateMainLine(line, out rMsg);
        }

        public void DeleteMainLine(SalesInvoiceLine line, out string rMsg)
        {
            _invoice.DeleteMainLine(line, out rMsg);
        }

        public int AddSubLine(SalesInvoiceLine line, out string rMsg)
        {
            return _invoice.AddSubLine(line, out rMsg);
        }

        public void UpdateSubLine(SalesInvoiceLine line, out string rMsg)
        {
            _invoice.UpdateSubLine(line, out rMsg);
        }

        public void DeleteSubLine(SalesInvoiceLine line, out string rMsg)
        {
            _invoice.DeleteSubLine(line, out rMsg);
        }
    }
}