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
    public partial class ItemForm : System.Web.UI.Page
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

                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetItemDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                    InitializeForm();
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

            ddlUom.DataTextField = "Name";
            ddlUom.DataValueField = "UomId";
            ddlUom.DataSource = ds.Tables[3];
            ddlUom.DataBind();
            ddlUom.Items.Insert(0, new ListItem("-- Select One --", "-1"));
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

        protected void GetItemDetails(int itemId)
        {
            Item item = _item.GetItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect(string.Format("item-list.aspx?e={0}", 1));
            }

            ItemId = item.ItemId;
            txtItemCode.Text = item.ItemCode;
            txtAdditionalCode.Text = item.AdditionalCode;
            txtPartNumber.Text = item.PartNumber;
            txtItemName.Text = item.Description;
            txtItemNameAr.Text = item.DescriptionAr;
            txtItemNameShowAs.Text = item.DescriptionAs;
            ddlItemType.SelectedValue = item.ItemTypeId.ToString();
            ddlCategory.SelectedValue = item.CategoryId.ToString();
            txtRemarks.Text = item.Remarks;
            txtBarCode.Text = item.BarCode;
            txtUnitPrice.Text = item.UnitPrice.ToDecimalFormat();
            txtMinPrice.Text = item.MinimumPrice.ToDecimalFormat();
            cbIsActive.Checked = item.IsActive;
            cbBeSold.Checked = item.IsCanBeSold;
            cbManufacture.Checked = item.IsManufacture;
            cbIsNonStandard.Checked = item.IsNonStandard;
            cbHasBom.Checked = item.HasBom;

            ddlBrand.SelectedValue = item.BrandId.ToString();
            ddlUom.SelectedValue = item.UomId.ToString();
            GetSubCategory(item.CategoryId);
            ddlSubCategory.SelectedValue = item.SubCategoryId.ToString();
            imgItem.ImageUrl = item.ItemImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(item.ItemImage.ImageData, item.ItemImage.ImageType) : "~/ERP/resources/images/default-product.png";

            // prevent user change below values
            txtItemCode.Enabled = false;
            txtPartNumber.Enabled = false;
            txtItemName.Enabled = false;
            ddlItemType.Enabled = false;
            ddlCategory.Enabled = false;
            ddlSubCategory.Enabled = false;
            ddlBrand.Enabled = false;
            ddlUom.Enabled = false;
            rfvCategory.Enabled = false;
            rfvtxtItemCode.Enabled = false;
        }

        protected void AddItemAdvanced()
        {
            Item item = new Item();

            item.ItemId = ItemId;
            item.AdditionalCode = txtAdditionalCode.Text.ToTrimString();
            item.ItemCode = txtItemCode.Text.ToTrimString();
            item.PartNumber = txtPartNumber.Text.ToTrimString();
            item.Description = txtItemName.Text.ToTrimString();
            item.DescriptionAr = txtItemNameAr.Text.ToTrimString();
            item.DescriptionAs = txtItemNameShowAs.Text.ToTrimString();
            item.ItemTypeId = ddlItemType.SelectedValue.ToInt();
            item.CategoryId = ddlCategory.SelectedValue.ToInt();
            item.SubCategoryId = ddlSubCategory.SelectedValue.ToInt();
            item.Remarks = txtRemarks.Text.ToTrimString();
            item.BarCode = txtBarCode.Text.ToTrimString();
            item.UnitPrice = txtUnitPrice.Text.ToDecimal();
            item.MinimumPrice = txtMinPrice.Text.ToDecimal();
            item.BrandId = ddlBrand.SelectedValue.ToInt();
            item.UomId = ddlUom.SelectedValue.ToInt();
            item.IsActive = cbIsActive.Checked;
            item.IsCanBeSold = cbBeSold.Checked;
            item.IsManufacture = cbManufacture.Checked;
            item.IsNonStandard = cbIsNonStandard.Checked;
            item.HasBom = cbHasBom.Checked;
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

        protected void UpdateItemAdvanced()
        {
            Item item = new Item();
            item.ItemId = ItemId;
            item.ItemCode = txtItemCode.Text.ToTrimString();
            item.AdditionalCode = txtAdditionalCode.Text.ToTrimString();
            item.PartNumber = txtPartNumber.Text.ToTrimString();
            item.Description = txtItemName.Text.ToTrimString();
            item.DescriptionAr = txtItemNameAr.Text.ToTrimString();
            item.DescriptionAs = txtItemNameShowAs.Text.ToTrimString();
            item.ItemTypeId = ddlItemType.SelectedValue.ToInt();
            item.CategoryId = ddlCategory.SelectedValue.ToInt();
            item.SubCategoryId = ddlSubCategory.SelectedValue.ToInt();
            item.Remarks = txtRemarks.Text.ToTrimString();
            item.BarCode = txtBarCode.Text.ToTrimString();
            item.UnitPrice = txtUnitPrice.Text.ToDecimal();
            item.MinimumPrice = txtMinPrice.Text.ToDecimal();
            item.BrandId = ddlBrand.SelectedValue.ToInt();
            item.UomId = ddlUom.SelectedValue.ToInt();
            item.IsActive = cbIsActive.Checked;
            item.IsCanBeSold = cbBeSold.Checked;
            item.IsManufacture = cbManufacture.Checked;
            item.IsNonStandard = cbIsNonStandard.Checked;
            item.HasBom = cbHasBom.Checked;

            FileImage itemImage = new FileImage();

            if (cbRemoveImage.Checked)
            {
                itemImage.IsUpdated = true;
                itemImage.ImageData = null;
                itemImage.ImageType = null;
            }
            else if (fuItemImage.HasFile)
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
            _item.UpdateItemAdvanced(item, out rMessage);

            if (rMessage != string.Empty || ItemId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-preview-x.aspx?o={0}&id={1}", 2, ItemId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddItemAdvanced();
                }
                else if (Operation == "edit" && ItemId > 0)
                {
                    UpdateItemAdvanced();
                }
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

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
    }
}