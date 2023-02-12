using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.Controls.SearchBoxDialog
{
    public partial class ItemSearchDialog : System.Web.UI.Page
    {
        //readonly ClsItem _clsItem = new ClsItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //InitializeItemFilters();
            }
        }
        //protected void Page_PreRender(object o, EventArgs e)
        //{
        //    rgvItems.MasterTableView.GetColumn("ItemId").Display = false;
        //}
        //private void InitializeItemFilters()
        //{
        //    try
        //    {
        //        //DataSet ds = _clsItem.GetItemFilterDDL();

        //        //ddlbrand.DataTextField = "BrandName";
        //        //ddlbrand.DataValueField = "BrandID";
        //        //ddlbrand.DataSource = ds.Tables[0];
        //        //ddlbrand.DataBind();
        //        //ddlbrand.Items.Insert(0, new DropDownListItem("All Brands", "-1"));

        //        //ddlItemMainType.DataTextField = "MainTypeName";
        //        //ddlItemMainType.DataValueField = "MainTypeID";
        //        //ddlItemMainType.DataSource = ds.Tables[1];
        //        //ddlItemMainType.DataBind();
        //        //ddlItemMainType.Items.Insert(0, new DropDownListItem("All Types", "-1"));

        //        //ddlCategoryType.DataTextField = "CategoryTypeName";
        //        //ddlCategoryType.DataValueField = "TypeID";
        //        //ddlCategoryType.DataSource = ds.Tables[2];
        //        //ddlCategoryType.DataBind();
        //        //ddlCategoryType.Items.Insert(0, new DropDownListItem("All Types", "-1"));
        //    }
        //    catch(Exception)
        //    {
        //        //AppNotification.MessageBoxException(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.ConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}
        //protected void GetData()
        //{
        //    try
        //    {
        //        int brandId = Convert.ToInt32(hfBrandId.Value);
        //        int mainTypeId = Convert.ToInt32(hfMainTypeId.Value);
        //        int categoryTypeId = Convert.ToInt32(hfTypeId.Value);
        //        //string partNumber = hfPartNumber.Value;
        //        //string sku = hfsku.Value;
        //        string itemName = hfItemName.Value;

        //        //rgvItems.DataSource = _clsItem.GetItemListDialogDataTable(brandId, mainTypeId, categoryTypeId, "", "", itemName);
        //    }
        //    catch(Exception)
        //    {
        //        //AppNotification.MessageBoxException(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.ConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}
        //protected void BindData()
        //{
        //    rgvItems.Rebind();
        //}
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    hfBrandId.Value = ddlbrand.SelectedValue;
        //    hfMainTypeId.Value= ddlItemMainType.SelectedValue;
        //    hfTypeId.Value= ddlCategoryType.SelectedValue;
        //    //hfPartNumber.Value = txtPartNumber.Text;
        //    //hfsku.Value = txtSKU.Text;
        //    hfItemName.Value = txtItemName.Text;

        //    BindData();
        //}
        //protected void rgvItems_Init(object sender, EventArgs e)
        //{
        //    var grid = (RadGrid)sender;
        //    //grid.PageSize = ClsCommonMember.XGridPageDialogSize;
        //}

        //protected void rgvItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    GetData();
        //}
    }
}