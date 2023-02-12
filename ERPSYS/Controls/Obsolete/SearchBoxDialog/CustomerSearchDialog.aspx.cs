using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.Controls.SearchBoxDialog
{
    public partial class CustomerSearchDialog : System.Web.UI.Page
    {
        //readonly ClsCustomer _clsCustomer = new ClsCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Page_PreRender(object o, EventArgs e)
        //{
        //    rgvCustomer.MasterTableView.GetColumn("CustomerId").Display = false;
        //}
        //protected void BindData()
        //{
        //    rgvCustomer.Rebind();
        //}
        //protected void GetData()
        //{
        //    try
        //    {
        //        string supplierName = txtCustomerName.Text;
        //        //rgvCustomer.DataSource = _clsCustomer.GetCustomerListDataTable(supplierName);
        //    }
        //    catch(Exception)
        //    {
        //        //AppNotification.MessageBoxException(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindData();
        //}
        //protected void rgvCustomer_Init(object sender, EventArgs e)
        //{
        //    var grid = (RadGrid)sender;
        //    //grid.PageSize = ClsCommonMember.XGridPageDialogSize;
        //}

        //protected void rgvCustomer_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if(e.Item is GridPagerItem)
        //    {
        //        RadComboBox combo = (RadComboBox)e.Item.FindControl("PageSizeComboBox");
        //        combo.Visible = false;
        //    }
        //}
        //protected void rgvCustomer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    GetData();
        //}
    }
}