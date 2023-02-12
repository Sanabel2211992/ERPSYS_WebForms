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
    public partial class ProformaInvoicePreview : System.Web.UI.Page
    {
        readonly ProformaInvoiceBLL _invoice = new ProformaInvoiceBLL();
        private List<ProformaInvoiceLine> _lstLines = new List<ProformaInvoiceLine>();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("pro_invoice_update_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("pro_invoice_cancel_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("pro_invoice_delete_failed"));
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
                    GetProformaInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
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

        protected void GetProformaInvoice(int invoiceId)
        {
            ProformaInvoice invoice = _invoice.GetProformaInvoiceHeader(invoiceId);

            if (invoice.InvoiceId <= 0)
            {
                Response.Redirect(string.Format("pro-invoice-list.aspx?e={0}", 1));
            }

            InvoiceId = invoice.InvoiceId;

            hlnkCustomerName.Text = invoice.CustomerName;
            if (invoice.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", invoice.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblStatus.Text = invoice.Status.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = invoice.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblInvoiceDate.Text = invoice.InvoiceDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = invoice.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblInvoiceNumber.Text = invoice.InvoiceNumber;
            lblSubTotal.Text = invoice.SubTotal.ToDecimalFormat();
            lblExpenses.Text = invoice.Expenses.ToDecimalFormat();
            lblDiscount.Text = invoice.Discount.ToDecimalFormat();
            lblGrandTotal.Text = invoice.GrandTotal.ToDecimalFormat();
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(invoice.SubTotal, 0, invoice.Discount, invoice.IsPercentDiscount, invoice.Tax).ToDecimalFormat();
            if (SystemProperties.HasSalesTax || invoice.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            int statusId = invoice.StatusId;

            _lstLines = _invoice.GetProformaInvoiceLines(InvoiceId);

            SettingsBLL setting = new SettingsBLL();
            SystemSettings preferences = setting.GetSystemSettings();

            if (statusId != 1) // Open
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("convertsalesinvoice"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("pro-invoice-form.aspx?id={0}", InvoiceId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("pro-invoice-delete.aspx?id={0}", InvoiceId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("pro-invoice-cancel.aspx?id={0}", InvoiceId), false);
                    break;
                case "convertsalesinvoice":
                    Response.Redirect(string.Format("sales-invoice-pro.aspx?id={0}", InvoiceId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("pro-invoice-report.aspx?id={0}", InvoiceId), false);
                    break;
            }
        }

        public List<ProformaInvoiceLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        public List<ProformaInvoiceLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgProInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                rgProInvoice.DataSource = GetMainLines();
            }
        }

        protected void rgProInvoice_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgProInvoice_ItemDataBound(object sender, GridItemEventArgs e)
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
        protected void rgProInvoice_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgProInvoice.MasterTableView.Items)
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


        //************************************** Properties ************************************//

        public int InvoiceId
        {
            get { return ViewState["InvoiceId"] != null ? ViewState["InvoiceId"].ToInt() : -1; }
            set { ViewState["InvoiceId"] = value; }
        }
    }
}