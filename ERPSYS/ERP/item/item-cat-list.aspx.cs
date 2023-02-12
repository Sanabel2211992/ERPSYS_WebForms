using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.item
{
    public partial class ItemCategoryList : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_cat_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_cat_has_item"));
                        break;
                    case "41":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_cat_has_subcat"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void ReBindData()
        {
            rgCategoryList.Rebind();
        }

        protected void rgCategoryList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgCategoryList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetCategoryList();
        }

        private void GetCategoryList()
        {
            try
            {
                rgCategoryList.DataSource = _item.GetCategoryList(Category, SubCategory);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Category = txtCategory.Text.ToTrimString();
                SubCategory = txtSubCategory.Text.ToTrimString();

                ReBindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("item-cat-form.aspx");
        }

        //************************************** Properties ************************************//

        public string Category
        {
            get { return ViewState["Category"] != null ? ViewState["Category"].ToString() : ""; }
            set { ViewState["Category"] = value; }
        }

        public string SubCategory
        {
            get { return ViewState["SubCategory"] != null ? ViewState["SubCategory"].ToString() : ""; }
            set { ViewState["SubCategory"] = value; }
        }
    }
}