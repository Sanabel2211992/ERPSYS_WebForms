using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.HierarchyItems.MAN.Material
{
    public partial class UCItemAdd : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                if (ddlCategory.Items.Count == 0)
                {
                    GetItemLookupTables();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            DataSet ds = _item.GetItemLookupTables();

            ddlItemType.DataTextField = "Name";
            ddlItemType.DataValueField = "ItemTypeId";
            ddlItemType.DataSource = ds.Tables[0];
            ddlItemType.DataBind();

            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = ds.Tables[1];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataSource = ds.Tables[2];
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        protected void GetSubCategory(int categoryId)
        {
            ddlSubCategory.DataTextField = "Name";
            ddlSubCategory.DataValueField = "CategoryId";
            ddlSubCategory.DataSource = _item.GetSubCategoryList(categoryId);
            ddlSubCategory.DataBind();

            ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue.ToInt() <= 0)
                return;

            GetSubCategory(ddlCategory.SelectedValue.ToInt());
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            int typeId = ddlItemType.SelectedValue.ToInt();
            int categoryId = ddlCategory.SelectedValue.ToInt();
            int subCategoryId = ddlSubCategory.SelectedValue.ToInt();
            int brandId = ddlBrand.SelectedValue.ToInt();
            string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

            rsbItem.DataSource = _item.GetItemBomSearchBox2(typeId, categoryId, subCategoryId, brandId, search);
        }

        protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                txtStockQuantity.Text = ((Dictionary<string, object>)e.DataItem)["StockQuantity"].ToDecimalFormat(0);
                txtItemQuantity.Text = "1".ToDecimalFormat(0);
            }
        }

        public void ResetFields()
        {
            txtItemQuantity.Text = "1".ToDecimalFormat(0);
        }

        protected void cvItem_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (hfItemID.Value.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(3); }
        }

        public object DataItem { get; set; }
    }
}