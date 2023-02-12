using System;
using System.Collections;
using System.Collections.Generic;
using ERPSYS.BLL;

namespace ERPSYS.Members
{
    public static class CommonMember
    {
        public static string AttachmentUploadTempFolderPath = "~/Files/TempUpload/";
        public static string AttachmentUploadProjectFolderPath = "~/Files/Project/";
        public static string AttachmentUploadFolderPath = "~/Files/Attachment/Upload/";
        public static string AttachmentUploadFolderPathTicket = "../../Files/Attachment/Ticket/";
        public static string AttachmentEmailUploadFolderPath = "~/Files/Attachment/Email/";
        public static string AttachmentSystemFolderPath = "~/Files/Attachment/System/";
        public static string SystemPrintFolderPath = "~/Files/System/Print/";
        public static string SystemProfilePictrureCachePath = "~/Files/System/Profile/PictureCache/";
        public static string SystemProfilePictrureSmallCachePath = "~/Files/System/Profile/SPictureCache/";
        public static string TrashFolderPath = "~/Files/Trash/";
        public static string TrashEmailFolderPath = "~/Files/Trash/Email/";

        public static string DefaultDateFormat = "dd/MM/yyyy";
        public static int GridPageSize = 50;

        public static string[] AllowedExtenstionsProfilePicture = { ".png", ".jpg", ".jpeg" };
        public static decimal MaxFileSizeProfilePicture = 500;// (2000 / (decimal)1024); // MB -> xxx * 1024

        public static decimal MaxUploadFileSizeMb = 25; // MB

        public static string EditorCSSFilePath = "~/ERP/resources/css/editor/editor.css";
        public static string EditorToolBarFilePath = "~/ERP/resources/xml/editor/toolbar.xml";
        public static string EditMiniToolBarFilePath = "~/ERP/resources/xml/editor/toolbar-mini.xml";
    }

    #region Company Profile Structure...

    public struct CompanyProfile
    {
        public int CompanyId { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string WebSite { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Country { set; get; }
        public string PostalCode { set; get; }
        public string TaxNumber { set; get; }
        public FileAttachmentTypes PictureFileAttachmentType { set; get; }
        public int PictureFileAttachmentId { set; get; }
        public string PictureFileAttachmentName { set; get; }
        public byte[] PictureFileAttachmentData { set; get; }
    }

    public struct SystemSettings
    {
        public int CompanyId { set; get; }
        public bool EnableSalesTax { set; get; }
        public decimal SalesTaxValue { set; get; }
        public bool ShowSalesInvoicePrintTemplate { set; get; }
        public bool ShowProInvoicePrintTemplate { set; get; }
        public bool ShowDeliveryReceiptPrintTemplate { set; get; }
        public bool ShowWatermarkInReports { set; get; }
        public bool HidePOQuantityInMR { set; get; }
        public bool AddExpensesValueToTotal { set; get; }
        public bool CreateJobOrderWhenSalesOrderPost { set; get; }
        public bool CreateJobOrderWhenSalesInvoicePost { set; get; }
        public bool SetSalesInvoiceReferenceManually { set; get; }
        public bool ShowOnlyRetailUserLocationInvoices { set; get; }
        public int MinPasswordLength { set; get; }
        public int MinPasswordAge { set; get; }
        public int MaxPasswordAge { set; get; }
        public bool EnableComplexPassword { set; get; }
    }

    public struct CompanyPrintTemplate
    {
        public int CompanyId { set; get; }
        public string HeaderRightImageName { set; get; }
        public string HeaderCenterImageName { set; get; }
        public string HeaderLeftImageName { set; get; }
        public string FooterImageName { set; get; }
        public bool ShowWaterMark { set; get; }

    }

    #endregion

    #region Mail Settings Structure...

    public struct MailSettings
    {
        public int EmailId { set; get; }
        public string EmailName { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public int Timeout { get; set; }
        public bool IsUsingSSL { get; set; }
        public bool IsUsingTLS { get; set; }
        public bool IgnoreCertificate { get; set; }
        public bool SMTPRequiresAuthentication { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
    }

    public struct EmailTemplate
    {
        public int TemplateId { set; get; }
        public int TemplateTypeId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }
        public string Note { set; get; }
        public bool IsActive { set; get; }
    }

    #endregion

    #region Documents Structure...

    public struct DocumentClass
    {
        public int DocTypeId { set; get; }
        public string Name { set; get; }
        public int DocNoFormatId { set; get; }
        public int NextNumber { set; get; }
        public int MinDigits { set; get; }
        public string Prefix { set; get; }
        public string Suffix { set; get; }
    }


    #endregion

    #region Files Structure...
    public struct FileAttachment
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ActualFileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public byte[] FileData { get; set; }
        public decimal Size { set; get; }
        public bool OnDisk { set; get; }
        public bool OnDatabase { set; get; }
        public string RelativeDiskPath { set; get; }
        public int AttachmentTypeId { set; get; }
        public string AttachmentType { set; get; }
        public int EntryUserId { set; get; }
        public string EntryUserName { set; get; }
        public DateTime EntryDate { set; get; }
        public bool IsUpdated { set; get; }
        public bool IsPrivate { set; get; }
    }

    public struct FileImage
    {
        public int ImageId { set; get; }
        public string ImageType { set; get; }
        public string ImageName { set; get; }
        public byte[] ImageData { set; get; }
        public bool IsUpdated { set; get; }
    }

    #endregion

    #region Event Log Structure...

    public struct EventLog
    {
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string MachineName { set; get; }
        public string IpAddress { set; get; }
        public string BrowserType { set; get; }
        public string Message { set; get; }

    }
    #endregion

    #region Projects Structure...

    public struct Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
    }
    public struct ProjectFiles
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public byte[] FileData { get; set; }
        public decimal Size { set; get; }
        public DateTime EntryDate { set; get; }
        public int ProjectId { get; set; }
        public string DiskFileName { get; set; }

    }
    public struct ProjectNotes
    {
        public int NoteId { get; set; }
        public int ProjectId { get; set; }
        public string NoteText { get; set; }
        public DateTime EntryDate { set; get; }
    }

    #endregion

    #region Documents Template Structure...

    public struct DocumentTemplateClass
    {
        public int TemplateId { set; get; }
        public int DocId { set; get; }
        public string DocNumber { set; get; }
        public int CompanyId { set; get; }
        public int DocTypeId { set; get; }
        public string Remark1 { set; get; }
        public string Remark2 { set; get; }
    }

    #endregion

    #region Location Structure...

    public struct Location
    {
        public int LocationId { set; get; }
        public string LocationName { set; get; }
        public string StoreKeeper { set; get; }
        public string StoreCode { set; get; }
        public bool IsReceivedGoods { set; get; }
        public bool IsDeliveryGoods { set; get; }
        public bool IsConsigned { set; get; }
        public bool HasCost { set; get; }
        public bool IsActive { set; get; }
    }

    public struct MainLocation
    {
        public int LocationId { set; get; }
        public int RawMaterialLocationId { set; get; }
        public int ProductionLocationId { set; get; }
        public int FinishMaterialLocationId { set; get; }
    }

    #endregion

    #region Payment Terms Structure...

    public struct PaymentTermsClass
    {
        public int PaymentTermsId { set; get; }
        public string PaymentName { set; get; }
        public int DaysDue { set; get; }
        public bool IsActive { set; get; }
    }

    #endregion

    #region Payment Method Structure...

    public struct PaymentMethodClass
    {
        public int PaymentMethodId { set; get; }
        public string Name { set; get; }

    }

    #endregion

    #region Unit Measure Structure...

    public struct UnitOfMeasure
    {
        public int UomId { set; get; }
        public string UnitName { set; get; }
        public string UnitCode { set; get; }
    }

    public struct UnitOfMeasureConversionRule
    {
        public int ConversionId { set; get; }
        public int FromUomId { set; get; }
        public int ToUomId { set; get; }
        public decimal UomFactor { set; get; }
    }

    #endregion

    #region User Account Structure...

    public struct Department
    {
        public int DepartmentId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Remark { set; get; }

    }

    public struct Role
    {
        public int RoleId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Remark { set; get; }
    }

    public struct UserAccount
    {
        public int UserId { set; get; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int DepratmentId { get; set; }
        public string RoleName { get; set; }
        public string DepratmentName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string UserTitle { get; set; }
        public string UserSignature { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool HasCostView { get; set; }
        public string AuthorizePages { get; set; }
        public FileImage UserImage { set; get; }
    }

    public struct LoginUserAccount
    {
        public int UserId { set; get; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserSignature { get; set; }
        public FileImage UserImage { set; get; }
    }



    #endregion

    #region Session Values Structure...

    public struct SessionValues
    {
        public int UserId { set; get; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public bool HasProfilePicture { get; set; }
        public int RoleId { set; get; }
        public string Role { set; get; }
        public int DepartmentId { set; get; }
        public string Department { set; get; }
        public int LocationId { set; get; }
        public string EmailAddress { get; set; }
        public string UserTitle { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool HasSalesTax { get; set; }
        public decimal SalesTaxValue { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsAdministrator { get; set; }
        public bool HasCostView { get; set; }
        public ArrayList AuthorizePages { get; set; }
        public string UserImageType { get; set; }
    }

    #endregion

    #region Page Structure...

    public struct SystemPage
    {
        public int PageId { set; get; }
        public string Name { set; get; }
        public string DisplayName { set; get; }
        public bool IsPublic { set; get; }
    }

    public struct SysPageFrom
    {
        public int PageId { set; get; }
        public string Name { set; get; }
        public string DisplayName { set; get; }
        public string Description { set; get; }
        public int CategoryId { set; get; }
        public bool HasInsertOperation { set; get; }
        public bool HasUpdateOperation { set; get; }
        public bool HasDeleteOperation { set; get; }
        public int AccessTypeId { set; get; }
        public bool ViewOnly { set; get; }
        public bool IsActive { set; get; }

    }

    public struct GroupPermission
    {
        public int GroupId { set; get; }
        public string Name { set; get; }
        public bool HasCostView { get; set; }
        public string AuthorizePages { get; set; }
    }

    #endregion

    #region Currency Structure...

    public struct Currency
    {
        public int CurrencyId { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
        public string Symbol { set; get; }
        public bool IsActive { set; get; }
        public int DecimalPlaces { set; get; }
        public string DecimalSeparator { set; get; }
        public string ThousandsSeparator { set; get; }
        public int CrCurrencyPositionType { set; get; }
        public int CrNegativeType { set; get; }
        public decimal ExchangeRate { set; get; }
    }

    public struct CurrencyProperties
    {
        public int CurrencyId { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string FractionName { set; get; }
        public int FractionDigit { set; get; }
        public int FractionValue { set; get; }
    }

    #endregion

    #region Catalog Item Structure...

    public struct Item
    {
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string AdditionalCode { set; get; }
        public string PartNumber { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public string DescriptionAr { set; get; }
        public int ItemTypeId { set; get; }
        public string ItemType { set; get; }
        public int CategoryId { set; get; }
        public string Category { set; get; }
        public int SubCategoryId { set; get; }
        public string SubCategory { set; get; }
        public string BarCode { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal MinimumPrice { set; get; }
        public int UomId { set; get; }
        public string Uom { set; get; }
        public int StorageUomId { set; get; }
        public string StorageUmo { set; get; }
        public int PurchaseUomId { set; get; }
        public string SalesUom { set; get; }
        public int BrandId { set; get; }
        public string Brand { set; get; }
        public string Pole { set; get; }
        public string Rating { set; get; }
        public string Incomer { set; get; }
        public string Outgoing { set; get; }
        public string Way { set; get; }
        public string Ka { set; get; }
        public string ItemCurrent { set; get; }
        public string Remarks { set; get; }
        public decimal BomPrice { set; get; }
        public FileImage ItemImage { set; get; }
        public bool IsNonStandard { set; get; }
        public bool IsCanBeSold { set; get; }
        public bool IsManufacture { set; get; }
        public bool HasBom { set; get; }
        public bool IsActive { set; get; }

        /*Additional info */
        public string MCode { set; get; } // malik code
        public string MDescription { set; get; } // malik description
    }

    public struct ItemBomLine
    {
        public int LineId { set; get; }
        public int ItemId { set; get; }
        public int BomTypeId { set; get; }
        public int ItemBomId { set; get; }
        public decimal Quantity { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int ItemTypeId { set; get; }
        public string ItemType { set; get; }
        public int CategoryId { set; get; }
        public string Category { set; get; }
        public int SubCategoryId { set; get; }
        public string SubCategory { set; get; }
        public int UomId { set; get; }
        public string Uom { set; get; }
        public int BrandId { set; get; }
        public string Brand { set; get; }
        public decimal SellingPrice { set; get; }
    }

    public struct ItemCategory
    {
        public int CategoryId { set; get; }
        public int ParentCategoryId { set; get; }
        public string ParentCategory { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public bool IsCanBeSold { set; get; }
        public bool IsManufacture { set; get; }
        public bool IsActive { set; get; }

    }

    public struct Brand
    {
        public int BrandId { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
    }
    #endregion

    #region Stock Transfer Structure...

    public struct StockTransfer
    {
        public int TransferId { set; get; }
        public string TransferNumber { set; get; }
        public string TransferDescription { set; get; }
        public DateTime TransferDate { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public int FromLocationId { set; get; }
        public string FromLocation { set; get; }
        public int ToLocationId { set; get; }
        public string ToLocation { set; get; }
        public DateTime PostedDate { set; get; }
        public int PostedUserId { set; get; }
        public string PostedUserName { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    [Serializable]
    public struct StockTransferLine
    {
        public int TransferId { set; get; }
        public int LineId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public decimal Quantity { set; get; }
        public int UomId { set; get; }
        public string Uom { set; get; }
        public string Remarks { set; get; }
    }

    #endregion

    #region Supplier Structure...

    public struct Supplier
    {
        public int SupplierId { set; get; }
        public string Name { set; get; }
        public string NameAr { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Country { set; get; }
        public string PostalCode { set; get; }
        public string ContactName { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string WebSite { set; get; }
        public int CurrencyId { set; get; }
        public string Currency { set; get; }
        public string CurrencyCode { set; get; }
        public int DefaultPaymentTermsId { set; get; }
        public string DefaultPaymentTerms { set; get; }
        public string Remarks { set; get; }
        public bool IsActive { set; get; }
    }

    #endregion

    #region Supplier Chain Management

    public struct PurchaseOrder
    {
        public int PurchaseOrderId { set; get; }
        public string OrderNumber { set; get; }
        public DateTime OrderDate { set; get; }
        public int SupplierId { set; get; }
        public string SupplierName { set; get; }
        public string ContactName { set; get; }
        public string Phone { set; get; }
        public string SupplierAddress { set; get; }
        public int ShippingTermsId { set; get; }
        public string ShippingTerms { set; get; }
        public string ShipToAddress { set; get; }
        public string ShipToCompany { set; get; }
        public int PaymentTermsId { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Tax { set; get; }
        public decimal GrandTotal { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public decimal ExchangeRate { set; get; }
        public string Remarks { set; get; }
        public string PreparedBy { set; get; }
        public string PostedBy { set; get; }
        public string CanceledBy { set; get; }
        public DateTime CanceledDate { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    [Serializable]
    public struct PurchaseOrderLine
    {
        public int LineId { set; get; }
        public int PurchaseOrderId { set; get; }
        public int SeqId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string SupplierItemCode { set; get; }
        public int PurchaseUomId { set; get; }
        public string PurchaseUom { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public int StatusId { set; get; }
        public decimal ReceivedQuantity { set; get; }
        public decimal RemainingQuantity { set; get; }
    }

    public struct GoodsReceipt
    {
        public int GoodsReceiptId { set; get; }
        public string ReceiptNumber { set; get; }
        public DateTime ReceiptDate { set; get; }
        public int SupplierId { set; get; }
        public string SupplierName { set; get; }
        //public string SupplierInvoiceNumber { set; get; }
        public string Remarks { set; get; }
        public string CancelRemarks { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public string PreparedBy { set; get; }
        public string PostedBy { set; get; }
        public string CanceledBy { set; get; }
        public DateTime CanceledDate { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public int PurchaseOrderId { set; get; }
        public string PurchaseOrderNumber { set; get; }
        public bool IsConsignedGoods { set; get; }
        public decimal ProductsQuantity { set; get; }
    }

    [Serializable]
    public struct GoodsReceiptLine
    {
        public int LineId { set; get; }
        public int GoodsReceiptId { set; get; }
        public int SeqId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public int UomId { set; get; }
        public string Uom { set; get; }
        public decimal Quantity { set; get; }
        public string Remarks { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }

        /**/
        public decimal UnitPrice { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal BilledQuantity { set; get; }
        public decimal RemainingQuantity { set; get; }

        /**/
    }

    public struct PurchaseInvoice
    {
        public int PurchaseInvoiceId { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }
        public int SupplierId { set; get; }
        public string SupplierName { set; get; }
        public string SupplierInvoiceNumber { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public int LocalCurrencyId { set; get; }
        public string LocalCurrencyCode { set; get; }
        public decimal ExchangeRate { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public decimal FreightExpenses { set; get; }
        public decimal ClearanceExpenses { set; get; }
        public decimal OtherExpenses { set; get; }
        public decimal OtherExpensesLocalCurrency { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal SubTotal { set; get; }
        public decimal GrandTotal { set; get; }
        public string Remarks { set; get; }
        public string PreparedBy { set; get; }
        public string PostedBy { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public int PurchaseOrderId { set; get; }
        public string PurchaseOrderNumber { set; get; }
        public int GoodsReceiptId { set; get; }
        public string GoodsReceiptNumber { set; get; }
        public decimal ProductsQuantity { set; get; }
    }

    [Serializable]
    public struct PurchaseInvoiceLine
    {
        public int LineId { set; get; }
        public int PurchaseInvoiceId { set; get; }
        public int SeqId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string SupplierItemCode { set; get; }
        public int PurchaseUomId { set; get; }
        public string PurchaseUom { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal UnitCost { set; get; }
        public decimal TotalCost { set; get; }
        public int StatusId { set; get; }
    }

    #endregion

    #region Customer Structure...

    public struct Customer
    {
        public int CustomerId { set; get; }
        public string Name { set; get; }
        public string NameAr { set; get; }
        public string ContactName { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Country { set; get; }
        public string PostalCode { set; get; }
        public string WebSite { set; get; }
        public int DefaultPaymentTermsId { set; get; }
        public string DefaultPaymentTerms { set; get; }
        public int DefaultPaymentMethodId { set; get; }
        public string DefaultPaymentMethod { set; get; }
        public string Remarks { set; get; }
        public bool IsActive { set; get; }
    }

    #endregion

    #region Production Kit Structure...

    public struct ProductionKit
    {
        public int KitId { set; get; }
        public int TypeId { set; get; }
        public string Type { set; get; }
        public string Name { get; set; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public int CategoryId { set; get; }
        public string Category { set; get; }
        public decimal EtPerHour { get; set; }
        public decimal ProductionRatio { set; get; }
        public string DrawingName { set; get; }
        public string Remarks { set; get; }
        public String KitLinesXml { set; get; }
        public List<ProductionKitLine> KitLines { set; get; }
    }

    [Serializable]
    public struct ProductionKitLine
    {
        public int SeqId { set; get; }
        public int KitLineId { set; get; }
        public int KitId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public decimal Quantity { set; get; }
        public string Category { set; get; }
        public string Uom { set; get; }
    }

    #endregion

    #region Sales Order Structure...

    public struct SalesOrder
    {
        public int OrderId { set; get; }
        public string OrderNumber { set; get; }
        public DateTime OrderDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerNameAr { set; get; }
        public bool IsCustomerNameAr { set; get; }
        public string PurchaseOrder { set; get; }
        public string ProjectName { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public decimal ExchangeRate { set; get; }
        public Decimal SubTotal { set; get; }
        public Decimal Expenses { set; get; }
        public Decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public bool IsPercentDiscount { set; get; }
        public Decimal GrandTotal { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int QuoteId { set; get; }
        public string QuoteNumber { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public bool IsContainGroup { set; get; }

    }

    [Serializable]
    public struct SalesOrderLine
    {
        public int OrderId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal UnitCost { set; get; }
        public decimal TotalCost { set; get; }
        public bool IsConsigned { set; get; }
        public int StatusId { set; get; }
        public bool IsServiceItem { set; get; }

        /**/
        public decimal DeliveredQuantity { set; get; }
        public decimal RemainingQuantity { set; get; }
        public decimal StockQuantity { set; get; }
        /**/
    }

    #endregion

    #region Sales Quote Structure...

    public struct Quote
    {
        public int QuoteId { set; get; }
        public string QuoteNumber { set; get; }
        public DateTime QuoteDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerNameAr { set; get; }
        public bool IsCustomerNameAr { set; get; }
        public string ProjectName { set; get; }
        public string InquiryNumber { set; get; }
        public DateTime InquiryDate { set; get; }
        public decimal ExchangeRate { set; get; }
        public Decimal SubTotal { set; get; }
        public Decimal Expenses { set; get; }
        public Decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public bool IsRoundUp { set; get; }
        public bool IsContainGroup { set; get; }
        public Decimal GrandTotal { set; get; }
        public int SalesOrderId { set; get; }
        public int SalesInvoiceId { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int SalesEngineerId { set; get; }
        public string SalesEngineerName { set; get; }
        public int CurrencyIdView { set; get; }
        public string CurrencyViewCode { set; get; }
        public int CompanyIdView { set; get; }
        public string CompanyCode { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public List<QuoteLine> QuoteLines { set; get; }
        public decimal Tax { set; get; }
    }

    [Serializable]
    public struct QuoteLine
    {
        public int QuoteId { set; get; }
        public int QuoteLineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal UnitCost { set; get; }
        public decimal TotalCost { set; get; }
        public int StatusId { set; get; }
        public bool IsRoundUp { set; get; }
    }

    #endregion

    #region Sales Invoice Structure...

    public struct SalesInvoice
    {
        public int InvoiceId { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerNameAr { set; get; }
        public bool IsCustomerNameAr { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public string PurchaseOrder { set; get; }
        public string ProjectName { set; get; }
        public int PaymentMethodId { set; get; }
        public string PaymentMethod { set; get; }
        public int PaymentTermsId { set; get; }
        public string PaymentTerms { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public decimal ExchangeRate { set; get; }
        public Decimal SubTotal { set; get; }
        public Decimal Expenses { set; get; }
        public Decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public bool IsPercentDiscount { set; get; }
        public Decimal GrandTotal { set; get; }
        public string Remarks { set; get; }
        public int RefundInvoiceId { set; get; }
        public bool IsRefund { set; get; }
        public int CurrencyIdView { set; get; }
        public string CurrencyView { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int SalesOrderId { set; get; }
        public string SalesOrderNumber { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }

        /**/
        public bool IsRefundBefore { set; get; }
        /**/
    }

    [Serializable]
    public struct SalesInvoiceLine
    {
        public int InvoiceId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public decimal UnitCost { set; get; }
        public decimal TotalCost { set; get; }
        public bool IsSpecialRecord { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public int StatusId { set; get; }
        public int IsLowMinPrice { set; get; }
        public bool IsServiceItem { set; get; }


        /**/
        public decimal RefundQuantity { set; get; }
        public decimal RemainingQuantity { set; get; }
        public decimal StoreQuantity { set; get; }
        public string Uom { set; get; }
        /**/
    }

    #endregion

    #region Proforma Invoice Structure...

    public struct ProformaInvoice
    {
        public int InvoiceId { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerNameAr { set; get; }
        public string ProjectName { set; get; }
        public int PaymentMethodId { set; get; }
        public string PaymentMethod { set; get; }
        public int PaymentTermsId { set; get; }
        public string PaymentTerms { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public Decimal SubTotal { set; get; }
        public Decimal Expenses { set; get; }
        public Decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public bool IsPercentDiscount { set; get; }
        public Decimal GrandTotal { set; get; }
        public string Remarks { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    [Serializable]
    public struct ProformaInvoiceLine
    {
        public int InvoiceId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public bool IsServiceItem { set; get; }
    }

    #endregion

    #region Delivery Receipt Structure...

    public struct DeliveryReceipt
    {
        public int ReceiptId { set; get; }
        public string ReceiptNumber { set; get; }
        public DateTime ReceiptDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string CustomerNameAr { set; get; }
        public bool IsCustomerNameAr { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public string PurchaseOrder { set; get; }
        public string ProjectName { set; get; }
        public int CurrencyId { set; get; }
        public string CurrencyCode { set; get; }
        public decimal ExchangeRate { set; get; }
        public Decimal SubTotal { set; get; }
        public Decimal Expenses { set; get; }
        public Decimal Discount { set; get; }
        public decimal Tax { set; get; }
        public bool IsPercentDiscount { set; get; }
        public Decimal GrandTotal { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public int SalesOrderId { set; get; }
        public string SalesOrderNumber { set; get; }
        public int SalesInvoiceId { set; get; }
        public string SalesInvoiceNumber { set; get; }
        public int TypeId { set; get; }
        public string Type { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public Decimal OrderDiscount { set; get; }
    }

    [Serializable]
    public struct DeliveryReceiptLine
    {
        public int ReceiptId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal TotalPrice { set; get; }
        public int UomId { set; get; }
        public string Uom { set; get; }
        public bool IsSpecialRecord { set; get; }
        public int LocationId { set; get; }
        public string Location { set; get; }
        public int StatusId { set; get; }
        public bool IsServiceItem { set; get; }

        /**/
        public decimal StoreQuantity { set; get; }
        /**/
    }

    #endregion

    #region Audit Structure...

    public struct Audit
    {
        public int AuditId { set; get; }
        public string Type { set; get; }
        public string TableName { set; get; }
        public string Action { set; get; }
        public string Entity { set; get; }
        public DateTime EntryDate { set; get; }
        public int EntryUserId { set; get; }
        public string UserName { set; get; }
    }
   #endregion

    #region Job Order Structure...

    public struct JobOrder
    {
        public int OrderId { set; get; }
        public string OrderNumber { set; get; }
        public DateTime OrderDate { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string ProjectName { set; get; }
        public string Remarks { set; get; }
        public int SalesOrderId { set; get; }
        public string SalesOrderNumber { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    [Serializable]
    public struct JobOrderLine
    {
        public int OrderId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ParentId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Quantity { set; get; }
        public string Remarks { set; get; }
        public int StatusId { set; get; }
    }

    #endregion

    #region Production Order Structure...

    public struct ProductionOrder
    {
        public int ProductionOrderId { set; get; }
        public string ProductionOrderNumber { set; get; }
        public string OrderType { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public string ProjectName { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int EstimatedDays { set; get; }
        public string RawMaterialLocation { set; get; }
        public string ProductionLocation { set; get; }
        public string FinishLocation { set; get; }
        public string Remarks { set; get; }
        public string CloseRemarks { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public DateTime OrderDate { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
    }

    public struct ProductionOrderLine
    {
        public int ProductionOrderId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Quantity { set; get; }
        public string Remarks { set; get; }
        public int StatusId { set; get; }
    }

    public struct ProductionOrderBomLine
    {
        public int LineId { set; get; }
        public int ProductionOrderId { set; get; }
        public int ProductionItemId { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Quantity { set; get; }
        public decimal Cost { set; get; }
        public string Remarks { set; get; }
    }

    #endregion

    #region Raw Material Transfer Structure...

    public struct MaterialTransfer
    {
        public int MaterialTransferId { set; get; }
        public string MaterialTransferNumber { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public string ProjectName { set; get; }
        public int OrderId { set; get; }
        public string OrderNumber { set; get; }
        public int OrderTypeId { set; get; }
        public string OrderType { set; get; }
        public int FromLocationId { set; get; }
        public string FromLocation { set; get; }
        public int ToLocationId { set; get; }
        public string ToLocation { set; get; }
        public int TransferTypeId { set; get; }
        public string TransferType { set; get; }
        public string Remarks { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public int UserId { set; get; }
        public string PreparedBy { set; get; }
        public DateTime PreparedDate { set; get; }
    }

    public struct MaterialTransferLine
    {
        public int LineId { set; get; }
        public int MaterialTransferId { set; get; }
        public int OrderId { set; get; }
        public int OrderItemId { set; get; }
        public decimal OrderItemQuantity { set; get; }
        public int ItemId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Quantity { set; get; }
        public decimal Cost { set; get; }
        public decimal TotalQuantity { set; get; }
    }

    public enum MaterialTransferStatus
    {
        Draft = 1,
        Posted = 2,
    }

    public enum MaterialTransferType
    {
        Request = 1,
        Return = 2,
    }

    #endregion

    #region Assembly Order Structure...

    public struct AssemblyOrder
    {
        public int AssemblyOrderId { set; get; }
        public string AssemblyOrderNumber { set; get; }
        public string OrderType { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public string ProjectName { set; get; }
        public DateTime OrderDate { set; get; }
        public int ItemLocationId { set; get; }
        public string ItemLocation { set; get; }
        public int BomLocationId { set; get; }
        public string BomLocation { set; get; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public decimal Quantity { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct AssemblyBomLine
    {
        public int AssemblyOrderId { set; get; }
        public int LineId { set; get; }
        public int ItemBomId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public string Uom { set; get; }
        public decimal Quantity { set; get; }
        public decimal RequestedQuantity { set; get; }
        public decimal StockQuantity { set; get; }
    }

    #endregion

    #region Modification Order Structure...

    public struct ModificationOrder
    {
        public int ModificationOrderId { set; get; }
        public string ModificationOrderNumber { set; get; }
        public int OrderTypeId { set; get; }
        public string OrderType { set; get; }
        public int JobOrderId { set; get; }
        public string JobOrderNumber { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime OrderDate { set; get; }
        public string ProjectName { set; get; }
        public int EstimatedDays { set; get; }
        public int InputLocationId { set; get; }
        public string InputLocation { get; set; }
        public int OutputLocationId { set; get; }
        public string OutputLocation { get; set; }
        public int BomLocationId { set; get; }
        public string BomLocation { get; set; }
        public string Remarks { set; get; }
        public string CloseRemarks { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
    }

    public struct ModificationOrderLine
    {
        public int ModificationOrderLineId { set; get; }
        public int ModificationOrderId { set; get; }
        public int LineId { set; get; }
        public int LineSeqId { set; get; }
        public int InputItemId { set; get; }
        public string InputItemCode { set; get; }
        public string InputPartNumber { set; get; }
        public string InputDescription { set; get; }
        public string InputCategory { set; get; }
        public string InputSubCategory { set; get; }
        public decimal InputQuantity { set; get; }
        public int OutputItemId { set; get; }
        public string OutputItemCode { set; get; }
        public string OutputPartNumber { set; get; }
        public string OutputDescription { set; get; }
        public string OutputCategory { set; get; }
        public string OutputSubCategory { set; get; }
        public decimal OutputQuantity { set; get; }
        //public string Remarks { set; get; }
        //public int StatusId { set; get; }
    }

    public struct ModificationOrderBomLine
    {
        public int LineId { set; get; }
        public int ModificationOrderId { set; get; }
        public int ModificationItemId { set; get; }
        public int ItemBomId { set; get; }
        public string ItemCode { set; get; }
        public string PartNumber { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public decimal Quantity { set; get; }
        public decimal Cost { set; get; }
        public string Remarks { set; get; }
    }

    #endregion

    #region CRM Structure...

    public struct Client
    {
        public int ClientId { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Mobile { set; get; }
        public string Fax { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public string PostalCode { set; get; }
        public string WebSite { set; get; }
        public string Remarks { set; get; }
        public bool IsActive { set; get; }
    }

    public struct Contact
    {
        public int ContactId { set; get; }
        public int ClientId { set; get; }
        public int ContactTypeId { set; get; }
        public string Name { set; get; }
        public string NameTitle { set; get; }
        public string JobTitle { set; get; }
        public string Phone { set; get; }
        public string Mobile { set; get; }
        public string Fax { set; get; }
        public string Email1 { set; get; }
        public string Email2 { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public string PostalCode { set; get; }
        public string Remarks { set; get; }
        public bool IsActive { set; get; }
    }
    #endregion

    #region Projects Structure...

    public struct Proj
    {
        public int ProjectId { get; set; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public string ProjectName { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string Remarks { set; get; }
        public decimal SalesTotal { set; get; }
        public decimal ExpensesTotal { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct ProjPurchase
    {
        public int PurchaseId { get; set; }
        public int ProjectId { get; set; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal Amount { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct ProjSales
    {
        public int SalesId { get; set; }
        public int ProjectId { get; set; }
        public int ItemId { set; get; }
        public string PartNumber { set; get; }
        public string ItemCode { set; get; }
        public string Description { set; get; }
        public string DescriptionAs { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Profit { set; get; }
        public decimal Discount { set; get; }
        public bool IsPercentDiscount { set; get; }
        public decimal NetPrice { set; get; }
        public decimal Amount { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct ProjVisitLine
    {
        public int VisitId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { set; get; }
        public string EmployeeName { set; get; }
        public string Remarks { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct ProjExpense
    {
        public int ExpenseId { get; set; }
        public int ProjectId { get; set; }
        public string Description { set; get; }
        public decimal Amount { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    public struct ProjSaleLine
    {
        public int SaleId { get; set; }
        public int ProjectId { get; set; }
        public string Description { set; get; }
        public decimal Amount { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int StatusId { set; get; }
        public string Status { set; get; }
    }

    #endregion

    #region Ticket Structure New...

    public struct TicketSettings
    {
        public string URL { set; get; }
        public string SiteName { set; get; }
        public int EmailId { set; get; }
        public string ToMail { get; set; }
        public string CcMail { get; set; }
        public string BccMail { get; set; }
    }

    public struct TicketCategory
    {
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
    }

    public struct TicketDepartment
    {
        public int DepartmentId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
    }
    public struct TicketIssue
    {
        public int IssueId { set; get; }
        public int ServiceId { set; get; }
        public string Service { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
    }

    public struct TicketIssueReason
    {
        public int ReasonId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
    }

    public struct TicketStaff
    {
        public int UserId { set; get; }
        public string DisplayName { set; get; }
        public bool IsTicketUser { set; get; }
    }

    public struct TicketTeam
    {
        public int TeamId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<TicketTeamStaff> Satff { get; set; }
        public bool IsActive { set; get; }
    }

    public struct TicketTeamStaff
    {
        public int TeamId { set; get; }
        public int UserId { set; get; }
        public string DisplayName { set; get; }
    }

    public struct Ticket
    {
        public int TicketId { set; get; }
        public string TicketNumber { set; get; }
        public DateTime TicketDate { set; get; }
        public DateTime IssueDate { set; get; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public List<string> IssueList { get; set; }
        public string Issue { get; set; }
        public string IssueSource { get; set; }
        public int IssueStatusId { get; set; }
        public string IssueStatus { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int AssignedTeamId { get; set; }
        public string AssignedTeam { get; set; }
        public int AssignedUserId { get; set; }
        public string AssignedUser { get; set; }
        public string AssignedUserEmail { get; set; }
        public string Subject { get; set; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public bool IsResolvedImmediately { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }

    public struct TicketThread
    {
        public int ThreadId { set; get; }
        public int TicketId { set; get; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string DisplayName { set; get; }
        public DateTime ThreadDate { set; get; }
        public string ThreadType { set; get; }
        public string ThreadLabel { set; get; }
        public string UserIPAddress { get; set; }
        public string Body { get; set; }
        public bool HasAttachment { get; set; }
        public List<ThreadAttachment> Attachment { set; get; }
        public string AttachmentXml { set; get; }
    }

    public struct ThreadAttachment
    {
        public int ThreadId { set; get; }
        public int TicketId { set; get; }
        public string AttachmentName { get; set; }
        public string AttachmentKey { get; set; }
    }

    #endregion
}