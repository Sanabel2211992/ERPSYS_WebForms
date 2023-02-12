using System.Collections.Generic;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ItemBLL
    {
        private readonly ItemDB _item = new ItemDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetCategoryList(string category, string subCategory)
        {
            return _item.GetCategoryList(category, subCategory);
        }

        public DataTable GetCategories()
        {
            return _item.GetCategories();
        }

        public DataTable GetSubCategoryList(int parentCategoryId)
        {
            return _item.GetSubCategoryList(parentCategoryId);
        }

        public DataTable GetBrandList(string brand)
        {
            return _item.GetBrandList(brand);
        }

        public DataTable GetTypeList()
        {
            return _item.GetTypeList();
        }

        public DataSet GetItemLookupTables()
        {
            return _item.GetItemLookupTables();
        }

        public DataSet GetItemBomLookupTables()
        {
            return _item.GetItemBomLookupTables();
        }

        public Item GetItem(int itemId)
        {
            DataTable dt = _item.GetItem(itemId);

            Item item = new Item();

            if (dt.Rows.Count == 0)
            {
                item.ItemId = -1;
                return item;
            }

            DataRow dr = dt.Rows[0];

            item.ItemId = itemId;

            item.ItemCode = dr["ItemCode"].ToString();
            item.AdditionalCode = dr["AdditionalCode"].ToString();
            item.PartNumber = dr["PartNumber"].ToString();
            item.Description = dr["Description"].ToString();
            item.DescriptionAr = dr["DescriptionAr"].ToString();
            item.DescriptionAs = dr["DescriptionAs"].ToString();
            item.ItemTypeId = dr["ItemTypeId"].ToInt();
            item.ItemType = dr["ItemType"].ToString();
            item.CategoryId = dr["CategoryId"].ToInt();
            item.Category = dr["Category"].ToString();
            item.SubCategoryId = dr["SubCategoryId"].ToInt();
            item.SubCategory = dr["SubCategory"].ToString();
            item.BarCode = dr["BarCode"].ToString();
            item.UnitPrice = dr["SellingPrice"].ToDecimal();
            item.MinimumPrice = dr["MinimumPrice"].ToDecimal();
            item.UomId = dr["UomId"].ToInt();
            item.Uom = dr["Uom"].ToString();
            item.StorageUomId = dr["StorageUomId"].ToInt();
            item.PurchaseUomId = dr["PurchaseUomId"].ToInt();
            item.BrandId = dr["BrandId"].ToInt();
            item.Brand = dr["Brand"].ToString();
            item.Remarks = dr["Remarks"].ToString();

            item.HasBom = dr["HasBOM"].ToBool();
            item.IsActive = dr["IsActive"].ToBool();
            item.IsCanBeSold = dr["IsCanBeSold"].ToBool();
            item.IsManufacture = dr["IsManufacture"].ToBool();
            item.IsNonStandard = dr["IsNoneStandard"].ToBool();
            item.IsNonStandard = dr["IsNoneStandard"].ToBool();

            FileImage itemImage = new FileImage();
            itemImage.ImageData = dr["Data"].ToBytes();
            itemImage.ImageType = dr["FileType"].ToString();
            item.ItemImage = itemImage;

            return item;
        }

        public Item GetManufactureItem(int itemId)
        {
            DataTable dt = _item.GetManufactureItem(itemId);

            Item item = new Item();

            if (dt.Rows.Count == 0)
            {
                item.ItemId = -1;
                return item;
            }

            DataRow dr = dt.Rows[0];

            item.ItemId = itemId;
            item.ItemCode = dr["ItemCode"].ToString();
            item.PartNumber = dr["PartNumber"].ToString();
            item.Description = dr["Description"].ToString();
            item.DescriptionAr = dr["DescriptionAr"].ToString();
            item.DescriptionAs = dr["DescriptionAs"].ToString();
            item.Category = dr["Category"].ToString();
            item.SubCategory = dr["SubCategory"].ToString();
            item.BarCode = dr["BarCode"].ToString();
            item.UnitPrice = dr["SellingPrice"].ToDecimal();
            item.Uom = dr["Uom"].ToString();
            item.Brand = dr["Brand"].ToString();

            item.IsActive = dr["IsActive"].ToBool();
            item.IsCanBeSold = dr["IsCanBeSold"].ToBool();
            item.IsManufacture = dr["IsManufacture"].ToBool();
            item.IsNonStandard = dr["IsNoneStandard"].ToBool();

            FileImage itemImage = new FileImage();
            itemImage.ImageData = dr["Data"].ToBytes();
            itemImage.ImageType = dr["FileType"].ToString();
            item.ItemImage = itemImage;

            return item;
        }

        public List<ItemBomLine> GetItemBom(int itemId, int bomTypeId)
        {
            DataTable dtLines = _item.GetItemBom(itemId, bomTypeId);

            List<ItemBomLine> lstLines = new List<ItemBomLine>();

            foreach (DataRow drLine in dtLines.Rows)
            {
                var line = new ItemBomLine();

                line.LineId = drLine["ItemBomLineId"].ToInt();
                line.ItemId = drLine["ItemId"].ToInt();
                line.ItemBomId = drLine["ItemBomId"].ToInt();
                line.PartNumber = drLine["PartNumber"].ToString().ReplaceWhenNullOrEmpty("-");
                line.ItemCode = drLine["ItemCode"].ToString().ReplaceWhenNullOrEmpty("-");
                line.Description = drLine["Description"].ToString();
                line.Uom = drLine["Uom"].ToString();
                line.Brand = drLine["Brand"].ToString();
                line.Quantity = drLine["Quantity"].ToDecimal();
                line.SellingPrice = drLine["SellingPrice"].ToDecimal();
                line.Category = drLine["Category"].ToString().ReplaceWhenNullOrEmpty("-");
                line.SubCategory = drLine["SubCategory"].ToString().ReplaceWhenNullOrEmpty("-");

                lstLines.Add(line);
            }

            return lstLines;
        }

        public DataTable GetItemList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId, bool isManufacture, bool isNonStandard)
        {
            return _item.GetItemList(description, itemCode, partNumber, typeId, categoryId, brandId, isManufacture, isNonStandard);
        }

        public DataTable GetItemBomList(string description, string itemCode, string partNumber, int categoryId, int brandId, bool isEmpty)
        {
            return _item.GetItemBomList(description, itemCode, partNumber, categoryId, brandId, isEmpty);
        }

        public DataTable GetItemBomLines(int itemId, int bomTypeId)
        {
            return _item.GetItemBomLines(itemId, bomTypeId);
        }

        public DataTable GetItemsNoBomList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId)
        {
            return _item.GetItemsNoBomList(description, itemCode, partNumber, typeId, categoryId, brandId);
        }

        public DataTable GetItemPriceList(string description, string itemCode, string partNumber, int typeId, int categoryId, int brandId, bool showAvailableOnly)
        {
            return _item.GetItemPriceList(description, itemCode, partNumber, typeId, categoryId, brandId, showAvailableOnly);
        }

        public ItemCategory GetCategoryDetails(int categoryId)
        {
            DataTable dt = _item.GetCategoryDetails(categoryId);

            ItemCategory category = new ItemCategory();

            if (dt.Rows.Count == 0)
            {
                category.CategoryId = -1;
                return category;
            }

            DataRow dr = dt.Rows[0];

            category.CategoryId = categoryId;
            category.Name = dr["Name"].ToString();
            category.Code = dr["Code"].ToString();
            category.IsCanBeSold = dr["IsCanBeSold"].ToBool();
            category.IsManufacture = dr["IsManufacture"].ToBool();

            return category;
        }

        public ItemCategory GetSubCategoryDetails(int categoryId)
        {
            DataTable dt = _item.GetSubCategoryDetails(categoryId);

            ItemCategory category = new ItemCategory();

            if (dt.Rows.Count == 0)
            {
                category.CategoryId = -1;
                return category;
            }

            DataRow dr = dt.Rows[0];

            category.CategoryId = categoryId;
            category.ParentCategoryId = dr["ParentCategoryId"].ToInt();
            category.ParentCategory = dr["ParentCategory"].ToString();
            category.CategoryId = categoryId;
            category.Name = dr["Name"].ToString();
            category.Code = dr["Code"].ToString();

            return category;
        }

        public Brand GetBrand(int brandId)
        {
            DataTable dt = _item.GetBrand(brandId);

            Brand brand = new Brand();

            if (dt.Rows.Count == 0)
            {
                brand.BrandId = -1;
                return brand;
            }

            DataRow dr = dt.Rows[0];

            brand.BrandId = brandId;
            brand.Name = dr["Name"].ToString();
            brand.Code = dr["Code"].ToString();

            return brand;
        }

        public List<ItemCategory> GetGroupCategories()
        {
            DataTable dt = _item.GetGroupCategories();

            List<ItemCategory> lstLines = new List<ItemCategory>();

            foreach (DataRow dr in dt.Rows)
            {
                var cat = new ItemCategory();

                cat.CategoryId = dr["CategoryId"].ToInt();

                lstLines.Add(cat);
            }

            return lstLines;
        }

        public DataTable GetLatestItemList(string productSearch)
         {
             return _item.GetLatestItemList(productSearch);
         }

        //**************************************************************************************************************************//SELECT SEARCH DIALOG

        public DataTable GetBomItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetBomItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetAssemblyOrderItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetAssemblyOrderItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetProductionOrderRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetProductionOrderRawMaterialItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetModificationOrderRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetModificationOrderRawMaterialItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetMaterialTransferRawMaterialItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetMaterialTransferRawMaterialItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetStockTransferItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetStockTransferItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetGoodsReceiptItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetGoodsReceiptItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetPurchaseOrderItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetPurchaseOrderItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetPurchaseInvoiceItemDialog(string itemCode, string partNumber, string description)
        {
            return _item.GetPurchaseInvoiceItemDialog(itemCode, partNumber, description);
        }

        public DataTable GetSalesOrderItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetSalesOrderItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetJobOrderItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetJobOrderItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetJobOrderItemDialogBox(string itemCode, string partNumber, string description, int jobOrderId)
        {
            return _item.GetJobOrderItemDialogBox(itemCode, partNumber, description, jobOrderId);
        }

        public DataTable GetSalesInvoiceItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetSalesInvoiceItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetProformaInvoiceItemDialog(string itemCode, string partNumber, string description, bool showAvailableOnly)
        {
            return _item.GetProformaInvoiceItemDialog(itemCode, partNumber, description, showAvailableOnly);
        }

        public DataTable GetStoreItemQuantityDialog(int itemId)
        {
            return _item.GetStoreItemQuantityDialog(itemId);
        }

        //**************************************************************************************************************************//SELECT SEARCH BOX
     
        public DataTable GetPurchaseOrderItemSearchBox(string search)
        {
            return _item.GetPurchaseOrderItemSearchBox(search);
        }

        public DataTable GetPurchaseInvoiceItemSearchBox(string search)
        {
            return _item.GetPurchaseInvoiceItemSearchBox(search);
        }

        public DataTable GetGoodsReceiptItemSearchBox(string search)
        {
            return _item.GetGoodsReceiptItemSearchBox(search);
        }

        public DataTable GetDeliveryReceiptItemSearchBox(string search, int locationId)
        {
            return _item.GetDeliveryReceiptItemSearchBox(search, locationId);
        }

        public DataTable GetSalesQuoteItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetSalesQuoteItemSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetSalesQuoteItemSearchBoxByQuote(int quoteId, string search)
        {
            return _item.GetSalesQuoteItemSearchBoxByQuote(quoteId, search);
        }
  
        public DataTable GetSalesOrderItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetSalesOrderItemSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetSalesInvoiceItemSearchBox(int typeId, int categoryId,int brandId, bool showAvailableOnly,string search)
        {
            return _item.GetSalesInvoiceItemSearchBox(typeId, categoryId, brandId, showAvailableOnly, search);
        }

        public DataTable GetJobOrderItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetJobOrderItemSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetProformaInvoiceItemSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetProformaInvoiceItemSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetStockItemSearchBox(string search)
        {
            return _item.GetStockItemSearchBox(search);
        }

        public DataTable GetItemBomSearchBox2(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetItemBomSearchBox2(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetRawMaterialItemSearchBox(string search)
        {
            return _item.GetRawMaterialItemSearchBox(search);
        }

        public DataTable GetMaterialTransferReturnItemSearchBox(int materialTransferId, string search)
        {
            return _item.GetMaterialTransferReturnItemSearchBox(materialTransferId, search);
        }

        public DataTable GetAssemblyItemSearchBox(string search)
        {
            return _item.GetAssemblyItemSearchBox(search);
        }

        public DataTable GetAssemblyItemMaterialSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetAssemblyItemMaterialSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        public DataTable GetModificationItemSearchBox(string search)
        {
            return _item.GetModificationItemSearchBox(search);
        }

        public DataTable GetModificationItemSearchBoxByJobOrder(int jobOrderId, string search)
        {
            return _item.GetModificationItemSearchBoxByJobOrder(jobOrderId, search);
        }

        public DataTable GetModificationItemMaterialSearchBox(int typeId, int categoryId, int subCategoryId, int brandId, string search)
        {
            return _item.GetModificationItemMaterialSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        //**************************************************************************************************************************//INSERT

        public int AddItemAdvanced(Item item, out string rMsg)
        {
            return _item.AddItemAdvanced(item, out rMsg);
        }

        public int CopyItem(Item item, bool bom, bool img, bool price, out string rMsg)
        {
            return _item.CopyItem(item, bom, img, price, out rMsg);
        }

        internal void AddCategory(ItemCategory category, out string rMessage)
        {
            _item.AddCategory(category, out rMessage);
        }

        internal void AddSubCategory(ItemCategory category, out string rMessage)
        {
            _item.AddSubCategory(category, out rMessage);
        }

        internal void AddBrand(Brand brand, out string rMessage)
        {
            _item.AddBrand(brand, out rMessage);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateItemAdvanced(Item item, out string rMsg)
        {
            return _item.UpdateItemAdvanced(item, out rMsg);
        }

        public void UpdateItemBulkSettings(int categoryId, int subCategoryId, bool updateSold, bool updateSoldValue, bool updateManufacture, bool updateManufactureValue, bool updateBom, bool updateBomValue, out string rMessage)
        {
            _item.UpdateItemBulkSettings( categoryId,  subCategoryId,updateSold, updateSoldValue, updateManufacture, updateManufactureValue, updateBom, updateBomValue, out rMessage);
        }

        public int UpdateCategory(ItemCategory category, out string rMsg)
        {
            return _item.UpdateCategory(category, out rMsg);
        }

        public int UpdateSubCategory(ItemCategory category, out string rMsg)
        {
            return _item.UpdateSubCategory(category, out rMsg);
        }

        public void UpdateBrand(Brand brand, out string rMessage)
        {
            _item.UpdateBrand(brand, out rMessage);
        }

        public void UpdateRawMaterialsBomCategories(string categories, out string rMessage)
        {
            _item.UpdateRawMaterialsBomCategories(categories, out rMessage);
        }

        public void CloneItemBom(int itemId, string clonedItemsIds, int bomTypeId, out string rMsg)
        {
            _item.CloneItemBom(itemId, clonedItemsIds, bomTypeId, out rMsg);
        }

        public int ReplaceItem(int itemOldId, int itemNewId, string remarks, out string rMsg)
        {
            return _item.ReplaceItem(itemOldId, itemNewId, remarks, out rMsg);
        }

        //************************************************************************************************************************//DELETE

        public void DeleteItem(int itemId, out string rMessage, out int rMessageId)
        {
            _item.DeleteItem(itemId, out rMessage, out rMessageId);
        }

        public void DeleteCategory(int categoryId, out string rMsg, out int rMessageId)
        {
            _item.DeleteCategory(categoryId, out rMsg, out rMessageId);
        }

        public void DeleteSubCategory(int categoryId, out string rMsg, out int rMessageId)
        {
            _item.DeleteSubCategory(categoryId, out rMsg, out rMessageId);
        }

        public void DeleteBrand(int brandId, out string rMessage, out int rMessageId)
        {
            _item.DeleteBrand(brandId, out rMessage, out rMessageId);
        }

        public void DeleteItemBomLines(int itemId, int bomTypeId, out string rMessage, out int rMessageId)
        {
            _item.DeleteItemBomLines(itemId, bomTypeId, out rMessage, out rMessageId);
        }

        //*************************************************************************************************************************//LINES

        public int AddBomLine(ItemBomLine line, out string rMsg)
        {
            return _item.AddBomLine(line, out rMsg);
        }

        public void UpdateBomLine(ItemBomLine line, out string rMsg)
        {
            _item.UpdateBomLine(line, out rMsg);
        }

        public void DeleteBomLine(ItemBomLine line, out string rMsg)
        {
            _item.DeleteBomLine(line, out rMsg);
        }
    }
}