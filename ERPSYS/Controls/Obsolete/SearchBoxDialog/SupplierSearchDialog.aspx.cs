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
    public partial class SupplierSearchDialog : System.Web.UI.Page
    {
        //readonly ClsSupplier _clsSupplier = new ClsSupplier();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Page_PreRender(object o, EventArgs e)
        //{
        //    rgvSupplier.MasterTableView.GetColumn("SupplierId").Display = false;
        //}  

        //protected void BindData()
        //{
        //    rgvSupplier.Rebind();
        //}
        //protected void GetData()
        //{
        //    try
        //    {
        //        string supplierName = txtSupplierName.Text;
        //        //rgvSupplier.DataSource = _clsSupplier.GetSupplierListDataTable(supplierName);
        //    }
        //    catch(Exception)
        //    {
        //        //AppNotification.MessageBoxException(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.XConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindData();
        //}

        //protected void rgvSupplier_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if (e.Item is GridPagerItem)
        //    {
        //        RadComboBox combo = (RadComboBox) e.Item.FindControl("PageSizeComboBox");
        //        combo.Visible = false;
        //    }
        //}
        //protected void rgvSupplier_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    GetData();
        //}

        //protected void rgvSupplier_Init(object sender, EventArgs e)
        //{
        //    var grid = (RadGrid)sender;
        //    //grid.PageSize = ClsCommonMember.XGridPageDialogSize;
        //}
    }
}