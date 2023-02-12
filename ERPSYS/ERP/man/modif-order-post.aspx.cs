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
    public partial class ModificationOrderPost : System.Web.UI.Page
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

            if (order.StatusId != 1)
            {
                Response.Redirect(string.Format("modif-order-preview.aspx?id={0}&e={1}", ModificationOrderId, 11), false);
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
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "edit":
                    Response.Redirect(string.Format("modif-order-form.aspx?id={0}", ModificationOrderId), false);
                    break;
                case "post":
                    PostModificationOrder();
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

        protected void PostModificationOrder()
        {
            try
            {
                ModificationOrder order = new ModificationOrder();

                order.ModificationOrderId = ModificationOrderId;
                order.EstimatedDays = txtEstimatedDays.Text.ToInt(0);
                order.Remarks = txtRemarks.Text.ToTrimString();

                string rMessage;
                _order.PostModificationOrder(order, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("modif-order-preview.aspx?id={0}&o={1}", ModificationOrderId, 2), false);
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