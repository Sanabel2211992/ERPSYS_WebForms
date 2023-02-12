using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class ProformaInvoiceDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetProformaInvoiceList(DateTime dateStart, DateTime dateEnd, string customerName, int invoiceStatusId, string itemSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@InvoiceStatusId", invoiceStatusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemSearch", itemSearch));

            return Dbhelper.ExecuteDataTable("SM_ProInvoice_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceHeader(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_ProInvoice_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceLines(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_ProInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceMainLines(int invoiceId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_ProInvoice_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceSubLine(int invoiceId, int invoiceLinesId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@InvoiceLineId", invoiceLinesId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_ProInvoice_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateProformaInvoice(ProformaInvoice invoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CustomerId", invoice.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProjectName", invoice.ProjectName));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Tax", invoice.Tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_ADD", paramCollection, CommandType.StoredProcedure);
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

        //**************************************************************************************************************************//UPDATE

        public int UpdateProformaInvoiceHeader(ProformaInvoice invoice, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoice.InvoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CustomerId", invoice.CustomerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProjectName", invoice.ProjectName));
            paramCollection.Add(new DBParameter("@InvoiceDate", invoice.InvoiceDate, DbType.Date));
            paramCollection.Add(new DBParameter("@Remarks", invoice.Remarks));
            paramCollection.Add(new DBParameter("@CurrencyId", UserSession.CurrencyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentMethodId", invoice.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentTermsId", invoice.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_Header_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("pro_invoice_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int UpdateProformaInvoiceSummary(int invoiceId, decimal expenses, decimal discount, decimal tax, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Expenses", expenses, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Discount", discount, DbType.Decimal));
            paramCollection.Add(new DBParameter("@Tax", tax, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_Summary_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("pro_invoice_update_inactive");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public void CancelProformaInvoice(int invoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_CANCEL", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("pro_invoice_cancel_failed");
                    rMsgId = 2;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

        }

      
        //**************************************************************************************************************************//DELETE

        public void DeleteProformaInvoice(int invoiceId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@InvoiceId", invoiceId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("pro_invoice_delete_failed");
                    rMsgId = 2;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddMainLine(ProformaInvoiceLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_MainLine_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_master_item_exist");
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

        public void UpdateMainLine(ProformaInvoiceLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_MainLine_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_update_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_master_item_exist");
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

        public void DeleteMainLine(ProformaInvoiceLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@InvoiceId", line.InvoiceId, DbType.Int32));
                paramCollection.Add(new DBParameter("@InvoiceLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_PorInvoice_MainLine_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_delete_failed_inactive");
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

        public int AddSubLine(ProformaInvoiceLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_SubLine_ADD", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_add_failed_inactive");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_sub_item_exist");
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

        public void UpdateSubLine(ProformaInvoiceLine line, out string rMsg)
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
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_SubLine_UPDATE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_update_failed_inactive");
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

        public void DeleteSubLine(ProformaInvoiceLine line, out string rMsg)
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

                IDbCommand command = Dbhelper.GetCommand("SM_ProInvoice_SubLine_DELETE", paramCollection, CommandType.StoredProcedure);
                command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("pro_invoice_item_delete_failed_inactive");
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