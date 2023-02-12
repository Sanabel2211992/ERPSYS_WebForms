using System;

namespace ERPSYS.Controls.Obsolete.HierarchyItems.Quote
{
    public partial class UCMainItemAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void rblMainItemType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rblMainItemType.SelectedValue == "Single")
        //    {
        //        pnlSingle.Visible = true;
        //        pnlGroup.Visible = false;
        //        ResetFields();
        //    }
        //    else if (rblMainItemType.SelectedValue == "Group")
        //    {
        //        pnlSingle.Visible = false;
        //        pnlGroup.Visible = true;
        //        ResetFields();
        //    }
        //}

        //protected void rsbItem_Load(object sender, EventArgs e)
        //{
        //    rsbItem.DataSource = new DataTable();
        //}

        //protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        //{
        //    ItemBLL item = new ItemBLL();
        //    const int categoryId = -1;
        //    const int brandId = -1;
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
        //        txtItemUnitPrice.Text = ((Dictionary<string, object>)e.DataItem)["UnitPrice"].ToDecimal().ToString();
        //        txtItemProfit.Text = "0".ToDecimalFormat();
        //        txtItemDiscount.Text = "0".ToDecimalFormat();
        //        txtItemQuantity.Text = "1".ToDecimal(0).ToString();
        //    }
        //}

        //public void ResetFields()
        //{
        //    txtGroupItemQuantity.Text = "1".ToDecimal(0).ToString();

        //    txtItemUnitPrice.Text = "0".ToDecimalFormat();
        //    txtItemProfit.Text = "0".ToDecimalFormat();
        //    txtItemDiscount.Text = "0".ToDecimalFormat();
        //    txtItemQuantity.Text = "1".ToDecimal(0).ToString();
        //}

        //protected void cvItem_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        //{
        //    if (hfItemID.Value.ToInt() <=0)
        //    {
        //        args.IsValid = false;
        //    }
        //}

        ////************************************** Properties ************************************//

        //private string ItemType
        //{
        //    get { return rblMainItemType.SelectedValue; }
        //}

        //public int ItemId
        //{
        //    get { return ItemType == "Single" ? hfItemID.Value.ToInteger() : -1; }
        //}

        //public string PartNumber
        //{
        //    get { return ItemType == "Single" ? txtItemPartNumber.Text : ""; }
        //}

        //public string ItemCode
        //{
        //    get { return ItemType == "Single" ? txtItemCode.Text : ""; }
        //}

        //public string DescriptionAs
        //{
        //    get { return ItemType == "Single" ? txtItemDescriptionAs.Text.ToTrimString() : txtGroupItemDescription.Text.ToTrimString(); }
        //}

        //public decimal UnitPrice
        //{
        //    get { return ItemType == "Single" ? txtItemUnitPrice.Text.ToDecimal() : "0".ToDecimal(); }
        //}

        //public decimal Profit
        //{
        //    get { return ItemType == "Single" ? txtItemProfit.Text.ToDecimal() : 0; }
        //}
        //public decimal Discount
        //{
        //    get { return ItemType == "Single" ? txtItemDiscount.Text.ToDecimal() : 0; }
        //}

        //public bool IsPercentDiscount
        //{
        //    get { return true; }
        //}

        //public decimal Quantity
        //{
        //    get { return ItemType == "Single" ? txtItemQuantity.Text.ToDecimal(2) : txtGroupItemQuantity.Text.ToDecimal(0); }
        //}

        //public object DataItem { get; set; }
    }
}