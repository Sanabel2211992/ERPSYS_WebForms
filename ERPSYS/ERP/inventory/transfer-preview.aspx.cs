using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.inventory
{
    public partial class TransferPreview : System.Web.UI.Page
    {
        readonly InventoryBLL _inventory = new InventoryBLL();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("inv_transfer_post_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_delete_failed"));
                        break;
                    case "2":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_item_invalid"));
                        break;
                    case "3":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_status_invalid"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_insufficient_quantity"));
                        break;
                    case "5":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("inv_transfer_empty"));
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
                    GetStockTransfer(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
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

        protected void GetStockTransfer(int transferId)
        {
            StockTransfer transfer = _inventory.GetStockTransferHeader(transferId);

            if (transfer.TransferId <= 0)
            {
                Response.Redirect(string.Format("transfer-list.aspx?e={0}", 1));
            }

            TransferId = transferId;
            lblTransferNumber.Text = transfer.TransferNumber.ReplaceWhenNullOrEmpty("N/A");
            lblTransferDescription.Text = transfer.TransferDescription.ReplaceWhenNullOrEmpty("N/A");
            lblPreparedBy.Text = transfer.UserName;
            lblDate.Text = transfer.TransferDate.ToShortDateString();
            lblJobOrderNumber.Text = transfer.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = transfer.Status;
            lblFromLocation.Text = transfer.FromLocation;
            lblToLocation.Text = transfer.ToLocation;
            lblPostBy.Text = transfer.PostedUserName.ReplaceWhenNullOrEmpty("N/A");
            lblPostDate.Text = transfer.PostedDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblRemarks.Text = transfer.Remarks.ReplaceWhenNullOrEmpty("N/A");

            int statusId = transfer.StatusId;

            switch (statusId)
            {
                case 1:
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("print"));
                    rts.Tabs[1].Visible = true;
                    rts.Width = 250;
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
                    Response.Redirect(string.Format("transfer-form.aspx?id={0}", TransferId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("transfer-delete.aspx?id={0}", TransferId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("transfer-post.aspx?id={0}", TransferId), false);
                    break;
                case "print":
                    Response.Redirect(string.Format("transfer-report.aspx?id={0}", TransferId), false);
                    break;
            }
        }

        protected void rgStockTransfer_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgStockTransfer.DataSource = _inventory.GetStockTransferLines(TransferId);
        }

        protected void rgStockTransferStatus_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgStockTransferStatus.DataSource = _inventory.GetStockTransferLinesStatus(TransferId);
        }

        protected void rgStockTransferStatus_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                decimal x = dataItem["FromLocationQuantity"].Text.ToDecimal() - dataItem["Quantity"].Text.ToDecimal();
                imgStatus.ImageUrl = (x >= 0) ? "../resources/images/ico_allow_16.png" : "../resources/images/ico_deny_16.png";
            }
        }

        //************************************** Properties ************************************//

        public int TransferId
        {
            get { return ViewState["TransferId"] != null ? ViewState["TransferId"].ToInt() : -1; }
            set { ViewState["TransferId"] = value; }
        }
    }
}