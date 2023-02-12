using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.item
{
    public partial class item_copy : System.Web.UI.Page
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
                    GetItemCopyDetails(Request.QueryString["id"].ToInt());
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemCopyDetails(int itemId)
        {
            Item item = _item.GetManufactureItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect("item-list.aspx?e=1", false);
            }

            ItemId = item.ItemId;
            lblItemCode.Text = item.ItemCode.ReplaceWhenNullOrEmpty("N/A");
            lblPartNumber.Text = item.PartNumber.ReplaceWhenNullOrEmpty("N/A");
            lblDescription.Text = item.Description.ReplaceWhenNullOrEmpty("N/A");
            lblCategory.Text = string.Format("{0}{1}", item.Category.ReplaceWhenNullOrEmpty("N/A"), item.SubCategory.ReplaceWhenNullOrEmpty("N/A") != "N/A" ? string.Format("/ {0}", item.SubCategory) : string.Empty);
            lblBrand.Text = item.Brand.ReplaceWhenNullOrEmpty("N/A");
            lblUnitPrice.Text = item.UnitPrice.ToDecimalFormat();
            lblStandard.Text = item.IsNonStandard ? "Product Is Non Standard" : "Product Is Standard";
            imgItem.ImageUrl = item.ItemImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(item.ItemImage.ImageData, item.ItemImage.ImageType) : "~/ERP/resources/images/default-product.png";
        }

        protected void CopyItem()
        {
            Item item = new Item();

            item.ItemId = ItemId;
            item.ItemCode = txtItemCode.Text.ToTrimString();
            item.PartNumber = txtPartNumber.Text.ToTrimString();
            item.Description = txtItemName.Text.ToTrimString();
            item.DescriptionAr = txtItemNameAr.Text.ToTrimString();
            item.DescriptionAs = txtItemNameShowAs.Text.ToTrimString();

            bool Bom = cbBom.Checked;
            bool Img = cbImage.Checked;
            bool Price = cbPrice.Checked;
            
            
            string rMessage;
            int itemId = _item.CopyItem(item, Bom, Img, Price, out rMessage);

            if (rMessage != string.Empty || itemId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("item-preview-x.aspx?o={0}&id={1}", 1, itemId), false);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;
                    CopyItem();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-preview-x.aspx?id={0}", ItemId), false);
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }     
    }
}