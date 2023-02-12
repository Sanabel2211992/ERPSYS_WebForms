using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class QuoteDB : CommonDB
    {
         //**************************************************************************************************************************//SELECT

        public DataTable GetSalesQuoteList(DateTime dateStart, DateTime dateEnd, string customerName, string quoteNumber, int quoteStatusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@QuoteNumber", quoteNumber));
            paramCollection.Add(new DBParameter("@QuoteStatusId", quoteStatusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteHeader(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetSalesQuote(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataSet("EST_SalesQuote_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteLines(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteMainLines(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteSubLine(int quoteId, int orderLineId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@QuoteLineId", orderLineId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteCompactLines(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_Compact_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        //public DataTable GetSalesQuoteMasterLinesStatus(int quoteId) // parent is null only
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

        //    return Dbhelper.ExecuteDataTable("EST_Quote_Lines_Master_Status_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataTable GetSalesQuoteLinesCombinedStatus(int quoteId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

        //    return Dbhelper.ExecuteDataTable("EST_Quote_Lines_Combined_Status_GET", paramCollection, CommandType.StoredProcedure);
        //}

        public DataTable GetSalesQuoteRemarks(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId));

            return Dbhelper.ExecuteDataTable("EST_SalesQuoteRemark_GET", paramCollection, CommandType.StoredProcedure); 
        }
        
        public DataTable GetMainQuoteOrderLines(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_OrderMainLines_GET", paramCollection, CommandType.StoredProcedure);
        }
     
        public DataSet GetSalesQuotePivotView(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId));

            return Dbhelper.ExecuteDataSet("EST_SalesQuote_PivotView_GET", paramCollection, CommandType.StoredProcedure);
        }

        //public DataTable GetSalesQuoteGroupView(int quoteId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@QuoteId", quoteId));

        //    return Dbhelper.ExecuteDataTable("EST_SalesQuote_GroupView_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataTable GetSalesQuoteGroupItemsQuantity(int quoteId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@QuoteId", quoteId));

        //    return Dbhelper.ExecuteDataTable("EST_SalesQuote_ItemsQuantity_GET", paramCollection, CommandType.StoredProcedure);
        //}

        public DataTable GetSalesQuoteLinesQuantityCheck(int quoteId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("EST_SalesQuote_Lines_QuantityCheck_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesQuote(Quote quote, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CustomerId", quote.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProjectName", quote.ProjectName));
            paramCollection.Add(new DBParameter("@QuoteDate", quote.QuoteDate, DbType.Date));
            paramCollection.Add(new DBParameter("@SalesEngineerId", quote.SalesEngineerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InquiryNumber", quote.InquiryNumber));
            paramCollection.Add(new DBParameter("@InquiryDate", quote.InquiryDate, DbType.Date));
            paramCollection.Add(new DBParameter("@CurrencyIdView", quote.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@CompanyIdView", quote.CompanyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", quote.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Tax", quote.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_ADD", paramCollection, CommandType.StoredProcedure);
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

        public int CloneSalesQuote(int quoteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_CLONE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_quote_clone_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesQuoteHeader(Quote quote, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quote.QuoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", quote.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProjectName", quote.ProjectName));
            paramCollection.Add(new DBParameter("@QuoteDate", quote.QuoteDate, DbType.Date));
            paramCollection.Add(new DBParameter("@SalesEngineerId", quote.SalesEngineerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InquiryNumber", quote.InquiryNumber));
            paramCollection.Add(new DBParameter("@InquiryDate", quote.InquiryDate, DbType.Date));
            paramCollection.Add(new DBParameter("@CurrencyIdView", quote.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@CompanyIdView", quote.CompanyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", quote.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdateSalesQuoteSummary(int quoteId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Expenses", expenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Tax", tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostSalesQuote(int quoteId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_no_records");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_group_empty");
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_add_joborder_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public void UpdateSalesQuoteRemarks(DocumentTemplateClass quoteRemark, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteRemark.DocId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remark1", quoteRemark.Remark1));
            paramCollection.Add(new DBParameter("@Remark2", quoteRemark.Remark2));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuoteRemark_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public int ReviseSalesQuote(int quoteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_REVISE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("sales_quote_revise_failed");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        public void CancelSalesQuote(int quoteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_CANCEL", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_quote_cancel_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesQuote(int quoteId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_quote_delete_failed");
                    rMsgId = 5;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int CloneLines(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();
                 
                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Lines_CLONE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_clone_failed_inactive");
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

        public int AddMainLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsRoundUp", line.IsRoundUp, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_MainLine_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_master_item_exist");
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
  
        public void UpdateMainLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsRoundUp", line.IsRoundUp, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_MainLine_Update", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId) 
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_master_item_exist");
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

        public void DeleteMainLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_MainLine_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_delete_failed_inactive");
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

        public int AddSubLine(QuoteLine line, out string rMsg) 
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_SubLine_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_sub_item_exist");
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

        public void UpdateSubLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_SubLine_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_sub_item_exist");
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

        public void ReplaceSubLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_SubLine_REPLACE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_sub_item_exist");
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

        public void DeleteSubLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId", line.QuoteLineId, DbType.Int32));
                //paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_SubLine_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_item_delete_failed_inactive");
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

        public void MoveLineUp(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId'", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineSeqId", line.LineSeqId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Lines_Move_UP", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_inactive");
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

        public void MoveLineDown(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@QuoteLineId'", line.QuoteLineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LineSeqId", line.LineSeqId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Lines_Move_DOWN", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_order_inactive");
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

        public int AddGroupLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", line.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_ItemGroup_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_add_failed_inactive");
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

        public void UpdateGroupLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_ItemGroup_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_update_failed_inactive");
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

        public void ReplaceGroupItem(QuoteLine oldLine, QuoteLine newLine, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", oldLine.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@OldItemId", oldLine.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", newLine.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemCode", newLine.ItemCode));
                paramCollection.Add(new DBParameter("@PartNumber", newLine.PartNumber));
                paramCollection.Add(new DBParameter("@Description", newLine.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", newLine.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", newLine.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", newLine.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", newLine.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", newLine.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", newLine.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", newLine.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_ItemGroup_Replace", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_replace_failed_inactive");
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

        public void DeleteGroupLine(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_ItemGroup_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_item_delete_failed_inactive");
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

        public void UpdateItemMargin(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Item_Margin_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_inactive");
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

        public void UpdateEstimationView(QuoteLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@QuoteId", line.QuoteId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemPartNumber", line.PartNumber));
                paramCollection.Add(new DBParameter("@GroupName", line.Description));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_EstimationView_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_quote_inactive");
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

        internal void MoveLine(int quoteId,int movedItemId, int nextItemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@MovedItemId", movedItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@NextItemId", nextItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("EST_SalesQuote_Line_Move", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_quote_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}