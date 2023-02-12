using DAL;
using ERPSYS.BLL;
using System.Data;

namespace ERPSYS.DAL
{
    public class LookupDB : CommonDB
    {
        public DataTable GetSystemCompany()
        {
            return Dbhelper.ExecuteDataTable("LU_SystemCompany_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSystemCompanyCode()
        {
            return Dbhelper.ExecuteDataTable("LU_SystemCompanyCode_GET", CommandType.StoredProcedure);
        }

        public DataTable GetRoleList()
        {
            return Dbhelper.ExecuteDataTable("LU_Role_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDepartmentList()
        {
            return Dbhelper.ExecuteDataTable("LU_Department_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDocumentTypes()
        {
            return Dbhelper.ExecuteDataTable("LU_DocumentTypes_GET", CommandType.StoredProcedure);
        }

        public DataTable GetEmailSettings()
        {
            return Dbhelper.ExecuteDataTable("LU_Mail_Settings_GET", CommandType.StoredProcedure);
        }

        public DataSet GetItemPriceListLookup()
        {
            return Dbhelper.ExecuteDataSet("LU_Item_PriceList_Lookup_GET", CommandType.StoredProcedure);
        }

        public DataTable GetItemCategory()
        {
            return Dbhelper.ExecuteDataTable("LU_ItemCategory_GET", CommandType.StoredProcedure);
        }

        public DataTable GetItemBrand()
        {
            return Dbhelper.ExecuteDataTable("LU_ItemBrand_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCurrency()
        {
            return Dbhelper.ExecuteDataTable("LU_Currency_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGRNLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_Location_GRN_GET", CommandType.StoredProcedure);
        }

        public DataTable GetLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetMaterialReceiptLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_MaterialReceipt_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPaymentTerms()
        {
            return Dbhelper.ExecuteDataTable("LU_PaymentTerms_GET", CommandType.StoredProcedure);
        }

        public DataTable GetShippingTerms()
        {
            return Dbhelper.ExecuteDataTable("LU_ShippingTerms_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGroupPermission()
        {
            return Dbhelper.ExecuteDataTable("LU_GroupPermission_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPaymentMethod()
        {
            return Dbhelper.ExecuteDataTable("LU_PaymentMethod_GET", CommandType.StoredProcedure);
        }

        public DataTable GetUom()
        {
            return Dbhelper.ExecuteDataTable("LU_Uom_GET", CommandType.StoredProcedure);
        }

        public DataTable ContactType()
        {
            return Dbhelper.ExecuteDataTable("CRM_Contact_Type_GET", CommandType.StoredProcedure);
        }

        public DataTable GetItemManufactureCategory()
        {
            return Dbhelper.ExecuteDataTable("LU_ItemManufactureCategory_GET", CommandType.StoredProcedure);
        }

        public DataTable GetItemManufactureBrand()
        {
            return Dbhelper.ExecuteDataTable("LU_ItemManufactureBrand_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// MAN ///////////////////////////////////////////////

        public DataTable GetAssemblyLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_Assembly_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_Assembly_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetModificationOrderTypes()
        {
            return Dbhelper.ExecuteDataTable("LU_ModificationOrder_Type_GET", CommandType.StoredProcedure);
        }

        public DataTable GetModificationLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_Modification_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetModificationOrderHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_Modification_Header_Status_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// ITEM ///////////////////////////////////////////////

        public DataTable GetItemBomTypes()
        {
            return Dbhelper.ExecuteDataTable("LU_BOMTypes_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// INV ///////////////////////////////////////////////

        public DataTable GetTransferStoreLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_TransferStore_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_Goods_Location_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// SCM ///////////////////////////////////////////////

        public DataTable GetPurchseOrderHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_PurchaseOrder_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPurchseOrderItemStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_PurchaseOrder_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_GoodsReceipt_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptItemStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_GoodsReceipt_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_GoodsReceipt_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGoodsConsignedLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_GoodsConsigned_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPurchseInvoiceHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_PurchaseInvoice_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_PurchaseInvoice_Location_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// Sales ///////////////////////////////////////////////

        public DataTable GetSalesLocation()
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("LU_Sales_Location_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptLocation()
        {
            return Dbhelper.ExecuteDataTable("LU_DeliveryReceipt_Location_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesOrder_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderItemStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesOrder_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_JobOrder_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderItemStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_JobOrder_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesInvoice_Header_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceItemStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesInvoice_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_DeliveryReceipt_Item_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_ProductionOrder_Status_GET", CommandType.StoredProcedure);
        }

        public DataTable GetProjectStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_Project_Status_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// Support Center ///////////////////////////////////////////////

        public DataTable GetTicketHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SupportTicket_Header_Status_GET", CommandType.StoredProcedure);
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable GetKitTypes()
        {
            return Dbhelper.ExecuteDataTable("LU_KitTypes_GET", CommandType.StoredProcedure);
        }

        public DataTable GetKitCategory()
        {
            return Dbhelper.ExecuteDataTable("LU_KitCategory_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPageCategory()
        {
            return Dbhelper.ExecuteDataTable("LU_PageCategory_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesQuoteStatus_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesInvoiceStatus_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptTypes()
        {
            return Dbhelper.ExecuteDataTable("LU_DeliveryReceiptTypes_GET", CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_JobOrderStatus_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesEngineerList()
        {
            return Dbhelper.ExecuteDataTable("LU_SalesEngineer_GET", CommandType.StoredProcedure);
        }

        public DataTable GetSalesTransferStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_TransferStatus_GET", CommandType.StoredProcedure);
        }

        public DataTable GetUsersList()
        {
            return Dbhelper.ExecuteDataTable("LU_Users_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCustomer()
        {
            return Dbhelper.ExecuteDataTable("CRM_Customer_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPageAccessType()
        {
            return Dbhelper.ExecuteDataTable("LU_PageAccessType_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////// Quote ///////////////////////////////////////////////

        internal object GetSalesQuoteSHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("EST_SalesQuote_Header_Status_GET", CommandType.StoredProcedure);
        }

        // ///////////////////////////////////////////////////// Proforma ////////////////////////////////////////////

        public DataTable GetProInvoiceHeaderStatus()
        {
            return Dbhelper.ExecuteDataTable("LU_ProInvoice_Header_Status_GET", CommandType.StoredProcedure);
        }

        // ////////////////////////////////////////////////////  event log  ///////////////////////////////////////////

        public DataTable GetEventLogType()
        {
            return Dbhelper.ExecuteDataTable("LU_EventLogType_GET", CommandType.StoredProcedure);
        }
    }
}