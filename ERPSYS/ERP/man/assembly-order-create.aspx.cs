using System;
using System.Data;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderCreate : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _order = new AssemblyOrderBLL();

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
                    GetJobOrder(Request.QueryString["id"].ToInt());
                    GetItemLookupTables();
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

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            DataTable dtLocations = lookup.GetAssemblyLocation();

            ddlAssemblyLocation.DataTextField = "Name";
            ddlAssemblyLocation.DataValueField = "LocationId";
            ddlAssemblyLocation.DataSource = dtLocations;
            ddlAssemblyLocation.DataBind();
            ddlAssemblyLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlMaterialLocation.DataTextField = "Name";
            ddlMaterialLocation.DataValueField = "LocationId";
            ddlMaterialLocation.DataSource = dtLocations;
            ddlMaterialLocation.DataBind();
            ddlMaterialLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
        }

        protected void GetJobOrder(int jobOrderId)
        {
            JobOrderBLL jobOrder = new JobOrderBLL();

            JobOrder order = jobOrder.GetJobOrderHeader(jobOrderId);

            if (order.OrderId <= 0)
            {
                Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
            }

            if (order.StatusId != 2)
            {
                Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}&e={1}", jobOrderId, 10), false);
            }

            JobOrderId = order.OrderId;
            lblOrderNumber.Text = order.OrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
        }

        protected void rtbOperations_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton toolbarButton = (RadToolBarButton)e.Item;

            switch (toolbarButton.CommandName.ToLower())
            {
                case "back":
                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}", JobOrderId), false);
                    break;
            }
        }

        private void CreateAssemblyOrder()
        {
            if (UCAssembly.ItemId <= 0)
            {
                AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("no_items_selected"));
                return;
            }

            AssemblyOrder order = new AssemblyOrder();

            order.JobOrderId = JobOrderId;
            order.ItemId = UCAssembly.ItemId;
            order.Quantity = UCAssembly.Quantity;
            order.ItemLocationId = ddlAssemblyLocation.SelectedValue.ToInt();
            order.BomLocationId = ddlMaterialLocation.SelectedValue.ToInt();
            order.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var orderId = _order.CreateAssemblyOrderX(order, out rMessage);

            if (rMessage != string.Empty || orderId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("assembly-order-form.aspx?id={0}", orderId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateAssemblyOrder();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
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