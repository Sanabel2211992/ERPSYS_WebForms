using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.HierarchyItems.SM.JobOrder;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderForm : Page
    {
        readonly JobOrderBLL _order = new JobOrderBLL();

        public JobOrderForm()
        {
            GetMaster = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgJobOrder, (UCNotificationPanel)Master.FindControl("NotificationPanel"));
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
                    GetJobOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1), false);
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

        protected void GetJobOrder(int orderId)
        {
            JobOrder order = _order.GetJobOrderHeader(orderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
            }

            JobOrderId = orderId;
            lblOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = order.OrderDate;
            UCCustomer.CustomerId = order.CustomerId;
            UCCustomer.CustomerName = order.CustomerName;
            txtProjectName.Text = order.ProjectName;
            txtRemarks.Text = order.Remarks;
        }

        protected List<JobOrderLine> GetJobOrderLines(int orderId)
        {
            return _order.GetJobOrderMainLines(orderId);
        }

        protected void rgJobOrder_PreRender(object sender, EventArgs e)
        {
            if (GetMaster)
            {
                BindData();
            }

            if (NewMainLineId > 0)
            {
                foreach (GridDataItem item in rgJobOrder.MasterTableView.Items)
                {
                    if (item["ParentId"].Text.ToInt() == -1 && item.GetDataKeyValue("ItemId").ToInt() == -1 && item.GetDataKeyValue("LineId").ToInt() == NewMainLineId)
                    {
                        item.Expanded = true;
                        NewMainLineId = -1;
                    }
                }
            }
        }

        protected void rgJobOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && JobOrderId > 0)
            {
                rgJobOrder.DataSource = GetJobOrderLines(JobOrderId);
            }
        }

        protected void rgJobOrder_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int orderLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _order.GetJobOrderSubLine(JobOrderId, orderLineId);
                        break;
                    }
            }
        }

        protected void rgJobOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "MainItem")
            {
                GridDataItem item = e.Item as GridDataItem;

                if (item.GetDataKeyValue("ItemId").ToInt() > 0)
                {
                    TableCell cell = (TableCell)(e.Item as GridDataItem)["ExpandColumn"];
                    cell.Controls[0].Visible = false;
                }
            }
        }

        protected void rgJobOrder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.Item.OwnerTableView.Name)
            {
                case "MainItem":
                    switch (e.CommandName)
                    {
                        case RadGrid.ExpandCollapseCommandName:
                            foreach (GridItem item in e.Item.OwnerTableView.Items)
                            {
                                if (item.Expanded && item != e.Item)
                                {
                                    item.Expanded = false;
                                }
                            }
                            break;
                        case RadGrid.InitInsertCommandName:
                            e.Canceled = true;
                            rgJobOrder.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/JobOrder/UCMainItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/JobOrder/UCMainItemEdit.ascx";
                            break;
                    }
                    break;
                case "SubItems":
                    switch (e.CommandName)
                    {
                        case RadGrid.InitInsertCommandName:
                            e.Canceled = true;
                            rgJobOrder.EditIndexes.Clear();

                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/JobOrder/UCSubItemAdd.ascx";
                            e.Item.OwnerTableView.InsertItem();
                            break;
                        case RadGrid.EditCommandName:
                            e.Item.OwnerTableView.IsItemInserted = false;
                            e.Item.OwnerTableView.EditFormSettings.UserControlName = @"~/Controls/HierarchyItems/SM/JobOrder/UCSubItemEdit.ascx";
                            break;
                    }
                    break;
            }
        }

        protected void rgJobOrder_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void rgJobOrder_InsertCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem iItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int itemId = ((UCMainItemAdd)uc).ItemId;
                    string itemCode = ((UCMainItemAdd)uc).ItemCode;
                    string partNumber = ((UCMainItemAdd)uc).PartNumber;
                    string description = ((UCMainItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemAdd)uc).Quantity;

                    AddOrderMainLine(itemId, partNumber, itemCode, description, quantity);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = ((GridDataItem)(e.Item.OwnerTableView.ParentItem));
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

                    int itemId = ((UCSubItemAdd)uc).ItemId;
                    string itemCode = ((UCSubItemAdd)uc).ItemCode;
                    string partNumber = ((UCSubItemAdd)uc).PartNumber;
                    string description = ((UCSubItemAdd)uc).DescriptionAs;
                    decimal quantity = ((UCSubItemAdd)uc).Quantity;

                    AddOrderSubLine(parentId, itemId, partNumber, itemCode, description, quantity);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgJobOrder_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem eItem = ((GridEditableItem)(e.Item));
            UserControl uc = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = ((UCMainItemEdit)uc).ItemId;
                    string description = ((UCMainItemEdit)uc).DescriptionAs;
                    decimal quantity = ((UCMainItemEdit)uc).Quantity;

                    UpdateOrderMainLine(lineId, itemId, description, quantity);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = ((GridDataItem)(e.Item.OwnerTableView.ParentItem));
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();
                    int lineId = eItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = eItem.GetDataKeyValue("ItemId").ToInt();
                    string description = ((UCSubItemEdit)uc).DescriptionAs;
                    decimal quantity = ((UCSubItemEdit)uc).Quantity;

                    UpdateOrderSubLine(parentId, lineId, itemId, description, quantity);
                }
            }
            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgJobOrder_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridEditableItem dItem = ((GridEditableItem)(e.Item));
            try
            {
                if (e.Item.OwnerTableView.Name == "MainItem")
                {
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();

                    DeleteOrderMainLine(lineId);
                }
                else if (e.Item.OwnerTableView.Name == "SubItems")
                {
                    GridDataItem dataItem = ((GridDataItem)(e.Item.OwnerTableView.ParentItem));
                    int parentId = dataItem.GetDataKeyValue("LineId").ToInt();
                    int lineId = dItem.GetDataKeyValue("LineId").ToInt();
                    int itemId = dItem.GetDataKeyValue("ItemId").ToInt();

                    DeleteOrderSubLine(parentId, lineId, itemId);
                }
            }

            catch (Exception ex)
            {
                e.Canceled = true;
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void AddOrderMainLine(int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;

            string rMessage;
            NewMainLineId = _order.AddMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
            }
        }

        protected void UpdateOrderMainLine(int lineId, int itemId, string description, decimal quantity)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.DescriptionAs = description;
            line.Quantity = quantity;

            string rMessage;
            _order.UpdateMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
            }
        }

        protected void DeleteOrderMainLine(int lineId)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.LineId = lineId;

            string rMessage;
            _order.DeleteMainLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Items_delete_success"), "Delete Product");
            }
        }

        protected void AddOrderSubLine(int parentId, int itemId, string partNumber, string itemCode, string descriptionAs, decimal quantity)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.ParentId = parentId;
            line.ItemId = itemId;
            line.PartNumber = partNumber;
            line.ItemCode = itemCode;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;

            string rMessage;
            var lineId = _order.AddSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_add_success"), "Add Product");
                GetMaster = true;
            }
        }

        protected void UpdateOrderSubLine(int parentId, int lineId, int itemId, string descriptionAs, decimal quantity)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;
            line.DescriptionAs = descriptionAs;
            line.Quantity = quantity;

            string rMessage;
            _order.UpdateSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_update_success"), "Update Product");
                GetMaster = true;
            }
        }

        protected void DeleteOrderSubLine(int parentId, int lineId, int itemId)
        {
            JobOrderLine line = new JobOrderLine();

            line.OrderId = JobOrderId;
            line.ParentId = parentId;
            line.LineId = lineId;
            line.ItemId = itemId;

            string rMessage;
            _order.DeleteSubLine(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessagePanelFailed(rMessage, "Failed");
            }
            else
            {
                AppNotification.MessagePanelSuccess(GeneralResources.GetStringFromResources("global_grid_Item_delete_success"), "Delete Product");
                GetMaster = true;
            }
        }

        private void BindData()
        {
            rgJobOrder.Rebind();
        }

        protected void UpdateJobOrderHeader()
        {
            JobOrder order = new JobOrder();

            order.OrderId = JobOrderId;
            order.CustomerId = UCCustomer.CustomerId;
            order.OrderDate = UCDatePicker.DateValue;
            order.ProjectName = txtProjectName.Text.ToTrimString();
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            _order.UpdateJobOrderHeader(order, out rMessage);

            if (rMessage != string.Empty || JobOrderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_update_success"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateJobOrderHeader();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("job-order-preview.aspx?id={0}", JobOrderId), false);
        }

        //************************************** Properties ************************************//

        private int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }

        private bool GetMaster { get; set; }

        private int NewMainLineId
        {
            get { return ViewState["NewMainItemId"] != null ? ViewState["NewMainItemId"].ToInt() : -1; }
            set { ViewState["NewMainItemId"] = value; }
        }
    }
}