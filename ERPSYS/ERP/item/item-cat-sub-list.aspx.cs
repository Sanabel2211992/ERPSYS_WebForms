using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.item
{
    public partial class ItemCategorySubList : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetCategoryDetails(Request.QueryString["id"].ToInt());
                    ShowMessages();
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_cat_sub_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_cat_sub_delete_failed"));
                        break;

                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_sub_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_sub_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_cat_sub_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetCategoryDetails(int categoryId)
        {
            ItemCategory category = _item.GetCategoryDetails(categoryId);

            if (category.CategoryId <= 0)
            {
                Response.Redirect("item-cat.aspx?e=1", false);
            }

            MainCategoryId = category.CategoryId;
            lblMainCategory.Text = category.Name;
            lblMainCategoryCode.Text = category.Code;
        }

        protected void rgSubCategoryList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgSubCategoryList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetSubCategoryList();
        }

        private void GetSubCategoryList()
        {
            try
            {
                rgSubCategoryList.DataSource = _item.GetSubCategoryList(MainCategoryId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-cat-sub-form.aspx?mid={0}", MainCategoryId));
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-cat-list.aspx"));
        }

        //************************************** Properties ************************************//

        public int MainCategoryId
        {
            get { return ViewState["MainCategoryId"] != null ? ViewState["MainCategoryId"].ToInt() : -1; }
            set { ViewState["MainCategoryId"] = value; }
        }
    }
}