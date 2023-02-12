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
    public partial class UCCustomerSearch : System.Web.UI.UserControl
    {
        //readonly ClsCustomer _clsCustomer = new ClsCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void rsbCustomer_Load(object sender, EventArgs e)
        //{
        //    rsbCustomer.DataSource =  new DataTable();
        //}
        //protected void rsbCustomer_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        //{
        //    //rsbCustomer.DataSource =_clsCustomer.GetCustomerSearchBoxDataTable(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        //}

        //protected void rsbCustomer_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        //{
        //    hfCustomerID.Value = e.Value;
        //    hfCustomerName.Value = e.Text;
        //}
        //public void ClearFields()
        //{
        //    hfCustomerID.Value = string.Empty;
        //    hfCustomerName.Value = string.Empty;
        //}

        ////public int CustomerID
        ////{
        ////    get { return hfCustomerID.Value.XConvertToInteger(); }
        ////}
        //public string CustomerName
        //{
        //    get { return hfCustomerName.Value; }
        //}
    }
}