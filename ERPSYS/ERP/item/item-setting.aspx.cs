using System;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using NPOI.SS.Formula.Functions;

namespace ERPSYS.ERP.item
{
    public partial class ItemSetting : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetItemLookupTables();
            }
        }

        protected void GetItemLookupTables()
        {
            DataSet ds = _item.GetItemLookupTables();

            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = ds.Tables[1];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

            ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

            //ddlBrand.DataTextField = "Name";
            //ddlBrand.DataValueField = "BrandId";
            //ddlBrand.DataSource = ds.Tables[2];
            //ddlBrand.DataBind();
            //ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        protected void GetSubCategory(int categoryId)
        {
            try
            {
                ddlSubCategory.Items.Clear();
                ddlSubCategory.DataTextField = "Name";
                ddlSubCategory.DataValueField = "CategoryId";
                ddlSubCategory.DataSource = _item.GetSubCategoryList(categoryId);
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategory(ddlCategory.SelectedValue.ToInt());
        }

        private void UpdateItemBulkSettings()
        {
            try
            {
                if (!cbUpdateIsSold.Checked && !cbIsManufacture.Checked && !cbHasBOM.Checked)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("item_bulk_update_not_select"));
                    return;
                }

                int categoryId = ddlCategory.SelectedValue.ToInt();
                int subCategoryId = ddlSubCategory.SelectedValue.ToInt();

                string rMessage;
                _item.UpdateItemBulkSettings(categoryId, subCategoryId, cbUpdateIsSold.Checked, rbtnlstSold.SelectedValue.ToBool(), cbIsManufacture.Checked, rbtnlstManufactur.SelectedValue.ToBool(), cbHasBOM.Checked, rbtnlstBOM.SelectedValue.ToBool(), out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_bulk_update_success"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateItemBulkSettings();
        }

    }
}