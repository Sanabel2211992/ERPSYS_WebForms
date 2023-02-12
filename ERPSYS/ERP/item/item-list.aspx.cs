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
    public partial class ItemList : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetItemLookupTables();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_update_success"));
                        break;
                    case "3":
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_delete_success"));
                        break;

                       }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            try
            {
                DataSet ds = _item.GetItemLookupTables();

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
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgItemList.Rebind();
        }

        private DataTable GetData()
        {
            try
            {
                return _item.GetItemList(Description, ItemCode, PartNumber, TypeId, CategoryId, BrandId, IsManufacture, IsNonStandard);
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

        protected void rgItemList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            // //   item["Delete"].Visible = RegisteredUser.HasAdministratorView; // system administrator has permission to view delete option
            //}  
        }

        protected void rgItemList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgItemList.DataSource = GetData();
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "export":
                    ExportToExcelFile();
                    break;
                case "add":
                    Response.Redirect("~/ERP/item/item-form.aspx", false);
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
                dt.Columns.Remove("ItemType");
                dt.Columns.Remove("IsActive");
                dt.Columns.Remove("SubCategoryName");
                dt.Columns.Remove("UomName");

                dt.Columns["PartNumber"].ColumnName = "Part Number";
                dt.Columns["ItemCode"].ColumnName = "Catalog Number";
                dt.Columns["CategoryName"].ColumnName = "Category";
                dt.Columns["BrandName"].ColumnName = "Brand";

                excel.ExportExcel(dt, ExcelType.Xls, "Products List", "Products_List");
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
                IsManufacture = cbIsManufacture.Checked;
                IsNonStandard = cbIsNonStandard.Checked;

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //protected void lnkbtnAddItem_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/ERP/item/item-form.aspx", false);
        //}

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

        public bool IsManufacture
        {
            get { return ViewState["IsManufacture"] != null && ViewState["IsManufacture"].ToBool(); }
            set { ViewState["IsManufacture"] = value; }
        }

        public bool IsNonStandard
        {
            get { return ViewState["IsNonStandard"] != null && ViewState["IsNonStandard"].ToBool(); }
            set { ViewState["IsNonStandard"] = value; }
        }
    }
}