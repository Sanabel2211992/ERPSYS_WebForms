using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class SalesInvoiceDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetSalesInvoiceList(DateTime dateStart, DateTime dateEnd, string customerName, string invoiceNumber, int invoiceStatusId, string itemSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@InvoiceNumber", invoiceNumber));
            paramCollection.Add(new DBParameter("@InvoiceStatusId", invoiceStatusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemSearch", itemSearch));
            paramCollection.Add(new DBParameter("@UserId", RegisteredUser.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceReportList(DateTime dateStart, DateTime dateEnd, int locationId, int paymentMethodId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", paymentMethodId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoiceReport_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public int GetSalesInvoiceId(string invoiceNumber)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceNumber", invoiceNumber));

            return Dbhelper.ExecuteScalar("SM_SalesInvoice_ID_GET", paramCollection, CommandType.StoredProcedure).ToInt();
        }

        public DataTable GetSalesInvoiceHeader(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", RegisteredUser.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceLines(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceMainLines(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceSubLine(int invoiceId, int invoiceLinesId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceLineId", invoiceLinesId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceLinesStoreQuantity(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_Lines_Store_Quantity_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceDeliveryReceipts(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_DeliveryReceipt_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceRefundLines(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_SalesInvoice_Lines_Refund_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateSalesInvoice(SalesInvoice invoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CustomerId", invoice.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", invoice.PurchaseOrder));
            paramCollection.Add(new DBParameter("@ProjectName", invoice.ProjectName));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyIdView", invoice.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Tax", invoice.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        public int CreateSalesInvoiceFromDeliveryReceiptNote(SalesInvoice invoice, int receiptId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyIdView", invoice.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubTotal", invoice.SubTotal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", invoice.Discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@IsPercentDiscount", invoice.IsPercentDiscount, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Tax", invoice.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Expenses", 0, DbType.Decimal));
            paramCollection.Add(new DBParameter("@GrandTotal", invoice.GrandTotal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_DeliveryReceipt_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateSalesInvoiceFromMultipleDeliveryReceiptNote(SalesInvoice invoice, string xmlLines, List<int> receiptsIdList, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyIdView", invoice.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ReceiptsId", String.Join(",", receiptsIdList.ToArray())));
            paramCollection.Add(new DBParameter("@XmlLines", xmlLines));
            paramCollection.Add(new DBParameter("@SubTotal", invoice.SubTotal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", invoice.Discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@IsPercentDiscount", invoice.IsPercentDiscount, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Tax", invoice.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Expenses", 0, DbType.Decimal));
            paramCollection.Add(new DBParameter("@GrandTotal", invoice.GrandTotal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_Multiple_DeliveryReceipt_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateSalesInvoiceFromProformaInvoice(SalesInvoice invoice, int proInvoiceId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProInvoiceId", proInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", invoice.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", invoice.PurchaseOrder));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_ProInvoice_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("pro_invoice_no_records");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateRefundWholeSalesInvoice(SalesInvoice invoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoice.InvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_Whole_Refund_POST", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_refund_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_refund_individual_before");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateRefundSalesInvoice(int mainInvoiceId, SalesInvoice invoice, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@MainInvoiceId", mainInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@XmlLines", xmlLines));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@Discount", invoice.Discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@IsPercentDiscount", invoice.IsPercentDiscount, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Expenses", invoice.Expenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_Refund_Post", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_refund_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_refund_insufficient_quantity");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CreateSalesInvoiceFromSalesQuotation(SalesInvoice invoice, int quoteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@QuoteId", quoteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_SalesQuote_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_create_from_quote_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_create_from_quote_failed");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_create_from_quote_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;
        }

        public int CloneSalesInvoice(int salesInvoiceId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", salesInvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_CLONE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_clone_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateSalesInvoiceHeader(SalesInvoice invoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoice.InvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", invoice.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PurchaseOrder", invoice.PurchaseOrder));
            paramCollection.Add(new DBParameter("@ProjectName", invoice.ProjectName));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@CurrencyIdView", invoice.CurrencyIdView, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@LocationId", invoice.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_update_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdateSalesInvoiceSummary(int invoiceId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Expenses", expenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Tax", tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_update_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostSalesInvoice(int invoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_post_inactive");
                    rMsgId = 5;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_no_records");
                    rMsgId = 6;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_group_empty");
                    rMsgId = 7;
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_insufficient_quantity");
                    rMsgId = 8;
                    break;
                case 5:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_has_job_order");
                    rMsgId = 10;
                    break;
                case 6:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    rMsgId = 13;
                    break;
                case 8:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_post_low_cost");
                    rMsgId = 14;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int PostSalesInvoiceAdvanced(int invoiceId, int invoiceSeq, DateTime invoiceDate, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ManualSet", true, DbType.Boolean));
            paramCollection.Add(new DBParameter("@XInvoiceNumber", invoiceSeq, DbType.Int32));
            paramCollection.Add(new DBParameter("@XInvocieDate", invoiceDate, DbType.DateTime));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_post_inactive");
                    rMsgId = 5;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_no_records");
                    rMsgId = 6;
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_group_empty");
                    rMsgId = 7;
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_insufficient_quantity");
                    rMsgId = 8;
                    break;
                case 5:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_has_job_order");
                    rMsgId = 10;
                    break;
                case 6:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_invalid_seq_number");
                    rMsgId = 11;
                    break;
                case 7:
                    rMsg = GeneralResources.GetStringFromResources("sm_si_number_exists");
                    rMsgId = 12;
                    break;
                case 8:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_post_low_cost");
                    rMsgId = 14;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteSalesInvoice(int invoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_delete_failed");
                    rMsgId = 2;
                    break;
                case 2:
                    rMsgId = 13;
                    rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
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
                paramCollection.Add(new DBParameter("@IsSpecialRecord", line.IsSpecialRecord, DbType.Boolean));
                paramCollection.Add(new DBParameter("@LocationId", line.LocationId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_MainLine_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_master_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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

        public void UpdateMainLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@InvoiceLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsSpecialRecord", line.IsSpecialRecord, DbType.Boolean));
                paramCollection.Add(new DBParameter("@LocationId", line.LocationId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_MainLine_Update", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_master_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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

        public void DeleteMainLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@InvoiceLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_MainLine_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_delete_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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

        public int AddSubLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
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
                paramCollection.Add(new DBParameter("@IsSpecialRecord", line.IsSpecialRecord, DbType.Boolean));
                paramCollection.Add(new DBParameter("@LocationId", line.LocationId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_SubLine_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_sub_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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

        public void UpdateSubLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@InvoiceLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Description", line.DescriptionAs));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UnitPrice", line.UnitPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Profit", line.Profit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@Discount", line.Discount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsPercentDiscount", line.IsPercentDiscount, DbType.Boolean));
                paramCollection.Add(new DBParameter("@NetPrice", line.NetPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalPrice", line.TotalPrice, DbType.Decimal));
                paramCollection.Add(new DBParameter("@IsSpecialRecord", line.IsSpecialRecord, DbType.Boolean));
                paramCollection.Add(new DBParameter("@LocationId", line.LocationId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_SubLine_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_sub_item_exist");
                        break;
                    case 3:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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

        public void DeleteSubLine(SalesInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ParentId", line.ParentId, DbType.Int32));
                paramCollection.Add(new DBParameter("@InvoiceLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_SalesInvoice_SubLine_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_item_delete_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission");
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