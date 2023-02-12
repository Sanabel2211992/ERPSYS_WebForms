using System;
using System.Collections.Generic;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.ITEM.BOM;

namespace ERPSYS.ERP.item
{
    public partial class ItemBomForm : Page
    {
        readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(btnAddItem, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgBom, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
            }

            if (!IsPostBack)
            {
                BindData();
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("item_bom_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_bom_clone_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_bom_delete_success"));
                        break;
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
                    GetManufactureItemDetails(Request.QueryString["id"].ToInt());
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetManufactureItemDetails(int itemId)
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

            // check if item is able to bom or not ??
        }

        protected void rgBom_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                List<ItemBomLine> lstLines = _item.GetItemBom(ItemId, BomTypeId);  //lblBomPrice.Text = to do calculate the total bpm price
                rgBom.DataSource = lstLines;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgBom_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/ITEM/BOM/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgBom_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemBomId = eItem.GetDataKeyValue("ItemBomId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;

                UpdateBomLine(lineId, itemBomId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgBom_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                int itemBomId = dItem.GetDataKeyValue("ItemBomId").ToInt();

                DeleteBomLine(lineId, itemBomId);
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddBomLine(int itemBomId, decimal quantity)
        {
            ItemBomLine line = new ItemBomLine();

            line.ItemId = ItemId;
            line.BomTypeId = BomTypeId;
            line.ItemBomId = itemBomId;
            line.Quantity = quantity;

            string rMessage;
            _item.AddBomLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
        }

        protected void UpdateBomLine(int lineId, int itemBomId, decimal quantity)
        {
            ItemBomLine line = new ItemBomLine();

            line.ItemId = ItemId;
            line.LineId = lineId;
            line.BomTypeId = BomTypeId;
            line.ItemBomId = itemBomId;
            line.Quantity = quantity;

            string rMessage;
            _item.UpdateBomLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
        }

        protected void DeleteBomLine(int lineId, int itemBomId)
        {
            ItemBomLine line = new ItemBomLine();

            line.ItemId = ItemId;
            line.LineId = lineId;
            line.BomTypeId = BomTypeId;
            line.ItemBomId = itemBomId;

            string rMessage;
            _item.DeleteBomLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {     
            try
            {
                    ItemBomLine line = new ItemBomLine();

                    line.ItemId = ItemId;
                    line.BomTypeId = BomTypeId;
                    line.Quantity = UCItemAddMaterial.Quantity;
                    line.ItemBomId = UCItemAddMaterial.ItemId;

                    if (ItemId == line.ItemBomId)
                    {
                        AppNotification.MessagePanelFailed(GeneralResources.GetStringFromResources("item_bom_main_item_exists"), "Failed");

                    }
                    else
                    {
                        string rMessage;
                        _item.AddBomLine(line, out rMessage);
                        UCItemAddMaterial.ClearFields();

                        if (rMessage != string.Empty)
                        {
                            AppNotification.MessagePanelFailed(rMessage, "Failed");
                        }
                        rgBom.Rebind();
                        AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
                    }
                   
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "productdetails":
                    Response.Redirect(string.Format("item-preview-x.aspx?id={0}", ItemId), false);
                    break;
                case "clone":
                    Response.Redirect(string.Format("item-bom-clone.aspx?id={0}", ItemId), false);
                    break;
                case "deletebom":
                    Response.Redirect(string.Format("item-bom-delete.aspx?id={0}&tid={1}", ItemId, BomTypeId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("item-bom-report.aspx?id={0}", ItemId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        private int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }

        private int BomTypeId
        {
            get { return 1; } // BOM Type 1 - 'A' - Assembly BOM
        } 
    }
}