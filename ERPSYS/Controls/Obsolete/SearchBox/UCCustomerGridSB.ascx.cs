using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using Telerik.Web.UI;

namespace ERPSYS.Controls.SearchBox
{
    public partial class UCCustomerGridSB : UserControl
    {
        //readonly ClsCustomer _clsCustomer = new ClsCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = _clsCustomer.GetCustomerDDL((TextBox1.Text)); 
            //GetDataTable("SELECT CompanyName FROM [Customers] Where CompanyName LIKE '" + TextBox1.Text + "%'");
        } 
 
        protected void raManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if(e.Argument.IndexOf("FilterGrid", StringComparison.Ordinal) != -1)
            {
                RadGrid1.Rebind();
            }
        }
    }
}