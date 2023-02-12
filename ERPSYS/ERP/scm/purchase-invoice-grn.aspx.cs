using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoiceGRN : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOpenGoodsReceiptNotes();
            }
        }

        protected void GetOpenGoodsReceiptNotes()
        {
            try
            {
                ddlGoodsReceiptList.DataTextField = "ReceiptNumber";
                ddlGoodsReceiptList.DataValueField = "GoodsReceiptId";
                ddlGoodsReceiptList.DataSource = _scm.GetGoodsReceiptNoteOpen();
                ddlGoodsReceiptList.DataBind();

                ddlGoodsReceiptList.Items.Insert(0, new ListItem("-- Select One --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnMaterialReceipt_Click(object sender, EventArgs e)
        {
            int goodsReceiptId = ddlGoodsReceiptList.SelectedValue.ToInt();

            if (goodsReceiptId > 0)
            {
                pnlPurchaseInvoice.Visible = true;
                InitializeComponent(goodsReceiptId);
            }
        }

        private void InitializeComponent(int goodsReceiptId)
        {
            try
            {
                UCDate.DateValue = DateTime.Today;
                GetItemLookupTables();
                GetGoodsReceiptNote(goodsReceiptId);
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

            ddlCurrency.DataTextField = "Description";
            ddlCurrency.DataValueField = "CurrencyId";
            ddlCurrency.DataSource = lookup.GetCurrency();
            ddlCurrency.DataBind();

            ddlCurrency.SelectedValue = UserSession.CurrencyId.ToString();

            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "Locationid";
            ddlLocation.DataSource = lookup.GetPurchaseInvoiceLocation();
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetGoodsReceiptNote(int goodsReceiptId)
        {
            GoodsReceipt goodsReceipt = _scm.GetGoodsReceiptNoteHeader(goodsReceiptId);

            if (goodsReceipt.GoodsReceiptId <= 0)
            {
                Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
            }

            GoodsReceiptId = goodsReceipt.GoodsReceiptId;
            lblPurchaseOrderNumber.Text = goodsReceipt.PurchaseOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblGoodsReceiptNumber.Text = goodsReceipt.ReceiptNumber;
            lblSupplierName.Text = goodsReceipt.SupplierName;

            txtFreightExpenses.Text = @"0";
            txtClearanceExpenses.Text = @"0";
            txtOtherExpenses.Text = @"0";
            txtOtherExpensesLocalCurrency.Text = @"0";

            lblFreightExpensesCurrency.Text = UserSession.CurrencyCode;
            lblClearanceExpensesCurrency.Text = UserSession.CurrencyCode;
            lblOtherExpenses.Text = UserSession.CurrencyCode;
            lblOtherExpensesLocalCurrency.Text = UserSession.CurrencyCode;

            if (goodsReceipt.PurchaseOrderId > 0)
            {
                PurchaseOrder purchaseOrder = _scm.GetPurchaseOrderHeader(goodsReceipt.PurchaseOrderId);

                lblPurchaseOrderNumber.Text = purchaseOrder.OrderNumber;
                ddlCurrency.SelectedValue = purchaseOrder.CurrencyId.ToString();

                lblFreightExpensesCurrency.Text = purchaseOrder.CurrencyCode;
                lblOtherExpenses.Text = purchaseOrder.CurrencyCode;
            }

            rgPurchaseInvoice.DataSource = _scm.GetGoodsReceiptLinesToPurchaseInvoice(goodsReceiptId);
            rgPurchaseInvoice.DataBind();
        }

        protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int currencyId = ddlCurrency.SelectedValue.ToInt();
                if (currencyId > 0)
                {
                    CurrencyBLL currencyBll = new CurrencyBLL();
                    Currency currency = currencyBll.GetCurrency(currencyId);

                    lblFreightExpensesCurrency.Text = currency.Code;
                    lblOtherExpenses.Text = currency.Code;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPurchaseInvoice_ItemDataBound(object sender, GridItemEventArgs e)
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
                    ((RadNumericTextBox)dataItem.FindControl("txtNetPrice")).Text = @"0";
                    ((RadNumericTextBox)dataItem.FindControl("txtNetPrice")).Enabled = false;
                }
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            ((GridItem)((CheckBox)sender).NamingContainer).Selected = ((CheckBox)sender).Checked;
            ((RadNumericTextBox)((GridItem)((CheckBox)sender).NamingContainer).FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;
            ((RadNumericTextBox)((GridItem)((CheckBox)sender).NamingContainer).FindControl("txtNetPrice")).Enabled = !((CheckBox)sender).Checked;

            bool checkHeader = rgPurchaseInvoice.MasterTableView.Items.Cast<GridDataItem>().All(dataItem => ((CheckBox)dataItem.FindControl("cbItem")).Checked);
            GridHeaderItem headerItem = rgPurchaseInvoice.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
            if (headerItem != null) ((CheckBox)headerItem.FindControl("cbAllItems")).Checked = checkHeader;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in rgPurchaseInvoice.MasterTableView.Items.Cast<GridDataItem>().Where(dataItem => headerCheckBox != null).Where(dataItem => headerCheckBox != null && dataItem.Cells[17].Text.ToInt() != 3))
            {
                if (headerCheckBox != null)
                {
                    ((CheckBox)dataItem.FindControl("cbItem")).Checked = headerCheckBox.Checked;
                    ((RadNumericTextBox)dataItem.FindControl("txtQuantity")).Enabled = !((CheckBox)sender).Checked;
                    ((RadNumericTextBox)dataItem.FindControl("txtNetPrice")).Enabled = !((CheckBox)sender).Checked;
                    dataItem.Selected = headerCheckBox.Checked;
                }
            }
        }

        private DataTable PurchaseInvoiceTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);

            dt.Columns.Add(new DataColumn("ItemId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(decimal)));
            dt.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Discount", typeof(decimal)));
            dt.Columns.Add(new DataColumn("IsPercentDiscount", typeof(bool)));
            dt.Columns.Add(new DataColumn("NetPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("TotalPrice", typeof(decimal)));
            dt.Columns.Add(new DataColumn("UomId", typeof(int)));

            return dt;
        }

        private DataTable GetPurchaseInvoiceTable()
        {
            DataTable dt = PurchaseInvoiceTable("tblLines");

            foreach (GridDataItem item in rgPurchaseInvoice.Items)
            {
                if (((CheckBox)item.FindControl("cbItem")).Checked)
                {
                    decimal netPrice = ((RadNumericTextBox)item.FindControl("txtNetPrice")).Text.ToDecimal(3);
                    decimal quantity = ((RadNumericTextBox)item.FindControl("txtQuantity")).Text.ToDecimal(3);

                    if ((netPrice <= 0))
                    {
                        throw new Exception("Invalid item price");
                    }
                    if ((quantity <= 0))
                    {
                        throw new Exception("Invalid item quantity");
                    }

                    var dr = dt.NewRow();
                    dr["ItemId"] = item.Cells[5].Text.ToInt();
                    dr["Quantity"] = quantity;
                    dr["UnitPrice"] = netPrice;
                    dr["Discount"] = 0;
                    dr["IsPercentDiscount"] = 1;
                    dr["NetPrice"] = netPrice;
                    dr["TotalPrice"] = Calculation.GetLineTotal(netPrice, quantity);
                    dr["UomId"] = item.Cells[16].Text.ToInt();

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        protected void CreatePurchaseInvoice()
        {
            DataTable dtLines = GetPurchaseInvoiceTable();
            DataSet dsLines = new DataSet();
            dsLines.Tables.Add(HelperFunctions.MappingDataTable(dtLines));

            if (dtLines.Rows.Count == 0)
            {
                //AppNotification.MessageBoxWarning("No items selected");
                AppNotification.MessagePanelWarning("Please select a valid Product", "Warning");
                return;
            }

            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();

            purchaseInvoice.InvoiceDate = UCDate.DateValue;
            purchaseInvoice.GoodsReceiptId = GoodsReceiptId;
            purchaseInvoice.SupplierInvoiceNumber = txtSupplierInvoice.Text.ToTrimString();
            purchaseInvoice.LocationId = ddlLocation.SelectedValue.ToInt();
            purchaseInvoice.CurrencyId = ddlCurrency.SelectedValue.ToInt();
            purchaseInvoice.Remarks = txtRemarks.Text.ToTrimString();

            purchaseInvoice.FreightExpenses = txtFreightExpenses.Text.ToDecimal(3);
            purchaseInvoice.ClearanceExpenses = txtClearanceExpenses.Text.ToDecimal(3);
            purchaseInvoice.OtherExpenses = txtOtherExpenses.Text.ToDecimal(3);
            purchaseInvoice.OtherExpensesLocalCurrency = txtOtherExpenses.Text.ToDecimal(3);

            string rMessage;
            var invoiceId = _scm.CreatePurchaseInvoiceFromGoodsReceiptNote(purchaseInvoice, dsLines.GetXml(), out rMessage);

            if (rMessage != string.Empty || invoiceId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

           Response.Redirect(string.Format("purchase-invoice-preview.aspx?id={0}", invoiceId));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreatePurchaseInvoice();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("purchase-invoice-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private int GoodsReceiptId
        {
            get { return ViewState["GoodsReceiptId"] != null ? ViewState["GoodsReceiptId"].ToInt() : -1; }
            set { ViewState["GoodsReceiptId"] = value; }
        }
    }
}