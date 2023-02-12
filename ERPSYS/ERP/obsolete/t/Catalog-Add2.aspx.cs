using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.t
{
    public partial class Catalog_Add2 : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();
       protected void Page_Load(object sender, EventArgs e)
        {
            GetItemLookupTables();
        }
        public void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = lookup.GetItemCategory();
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
        }
        //private void ItemCatAdd()
        //{
        //    ItemCategory category = new ItemCategory();

        //    category.Name = txtName.Text.ToTrimString();
        //    //category.Code = txtCode.Text.ToTrimString();
        //    //category.IsActive = cbIsActive.Checked.ToBool();

        //    string rMessage;
        //    _item.AddCategory(category, out rMessage);

        //    txtName.Text = string.Empty;
        //    //txtCode.Text = string.Empty;

        //    GetItemLookupTables();

        //    if (rMessage != string.Empty)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }
        //}
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ItemCatAdd();            
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        protected void MyUserControl1_FinishClicked(object sender, EventArgs e)
        {
            GetItemLookupTables();
        }
        //************************************** Properties ************************************//

        //public string Name
        //{
        //    get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
        //    set { ViewState["Name"] = value; }
        //}

        //public int CategoryId
        //{
        //    get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
        //    set { ViewState["CategoryId"] = value; }
        //}

       
    }
}