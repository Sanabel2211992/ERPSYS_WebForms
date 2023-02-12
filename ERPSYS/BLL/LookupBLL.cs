using System.Data;
using ERPSYS.DAL;

namespace ERPSYS.BLL
{
    public class LookupBLL
    {
        private readonly LookupDB _lookup = new LookupDB();

        public DataTable GetSystemCompanay()
        {
            return _lookup.GetSystemCompany();
        }

        public DataTable GetSystemCompanyCode()
        {
            return _lookup.GetSystemCompanyCode();
        }

        public DataTable GetRoleList()
        {
            return _lookup.GetRoleList();
        }

        public DataTable GetDepartmentList()
        {
            return _lookup.GetDepartmentList();
        }

        public DataTable GetDocumentTypes()
        {
            return _lookup.GetDocumentTypes();
        }

        public DataTable GetEmailSettings()
        {
            return _lookup.GetEmailSettings();
        }

        public DataSet GetItemPriceListLookup()
        {
            return _lookup.GetItemPriceListLookup();
        }

        public DataTable GetItemCategory()
        {
            // Allow To Sale Only
            return _lookup.GetItemCategory();
        }

        public DataTable GetItemBrand()
        {
            return _lookup.GetItemBrand();
        }

        public DataTable GetCurrency()
        {
            return _lookup.GetCurrency();
        }

        public DataTable GetLocation()
        {
            return _lookup.GetLocation();
        }

        public DataTable GetMaterialReceiptLocation()
        {
            return _lookup.GetMaterialReceiptLocation();
        }

        public DataTable GetPaymentTerms()
        {
            return _lookup.GetPaymentTerms();
        }

        public DataTable GetShippingTerms()
        {
            return _lookup.GetShippingTerms();
        }

        public DataTable GetGroupPermission()
        {
            return _lookup.GetGroupPermission();
        }

        public DataTable GetPaymentMethod()
        {
            return _lookup.GetPaymentMethod();
        }

        public DataTable GetUom()
        {
            return _lookup.GetUom();
        }

        public DataTable ContactType()
        {
            return _lookup.ContactType();
        }

        public DataTable GetItemManufactureCategory()
        {
            return _lookup.GetItemManufactureCategory();
        }

        public DataTable GetItemManufactureBrand()
        {
            return _lookup.GetItemManufactureBrand();
        }

        // ////////////////////////////////////////////////////// MAN ///////////////////////////////////////////////

        public DataTable GetAssemblyLocation()
        {
            return _lookup.GetAssemblyLocation();
        }

        public DataTable GetAssemblyOrderHeaderStatus()
        {
            return _lookup.GetAssemblyOrderHeaderStatus();
        }

        public DataTable GetModificationOrderTypes()
        {
            return _lookup.GetModificationOrderTypes();
        }

        public DataTable GetModificationLocation()
        {
            return _lookup.GetModificationLocation();
        }

        public DataTable GetModificationOrderHeaderStatus()
        {
            return _lookup.GetModificationOrderHeaderStatus();
        }

        // ////////////////////////////////////////////////////// ITEM ///////////////////////////////////////////////

        public DataTable GetItemBomTypes()
        {
            return _lookup.GetItemBomTypes();
        }

        // ////////////////////////////////////////////////////// INV ///////////////////////////////////////////////

        public DataTable GetTransferStoreLocation()
        {
            return _lookup.GetTransferStoreLocation();
        }

        public DataTable GetGoodsLocation()
        {
            return _lookup.GetGoodsLocation();
        }

        // ////////////////////////////////////////////////////// SCM ///////////////////////////////////////////////

        public DataTable GetPurchseOrderHeaderStatus()
        {
            return _lookup.GetPurchseOrderHeaderStatus();
        }

        public DataTable GetPurchseOrderItemStatus()
        {
            return _lookup.GetPurchseOrderItemStatus();
        }

        public DataTable GetGoodsReceiptHeaderStatus()
        {
            return _lookup.GetGoodsReceiptHeaderStatus();
        }

        public DataTable GetGoodsReceiptItemStatus()
        {
            return _lookup.GetGoodsReceiptItemStatus();
        }

        public DataTable GetGoodsReceiptLocation()
        {
            return _lookup.GetGoodsReceiptLocation();
        }

        public DataTable GetGoodsConsignedLocation()
        {
            return _lookup.GetGoodsConsignedLocation();
        }

        public DataTable GetPurchseInvoiceHeaderStatus()
        {
            return _lookup.GetPurchseInvoiceHeaderStatus();
        }

        public DataTable GetPurchaseInvoiceLocation()
        {
            return _lookup.GetPurchaseInvoiceLocation();
        }

        // ////////////////////////////////////////////////////// Sales ///////////////////////////////////////////////

        public DataTable GetSalesLocation()
        {
            return _lookup.GetSalesLocation();
        }

        public DataTable GetDeliveryReceiptLocation()
        {
            return _lookup.GetDeliveryReceiptLocation();
        }

        public DataTable GetSalesOrderHeaderStatus()
        {
            return _lookup.GetSalesOrderHeaderStatus();
        }

        public DataTable GetSalesOrderItemStatus()
        {
            return _lookup.GetSalesOrderItemStatus();
        }

        public DataTable GetJobOrderHeaderStatus()
        {
            return _lookup.GetJobOrderHeaderStatus();
        }

        public DataTable GetJobOrderItemStatus()
        {
            return _lookup.GetJobOrderItemStatus();
        }

        public DataTable GetSalesInvoiceHeaderStatus()
        {
            return _lookup.GetSalesInvoiceHeaderStatus();
        }

        public DataTable GetSalesInvoiceItemStatus()
        {
            return _lookup.GetSalesInvoiceItemStatus();
        }

        public DataTable GetDeliveryReceiptHeaderStatus()
        {
            return _lookup.GetDeliveryReceiptHeaderStatus();
        }

        public DataTable GetProductionOrderStatus()
        {
            return _lookup.GetProductionOrderStatus();
        }

        public DataTable GetProjectStatus()
        {
            return _lookup.GetProjectStatus();
        }

        // ////////////////////////////////////////////////////// Support Center ///////////////////////////////////////////////

        public DataTable GetTicketHeaderStatus()
        {
            return _lookup.GetTicketHeaderStatus();
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable GetKitTypes()
        {
            return _lookup.GetKitTypes();
        }

        public DataTable GetKitCategory()
        {
            return _lookup.GetKitCategory();
        }

        public DataTable GetPageCategory()
        {
            return _lookup.GetPageCategory();
        }

        public DataTable GetSalesQuoteStatus()
        {
            return _lookup.GetSalesQuoteStatus();
        }

        public DataTable GetSalesInvoiceStatus()
        {
            return _lookup.GetSalesInvoiceStatus();
        }

        public DataTable GetDeliveryReceiptTypes()
        {
            return _lookup.GetDeliveryReceiptTypes();
        }

        public DataTable GetJobOrderStatus()
        {
            return _lookup.GetJobOrderStatus();
        }

        public DataTable GetSalesEngineerList()
        {
            return _lookup.GetSalesEngineerList();
        }

        public DataTable GetSalesTransferStatus()
        {
            return _lookup.GetSalesTransferStatus();
        }

        public DataTable GetUsersList()
        {
            return _lookup.GetUsersList();
        }

        public DataTable GetCustomer()
        {
            return _lookup.GetCustomer();
        }

        public DataTable GetPageAccessType()
        {
            return _lookup.GetPageAccessType();
        }

        // ////////////////////////////////////////////////////// Quote ///////////////////////////////////////////////

        internal object GetSalesQuoteSHeaderStatus()
        {
            return _lookup.GetSalesQuoteSHeaderStatus();
        }

        // ///////////////////////////////////////////////////// Proforma ////////////////////////////////////////////
        public DataTable GetProInvoiceHeaderStatus()
        {
            return _lookup.GetProInvoiceHeaderStatus();
        }

        // ////////////////////////////////////////////////////  event log  ///////////////////////////////////////////

        public DataTable GetEventLogType()
        {
            return _lookup.GetEventLogType();
        }
    }
}