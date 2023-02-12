using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderPreview : System.Web.UI.Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();

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
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("prod_order_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("prod_order_close_fully_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("prod_order_close_partial_success"));
                        break;
                    case "21":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("request_rm_post_success"));
                        break;
                    case "31":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("request_rm_delete_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "11":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("prod_order_post_inactive"));
                        break;
                    case "41":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("prod_order_cancel_failed"));
                        break;
                    case "42":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("prod_order_rm_request_cancel_failed"));
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
                    GetProductionOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1), false);
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

        protected void GetProductionOrder(int orderId)
        {
            ProductionOrder order = _porder.GetProductionOrderHeader(orderId);

            if (order.ProductionOrderId <= 0)
            {
                Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1));
            }

            ProductionOrderId = order.ProductionOrderId;
            JobOrderId = order.JobOrderId;
            lblProductionOrder.Text = order.ProductionOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            lblEstimatedTime.Text = order.EstimatedDays <= 0 ? @"Not Specified " : string.Format("{0} Days", order.EstimatedDays);
            lblStartDate.Text = order.StartDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblEndDate.Text = order.EndDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = order.Remarks.ReplaceWhenNullOrEmpty("N/A");

            switch (order.StatusId)
            {
                case 1:
                    rtbOperations.Items.RemoveAt(4);

                    pnlRawMaterialReview.Visible = true; // for draft only
                    pnlRawMaterialsRequest.Visible = false;
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("finish"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("requestrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("returnrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                    break;

                case 2:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    break;

                case 3:

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("finish"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    break;

                case 4:
                    rtbOperations.Items.RemoveAt(4);

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("finish"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("requestrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("returnrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));
                    break;
                case 5:
                    rtbOperations.Items.RemoveAt(4);

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("finish"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("requestrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("returnrm"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep2"));
                    break;
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("prod-order-form.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("prod-order-delete.aspx?id={0}&jid={1}", ProductionOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("prod-order-post.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "fullclose":
                    Response.Redirect(string.Format("prod-order-close.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "partclose":
                    Response.Redirect(string.Format("prod-order-close-partial.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("prod-order-cancel.aspx?id={0}&jid={1}", ProductionOrderId, JobOrderId), false);
                    break;
                case "requestrm":
                    Response.Redirect(string.Format("m-trans-create.aspx?id={0}&ot={1}&tt={2}", ProductionOrderId, 1, 1), false);
                    break;
                case "returnrm":
                    Response.Redirect(string.Format("m-trans-create.aspx?id={0}&ot={1}&tt={2}", ProductionOrderId, 1, 2), false);
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("prod-order-report.aspx?id={0}&t={1}", ProductionOrderId, 1), false);
                    break;
            }
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgProductionItems.DataSource = _porder.GetProductionOrderLines(ProductionOrderId);
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _porder.GetProductionOrderBomLinesQuantityCheck(ProductionOrderId);
        }

        protected void rgBillofMaterialsReview_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");

                decimal delta = dataItem["AvailableQuantity"].Text.ToDecimal() - dataItem["RequiredQuantity"].Text.ToDecimal();
                imgStatus.ImageUrl = (delta >= 0) ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
            }
        }

        protected void rgRawMaterialsRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgRawMaterialsRequest.DataSource = _porder.GetOrderRawMaterialRequestList(ProductionOrderId);
        }

        protected void rgRawMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgRawMaterials.DataSource = _porder.GetOrderRawMaterialRequestLines(ProductionOrderId);
        }

        protected void rgRawMaterialsRequest_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int id = dataItem["StatusId"].Text.ToInt();

                switch (id)
                {
                    case 1:
                        imgStatus.ImageUrl = "../resources/images/ico_o_draft.png";
                       break;
                    case 2:
                       imgStatus.ImageUrl = "../resources/images/ico_o_close.png";
                       break;
                }
            }
        }

        //************************************** Properties ************************************//

        public int ProductionOrderId
        {
            get { return ViewState["ProductionOrderId"] != null ? ViewState["ProductionOrderId"].ToInt() : -1; }
            set { ViewState["ProductionOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}