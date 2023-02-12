using System;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using System.Web.UI;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.Common;
using System.Web.UI.WebControls;
using ERPSYS.Controls.HierarchyItems.MAN.Material;

namespace ERPSYS.ERP.man
{
    public partial class MaterialTransferForm : Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();
        readonly MaterialTransferBLL _transfer = new MaterialTransferBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgRawMaterials, (UCNotificationPanel)Master.FindControl("NotificationPanel"));

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
                    GetMaterialTransfer(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("../sm/job-order-list.aspx.aspx"));
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

        protected void GetMaterialTransfer(int transferId)
        {
            MaterialTransfer transfer = _transfer.GetMaterialTransferHeader(transferId);

            if (transfer.MaterialTransferId <= 0)
            {
                Response.Redirect(string.Format("../sm/job-order-list.aspx.aspx"));
            }

            if (transfer.StatusId != (int)MaterialTransferStatus.Draft)
            {
                Response.Redirect(string.Format("m-trans-preview.aspx?id={0}", transfer.MaterialTransferId), false);
            }

            TransferId = transfer.MaterialTransferId;
            TransferTypeId = transfer.TransferTypeId;
            OrderId = transfer.OrderId;
            OrderTypeId = transfer.OrderTypeId;
            lblRequestNumber.Text = transfer.MaterialTransferNumber.ReplaceWhenNullOrEmpty("N/A");
            lblRequestDate.Text = transfer.PreparedDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRequestBy.Text = transfer.PreparedBy.ReplaceWhenNullOrEmpty("N/A");
            lblRequestStatus.Text = transfer.Status.ReplaceWhenNullOrEmpty("N/A");
            lblTransferType.Text = transfer.TransferType.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = transfer.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (transfer.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", transfer.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblOrderNumber.Text = transfer.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblOrderType.Text = transfer.OrderType.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = transfer.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = transfer.Remarks.ReplaceWhenNullOrEmpty("N/A");

            lblRequestNote.Text = String.Format("All Materials will Transfer from {0} Store to {1} Store after post this request.", transfer.FromLocation.ReplaceWhenNullOrEmpty("N/A"), transfer.ToLocation.ReplaceWhenNullOrEmpty("N/A"));

            //if (TransferTypeId == (int)MaterialTransferType.Request)
            //{
            //    pnlRequestMaterials.Visible = true;
            //    pnlReturnMaterials.Visible = true;
            //}
            //else if (TransferTypeId == (int)MaterialTransferType.Return)
            //{
            //    pnlReturnMaterials.Visible = true;
            //    pnlRequestMaterials.Visible = true;
            //}
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (OrderTypeId == 1)
                {
                    rgProductionItems.DataSource = _porder.GetProductionOrderLines(OrderId);
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgRawMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgRawMaterials.DataSource = _transfer.GetMaterialTransferLines(TransferId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _transfer.GetMaterialTransferLinesQuantityCheck(TransferId);
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

        protected void rtsMaterialTransfer_TabClick(object sender, RadTabStripEventArgs e)
        {
            rgRawMaterials.Rebind();
            rgBillofMaterialsReview.Rebind();
        }

        protected void rgRawMaterials_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgRawMaterials.EditIndexes.Clear();

                    if (TransferTypeId == (int)MaterialTransferType.Request)
                    {
                        e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Material/UCItemAdd.ascx";
                    }
                    else if (TransferTypeId == (int)MaterialTransferType.Return)
                    {
                        e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Material/UCRItemAdd.ascx";
                    }

                    e.Item.OwnerTableView.InsertItem();
                    break;
                case RadGrid.EditCommandName:
                    e.Item.OwnerTableView.IsItemInserted = false;

                    if (TransferTypeId == (int)MaterialTransferType.Request)
                    {
                        e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Material/UCItemEdit.ascx";
                       
                    }
                    else if (TransferTypeId == (int)MaterialTransferType.Return)
                    {
                        e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/MAN/Material/UCItemEdit.ascx";                        
                    }
                    break;
            }
        }

        protected void rgRawMaterials_InsertCommand(object sender, GridCommandEventArgs e)
        {
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            try
            {
                int orderItemId = (from GridDataItem item in rgProductionItems.MasterTableView.Items select item.GetDataKeyValue("ItemId").ToInt()).FirstOrDefault();

                if (TransferTypeId == (int)MaterialTransferType.Request)
                {
                    int itemId = ((UCItemAdd)uc).ItemId;
                    decimal quantity = ((UCItemAdd)uc).Quantity;
                    AddRawMaterialLine(orderItemId, itemId, quantity);
                }
                else if (TransferTypeId == (int)MaterialTransferType.Return)
                {
                    int itemId = ((UCRItemAdd)uc).ItemId;
                    decimal quantity = ((UCRItemAdd)uc).Quantity;
                    AddRawMaterialLine(orderItemId, itemId, quantity);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgRawMaterials_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                decimal quantity = ((UCItemEdit)uc).Quantity;

                UpdateRawMaterialLine(lineId, quantity);
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgRawMaterials_DeleteCommand(object sender, GridCommandEventArgs e)
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

        protected void AddRawMaterialLine(int orderItemId, int itemId, decimal quantity)
        {
            MaterialTransferLine line = new MaterialTransferLine();

            line.MaterialTransferId = TransferId;
            line.OrderId = OrderId;
            line.OrderItemId = orderItemId;
            line.OrderItemQuantity = 1;
            line.ItemId = itemId;
            line.Quantity = quantity;

            if(orderItemId == itemId)
            {
                AppNotification.MessagePanelFailed(GeneralResources.GetStringFromResources("prod_order_main_item_exists"), "Failed");
            }
            else
            {
                string rMessage;
                _transfer.AddMaterialTransferLine(line, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessagePanelFailed(rMessage, "Failed");
                    return;
                }

                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product Raw Materials");
            }
            
        }

        protected void UpdateRawMaterialLine(int lineId, decimal quantity)
        {
            MaterialTransferLine line = new MaterialTransferLine();

            line.MaterialTransferId = TransferId;
            line.LineId = lineId;
            line.Quantity = quantity;

            string rMessage;
            _transfer.UpdateMaterialTransferLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Raw Material");
        }

        protected void DeleteRawMaterialLine(int lineId)
        {
            MaterialTransferLine line = new MaterialTransferLine();

            line.MaterialTransferId = TransferId;
            line.LineId = lineId;

            string rMessage;
            _transfer.DeleteMaterialTransferLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
                return;
            }

            AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Raw Material");
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "view":
                    Response.Redirect(string.Format("m-trans-preview.aspx?id={0}", TransferId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("m-trans-delete.aspx?id={0}&tid={1}&oid={2}", TransferId, OrderTypeId, OrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("m-trans-post.aspx?id={0}&tid={1}&oid={2}", TransferId, OrderTypeId, OrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("m-trans-report.aspx?id={0}", TransferId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int TransferId
        {
            get { return ViewState["TransferId"] != null ? ViewState["TransferId"].ToInt() : -1; }
            set { ViewState["TransferId"] = value; }
        }

        public int TransferTypeId
        {
            get { return ViewState["TransferTypeId"] != null ? ViewState["TransferTypeId"].ToInt() : -1; }
            set { ViewState["TransferTypeId"] = value; }
        }

        public int OrderId
        {
            get { return ViewState["OrderId"] != null ? ViewState["OrderId"].ToInt() : -1; }
            set { ViewState["OrderId"] = value; }
        }

        public int OrderTypeId
        {
            get { return ViewState["OrderTypeId"] != null ? ViewState["OrderTypeId"].ToInt() : -1; }
            set { ViewState["OrderTypeId"] = value; }
        }
    }
}