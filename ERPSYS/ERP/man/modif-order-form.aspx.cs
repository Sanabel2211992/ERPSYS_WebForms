using System;
using System.Threading;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using ERPSYS.Controls.Common;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERPSYS.Controls.HierarchyItems.MAN.Modification;

namespace ERPSYS.ERP.man
{
    public partial class ModificationOrderForm : Page
    {
      
        readonly ModificationOrderBLL _order = new ModificationOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgModificationInputItems, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgModificationOutputItems, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgBillofMaterials, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
            }

            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            try
            {
                GetItemLookupTables();

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetModificationOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("modif-order-list.aspx?e={0}", 1), false);
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
            LookupBLL lookup = new LookupBLL();

            DataTable dtLocations = lookup.GetModificationLocation();

            ddlModificationLocation.DataTextField = "Name";
            ddlModificationLocation.DataValueField = "LocationId";
            ddlModificationLocation.DataSource = dtLocations;
            ddlModificationLocation.DataBind();
            ddlModificationLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlMaterialLocation.DataTextField = "Name";
            ddlMaterialLocation.DataValueField = "LocationId";
            ddlMaterialLocation.DataSource = dtLocations;
            ddlMaterialLocation.DataBind();
            ddlMaterialLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetModificationOrder(int orderId)
        {
            ModificationOrder order = _order.GetModificationOrderHeader(orderId);

            if (order.ModificationOrderId <= 0)
            {
                Response.Redirect(string.Format("modif-order-list.aspx?e={0}", 1));
            }

            ModificationOrderId = order.ModificationOrderId;
            JobOrderId = order.JobOrderId;
            lblModificationOrder.Text = order.ModificationOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblOrderDate.Text = order.OrderDate.ToDateString().ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            txtRemarks.Text = order.Remarks;

            ddlModificationLocation.SelectedValue = order.InputLocationId.ToString();
            ddlMaterialLocation.SelectedValue = order.BomLocationId.ToString();
        }

        protected void UpdateModificationOrderHeader()
        {

            ModificationOrder order = new ModificationOrder();

            order.ModificationOrderId = ModificationOrderId;
            order.InputLocationId = ddlModificationLocation.SelectedValue.ToInt();
            order.OutputLocationId = ddlModificationLocation.SelectedValue.ToInt();
            order.BomLocationId = ddlMaterialLocation.SelectedValue.ToInt();
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _order.UpdateModificationOrderHeader(order, out rMessage);

            if (rMessage != string.Empty || ModificationOrderId <= 0) 
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_update_success"));
        }

        protected void rgModificationInputItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgModificationInputItems.DataSource = _order.GetInputModificationOrderLines(ModificationOrderId);
        }

        protected void rgModificationInputItems_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Modification/UCInputItemEdit.ascx";
                    break;
            }
        }

        protected void rgModificationInputItems_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("InputItemId").ToInt();
                decimal quantity = ((UCInputItemEdit)uc).Quantity;

                UpdateInputOrderLine(lineId, itemId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateInputOrderLine(int lineId, int itemId, decimal quantity)
        {
            ModificationOrderLine line = new ModificationOrderLine();

            line.ModificationOrderId = ModificationOrderId;
            line.LineId = lineId;
            line.InputItemId = itemId;
            line.InputQuantity = quantity;

            string rMessage;
            _order.UpdateInputOrderLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Input Product");
            }
        }

        protected void rgModificationOutputItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgModificationOutputItems.DataSource = _order.GetOutputModificationOrderLines(ModificationOrderId);
        }

        protected void rgModificationOutputItems_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Modification/UCOutputItemEdit.ascx";
                    break;
            }
        }

        protected void rgModificationOutputItems_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("OutputItemId").ToInt();
                decimal quantity = ((UCOutputItemEdit)uc).Quantity;

                UpdateOutputOrderLine(lineId, itemId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateOutputOrderLine(int lineId, int itemId, decimal quantity)
        {
            ModificationOrderLine line = new ModificationOrderLine();

            line.ModificationOrderId = ModificationOrderId;
            line.LineId = lineId;
            line.OutputItemId = itemId;
            line.OutputQuantity = quantity;

            string rMessage;
            _order.UpdateOutputOrderLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Output Product");

            }
        }

        protected void rgBillofMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterials.DataSource = _order.GetModificationOrderBomLines(ModificationOrderId);
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _order.GetModificationOrderBomLinesQuantityCheck(ModificationOrderId);
        }

        protected void rgBillofMaterialsReview_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");

                decimal delta = dataItem["AvailableQuantity"].Text.ToDecimal() - dataItem["RequiredQuantity"].Text.ToDecimal();
                imgStatus.ImageUrl = (delta >= 0) ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
            }
        }

        protected void rgBillofMaterials_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgBillofMaterials.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Modification/UCMaterialAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Modification/UCMaterialEdit.ascx";
                    break;
            }
        }

        protected void rgBillofMaterials_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int itemId = ((UCMaterialAdd)uc).ItemId;
                decimal quantity = ((UCMaterialAdd)uc).Quantity;

                AddMaterialLine(itemId, quantity);

            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgBillofMaterials_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("ItemBomId").ToInt();
                decimal quantity = ((UCMaterialEdit)uc).Quantity;

                UpdateMaterialLine(lineId, itemId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgBillofMaterials_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                DeleteMaterialLine(lineId, itemId);
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddMaterialLine(int itemId, decimal quantity)
        {
            ModificationOrderBomLine line = new ModificationOrderBomLine();

            line.ModificationOrderId = ModificationOrderId;
            line.ItemBomId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _order.AddRawMaterialLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Raw Material");
            }
        }

        protected void UpdateMaterialLine(int lineId, int itemId, decimal quantity)
        {
            ModificationOrderBomLine line = new ModificationOrderBomLine();

            line.ModificationOrderId = ModificationOrderId;
            line.LineId = lineId;
            line.ItemBomId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _order.UpdateRawMaterialLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Raw Material");
            }
        }

        protected void DeleteMaterialLine(int lineId, int itemId)
        {
            ModificationOrderBomLine line = new ModificationOrderBomLine();

            line.ModificationOrderId = ModificationOrderId;
            line.ItemBomId = itemId;
            line.LineId = lineId;

            string rMessage;
            _order.DeleteRawMaterialLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Raw Material");
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "delete":
                    Response.Redirect(string.Format("modif-order-delete.aspx?id={0}&jid={1}", ModificationOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("modif-order-post.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "jorder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "modiforder":
                    Response.Redirect(string.Format("modif-order-preview.aspx?id={0}", ModificationOrderId), false);
                    break;
            }
        }

        protected void rtsModificationOrder_TabClick(object sender, RadTabStripEventArgs e)
        {
            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateModificationOrderHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int ModificationOrderId
        {
            get { return ViewState["ModificationOrderId"] != null ? ViewState["ModificationOrderId"].ToInt() : -1; }
            set { ViewState["ModificationOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}