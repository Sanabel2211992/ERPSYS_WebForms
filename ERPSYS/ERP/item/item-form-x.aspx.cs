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
using Telerik.Web.UI;
using System.Web.UI;
using ERPSYS.Controls.HierarchyItems.ITEM.BOM;
using System.Collections.Generic;

namespace ERPSYS.ERP.item
{
    public partial class ItemFormX : System.Web.UI.Page
    {
        //readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindData();
            //    //ShowMessages();
            //}
        }
        //private void ShowMessages()
        //{
        //    try
        //    {
        //        if (Request.QueryString["o"] == "1") // item add 
        //        {
        //            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_add_success"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}
        //private void BindData()
        //{
        //    try
        //    {
        //        GetItemLookupTables();

        //        if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
        //        {
        //            Operation = "edit";
        //            GetItemDetails(Request.QueryString["id"].ToInt());
        //            rgBom.Visible = true;
        //        }
        //        else
        //        {
        //            Operation = "new";
        //            InitializeForm();
        //            lblBOM.Visible = true;
        //        }
        //    }
        //    catch (ThreadAbortException)
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void GetItemLookupTables()
        //{
        //    DataSet ds = _item.GetItemLookupTables();

        //    ddlItemType.DataTextField = "Name";
        //    ddlItemType.DataValueField = "ItemTypeId";
        //    ddlItemType.DataSource = ds.Tables[0];
        //    ddlItemType.DataBind();

        //    ddlCategory.DataTextField = "Name";
        //    ddlCategory.DataValueField = "CategoryId";
        //    ddlCategory.DataSource = ds.Tables[1];
        //    ddlCategory.DataBind();
        //    ddlCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //    ddlCategory.Items.Insert(1, new ListItem("Not specified", "0"));

        //    ddlSubCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //    ddlSubCategory.Items.Insert(1, new ListItem("Not specified", "0"));

        //    ddlBrand.DataTextField = "Name";
        //    ddlBrand.DataValueField = "BrandId";
        //    ddlBrand.DataSource = ds.Tables[2];
        //    ddlBrand.DataBind();
        //    ddlBrand.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //    ddlBrand.Items.Insert(1, new ListItem("Not specified", "0"));

        //    ddlUom.DataTextField = "Name";
        //    ddlUom.DataValueField = "UomId";
        //    ddlUom.DataSource = ds.Tables[3];
        //    ddlUom.DataBind();
        //    ddlUom.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //}

        //protected void InitializeForm()
        //{
        //    ddlItemType.SelectedValue = 1.ToString();
        //    imgItem.ImageUrl = "~/ERP/resources/images/default-product.png";
        //}

        //protected void GetSubCategory(int categoryId)
        //{
        //    try
        //    {
        //        ddlSubCategory.Items.Clear();
        //        ddlSubCategory.DataTextField = "Name";
        //        ddlSubCategory.DataValueField = "CategoryId";
        //        ddlSubCategory.DataSource = _item.GetSubCategoryList(categoryId);
        //        ddlSubCategory.DataBind();
        //        ddlSubCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        //        ddlSubCategory.Items.Insert(1, new ListItem("Not specified", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetSubCategory(ddlCategory.SelectedValue.ToInt());
        //}

        //protected void GetItemDetails(int itemId)
        //{
        //    Item item = _item.GetItem(itemId);

        //    if (item.ItemId <= 0)
        //    {
        //        Response.Redirect(string.Format("item-list.aspx?e={0}", 1));
        //    }

        //    ItemId = item.ItemId;                 
        //    txtItemCode.Text = item.ItemCode;
        //    txtPartNumber.Text = item.PartNumber;
        //    txtItemName.Text = item.Description;
        //    txtItemNameAr.Text = item.DescriptionAr;
        //    txtItemNameShowAs.Text = item.DescriptionAs;
        //    ddlItemType.SelectedValue = item.ItemTypeId.ToString();
        //    ddlCategory.SelectedValue = item.CategoryId.ToString();
        //    txtRemarks.Text = item.Remarks;
        //    txtBarCode.Text = item.BarCode;
        //    txtUnitPrice.Text = item.UnitPrice.ToDecimalFormat();
        //    cbIsActive.Checked = item.IsActive;
        //    cbBeSold.Checked = item.IsCanBeSold;
        //    cbManufacture.Checked = item.IsManufacture;
        //    cbIsNonStandard.Checked = item.IsNonStandard;
        //    cbHasBom.Checked = item.HasBom;

        //    ddlBrand.SelectedValue = item.BrandId.ToString();
        //    ddlUom.SelectedValue = item.UomId.ToString();
        //    GetSubCategory(item.CategoryId);
        //    ddlSubCategory.SelectedValue = item.SubCategoryId.ToString();
        //    imgItem.ImageUrl = item.ItemImage.ImageData.Length > 0 ? ImageHandel.ImageFromByte(item.ItemImage.ImageData, item.ItemImage.ImageType) : "~/ERP/resources/images/default-product.png";

        //    // prevent user change below values
        //    txtItemCode.Enabled = false;
        //    txtPartNumber.Enabled = false;
        //    txtItemName.Enabled = false;
        //    ddlItemType.Enabled = false;
        //    ddlCategory.Enabled = false;
        //    ddlSubCategory.Enabled = false;
        //    ddlBrand.Enabled = false;
        //    ddlUom.Enabled = false;
        //    rfvCategory.Enabled = false;
        //    rfvtxtItemCode.Enabled = false;
        //}

        //protected void AddItemAdvanced()
        //{
        //    Item item = new Item();

        //    item.ItemId = ItemId;
        //    item.ItemCode = txtItemCode.Text.ToTrimString();
        //    item.PartNumber = txtPartNumber.Text.ToTrimString();
        //    item.Description = txtItemName.Text.ToTrimString();
        //    item.DescriptionAr = txtItemNameAr.Text.ToTrimString();
        //    item.DescriptionAs = txtItemNameShowAs.Text.ToTrimString();
        //    item.ItemTypeId = ddlItemType.SelectedValue.ToInt();
        //    item.CategoryId = ddlCategory.SelectedValue.ToInt();
        //    item.SubCategoryId = ddlSubCategory.SelectedValue.ToInt();
        //    item.Remarks = txtRemarks.Text.ToTrimString();
        //    item.BarCode = txtBarCode.Text.ToTrimString();
        //    item.UnitPrice = txtUnitPrice.Text.ToDecimal();
        //    item.BrandId = ddlBrand.SelectedValue.ToInt();
        //    item.UomId = ddlUom.SelectedValue.ToInt();
        //    item.IsActive = cbIsActive.Checked;
        //    item.IsCanBeSold = cbBeSold.Checked;
        //    item.IsManufacture = cbManufacture.Checked;
        //    item.IsNonStandard = cbIsNonStandard.Checked;
        //    item.HasBom = cbHasBom.Checked;
        //    FileImage itemImage = new FileImage();

        //    itemImage.ImageData = new byte[] { };
        //    itemImage.ImageName = "";
        //    itemImage.ImageType = "";

        //    if (fuItemImage.HasFile)
        //    {
        //        string ext = Path.GetExtension(fuItemImage.FileName);
        //        string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;

        //        if (!allowedExtenstions.Contains(ext))
        //        {
        //            AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_ext_not_allowed"));
        //            return;
        //        }

        //        var maxFileSize = CommonMember.MaxFileSizeProfilePicture;
        //        var fileSize = (fuItemImage.PostedFile.ContentLength / (decimal)1024);

        //        if (fileSize > maxFileSize)
        //        {
        //            AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_size_exceed"));
        //            return;
        //        }

        //        HttpPostedFile postimg = fuItemImage.PostedFile;

        //        itemImage.IsUpdated = true;
        //        itemImage.ImageData = ImageHandel.ImageToByte(fuItemImage.PostedFile);
        //        itemImage.ImageType = Path.GetExtension(postimg.FileName);
        //        imgItem.ImageUrl = ImageHandel.ImageFromByte(itemImage.ImageData, itemImage.ImageType);
        //    }

        //    item.ItemImage = itemImage;


        //    string rMessage;
        //    int itemId = _item.AddItemAdvanced(item, out rMessage);

        //    if (rMessage != string.Empty || itemId <= 0)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }
        //    Response.Redirect(string.Format("item-form-x.aspx?o={0}&id={1}", "edit", itemId), false);
        //}

        //protected void UpdateItemAdvanced()
        //{
        //    Item item = new Item();
        //    item.ItemId = ItemId;
        //    item.ItemCode = txtItemCode.Text.ToTrimString();
        //    item.PartNumber = txtPartNumber.Text.ToTrimString();
        //    item.Description = txtItemName.Text.ToTrimString();
        //    item.DescriptionAs = txtItemNameShowAs.Text.ToTrimString();
        //    item.ItemTypeId = ddlItemType.SelectedValue.ToInt();
        //    item.CategoryId = ddlCategory.SelectedValue.ToInt();
        //    item.SubCategoryId = ddlSubCategory.SelectedValue.ToInt();
        //    item.Remarks = txtRemarks.Text.ToTrimString();
        //    item.BarCode = txtBarCode.Text.ToTrimString();
        //    item.UnitPrice = txtUnitPrice.Text.ToDecimal();
        //    item.BrandId = ddlBrand.SelectedValue.ToInt();
        //    item.UomId = ddlUom.SelectedValue.ToInt();
        //    item.IsActive = cbIsActive.Checked;
        //    item.IsCanBeSold = cbBeSold.Checked;
        //    item.IsManufacture = cbManufacture.Checked;
        //    item.IsNonStandard = cbIsNonStandard.Checked;
        //    item.HasBom = cbHasBom.Checked;

        //    FileImage itemImage = new FileImage();

        //    if (cbRemoveImage.Checked)
        //    {
        //        itemImage.IsUpdated = true;
        //        itemImage.ImageData = null;
        //        itemImage.ImageType = null;
        //    }
        //    else if (fuItemImage.HasFile)
        //    {
        //        string ext = Path.GetExtension(fuItemImage.FileName);
        //        string[] allowedExtenstions = CommonMember.AllowedExtenstionsProfilePicture;

        //        if (!allowedExtenstions.Contains(ext))
        //        {
        //            AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_ext_not_allowed"));
        //            return;
        //        }

        //        var maxFileSize = CommonMember.MaxFileSizeProfilePicture;
        //        var fileSize = (fuItemImage.PostedFile.ContentLength / (decimal)1024);

        //        if (fileSize > maxFileSize)
        //        {
        //            AppNotification.MessageBoxWarning(Notifications.GetMessage("user_profile_image_size_exceed"));
        //            return;
        //        }

        //        HttpPostedFile postimg = fuItemImage.PostedFile;

        //        itemImage.IsUpdated = true;
        //        itemImage.ImageData = ImageHandel.ImageToByte(fuItemImage.PostedFile);
        //        itemImage.ImageType = Path.GetExtension(postimg.FileName);

        //        imgItem.ImageUrl = ImageHandel.ImageFromByte(itemImage.ImageData, itemImage.ImageType);
        //    }

        //    item.ItemImage = itemImage;

        //    string rMessage;
        //    _item.UpdateItemAdvanced(item, out rMessage);

        //    if (rMessage != string.Empty || ItemId <= 0)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }

        //    Response.Redirect(string.Format("item-preview.aspx?o={0}&id={1}", 2, ItemId), false);
        //}

        //protected void rgBom_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    try
        //    {
        //        List<ItemBomLine> lstLines = _item.GetItemBom(ItemId, BomTypeId);  //lblBomPrice.Text = to do calculate the total bpm price
        //        rgBom.DataSource = lstLines;
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void rgBom_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case RadGrid.InitInsertCommandName:
        //            e.Canceled = true;
        //            rgBom.EditIndexes.Clear();

        //            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/ITEM/BOM/UCItemAddGrid.ascx";
        //            e.Item.OwnerTableView.InsertItem();
        //            break;
        //        case RadGrid.EditCommandName:
        //            e.Item.OwnerTableView.IsItemInserted = false;
        //            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/ITEM/BOM/UCItemEdit.ascx";
        //            break;
        //    }
        //}

        //protected void rgBom_InsertCommand(object sender, GridCommandEventArgs e)
        //{
        //    UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

        //    try
        //    {
        //        int itemId = ((UCItemAddGrid)uc).ItemId;
        //        decimal quantity = ((UCItemAddGrid)uc).Quantity;

        //        AddBomLine(itemId, quantity);

        //    }
        //    catch (Exception ex)
        //    {
        //        e.Canceled = true;
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void rgBom_UpdateCommand(object sender, GridCommandEventArgs e)
        //{
        //    GridEditableItem eItem = ((GridEditableItem)(e.Item));
        //    UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

        //    try
        //    {
        //        int lineId = eItem.GetDataKeyValue("LineId").ToInt();
        //        int itemBomId = eItem.GetDataKeyValue("ItemBomId").ToInt();
        //        decimal quantity = ((UCItemEdit)uc).Quantity;

        //        UpdateBomLine(lineId, itemBomId, quantity);
        //    }
        //    catch (Exception ex)
        //    {
        //        e.Canceled = true;
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void rgBom_DeleteCommand(object sender, GridCommandEventArgs e)
        //{
        //    GridEditableItem dItem = ((GridEditableItem)(e.Item));
        //    try
        //    {
        //        int lineId = dItem.GetDataKeyValue("LineId").ToInt();
        //        int itemBomId = dItem.GetDataKeyValue("ItemBomId").ToInt();

        //        DeleteBomLine(lineId, itemBomId);
        //    }

        //    catch (Exception ex)
        //    {
        //        e.Canceled = true;
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void AddBomLine(int itemBomId, decimal quantity)
        //{
        //    ItemBomLine line = new ItemBomLine();

        //    line.ItemId = ItemId;
        //    line.BomTypeId = BomTypeId;
        //    line.ItemBomId = itemBomId;
        //    line.Quantity = quantity;

        //    string rMessage;
        //    _item.AddBomLine(line, out rMessage);

        //    if (rMessage != string.Empty)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }

        //    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"));
        //}

        //protected void UpdateBomLine(int lineId, int itemBomId, decimal quantity)
        //{
        //    ItemBomLine line = new ItemBomLine();

        //    line.ItemId = ItemId;
        //    line.LineId = lineId;
        //    line.BomTypeId = BomTypeId;
        //    line.ItemBomId = itemBomId;
        //    line.Quantity = quantity;

        //    string rMessage;
        //    _item.UpdateBomLine(line, out rMessage);

        //    if (rMessage != string.Empty)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }

        //    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"));
        //}

        //protected void DeleteBomLine(int lineId, int itemBomId)
        //{
        //    ItemBomLine line = new ItemBomLine();

        //    line.ItemId = ItemId;
        //    line.LineId = lineId;
        //    line.BomTypeId = BomTypeId;
        //    line.ItemBomId = itemBomId;

        //    string rMessage;
        //    _item.DeleteBomLine(line, out rMessage);

        //    if (rMessage != string.Empty)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }

        //    AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"));
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!IsValid)
        //            return;

        //        if (Operation == "new")
        //        {
        //            AddItemAdvanced();
        //        }
        //        else if (Operation == "edit" && ItemId > 0)
        //        {
        //            UpdateItemAdvanced();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(string.Format("item-list.aspx"), false);
        //}

        ////************************************** Properties ************************************//

        //private string Operation
        //{
        //    get { return ViewState["Opertaion"].ToString(); }
        //    set { ViewState["Opertaion"] = value; }
        //}

        //public int ItemId
        //{
        //    get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
        //    set { ViewState["ItemId"] = value; }
        //}

        //private int BomTypeId
        //{
        //    get { return 1; } // BOM Type 1 - 'A' - Assembly BOM
        //}
    }
}