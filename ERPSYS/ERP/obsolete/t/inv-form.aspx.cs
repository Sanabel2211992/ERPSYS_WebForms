using System;
using System.Collections.Generic;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Controls;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.ITEM.BOM;

namespace ERPSYS.ERP.t
{
    public partial class env_form : System.Web.UI.Page
    {
        //readonly ItemBLL _item = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
        //        case RadGrid.EditCommandName:
        //            e.Item.OwnerTableView.IsItemInserted = false;
        //            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/ITEM/BOM/UCItemEdit.ascx";
        //            break;
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

        //protected void btnAddItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ItemBomLine line = new ItemBomLine();

        //        line.ItemId = ItemId;
        //        line.BomTypeId = BomTypeId;
        //        line.Quantity = UCItemAddMaterial.Quantity;
        //        line.ItemBomId = UCItemAddMaterial.ItemId;

        //        string rMessage;
        //        _item.AddBomLine2(line, out rMessage);
        //        UCItemAddMaterial.ClearFields();

        //        if (rMessage != string.Empty)
        //        {
        //            AppNotification.MessageBoxFailed(rMessage);
        //        }
        //        else
        //        {
        //            rgBom.Rebind();
        //            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        ////************************************** Properties ************************************//
        //private int ItemId
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