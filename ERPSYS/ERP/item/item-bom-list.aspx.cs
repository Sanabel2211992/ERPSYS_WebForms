using System;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.item
{
    public partial class ItemBomList : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetItemLookupTables();
            }
        }

        protected void GetItemLookupTables()
        {
            try
            {
                DataSet ds = _item.GetItemBomLookupTables();

                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataSource = ds.Tables[0];
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandId";
                ddlBrand.DataSource = ds.Tables[1];
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgItemBomList.Rebind();
        }

        private DataTable GetData()
        {
            try
            {
                return _item.GetItemBomList(Description, ItemCode, PartNumber, CategoryId, BrandId, IsEmpty);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgItemBomList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgItemBomList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgItemBomList.DataSource = GetData();
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "export":
                    ExportToExcelFile();
                    break;
            }
        }

        protected void ExportToExcelFile()
        {
            try
            {
                ExcelHandle excel = new ExcelHandle();
                DataTable dt = GetData();

                dt.Columns.Remove("ItemId");
                dt.Columns.Remove("ItemId1");
                dt.Columns.Remove("ItemType");
                dt.Columns.Remove("SubCategoryCode");
                dt.Columns.Remove("DescriptionAs");
                dt.Columns.Remove("CategoryCode");
                dt.Columns.Remove("BrandCode");
                dt.Columns.Remove("CategoryId");
                dt.Columns.Remove("SubCategory");
                dt.Columns.Remove("Uom");

                dt.Columns["ItemCode"].ColumnName = "Catalog Number";

                excel.ExportExcel(dt, ExcelType.Xls, "Products BOM", "Products_BOM");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Description = txtDescription.Text.ToTrimString();
                ItemCode = txtItemCode.Text.ToTrimString();
                PartNumber = txtPartNumber.Text.ToTrimString();
                CategoryId = ddlCategory.SelectedValue.ToInt();
                BrandId = ddlBrand.SelectedValue.ToInt();
                IsEmpty = cbIsEmpty.Checked;

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }


        //************************************** Properties ************************************//

        public string Description
        {
            get { return ViewState["Description"] != null ? ViewState["Description"].ToString() : ""; }
            set { ViewState["Description"] = value; }
        }

        public string ItemCode
        {
            get { return ViewState["ItemCode"] != null ? ViewState["ItemCode"].ToString() : ""; }
            set { ViewState["ItemCode"] = value; }
        }

        public string PartNumber
        {
            get { return ViewState["PartNumber"] != null ? ViewState["PartNumber"].ToString() : ""; }
            set { ViewState["PartNumber"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }

        public int BrandId
        {
            get { return ViewState["BrandId"] != null ? ViewState["BrandId"].ToInt() : -1; }
            set { ViewState["BrandId"] = value; }
        }

        public bool IsEmpty
        {
            get { return ViewState["IsEmpty"] != null && ViewState["IsEmpty"].ToBool(); }
            set { ViewState["IsEmpty"] = value; }
        }
    }
}