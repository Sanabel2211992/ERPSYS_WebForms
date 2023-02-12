using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Members;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.t
{
    public partial class Add_Sub_Category : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetItemLookupTables();
        }
        public void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlCategoryGet.DataTextField = "Name";
            ddlCategoryGet.DataValueField = "CategoryId";
            ddlCategoryGet.DataSource = lookup.GetItemCategory();
            ddlCategoryGet.DataBind();
            ddlCategoryGet.Items.Insert(0, new ListItem("-- All --", "-1"));
        }
        private void SubItemCatAdd()
        {
            ItemCategory subCategory = new ItemCategory();

            subCategory.Name = txtNameSubCategory.Text.ToTrimString();
            subCategory.ParentCategoryId = ddlCategoryGet.SelectedItem.Value.ToInt();

            string rMessage;
            _item.AddSubCategory(subCategory, out rMessage);

            txtNameSubCategory.Text = string.Empty;

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
        }
        protected void btnSaveSubCategory_Click(object sender, EventArgs e)
        {
            try
            {
                SubItemCatAdd();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        //************************************** Properties ************************************//
        public string Name
        {
            get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
            set { ViewState["Name"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }

    }
}