using System;
using System.Data;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderCreate : System.Web.UI.Page
    {
        readonly JobOrderBLL _jorder = new JobOrderBLL();
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

            rgManufactureItem.DataSource = _jorder.GetManufactureItemsList(JobOrderId);
            rgManufactureItem.DataBind();

            rgProductionItem.DataSource = new DataTable();
            rgProductionItem.DataBind();


            pnlItemSelection.Visible = rgManufactureItem.Items.Count > 0; // hide panel if no Manufacture Item found
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

        protected void rgManufactureItem_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "select")
            {
                GridDataItem dataItem = (GridDataItem)(e.Item);
                int itemId = dataItem.GetDataKeyValue("ItemId").ToInt();

                GetManufactureItemDetails(itemId);
            }
        }

        protected void GetManufactureItemDetails(int itemId)
        {
            try
            {
                rgProductionItem.DataSource = _jorder.GetManufactureItem(JobOrderId, itemId);
                rgProductionItem.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void CreateProductionOrder()
        {
            try
            {
                ProductionOrder order = new ProductionOrder();
                ProductionOrderLine line = new ProductionOrderLine();

                order.JobOrderId = JobOrderId;


                if (rgProductionItem.MasterTableView.Items.Count == 0)
                {
                    AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("prod_order_invalid_item"));
                    return;
                }

                foreach (GridDataItem item in rgProductionItem.MasterTableView.Items)
                {
                    int itemId = item.GetDataKeyValue("ItemId").ToInt();
                    decimal quantity = ((RadNumericTextBox)item.FindControl("txtQuantity")).Value.ToDecimal();

                    if (quantity <= 0)
                    {
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("prod_order_invalid_quantity"));
                        return;
                    }

                    line.ItemId = itemId;
                    line.Quantity = quantity;
                    break;
                }

                string rMessage;
                var orderId = _porder.CreateProductionOrder(order, line, out rMessage);

                if (rMessage != string.Empty || orderId <= 0)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("prod-order-form.aspx?id={0}", orderId), false);
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

                CreateProductionOrder();
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