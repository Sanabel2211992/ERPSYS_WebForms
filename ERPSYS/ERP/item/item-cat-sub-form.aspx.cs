using ERPSYS.BLL;
using System;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System.Threading;

namespace ERPSYS.ERP.item
{
    public partial class ItemCategorySubForm : System.Web.UI.Page
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
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetSubCategoryDetails(Request.QueryString["id"].ToInt());
                }
                else if (Request.QueryString["mid"] != null && Request.QueryString["mid"] != string.Empty)
                {
                    Operation = "new";
                    GetMainCategoryDetails(Request.QueryString["mid"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("item-cat-list.aspx?e={0}", 1), false);
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

        protected void GetMainCategoryDetails(int categoryId)
        {
            ItemCategory category = _item.GetCategoryDetails(categoryId);

            if (category.CategoryId <= 0)
            {
                Response.Redirect(string.Format("item-cat-list.aspx?e={0}", 1), false);
            }

            MainCategoryId = category.CategoryId;
            lbMainCategory.Text = category.Name;   
        }

        protected void GetSubCategoryDetails(int categoryId)
        {
            ItemCategory category = _item.GetSubCategoryDetails(categoryId);

            if (category.CategoryId <= 0)
            {
                Response.Redirect(string.Format("item-cat-list.aspx?e={0}", 1), false);
            }

            SubCategoryId = category.CategoryId;
            MainCategoryId = category.ParentCategoryId;
            lbMainCategory.Text = category.ParentCategory;   
            txtSubCategory.Text = category.Name;
            txtSubCategoryCode.Text = category.Code;
        }

        private void AddSubCategory()
        {
            ItemCategory category = new ItemCategory();

            category.ParentCategoryId = MainCategoryId;
            category.Name = txtSubCategory.Text.ToTrimString();
            category.Code = txtSubCategoryCode.Text.ToTrimString();

            string rMessage;
            _item.AddSubCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-cat-sub-list.aspx?id={0}&o={1}", MainCategoryId, 1), false);
        }

        private void UpdateSubCategory()
        {
            ItemCategory category = new ItemCategory();

            category.CategoryId = SubCategoryId;
            category.ParentCategoryId = MainCategoryId;
            category.Name = txtSubCategory.Text.ToTrimString();
            category.Code = txtSubCategoryCode.Text.ToTrimString();

            string rMessage;
            _item.UpdateSubCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-cat-sub-list.aspx?id={0}&o={1}", MainCategoryId, 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddSubCategory();
                }
                else if (Operation == "edit" && SubCategoryId > 0)
                {
                    UpdateSubCategory();
                }  
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-cat-sub-list.aspx?id={0}", MainCategoryId), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int MainCategoryId
        {
            get { return ViewState["MainCategoryId"] != null ? ViewState["MainCategoryId"].ToInt() : -1; }
            set { ViewState["MainCategoryId"] = value; }
        }

        public int SubCategoryId
        {
            get { return ViewState["SubCategoryId"] != null ? ViewState["SubCategoryId"].ToInt() : -1; }
            set { ViewState["SubCategoryId"] = value; }
        }
    }
}


