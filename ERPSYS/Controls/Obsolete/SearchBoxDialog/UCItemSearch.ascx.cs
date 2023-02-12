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
    public partial class UCItemSearch : System.Web.UI.UserControl
    {
        //readonly ItemBLL _clsItem = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void rsbItem_Load(object sender, EventArgs e)
        //{
        //    rsbItem.DataSource = new DataTable();
        //}
        //protected void rsbItem_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        //{
        //    //rsbItem.DataSource =_clsItem.GetItemSearchBoxDataTable(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        //}
        //protected void rsbItem_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        //{
        //    hfItemID.Value = e.Value;
        //    hfItemdescription.Value = e.Text;
        //}

        //public void ClearFields()
        //{
        //    hfItemID.Value = string.Empty;
        //    hfItemdescription.Value = string.Empty;
        //    rsbItem.Text = string.Empty;
        //    hfSKU.Value = string.Empty;
        //    hfCatalogNumber.Value = string.Empty;
        //    hfPartNumber.Value = string.Empty;
        //}

        ////public int ItemID
        ////{
        ////    get { return hfItemID.Value.XConvertToInteger(); }
        ////}
        //public string Description
        //{
        //    get { return hfItemdescription.Value; }
        //}
        //public string SKU
        //{
        //    get { return hfSKU.Value; ; }
        //}
        //public string CatalogNumber
        //{
        //    get { return hfCatalogNumber.Value; ; }
        //}
        //public string PartNumber
        //{
        //    get { return hfPartNumber.Value; }
        //}
        ////public int StorageUnitID
        ////{
        ////    get { return hfStorageUnitID.Value.XConvertToInteger(); }
        ////}
    }
}