using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.t
{
    public partial class ItemSearchJobOrder : System.Web.UI.Page
    {
        //readonly SanabelBLL _item = new SanabelBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void GetData()
        //{
        //    try
        //    {
        //        rgItems.DataSource = _item.GetItemJobOrderDialog(ItemCode, PartNumber, Description, ShowAvailableOnly);
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void BindData()
        //{
        //    rgItems.Rebind();
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Description = txtDescription.Text.ToTrimString();
        //        ItemCode = txtItemCode.Text.ToTrimString();
        //        PartNumber = txtPartNumber.Text.ToTrimString();
        //        ShowAvailableOnly = cbAvailableOnly.Checked;

        //        BindData();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void rgItems_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    GetData();
        //}

        ////************************************** Properties ************************************//
        //public string Description
        //{
        //    get { return ViewState["Description"] != null ? ViewState["Description"].ToString() : ""; }
        //    set { ViewState["Description"] = value; }
        //}

        //public string ItemCode
        //{
        //    get { return ViewState["ItemCode"] != null ? ViewState["ItemCode"].ToString() : ""; }
        //    set { ViewState["ItemCode"] = value; }
        //}

        //public string PartNumber
        //{
        //    get { return ViewState["PartNumber"] != null ? ViewState["PartNumber"].ToString() : ""; }
        //    set { ViewState["PartNumber"] = value; }
        //}

        //public bool ShowAvailableOnly
        //{
        //    get { return ViewState["ShowAvailableOnly"] != null && ViewState["ShowAvailableOnly"].ToBool(); }
        //    set { ViewState["ShowAvailableOnly"] = value; }
        //}
    }
}