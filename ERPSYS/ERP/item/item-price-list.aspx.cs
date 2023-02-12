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
    public partial class ItemPriceList : System.Web.UI.Page
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
            LookupBLL lookup = new LookupBLL();

            DataSet ds = lookup.GetItemPriceListLookup();

            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "ItemTypeId";
            ddlType.DataSource = ds.Tables[0];
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = ds.Tables[1];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataSource = ds.Tables[2];
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgItemList.Rebind();
        }

        private DataTable GetData()
        {
            try
            {
                return _item.GetItemPriceList(Description, ItemCode, PartNumber, TypeId, CategoryId, BrandId, ShowAvailableOnly);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void rgItemList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgItemList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
             rgItemList.DataSource  = GetData();
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
                dt.Columns.Remove("UomCode");
                dt.Columns.Remove("ItemType");

                dt.Columns["ItemCode"].ColumnName = "Catalog Number";
                dt.Columns["CategoryCode"].ColumnName = "Category";
                dt.Columns["BrandCode"].ColumnName = "Brand";
                dt.Columns["SellingPrice"].ColumnName = "Unit Price";
                dt.Columns["AvailableQuantity"].ColumnName = "Store Quantity";

                excel.ExportExcel(dt, ExcelType.Xls, "Products Price", "Products_Price");
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
                TypeId = ddlType.SelectedValue.ToInt();
                CategoryId = ddlCategory.SelectedValue.ToInt();
                BrandId = ddlBrand.SelectedValue.ToInt();
                ShowAvailableOnly = cbAvailableOnly.Checked;

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

        public int TypeId
        {
            get { return ViewState["TypeId"] != null ? ViewState["TypeId"].ToInt() : -1; }
            set { ViewState["TypeId"] = value; }
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

        public bool ShowAvailableOnly
        {
            get { return ViewState["ShowAvailableOnly"] != null && ViewState["ShowAvailableOnly"].ToBool(); }
            set { ViewState["ShowAvailableOnly"] = value; }
        }
    }
}