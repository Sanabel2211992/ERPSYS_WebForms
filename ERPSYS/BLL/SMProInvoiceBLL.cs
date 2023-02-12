using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ProformaInvoiceBLL
    {
        private readonly ProformaInvoiceDB _invoice = new ProformaInvoiceDB();

        //**************************************************************************************************************************//Settings

        public int DefaultPaymentMethodId
        {
            get { return 1; } //  Not Specified
        }

        public int DefaultPaymentTermsId
        {
            get { return 1; } //  Not Specified
        }

        public void CancelProformaInvoice(int invoiceId, out string rMsg, out int rMessageId)
        {
            _invoice.CancelProformaInvoice(invoiceId, out rMsg, out rMessageId);
        }
        
        //**************************************************************************************************************************//SELECT

        public DataTable GetProformaInvoiceList(DateTime dateStart, DateTime dateEnd, string customerName, int invoiceStatusId, string itemSearch)
        {
            return _invoice.GetProformaInvoiceList(dateStart, dateEnd, customerName, invoiceStatusId, itemSearch);
        }

        public ProformaInvoice GetProformaInvoiceHeader(int invoiceId) 
        {
            DataTable dt = _invoice.GetProformaInvoiceHeader(invoiceId);

            ProformaInvoice invoice = new ProformaInvoice();

            if (dt.Rows.Count == 0)
            {
                invoice.InvoiceId = -1;
                return invoice;
            }

            DataRow dr = dt.Rows[0];

            invoice.InvoiceId = invoiceId;
            invoice.InvoiceDate = dr["InvoiceDate"].ToDate();
            invoice.CustomerId = dr["CustomerId"].ToInt();
            invoice.CustomerName = dr["CustomerName"].ToString();
            invoice.CustomerNameAr = dr["CustomerNameAr"].ToString();
            invoice.ProjectName = dr["ProjectName"].ToString();
            invoice.InvoiceNumber = dr["InvoiceNumber"].ToString();
            invoice.PaymentMethodId = dr["PaymentMethodId"].ToInt();
            invoice.PaymentMethod = dr["PaymentMethod"].ToString();
            invoice.PaymentTermsId = dr["PaymentTermsId"].ToInt();
            invoice.PaymentTerms = dr["PaymentTerms"].ToString();
            invoice.CurrencyId = dr["CurrencyId"].ToInt();
            invoice.CurrencyCode = dr["CurrencyCode"].ToString();
            invoice.SubTotal = dr["SubTotal"].ToDecimal();
            invoice.Discount = dr["Discount"].ToDecimal();
            invoice.Tax = dr["Tax"].ToDecimal();
            invoice.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            invoice.Expenses = dr["Expenses"].ToDecimal();
            invoice.GrandTotal = dr["GrandTotal"].ToDecimal();
            invoice.Remarks = dr["Remarks"].ToString();
            invoice.StatusId = dr["StatusId"].ToInt();
            invoice.Status = dr["InvoiceStatus"].ToString();

            return invoice;
        }

        public List<ProformaInvoiceLine> GetProformaInvoiceLines(int invoiceId)
        {
            DataTable dtLines = _invoice.GetProformaInvoiceLines(invoiceId);

            List<ProformaInvoiceLine> lstLines = new List<ProformaInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ProformaInvoiceLine();
                
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
                line.IsServiceItem = drLine["IsServiceItem"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<ProformaInvoiceLine> GetProformaInvoiceMainLines(int invoiceId)
        {
            DataTable dtLines = _invoice.GetProformaInvoiceMainLines(invoiceId);

            List<ProformaInvoiceLine> lstLines = new List<ProformaInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ProformaInvoiceLine();

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

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<ProformaInvoiceLine> GetProformaInvoiceSubLine(int invoiceId, int invoiceLineId)
        {
            DataTable dtLines = _invoice.GetProformaInvoiceSubLine(invoiceId, invoiceLineId);

            List<ProformaInvoiceLine> lstLines = new List<ProformaInvoiceLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ProformaInvoiceLine();

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

                lstLines.Add(line);
            }

            return lstLines;
        }

        //**************************************************************************************************************************//INSERT

        public int CreateProformaInvoice(ProformaInvoice invoice, out string rMsg)
        {
            return _invoice.CreateProformaInvoice(invoice, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateProformaInvoiceHeader(ProformaInvoice invoice, out string rMsg)
        {
            return _invoice.UpdateProformaInvoiceHeader(invoice, out rMsg);
        }

        public int UpdateProformaInvoiceSummary(int invoiceId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            return _invoice.UpdateProformaInvoiceSummary(invoiceId, expenses, discount, tax, out rMsg);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteProformaInvoice(int invoiceId, out string rMsg, out int rMessageId)
        {
            _invoice.DeleteProformaInvoice(invoiceId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(ProformaInvoiceLine line, out string rMsg)
        {
            return _invoice.AddMainLine(line, out rMsg);
        }

        public void UpdateMainLine(ProformaInvoiceLine line, out string rMsg)
        {
            _invoice.UpdateMainLine(line, out rMsg);
        }

        public void DeleteMainLine(ProformaInvoiceLine line, out string rMsg)
        {
            _invoice.DeleteMainLine(line, out rMsg);
        }

        public int AddSubLine(ProformaInvoiceLine line, out string rMsg)
        {
            return _invoice.AddSubLine(line, out rMsg);
        }

        public void UpdateSubLine(ProformaInvoiceLine line, out string rMsg)
        {
            _invoice.UpdateSubLine(line, out rMsg);
        }

        public void DeleteSubLine(ProformaInvoiceLine line, out string rMsg)
        {
            _invoice.DeleteSubLine(line, out rMsg);
        }
    }
}