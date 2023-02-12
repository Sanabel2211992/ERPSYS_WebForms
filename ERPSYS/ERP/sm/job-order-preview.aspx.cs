using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderPreview : System.Web.UI.Page
    {
        readonly JobOrderBLL _jobOrder = new JobOrderBLL();
        private List<JobOrderLine> _lstLines = new List<JobOrderLine>();

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
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources(""));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_post_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_close_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("job_order_cancel_success"));
                        break;
                    case "31":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("prod_order_delete_success"));
                        break;
                    case "32":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("prod_order_cancel_success"));
                        break;
                    case "41":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_mod_order_delete_success"));
                        break;
                    case "51":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_assembly_order_delete_success"));
                        break;
                    case "61":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_delete_success"));
                        break;
                    case "62":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("man_modif_order_cancel_success"));
                        break;
                }
                switch (Request.QueryString["e"])
                {
                    case "10":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_inactive"));
                        break;
                    case "11":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_post_inactive"));
                        break;
                    case "12":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_no_records"));
                        break;
                    case "13":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_group_empty"));
                        break;
                    case "15":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_cancel_failed"));
                        break;
                    case "16":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_trans_cancel_failed"));
                        break;
                    case "17":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_close_failed"));
                        break;
                    case "18":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_trans_close_failed"));
                        break;
                    case "33":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("job_order_delete_failed"));
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
                    GetJobOrder(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1), false);
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

        protected void GetJobOrder(int jobOrderId)
        {
            JobOrder order = _jobOrder.GetJobOrderHeader(jobOrderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
            }

            JobOrderId = order.OrderId;
            lblJobOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");

            hlnkCustomerName.Text = order.CustomerName;
            if (order.CustomerId > 0)
            {
                hlnkCustomerName.NavigateUrl = string.Format("../customer/customer-view.aspx?id={0}", order.CustomerId);
                hlnkCustomerName.Enabled = true;
            }

            lblDate.Text = order.OrderDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblPreparedBy.Text = order.UserName;
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblRemarks.Text = order.Remarks.ReplaceWhenNullOrEmpty("N/A");

            switch (order.StatusId)
            {
                case 1: //Draft
                    pnlOrderTransactions.Visible = false;

                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel")); 
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("close"));

                    break;
                case 2: //Open
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete")); 
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post")); 

                    break;
                case 3: //Closed
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("close"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));

                    rtbOrders.Visible = false;

                    break;
                case 4: //Canceled
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("edit"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("delete"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("post"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("cancel"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("close"));
                    rtbOperations.Items.Remove(rtbOperations.FindItemByValue("sep1"));

                    rtbOrders.Visible = false;

                    break;
            }
        }

        protected void GetJobOrderLines()
        {
            _lstLines = _jobOrder.GetJobOrderLines(JobOrderId);
        }

        protected List<JobOrderLine> GetMainLines()
        {
            return _lstLines.Where(s => s.ParentId == -1).ToList();
        }

        protected List<JobOrderLine> GetSubLines(int parentId)
        {
            return _lstLines.Where(s => s.ParentId == parentId).ToList();
        }

        protected void rgJobOrderGroup_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (_lstLines.Count == 0)
            {
                GetJobOrderLines();
            }

            if (!e.IsFromDetailTable)
            {
                rgJobOrderGroup.DataSource = GetMainLines();
            }
        }

        protected void rgJobOrderGroup_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();
            int parentId = dataItem.GetDataKeyValue("LineId").ToInt();

            if (e.DetailTableView.Name == "SubItems" && (itemId == -1))
            {
                e.DetailTableView.DataSource = GetSubLines(parentId);
            }
        }

        protected void rgJobOrderGroup_PreRender(object sender, EventArgs e)
        {
            foreach (object gridDataItem in rgJobOrderGroup.MasterTableView.Items)
            {
                if (gridDataItem is GridDataItem)
                {
                    GridDataItem item = gridDataItem as GridDataItem;
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();

                    if (itemId == -1)
                    {
                    }
                    else
                    {
                        item.Enabled = false;
                        item.Cells[0].Controls[0].Visible = false;
                    }
                }
            }
        }

        protected void rgJobOrderLine_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgJobOrderLine.DataSource = _jobOrder.GetJobOrderCompactLines(JobOrderId);
        }

        protected void rgJobOrderLine_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgProduct = (Image)dataItem.FindControl("imgProduct");
                bool isManufacture = dataItem["IsManufacture"].Text.ToBool();

                if (isManufacture)
                {
                    imgProduct.ImageUrl = "../resources/images/ico_manuf.png";
                    imgProduct.ToolTip = @"Manufacture";
                }
            }
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("job-order-form.aspx?id={0}", JobOrderId), false);
                    break;
                case "delete":
                    Response.Redirect(string.Format("job-order-delete.aspx?id={0}", JobOrderId), false);
                    break;
                case "post":
                    Response.Redirect(string.Format("job-order-post.aspx?id={0}", JobOrderId), false);
                    break;
                case "cancel":
                    Response.Redirect(string.Format("job-order-cancel.aspx?id={0}", JobOrderId), false);
                    break;
                case "close":
                    Response.Redirect(string.Format("job-order-close.aspx?id={0}", JobOrderId), false);
                    break;
                case "compact":
                    pnlGroupView.Visible = false;
                    pnlCompactView.Visible = true;

                    rgJobOrderLine.Rebind();
                    break;
                case "groups":
                    pnlGroupView.Visible = true;
                    pnlCompactView.Visible = false;

                    rgJobOrderGroup.Rebind();
                    break;
                case "print":
                    Response.Redirect(string.Format("job-order-report.aspx?id={0}", JobOrderId), false);
                    break;
                case "issuematerials":
                    Response.Redirect(string.Format("job-order-issue-materials-report.aspx?id={0}", JobOrderId), false);
                    break;
                case "export":

                    break;
            }
        }

        protected void rtbOrders_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "production":
                    Response.Redirect(string.Format("../man/prod-order-create.aspx?id={0}", JobOrderId), false);
                    break;
                case "modification":
                    Response.Redirect(string.Format("../man/modif-order-create.aspx?id={0}", JobOrderId), false);
                    break;
                case "assembly":
                    Response.Redirect(string.Format("../man/assembly-order-create.aspx?id={0}", JobOrderId), false);
                    break;
            }
        }

        protected void rgJobOrderGroupTransactions_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgJobOrderGroupTransactions.DataSource = _jobOrder.GetTransactionsList(JobOrderId);
        }

        protected void rgJobOrderGroupTransactions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;

                //int finishedQty = dataItem["FinishedQty"].Text.ToInt();
                //RadProgressBar rpbPercentCompleted = (RadProgressBar)dataItem.FindControl("rpbPercentCompleted");
                //rpbPercentCompleted.Value = finishedQty * 10;

                ImageButton imgbtnLink = (ImageButton)dataItem.FindControl("imgbtnLink");
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int orderTypeId = dataItem["OrderTypeId"].Text.ToInt();
                int id = dataItem["StatusId"].Text.ToInt();
                imgbtnLink.AlternateText = dataItem["OrderType"].Text;
                imgbtnLink.ToolTip = dataItem["OrderType"].Text;

                switch (orderTypeId)
                {
                    case 1:

                        imgbtnLink.PostBackUrl = string.Format("../man/prod-order-preview.aspx?id={0}", dataItem["OrderId"].Text);

                        switch (id)
                        {
                            case 1: //DRAFT
                                imgStatus.ImageUrl = "../resources/images/ico_o_draft.png";
                                break;
                            case 2: //IN PROGRESS
                                imgStatus.ImageUrl = "../resources/images/ico_o_wip.png";
                                break;
                            case 3: //P CLOSED
                                imgStatus.ImageUrl = "../resources/images/ico_o_wip.png";
                                break;
                            case 4: //CLOSED
                                imgStatus.ImageUrl = "../resources/images/ico_o_close.png";
                                break;
                            case 5: //CANCELD
                                imgStatus.ImageUrl = "../resources/images/ico_o_cancel.png";
                                break;
                        }
                        break;

                    case 2:
                        imgbtnLink.PostBackUrl = string.Format("../man/modif-order-preview.aspx?id={0}", dataItem["OrderId"].Text);

                        switch (id)
                        {case 1: //DRAFT
                                imgStatus.ImageUrl = "../resources/images/ico_o_draft.png";
                                break;
                            case 2: //IN PROGRESS
                                imgStatus.ImageUrl = "../resources/images/ico_o_wip.png";
                                break;
                            case 3: //P CLOSED
                                imgStatus.ImageUrl = "../resources/images/ico_o_wip.png";
                                break;
                            case 4: //CLOSED
                                imgStatus.ImageUrl = "../resources/images/ico_o_close.png";
                                break;
                            case 5: //CANCELD
                                imgStatus.ImageUrl = "../resources/images/ico_o_cancel.png";
                                break;
                        }
                        break;

                    case 3:
                        imgbtnLink.PostBackUrl = string.Format("../man/assembly-order-preview.aspx?id={0}", dataItem["OrderId"].Text);

                        switch (id)
                        {
                            case 1:
                                imgStatus.ImageUrl = "../resources/images/ico_o_draft.png";
                                break;
                            case 2:
                                imgStatus.ImageUrl = "../resources/images/ico_o_close.png";
                                break;
                        }
                        break;
                }
            }
        }

        //************************************** Properties ************************************//

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}