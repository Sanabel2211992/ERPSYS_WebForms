using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderAdjust : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgSalesOrder, (UCNotification)Master.FindControl("NotificationBox"));
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
            lblOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");

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
        }

        protected List<SalesOrderLine> GetSalesOrderLines(int orderId)
        {
            List<SalesOrderLine> salesOrderItems = _order.GetSalesOrderMainLines(orderId);
            return salesOrderItems;
        }

        protected void rgSalesOrder_PreRender(object sender, EventArgs e)
        {

        }

        protected void rgSalesOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable && SalesOrderId > 0)
            {
                rgSalesOrder.DataSource = GetSalesOrderLines(SalesOrderId);
            }
        }

        protected void rgSalesOrder_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int orderLineId = dataItem.GetDataKeyValue("LineId").ToInt();

            switch (e.DetailTableView.Name)
            {
                case "SubItems":
                    {
                        e.DetailTableView.DataSource = _order.GetSalesOrderSubLine(SalesOrderId, orderLineId);
                        break;
                    }
            }
        }

        protected void rgSalesOrder_ItemDataBound(object sender, GridItemEventArgs e)
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

        protected void rgSalesOrder_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Exclude":
                    {
                        GridDataItem dataItem = (GridDataItem)(e.Item);
                        int parentId = dataItem.GetDataKeyValue("ParentId").ToInt();
                        int lineId = dataItem.GetDataKeyValue("LineId").ToInt();

                        ExcludeLine(parentId, lineId);
                    }
                    break;
            }
        }

        protected void ExcludeLine(int parentId, int lineId)
        {
            SalesOrderLine line = new SalesOrderLine();

            line.OrderId = SalesOrderId;
            line.ParentId = parentId;
            line.LineId = lineId;

            string rMessage;
            _order.ExcludeLineFromGroup(line, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
            }
            else
            {
                AppNotification.MessageBoxSuccess("Operation done successfully");
            }

            BindData();
        }

        private void BindData()
        {
            rgSalesOrder.Rebind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-order-preview.aspx?id={0}", SalesOrderId), false);
        }

        //************************************** Properties ************************************//

        private int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }
    }
}