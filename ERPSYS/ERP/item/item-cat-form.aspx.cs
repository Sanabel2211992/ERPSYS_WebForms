using ERPSYS.BLL;
using System;
using System.Threading;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.item
{
    public partial class ItemCategoryForm : System.Web.UI.Page
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
                    GetCategoryDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
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

        protected void GetCategoryDetails(int categoryId)
        {
            try
            {
                ItemCategory category = _item.GetCategoryDetails(categoryId);

                if (category.CategoryId <= 0)
                {
                    Response.Redirect(string.Format("item-cat-list.aspx?e={0}", 1));
                }

                CategoryId = categoryId;
                txtMainCategory.Text = category.Name;
                txtMainCategoryCode.Text = category.Code;
                cbBeSold.Checked = category.IsCanBeSold;
                cbManufacture.Checked = category.IsManufacture;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void AddCategory()
        {
            ItemCategory category = new ItemCategory();

            category.Name = txtMainCategory.Text.ToTrimString();
            category.Code = txtMainCategoryCode.Text.ToTrimString();
            category.IsCanBeSold = cbBeSold.Checked;
            category.IsManufacture = cbManufacture.Checked;

            string rMessage;
            _item.AddCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-cat-list.aspx?o={0}", 1));
        }

        private void UpdateCategory()
        {
            ItemCategory category = new ItemCategory();

            category.CategoryId = CategoryId;
            category.Name = txtMainCategory.Text.ToTrimString();
            category.Code = txtMainCategoryCode.Text.ToTrimString();
            category.IsCanBeSold = cbBeSold.Checked;
            category.IsManufacture = cbManufacture.Checked;

            string rMessage;
            _item.UpdateCategory(category, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-cat-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddCategory();
                }
                else if (Operation == "edit" && CategoryId > 0)
                {
                    UpdateCategory();
                }  
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-cat-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }
    }
}