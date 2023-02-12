using System;
using System.Data;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.IO;
using System.Web;
using System.Linq;

namespace ERPSYS.ERP.item
{
    public partial class ItemSempForm : System.Web.UI.Page
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
                GetItemLookupTables();
                InitializeForm();
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            DataSet ds = _item.GetItemLookupTables();

            ddlItemType.DataTextField = "Name";
            ddlItemType.DataValueField = "ItemTypeId";
            ddlItemType.DataSource = ds.Tables[0];
            ddlItemType.DataBind();

            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = ds.Tables[1];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            ddlCategory.Items.Insert(1, new ListItem("Not specified", "0"));

            ddlSubCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            ddlSubCategory.Items.Insert(1, new ListItem("Not specified", "0"));

            ddlBrand.DataTextField = "Name";
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataSource = ds.Tables[2];
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            ddlBrand.Items.Insert(1, new ListItem("Not specified", "0"));
        }

        protected void InitializeForm()
        {
            ddlItemType.SelectedValue = 1.ToString();
            imgItem.ImageUrl = "~/ERP/resources/images/default-product.png";
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
                ddlSubCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
                ddlSubCategory.Items.Insert(1, new ListItem("Not specified", "0"));
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

        protected void AddItemAdvanced()
        {
            Item item = new Item();

            item.ItemId = ItemId;
            item.ItemCode = txtItemCode.Text.ToTrimString();
            item.PartNumber = txtPartNumber.Text.ToTrimString();
            item.Description = txtItemName.Text.ToTrimString();
            item.DescriptionAs = txtItemName.Text.ToTrimString();
            item.ItemTypeId = ddlItemType.SelectedValue.ToInt();
            item.CategoryId = ddlCategory.SelectedValue.ToInt();
            item.SubCategoryId = ddlSubCategory.SelectedValue.ToInt();
            item.Remarks = txtRemarks.Text.ToTrimString();
            item.BarCode = "";
            item.UnitPrice = txtUnitPrice.Text.ToDecimal();
            item.MinimumPrice = txtMinPrice.Text.ToDecimal();
            item.BrandId = ddlBrand.SelectedValue.ToInt();
            item.UomId = 10;
            item.IsActive = cbIsActive.Checked;
            item.IsCanBeSold = cbBeSold.Checked;
            item.IsManufacture = false;
            item.IsNonStandard = false;
            item.HasBom = false;
            FileImage itemImage = new FileImage();

            itemImage.ImageData = new byte[] { };
            itemImage.ImageName = "";
            itemImage.ImageType = "";

            if (fuItemImage.HasFile)
            {
                string ext = Path.GetExtension(fuItemImage.FileName);
                string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;

                if (!allowedExtenstions.Contains(ext))
                {
                    AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_ext_not_allowed"));
                    return;
                }

                var maxFileSize = CommonMember.MaxFileSizeProfilePicture;
                var fileSize = (fuItemImage.PostedFile.ContentLength / (decimal)1024);

                if (fileSize > maxFileSize)
                {
                    AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_size_exceed"));
                    return;
                }

                HttpPostedFile postimg = fuItemImage.PostedFile;

                itemImage.IsUpdated = true;
                itemImage.ImageData = ImageHandle.ImageToByte(fuItemImage.PostedFile);
                itemImage.ImageType = Path.GetExtension(postimg.FileName);
                imgItem.ImageUrl = ImageHandle.ImageFromByte(itemImage.ImageData, itemImage.ImageType);
            }

            item.ItemImage = itemImage;


            string rMessage;
            int itemId = _item.AddItemAdvanced(item, out rMessage);

            if (rMessage != string.Empty || itemId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-preview-x.aspx?o={0}&id={1}", 1, itemId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                    AddItemAdvanced();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
    }
}