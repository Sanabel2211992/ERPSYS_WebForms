using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ModificationOrderClose : System.Web.UI.Page
    {
        readonly ModificationOrderBLL _order = new ModificationOrderBLL();

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

            if (order.StatusId != 2)
            {
                Response.Redirect(string.Format("modif-order-preview.aspx?id={0}", orderId), false);
            }

            ModificationOrderId = order.ModificationOrderId;
            JobOrderId = order.JobOrderId;
            lblModificationOrder.Text = order.ModificationOrderNumber.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");
            lblUserDisplayName.Text = order.UserName.ReplaceWhenNullOrEmpty("N/A");
            UCCloseDate.DateValue = DateTime.Now;
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "close":
                    CloseModificationOrder();
                    break;
                case "order":
                    Response.Redirect(string.Format("modif-order-preview.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "joborder":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
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


        protected void rgBillofMaterialsReview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgBillofMaterialsReview.DataSource = _order.GetModificationOrderBomLinesQuantityCheck(ModificationOrderId);
        }

        protected void CloseModificationOrder()
        {
            try
            {
                ModificationOrder order = new ModificationOrder();

                order.ModificationOrderId = ModificationOrderId;
                order.EndDate = UCCloseDate.DateValue;
                order.CloseRemarks = txtRemarks.Text.ToTrimString();

                string rMessage;
                _order.CloseFullyModificationOrder(order, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("modif-order-preview.aspx?id={0}&o={1}", ModificationOrderId, 3), false);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //************************************** Properties ************************************//

        private int ModificationOrderId
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