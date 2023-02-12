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
    public partial class AssemblyOrderPreview : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _assembly = new AssemblyOrderBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_assembly_order_post_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "11":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_assembly_order_post_inactive"));
                        break;
                    case "52":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_assembly_order_delete_failed"));
                        break;
                    case "53":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_assembly_update_inactive"));
                        break;
                    case "54":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_assembly_order_no_records"));
                        break;
                    case "55":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("man_assembly_order_insufficient_quantity"));
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
                    GetAssemblyOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1), false);
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

        protected void GetAssemblyOrder(int orderId)
        {
            AssemblyOrder order = _assembly.GetAssemblyOrderHeaderX(orderId);

            if (order.AssemblyOrderId <= 0)
            {
                Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1));
            }

            AssemblyOrderId = order.AssemblyOrderId;
            JobOrderId = order.JobOrderId;
            lblAssemblyOrder.Text = order.AssemblyOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblItemsLocation.Text = order.ItemLocation.ReplaceWhenNullOrEmpty("N/A");
            lblMaterialsLocation.Text = order.BomLocation.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = order.Remarks.ReplaceWhenNullOrEmpty("N/A");

            switch (order.StatusId)
            {
                case 1:
                    pnlBillofMaterialsReview.Visible = true; // for draft only
                    pnlBillofMaterials.Visible = false;
                    break;

                case 2:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));
                    break;
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("assembly-order-form.aspx?id={0}", AssemblyOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("assembly-order-delete.aspx?id={0}&jid={1}", AssemblyOrderId, JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("assembly-order-post.aspx?id={0}", AssemblyOrderId), false);
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("assembly-order-report.aspx?id={0}&t={1}", AssemblyOrderId, 1), false);
                    break;
            }
        }

        protected void rgAssemblyItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgAssemblyItems.DataSource = _assembly.GetAssemblyOrderLineX(AssemblyOrderId);
        }

        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _assembly.GetAssemblyOrderBomLinesQuantityCheckX(AssemblyOrderId);
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

        protected void rgBillofMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterials.DataSource = _assembly.GetAssemblyOrderBomLinesX(AssemblyOrderId);
        }

        protected void rgBillofMaterialsRequest_ItemDataBound(object sender, GridItemEventArgs e)
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

        public int AssemblyOrderId
        {
            get { return ViewState["AssemblyOrderId"] != null ? ViewState["AssemblyOrderId"].ToInt() : -1; }
            set { ViewState["AssemblyOrderId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}