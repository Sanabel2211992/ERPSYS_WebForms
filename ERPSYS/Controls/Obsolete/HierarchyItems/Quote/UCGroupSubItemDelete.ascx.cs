using System;

namespace ERPSYS.Controls.Obsolete.HierarchyItems.Quote
{
    public partial class UCGroupSubItemDelete : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //protected void rsbItem_Load(object sender, EventArgs e)
        //{
        //    rsbItem.DataSource = new DataTable();
        //}

        //protected void rsbItem_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        //{
        //    ItemBLL item = new ItemBLL();
        //    rsbItem.DataSource = item.oldGetSalesQuoteItemSearchBoxByQuote(Request.QueryString["id"].ToInt(), e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));

        //}

        //protected void rsbItem_Search(object sender, SearchBoxEventArgs e)
        //{
        //    if (e.Value != null)
        //    {
        //        hfItemID.Value = e.Value;
        //        txtItemDescription.Text = ((Dictionary<string, object>)e.DataItem)["Description"].ToString();
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
        //}

        ////************************************** Properties ************************************//

        //public int ItemID
        //{
        //    get { return hfItemID.Value.ToInteger(); }
        //}
    }
}