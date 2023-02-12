using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.t
{
    public partial class ItemSearch : System.Web.UI.Page
    {
       //readonly SanabelBLL _item = new SanabelBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            //GetItemLookupTables();
        }
        //public void GetItemLookupTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlLocationGet.DataTextField = "Name";
        //    ddlLocationGet.DataValueField = "LocationId";
        //    ddlLocationGet.DataSource = lookup.GetLocation();
        //    ddlLocationGet.DataBind();
        //    ddlLocationGet.Items.Insert(0, new ListItem("-- All --", "-1"));
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Description = txtDescription.Text.ToTrimString();
        //        ItemCode = txtItemCode.Text.ToTrimString();
        //        PartNumber = txtPartNumber.Text.ToTrimString();
        //        LocationId = ddlLocationGet.SelectedValue.ToInt();

        //        rgItems.DataSource = _item.GetItemStockDialog(ItemCode, PartNumber, Description, 1);
        //        rgItems.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
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
        //public int LocationId
        //{
        //    get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : -1; }
        //    set { ViewState["LocationId"] = value; }
        //}
    }
}