using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.import
{
    public partial class imp_excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        private DataSet ReadImport(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            if (filePath.Contains(".xlsx"))
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }

            excelReader.IsFirstRowAsColumnNames = true;
            DataSet ds = excelReader.AsDataSet();

            return ds;
        }

        //private void ReadImport22(string FilePath)
        //{
        //    try
        //    {

        //        FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
        //        IExcelDataReader excelReader;
        //        if (FilePath.Contains(".xlsx"))
        //        {
        //            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //        }
        //        else
        //        {
        //            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //        }

        //        excelReader.IsFirstRowAsColumnNames = true;
        //        DataSet ds = excelReader.AsDataSet();

        //        if (rbCustomers.Checked)
        //        {
        //            DataTable Customersdt = CustonmerTable("Customers");

        //            foreach (DataRow drt in ds.Tables[0].Rows)
        //            {

        //                var dr = Customersdt.NewRow();
        //                dr["EnglishName"] = drt["English Name"].ToString();
        //                dr["ArabicName"] = drt["Arabic Name"].ToString();
        //                dr["ContactName"] = drt["Contact Name"].ToString();
        //                dr["Phone"] = drt["Phone"].ToString();
        //                dr["Fax"] = drt["Fax"].ToString();
        //                dr["Email"] = drt["Email"].ToString();
        //                dr["Address"] = drt["Address"].ToString();
        //                dr["City"] = drt["City"].ToString();
        //                dr["Country"] = drt["Country"].ToString();

        //                Customersdt.Rows.Add(dr);
        //                //if (Customersdt != null)
        //                //{
        //                //    btnSave.Visible = true;
        //                //}
        //            }

        //            // Save Into DB
        //            DataSet Customersd = new DataSet();

        //            foreach (DataColumn column in Customersdt.Columns)
        //            {
        //                column.ColumnMapping = MappingType.Attribute;
        //            }
        //            Customersd.Tables.Add(Customersdt);
        //            string xmlobj = Customersd.GetXml();

        //            CustomerBLL _customer = new CustomerBLL();
        //            _customer.ImportCustomer(xmlobj);

        //            rgSavedData.DataSource = Customersdt;
        //            rgSavedData.DataBind();
        //        }

        //        else if (rbSuppliers.Checked)
        //        {
        //            DataTable Suppliersdt = SupplierTable("Suppliers");

        //            foreach (DataRow drt in ds.Tables[0].Rows)
        //            {

        //                var dr = Suppliersdt.NewRow();
        //                dr["EnglishName"] = drt["English Name"].ToString();
        //                dr["ArabicName"] = drt["Arabic Name"].ToString();
        //                dr["ContactName"] = drt["Contact Name"].ToString();
        //                dr["Phone"] = drt["Phone"].ToString();
        //                dr["Fax"] = drt["Fax"].ToString();
        //                dr["Email"] = drt["Email"].ToString();
        //                dr["Address"] = drt["Address"].ToString(); 
        //                dr["City"] = drt["City"].ToString();
        //                dr["Country"] = drt["Country"].ToString();

        //                Suppliersdt.Rows.Add(dr);
        //                //if (Customersdt != null)
        //                //{
        //                //    btnSave.Visible = true;
        //                //}
        //            }

        //            // Save Into DB
        //            DataSet Suppliersd = new DataSet();

        //            foreach (DataColumn column in Suppliersdt.Columns)
        //            {
        //                column.ColumnMapping = MappingType.Attribute;
        //            }
        //            Suppliersd.Tables.Add(Suppliersdt);
        //            string xmlobj = Suppliersd.GetXml();

        //            SupplierBLL _supplier = new SupplierBLL();
        //            _supplier.ImportSupplier(xmlobj);

        //            rgSavedData.DataSource = Suppliersdt;
        //            rgSavedData.DataBind();
        //        }

        //        plInteredData.Visible = true;
        //        plSavedData.Visible = true;

        //        rgInteredData.DataSource = ds.Tables[0];
        //        rgInteredData.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        private DataTable CustonmerTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("EnglishName", typeof(string)));
            dt.Columns.Add(new DataColumn("ArabicName", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactName", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone", typeof(string)));
            dt.Columns.Add(new DataColumn("Fax", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("City", typeof(string)));
            dt.Columns.Add(new DataColumn("Country", typeof(string)));

            return dt;
        }
        private DataTable SupplierTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("EnglishName", typeof(string)));
            dt.Columns.Add(new DataColumn("ArabicName", typeof(string)));
            dt.Columns.Add(new DataColumn("ContactName", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone", typeof(string)));
            dt.Columns.Add(new DataColumn("Fax", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("City", typeof(string)));
            dt.Columns.Add(new DataColumn("Country", typeof(string)));

            return dt;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuSampleUpload.HasFile)
                {
                    FileHandle fileHandle = new FileHandle();
                    FileAttachment file = fileHandle.SaveFileToTempFolder(fuSampleUpload);

                    string FileName = Path.GetFileName(fuSampleUpload.PostedFile.FileName);

                    FilePath = Server.MapPath(string.Format("{0}{1}", CommonMember.AttachmentUploadTempFolderPath, FileName));
                    fuSampleUpload.SaveAs(FilePath);
                    
                    plInteredData.Visible = true;
                    rgInteredData.DataSource = ReadImport(FilePath);
                    rgInteredData.DataBind();
                }

                else if (!fuSampleUpload.HasFile)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                    return;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnAnalyzes_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = ReadImport(FilePath);

                if (rbCustomers.Checked)
                {
                    DataTable Customersdt = CustonmerTable("Customers");

                    foreach (DataRow drt in ds.Tables[0].Rows)
                    {

                        var dr = Customersdt.NewRow();
                        dr["EnglishName"] = drt["English Name"].ToString();
                        dr["ArabicName"] = drt["Arabic Name"].ToString();
                        dr["ContactName"] = drt["Contact Name"].ToString();
                        dr["Phone"] = drt["Phone"].ToString();
                        dr["Fax"] = drt["Fax"].ToString();
                        dr["Email"] = drt["Email"].ToString();
                        dr["Address"] = drt["Address"].ToString();
                        dr["City"] = drt["City"].ToString();
                        dr["Country"] = drt["Country"].ToString();

                        Customersdt.Rows.Add(dr);
                    }
                    rgSavedData.DataSource = Customersdt;
                    rgSavedData.DataBind();
                }

                else if (rbSuppliers.Checked)
                {
                    DataTable Suppliersdt = SupplierTable("Suppliers");

                    foreach (DataRow drt in ds.Tables[0].Rows)
                    {

                        var dr = Suppliersdt.NewRow();
                        dr["EnglishName"] = drt["English Name"].ToString();
                        dr["ArabicName"] = drt["Arabic Name"].ToString();
                        dr["ContactName"] = drt["Contact Name"].ToString();
                        dr["Phone"] = drt["Phone"].ToString();
                        dr["Fax"] = drt["Fax"].ToString();
                        dr["Email"] = drt["Email"].ToString();
                        dr["Address"] = drt["Address"].ToString();
                        dr["City"] = drt["City"].ToString();
                        dr["Country"] = drt["Country"].ToString();

                        Suppliersdt.Rows.Add(dr);
                    }

                    rgSavedData.DataSource = Suppliersdt;
                    rgSavedData.DataBind();
                }
                plSavedData.Visible = true;
                rbCustomers.Enabled = false;
                rbSuppliers.Enabled = false;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = ReadImport(FilePath);

                if (rbCustomers.Checked)
                {
                    DataTable Customersdt = CustonmerTable("Customers");

                    foreach (DataRow drt in ds.Tables[0].Rows)
                    {

                        var dr = Customersdt.NewRow();
                        dr["EnglishName"] = drt["English Name"].ToString();
                        dr["ArabicName"] = drt["Arabic Name"].ToString();
                        dr["ContactName"] = drt["Contact Name"].ToString();
                        dr["Phone"] = drt["Phone"].ToString();
                        dr["Fax"] = drt["Fax"].ToString();
                        dr["Email"] = drt["Email"].ToString();
                        dr["Address"] = drt["Address"].ToString();
                        dr["City"] = drt["City"].ToString();
                        dr["Country"] = drt["Country"].ToString();

                        Customersdt.Rows.Add(dr);
                    } DataSet Customersd = new DataSet();

                    foreach (DataColumn column in Customersdt.Columns)
                    {
                        column.ColumnMapping = MappingType.Attribute;
                    }
                    Customersd.Tables.Add(Customersdt);
                    string xmlobj = Customersd.GetXml();

                    CustomerBLL _customer = new CustomerBLL();
                    _customer.ImportCustomer(xmlobj);
                    //AppNotification.MessagePanelSuccess("Done successfully");

                }

                else if (rbSuppliers.Checked)
                {
                    DataTable Suppliersdt = SupplierTable("Suppliers");

                    foreach (DataRow drt in ds.Tables[0].Rows)
                    {

                        var dr = Suppliersdt.NewRow();
                        dr["EnglishName"] = drt["English Name"].ToString();
                        dr["ArabicName"] = drt["Arabic Name"].ToString();
                        dr["ContactName"] = drt["Contact Name"].ToString();
                        dr["Phone"] = drt["Phone"].ToString();
                        dr["Fax"] = drt["Fax"].ToString();
                        dr["Email"] = drt["Email"].ToString();
                        dr["Address"] = drt["Address"].ToString();
                        dr["City"] = drt["City"].ToString();
                        dr["Country"] = drt["Country"].ToString();

                        Suppliersdt.Rows.Add(dr);
                    }

                    DataSet Suppliersd = new DataSet();

                    foreach (DataColumn column in Suppliersdt.Columns)
                    {
                        column.ColumnMapping = MappingType.Attribute;
                    }
                    Suppliersd.Tables.Add(Suppliersdt);
                    string xmlobj = Suppliersd.GetXml();

                    SupplierBLL _supplier = new SupplierBLL();
                    _supplier.ImportSupplier(xmlobj);
                    //AppNotification.MessagePanelSuccess("Done successfully");
                }

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }


        //************************************** Properties ************************************//
        private string FilePath
        {
            get { return ViewState["FilePath"] != null ? ViewState["FilePath"].ToString() : ""; }
            set { ViewState["FilePath"] = value; }
        }
    }
}