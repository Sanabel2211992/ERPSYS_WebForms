using System;
using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class SettingsBLL
    {
        private readonly SettingsDB _setting = new SettingsDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetCompanyList()
        {
            return _setting.GetCompanyList();
        }

        public CompanyProfile GetCompanyProfile(int companyId)
        {
            DataTable companyDt = _setting.GetCompanyProfile(companyId);


            if (companyDt.Rows.Count == 0)
            {
                throw new Exception("Error");
            }

            DataRow dr = companyDt.Rows[0];

            CompanyProfile company = new CompanyProfile();

            company.CompanyId = companyId;
            company.Name = dr["Name"].ToString();
            company.Phone = dr["Phone"].ToString();
            company.Fax = dr["Fax"].ToString();
            company.Email = dr["Email"].ToString();
            company.WebSite = dr["WebSite"].ToString();
            company.Address1 = dr["Address1"].ToString();
            company.Address2 =
            company.City = dr["City"].ToString();
            company.State = dr["State"].ToString();
            company.Country = dr["Country"].ToString();
            company.PostalCode = dr["PostalCode"].ToString();
            company.TaxNumber = dr["TaxNumber"].ToString();
            company.PictureFileAttachmentId = dr["PictureFileAttachmentId"].ToInt();

            if (company.PictureFileAttachmentId > 0)
            {
                company.PictureFileAttachmentType = (FileAttachmentTypes)dr["FileAttachmentType"];
                company.PictureFileAttachmentName = dr["FileName"].ToString();
                company.PictureFileAttachmentData = (byte[])dr["Data"];
            }

            return company;
        }

        public SystemSettings GetSystemSettings()
        {
            DataTable dt = _setting.GetSystemSettings();

            SystemSettings settings = new SystemSettings();

            if (dt.Rows.Count == 0)
            {
                settings.CompanyId = -1;
                return settings;
            }

            DataRow dr = dt.Rows[0];

            settings.CompanyId = dr["CompanyId"].ToInt();
            settings.EnableSalesTax = dr["EnableSalesTax"].ToBool();
            settings.SalesTaxValue = dr["SalesTaxValue"].ToDecimal();
            settings.ShowSalesInvoicePrintTemplate = dr["ShowSalesInvoicePrintTemplate"].ToBool();
            settings.ShowProInvoicePrintTemplate = dr["ShowProInvoicePrintTemplate"].ToBool();
            settings.ShowDeliveryReceiptPrintTemplate = dr["ShowDeliveryReceiptPrintTemplate"].ToBool();
            settings.CreateJobOrderWhenSalesOrderPost = dr["CreateJobOrderWhenSalesOrderPost"].ToBool();
            settings.ShowWatermarkInReports = dr["ShowWatermarkInReports"].ToBool();
            settings.HidePOQuantityInMR = dr["HidePurchaseOrderQuantityInMaterialReceived"].ToBool();
            settings.AddExpensesValueToTotal = dr["AddExpensesValueToGrandTotal"].ToBool();
            settings.CreateJobOrderWhenSalesInvoicePost = dr["CreateJobOrderWhenSalesInvoicePost"].ToBool();
            settings.SetSalesInvoiceReferenceManually = dr["SetSalesInvoiceReferenceManually"].ToBool();
            settings.ShowOnlyRetailUserLocationInvoices = dr["ShowOnlyRetailUserLocationInvoices"].ToBool();

            settings.MinPasswordLength = dr["MinPasswordLength"].ToInt();
            settings.MaxPasswordAge = dr["MaxPasswordAge"].ToInt();
            settings.MinPasswordAge = dr["MinPasswordAge"].ToInt();
            settings.EnableComplexPassword = dr["EnableComplexPassword"].ToBool();

            return settings;
        }

        public string GetCompanyPreferencesPricing()
        {
            DataTable dt = _setting.GetCompanyPreferencesPricing();

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Error");
            }

            DataRow dr = dt.Rows[0];

            string defaultCompanyCirrency = dr["Description"].ToString();

            return defaultCompanyCirrency;

        }

        public CompanyPrintTemplate GetCompanyPrintReportTemplate(int companyId)
        {
            DataTable dt = _setting.GetCompanyPrintReportTemplate(companyId);

            if (dt.Rows.Count == 0)
            {
                return new CompanyPrintTemplate();
            }

            DataRow dr = dt.Rows[0];

            CompanyPrintTemplate companyTemplate = new CompanyPrintTemplate();
            companyTemplate.CompanyId = companyId;
            companyTemplate.HeaderRightImageName = dr["HeaderImageRight"].ToString();
            companyTemplate.HeaderCenterImageName = dr["HeaderImageCenter"].ToString();
            companyTemplate.HeaderLeftImageName = dr["HeaderImageLeft"].ToString();
            companyTemplate.FooterImageName = dr["FooterImage"].ToString();
            companyTemplate.ShowWaterMark = dr["ShowWatermarkInReports"].ToBool();

            return companyTemplate;
        }

        //public DataTable GetSystemPageList() update the access level
        //{
        //    return _setting.GetSystemPageList();
        //}

        public DataTable GetPermissionPageList(int categoryId)
        {
            return _setting.GetPermissionPageList(categoryId);
        }

        public DataTable GetPageList(string pageName, int statusId, int accessTypeId)
        {
            return _setting.GetPageList(pageName, statusId, accessTypeId);
        }

        public DataTable GetPageDetailsList()
        {
            return _setting.GetPageDetailsList();
        }

        public GroupPermission GetGroupPermission(int groupId)
        {
            DataTable dtPermission = _setting.GetGroupPermission(groupId);

            if (dtPermission.Rows.Count == 0)
            {
                throw new Exception("Error");
            }

            GroupPermission permission = new GroupPermission();
            DataRow dr = dtPermission.Rows[0];

            permission.GroupId = groupId;
            permission.HasCostView = dr["HasCostView"].ToBool();
            permission.AuthorizePages = dr["AuthorizePage"].ToString();

            return permission;
        }

        public DataTable GetDepartmentList(string department)
        {
            return _setting.GetDepartmentList(department);
        }

        public DataTable GetRoleList(string role)
        {
            return _setting.GetRoleList(role);
        }

        public DataTable GetLocationList()
        {
            return _setting.GetLocationList();
        }

        public DataTable GetDocumentFormatList()
        {
            return _setting.GetDocumentFormatList();
        }

        public DataTable GetPaymentList()
        {
            return _setting.GetPaymentList();
        }

        public DataTable GetPaymentMethodList()
        {
            return _setting.GetPaymentMethodList();
        }

        public DataTable GetUnitOfMeasureList(string unitName)
        {
            return _setting.GetUnitOfMeasureList(unitName);
        }

        public UnitOfMeasure GetUnitOfMeasure(int uomId)
        {
            DataTable dt = _setting.GetUnitOfMeasure(uomId);

            UnitOfMeasure unit = new UnitOfMeasure();

            if (dt.Rows.Count == 0)
            {
                unit.UomId = -1;
                return unit;
            }

            DataRow dr = dt.Rows[0];

            unit.UomId = uomId;
            unit.UnitName = dr["UnitName"].ToString();
            unit.UnitCode = dr["UnitCode"].ToString();

            return unit;
        }

        public DataTable GetUnitOfMeasureConversionList()
        {
            return _setting.GetUnitOfMeasureConversionList();
        }

        public UnitOfMeasureConversionRule GetUnitOfMeasureConversionRule(int conversionId)
        {
            DataTable dt = _setting.GetUnitOfMeasureConversionRule(conversionId);

            UnitOfMeasureConversionRule conversion = new UnitOfMeasureConversionRule();

            if (dt.Rows.Count == 0)
            {
                conversion.ConversionId = -1;
                return conversion;
            }

            DataRow dr = dt.Rows[0];

            conversion.ConversionId = conversionId;
            conversion.FromUomId = dr["FromUomId"].ToInt();
            conversion.ToUomId = dr["ToUomId"].ToInt();
            conversion.UomFactor = dr["UomFactor"].ToDecimal();

            return conversion;
        }

        public SysPageFrom GetPage(int pageId)
        {
            DataTable dt = _setting.GetPage(pageId);

            SysPageFrom page = new SysPageFrom();

            if (dt.Rows.Count == 0)
            {
                page.PageId = -1;
                return page;
            }

            DataRow dr = dt.Rows[0];

            page.PageId = pageId;
            page.Name = dr["PageName"].ToString();
            page.DisplayName = dr["DisplayName"].ToString();
            page.Description = dr["Description"].ToString();
            page.CategoryId = dr["CategoryId"].ToInt();
            page.ViewOnly = dr["ViewOnly"].ToBool();
            page.HasInsertOperation = dr["HasInsertOperation"].ToBool();
            page.HasUpdateOperation = dr["HasUpdateOperation"].ToBool();
            page.HasDeleteOperation = dr["HasDeleteOperation"].ToBool();
            page.IsActive = dr["IsActive"].ToBool();
            page.AccessTypeId = dr["AccessTypeId"].ToInt();

            return page;
        }

        public PaymentTermsClass GetPaymentTerms(int paymentTermsId)
        {
            DataTable dt = _setting.GetPaymentTerms(paymentTermsId);

            PaymentTermsClass paymentTerms = new PaymentTermsClass();

            if (dt.Rows.Count == 0)
            {
                paymentTerms.PaymentTermsId = -1;
                return paymentTerms;
            }

            DataRow dr = dt.Rows[0];

            paymentTerms.PaymentTermsId = paymentTermsId;
            paymentTerms.PaymentName = dr["PaymentName"].ToString();
            paymentTerms.DaysDue = dr["DaysDue"].ToInt();
            paymentTerms.IsActive = dr["IsActive"].ToBool();

            return paymentTerms;
        }

        public DocumentClass GetDocInformation(int docTypeId)
        {
            DataTable dt = _setting.GetDocumentInformation(docTypeId);

            DocumentClass doc = new DocumentClass();

            if (dt.Rows.Count == 0)
            {
                doc.DocTypeId = -1;
                return doc;
            }

            DataRow dr = dt.Rows[0];

            doc.DocTypeId = docTypeId;
            doc.Name = dr["Name"].ToString();
            doc.NextNumber = dr["NextNumber"].ToInt();
            doc.MinDigits = dr["MinDigits"].ToInt();
            doc.Prefix = dr["Prefix"].ToString();
            doc.Suffix = dr["Suffix"].ToString();

            return doc;
        }

        public PaymentMethodClass GetPaymentMethod(int paymentMethodId)
        {
            DataTable dt = _setting.GetPaymentMethod(paymentMethodId);

            PaymentMethodClass paymentMethod = new PaymentMethodClass();

            if (dt.Rows.Count == 0)
            {
                paymentMethod.PaymentMethodId = -1;
                return paymentMethod;
            }

            DataRow dr = dt.Rows[0];

            paymentMethod.PaymentMethodId = paymentMethodId;
            paymentMethod.Name = dr["MethodName"].ToString();

            return paymentMethod;
        }

        public Location GetLocation(int locationId)
        {
            DataTable dt = _setting.GetLocation(locationId);

            Location location = new Location();

            if (dt.Rows.Count == 0)
            {
                location.LocationId = -1;
                return location;
            }

            DataRow dr = dt.Rows[0];

            location.LocationId = locationId;
            location.LocationName = dr["Name"].ToString();
            location.StoreCode = dr["StoreCode"].ToString();
            location.StoreKeeper = dr["StoreKeeper"].ToString();
            location.IsReceivedGoods = dr["IsReceivedGoods"].ToBool();
            location.IsConsigned = dr["IsConsigned"].ToBool();
            location.HasCost = dr["HasCost"].ToBool();
            location.IsDeliveryGoods = dr["IsDeliveryGoods"].ToBool();
            location.IsActive = dr["IsActive"].ToBool();

            return location;
        }

        public Department GetDepartment(int departmentId)
        {
            DataTable dt = _setting.GetDepartment(departmentId);

            Department department = new Department();

            if (dt.Rows.Count == 0)
            {
                department.DepartmentId = -1;
                return department;
            }

            DataRow dr = dt.Rows[0];

            department.DepartmentId = departmentId;
            department.Name = dr["Name"].ToString();
            department.Description = dr["Description"].ToString();
            department.Remark = dr["Remark"].ToString();

            return department;
        }

        public Role GetRole(int roleId)
        {
            DataTable dt = _setting.GetRole(roleId);

            Role role = new Role();

            if (dt.Rows.Count == 0)
            {
                role.RoleId = -1;
                return role;
            }

            DataRow dr = dt.Rows[0];

            role.RoleId = roleId;
            role.Name = dr["Name"].ToString();
            role.Description = dr["Description"].ToString();
            role.Remark = dr["Remark"].ToString();

            return role;
        }

        public DocumentTemplateClass GetDocumentTemplate(int companyId, int docTypeId)
        {
            try
            {
                DataTable dtTemplate = _setting.GetDocumentTemplate(companyId, docTypeId);
                DataRow dr = dtTemplate.Rows[0];

                DocumentTemplateClass doc = new DocumentTemplateClass();

                doc.TemplateId = dr["TemplateId"].ToInt();
                doc.CompanyId = dr["CompanyId"].ToInt();
                doc.DocTypeId = dr["DocTypeId"].ToInt();
                doc.Remark1 = dr["Remark1"].ToString();
                doc.Remark2 = dr["Remark2"].ToString();

                return doc;
            }
            catch (Exception)
            {
                return new DocumentTemplateClass();
            }
        }

        public MainLocation LocationAssignment()
        {
            DataTable dt = _setting.GetLocationAssignment();

            MainLocation location = new MainLocation();

            DataRow dr = dt.Rows[0];

            location.RawMaterialLocationId = dr["RMLocationId"].ToInt();
            location.ProductionLocationId = dr["PMLocationId"].ToInt();
            location.FinishMaterialLocationId = dr["FMLocationId"].ToInt();

            return location;
        }

        public SystemSettings GetPasswordSettings()
        {
            DataTable dt = _setting.GetPasswordSettings();

            SystemSettings settings = new SystemSettings();

            if (dt.Rows.Count == 0)
            {
                settings.CompanyId = -1;
                return settings;
            }

            DataRow dr = dt.Rows[0];

            settings.CompanyId = dr["CompanyId"].ToInt();

            settings.MinPasswordLength = dr["MinPasswordLength"].ToInt();
            settings.MaxPasswordAge = dr["MaxPasswordAge"].ToInt();
            settings.MinPasswordAge = dr["MinPasswordAge"].ToInt();
            settings.EnableComplexPassword = dr["EnableComplexPassword"].ToBool();

            return settings;
        }

        //**************************************************************************************************************************//INSERT

        public int AddPage(SysPageFrom page, out string rMsg)
        {
            return _setting.AddPage(page, out rMsg);
        }

        internal int AddPayment(PaymentTermsClass payment, out string rMessage)
        {
            return _setting.AddPayment(payment, out rMessage);
        }

        public int AddPaymentMethod(PaymentMethodClass method, out string rMsg)
        {
            return _setting.AddPaymentMethod(method, out rMsg);
        }

        public int AddUnitOfMeasure(UnitOfMeasure unit, out string rMsg)
        {
            return _setting.AddUnitOfMeasure(unit, out rMsg);
        }

        public void AddUnitOfMeasureConversionRule(UnitOfMeasureConversionRule uom, out string rMessage)
        {
            _setting.AddUnitOfMeasureConversionRule(uom, out rMessage);
        }

        public int AddLocation(Location location, out string rMsg)
        {
            return _setting.AddLocation(location, out rMsg);
        }

        public int AddDepartment(Department department, out string rMsg)
        {
            return _setting.AddDepartment(department, out rMsg);
        }

        public int AddRole(Role role, out string rMsg)
        {
            return _setting.AddRole(role, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateCompanyProfile(CompanyProfile company, out string rMsg)
        {
            return _setting.UpdateCompanyProfile(company, out rMsg);
        }

        public int UpdateSystemGeneralSettings(SystemSettings settings, out string rMsg)
        {
            return _setting.UpdateSystemGeneralSettings(settings, out rMsg);
        }

        public int UpdateSystemSecuritySettings(SystemSettings settings, out string rMsg)
        {
            return _setting.UpdateSystemSecuritySettings(settings, out rMsg);
        }

        public void UpdateCompanyPrintReportTemplate(int companyId, int imgPosition, string imgName, out string rMsg)
        {
            _setting.UpdateCompanyPrintReportTemplate(companyId, imgPosition, imgName, out rMsg);
        }

        public void RemoveCompanyPrintReportTemplate(int companyId, int imgPosition, out string rMsg)
        {
            _setting.RemoveCompanyPrintReportTemplate(companyId, imgPosition, out rMsg);
        }

        public int UpdatePage(SysPageFrom page, out string rMsg)
        {
            return _setting.UpdatePage(page, out rMsg);
        }

        public void UpdateGroupPermission(GroupPermission permission, out string rMessage)
        {
            _setting.UpdateGroupPermission(permission, out rMessage);
        }

        public void UpdatePaymentTerms(PaymentTermsClass paymentterms, out string rMessage)
        {
            _setting.UpdatePaymentTerms(paymentterms, out rMessage);
        }

        public void UpdateDocInformaion(DocumentClass docNum, out string rMessage)
        {
            _setting.UpdateDocumentInformaion(docNum, out rMessage);
        }

        public void UpdatePaymentMethod(PaymentMethodClass method, out string rMessage)
        {
            _setting.UpdatePaymentMethod(method, out rMessage);
        }

        public void UpdateUnitOfMeasure(UnitOfMeasure unit, out string rMessage)
        {
            _setting.UpdateUnitOfMeasure(unit, out rMessage);
        }

        public void UpdateUnitOfMeasureConversionRule(UnitOfMeasureConversionRule uom, out string rMessage)
        {
            _setting.UpdateUnitOfMeasureConversionRule(uom, out rMessage);
        }

        public void UpdateLocation(Location location, out string rMessage)
        {
            _setting.UpdateLocation(location, out rMessage);
        }

        public void UpdateDepartment(Department department, out string rMessage)
        {
            _setting.UpdateDepartment(department, out rMessage);
        }

        public void UpdateRole(Role role, out string rMessage)
        {
            _setting.UpdateRole(role, out rMessage);
        }

        public void UpdateDocumentTemplate(DocumentTemplateClass doc, out string rMessage)
        {
            _setting.UpdateDocumentTemplate(doc, out rMessage);
        }

        public void UpdateLocationsAssignment(int rawMaterialLocationId, int productionLocationId, int finishMaterialLocationId, out string rMessage)
        {
            _setting.UpdateLocationsAssignment(rawMaterialLocationId, productionLocationId, finishMaterialLocationId, out rMessage);
        }

        //**************************************************************************************************************************//DELETE

        public void DeletePage(int pageId, out string rMessage, out int rMessageId)
        {
            _setting.DeletePage(pageId, out rMessage, out rMessageId);
        }

        public void DeleteUnitOfMeasure(int uomId, out string rMessage, out int rMessageId)
        {
            _setting.DeleteUnitOfMeasure(uomId, out rMessage, out rMessageId);
        }

        public void DeleteDepartment(int departmentId, out string rMessage, out int rMessageId)
        {
            _setting.DeleteDepartment(departmentId, out rMessage, out rMessageId);
        }

        public void DeleteRole(int roleId, out string rMessage, out int rMessageId)
        {
            _setting.DeleteRole(roleId, out rMessage, out rMessageId);
        }
    }
}