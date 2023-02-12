using System;
using System.Collections.Generic;
using System.Linq;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceCost : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        private List<SalesInvoiceLine> _lstLines = new List<SalesInvoiceLine>();

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
                    GetSalesInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetSalesInvoice(int invoiceId)
        {
            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoice.InvoiceId;
            lblInvoiceNumber.Text = invoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            hlnkJobOrderNumber.Text = invoice.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            hlnkSalesOrderNumber.Text = invoice.SalesOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (invoice.SalesOrderId > 0)
            {
                hlnkSalesOrderNumber.NavigateUrl = string.Format("sales-order-preview.aspx?id={0}", invoice.SalesOrderId);
                hlnkSalesOrderNumber.Enabled = true;
            }

            hlnkJobOrderNumber.Text = invoice.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (invoice.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("job-order-preview.aspx?id={0}", invoice.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            hlnkCustomerName.Text = invoice.CustomerName;
            if (invoice.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", invoice.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblStatus.Text = invoice.Status.ReplaceWhenNullOrEmpty("N/A");
            lblCustomerPO.Text = invoice.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = invoice.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblLocation.Text = invoice.Location;
            lblInvoiceDate.Text = invoice.InvoiceDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = invoice.CurrencyView.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = invoice.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
            lblExpenses.Text = invoice.Expenses.ToDecimalFormat();
            lblDiscount.Text = invoice.Discount.ToDecimalFormat();
            lblGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();
            int statusId = invoice.StatusId;

            _lstLines = _invoice.GetSalesInvoiceLines(InvoiceId);
            lblTotalCost.Text = (from c in _lstLines where c.ParentId == -1 select (c.TotalCost)).Sum().ToDecimalFormat().ViewCostField();

            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(invoice.SubTotal, invoice.Expenses, invoice.Discount, invoice.IsPercentDiscount, invoice.Tax).ToDecimalFormat();

            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }
        }

        public List<SalesInvoiceLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<SalesInvoiceLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
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

                    if (itemId == -1)
                    {
                        //item.Expanded = true;
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgSalesInvoice_ItemDataBound(object sender, GridItemEventArgs e)
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
                    Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}", InvoiceId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}