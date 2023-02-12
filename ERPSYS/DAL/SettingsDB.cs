using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class SettingsDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetCompanyList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Settings_Company_List_Get", CommandType.StoredProcedure);
        }

        public DataTable GetCompanyProfile(int companyId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", companyId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Setting_Company_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetSystemSettings()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_SystemPreferences_GET", CommandType.StoredProcedure);
            //return Dbhelper.ExecuteDataTable("GLOBAL_SystemSettings_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCompanyPreferencesPricing()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_CompanyPreferencesPricing_GET", CommandType.StoredProcedure);
        }

        public DataTable GetCompanyPrintReportTemplate(int companyId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", companyId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Setting_Company_Print_Template_GET", paramCollection, CommandType.StoredProcedure);
        }

        //public DataTable GetSystemPageList() update the access level
        //{
        //    return Dbhelper.ExecuteDataTable("GLOBAL_Settings_PageList_GET", CommandType.StoredProcedure);
        //}

        public DataTable GetPermissionPageList(int categoryId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CategoryId", categoryId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("NEW_GLOBAL_PermissionPageList_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPageList(string pageName, int statusId, int accessTypeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PageName", pageName));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));
            paramCollection.Add(new DBParameter("@AccessTypeId", accessTypeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_PageList_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPageDetailsList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_PageDetails_GET", CommandType.StoredProcedure);
        }

        public DataTable GetGroupPermission(int groupId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@GroupId", groupId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_GroupPermission_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDepartmentList(string department)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Department", department));
            return Dbhelper.ExecuteDataTable("BASE_Department_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetRoleList(string role)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Role", role));
            return Dbhelper.ExecuteDataTable("BASE_Role_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetLocationList()
        {
            return Dbhelper.ExecuteDataTable("BASE_Location_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetDocumentFormatList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_DocNoFormatList_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPaymentList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_PaymentList_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPaymentMethodList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_PaymentMethodList_GET", CommandType.StoredProcedure);
        }

        public DataTable GetUnitOfMeasureList(string unitName)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@UomName", unitName));

            return Dbhelper.ExecuteDataTable("BASE_Uom_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetUnitOfMeasure(int uomId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@UomId", uomId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Uom_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetUnitOfMeasureConversionList()
        {
            return Dbhelper.ExecuteDataTable("BASE_Uom_Conversion_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetUnitOfMeasureConversionRule(int conversionId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ConversionId", conversionId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_Uom_ConversionRule_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPage(int pageId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@pageId", pageId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Page_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPaymentMethod(int paymentMethodId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PaymentMethodId", paymentMethodId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_PaymentMethod_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetPaymentTerms(int paymentTermsId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@PaymentTermsId", paymentTermsId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Payment_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDocumentInformation(int docTypeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DocTypeId", docTypeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_DocInformation_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetLocation(int locationId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Location_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDocumentTemplate(int companyId, int docTypeId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", companyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@DocTypeId", docTypeId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_DocTempalte_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetDepartment(int departmentId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@DepartmentId", departmentId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Department_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetRole(int roleId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@RoleId", roleId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_Role_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetEmailSettings(int settingsId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@SettingsId", settingsId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("GLOBAL_EmailSettings_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetEmailSettingsList()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_EmailSettings_List_GET", CommandType.StoredProcedure);
        }

        public DataTable GetLocationAssignment()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Location_Assignment_GET", CommandType.StoredProcedure);
        }

        public DataTable GetPasswordSettings()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Setting_Password_GET", CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int AddPage(SysPageFrom page, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", page.Name));
            paramCollection.Add(new DBParameter("@DisplayName", page.DisplayName));
            paramCollection.Add(new DBParameter("@Description", page.Description));
            paramCollection.Add(new DBParameter("@CategoryId", page.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ViewOnly", page.ViewOnly, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasInsertOperation", page.HasInsertOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasUpdateOperation", page.HasUpdateOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasDeleteOperation", page.HasDeleteOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsActive", page.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AccessTypeId", page.AccessTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Page_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("page_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return newId;
        }

        public int AddPayment(PaymentTermsClass payment, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PaymentName", payment.PaymentName));
            paramCollection.Add(new DBParameter("@DaysDue", payment.DaysDue, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsActive", payment.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Payment_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("payment_terms_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        public int AddPaymentMethod(PaymentMethodClass method, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", method.Name));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_PaymentMethod_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("payment_method_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return newId;

        }

        public int AddUnitOfMeasure(UnitOfMeasure unit, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@UnitName", unit.UnitName));
            paramCollection.Add(new DBParameter("@UnitCode", unit.UnitCode));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Uom_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("uom_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return newId;

        }

        public int AddUnitOfMeasureConversionRule(UnitOfMeasureConversionRule uom, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FromUomId", uom.FromUomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ToUomId", uom.ToUomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UomFactor", uom.UomFactor, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Uom_ConversionRule_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);

            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("uom_conversion_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;

        }

        public int AddLocation(Location location, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", location.LocationName));
            paramCollection.Add(new DBParameter("@StoreKeeper", location.StoreKeeper));
            paramCollection.Add(new DBParameter("@StoreCode", location.StoreCode));
            paramCollection.Add(new DBParameter("@IsReceivedGoods", location.IsReceivedGoods, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsDeliveryGoods", location.IsDeliveryGoods, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsConsigned", location.IsConsigned, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasCost", location.HasCost, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsActive", location.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Location_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("location_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;

        }

        public int AddDepartment(Department department, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", department.Name));
            paramCollection.Add(new DBParameter("@Description", department.Description));
            paramCollection.Add(new DBParameter("@Remark", department.Remark));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Department_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("department_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;
        }

        public int AddRole(Role role, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Name", role.Name));
            paramCollection.Add(new DBParameter("@Description", role.Description));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remark", role.Remark));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Role_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("role_add_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return newId;
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateCompanyProfile(CompanyProfile company, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", company.CompanyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", company.Name));
            paramCollection.Add(new DBParameter("@Phone", company.Phone));
            paramCollection.Add(new DBParameter("@Fax", company.Fax));
            paramCollection.Add(new DBParameter("@Email", company.Email));
            paramCollection.Add(new DBParameter("@Website", company.WebSite));
            paramCollection.Add(new DBParameter("@Address1", company.Address1));
            paramCollection.Add(new DBParameter("@Address2", company.Address2));
            paramCollection.Add(new DBParameter("@City", company.City));
            paramCollection.Add(new DBParameter("@State", company.State));
            paramCollection.Add(new DBParameter("@Country", company.Country));
            paramCollection.Add(new DBParameter("@PostalCode", company.PostalCode));
            paramCollection.Add(new DBParameter("@TaxNumber", company.TaxNumber));
            paramCollection.Add(new DBParameter("@PictureFileAttachmentId", company.PictureFileAttachmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PictureFileAttachmentType", company.PictureFileAttachmentType, DbType.Int32));
            paramCollection.Add(new DBParameter("@PictureFileAttachmentName", company.PictureFileAttachmentName));
            paramCollection.Add(new DBParameter("@PictureFileAttachmentData", company.PictureFileAttachmentData, DbType.Binary));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Setting_Company_Update", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId > 0)
            {
                rMsg = GeneralResources.GetStringFromResources("company_update_failed");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateSystemGeneralSettings(SystemSettings settings, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", settings.CompanyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EnableSalesTax", settings.EnableSalesTax, DbType.Boolean));
            paramCollection.Add(new DBParameter("@SalesTaxValue", settings.SalesTaxValue, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ShowSalesInvoicePrintTemplate", settings.ShowSalesInvoicePrintTemplate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ShowProInvoicePrintTemplate", settings.ShowProInvoicePrintTemplate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ShowDeliveryReceiptPrintTemplate", settings.ShowDeliveryReceiptPrintTemplate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ShowWatermarkInReports", settings.ShowWatermarkInReports, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HidePOQuantityInMR", settings.HidePOQuantityInMR, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AddExpensesValueToTotal", settings.AddExpensesValueToTotal, DbType.Boolean));
            paramCollection.Add(new DBParameter("@CreateJobOrderWhenSalesOrderPost", settings.CreateJobOrderWhenSalesOrderPost, DbType.Boolean));
            paramCollection.Add(new DBParameter("@CreateJobOrderWhenSalesInvoicePost", settings.CreateJobOrderWhenSalesInvoicePost, DbType.Boolean));
            paramCollection.Add(new DBParameter("@SetSalesInvoiceReferenceManually", settings.SetSalesInvoiceReferenceManually, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ShowOnlyRetailUserLocationInvoices", settings.ShowOnlyRetailUserLocationInvoices, DbType.Boolean));   
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_SystemPreferences_UPDATE", paramCollection, CommandType.StoredProcedure);
            //IDbCommand command = Dbhelper.GetCommand("GLOBAL_SystemGeneralSettings_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId != 0)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateSystemSecuritySettings(SystemSettings settings, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", settings.CompanyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@MinPasswordLength", settings.MinPasswordLength, DbType.Int32));
            paramCollection.Add(new DBParameter("@MinPasswordAge", settings.MinPasswordAge, DbType.Int32));
            paramCollection.Add(new DBParameter("@MaxPasswordAge", settings.MaxPasswordAge, DbType.Int32));
            paramCollection.Add(new DBParameter("@EnableComplexPassword", settings.EnableComplexPassword, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Setting_Password_UPDATE", paramCollection, CommandType.StoredProcedure);
            //IDbCommand command = Dbhelper.GetCommand("GLOBAL_SystemSecuritySettings_UPDATE", paramCollection, CommandType.StoredProcedure);

            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId != 0)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public void UpdateCompanyPrintReportTemplate(int companyId, int imgPosition, string imgName, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", companyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ImagePosition", imgPosition, DbType.Int32));
            paramCollection.Add(new DBParameter("@ImageName", imgName));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Setting_Company_Print_Template_Update", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId > 0)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void RemoveCompanyPrintReportTemplate(int companyId, int imgPosition, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@CompanyId", companyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ImagePosition", imgPosition, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Setting_Company_Print_Template_Delete", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId > 0)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public int UpdatePage(SysPageFrom page, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PageId", page.PageId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", page.Name));
            paramCollection.Add(new DBParameter("@DisplayName", page.DisplayName));
            paramCollection.Add(new DBParameter("@Description", page.Description));
            paramCollection.Add(new DBParameter("@CategoryId", page.CategoryId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ViewOnly", page.ViewOnly, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasInsertOperation", page.HasInsertOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasUpdateOperation", page.HasUpdateOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasDeleteOperation", page.HasDeleteOperation, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsActive", page.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AccessTypeId", page.AccessTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Page_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("page_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public void UpdateGroupPermission(GroupPermission permission, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@GroupId", permission.GroupId, DbType.Int32));
            paramCollection.Add(new DBParameter("@HasCostView", permission.HasCostView));
            paramCollection.Add(new DBParameter("@AuthorizePages", permission.AuthorizePages));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_GroupPermission_UPDATE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public int UpdatePaymentTerms(PaymentTermsClass paymentterms, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PaymentTermsId", paymentterms.PaymentTermsId, DbType.Int32));
            paramCollection.Add(new DBParameter("@PaymentName", paymentterms.PaymentName));
            paramCollection.Add(new DBParameter("@DaysDue", paymentterms.DaysDue, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsActive", paymentterms.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Payment_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("payment_terms_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateDocumentInformaion(DocumentClass doc, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DocTypeId", doc.DocTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@NextNumber", doc.NextNumber, DbType.Int32));
            paramCollection.Add(new DBParameter("@MinDigits", doc.MinDigits, DbType.Int32));
            paramCollection.Add(new DBParameter("@Prefix", doc.Prefix));
            paramCollection.Add(new DBParameter("@Suffix", doc.Suffix));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_DocInformation_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdatePaymentMethod(PaymentMethodClass method, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PaymentMethodId", method.PaymentMethodId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", method.Name));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_PaymentMethod_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("payment_method_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateUnitOfMeasure(UnitOfMeasure unit, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@UomId", unit.UomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", unit.UnitName));
            paramCollection.Add(new DBParameter("@Code", unit.UnitCode));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Uom_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("uom_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public void UpdateUnitOfMeasureConversionRule(UnitOfMeasureConversionRule uom, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ConversionId", uom.ConversionId, DbType.Int32));
            paramCollection.Add(new DBParameter("@FromUomId", uom.FromUomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ToUomId", uom.ToUomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UomFactor", uom.UomFactor, DbType.Decimal));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Uom_ConversionRule_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("uom_conversion_update_duplicate");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public int UpdateLocation(Location location, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Locationid", location.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", location.LocationName));
            paramCollection.Add(new DBParameter("@StoreCode", location.StoreCode));
            paramCollection.Add(new DBParameter("@StoreKeeper", location.StoreKeeper));
            paramCollection.Add(new DBParameter("@IsReceivedGoods", location.IsReceivedGoods, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsDeliveryGoods", location.IsDeliveryGoods, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsConsigned", location.IsConsigned, DbType.Boolean));
            paramCollection.Add(new DBParameter("@HasCost", location.HasCost, DbType.Boolean));
            paramCollection.Add(new DBParameter("@IsActive", location.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Location_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("location_update_duplicate");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateDocumentTemplate(DocumentTemplateClass doc, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@CompanyId", doc.CompanyId, DbType.Int32));
            paramCollection.Add(new DBParameter("@DocTypeId", doc.DocTypeId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Remark1", doc.Remark1));
            paramCollection.Add(new DBParameter("@Remark2", doc.Remark2));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_DocTempalte_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
            return i;
        }

        public int UpdateDepartment(Department department, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DepartmentId", department.DepartmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", department.Name));
            paramCollection.Add(new DBParameter("@Description", department.Description));
            paramCollection.Add(new DBParameter("@Remark", department.Remark));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Department_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("department_update_duplicate");
                    break;
                case 2:
                    rMessage = GeneralResources.GetStringFromResources("department_update_failed");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateRole(Role role, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@RoleId", role.RoleId, DbType.Int32));
            paramCollection.Add(new DBParameter("@Name", role.Name));
            paramCollection.Add(new DBParameter("@Description", role.Description));
            paramCollection.Add(new DBParameter("@Remark", role.Remark));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Role_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMessage = GeneralResources.GetStringFromResources("department_update_duplicate");
                    break;
                case -1:
                    rMessage = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
            return i;
        }

        public int UpdateLocationsAssignment(int rawMaterialLocationId, int productionLocationId, int finishMaterialLocationId, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@RawMaterialStore", rawMaterialLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@ProductionStore", productionLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@FinishMaterialStore", finishMaterialLocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Location_Assignment_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return i;
        }

        //****************************************************************************************************************************//DELETE

        public void DeletePage(int pageId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@PageId", pageId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Page_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("page_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteUnitOfMeasure(int uomId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@UomId", uomId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_Uom_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 0: // no error found
                    break;
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("uom_delete_failed");
                    rMsgId = 4;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("uom_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
                default:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteDepartment(int departmentId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DepartmentId", departmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Department_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("department_delete_failed");
                    rMsgId = 4;
                    break;
                case 2:
                    rMsg = GeneralResources.GetStringFromResources("department_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteRole(int roleId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@RoleId", roleId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("GLOBAL_Role_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("role_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}