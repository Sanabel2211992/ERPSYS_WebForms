using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoiceRefund : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        private List<SalesInvoiceLine> _lstLines = new List<SalesInvoiceLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rgRefundSalesInvoice, (UCNotification)Master.FindControl("NotificationBox"));
                raManager.AjaxSettings.AddAjaxSetting(btnApplyChanges, (UCNotification)Master.FindControl("NotificationBox"));
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
                GetItemLookupTables();

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    SalesInvoiceRefundTypes typeId = SalesInvoiceRefundTypes.Individual;

                    if (Request.QueryString["o"] != null && Request.QueryString["o"] != string.Empty && Request.QueryString["o"].ToInt() == 1)
                    {
                        typeId = SalesInvoiceRefundTypes.Whole;
                    }

                    GetSalesInvoice(Request.QueryString["id"].ToInt(), typeId);
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1), false);
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

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetSalesLocation();
            ddlLocation.DataBind();
        }

        protected void GetSalesInvoice(int invoiceId, SalesInvoiceRefundTypes typeId)
        {
            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(String.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            if (invoice.IsRefund)
            {
                Response.Redirect(String.Format("sales-invoice-preview.aspx?id={0}&e={1}", invoiceId, 1));
            }

            if (invoice.IsRefundBefore)
            {
                typeId = SalesInvoiceRefundTypes.Individual;
            }

            InvoiceId = invoiceId;
            RefundTypeId = typeId;
            lblInvoiceNumber.Text = invoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            UCDatePicker.DateValue = DateTime.Today;

            hlnkCustomerName.Text = invoice.CustomerName;
            if (invoice.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", invoice.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            ddlLocation.SelectedValue = invoice.LocationId.ToString();
            lblProjectName.Text = invoice.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            txtRemarks.Text = invoice.Remarks;
            Tax = invoice.Tax;
           
            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
                lblSalesTaxValue.Text = invoice.Tax.ToDecimalFormat();
            }

            if (typeId == SalesInvoiceRefundTypes.Whole)
            {
                pnlWhole.Visible = true;
                pnlIndividual.Visible = false;
                _lstLines = _invoice.GetSalesInvoiceLines(InvoiceId);
                rgRefundWholeSalesInvoice.Rebind();

                txtSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
                txtDiscount.Text = invoice.Discount.ToDecimalFormat();
                txtExpenses.Text = invoice.Expenses.ToDecimalFormat();
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                txtGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();

                txtDiscount.Enabled = false;
                txtExpenses.Enabled = false;
                btnApplyChanges.Visible = false;
            }

            else if (typeId == SalesInvoiceRefundTypes.Individual)
            {
                pnlWhole.Visible = false;
                pnlIndividual.Visible = true;

                if (invoice.Discount > 0)
                {
                    lblIndividualDiscount.Text = invoice.Discount.ToDecimalFormat();
                    pnlIndividualDiscount.Visible = true;
                }

                if (invoice.Expenses > 0)
                {
                    lblIndividualExpenses.Text = invoice.Expenses.ToDecimalFormat();
                    pnlIndividualExpenses.Visible = true;
                }

                rgRefundSalesInvoice.Rebind();
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

        protected void rgRefundWholeSalesInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgRefundWholeSalesInvoice.DataSource = GetMainLines();
            }
        }

        protected void rgRefundWholeSalesInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgRefundWholeSalesInvoice_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgRefundWholeSalesInvoice.MasterTableView.Items)
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

        protected void rgRefundSalesInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                List<SalesInvoiceLine> lines = _invoice.GetSalesInvoiceRefundLines(InvoiceId);

                if (lines.Count == 0)
                {
                    Response.Redirect(String.Format("sales-invoice-preview.aspx?id={0}&e={1}", InvoiceId, 9));
                }

                rgRefundSalesInvoice.DataSource = lines;
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            CheckBox cbSelected = (CheckBox)sender;
            GridItem item = (GridItem)((CheckBox)sender).NamingContainer;

            item.Selected = cbSelected.Checked;
            RadNumericTextBox txtNetPrice = ((RadNumericTextBox)(item.FindControl("txtNetPrice")));
            RadNumericTextBox txtRefundQuantity = ((RadNumericTextBox)(item.FindControl("txtRefundQuantity")));
            CheckBox cbHidePrice = ((CheckBox)(item.FindControl("cbHidePrice")));
            Label lblTotal = ((Label)(item.FindControl("lblTotal")));

            cbHidePrice.Enabled = !cbSelected.Checked;
            txtNetPrice.Enabled = !cbSelected.Checked;
            txtRefundQuantity.Enabled = !cbSelected.Checked;

            lblTotal.Text = cbSelected.Checked ? Calculation.GetLineTotal(txtNetPrice.Value.ToDecimal(), txtRefundQuantity.Value.ToDecimal()).ToDecimalFormat() : "0";

            UpdateSubTotal();
        }

        protected void UpdateSubTotal()
        {
            try
            {
                foreach (GridDataItem item in rgRefundSalesInvoice.MasterTableView.Items)
                {
                    CheckBox cbItem = ((CheckBox)item.FindControl("cbItem"));

                    if (cbItem.Checked)
                    {
                        Label lblTotal = ((Label)(item.FindControl("lblTotal")));
                        SubTotal += lblTotal.Text.ToDecimal();
                    }
                }

                UpdateTotalSummary();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void UpdateTotalSummary()
        {
            try
            {
                txtSubTotal.Text = SubTotal.ToDecimalFormat();
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();

                //txtSubTotal.Text = SubTotal.ToDecimalFormat();
                //txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(),  txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false).ToDecimalFormat();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {
            try
            {
                txtSalesTax.Text = Calculation.GetSalesTaxAmount(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(), txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false, Tax).ToDecimalFormat();
                //txtGrandTotal.Text = Calculation.GetGrandTotal(txtSubTotal.Text.ToDecimal(),  txtExpenses.Text.ToDecimal(), txtDiscount.Text.ToDecimal(), false).ToDecimalFormat();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private DataTable RefundInvoiceLinesTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("NetPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
            dt.Columns.Add(new DataColumn("HidePrice", typeof(bool)));

            return dt;
        }

        private DataTable GetRefundInvoiceLinesTable()
        {
            DataTable dt = RefundInvoiceLinesTable("tblLines");

            foreach (GridDataItem item in rgRefundSalesInvoice.MasterTableView.Items)
            {
                CheckBox cbItem = ((CheckBox)item.FindControl("cbItem"));

                if (cbItem.Checked)
                {
                    decimal netPrice = ((RadNumericTextBox)(item.FindControl("txtNetPrice"))).Value.ToDecimal();
                    decimal quantity = ((RadNumericTextBox)item.FindControl("txtRefundQuantity")).Value.ToDecimal();
                    CheckBox cbHidePrice = ((CheckBox)(item.FindControl("cbHidePrice")));

                    if (quantity > 0 && quantity <= item["RemainingQuantity"].Text.ToDecimal()) //  check if the quantity is valid 
                    {
                        var dr = dt.NewRow();

                        dr["ItemId"] = item["ItemId"].Text.ToInt();
                        dr["NetPrice"] = netPrice;
                        dr["Quantity"] = quantity;
                        dr["HidePrice"] = cbHidePrice.Checked;

                        dt.Rows.Add(dr);
                    }
                }
            }

            return dt;
        }

        private void CreateRefundWholeInvoice()
        {
            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceId = InvoiceId;
            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();

            string rMessage;
            int refundInvoiceId = _invoice.CreateRefundWholeSalesInvoice(invoice, out rMessage);

            if (rMessage != string.Empty || refundInvoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", refundInvoiceId, 3), false);
        }

        private void CreateRefundInvoice()
        {
            DataTable dtLines = GetRefundInvoiceLinesTable();

            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                AppNotification.MessageBoxWarning("No Item Selected");
                return;
            }

            SalesInvoice invoice = new SalesInvoice();

            invoice.InvoiceDate = UCDatePicker.DateValue;
            invoice.Remarks = txtRemarks.Text.ToTrimString();
            invoice.Discount = txtDiscount.Value.ToDecimal();
            invoice.IsPercentDiscount = false;
            invoice.Expenses = txtExpenses.Value.ToDecimal();
            invoice.LocationId = ddlLocation.SelectedValue.ToInt();

            string rMessage;
            int refundInvoiceId = _invoice.CreateRefundSalesInvoice(InvoiceId, invoice, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || refundInvoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("sales-invoice-preview.aspx?id={0}&o={1}", refundInvoiceId, 3), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (RefundTypeId == SalesInvoiceRefundTypes.Whole)
                {
                    CreateRefundWholeInvoice();
                }

                else if (RefundTypeId == SalesInvoiceRefundTypes.Individual)
                {
                    CreateRefundInvoice();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }

        private SalesInvoiceRefundTypes RefundTypeId
        {
            get { return ViewState["RefundTypeId"] != null ? (SalesInvoiceRefundTypes)ViewState["RefundTypeId"] : SalesInvoiceRefundTypes.Individual; }
            set { ViewState["RefundTypeId"] = value; }
        }

        private decimal SubTotal { get; set; }

        private decimal Tax
        {
            get { return ViewState["Tax"] != null ? ViewState["Tax"].ToDecimal() : 0; }
            set { ViewState["Tax"] = value; }
        }
    }
}