using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderPost : Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
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

            if (order.StatusId != 1)
            {
                Response.Redirect(string.Format("prod-order-preview.aspx?id={0}&e={1}", ProductionOrderId, 11), false);
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

            lblProductionNote.Text = String.Format("All Raw Materials will Transfer from {0} Store to {1} Store after post this Order.", order.RawMaterialLocation.ReplaceWhenNullOrEmpty("N/A"), order.ProductionLocation.ReplaceWhenNullOrEmpty("N/A"));
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("prod-order-form.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "post":
                    PostProductionOrder();
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

        protected void PostProductionOrder()
        {
            try
            {
                ProductionOrder order = new ProductionOrder();

                order.ProductionOrderId = ProductionOrderId;
                order.EstimatedDays = txtEstimatedDays.Text.ToInt(0);
                order.Remarks = txtRemarks.Text.ToTrimString();

                string rMessage;
                _porder.PostProductionOrder(order, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("prod-order-preview.aspx?id={0}&o={1}", ProductionOrderId, 2), false);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
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