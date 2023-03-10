using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Helpers;

namespace ERPSYS.Controls.HierarchyItems.SM.SalesInvoice
{
    public partial class UCSubItemAdd : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (UserSession.RoleId == 5)
            {
                cbSpecialItem.Visible = false;
                txtItemUnitPrice.ReadOnly = true;
            }

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
        protected void rsbItem_Load(object sender, EventArgs e)
        {
            rsbItem.DataSource = new DataTable();
        }

        protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            int typeId = ddlItemType.SelectedValue.ToInt();
            int categoryId = ddlItemCategory.SelectedValue.ToInt();
            int brandId = ddlBrand.SelectedValue.ToInt();
            bool showAvailableOnly = cbAvailableOnly.Checked;
            string search = e.FilterString.Replace("%", "[%]").Replace("_", "[_]").ToTrimString();

            rsbItem.DataSource = _item.GetSalesInvoiceItemSearchBox(typeId, categoryId, brandId, showAvailableOnly, search);
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
                txtItemDescriptionAs.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
                txtItemUnitPrice.Text = ((Dictionary<string, object>)e.DataItem)["UnitPrice"].ToDecimalFormat();
                txtItemProfit.Text = "0".ToDecimalFormat();
                txtItemDiscount.Text = "0".ToDecimalFormat();
                txtItemQuantity.Text = "1".ToDecimalFormat(0);
                hfMinPrice.Value = ((Dictionary<string, object>)e.DataItem)["MinPrice"].ToDecimalFormat();                
            }
        }

        protected void cbSpecialItem_CheckedChanged(object sender, EventArgs e)
        {
            pnlSpecialItem.Visible = cbSpecialItem.Checked;
            if (cbSpecialItem.Checked)
            {
                GetItemLookupLocationTables();
            }
        }

        protected void GetItemLookupLocationTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetDeliveryReceiptLocation();
            ddlLocation.DataBind();
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
            get { return txtItemPartNumber.Text.ToTrimString(); }
        }

        public string ItemCode
        {
            get { return txtItemCode.Text.ToTrimString(); }
        }

        public string DescriptionAs
        {
            get { return txtItemDescriptionAs.Text.ToTrimString(); }
        }

        public decimal UnitPrice
        {
            get { return txtItemUnitPrice.Text.ToDecimal(); }
        }
        public decimal MinPrice
        {
            get { return hfMinPrice.Value.ToDecimal(); }
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
            get { return txtItemQuantity.Text.ToDecimal(); }
        }

        public bool IsSpecialRecord
        {
            get { return cbSpecialItem.Checked; }
        }

        public int LocationId
        {
            get { return cbSpecialItem.Checked ? ddlLocation.SelectedValue.ToInt() : -1; }
        }

        public object DataItem { get; set; }
    }
}