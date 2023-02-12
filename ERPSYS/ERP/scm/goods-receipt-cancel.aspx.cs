using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Threading;
using Telerik.Web.UI;

namespace ERPSYS.ERP.scm
{
    public partial class GoodsReceiptCancel : System.Web.UI.Page
    {
        readonly SupplierChainBLL _scm = new SupplierChainBLL();

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

            if (goodsReceipt.PurchaseOrderId > 0)
            {
                hlnkPurchaseOrderNumber.NavigateUrl = string.Format("purchase-order-preview.aspx?id={0}",
                    goodsReceipt.PurchaseOrderId);
                hlnkPurchaseOrderNumber.Enabled = true;
            }
            else
            {
                cbUpdatePurchaseOrderStatus.Checked = false;
                cbUpdatePurchaseOrderStatus.Enabled = false;
            }
        }

        protected void rgGoodsReceipt_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgGoodsReceipt.DataSource = _scm.GetGoodsReceiptNoteLines(GoodsReceiptId);
        }

        protected void CancelGoodsReceipt()
        {
            try
            {
                int goodsReceiptId = GoodsReceiptId;
                bool updatePurchaseOrderStatus = cbUpdatePurchaseOrderStatus.Checked;
                string cancelRemarks = txtCancelRemarks.Text;

                string rMessage;
                int rMessageId;

                _scm.CancelGoodsReceiptNote(goodsReceiptId, updatePurchaseOrderStatus, cancelRemarks, out rMessage, out rMessageId);

                if (rMessage != string.Empty)
                {
                    Response.Redirect(string.Format("goods-receipt-preview.aspx?id={0}&e={1}", goodsReceiptId, rMessageId));
                }

                Response.Redirect(string.Format("goods-receipt-preview.aspx?id={0}&o=2", goodsReceiptId));

            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CancelGoodsReceipt();
        }

        //************************************** Properties ************************************//

        private int GoodsReceiptId
        {
            get { return ViewState["GoodsReceiptId"] != null ? ViewState["GoodsReceiptId"].ToInt() : -1; }
            set { ViewState["GoodsReceiptId"] = value; }
        }
    }
}