using System;
using System.Collections;
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
    public partial class SalesInvoiceMdr2 : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        // create sales invoice from multiple delivery note by merge the group manually

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCustomerList();
            }
        }

        protected void GetCustomerList()
        {

            DataTable dt = _delivery.GetCustomersListNotBilledDeliveryReceipt();

            if (dt.Rows.Count == 0)
            {
                rcbCustomer.Items.Clear();
                rcbCustomer.Items.Add(new RadComboBoxItem("No customer found", "-1"));

                pnlSalesOrder.Visible = false;
                pnlDeliveryReceipt.Visible = false;

                return;
            }

            rcbCustomer.DataSource = dt;
            rcbCustomer.DataBind();
        }

        protected void GetSalesOrderList(int customerId)
        {
            DataTable dt = _delivery.GetSalesOrderNotBilledDeliveryReceipt(customerId);

            if (dt.Rows.Count == 0)
            {
                AppNotification.MessageBoxWarning("No available Orders");
                pnlSalesOrder.Visible = false;
                return;
            }

            ddlSalesOrder.DataTextField = "OrderNumber";
            ddlSalesOrder.DataValueField = "OrderId";

            ddlSalesOrder.DataSource = dt;
            ddlSalesOrder.DataBind();

            pnlSalesOrder.Visible = true;

            if (ddlSalesOrder.Items.Count == 1)
            {
                cblDeliveryReceipts.Items.Clear();
                GetDeliveryReceiptList(customerId, ddlSalesOrder.SelectedValue.ToInt());
            }
            else if (ddlSalesOrder.Items.Count > 1)
            {
                cblDeliveryReceipts.Items.Clear();
                ddlSalesOrder.Items.Insert(0, new ListItem("-- Select Order --", "-1"));
            }
        }

        protected void GetDeliveryReceiptList(int customerId, int orderId)
        {
            DataTable dt = _delivery.GetNotBilledDeliveryReceiptBySalesOrder(customerId, orderId);

            if (dt.Rows.Count == 0)
            {
                AppNotification.MessageBoxWarning("No available Delivery Receipts");
                pnlDeliveryReceipt.Visible = false;
                return;
            }

            cblDeliveryReceipts.DataValueField = "ReceiptId";
            cblDeliveryReceipts.DataTextField = "ReceiptNumber";

            cblDeliveryReceipts.DataSource = dt;
            cblDeliveryReceipts.DataBind();

            pnlDeliveryReceipt.Visible = true;
        }

        protected void rcbCustomer_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            pnlDeliveryReceipt.Visible = false;

            int customerId = rcbCustomer.SelectedValue.ToInt();

            if (customerId > 0)
            {
                ddlSalesOrder.Items.Clear();
                GetSalesOrderList(customerId);
            }
        }

        protected void ddlSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDeliveryReceipt.Visible = false;

            int customerId = rcbCustomer.SelectedValue.ToInt();
            int orderId = ddlSalesOrder.SelectedValue.ToInt();

            if (customerId > 0 && orderId > 0)
            {
                cblDeliveryReceipts.Items.Clear();
                GetDeliveryReceiptList(customerId, orderId);
            }
        }

        protected void btnDeliveryReceipts_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            try
            {
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
                GetCustomerDeliveryReceipts();
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

            ddlPaymentMethod.DataTextField = "Name";
            ddlPaymentMethod.DataValueField = "paymentMethodId";
            ddlPaymentMethod.DataSource = lookup.GetPaymentMethod();
            ddlPaymentMethod.DataBind();
            ddlPaymentMethod.SelectedValue = _invoice.DefaultPaymentMethodId.ToString();

            ddlPaymentTerms.DataTextField = "Name";
            ddlPaymentTerms.DataValueField = "PaymentId";
            ddlPaymentTerms.DataSource = lookup.GetPaymentTerms();
            ddlPaymentTerms.DataBind();
            ddlPaymentTerms.SelectedValue = _invoice.DefaultPaymentTermsId.ToString();
        }

        protected void GetCustomerDeliveryReceipts()
        {
            CustomerId = rcbCustomer.SelectedValue.ToInt();
            SalesOrderId = ddlSalesOrder.SelectedValue.ToInt();

            List<int> lstReceiptsIds = new List<int>();

            foreach (ListItem item in cblDeliveryReceipts.Items.Cast<ListItem>().Where(item => item.Selected))
            {
                lstReceiptsIds.Add(item.Value.ToInt());
                rlbDeliveryReceipts.Items.Add(new RadListBoxItem(item.Text));
            }

            ReceiptsIdList = lstReceiptsIds;

            if (lstReceiptsIds.Count == 0)
            {
                AppNotification.MessageBoxWarning("Please select at least one delivery receipt.");
                return;
            }

            DeliveryReceipt deliveryRcpt = _delivery.GetMultipleDeliveryReceiptHeader(CustomerId, SalesOrderId, ReceiptsIdList);

            if (deliveryRcpt.ReceiptId == -1)
            {
                Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
            }

            if (deliveryRcpt.ReceiptId == -2)
            {
                AppNotification.MessageBoxWarning("Oops ! Something went wrong, Please check it with the system administrator and try again.");
                return;
            }

            lblCustomerName.Text = deliveryRcpt.CustomerName;
            lblSalesOrderNumber.Text = deliveryRcpt.SalesOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblJobOrderNumber.Text = deliveryRcpt.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            txtSubTotal.Text = deliveryRcpt.SubTotal.ToDecimalFormat();
            txtDiscount.Text = deliveryRcpt.Discount.ToDecimalFormat();
            txtGrandTotal.Text = deliveryRcpt.GrandTotal.ToDecimalFormat();

            LstLines = _delivery.GetMultipleDeliveryReceiptSalesInvoiceLines(ReceiptsIdList);

            if (LstLines.Where(s => s.ParentId == -1).ToList().Count == 0)
            {
                AppNotification.MessageBoxWarning("No available items in The Delivery Receipts");
                return;
            }
            rgSalesInvoice.Rebind();

            pnlDeliveryReceiptsCustomer.Visible = false;
            pnlDeliveryReceipts.Visible = true;
        }

        public List<DeliveryReceiptLine> GetMainLines()
        {
            return LstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<DeliveryReceiptLine> GetSubLines(int parentId)
        {
            return LstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgSalesInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgSalesInvoice.DataSource = GetMainLines();
            }
        }

        protected void rgSalesInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgSalesInvoice_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgSalesInvoice.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    if (itemId != -1)
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgSalesInvoice_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        public bool CompareGroups(List<DeliveryReceiptLine> list1, List<DeliveryReceiptLine> list2)
        {
            if ((list1 == null && list2 != null) || (list2 == null && list1 != null))
                return false;

            if (list1 == null)
                return true;

            if (list1.Count != list2.Count)
                return false;

            bool isEqual = true;

            foreach (DeliveryReceiptLine item in list1)
            {
                DeliveryReceiptLine object1 = item;
                DeliveryReceiptLine object2 = list2.ElementAt(list1.IndexOf(item));

                if (object1.ItemId != object2.ItemId || object1.NetPrice != object2.NetPrice)
                {
                    isEqual = false;
                    break;
                }
            }
            return isEqual;
        }

        private void MergeGroups()
        {
            ArrayList groupIds = new ArrayList();

            //foreach (GridDataItem item in rgSalesInvoice.MasterTableView.Items)
            //{
            //    if (((CheckBox)item.FindControl("cbItem")).Checked)
            //    {
            //        groupIds.Add(item.GetDataKeyValue("LineId").ToInt());
            //    }
            //}

            foreach (GridDataItem item in rgSalesInvoice.MasterTableView.Items.Cast<GridDataItem>().Where(item => ((CheckBox)item.FindControl("cbItem")).Checked))
            {
                groupIds.Add(item.GetDataKeyValue("LineId").ToInt());
            }

            if (groupIds.Count == 0)
            {
                AppNotification.MessageBoxWarning("No Group selected");
                return;
            }
            else if (groupIds.Count == 1)
            {
                AppNotification.MessageBoxWarning("One Group selected");
                return;
            }
            else if (groupIds.Count == 2)
            {
                //to do check the name of the selcted group if their are the same 

                int groupId1 = groupIds[0].ToInt();
                int groupId2 = groupIds[1].ToInt();

                var grouped1 = LstLines.Where(s => s.ParentId == groupId1).ToList();
                var grouped2 = LstLines.Where(s => s.ParentId == groupId2).ToList();

                bool isEqual = CompareGroups(grouped1, grouped2);

                if (!isEqual)
                {
                    AppNotification.MessageBoxWarning("Operation failed, You can't Merge Groups because the selected groups don't have the same sub Items");
                    return;
                }

                decimal qty = LstLines.Where(s => s.LineId == groupId2)
                                      .Select(c => c.Quantity).FirstOrDefault();

                LstLines.RemoveAll(x => x.LineId == groupId2); // remove parent
                LstLines.RemoveAll(x => x.ParentId == groupId2); // remove child

                DeliveryReceiptLine newGroup = LstLines.FirstOrDefault(c => c.LineId == groupId1);
                newGroup.Quantity += qty;
                newGroup.TotalPrice = Math.Round((newGroup.Quantity * newGroup.NetPrice), 3);

                LstLines.RemoveAll(x => x.LineId == groupId1); // remove parent ( remove item from the first group and add object again)

                LstLines.Add(newGroup);

                rgSalesInvoice.Rebind();
            }
            else
            {
                AppNotification.MessageBoxWarning("More than two Groups selected");
                return;
            }
        }

        protected void btnMerge_Click(object sender, EventArgs e)
        {
            MergeGroups();
        }

        void UpdateTotalSummary()
        {
            try
            {
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Value.ToDecimal(), txtDiscount.Value.ToDecimal(), false).ToDecimalFormat();
                AppNotification.MessageBoxSuccess("Operation done successfully");
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            UpdateTotalSummary();
        }

        private DataTable DeliveryReceiptsTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("ReceiptId", typeof(int)));
            dt.Columns.Add(new DataColumn("LineId", typeof(int)));
            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));

            return dt;
        }

        private DataTable GetDeliveryReceiptsTable()
        {
            DataTable dt = DeliveryReceiptsTable("tblLines");

            foreach (GridDataItem item in rgSalesInvoice.MasterTableView.Items)
            {
                var dr = dt.NewRow();

                dr["ReceiptId"] = item["ReceiptId"].Text.ToInt();
                dr["LineId"] = item.GetDataKeyValue("LineId").ToInt();
                dr["ItemId"] = item.GetDataKeyValue("ItemId").ToInt();
                dr["Quantity"] = item["Quantity"].Text.ToDecimal();
                dt.Rows.Add(dr);
            }

            return dt;
        }

        protected void CreateSalesInvoice()
        {
            DataTable dtLines = GetDeliveryReceiptsTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                return;
            }

            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceDate = UCDate.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.PaymentMethodId = ddlPaymentMethod.SelectedValue.ToInt();
            invoice.PaymentTermsId = ddlPaymentTerms.SelectedValue.ToInt();

            invoice.SubTotal = txtSubTotal.Value.ToDecimal();
            invoice.Discount = txtDiscount.Value.ToDecimal();
            invoice.IsPercentDiscount = false;
            //invoice.Tax = Tax;
            invoice.GrandTotal = txtGrandTotal.Value.ToDecimal();

            string rMessage;
            var invoiceId = _invoice.CreateSalesInvoiceFromMultipleDeliveryReceiptNote(invoice, dsLines.GetXml(), ReceiptsIdList, out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", invoiceId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateSalesInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("sales-invoice-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private int CustomerId
        {
            get { return ViewState["CustomerId"] != null ? ViewState["CustomerId"].ToInt() : -1; }
            set { ViewState["CustomerId"] = value; }
        }

        private int SalesOrderId
        {
            get { return ViewState["SalesOrderId"] != null ? ViewState["SalesOrderId"].ToInt() : -1; }
            set { ViewState["SalesOrderId"] = value; }
        }

        private List<int> ReceiptsIdList
        {
            get { return ViewState["ReceiptsIdList"] != null ? (List<int>)ViewState["ReceiptsIdList"] : new List<int>(); }
            set { ViewState["ReceiptsIdList"] = value; }
        }

        private List<DeliveryReceiptLine> LstLines
        {
            get { return ViewState["LstLines"] != null ? (List<DeliveryReceiptLine>)ViewState["LstLines"] : new List<DeliveryReceiptLine>(); }
            set { ViewState["LstLines"] = value; }
        }
    }
}