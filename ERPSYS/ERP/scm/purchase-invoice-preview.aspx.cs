using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseInvoicePreview : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

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
                        AppNotification.MessageBoxSuccess("Purchase Invoice has been posted succesfully.");
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_pi_post_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_pi_no_records"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_pi_grn_inactive"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_pi_grn_qty_invalid"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_pi_delete_failed"));
                        break;
                    case "-1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("error_not_defined"));
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
                    GetPurchaseInvoice(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
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

        protected void GetPurchaseInvoice(int purchaseInvoiceId)
        {
            PurchaseInvoice purchaseInvoice = _scm.GetPurchaseInvoiceHeader(purchaseInvoiceId);

            if (purchaseInvoice.PurchaseInvoiceId <= 0)
            {
                Response.Redirect(string.Format("purchase-invoice-list.aspx?e={0}", 1));
            }

            PurchaseInvoiceId = purchaseInvoice.PurchaseInvoiceId;
            lblInvoiceNumber.Text = purchaseInvoice.InvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = purchaseInvoice.Status;

            hlnkSupplierName.Text = purchaseInvoice.SupplierName;
            if (purchaseInvoice.SupplierId > 0)
            {
                hlnkSupplierName.NavigateUrl = string.Format("supplier-view.aspx?id={0}", purchaseInvoice.SupplierId);
                hlnkSupplierName.Enabled = true;
            }

            hlnkPurchaseOrderNumber.Text = purchaseInvoice.PurchaseOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (purchaseInvoice.PurchaseOrderId > 0)
            {
                hlnkPurchaseOrderNumber.NavigateUrl = string.Format("purchase-order-preview.aspx?id={0}", purchaseInvoice.PurchaseOrderId);
                hlnkPurchaseOrderNumber.Enabled = true;
            }

            hlnkGoodsReceiptNumber.Text = purchaseInvoice.GoodsReceiptNumber.ReplaceWhenNullOrEmpty("N/A");
            if (purchaseInvoice.GoodsReceiptId > 0)
            {
                hlnkGoodsReceiptNumber.NavigateUrl = string.Format("goods-receipt-preview.aspx?id={0}", purchaseInvoice.GoodsReceiptId);
                hlnkGoodsReceiptNumber.Enabled = true;
            }

            lblSupplierInvoiceNumber.Text = purchaseInvoice.SupplierInvoiceNumber.ReplaceWhenNullOrEmpty("N/A"); 
            lblCurrency.Text = purchaseInvoice.CurrencyCode;
            lblLocation.Text = purchaseInvoice.Location;
            lblInvoiceDate.Text = purchaseInvoice.InvoiceDate.ToDateString();
            lblPreparedBy.Text = purchaseInvoice.PreparedBy;
            lblPostedBy.Text = purchaseInvoice.PostedBy.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = purchaseInvoice.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblCurrencyExchange.Text = String.Format("{0}/{1}", purchaseInvoice.CurrencyCode, purchaseInvoice.LocalCurrencyCode);
            lblExchangeRate.Text = purchaseInvoice.ExchangeRate.ToDecimalFormat(4);
            lblGrandTotal.Text = purchaseInvoice.GrandTotal.ToDecimalFormat(3);
            lblFreightExpenses.Text = purchaseInvoice.FreightExpenses.ToDecimalFormat(3);
            lblClearanceExpenses.Text = purchaseInvoice.ClearanceExpenses.ToDecimalFormat(3);
            lblOtherExpensesCurrency.Text = purchaseInvoice.OtherExpenses.ToDecimalFormat(3);
            lblOtherExpensesLocalCurrency.Text = purchaseInvoice.OtherExpensesLocalCurrency.ToDecimalFormat(3);

            lblGrandTotalCurrencyCode.Text = purchaseInvoice.CurrencyCode;
            lblFreightExpensesCurrencyCode.Text = purchaseInvoice.CurrencyCode;
            lblClearanceExpensesCurrencyCode.Text = purchaseInvoice.LocalCurrencyCode;
            lblOtherExpensesCurrencyCode.Text = purchaseInvoice.CurrencyCode;
            lblOtherExpensesLocalCurrencyCode.Text = purchaseInvoice.LocalCurrencyCode;

            rgPurchaseInvoice.Columns[10].HeaderText = String.Format("Price({0})", purchaseInvoice.CurrencyCode);
            rgPurchaseInvoice.Columns[12].HeaderText = String.Format("Cost({0})", purchaseInvoice.LocalCurrencyCode);

            int statusId = purchaseInvoice.StatusId;

            switch (statusId)
            {
                case 1:
                    //if (purchaseInvoice.GoodsReceiptId > 0)
                    //{
                    //    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    //}
                    break;
                case 2:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    break;
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("purchase-invoice-form.aspx?id={0}", PurchaseInvoiceId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("purchase-invoice-delete.aspx?id={0}", PurchaseInvoiceId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("purchase-invoice-post.aspx?id={0}", PurchaseInvoiceId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("purchase-invoice-report.aspx?id={0}", PurchaseInvoiceId), false);
                    break;
            }
        }
        protected void rgPurchaseInvoice_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPurchaseInvoice.DataSource = _scm.GetPurchaseInvoiceLines(PurchaseInvoiceId);
        }

        //************************************** Properties ************************************//

        private int PurchaseInvoiceId
        {
            get { return ViewState["PurchaseInvoiceId"] != null ? ViewState["PurchaseInvoiceId"].ToInt() : -1; }
            set { ViewState["PurchaseInvoiceId"] = value; }
        }
    }
}