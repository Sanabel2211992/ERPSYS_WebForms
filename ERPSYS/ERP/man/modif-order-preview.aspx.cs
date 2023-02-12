using System;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ModificationOrderPreview : System.Web.UI.Page
    {
        readonly ModificationOrderBLL _order = new ModificationOrderBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_close_fully_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_close_partial_success"));
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_post_inactive"));
                        break;
                    case "52":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_delete_failed"));
                        break;
                    case "53":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_update_inactive"));
                        break;
                    case "54":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_no_records"));
                        break;
                    case "55":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_insufficient_quantity"));
                        break;
                    case "41":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_cancel_failed"));
                        break;
                    case "42":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_modif_order_rm_request_cancel_failed"));
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
                    GetModificationOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("modif-order-list.aspx?e={0}", 1), false);
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

        protected void GetModificationOrder(int orderId)
        {
            ModificationOrder order = _order.GetModificationOrderHeader(orderId);

            if (order.ModificationOrderId <= 0)
            {
                Response.Redirect(string.Format("modif-order-list.aspx?e={0}", 1));
            }

            ModificationOrderId = order.ModificationOrderId;
            JobOrderId = order.JobOrderId;

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblModificationOrder.Text = order.ModificationOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblItemsLocation.Text = order.InputLocation.ReplaceWhenNullOrEmpty("N/A");
            lblMaterialsLocation.Text = order.BomLocation.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = order.Remarks.ReplaceLineBreaks().ReplaceWhenNullOrEmpty("N/A");

            switch (order.StatusId)
            {
                case 1:
                    rtbOperations.Items.RemoveAt(4);

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

        protected void rgModificationInputItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgModificationInputItems.DataSource = _order.GetInputModificationOrderLines(ModificationOrderId);
        }

        protected void rgModificationOutputItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgModificationOutputItems.DataSource = _order.GetOutputModificationOrderLines(ModificationOrderId);
        }

        protected void rgBillofMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterials.DataSource = _order.GetModificationOrderBomLines(ModificationOrderId);
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
        
        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("modif-order-form.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("modif-order-delete.aspx?id={0}&jid={1}", ModificationOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("modif-order-post.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "fullclose":
                    Response.Redirect(string.Format("modif-order-close.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("modif-order-cancel.aspx?id={0}&jid={1}", ModificationOrderId, JobOrderId), false);
                    break;
                case "requestrm":
                    Response.Redirect(string.Format("m-trans-create.aspx?id={0}&ot={1}&tt={2}", ModificationOrderId, 1, 1), false);
                    break;
                case "returnrm":
                    Response.Redirect(string.Format("m-trans-create.aspx?id={0}&ot={1}&tt={2}", ModificationOrderId, 1, 2), false);
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("modif-order-report.aspx?id={0}&t={1}", ModificationOrderId, 1), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int ModificationOrderId
        {
            get { return ViewState["ModificationOrderId"] != null ? ViewState["ModificationOrderId"].ToInt() : -1; }
            set { ViewState["ModificationOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}