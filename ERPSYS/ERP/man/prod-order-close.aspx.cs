using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderClose : System.Web.UI.Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();

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

            if (order.StatusId != 2)
            {
                Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", orderId), false);
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
            lblEstimatedTime.Text = order.EstimatedDays <= 0 ? @"Not Specified " : string.Format("{0} Days.", order.EstimatedDays);
            lblStartDate.Text = order.StartDate.ReplaceDateWhenNullOrEmpty("N/A");
            lblEndDate.Text = order.EndDate.ReplaceDateWhenNullOrEmpty("N/A");
            UCCloseDate.DateValue = DateTime.Now;
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgProductionItems.DataSource = _porder.GetProductionOrderLines(ProductionOrderId);
        }

        protected void rgRawMaterials_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgRawMaterials.DataSource = _porder.GetOrderRawMaterialRequestLines(ProductionOrderId);
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "close":
                    CloseProductionOrder();
                    break;
                case "order":
                    Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", ProductionOrderId), false);
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
            }
        }

        protected void CloseProductionOrder()
        {
            try
            {
                ProductionOrder order = new ProductionOrder();

                order.ProductionOrderId = ProductionOrderId;
                order.EndDate = UCCloseDate.DateValue;
                order.CloseRemarks = txtRemarks.Text.ToTrimString();

                string rMessage;
                _porder.CloseFullyProductionOrder(order, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("prod-order-preview.aspx?id={0}&o={1}", ProductionOrderId, 3), false);
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