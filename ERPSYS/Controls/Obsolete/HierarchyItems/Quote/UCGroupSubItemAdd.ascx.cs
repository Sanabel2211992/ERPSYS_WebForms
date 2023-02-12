using System;

namespace ERPSYS.Controls.Obsolete.HierarchyItems.Quote
{
    public partial class UCGroupSubItemAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
        }

        //public void InitializeComponent()
        //{
        //    if (ddlItemCategory.Items.Count == 0)
        //    {
        //        GetItemLookupTables();

        //        txtItemUnitPrice.Text = "0".ToDecimalFormat();
        //        txtItemProfit.Text = "0".ToDecimalFormat();
        //        txtItemDiscount.Text = "0".ToDecimalFormat();
        //        txtItemQuantity.Text = "1".ToDecimalFormat(2);
        //    }
        //}

        //protected void GetItemLookupTables()
        //{
        //    try
        //    {
        //        LookupBLL lookup = new LookupBLL();

        //        ddlItemCategory.DataTextField = "Name";
        //        ddlItemCategory.DataValueField = "CategoryId";
        //        ddlItemCategory.DataSource = lookup.GetItemCategory();
        //        ddlItemCategory.DataBind();
        //        ddlItemCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));

        //        ddlItemBrand.DataTextField = "Name";
        //        ddlItemBrand.DataValueField = "BrandId";
        //        ddlItemBrand.DataSource = lookup.GetItemBrand();
        //        ddlItemBrand.DataBind();
        //        ddlItemBrand.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void rsbItem_Load(object sender, EventArgs e)
        //{
        //    rsbItem.DataSource = new DataTable();
        //}

        //protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        //{
        //    ItemBLL item = new ItemBLL();
        //    int categoryId = ddlItemCategory.SelectedValue.ToInt();
        //    int brandId = ddlItemBrand.SelectedValue.ToInt();
        //    rsbItem.DataSource = item.oldGetSalesQuoteItemSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"), categoryId, brandId);

        //}

        //protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        //{
        //    if (e.Value != null)
        //    {
        //        hfItemID.Value = e.Value;
        //        txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
        //        txtItemPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
        //        txtItemCode.Text = ((Dictionary<string, object>)e.DataItem)["ItemCode"].ToString();

        //        txtItemDescriptionAs.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
        //        txtItemUnitPrice.Text = ((Dictionary<string, object>)e.DataItem)["UnitPrice"].ToDecimalFormat();
        //    }
        //}

        //protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        //{
        //    if (hfItemID.Value.ToInt() <= 0)
        //    {
        //        args.IsValid = false;
        //    }
        //}

        //public void ClearFields()
        //{
        //    hfItemID.Value = string.Empty;
        //    txtItemDescription.Text = string.Empty;
        //    rsbItem.Text = string.Empty;
        //    txtItemPartNumber.Text = string.Empty;
        //    txtItemCode.Text = string.Empty;
        //    txtItemDescriptionAs.Text = string.Empty;
        //    txtItemUnitPrice.Text = "0".ToDecimalFormat();
        //    txtItemProfit.Text = "0".ToDecimalFormat();
        //    txtItemDiscount.Text = "0".ToDecimalFormat();
        //    txtItemQuantity.Text = "1".ToDecimalFormat(2);
        //}

        ////************************************** Properties ************************************//

        //public int ItemID
        //{
        //    get { return hfItemID.Value.ToInteger(); }
        //}

        //public string PartNumber
        //{
        //    get { return txtItemPartNumber.Text; }
        //}

        //public string ItemCode
        //{
        //    get { return txtItemCode.Text; }
        //}

        //public string DescriptionAs
        //{
        //    get { return txtItemDescriptionAs.Text; }
        //}

        //public decimal UnitPrice
        //{
        //    get { return txtItemUnitPrice.Text.ToDecimal(); }
        //}

        //public decimal Profit
        //{
        //    get { return txtItemProfit.Text.ToDecimal(); }
        //}
        //public decimal Discount
        //{
        //    get { return txtItemDiscount.Text.ToDecimal(); }
        //}

        //public bool IsPercentDiscount
        //{
        //    get { return true; }
        //}

        //public decimal Quantity
        //{
        //    get { return txtItemQuantity.Text.ToDecimal(); }
        //}
    }
}