using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderPreview : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();
        private List<SalesOrderLine> _lstLines = new List<SalesOrderLine>();

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
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_update_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_quote_create_success"));
                        break;
                    case "5":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_clone_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_post_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_no_records"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_group_empty"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_add_joborder_failed"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_order_delete_failed"));
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
                    GetSalesOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1), false);
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

        protected void GetSalesOrder(int orderId)
        {
            SalesOrder order = _order.GetSalesOrderHeader(orderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1));
            }

            SalesOrderId = order.OrderId;
            JobOrderId = order.JobOrderId;
            lblOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            hlnkCustomerName.Text = order.CustomerName;
            if (order.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", order.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblPreparedBy.Text = order.UserName;
            lblStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblCustomerPO.Text = order.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = order.Remarks.ReplaceWhenNullOrEmpty("N/A");

            lblSubTotal.Text = order.SubTotal.ToDecimalFormat();
            lblExpenses.Text = order.Expenses.ToDecimalFormat();
            lblDiscount.Text = order.Discount.ToDecimalFormat();
            lblGrandTotal.Text = order.GrandTotal.ToDecimalFormat();

            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(order.SubTotal, 0, order.Discount, order.IsPercentDiscount, order.Tax).ToDecimalFormat();
            if (SystemProperties.HasSalesTax || order.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            if (!RegisteredUser.HasCostView)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cost"));
            }

            if (order.StatusId == 1) // draft
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("print"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderc"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderv"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("clone"));

                //rtsOrder.Tabs[1].Visible = false;
                //rtsOrder.Tabs[2].Visible = false;
                //rtsOrder.Tabs[3].Visible = false;
                //rtsOrder.Width = 125;
                rtsOrder.Tabs[1].Visible = true;
                rtsOrder.Tabs[2].Visible = true;
                rtsOrder.Tabs[3].Visible = true;
                rtsOrder.Width = 500;
            }
            else
            {
                //rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));

                switch (order.StatusId)
                {
                    case 2:
                        if (!order.IsContainGroup)
                        {
                            rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                            rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));
                        }

                        if (order.JobOrderId > 0)
                        {
                            rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderc"));
                        }

                        break;
                    case 3:

                        if (!order.IsContainGroup)
                        {
                            rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                            rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));
                        }
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderc"));

                        break;
                    case 4:
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderc"));

                        break;
                    case 5:
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderc"));

                        break;
                }

                if (order.JobOrderId <= 0)
                {
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("jorderv"));
                }

                //if ((order.IsContainGroup) && (order.StatusId == 2 || order.StatusId == 3))
                //{
                //  // btnAdjust.Visible = true;
                //}
                //else
                //{
                //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("adjust"));//btnReport.Visible = true;
                //}

                rtsOrder.Tabs[1].Visible = true;
                rtsOrder.Tabs[2].Visible = true;
                rtsOrder.Tabs[3].Visible = true;
                rtsOrder.Width = 500;
            }

            if (!order.IsContainGroup)
            {
                rtsOrder.Tabs[1].Visible = false;
                rtsOrder.Width = 375;
            }

            _lstLines = _order.GetSalesOrderLines(SalesOrderId);
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("sales-order-form.aspx?id={0}", SalesOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("sales-order-delete.aspx?id={0}", SalesOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("sales-order-post.aspx?id={0}", SalesOrderId), false);
                    break;
                case "adjust":
                    Response.Redirect(string.Format("sales-order-adjust.aspx?id={0}", SalesOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("sales-order-report.aspx?id={0}", SalesOrderId), false);
                    break;
                case "jorderc":
                    Response.Redirect(string.Format("job-order-sorder.aspx?id={0}", SalesOrderId), false);
                    break;
                case "jorderv":
                    Response.Redirect(string.Format("job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "cost":
                    Response.Redirect(string.Format("sales-order-cost.aspx?id={0}", SalesOrderId), false);
                    break;
                case "clone":
                    Response.Redirect(string.Format("sales-order-clone.aspx?id={0}", SalesOrderId), false);
                    break;
            }
        }

        public List<SalesOrderLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<SalesOrderLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgSalesOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgSalesOrder.DataSource = GetMainLines();
            }
        }

        protected void rgSalesOrder_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgSalesOrder_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgSalesOrder.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    //item.Enabled = false;

                    if (itemId == -1)
                    {
                        // item.Expanded = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgSalesOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {
            var item = e.Item as GridDataItem;
            if (item != null)
            {
                GridDataItem dataItem = item;
                Image imgService = (Image)dataItem.FindControl("imgService");
                if (dataItem["IsServiceItem"].Text.ToBool())
                {
                    imgService.ImageUrl = "../resources/images/ico_star_16_16.png";
                    imgService.ToolTip = @"Service";
                }
            }
        }

        protected void rgSalesOrderMasterLineStatus_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgSalesOrderMasterLineStatus.DataSource = _order.GetSalesOrderMasterLinesStatus(SalesOrderId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesOrderCombinedLineStatus_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgSalesOrderCombinedLineStatus.DataSource = _order.GetSalesOrderLinesCombinedStatus(SalesOrderId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgSalesOrderCombinedLineStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                if (dataItem["RemainingQuantity"].Text.ToDecimal() > 0)
                {
                    decimal x = dataItem["StockQuantity"].Text.ToDecimal() - dataItem["Quantity"].Text.ToDecimal();
                    bool isServiceItem = dataItem["IsServiceItem"].Text.ToBool();
                    imgStatus.ImageUrl = (x >= 0) || isServiceItem ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
                }
                else
                {
                    imgStatus.ImageUrl = "../resources/images/ico_allow_16.png";
                }
            }
        }

        protected void rgDelivery_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgDelivery.DataSource = _order.GetSalesOrderDeliveryReceipts(SalesOrderId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        public int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}