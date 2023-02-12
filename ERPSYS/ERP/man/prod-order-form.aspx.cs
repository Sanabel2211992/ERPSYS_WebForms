using System;
using System.Linq;
using System.Threading;
using System.Web.UI;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using ERPSYS.Controls.Common;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Controls.HierarchyItems.MAN.Production;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderForm : Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgProductionItems, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rgBillofMaterials, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
                raManager.AjaxSettings.AddAjaxSetting(rtbBOMOperations, (UCNotificationPanel)Master.FindControl("NotificationPanel"));

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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetProductionOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1), false);
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

        protected void GetProductionOrder(int orderId)
        {
            ProductionOrder order = _porder.GetProductionOrderHeader(orderId);

            if (order.ProductionOrderId <= 0)
            {
                Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1));
            }

            ProductionOrderId = order.ProductionOrderId;
            JobOrderId = order.JobOrderId;
            lblProductionOrder.Text = order.ProductionOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblOrderDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "delete":
                    Response.Redirect(string.Format("prod-order-delete.aspx?id={0}&jid={1}", ProductionOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("prod-order-post.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "jorder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "porder":
                    Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", ProductionOrderId), false);
                   break;
            }
        }

        protected void rtbBOMOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "fillrm":
                    AddProductRawMaterials();
                    break;
                case "deleterm":
                    DeleteProductRawMaterials();
                    break;
            }
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgProductionItems.DataSource = _porder.GetProductionOrderLines(ProductionOrderId);
        }

        protected void rgBillofMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterials.DataSource = _porder.GetProductionOrderBomLines(ProductionOrderId);
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _porder.GetProductionOrderBomLinesQuantityCheck(ProductionOrderId);
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

        protected void rtsProductionOrder_TabClick(object sender, RadTabStripEventArgs e)
        {
            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();
        }

        protected void rgProductionItems_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Production/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgProductionItems_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;

                UpdateOrderLine(lineId, itemId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateOrderLine(int lineId, int itemId, decimal quantity)
        {
            ProductionOrderLine line = new ProductionOrderLine();

            line.ProductionOrderId = ProductionOrderId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _porder.UpdateOrderLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");

            }
        }

        protected void AddProductRawMaterials()
        {
            int itemId = (from GridDataItem item in rgProductionItems.MasterTableView.Items select item.GetDataKeyValue("ItemId").ToInt()).FirstOrDefault();

            string rMessage;
            _porder.AddProductRawMaterials(ProductionOrderId, itemId, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("prod_order_rm_add_success"), "Add Product Raw Materials");
        }

        protected void DeleteProductRawMaterials()
        {
            int itemId = (from GridDataItem item in rgProductionItems.MasterTableView.Items select item.GetDataKeyValue("ItemId").ToInt()).FirstOrDefault();

            string rMessage;
            _porder.DeleteProductRawMaterials(ProductionOrderId, itemId, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("prod_order_rm_delete_success"), "Delete Raw Materials");
        }

        protected void rgBillofMaterials_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgBillofMaterials.EditIndexes.Clear();

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Production/UCRMItemAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Production/UCRMItemEdit.ascx";
                    break;
            }
        }

        protected void rgBillofMaterials_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int itemId = ((UCRMItemAdd)uc).ItemId;
                decimal quantity = ((UCRMItemAdd)uc).Quantity;

                AddRawMaterialLine(itemId, quantity);

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
                decimal quantity = ((UCRMItemEdit)uc).Quantity;

                UpdateRawMaterialLine(lineId, quantity);
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

                DeleteRawMaterialLine(lineId);
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddRawMaterialLine(int itemId, decimal quantity)
        {
            ProductionOrderBomLine line = new ProductionOrderBomLine();

            line.ProductionOrderId = ProductionOrderId;
            foreach (GridDataItem item in rgProductionItems.MasterTableView.Items)
            {
                line.ProductionItemId = item.GetDataKeyValue("ItemId").ToInt();
                break;
            }
            line.ItemId = itemId;
            line.Quantity = quantity;

            if (line.ProductionItemId == itemId)
            {             
                AppNotification.MessagePanelFailed(GeneralResources.GetStringFromResources("prod_order_main_item_exists"), "Failed");
            }
            else
            {
                string rMessage;
                _porder.AddRawMaterialLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                }
                else
                {
                    AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Raw Material");
                }
            }          
        }

        protected void UpdateRawMaterialLine(int lineId, decimal quantity)
        {
            ProductionOrderBomLine line = new ProductionOrderBomLine();

            line.ProductionOrderId = ProductionOrderId;
            line.LineId = lineId;
            line.Quantity = quantity;

            string rMessage;
            _porder.UpdateRawMaterialLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Raw Material");
            }
        }

        protected void DeleteRawMaterialLine(int lineId)
        {
            ProductionOrderBomLine line = new ProductionOrderBomLine();

            line.ProductionOrderId = ProductionOrderId;
            line.LineId = lineId;

            string rMessage;
            _porder.DeleteRawMaterialLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Raw Material");
            }
        }

        //************************************** Properties ************************************//

        public int ProductionOrderId
        {
            get { return ViewState["ProductionOrderId"] != null ? ViewState["ProductionOrderId"].ToInt() : -1; }
            set { ViewState["ProductionOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}