using System;
using System.Collections.Generic;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Helpers;
using System.Web.UI.WebControls;

namespace ERPSYS.Controls.HierarchyItems.EST.Quote
{
    public partial class UCSubItemAdd : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtItemDescription.Text = Request.Form[txtItemDescription.UniqueID];
            txtItemPartNumber.Text = Request.Form[txtItemPartNumber.UniqueID];
            txtItemCode.Text = Request.Form[txtItemCode.UniqueID];
            txtStockQuantity.Text = Request.Form[txtStockQuantity.UniqueID]; 
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ddlItemCategory.Items.Count == 0)
            {
                GetItemLookupTables();

                txtItemProfit.Text = "0".ToDecimalFormat();
                txtItemDiscount.Text = "0".ToDecimalFormat();
            }
        }

        protected void GetItemLookupTables()
        {
            try
            {
                DataSet ds = _item.GetItemLookupTables();

                ddlItemType.DataTextField = "Name";
                ddlItemType.DataValueField = "ItemTypeId";
                ddlItemType.DataSource = ds.Tables[0];
                ddlItemType.DataBind();

                ddlItemCategory.DataTextField = "Name";
                ddlItemCategory.DataValueField = "CategoryId";
                ddlItemCategory.DataSource = ds.Tables[1];
                ddlItemCategory.DataBind();
                ddlItemCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandId";
                ddlBrand.DataSource = ds.Tables[2];
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetSubCategory(int categoryId)
        {
            ddlSubCategory.Items.Clear();
            ddlSubCategory.DataTextField = "Name";
            ddlSubCategory.DataValueField = "CategoryId";
            ddlSubCategory.DataSource = _item.GetSubCategoryList(categoryId);
            ddlSubCategory.DataBind();

            ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategory(ddlItemCategory.SelectedValue.ToInt());
        }

        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            int typeId = ddlItemType.SelectedValue.ToInt();
            int categoryId = ddlItemCategory.SelectedValue.ToInt();
            int subCategoryId = ddlSubCategory.SelectedValue.ToInt();
            int brandId = ddlBrand.SelectedValue.ToInt();
            string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

            rsbItem.DataSource = _item.GetSalesQuoteItemSearchBox(typeId, categoryId, subCategoryId, brandId, search);
        }

        protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        {
            if (e.Value != null)
            {
                hfItemID.Value = e.Value;
                txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
                txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();
                txtItemDescriptionAs.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemUnitPrice.Text = ((Dictionary<string, object>)e.DataItem)["UnitPrice"].ToDecimal().ToString();
                txtStockQuantity.Text = ((Dictionary<string, object>)e.DataItem)["StockQuantity"].ToDecimalFormat(0);
                txtItemProfit.Text = "0".ToDecimalFormat();
                txtItemDiscount.Text = "0".ToDecimalFormat();
                txtItemQuantity.Text = "1".ToDecimalFormat(0);
            }
        }

        protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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

        public string PartNumber
        {
            get { return txtItemPartNumber.Text; }
        }

        public string ItemCode
        {
            get { return txtItemCode.Text; }
        }

        public string DescriptionAs
        {
            get { return txtItemDescriptionAs.Text; }
        }

        public decimal UnitPrice
        {
            get { return txtItemUnitPrice.Text.ToDecimal(); }
        }

        public decimal Profit
        {
            get { return txtItemProfit.Text.ToDecimal(); }
        }

        public decimal Discount
        {
            get { return txtItemDiscount.Text.ToDecimal(); }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(0); }
        }

        public object DataItem { get; set; }
    }
}