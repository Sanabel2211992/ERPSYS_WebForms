using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Controls.Common;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class SalesInvoicePreview : System.Web.UI.Page
    {
        readonly SalesInvoiceBLL _invoice = new SalesInvoiceBLL();
        private List<SalesInvoiceLine> _lstLines = new List<SalesInvoiceLine>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rts, (UCNotification)Master.FindControl("NotificationBox"));
                raManager.AjaxSettings.AddAjaxSetting(RadMultiPage1, (UCNotification)Master.FindControl("NotificationBox"));
            }

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_invoice_update_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_invoice_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_invoice_refund_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_invoice_add_success"));
                        break;
                    case "5":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sales_order_clone_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_refund_deny"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_delete_failed"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed("You can't refund unposted Invoice");
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed("No Invoice items to refund");
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_post_inactive"));
                        break;
                    case "6":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_no_records"));
                        break;
                    case "7":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_group_empty"));
                        break;
                    case "8":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_insufficient_quantity"));
                        break;
                    case "9":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_refund_no_records"));
                        break;
                    case "10":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_si_has_job_order"));
                        break;
                    case "11":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_si_invalid_seq_number"));
                        break;
                    case "12":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_si_number_exists"));
                        break;
                    case "13":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_retailuser_permission"));
                        break;
                    case "14":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sales_invoice_post_low_cost"));
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
                    GetSalesInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
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

        protected void GetSalesInvoice(int invoiceId)
        {
            SalesInvoice invoice = _invoice.GetSalesInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("sales-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoice.InvoiceId;
            lblInvoiceNumber.Text = invoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");

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

            lblInvoiceDate.Text = invoice.InvoiceDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblCurrencyView.Text = invoice.CurrencyView.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = invoice.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
            lblExpenses.Text = invoice.Expenses.ToDecimalFormat();
            lblDiscount.Text = invoice.Discount.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(invoice.SubTotal, invoice.Expenses, invoice.Discount, invoice.IsPercentDiscount, invoice.Tax).ToDecimalFormat();
            lblGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();

            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            int statusId = invoice.StatusId;

            _lstLines = _invoice.GetSalesInvoiceLines(InvoiceId);

            SettingsBLL setting = new SettingsBLL();
            SystemSettings preferences = setting.GetSystemSettings();

            if (!RegisteredUser.HasCostView)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cost"));
            }

            switch (statusId)
            {
                case 1:
                    cbSetRefrenceManually.Visible = preferences.SetSalesInvoiceReferenceManually;

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("refund"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("print"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("clone"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));

                    rts.Tabs[1].Visible = true; // Stock
                    rts.Tabs[2].Visible = false; // Delivery
                    rts.Width = 250;
                    break;

                case 2:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));

                    rts.Tabs[1].Visible = false; // Stock
                    rts.Tabs[2].Visible = true; // Delivery
                    rts.Width = 250;

                    if (invoice.IsRefund)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("refund"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cost"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));
                        rts.Tabs[1].Visible = false; // Stock
                        rts.Tabs[2].Visible = false; // Delivery
                        rts.Width = 125;
                    }

                    break;
                case 3:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("receipt"));

                    rts.Tabs[1].Visible = false; // Stock
                    rts.Tabs[2].Visible = true; // Delivery
                    rts.Width = 250;

                    if (invoice.IsRefund)
                    {
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("refund"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cost"));
                        rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));
                        rts.Tabs[1].Visible = false; // Stock
                        rts.Tabs[2].Visible = false; // Delivery
                        rts.Width = 125;
                    }
                    break;
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("sales-invoice-form.aspx?id={0}", InvoiceId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("sales-invoice-delete.aspx?id={0}", InvoiceId), false);
                    break;
                case "post":
                    Response.Redirect(
                        cbSetRefrenceManually.Checked
                            ? string.Format("sales-invoice-post-advanced.aspx?id={0}", InvoiceId)
                            : string.Format("sales-invoice-post.aspx?id={0}", InvoiceId), false);
                    break;
                case "receipt":
                    Response.Redirect(string.Format("sales-invoice-stock-report.aspx?id={0}", InvoiceId), false);
                    break;
                case "refund":
                    Response.Redirect(string.Format("sales-invoice-refund-type.aspx?id={0}", InvoiceId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("sales-invoice-report.aspx?id={0}", InvoiceId), false);
                    break;
                case "cost":
                    Response.Redirect(string.Format("sales-invoice-cost.aspx?id={0}", InvoiceId), false);
                    break;
                case "clone":
                    Response.Redirect(string.Format("sales-invoice-clone.aspx?id={0}", InvoiceId), false);
                    break;
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

                if (dataItem["IsLowMinPrice"].Text.ToInt() == 1)
                {
                    dataItem.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvInvoiceLinesStock_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                gvInvoiceLinesStock.DataSource = _invoice.GetSalesInvoiceLinesStoreQuantity(InvoiceId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void gvInvoiceLinesStock_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                decimal x = dataItem["StoreQuantity"].Text.ToDecimal() - dataItem["Quantity"].Text.ToDecimal();
                bool isServiceItem = dataItem["IsServiceItem"].Text.ToBool();
                imgStatus.ImageUrl = (x >= 0) || isServiceItem ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
            }
        }

        protected void rgDelivery_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgDelivery.DataSource = _invoice.GetSalesInvoiceDeliveryReceipts(InvoiceId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
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