using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using ERPSYS.Helpers.Ext;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using Telerik.Web.UI;

namespace ERPSYS.ERP.item
{
    public partial class ItemPreviewx : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                BindData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                if (Request.QueryString["o"] == "1") // item add 
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_add_success"));
                }
                else if (Request.QueryString["o"] == "2") // item update
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_update_success"));
                }
                else if (Request.QueryString["o"] == "3") // item delete
                {
                    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_delete_success"));
                }

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetItemDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("item-list.aspx?e={0}", 1));
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

        protected void GetItemDetails(int itemId)
        {
            Item item = _item.GetItem(itemId);

            if (UserSession.RoleId == 5)
            {
                rtbOperations.Visible = false;
                tblItemView.Visible = false;
            }

            if (item.ItemId <= 0)
            {
                Response.Redirect(string.Format("item-list.aspx?e={0}", 1), false);
            }

            ItemId = item.ItemId;
            lblItemCode.Text = item.ItemCode.ReplaceWhenNullOrEmpty("N/A");
            lblPartNumber.Text = item.PartNumber.ReplaceWhenNullOrEmpty("N/A");
            lblAdditionalCode.Text = item.AdditionalCode.ReplaceWhenNullOrEmpty("N/A");
            lblDescription.Text = item.Description.ReplaceWhenNullOrEmpty("N/A");
            lblDescriptionAr.Text = item.DescriptionAr.ReplaceWhenNullOrEmpty("N/A");
            lblItemType.Text = item.ItemType.ReplaceWhenNullOrEmpty("N/A");
            //lblCategory.Text = string.Format("{0}{1}", item.Category.ReplaceWhenNullOrEmpty("N/A"), item.SubCategory.ReplaceWhenNullOrEmpty("N/A") != "N/A" ? string.Format("/ {0}", item.SubCategory) : string.Empty);
            lblCategory.Text = item.Category.ReplaceWhenNullOrEmpty("N/A");
            lblSubCategory.Text = item.SubCategory.ReplaceWhenNullOrEmpty("N/A");
            lblBrand.Text = item.Brand.ReplaceWhenNullOrEmpty("N/A");
            lblUom.Text = item.Uom.ReplaceWhenNullOrEmpty("N/A");
            lblBarCode.Text = item.BarCode.ReplaceWhenNullOrEmpty("N/A");
            lblUnitPrice.Text = item.UnitPrice.ToDecimalFormat();
            lblMinPrice.Text = item.MinimumPrice.ToDecimalFormat();
            lblStatus.Text = item.IsActive ? "Active" : "Inactive";

            lblUnitPrice.ForeColor = Color.Green;
            lblMinPrice.ForeColor = Color.Red;

            if (item.IsActive)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font.Bold = true;
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font.Bold = true;
            }

            if(!item.HasBom)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("bom"));
                rtsProduct.Tabs[1].Visible = false;
                rtsProduct.Width= 150;
            }

            lblManufacture.Text = item.IsManufacture ? "Manufacture Product" : "";
            lblManufacture.Visible = item.IsManufacture;
            lblCanBeSold.Text = item.IsCanBeSold ? "" : "Product Is Not For Sale";
            lblCanBeSold.Visible = !item.IsCanBeSold;
            lblStandard.Text = item.IsNonStandard ? "Product Is Non Standard" : "";
            lblStandard.Visible = item.IsNonStandard;
            lblRemarks.Text = item.Remarks.ReplaceWhenNullOrEmpty("N/A");
            imgItem.ImageUrl = item.ItemImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(item.ItemImage.ImageData, item.ItemImage.ImageType) : "~/ERP/resources/images/default-product.png";

            List<ItemBomLine> lstLines = _item.GetItemBom(ItemId, BomTypeId);
            rgBom.DataSource = lstLines;
            rgBom.DataBind();
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "bom":
                    Response.Redirect(string.Format("item-bom-form.aspx?id={0}", ItemId), false);
                    break;
                case "edit":
                    Response.Redirect(string.Format("item-form.aspx?o=edit&id={0}", ItemId), false);
                    break;
                case "copy":
                    Response.Redirect(string.Format("item-copy.aspx?o=edit&id={0}", ItemId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("item-delete.aspx?id={0}", ItemId), false);
                    break;
                case "back":
                    Response.Redirect(string.Format("item-list.aspx"), false);
                    break;
            }
        }
        
        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }
        private int BomTypeId
        {
            get { return 1; }
        }     
    }
}