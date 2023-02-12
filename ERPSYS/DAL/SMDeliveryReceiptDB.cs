using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class DeliveryReceiptDB :CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetDeliveryReceiptList(DateTime dateStart, DateTime dateEnd, string customerName, string receiptNumber, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@CustomerName", customerName));
            paramCollection.Add(new DBParameter("@ReceiptNumber", receiptNumber));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCustomerDeliveryReceipts(int customerId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CustomerId", customerId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_List_Customer_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetNotBilledDeliveryReceipt()
        {
            return Dbhelper.ExecuteDataTable("SM_SalesOrder_NotBilled_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCustomersListNotBilledDeliveryReceipt()
        {
            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_NotBilled_Customer_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderNotBilledDeliveryReceipt(int customerId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CustomerId", customerId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_NotBilled_SalesOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetNotBilledDeliveryReceiptBySalesOrder(int customerId, int orderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CustomerId", customerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OrderId", orderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_NotBilled_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptHeader(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptLines(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptMainLines(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_MainLines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptSubLine(int receiptId, int receiptLineId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ReceiptLineId", receiptLineId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_SubLine_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptCompactLines(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Compact_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptLinesStoreQuantity(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Lines_Store_Quantity_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptSalesInvoiceLines(int receiptId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_SalesInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMultipleDeliveryReceiptHeader(int customerId, int orderId, List<int> receiptsIdList)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CustomerId", customerId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SalesOrderId", orderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ReceiptsId", String.Join(",",receiptsIdList.ToArray()), DbType.String));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Multiple_Header_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMultipleDeliveryReceiptSalesInvoiceLines(List<int> receiptsIdList)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptsId", String.Join(",", receiptsIdList.ToArray()), DbType.String));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Multiple_SalesInvoice_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMultipleDeliveryReceiptSalesInvoiceLinesX(List<int> receiptsIdList)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ReceiptsId", String.Join(",", receiptsIdList.ToArray()), DbType.String));

            return Dbhelper.ExecuteDataTable("SM_DeliveryReceipt_Multiple_SalesInvoice_Lines2_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int CreateDeliveryReceiptNoteFromSalesOrder(DeliveryReceipt deliveryReceipt, string xmlLines, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptDate", deliveryReceipt.ReceiptDate, DbType.Date));
            paramCollection.Add(new DBParameter("@LocationId", deliveryReceipt.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", deliveryReceipt.Remarks));
            paramCollection.Add(new DBParameter("@SalesOrderId", deliveryReceipt.SalesOrderId, DbType.Int32));
            paramCollection.Add(new DBParameter("@XMLLines", xmlLines));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_DeliveryReceipt_SalesOrder_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_add_failed");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_add_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int PostDeliveryReceipt(int receiptId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_DeliveryReceipt_POST", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_post_inactive");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("sales_order_post_inactive");
                    break;
                case 3:
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_no_records");
                    rMsgId = 5;
                    break;
                case 4:
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_insufficient_quantity");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //**************************************************************************************************************************//DELETE

        public void DeleteDeliveryReceipt(int receiptId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ReceiptId", receiptId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("SM_DeliveryReceipt_DELETE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsgId = 3;
                    rMsg = GeneralResources.GetStringFromResources("sm_dr_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public void UpdateDeliveryReceiptLine(DeliveryReceiptLine line, out string rMsg)   
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ReceiptId", line.ReceiptId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ReceiptLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@LocationId", line.LocationId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_DeliveryReceipt_Line_Adjust", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sm_dr_post_inactive");
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

        public void DeleteMainLine(DeliveryReceiptLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ReceiptId", line.ReceiptId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ReceiptLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("SM_DeliveryReceipt_MainLine_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("sm_dr_post_inactive");
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