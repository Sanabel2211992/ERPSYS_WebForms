using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class PurchaseDB : CommonDB
    {

        //**************************************************************************************************************************//SELECT
        //**************************************************************************************************************************//

        //public DataTable GetPurchaseOrderList(string supplierName, string orderNumber, int orderStatusId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@SupplierName", supplierName));
        //    paramCollection.Add(new DBParameter("@OrderNumber", orderNumber));
        //    paramCollection.Add(new DBParameter("@OrderStatusId", orderStatusId, DbType.Int32));

        //    return Dbhelper.ExecuteDataTable("PO_PurchaseOrder_List_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataSet GetPurchaseOrderReceived(int orderId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@orderId", orderId, DbType.Int32));

        //    return Dbhelper.ExecuteDataSet("PO_PurchaseOrder_Receive_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataSet GetPurchaseOrder(int orderId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@orderId", orderId, DbType.Int32));

        //    return Dbhelper.ExecuteDataSet("PO_PurchaseOrder_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataTable GetPurchaseOrderReportHeader(int orderId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@orderId", orderId, DbType.Int32));

        //    return Dbhelper.ExecuteDataTable("PO_PurchaseOrder_ReportHeader_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //public DataTable GetPurchaseOrderReportLine(int orderId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@orderId", orderId));

        //    return Dbhelper.ExecuteDataTable("PO_PurchaseOrder_ReportLine_GET", paramCollection, CommandType.StoredProcedure);
        //}

        //**************************************************************************************************************************//INSERT
        //**************************************************************************************************************************//

        //public int CreatePurchaseOrder(XPurchaseOrder purchaseOrder, out string rMsg)
        //{
        //    rMsg = string.Empty;
        //    var paramCollection = new DBParameterCollection();

        //    paramCollection.Add(new DBParameter("@SupplierOrderNumber", purchaseOrder.SupplierOrderNumber));
        //    paramCollection.Add(new DBParameter("@OrderDate", purchaseOrder.OrderDate));
        //    paramCollection.Add(new DBParameter("@SupplierId", purchaseOrder.SupplierId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@PaymentTermsId", purchaseOrder.PaymentTermsId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@ContactName", purchaseOrder.ContactName));
        //    paramCollection.Add(new DBParameter("@Phone", purchaseOrder.Phone));
        //    paramCollection.Add(new DBParameter("@SupplierAddress1", purchaseOrder.SupplierAddress1));
        //    paramCollection.Add(new DBParameter("@ShippingTermsId", purchaseOrder.ShippingTermsId));
        //    paramCollection.Add(new DBParameter("@ShipToAddress1", purchaseOrder.ShipToAddress1));
        //    paramCollection.Add(new DBParameter("@Remarks", purchaseOrder.OrderRemarks));
        //    paramCollection.Add(new DBParameter("@Discount", purchaseOrder.OrderDiscount, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@IsPercentDiscount", purchaseOrder.IsPercentDiscount, DbType.Boolean));
        //    paramCollection.Add(new DBParameter("@OrderSubTotal", purchaseOrder.OrderSubTotal, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@OrderTotal", purchaseOrder.OrderTotal, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@CurrencyId", purchaseOrder.CurrencyId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@OrderLines", purchaseOrder.OrderLinesXML));
        //    paramCollection.Add(new DBParameter("@UserId", UserSession.UserID, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
        //    paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

        //    IDbCommand command = Dbhelper.GetCommand("PO_PurchaseOrder_ADD", paramCollection, CommandType.StoredProcedure);
        //    int i = command.ExecuteNonQuery();
        //    int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() -2, command);
        //    int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
        //    command.Dispose();

        //    if (errorId == 1)
        //    {
        //        rMsg = GeneralResources.GetStringFromResources("po_add_failed");
        //    }
        //    else if (errorId > 1)
        //    {
        //        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
        //    }

        //    return newId;
        //}

        //**************************************************************************************************************************//UPDATE
        //**************************************************************************************************************************//

        //public int UpdatePurchaseOrder(XPurchaseOrder purchaseOrder, out string rMsg)
        //{
        //    rMsg = string.Empty;
        //    var paramCollection = new DBParameterCollection();

        //    paramCollection.Add(new DBParameter("@PurchaseOrderId", purchaseOrder.PurchaseOrderId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@SupplierOrderNumber", purchaseOrder.SupplierOrderNumber));
        //    paramCollection.Add(new DBParameter("@OrderDate", purchaseOrder.OrderDate));
        //    paramCollection.Add(new DBParameter("@SupplierId", purchaseOrder.SupplierId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@PaymentTermsId", purchaseOrder.PaymentTermsId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@ContactName", purchaseOrder.ContactName));
        //    paramCollection.Add(new DBParameter("@Phone", purchaseOrder.Phone));
        //    paramCollection.Add(new DBParameter("@SupplierAddress1", purchaseOrder.SupplierAddress1));
        //    paramCollection.Add(new DBParameter("@ShippingTermsId", purchaseOrder.ShippingTermsId));
        //    paramCollection.Add(new DBParameter("@ShipToAddress1", purchaseOrder.ShipToAddress1));
        //    paramCollection.Add(new DBParameter("@Remarks", purchaseOrder.OrderRemarks));
        //    paramCollection.Add(new DBParameter("@Discount", purchaseOrder.OrderDiscount, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@IsPercentDiscount", purchaseOrder.IsPercentDiscount, DbType.Boolean));
        //    paramCollection.Add(new DBParameter("@OrderSubTotal", purchaseOrder.OrderSubTotal, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@OrderTotal", purchaseOrder.OrderTotal, DbType.Decimal));
        //    paramCollection.Add(new DBParameter("@CurrencyId", purchaseOrder.CurrencyId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@OrderLines", purchaseOrder.OrderLinesXML));
        //    paramCollection.Add(new DBParameter("@UserId", UserSession.UserID, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

        //    IDbCommand command = Dbhelper.GetCommand("PO_PurchaseOrder_UPDATE", paramCollection, CommandType.StoredProcedure);
        //    int i = command.ExecuteNonQuery();
        //    int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
        //    command.Dispose();

        //    if (errorId == 1)
        //    {
        //        rMsg = GeneralResources.GetStringFromResources("po_update_failed");
        //    }
        //    else if (errorId > 1)
        //    {
        //        rMsg = GeneralResources.GetStringFromResources("error_not_defined");
        //    }

        //    return i;
        //}

        //**************************************************************************************************************************//DELETE
        //**************************************************************************************************************************//
    }
}