using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class ItemRawMaterialsBomCategory : System.Web.UI.Page
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
            GetCategory();
            GetGroupCategories();
        }

        private void GetCategory()
        {
            try
            {
                cblCategoryNames.DataTextField = "Name";
                cblCategoryNames.DataValueField = "CategoryId";
                cblCategoryNames.DataSource = _item.GetCategories();
                cblCategoryNames.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetGroupCategories()
        {
            List<ItemCategory> categories = _item.GetGroupCategories();

            foreach (ListItem item in cblCategoryNames.Items.Cast<ListItem>().Where(item => categories.Any(x => x.CategoryId == item.Value.ToInt())))
            {
                item.Selected = true;
            }
        }

        private void UpdateRawMaterialsBomCategories()
        {
            try
            {
                var bomCategories = cblCategoryNames.Items.Cast<ListItem>().Where(item => item.Selected).Aggregate(string.Empty, (current, item) => current + (item.Value + ","));
                if (bomCategories != "") bomCategories = bomCategories.Remove(bomCategories.Length - 1, 1);

                string rMessage;
                _item.UpdateRawMaterialsBomCategories(bomCategories, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("bom_category_update_success"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateRawMaterialsBomCategories();
        }
    }
}