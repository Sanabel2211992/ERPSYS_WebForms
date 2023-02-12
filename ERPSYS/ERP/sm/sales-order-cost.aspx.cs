using System;
using System.Linq;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderCost : System.Web.UI.Page
    {

        readonly SalesOrderBLL _order = new SalesOrderBLL();
        private List<SalesOrderLine> _lstLines = new List<SalesOrderLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
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

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            hlnkCustomerName.Text = order.CustomerName.ReplaceWhenNullOrEmpty("N/A");
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
            //lblExpenses.Text = order.Expenses.ToDecimalFormat();
            lblDiscount.Text = order.Discount.ToDecimalFormat();
            lblGrandTotal.Text = order.GrandTotal.ToDecimalFormat();

            _lstLines = _order.GetSalesOrderLines(SalesOrderId);
            lblTotalCost.Text = (from c in _lstLines where c.ParentId == -1 select (c.TotalCost)).Sum().ToDecimalFormat().ViewCostField();
           
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(order.SubTotal, 0, order.Discount, order.IsPercentDiscount, order.Tax).ToDecimalFormat();
            if (SystemProperties.HasSalesTax || order.Tax > 0)
            {
                pnlSalesTax.Visible = true;
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
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                TableCell totalPriceCell = dataItem["TotalPrice"];
                TableCell costCell = dataItem["UnitCost"];
                TableCell totalCostCell = dataItem["TotalCost"];

                totalCostCell.Text = totalCostCell.Text.ViewCostField();
                costCell.Text = costCell.Text.ViewCostField();

                decimal totalPrice = totalPriceCell.Text.ToDecimal();
                decimal totalCost = totalCostCell.Text.ToDecimal();
                decimal delta = totalPrice - totalCost;

                if (RegisteredUser.HasCostView && delta <= 0)
                {
                    totalCostCell.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
                    Response.Redirect(string.Format("sales-order-preview.aspx?id={0}", SalesOrderId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }
    }
}