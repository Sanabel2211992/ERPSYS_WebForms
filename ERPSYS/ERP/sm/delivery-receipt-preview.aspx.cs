using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Controls.Common;

namespace ERPSYS.ERP.sm
{
    public partial class DeliveryReceiptPreview : System.Web.UI.Page
    {
        readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master != null)
            {
                raManager.AjaxSettings.AddAjaxSetting(rtsDelivery, (UCNotification)Master.FindControl("NotificationBox"));
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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sm_dr_update_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("sm_dr_post_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_post_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_post_failed"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_delete_failed"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_insufficient_quantity"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("sm_dr_no_records"));
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
                    GetDeliveryReceipt(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
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

        protected void GetDeliveryReceipt(int receiptId)
        {
            DeliveryReceipt deliveryRcpt = _delivery.GetDeliveryReceiptHeader(receiptId);

            if (deliveryRcpt.ReceiptId <= 0)
            {
                Response.Redirect(string.Format("delivery-receipt-list.aspx?e={0}", 1));
            }

            ReceiptId = receiptId;
            lblReceiptNumber.Text = deliveryRcpt.ReceiptNumber.ReplaceWhenNullOrEmpty("N/A");
            lblReceiptStatus.Text = deliveryRcpt.Status.ReplaceWhenNullOrEmpty("N/A");
            lblCustomerPO.Text = deliveryRcpt.PurchaseOrder.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = deliveryRcpt.CustomerName;
            if (deliveryRcpt.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", deliveryRcpt.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblLocation.Text = deliveryRcpt.Location;
            lblReceiptDate.Text = deliveryRcpt.ReceiptDate.ReplaceDateWhenNullOrEmpty("N/A");

            hlnkSalesOrderNumber.Text = deliveryRcpt.SalesOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (deliveryRcpt.SalesOrderId > 0)
            {
                hlnkSalesOrderNumber.NavigateUrl = string.Format("sales-order-preview.aspx?id={0}", deliveryRcpt.SalesOrderId);
                hlnkSalesOrderNumber.Enabled = true;
            }

            hlnkSalesInvoiceNumber.Text = deliveryRcpt.SalesInvoiceNumber.ReplaceWhenNullOrEmpty("N/A");
            if (deliveryRcpt.SalesInvoiceId > 0)
            {
                hlnkSalesInvoiceNumber.NavigateUrl = string.Format("sales-invoice-preview.aspx?id={0}", deliveryRcpt.SalesInvoiceId);
                hlnkSalesInvoiceNumber.Enabled = true;
            }

            lblRemarks.Text = deliveryRcpt.Remarks.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = deliveryRcpt.ProjectName.ReplaceWhenNullOrEmpty("N/A");

            if (deliveryRcpt.StatusId == 1) // draft
            {
                rtbOperations.Items.Remove(rtbOperations.FindItemByValue("print"));

                rtsDelivery.Tabs[1].Visible = true;
                rtsDelivery.Width = 250;
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
                    Response.Redirect(string.Format("delivery-receipt-adjust.aspx?id={0}", ReceiptId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("delivery-receipt-delete.aspx?id={0}", ReceiptId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("delivery-receipt-post.aspx?id={0}", ReceiptId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("delivery-receipt-report.aspx?id={0}", ReceiptId), false);
                    break;
            }
        }

        protected void gvDeliveryReceiptLines_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gvDeliveryReceiptLines.DataSource = _delivery.GetDeliveryReceiptCompactLines(ReceiptId);
        }

        protected void gvDeliveryReceiptLinesStock_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                gvDeliveryReceiptLinesStock.DataSource = _delivery.GetDeliveryReceiptLinesStoreQuantity(ReceiptId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void gvDeliveryReceiptLines_ItemDataBound(object sender, GridItemEventArgs e)
        {
            var item = e.Item as GridDataItem;
            if (item != null)
            {
                GridDataItem dataItem = item;
                Image imgService = (Image)dataItem.FindControl("imgService");
                if (dataItem["IsServiceItem"].Text.ToBool() == true)
                {
                    imgService.ImageUrl = "../resources/images/ico_star_16_16.png";
                    imgService.ToolTip = @"Service";
                }
            }
        }

        protected void gvDeliveryReceiptLinesStock_ItemDataBound(object sender, GridItemEventArgs e)
        {
            var item = e.Item as GridDataItem;
            if (item != null)
            {
                GridDataItem dataItem = item;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                decimal x = dataItem["StoreQuantity"].Text.ToDecimal() - dataItem["Quantity"].Text.ToDecimal();
                bool isServiceItem = dataItem["IsServiceItem"].Text.ToBool();
                imgStatus.ImageUrl = (x >= 0) || isServiceItem ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";   
            }
        }

        //************************************** Properties ************************************//

        public int ReceiptId
        {
            get { return ViewState["ReceiptId"] != null ? ViewState["ReceiptId"].ToInt() : -1; }
            set { ViewState["ReceiptId"] = value; }
        }
    }
}