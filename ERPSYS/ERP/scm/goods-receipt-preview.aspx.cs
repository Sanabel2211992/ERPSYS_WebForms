using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptPreview : System.Web.UI.Page
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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_grn_post_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("scm_grn_cancel_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_invalid_status"));
                        break;                                
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_no_records"));
                        break;                                  
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_po_inactive"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_delete_failed"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_cancel_failed"));
                        break;
                    case "6":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("scm_grn_cancel_insufficient_quantity"));
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
                    GetMaterialReceipt(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
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

        protected void GetMaterialReceipt(int goodsReceiptId)
        {
            GoodsReceipt goodsReceipt = _scm.GetGoodsReceiptNoteHeader(goodsReceiptId);

            if (goodsReceipt.GoodsReceiptId <= 0)
            {
                Response.Redirect(string.Format("goods-receipt-list.aspx?e={0}", 1));
            }

            GoodsReceiptId = goodsReceipt.GoodsReceiptId;
            lblMaterialReceiptNumber.Text = goodsReceipt.ReceiptNumber.ReplaceWhenNullOrEmpty("N/A");
            hlnkPurchaseOrderNumber.Text = goodsReceipt.PurchaseOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblMaterialReceiptStatus.Text = goodsReceipt.Status;

            hlnkSupplierName.Text = goodsReceipt.SupplierName;
            if (goodsReceipt.SupplierId > 0)
            {
                hlnkSupplierName.NavigateUrl = string.Format("supplier-view.aspx?id={0}", goodsReceipt.SupplierId);
                hlnkSupplierName.Enabled = true;
            }

            //lblInvoiceNumber.Text = goodsReceipt.SupplierInvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            lblLocation.Text = goodsReceipt.Location;
            lblMaterialReceiptDate.Text = goodsReceipt.ReceiptDate.ToDateString();
            lblPreparedBy.Text = goodsReceipt.PreparedBy;
            lblPostedBy.Text = goodsReceipt.PostedBy.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = goodsReceipt.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblCancelRemarks.Text = goodsReceipt.CancelRemarks.ReplaceWhenNullOrEmpty("N/A");
            lblCanceledBy.Text = goodsReceipt.CanceledBy;
            lblCanceledDate.Text = goodsReceipt.CanceledDate.ToDateString();

            if (goodsReceipt.PurchaseOrderId > 0)
            {
                hlnkPurchaseOrderNumber.NavigateUrl = string.Format("purchase-order-preview.aspx?id={0}", goodsReceipt.PurchaseOrderId);
                hlnkPurchaseOrderNumber.Enabled = true;
            }

            int statusId = goodsReceipt.StatusId;

            if (statusId == 4)
            {
                pnlCancelRemarks.Visible = true;
            }

            if (statusId != 2)
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
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
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("goods-receipt-form.aspx?id={0}", GoodsReceiptId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("goods-receipt-delete.aspx?id={0}", GoodsReceiptId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("goods-receipt-post.aspx?id={0}", GoodsReceiptId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("goods-receipt-cancel.aspx?id={0}", GoodsReceiptId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("goods-receipt-report.aspx?id={0}", GoodsReceiptId), false);
                    break;
            }
        }

        protected void rgGoodsReceipt_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgGoodsReceipt.DataSource = _scm.GetGoodsReceiptNoteLines(GoodsReceiptId);
        }

        //************************************** Properties ************************************//

        private int GoodsReceiptId
        {
            get { return ViewState["GoodsReceiptId"] != null ? ViewState["GoodsReceiptId"].ToInt() : -1; }
            set { ViewState["GoodsReceiptId"] = value; }
        }
    }
}