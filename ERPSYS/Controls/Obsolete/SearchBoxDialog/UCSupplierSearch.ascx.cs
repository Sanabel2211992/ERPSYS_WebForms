using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;


namespace ERPSYS.Controls.SearchBoxDialog
{
    public partial class UCSupplierSearch : System.Web.UI.UserControl
    {
        //readonly SupplierBLL _supplier = new SupplierBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void rsbSupplier_Load(object sender, EventArgs e)
        //{
        //    rsbSupplier.DataSource =  new DataTable();
        //}

        //protected void rsbSupplier_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        //{
        //    rsbSupplier.DataSource =_supplier.GetSupplierSearchBox(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        //}

        //protected void rsbSupplier_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        //{
        //    hfSupplierID.Value = e.Value;
        //    hfSupplierName.Value = e.Text;
        //    //string SupplierNameAr = ((Dictionary<string, object>)e.DataItem)["SupplierNameAr"].ToString();
        //}

        //public string ValidationGroup
        //{
        //    set { rfvSupplier.ValidationGroup = value; }
        //}

        //public bool CausesValidation
        //{
        //    //set { rfvSupplier.Enabled = value; }
        //    set { rfvSupplier.Enabled = false; }
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
    }
}