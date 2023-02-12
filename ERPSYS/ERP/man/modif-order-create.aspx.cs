using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Threading;
using ERPSYS.Helpers.Ext;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ModificationOrderCreate : System.Web.UI.Page
    {
        readonly ModificationOrderBLL _order = new ModificationOrderBLL();

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
                GetItemLookupTables();


                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetJobOrder(Request.QueryString["id"].ToInt());
                    BindModificationTypes();
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

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            rblModificationType.DataTextField = "Description";
            rblModificationType.DataValueField = "ModificationTypeId";

            rblModificationType.DataSource = lookup.GetModificationOrderTypes();
            rblModificationType.DataBind();

            rblModificationType.SelectedIndex = 0;

            DataTable dtLocations = lookup.GetModificationLocation();

            ddlModificationLocation.DataTextField = "Name";
            ddlModificationLocation.DataValueField = "LocationId";
            ddlModificationLocation.DataSource = dtLocations;
            ddlModificationLocation.DataBind();
            ddlModificationLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            ddlMaterialLocation.DataTextField = "Name";
            ddlMaterialLocation.DataValueField = "LocationId";
            ddlMaterialLocation.DataSource = dtLocations;
            ddlMaterialLocation.DataBind();
            ddlMaterialLocation.Items.Insert(0, new ListItem("-- Select One --", "-1"));
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

        private void BindModificationTypes()
        {
            pnlType1.Visible = false;
            pnlType2.Visible = false;
            pnlType3.Visible = false;

            switch (rblModificationType.SelectedValue.ToInt())
            {
                case 1:
                    pnlType1.Visible = true;
                    break;
                case 2:
                    pnlType2.Visible = true;
                    break;
                case 3:
                    pnlType3.Visible = true;
                    break;
            }
        }

        protected void rblModificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindModificationTypes();
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

        private void CreateModificationOrder()
        {
            try
            {
                ModificationOrder order = new ModificationOrder();
                ModificationOrderLine line = new ModificationOrderLine();

                order.JobOrderId = JobOrderId;
                order.OrderTypeId = rblModificationType.SelectedValue.ToInt();
                order.InputLocationId = ddlModificationLocation.SelectedValue.ToInt();
                order.OutputLocationId = ddlModificationLocation.SelectedValue.ToInt();
                order.BomLocationId = ddlMaterialLocation.SelectedValue.ToInt();
                order.Remarks = txtRemarks.Text.ToTrimString();

                switch (order.OrderTypeId)
                {
                    case 1:
                        line.InputItemId = UCItemType1.ItemId;
                        line.InputQuantity = UCItemType1.Quantity;
                        line.OutputItemId = UCItemType1.ItemId;
                        line.OutputQuantity = UCItemType1.Quantity;
                        break;
                    case 2:
                        line.InputItemId = UCInputItemAdd.ItemId;
                        line.InputQuantity = UCInputItemAdd.Quantity;
                        line.OutputItemId = UCOutputItemAdd.ItemId;
                        line.OutputQuantity = UCOutputItemAdd.Quantity;
                        break;
                    case 3:
                        line.InputItemId = UCItemType3.ItemId;
                        line.InputQuantity = UCItemType3.Quantity;
                        line.OutputItemId = UCItemType3.ItemId;
                        line.OutputQuantity = UCItemType3.Quantity;
                        break;
                }

                string rMessage;
                int orderId = _order.CreateModificationOrder(order, line, out rMessage);

                if (rMessage != string.Empty || orderId < 1)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("modif-order-form.aspx?id={0}", orderId), false);

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                CreateModificationOrder();
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