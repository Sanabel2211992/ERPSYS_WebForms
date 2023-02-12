using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.sm
{
    public partial class DeliveryReceiptSO : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOpenSalesOrder();
            }
        }

        protected void GetOpenSalesOrder()
        {
            try
            {
                ddlSalesOrderList.DataTextField = "OrderNumber";
                ddlSalesOrderList.DataValueField = "OrderId";
                ddlSalesOrderList.DataSource = _order.GetOpenSalesOrderList();
                ddlSalesOrderList.DataBind();

                ddlSalesOrderList.Items.Insert(0, new ListItem("-- Select Order --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnGetSalesOrder_Click(object sender, EventArgs e)
        {
            int salesOrderId = ddlSalesOrderList.SelectedValue.ToInt();

            if (salesOrderId > 0)
            {
                pnlDeliveryReceipt.Visible = true;
                InitializeComponent(salesOrderId);
            }
        }

        private void InitializeComponent(int salesOrderId)
        {
            try
            {
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
                GetSalesOrder(salesOrderId);
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

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetSalesLocation();
            ddlLocation.DataBind();

            ddlLocation.SelectedValue = _delivery.DefaultDeliveryReceiptLocationId.ToString();
        }

        protected void GetSalesOrder(int salesOrderId)
        {
            SalesOrder order = _order.  GetSalesOrderHeader(salesOrderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1));
            }

            SalesOrderId = order.OrderId;
            lblCustomerName.Text = order.CustomerName;
            lblSalesOrderNumber.Text = order.OrderNumber;
            lblSalesOrderStatus.Text = order.Status;

            LstLines = _order.GetSalesOrderDeliveredLines(SalesOrderId);

            if (LstLines.Where(s => s.ParentId == -1).ToList().Count == 0)
            {
                pnlDeliveryReceipt.Visible = false;
                AppNotification.MessageBoxWarning("No available items in The Sales Order, Please check all Delivery Receipt and try again.");
                return;
            }
            rgSalesOrder.Rebind();
        }

        public List<SalesOrderLine> GetMainLines()
        {
            return LstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<SalesOrderLine> GetSubLines(int parentId)
        {
            return LstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            CheckBox cbSelected = (CheckBox)sender;
            GridItem item = (GridItem)((CheckBox)sender).NamingContainer;

            item.Selected = cbSelected.Checked;
            ((RadNumericTextBox)(item.FindControl("txtDeliveredQuantity"))).Enabled = !cbSelected.Checked;
            bool checkHeader = rgSalesOrder.MasterTableView.Items.Cast<GridDataItem>().All(dataItem => ((CheckBox)dataItem.FindControl("cbItem")).Checked);
            GridHeaderItem headerItem = rgSalesOrder.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null) ((CheckBox)headerItem.FindControl("cbAllItems")).Checked = checkHeader;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox cbHeader = (sender as CheckBox);
            foreach (GridDataItem dataItem in rgSalesOrder.MasterTableView.Items)
            {
                if (cbHeader != null)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = cbHeader.Checked;
                    ((RadNumericTextBox)dataItem.FindControl("txtDeliveredQuantity")).Enabled = !((CheckBox)sender).Checked;
                    dataItem.Selected = cbHeader.Checked;
                }
            }
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

                    //if (itemId != -1)
                    //{
                    //    //item.Enabled = false;
                    //    item.Cells[0].Controls[0].Visible = false;
                    //}

                    if (itemId != -1)
                    {
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgSalesOrder_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        private DataTable DeliveryReceiptTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("OrderLineId", typeof(int)));
            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));

            return dt;
        }

        private DataTable GetDeliveryReceiptTable()
        {
            DataTable dt = DeliveryReceiptTable("tblLines");

            foreach (GridDataItem item in rgSalesOrder.MasterTableView.Items)
            {
                // only Parent Item IS NULL (Main Lines)
                if (((CheckBox)item.FindControl("cbItem")).Checked)
                {
                    decimal quantity = ((RadNumericTextBox)item.FindControl("txtDeliveredQuantity")).Text.ToDecimal();

                    var dr = dt.NewRow();

                    dr["OrderLineId"] = item.GetDataKeyValue("LineId").ToInt();
                    dr["ItemId"] = item.GetDataKeyValue("ItemId").ToInt();
                    dr["Quantity"] = quantity;
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        protected void CreateDeliveryReceiptNote()
        {
            DataTable dtLines = GetDeliveryReceiptTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                AppNotification.MessageBoxWarning("No items selected");
                return;
            }

            DeliveryReceipt deliveryReceipt = new DeliveryReceipt();

            deliveryReceipt.ReceiptDate = UCDate.DateValue;
            deliveryReceipt.LocationId = ddlLocation.SelectedValue.ToInt();
            deliveryReceipt.Remarks = txtRemarks.Text.ToTrimString();
            deliveryReceipt.SalesOrderId = SalesOrderId;

            string rMessage;
            var receiptId = _delivery.CreateDeliveryReceiptNoteFromSalesOrder(deliveryReceipt, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || receiptId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("delivery-receipt-preview.aspx?id={0}", receiptId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateDeliveryReceiptNote();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-order-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }

        private List<SalesOrderLine> LstLines
        {
            get { return (List<SalesOrderLine>) ViewState["LstLines"]; }
            set { ViewState["LstLines"] = value; }
        }
    }
}