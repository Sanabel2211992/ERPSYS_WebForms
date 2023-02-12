using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.Supplier
{
    public partial class UCSupplier : System.Web.UI.UserControl
    {
        readonly SupplierBLL _supplier = new SupplierBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //rsbSupplier.DataSource = GetData();
        }

        ////protected void rsbSupplier_Load(object sender, EventArgs e)
        ////{
        ////    rsbSupplier.DataSource =  new DataTable();
        ////}
        ////private  DataTable GetData()
        ////{
        ////    DataTable data = _supplier.GetSupplierSearchBox(FilterString);
        
        ////    return data;
        ////}
        //protected void rsbSupplier_Load(object sender, EventArgs e)
        //{
        //    rsbSupplier.DataSource =  new DataTable();
        //}

        //protected void rsbSupplier_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        //{
        //    //FilterString = e.FilterString.Replace("%", "[%]").Replace("_", "[_]");

        //    //txtSupplierID.Text = "";
        //    //txtSupplierName.Text = "";
        //    rsbSupplier.DataSource =_supplier.GetSupplierSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        //}

        //protected void rsbSupplier_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        //{
        //    if (e.DataItem != null)
        //    {
        //        hfSupplierID.Value = e.Value;
        //        hfSupplierName.Value = e.Text;
        //        txtSupplierID.Text = e.Value;
        //        txtSupplierName.Text = e.Text;
        //        //string SupplierNameAr = ((Dictionary<string, object>)e.DataItem)["SupplierNameAr"].ToString();
        //    }  
        //}

        //public string ValidationGroup
        //{
        //    set { rfvSupplier.ValidationGroup = value; }
        //}

        //public bool CausesValidation
        //{
        //    set { rfvSupplier.Enabled = value; }
        //}

        //public void ClearFields()
        //{
        //    hfSupplierID.Value = string.Empty;
        //    hfSupplierName.Value = string.Empty;
        //}

        //public int SupplierID
        //{
        //    get { return hfSupplierID.Value.ToInt(); }
        //    set { hfSupplierID.Value = value.ToString(); }
        //}

        //public string SupplierName
        //{
        //    get { return hfSupplierName.Value; }
        //    set { hfSupplierName.Value = value; rsbSupplier.Text = value; }
        //}

        ////protected void rsbSupplier_PreRender(object sender, EventArgs e)
        ////{

        ////}

        //public string FilterString
        //{
        //    get { return ViewState["FilterString"] != null ? ViewState["FilterString"].ToString() : ""; }
        //    set { ViewState["FilterString"] = value; }
        //}
    }
}