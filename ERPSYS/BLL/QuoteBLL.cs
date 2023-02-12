using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Linq;

namespace ERPSYS.BLL
{
    public class QuoteBLL 
    {
        private readonly QuoteDB _quote = new QuoteDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetSalesQuoteList(DateTime dateStart, DateTime dateEnd, string customerName, string quoteNumber, int quoteStatusId)
        {
            return _quote.GetSalesQuoteList(dateStart, dateEnd, customerName, quoteNumber, quoteStatusId);
        }

        public Quote GetSalesQuoteHeader(int quoteId)
        {
            DataTable dt = _quote.GetSalesQuoteHeader(quoteId);

            Quote quote = new Quote();

            if (dt.Rows.Count == 0)
            {
                quote.QuoteId = -1;
                return quote;
            }

            DataRow dr = dt.Rows[0];

            quote.QuoteId = quoteId;
            quote.QuoteNumber = dr["QuoteNumber"].ToString();
            quote.QuoteDate = dr["QuoteDate"].ToDate();
            quote.CustomerId = dr["CustomerId"].ToInt();
            quote.CustomerName = dr["CustomerName"].ToString();
            quote.CustomerNameAr = dr["CustomerNameAr"].ToString();
            quote.ProjectName = dr["ProjectName"].ToString();
            quote.Remarks = dr["Remarks"].ToString();
            quote.Expenses = dr["Expenses"].ToDecimal();
            quote.Discount = dr["Discount"].ToDecimal();
            quote.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            quote.SubTotal = dr["SubTotal"].ToDecimal();
            quote.GrandTotal = dr["GrandTotal"].ToDecimal();
            quote.Tax = dr["Tax"].ToDecimal();
            quote.SalesOrderId = dr["SalesOrderId"].ToInt();
            quote.SalesInvoiceId = dr["SalesInvoiceId"].ToInt();
            quote.StatusId = dr["StatusId"].ToInt();
            quote.Status = dr["QuoteStatus"].ToString();
            quote.CompanyIdView = dr["CompanyIdView"].ToInt();
            quote.CompanyCode = dr["CompanyCode"].ToString();
            quote.CurrencyIdView = dr["CurrencyIdView"].ToInt();
            quote.CurrencyViewCode = dr["CurrencyViewCode"].ToString();
            quote.SalesEngineerId = dr["SalesEngineerId"].ToInt();
            quote.SalesEngineerName = dr["SalesEngineerName"].ToString();
            quote.IsContainGroup = dr["IsContainGroup"].ToBool();
            quote.InquiryNumber = dr["InquiryNumber"].ToString();
            quote.InquiryDate = dr["InquiryDate"].ToDate();
            quote.UserId = dr["UserId"].ToInt();
            quote.UserName = dr["UserName"].ToString();
            return quote;
        }

        public Quote GetSalesQuote(int quoteId)
        {
            DataSet dsSalesQuote = _quote.GetSalesQuote(quoteId);

            DataTable dtHeader = dsSalesQuote.Tables[0];
            DataTable dtLines = dsSalesQuote.Tables[1];

            if (dtHeader.Rows.Count == 0)
            {
                throw new Exception("Error");
            }

            Quote quote = new Quote();
            DataRow dr = dtHeader.Rows[0];

            quote.QuoteId = quoteId;
            quote.QuoteNumber = dr["QuoteNumber"].ToString();
            quote.CustomerId = dr["CustomerId"].ToInt();
            quote.CustomerName = dr["CustomerName"].ToString();
            quote.CustomerNameAr = dr["CustomerNameAr"].ToString();
            quote.SalesEngineerId = dr["SalesEngineerId"].ToInt();
            quote.SalesEngineerName = dr["SalesEngineerName"].ToString();
            quote.ProjectName = dr["ProjectName"].ToString();
            quote.QuoteDate = dr["QuoteDate"].ToDate();
            quote.CurrencyIdView = dr["CurrencyIdView"].ToInt();
            quote.CurrencyViewCode = dr["CurrencyViewCode"].ToString();
            quote.CompanyIdView = dr["CompanyIdView"].ToInt();
            quote.CompanyCode = dr["CompanyCode"].ToString();
            quote.InquiryNumber = dr["InquiryNumber"].ToString();
            quote.InquiryDate = dr["InquiryDate"].ToDate();
            quote.StatusId = dr["StatusId"].ToInt();
            quote.Status = dr["Status"].ToString();
            quote.SubTotal = dr["SubTotal"].ToDecimal();
            quote.Expenses = dr["Expenses"].ToDecimal();
            quote.Discount = dr["Discount"].ToDecimal();
            quote.IsPercentDiscount = dr["IsPercentDiscount"].ToBool();
            quote.GrandTotal = dr["GrandTotal"].ToDecimal();
            quote.Remarks = dr["Remarks"].ToString();
            quote.UserId = dr["UserId"].ToInt();
            quote.UserName = dr["UserName"].ToString();
            
            // Quote Lines

            List<QuoteLine> lstLine = new List<QuoteLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new QuoteLine();

                line.QuoteLineId = drLine["QuoteLineId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-"); ;
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-"); ;
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();

                lstLine.Add(line);
            }

            quote.QuoteLines = lstLine;

            return quote;
        }

        public List<QuoteLine> GetSalesQuoteLines(int quoteId)
        {
            DataTable dtLines = _quote.GetSalesQuoteLines(quoteId);

            List<QuoteLine> lstLines = new List<QuoteLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new QuoteLine();

                line.QuoteId = drLine["QuoteId"].ToInt();
                line.QuoteLineId = drLine["QuoteLineId"].ToInt();
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
                line.UnitCost = drLine["UnitCost"].ToDecimal();
                line.TotalCost = drLine["TotalCost"].ToDecimal();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<QuoteLine> GetSalesQuoteMainLines(int quoteId)
        {
            DataTable dtLines = _quote.GetSalesQuoteMainLines(quoteId);

            List<QuoteLine> lstLines = new List<QuoteLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new QuoteLine();

                line.QuoteId = drLine["QuoteId"].ToInt();
                line.QuoteLineId = drLine["QuoteLineId"].ToInt();
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
                line.IsRoundUp = drLine["IsRoundUp"].ToBool();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public List<QuoteLine> GetSalesQuoteSubLine(int quoteId, int orderLineId)
        {
            DataTable dtLines = _quote.GetSalesQuoteSubLine(quoteId, orderLineId);

            List<QuoteLine> lstLines = new List<QuoteLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new QuoteLine();

                line.Quantity = drLine["QuoteId"].ToInt();
                line.QuoteLineId = drLine["QuoteLineId"].ToInt();
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
               // line.StatusId = drLine["StatusId"].ToInt();

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetSalesQuoteCompactLines(int quoteId)
        {
            return _quote.GetSalesQuoteCompactLines(quoteId);
        }

        //public List<QuoteLine> GetSalesQuoteLinesCombinedStatus(int quoteId)
        //{
        //    DataTable dtLines = _quote.GetSalesQuoteLinesCombinedStatus(quoteId);

        //    List<QuoteLine> lstLines = new List<QuoteLine>();

        //    foreach (DataRow drLine in dtLines.Rows)
        //    {
        //        var line = new QuoteLine();

        //        line.QuoteId = drLine["quoteId"].ToInt();
        //        line.ItemId = drLine["ItemId"].ToInt();
        //        line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
        //        line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
        //        line.DescriptionAs = drLine["DescriptionAs"].ToString();
        //        line.Quantity = drLine["Quantity"].ToDecimal();

        //        lstLines.Add(line);
        //    }

        //    return lstLines;
        //}

        public DocumentTemplateClass GetSalesQuoteRemarks(int quoteId)
        {
            DataTable dtQuoteremarks = _quote.GetSalesQuoteRemarks(quoteId);

            if (dtQuoteremarks.Rows.Count == 0)
            {
                throw new Exception("Error");
            }

            DocumentTemplateClass quoteRemark = new DocumentTemplateClass();
            DataRow dr = dtQuoteremarks.Rows[0];

            quoteRemark.DocId = quoteId;
            quoteRemark.DocNumber = dr["QuoteNumber"].ToString();
            quoteRemark.Remark1 = dr["Remark1"].ToString();
            quoteRemark.Remark2 = dr["Remark2"].ToString();

            return quoteRemark;
        }

        public List<QuoteLine> GetMainQuoteOrderLines(int quoteId)
        {
            DataTable dtLines = _quote.GetMainQuoteOrderLines(quoteId);

            List<QuoteLine> lstLine = new List<QuoteLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new QuoteLine();

                line.QuoteId = drLine["QuoteId"].ToInt();
                line.QuoteLineId = drLine["QuoteLineId"].ToInt();
                line.LineSeqId = drLine["lineSeqId"].ToInt();
                line.ParentId = drLine["ParentId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString();
                line.ItemCode = drLine["ItemCode"].ToString();
                line.DescriptionAs = drLine["DescriptionAs"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.UnitPrice = drLine["UnitPrice"].ToDecimal();
                line.Profit = drLine["Profit"].ToDecimal();
                line.Discount = drLine["Discount"].ToDecimal();
                line.NetPrice = drLine["NetPrice"].ToDecimal();
                line.TotalPrice = drLine["TotalPrice"].ToDecimal();

                lstLine.Add(line);
            }

            return lstLine;
        }

        public DataTable GetSalesQuotePivotView(int quoteId)
        {
            DataSet dsQuote = _quote.GetSalesQuotePivotView(quoteId);

            if (dsQuote.Tables.Count != 2)
            {
                DataTable dt = new DataTable();
                return dt;
            }

            DataTable dtColumnsName = dsQuote.Tables[0];
            DataTable dtLines = dsQuote.Tables[1];

            foreach (DataColumn col in dtLines.Columns)
            {
                int colName = col.ColumnName.ToInt();
                if (colName > 0)
                {
                    var newColName = (from m in dtColumnsName.AsEnumerable() where m.Field<int>("QuoteLineId").ToInt() == colName select m.Field<string>("DescriptionAs")).First();
                    col.ColumnName = newColName;
                }
            }

            return dtLines;
        }

        //public List<QuoteLine> GetSalesQuoteGroupView(int quoteId)
        //{

        //    DataTable dtLines = _quote.GetSalesQuoteGroupView(quoteId);

        //    List<QuoteLine> lstLine = new List<QuoteLine>();

        //    foreach (DataRow drLine in dtLines.Rows)
        //    {
        //        var line = new QuoteLine();

        //        line.ItemId = drLine["ItemId"].ToInt();
        //        line.PartNumber = drLine["PartNumber"].ToString();
        //        line.DescriptionAs = drLine["Description"].ToString();
        //        line.Quantity = drLine["Quantity"].ToDecimal(); ;
        //        line.NetPrice = drLine["NetPrice"].ToDecimal();
        //        line.TotalPrice = drLine["TotalPrice"].ToDecimal();

        //        lstLine.Add(line);
        //    }

        //    return lstLine;
        //}

        //public DataTable GetSalesQuoteGroupItemsQuantity(int quoteId)
        //{
        //    return _quote.GetSalesQuoteGroupItemsQuantity(quoteId);
        //}

        public DataTable GetSalesQuoteLinesQuantityCheck(int quoteId)
        {
            return _quote.GetSalesQuoteLinesQuantityCheck(quoteId);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesQuote(Quote quote, out string rMsg)
        {
            return _quote.CreateSalesQuote(quote, out rMsg);
        }

        public int CloneSalesQuote(int quoteId, out string rMsg)
        {
            return _quote.CloneSalesQuote(quoteId, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesQuoteHeader(Quote quote, out string rMsg)
        {
            return _quote.UpdateSalesQuoteHeader(quote, out rMsg);
        }

        public int UpdateSalesQuoteSummary(int quoteId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            return _quote.UpdateSalesQuoteSummary(quoteId, expenses, discount, tax, out rMsg);
        }

        public int PostSalesQuote(int quoteId, out string rMsg, out int rMessageId)
        {
            return _quote.PostSalesQuote(quoteId, out rMsg, out rMessageId);
        }

        public void UpdateSalesQuoteRemarks(DocumentTemplateClass quoteRemark, out string rMsg)
        {
            _quote.UpdateSalesQuoteRemarks(quoteRemark, out rMsg);
        }

        public int ReviseSalesQuote(int quoteId, out string rMsg)
        {
            return _quote.ReviseSalesQuote(quoteId, out rMsg);
        }

        public void CancelSalesQuote(int quoteId, out string rMsg)
        {
            _quote.CancelSalesQuote(quoteId, out rMsg);
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesQuote(int quoteId, out string rMsg, out int rMessageId)
        {
            _quote.DeleteSalesQuote(quoteId, out rMsg, out rMessageId);
        }

        //**************************************************************************************************************************//LINES
        public void CloneLines(QuoteLine line, out string rMsg)
        {
            _quote.CloneLines(line, out rMsg);
        }

        public int AddMainLine(QuoteLine line, out string rMsg)
        {
            return _quote.AddMainLine(line, out rMsg);
        }

        public void UpdateMainLine(QuoteLine line, out string rMsg)
        {
            _quote.UpdateMainLine(line, out rMsg);
        }

        public void DeleteMainLine(QuoteLine line, out string rMsg)
        {
            _quote.DeleteMainLine(line, out rMsg);
        }

        public int AddSubLine(QuoteLine line, out string rMsg)
        {
            return _quote.AddSubLine(line, out rMsg);
        }

        public void UpdateSubLine(QuoteLine line, out string rMsg)
        {
            _quote.UpdateSubLine(line, out rMsg);
        }

        public void ReplaceSubLine(QuoteLine line, out string rMsg)
        {
            _quote.ReplaceSubLine(line, out rMsg);
        }

        public void DeleteSubLine(QuoteLine line, out string rMsg)
        {
            _quote.DeleteSubLine(line, out rMsg);
        }

        public void MoveLineUp(QuoteLine line, out string rMsg)
        {
            _quote.MoveLineUp(line, out rMsg);
        }

        public void MoveLineDown(QuoteLine line, out string rMsg)
        {
            _quote.MoveLineDown(line, out rMsg);
        }

        public int AddGroupLine(QuoteLine line, out string rMsg)
        {
            return _quote.AddGroupLine(line, out rMsg);
        }

        public void UpdateGroupLine(QuoteLine line, out string rMsg)
        {
            _quote.UpdateGroupLine(line, out rMsg);
        }

        public void ReplaceGroupItem(QuoteLine oldLine, QuoteLine newLine, out string rMsg)
        {
            _quote.ReplaceGroupItem(oldLine, newLine, out rMsg);
        }

        public void DeleteGroupLine(QuoteLine line, out string rMsg)
        {
            _quote.DeleteGroupLine(line, out rMsg);
        }

        public void UpdateItemMargin(QuoteLine line, out string rMsg)
        {
            _quote.UpdateItemMargin(line, out rMsg);
        }

        public void UpdateEstimationView(QuoteLine line, out string rMsg)
        {
            _quote.UpdateEstimationView(line, out rMsg);
        }

        public void MoveLine(int quoteId, int movedItemId, int nextItemId, out string rMsg)
        {
            _quote.MoveLine(quoteId, movedItemId, nextItemId, out rMsg);
        }
        
        //**************************************************************************************************************************//REPORT     
    }
}