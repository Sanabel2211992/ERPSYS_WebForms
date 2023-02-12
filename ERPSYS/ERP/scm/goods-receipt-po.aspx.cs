using System;
using System.Data;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptPO : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOpenPurchaseOrder();
            }
        }

        protected void GetOpenPurchaseOrder()
        {
            try
            {
                ddlPurchaseOrderList.DataTextField = "OrderNumber";
                ddlPurchaseOrderList.DataValueField = "PurchaseOrderId";
                ddlPurchaseOrderList.DataSource = _scm.GetOpenPurchaseOrderList();
                ddlPurchaseOrderList.DataBind();

                ddlPurchaseOrderList.Items.Insert(0, new ListItem("-- Select Order --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnGetPurchaseOrder_Click(object sender, EventArgs e)
        {
            int purchaseOrderId = ddlPurchaseOrderList.SelectedValue.ToInt();

            if (purchaseOrderId > 0)
            {
                pnlGoodsReceipt.Visible = true;
                InitializeComponent(purchaseOrderId);
            }
        }

        private void InitializeComponent(int purchaseOrderId)
        {
            try
            {
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
                GetPurchaseOrder(purchaseOrderId);
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
            ddlLocation.DataSource = lookup.GetGoodsReceiptLocation();
            ddlLocation.DataBind();

            ddlLocation.SelectedValue = _scm.DefaultGoodsReceivedLocationId.ToString();
        }

        protected void GetPurchaseOrder(int purchaseOrderId)
        {
            PurchaseOrder purchaseOrder = _scm.GetPurchaseOrderHeader(purchaseOrderId);

            if (purchaseOrder.PurchaseOrderId <= 0)
            {
                Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
            }

            PurchaseOrderId = purchaseOrder.PurchaseOrderId;
            lblPurchaseOrderNumber.Text = purchaseOrder.OrderNumber;
            lblSupplierName.Text = purchaseOrder.SupplierName;

            rgGoodReceipt.DataSource = _scm.GetPurchaseOrderLinesToGoodsReceipt(purchaseOrderId);
            rgGoodReceipt.DataBind();
        }

        protected void rgGoodReceipt_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                decimal x = dataItem["statusId"].Text.ToInt();

                if (x == 3)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = false;
                    ((CheckBox)dataItem.FindControl("cbItem")).Enabled = false;
                    ((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Text = @"0";
                    ((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Enabled = false;

                }
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((GridItem)((CheckBox)sender).NamingContainer).Selected = ((CheckBox)sender).Checked;
            ((RadNumericTextBox)((GridItem)((CheckBox)sender).NamingContainer).FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;

            bool checkHeader = rgGoodReceipt.MasterTableView.Items.Cast<GridDataItem>().All(dataItem => ((CheckBox) dataItem.FindControl("cbItem")).Checked);
            GridHeaderItem headerItem = rgGoodReceipt.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null) ((CheckBox)headerItem.FindControl("cbAllItems")).Checked = checkHeader;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in rgGoodReceipt.MasterTableView.Items.Cast<GridDataItem>().Where(dataItem => headerCheckBox != null).Where(dataItem => headerCheckBox != null && dataItem.Cells[12].Text.ToInt() !=3))
            {
                if (headerCheckBox != null)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = headerCheckBox.Checked;
                    ((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;
                    dataItem.Selected = headerCheckBox.Checked;
                }
            }
        }

        private DataTable GoodsReceiptTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));

            return dt;
        }

        private DataTable GetGoodsReceiptTable()
        {
            DataTable dt = GoodsReceiptTable("tblLines");

            foreach (GridDataItem item in rgGoodReceipt.Items)
            {
                if (((CheckBox)item.FindControl("cbItem")).Checked)
                {
                    decimal quantity = ((RadNumericTextBox)item.FindControl("txtQuantity")).Text.ToDecimal();

                    //if ((quantity <= 0) || (quantity > item.Cells[12].Text.ToDecimal()))
                    //{
                    //    throw new Exception("Invalid Quantity");
                    //}

                    if ((quantity <= 0))
                    {
                        throw new Exception("Invalid item quantity");
                    }

                    var dr = dt.NewRow();
                    dr["ItemId"] = item.GetDataKeyValue("ItemId").ToInt(); //dr["ItemId"] = item.Cells[5].Text.ToInt();
                    dr["Quantity"] = quantity;
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        protected void CreateGoodsReceiptNote()
        {
            DataTable dtLines = GetGoodsReceiptTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                AppNotification.MessageBoxWarning("No items selected");
                return;
            }

            GoodsReceipt goodsReceipt = new GoodsReceipt();

            goodsReceipt.ReceiptDate = UCDate.DateValue;
            goodsReceipt.LocationId = ddlLocation.SelectedValue.ToInt();
            goodsReceipt.Remarks = txtRemarks.Text.ToTrimString();
            goodsReceipt.PurchaseOrderId = PurchaseOrderId;

            string rMessage;
            var grnId = _scm.CreateGoodsReceiptNoteFromPurchaseOrder(goodsReceipt, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || grnId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("goods-receipt-preview.aspx?id={0}", grnId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateGoodsReceiptNote();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("goods-receipt-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private int PurchaseOrderId
        {
            get { return ViewState["PurchaseOrderId"] != null ? ViewState["PurchaseOrderId"].ToInt() : -1; }
            set { ViewState["PurchaseOrderId"] = value; }
        }
    }
}