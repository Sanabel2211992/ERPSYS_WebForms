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
using ERPSYS.Controls.HierarchyItems.MAN.Assembly;
using System.Data;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderForm : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _assembly = new AssemblyOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgAssemblyItems, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetItemLookupTables();
                    GetAssemblyOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1), false);
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

            DataTable dtLocations = lookup.GetAssemblyLocation();

            ddlAssemblyLocation.DataTextField = "Name";
            ddlAssemblyLocation.DataValueField = "LocationId";
            ddlAssemblyLocation.DataSource = dtLocations;
            ddlAssemblyLocation.DataBind();
            ddlAssemblyLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlMaterialLocation.DataTextField = "Name";
            ddlMaterialLocation.DataValueField = "LocationId";
            ddlMaterialLocation.DataSource = dtLocations;
            ddlMaterialLocation.DataBind();
            ddlMaterialLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetAssemblyOrder(int orderId)
        {
            AssemblyOrder order = _assembly.GetAssemblyOrderHeaderX(orderId);

            if (order.AssemblyOrderId <= 0)
            {
                Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1));
            }

            AssemblyOrderId = order.AssemblyOrderId;
            JobOrderId = order.JobOrderId;
            lblAssemblyOrder.Text = order.AssemblyOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            ddlAssemblyLocation.Text = order.ItemLocationId.ToString();
            ddlMaterialLocation.Text = order.BomLocationId.ToString();
            txtRemarks.Text = order.Remarks;
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "delete":
                    Response.Redirect(string.Format("assembly-order-delete.aspx?id={0}&jid={1}", AssemblyOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("assembly-order-post.aspx?id={0}", AssemblyOrderId), false);
                    break;
                case "jorder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "assmorder":
                    Response.Redirect(string.Format("assembly-order-preview.aspx?id={0}", AssemblyOrderId), false);
                    break;
            }
        }

        protected void rtbBOMOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "fillm":
                    AddProductMaterials();
                    break;
                case "deletem":
                    DeleteProductMaterials();
                    break;
            }
        }

        protected void AddProductMaterials()
        {
            int itemId = (from GridDataItem item in rgAssemblyItems.MasterTableView.Items select item.GetDataKeyValue("ItemId").ToInt()).FirstOrDefault();

            string rMessage;
            _assembly.AddAssemblyOrderProductMaterialsX(AssemblyOrderId, itemId, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("prod_order_rm_add_success"), "Add Product Raw Materials");
        }

        protected void DeleteProductMaterials()
        {
            int itemId = (from GridDataItem item in rgAssemblyItems.MasterTableView.Items select item.GetDataKeyValue("ItemId").ToInt()).FirstOrDefault();

            string rMessage;
            _assembly.DeleteAssemblyOrderProductMaterialsX(AssemblyOrderId, itemId, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("prod_order_rm_delete_success"), "Delete Raw Materials");
        }

        protected void rgAssemblyItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgAssemblyItems.DataSource = _assembly.GetAssemblyOrderLineX(AssemblyOrderId);
        }

        protected void rgAssemblyItems_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Assembly/UCItemEdit.ascx";
                    break;
            }
        }

        protected void rgAssemblyItems_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;

                UpdateOrderLine(itemId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateOrderLine(int itemId, decimal quantity)
        {
            AssemblyOrder line = new AssemblyOrder();

            line.AssemblyOrderId = AssemblyOrderId;
            line.ItemId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _assembly.UpdateOrderLineX(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void UpdateAssemblyOrderHeader()
        {

            AssemblyOrder order = new AssemblyOrder();

            order.AssemblyOrderId = AssemblyOrderId;
            order.ItemLocationId = ddlAssemblyLocation.SelectedValue.ToInt();
            order.BomLocationId = ddlMaterialLocation.SelectedValue.ToInt();
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _assembly.UpdateAssemblyOrderHeaderX(order, out rMessage);

            if (rMessage != string.Empty || AssemblyOrderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_assembly_order_update_success"));
        }

        protected void rtsAssemblyOrder_TabClick(object sender, RadTabStripEventArgs e)
        {
            rgBillofMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();
        }

        protected void rgBillofMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterials.DataSource = _assembly.GetAssemblyOrderBomLinesX(AssemblyOrderId);
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _assembly.GetAssemblyOrderBomLinesQuantityCheckX(AssemblyOrderId);
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

                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Assembly/UCMaterialAdd.ascx";
                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;
                    e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Assembly/UCMaterialEdit.ascx";
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
                int itemId = dItem.GetDataKeyValue("ItemBomId").ToInt();

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
            AssemblyBomLine line = new AssemblyBomLine();

            line.AssemblyOrderId = AssemblyOrderId;
            line.ItemBomId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _assembly.AddBomLineX(line, out rMessage);

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
            AssemblyBomLine line = new AssemblyBomLine();

            line.AssemblyOrderId = AssemblyOrderId;
            line.LineId = lineId;
            line.ItemBomId = itemId;
            line.Quantity = quantity;

            string rMessage;
            _assembly.UpdateBomLineX(line, out rMessage);

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
            AssemblyBomLine line = new AssemblyBomLine();

            line.AssemblyOrderId = AssemblyOrderId;
            line.ItemBomId = itemId;
            line.LineId = lineId;

            string rMessage;
            _assembly.DeleteBomLineX(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Raw Material");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateAssemblyOrderHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int AssemblyOrderId
        {
            get { return ViewState["AssemblyOrderId"] != null ? ViewState["AssemblyOrderId"].ToInt() : -1; }
            set { ViewState["AssemblyOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}