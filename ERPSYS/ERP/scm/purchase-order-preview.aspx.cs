using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.scm
{
    public partial class PurchaseOrderPreview : System.Web.UI.Page
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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_po_post_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_po_cancel_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_po_delete_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_po_no_records"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_po_invalid_status"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_po_cancel_failed"));
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
                    GetPurchaseOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
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

        protected void GetPurchaseOrder(int purchaseOrderId)
        {
            PurchaseOrder purchaseOrder = _scm.GetPurchaseOrderHeader(purchaseOrderId);

            if (purchaseOrder.PurchaseOrderId <= 0)
            {
                Response.Redirect(string.Format("purchase-order-list.aspx?e={0}", 1));
            }

            PurchaseOrderId = purchaseOrder.PurchaseOrderId;
            lblPurchaseOrderNumber.Text = purchaseOrder.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblPurchaseOrderStatus.Text = purchaseOrder.Status;

            hlnkSupplierName.Text = purchaseOrder.SupplierName;
            if (purchaseOrder.SupplierId > 0)
            {
                hlnkSupplierName.NavigateUrl = string.Format("supplier-view.aspx?id={0}", purchaseOrder.SupplierId);
                hlnkSupplierName.Enabled = true;
            }

            lblCurrency.Text= purchaseOrder.CurrencyCode;
            lblPurchaseOrderDate.Text = purchaseOrder.OrderDate.ToDateString();
            lblPreparedBy.Text = purchaseOrder.PreparedBy;
            lblPostedBy.Text = purchaseOrder.PostedBy.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = purchaseOrder.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblCanceledBy.Text = purchaseOrder.CanceledBy;
            lblCanceledDate.Text = purchaseOrder.CanceledDate.ToDateString();
            lblSubTotal.Text = purchaseOrder.SubTotal.ToDecimalFormat(3);
            lblDiscount.Text = purchaseOrder.Discount.ToDecimalFormat(3);
            lblSalesTaxAmount.Text = Calculation.GetSalesTaxAmount(purchaseOrder.SubTotal, 0, purchaseOrder.Discount, purchaseOrder.IsPercentDiscount, purchaseOrder.Tax).ToDecimalFormat(3);
            lblGrandTotal.Text = purchaseOrder.GrandTotal.ToDecimalFormat(3);

            if (SystemProperties.HasSalesTax || purchaseOrder.Tax > 0)
            {
                pnlSalesTax.Visible = true;
            }

            int statusId = purchaseOrder.StatusId;

            if (statusId == 5)
            {
                pnlCancel.Visible = true;
            }

            if (statusId == 1) // draft
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("print"));
            }
            else
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
            }

            if (statusId != 2)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("purchase-order-form.aspx?id={0}", PurchaseOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("purchase-order-delete.aspx?id={0}", PurchaseOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("purchase-order-post.aspx?id={0}", PurchaseOrderId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("purchase-order-cancel.aspx?id={0}", PurchaseOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("purchase-order-report.aspx?id={0}", PurchaseOrderId), false);
                    break;

            }
        }

        protected void rgPurchaseOrder_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPurchaseOrder.DataSource = _scm.GetPurchaseOrderLines(PurchaseOrderId);
        }

        protected void rgMaterialReceipt_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgMaterialReceipt.DataSource = _scm.GetPurchaseGoodsReceipts(PurchaseOrderId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int PurchaseOrderId
        {
            get { return ViewState["PurchaseOrderId"] != null ? ViewState["PurchaseOrderId"].ToInt() : -1; }
            set { ViewState["PurchaseOrderId"] = value; }
        }
    }
}