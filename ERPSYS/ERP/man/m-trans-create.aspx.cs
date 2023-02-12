using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.man
{
    public partial class MaterialTransferCreate : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["ot"] != null && Request.QueryString["ot"] != string.Empty && Request.QueryString["tt"] != null && Request.QueryString["tt"] != string.Empty)
                {
                    GetOrderInformation(Request.QueryString["id"].ToInt(), Request.QueryString["ot"].ToInt(), Request.QueryString["tt"].ToInt());
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

        protected void GetOrderInformation(int orderId, int orderTypeId, int transferTypeId)
        {
            OrderTypeId = orderTypeId;
            TransferTypeId = transferTypeId;

            if (transferTypeId != 1 && transferTypeId != 2)
            {
                Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1));
            }

            if (OrderTypeId == 1)
            {
                GetProductionOrderInformation(orderId);
            }
        }

        protected void GetProductionOrderInformation(int orderId)
        {
            ProductionOrder order = _porder.GetProductionOrderHeader(orderId);

            if (order.ProductionOrderId <= 0)
            {
                Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1));
            }

            OrderId = order.ProductionOrderId;
            JobOrderId = order.JobOrderId;
            lblOrderNumber.Text = order.ProductionOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            lblOrderType.Text = order.OrderType.ReplaceWhenNullOrEmpty("N/A");

            hlnkJobOrderNumber.Text = order.JobOrderNumber.ReplaceWhenNullOrEmpty("N/A");
            if (order.JobOrderId > 0)
            {
                hlnkJobOrderNumber.NavigateUrl = string.Format("../sm/job-order-preview.aspx?id={0}", order.JobOrderId);
                hlnkJobOrderNumber.Enabled = true;
            }

            lblProjectName.Text = order.ProjectName.ReplaceWhenNullOrEmpty("N/A");
            lblOrderStatus.Text = order.Status.ReplaceWhenNullOrEmpty("N/A");

            switch (TransferTypeId)
            {
                case 1:
                    lblTransferType.Text = @"Request Raw Materials";
                    break;
                case 2:
                    lblTransferType.Text = @"Return Raw Materials";
                    break;
            }
        }

        protected void rgProductionItems_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (OrderTypeId == 1)
            {
                rgProductionItems.DataSource = _porder.GetProductionOrderLines(OrderId);
            }
        }

        private void CreateProductionOrderRawMaterialTransfer()
        {
            MaterialTransfer transfer = new MaterialTransfer();

            transfer.OrderId = OrderId;
            transfer.OrderTypeId = OrderTypeId;
            transfer.TransferTypeId = TransferTypeId;
            transfer.Remarks = txtRemarks.Text.ToTrimString();

            string rMessage;
            var requestId = _porder.CreateRawMaterialTransfer(transfer, out rMessage);

            if (rMessage != string.Empty || requestId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("m-trans-form.aspx?id={0}", requestId), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (OrderTypeId == 1)
                {
                    CreateProductionOrderRawMaterialTransfer();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (OrderTypeId == 1)
            {
                Response.Redirect(string.Format("prod-order-preview.aspx?id={0}", OrderId), false);
            }
        }

        //************************************** Properties ************************************//

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

        public int TransferTypeId
        {
            get { return ViewState["TransferTypeId"] != null ? ViewState["TransferTypeId"].ToInt() : -1; }
            set { ViewState["TransferTypeId"] = value; }
        }

        public int JobOrderId
        {
            get { return ViewState["JobOrderId"] != null ? ViewState["JobOrderId"].ToInt() : -1; }
            set { ViewState["JobOrderId"] = value; }
        }
    }
}