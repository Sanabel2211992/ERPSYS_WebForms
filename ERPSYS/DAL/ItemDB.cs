using System;
using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class ItemDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetCategoryList(string category, string subCategory)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Category", category));
            paramCollection.Add(new DBParameter("@SubCategory", subCategory));

            return Dbhelper.ExecuteDataTable("BASE_Item_Category_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetCategories()
        {
            return Dbhelper.ExecuteDataTable("BASE_Item_Categories_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCategoryDetails(int categoryId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_Category_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSubCategoryList(int parentCategoryId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@parentCategoryId", parentCategoryId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_Category_Sub_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSubCategoryDetails(int categoryId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_Category_Sub_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetBrandList(string brand)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Brand", brand));

            return Dbhelper.ExecuteDataTable("BASE_Item_BrandList_Get", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetTypeList()
        {
            return Dbhelper.ExecuteDataTable("BASE_Item_TypeList_Get", CommandType.StoredProcedure);
        }

        public DataSet GetItemLookupTables()
        {
            return Dbhelper.ExecuteDataSet("BASE_Item_Lookup_GET", CommandType.StoredProcedure);
        }

        public DataSet GetItemBomLookupTables()
        {
            return Dbhelper.ExecuteDataSet("BASE_Item_BOM_Lookup_GET", CommandType.StoredProcedure);
        }

        public DataTable GetItem(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_ItemDetails_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetManufactureItem(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_ManufactureItem_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemBom(int itemId, int bomTypeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomTypeId", bomTypeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_BOM_Lines_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId, bool isManufacture, bool isNonStandard)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsManufacture", isManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsNonStandard", isNonStandard, DbType.Boolean));

            return Dbhelper.ExecuteDataTable("BASE_Item_ItemList_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemBomList(string description, string itemCode, string partNumber, int categoryId, int brandId, bool isEmpty)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsEmpty", isEmpty, DbType.Boolean));

            return Dbhelper.ExecuteDataTable("BASE_Item_ItemBOM_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemBomLines(int itemId, int bomTypeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BomTypeId", bomTypeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_BOM_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemsNoBomList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Items_No_BOM_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemPriceList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", RegisteredUser.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_PriceList_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetBrand(int brandId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_Brand_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGroupCategories()
        {
            return Dbhelper.ExecuteDataTable("BASE_Item_GroupCategories_GET", CommandType.StoredProcedure);
        }

        public DataTable GetLatestItemList(string productSearch)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ProductSearch", productSearch));

            return Dbhelper.ExecuteDataTable("BASE_Item_LatestList_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//SELECT SEARCH DIALOG

        public DataTable GetBomItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));

            return Dbhelper.ExecuteDataTable("BASE_Item_BOM_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyOrderItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_AssemblyOrder_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProductionOrderRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_ProductionOrder_RM_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }
        
        public DataTable GetModificationOrderRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_ModificationOrder_RM_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMaterialTransferRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_MaterialTransfer_RM_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockTransferItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));

            return Dbhelper.ExecuteDataTable("BASE_Item_StockTransfer_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_GoodsReceipt_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseOrderItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_PurchaseOrder_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceItemDialog(string itemCode, string partNumber, string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));

            return Dbhelper.ExecuteDataTable("BASE_Item_PurchaseInvoice_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));

            return Dbhelper.ExecuteDataTable("BASE_Item_SalesOrder_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));

            return Dbhelper.ExecuteDataTable("BASE_Item_JobOrder_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderItemDialogBox(string itemCode, string partNumber, string description, int jobOrderId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@OrderId", jobOrderId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_JobOrder_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_SalesInvoice_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemCode", itemCode));
            paramCollection.Add(new DBParameter("@PartNumber", partNumber));
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly));

            return Dbhelper.ExecuteDataTable("BASE_Item_ProInvoice_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStoreItemQuantityDialog(int itemId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_Store_Quantity_Dialog_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//SELECT SEARCH BOX

        public DataTable GetPurchaseOrderItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_PurchaseOrder_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPurchaseInvoiceItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_PurchaseInvoice_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetGoodsReceiptItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_GoodsReceipt_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDeliveryReceiptItemSearchBox(string search, int locationId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));
            paramCollection.Add(new DBParameter("@locationId", locationId));

            return Dbhelper.ExecuteDataTable("BASE_Item_DeliveryReceiptSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_QuoteSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesQuoteItemSearchBoxByQuote(int quoteId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@QuoteId", quoteId));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_QuoteSearchBoxByQuote_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesOrderItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_SalesOrderSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSalesInvoiceItemSearchBox(int typeId, int categoryId,int brandId, bool showAvailableOnly,string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@AvailableOnly", showAvailableOnly, DbType.Boolean));
            paramCollection.Add(new DBParameter("@search", search));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Item_SalesInvoiceSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetJobOrderItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_JobOrderSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetProformaInvoiceItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_ProInvoiceSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetStockItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_StockSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetItemBomSearchBox2(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_BOMSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetRawMaterialItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_RawMaterialSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetMaterialTransferReturnItemSearchBox(int materialTransferId, string search)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@MaterialTransferId", materialTransferId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("MAN_MaterialTransfer_Return_RM_Item_SearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_AssemblySearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAssemblyItemMaterialSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_Assembly_MatrialSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationItemSearchBox(string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_ModificationSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationItemSearchBoxByJobOrder(int jobOrderId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@JobOrderId", jobOrderId));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_ModificationSearchBoxByJobOrder_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetModificationItemMaterialSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@TypeId", typeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@search", search));

            return Dbhelper.ExecuteDataTable("BASE_Item_Modification_MatrialSearchBox_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int AddItemAdvanced(Item item, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ItemCode", item.ItemCode));
            paramCollection.Add(new DBParameter("@AdditionalCode", item.AdditionalCode));
            paramCollection.Add(new DBParameter("@PartNumber", item.PartNumber));
            paramCollection.Add(new DBParameter("@Description", item.Description));
            paramCollection.Add(new DBParameter("@DescriptionAr", item.DescriptionAr));
            paramCollection.Add(new DBParameter("@DescriptionAs", item.DescriptionAs));
            paramCollection.Add(new DBParameter("@ItemTypeId", item.ItemTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", item.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", item.SubCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BarCode", item.BarCode));
            paramCollection.Add(new DBParameter("@UnitPrice", item.UnitPrice, DbType.Decimal));
            paramCollection.Add(new DBParameter("@MinPrice", item.MinimumPrice, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UomId", item.UomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", item.BrandId, DbType.Int32));

            paramCollection.Add(new DBParameter("@Data", item.ItemImage.ImageData, DbType.Binary));
            paramCollection.Add(new DBParameter("@FileType", item.ItemImage.ImageType));

            paramCollection.Add(new DBParameter("@Remarks", item.Remarks));
            paramCollection.Add(new DBParameter("@IsActive", item.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsNoneStandard", item.IsNonStandard, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsCanBeSold", item.IsCanBeSold, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsManufacture", item.IsManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasBOM", item.HasBom, DbType.Boolean));

            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Advanced_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public int CopyItem(Item item, bool bom, bool img, bool price, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ItemId", item.ItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemCode", item.ItemCode));
            paramCollection.Add(new DBParameter("@PartNumber", item.PartNumber));
            paramCollection.Add(new DBParameter("@Description", item.Description));
            paramCollection.Add(new DBParameter("@DescriptionAr", item.DescriptionAr));
            paramCollection.Add(new DBParameter("@DescriptionAs", item.DescriptionAs));

            paramCollection.Add(new DBParameter("@Bom", bom, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Img", img, DbType.Boolean));
            paramCollection.Add(new DBParameter("@Price", price, DbType.Boolean));

            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Copy", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return newId;
        }

        public void AddCategory(ItemCategory category, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Code", category.Code));
            paramCollection.Add(new DBParameter("@IsCanBeSold", category.IsCanBeSold, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsManufacture", category.IsManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("item_cat_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void AddSubCategory(ItemCategory category, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Code", category.Code));
            paramCollection.Add(new DBParameter("@ParentCategoryId", category.ParentCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_Sub_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("item_cat_sub_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void AddBrand(Brand brand, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", brand.Name));
            paramCollection.Add(new DBParameter("@Code", brand.Code));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Brand_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("brand_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateItemAdvanced(Item item, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ItemId", item.ItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemCode", item.ItemCode));
            paramCollection.Add(new DBParameter("@AdditionalCode", item.AdditionalCode));
            paramCollection.Add(new DBParameter("@PartNumber", item.PartNumber));
            paramCollection.Add(new DBParameter("@Description", item.Description));
            paramCollection.Add(new DBParameter("@DescriptionAr", item.DescriptionAr));
            paramCollection.Add(new DBParameter("@DescriptionAs", item.DescriptionAs));
            paramCollection.Add(new DBParameter("@ItemTypeId", item.ItemTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@CategoryId", item.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", item.SubCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BarCode", item.BarCode));
            paramCollection.Add(new DBParameter("@UnitPrice", item.UnitPrice, DbType.Decimal));
            paramCollection.Add(new DBParameter("@MinPrice", item.MinimumPrice, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UomId", item.UomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@BrandId", item.BrandId, DbType.Int32));

            paramCollection.Add(new DBParameter("@Data", item.ItemImage.ImageData, DbType.Binary));
            paramCollection.Add(new DBParameter("@FileType", item.ItemImage.ImageType));
            paramCollection.Add(new DBParameter("@IsUpdated", item.ItemImage.IsUpdated, DbType.Boolean));

            paramCollection.Add(new DBParameter("@Remarks", item.Remarks));
            paramCollection.Add(new DBParameter("@IsActive", item.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsNoneStandard", item.IsNonStandard, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsCanBeSold", item.IsCanBeSold, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsManufacture", item.IsManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasBOM", item.HasBom, DbType.Boolean));

            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Advanced_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_update_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateItemBulkSettings(int categoryId, int subCategoryId, bool updateSold, bool updateSoldValue, bool updateManufacture, bool updateManufactureValue, bool updateBom, bool updateBomValue, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@SubCategoryId", subCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UpdateSold", updateSold, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UpdateSoldValue", updateSoldValue, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UpdateManufacture", updateManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UpdateManufactureValue", updateManufactureValue, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UpdateBom", updateBom, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UpdateBomValue", updateBomValue, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Bulk_Setting_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_bulk_update_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateCategory(ItemCategory category, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", category.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Code", category.Code));
            paramCollection.Add(new DBParameter("@IsCanBeSold", category.IsCanBeSold, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsManufacture", category.IsManufacture, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("item_cat_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateSubCategory(ItemCategory category, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", category.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ParentCategoryId", category.ParentCategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", category.Name));
            paramCollection.Add(new DBParameter("@Code", category.Code));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_Sub_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("item_cat_sub_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public void UpdateBrand(Brand brand, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@BrandId", brand.BrandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", brand.Name));
            paramCollection.Add(new DBParameter("@Code", brand.Code));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Brand_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("brand_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void UpdateRawMaterialsBomCategories(string categories, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoriesIds", categories));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_RM_Category_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            if (errorId == -1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public int CloneItemBom(int itemId, string clonedItemsIds, int bomTypeId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@BomTypeId", bomTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ClonedItemsIds", clonedItemsIds));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_Clone", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_bom_clone_empty");
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("item_bom_m_clone_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        public int ReplaceItem(int itemOldId, int itemNewId, string remarks, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@OldItemId", itemOldId, DbType.Int32));
            paramCollection.Add(new DBParameter("@NewItemId", itemNewId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remarks", remarks));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Replace", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_replaced_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }

            return i;
        }

        //****************************************************************************************************************************//Delete

        public void DeleteItem(int itemId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_delete_failed");
                    break;

                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteCategory(int categoryId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_cat_has_item");
                    rMsgId = 4;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("item_cat_has_subcat");
                    rMsgId = 41;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteSubCategory(int categoryId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Category_Sub_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("item_cat_sub_delete_failed");
                    rMsgId = 499;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteBrand(int brandId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@BrandId", brandId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_Brand_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("brand_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteItemBomLines(int itemId, int bomTypeId, out string rMessage, out int rMsgId)
        {
            rMessage = string.Empty;

            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@BomTypeId", bomTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ItemId", itemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("item_bom_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //**************************************************************************************************************************//LINES

        public int AddBomLine(ItemBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            int newId = -1;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@BomTypeId", line.BomTypeId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_Line_ADD", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("item_bom_exists");
                        break;
                    case 2:
                        rMsg = GeneralResources.GetStringFromResources("item_bom_main_item_exists");
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

        public void UpdateBomLine(ItemBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@BomTypeId", line.BomTypeId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@Quantity", line.Quantity, DbType.Decimal));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_Line_UPDATE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("item_bom_not_exists");
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

        public void DeleteBomLine(ItemBomLine line, out string rMsg)
        {
            rMsg = string.Empty;
            try
            {
                var paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemId", line.ItemId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomLineId", line.LineId, DbType.Int32));
                paramCollection.Add(new DBParameter("@BomTypeId", line.BomTypeId, DbType.Int32));
                paramCollection.Add(new DBParameter("@ItemBomId", line.ItemBomId, DbType.Int32));
                paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
                paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

                IDbCommand command = Dbhelper.GetCommand("BASE_Item_BOM_Line_DELETE", paramCollection, CommandType.StoredProcedure);
                int i = command.ExecuteNonQuery();
                int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
                command.Dispose();

                switch (errorId)
                {
                    case 1:
                        rMsg = GeneralResources.GetStringFromResources("item_bom_not_exists");
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