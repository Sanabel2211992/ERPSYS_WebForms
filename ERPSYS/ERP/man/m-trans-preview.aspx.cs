using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class MaterialTransferPreview : System.Web.UI.Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();
        readonly MaterialTransferBLL _transfer = new MaterialTransferBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetData();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "21":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("request_rm_inactive"));
                        break;
                    case "22":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("request_rm_no_records"));
                        break;
                    case "23":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("request_rm_insufficient_quantity"));
                        break;
                    case "32":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("request_rm_delete_failed"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetMaterialTransfer(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("../sm/job-order-list.aspx.aspx"));
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

        protected void GetMaterialTransfer(int transferId)
        {
            MaterialTransfer transfer = _transfer.GetMaterialTransferHeader(transferId);

            if (transfer.MaterialTransferId <= 0)
            {
                Response.Redirect(string.Format("../sm/job-order-list.aspx.aspx"));
            }

            TransferId = transfer.MaterialTransferId;
            OrderId = transfer.OrderId;
            OrderTypeId = transfer.OrderTypeId;
            JobOrderId = transfer.JobOrderId;
            lblMaterialTransferNumber.Text = transfer.MaterialTransferNumber.ReplaceWhenNullOrEmpty("N/A");
            lblMaterialTransferStatus.Text = transfer.Status.ReplaceWhenNullOrEmpty("N/A");
            lblPreparedDate.Text = transfer.PreparedDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblPreparedBy.Text = transfer.PreparedBy.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = transfer.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (transfer.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", transfer.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblOrderNumber.Text = transfer.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblOrderType.Text = transfer.OrderType.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = transfer.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblFromLocation.Text = transfer.FromLocation.ReplaceWhenNullOrEmpty("N/A");
            lblToLocation.Text = transfer.ToLocation.ReplaceWhenNullOrEmpty("N/A");
            lblTransactionType.Text = transfer.TransferTypeId == 1 ? @"Request Materials" : @"Return Materials";
            lblRemarks.Text = transfer.Remarks.ReplaceWhenNullOrEmpty("N/A");

            switch (transfer.StatusId)
            {
                case 1:
                    pnlRawMaterialsReview.Visible = true; // for draft only
                    pnlRawMaterials.Visible = false;
                    break;

                case 2:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));

                    break;
            }
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (OrderTypeId == 1)
                {
                    rgProductionItems.DataSource = _porder.GetProductionOrderLines(OrderId);
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgRawMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgRawMaterialsReview.DataSource = _transfer.GetMaterialTransferLinesQuantityCheck(TransferId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgRawMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgRawMaterials.DataSource = _transfer.GetMaterialTransferLines(TransferId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }


        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("m-trans-form.aspx?id={0}", TransferId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("m-trans-delete.aspx?id={0}&tid={1}&oid={2}", TransferId, OrderTypeId, OrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("m-trans-post.aspx?id={0}&tid={1}&oid={2}", TransferId, OrderTypeId, OrderId), false);
                    break;
                case "order":
                    switch (OrderTypeId)
                    {
                        case 1:
                            Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", OrderId), false);
                            break;
                        case 2:
                            Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", OrderId), false);
                            break;
                    }
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("m-trans-report.aspx?id={0}", TransferId), false);
                    break;
            }
        }

        //************************************** Properties ************************************//

        public int TransferId
        {
            get { return ViewState["TransferId"] != null ? ViewState["TransferId"].ToInt() : -1; }
            set { ViewState["TransferId"] = value; }
        }

        public int OrderId
        {
            get { return ViewState["OrderId"] != null ? ViewState["OrderId"].ToInt() : -1; }
            set { ViewState["OrderId"] = value; }
        }

        public int OrderTypeId
        {
            get { return ViewState["OrderTypeId"] != null ? ViewState["OrderTypeId"].ToInt() : -1; }
            set { ViewState["OrderTypeId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}