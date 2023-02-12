using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.Controls.SearchBoxDialog
{
    public partial class UCItemSearchAdvanced : System.Web.UI.UserControl
    {
        //readonly ClsItem _clsItem = new ClsItem();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void rsbItem_Load(object sender, EventArgs e)
        //{
        //    rsbItem.DataSource =  new DataTable();
        //}
        //protected void rsbItem_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        //{
        //   // rsbItem.DataSource =_clsItem.GetItemSearchBoxDataTable(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        //}
        //protected void rsbItem_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        //{
        //    hfItemID.Value = e.Value;
        //    //hfItemName.Value = e.Text;
        //    lblPartNumber.Text = ((Dictionary<string, object>)e.DataItem)["PartNumber"].ToString();
        //    lblCatalogNumber.Text = ((Dictionary<string, object>)e.DataItem)["CatalogNumber"].ToString();
        //    lblSKU.Text = ((Dictionary<string, object>)e.DataItem)["SKU"].ToString();
        //    lblBrand.Text = ((Dictionary<string, object>)e.DataItem)["Brand"].ToString();
        //    lblStorageUnit.Text = ((Dictionary<string, object>)e.DataItem)["StorageUnit"].ToString();
        //    lblMainType.Text = ((Dictionary<string, object>)e.DataItem)["MainType"].ToString();
        //}

        //public void ClearFields()
        //{
        //    //hfItemID.Value = string.Empty;
        //    //hfItemName.Value = string.Empty;
        //    //rsbItem.Text = string.Empty;
        //    //hfSKU.Value = string.Empty;
        //    //hfCatalogNumber.Value = string.Empty;
        //    //hfPartNumber.Value = string.Empty;
        //}

        ////public int ItemID
        ////{
        ////    get { return hfItemID.Value.XConvertToInteger(); }
        ////}
        ////public string Description
        ////{
        ////    get { return hfItemName.Value; }
        ////}
        ////public string SKU
        ////{
        ////    get { return hfSKU.Value; ; }
        ////}
        ////public string CatalogNumber
        ////{
        ////    get { return hfCatalogNumber.Value; ; }
        ////}
        ////public string PartNumber
        ////{
        ////    get { return hfPartNumber.Value; }
        ////}
        ////public int StorageUnitID
        ////{
        ////    get { return hfStorageUnitID.Value.ConvertToInteger(); }
        ////}
    }
}