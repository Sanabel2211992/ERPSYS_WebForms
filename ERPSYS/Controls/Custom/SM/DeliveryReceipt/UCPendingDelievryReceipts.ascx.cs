using System;
using System.Data;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.Custom.SM.DeliveryReceipt
{
    public partial class UCPendingDelievryReceipts : System.Web.UI.UserControl
    {
        //readonly DeliveryReceiptBLL _delivery = new DeliveryReceiptBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetCustomerList();
            }
        }

        //protected void GetCustomerList()
        //{

        //    DataTable dt = _delivery.GetCustomersListNotBilledDeliveryReceipt();

        //    if (dt.Rows.Count == 0)
        //    {
        //        rcbCustomer.Items.Clear();
        //        rcbCustomer.Items.Add(new RadComboBoxItem("No customer found", "-1"));

        //        pnlSalesOrder.Visible = false;
        //        pnlDeliveryReceipt.Visible = false;

        //        return;
        //    }

        //    rcbCustomer.DataSource = dt;
        //    rcbCustomer.DataBind();
        //}

        //protected void GetSalesOrderList(int customerId)
        //{
        //    DataTable dt = _delivery.GetSalesOrderNotBilledDeliveryReceipt(customerId);

        //    if (dt.Rows.Count == 0)
        //    {
        //        AppNotification.MessageBoxWarning("No available Orders");
        //        pnlSalesOrder.Visible = false;
        //        return;
        //    }
        //    else if (dt.Rows.Count > 1)
        //    {
        //        ddlSalesOrder.Items.Insert(0, new ListItem("-- Select Order --", "-1"));
        //    }

        //    ddlSalesOrder.DataTextField = "OrderNumber";
        //    ddlSalesOrder.DataValueField = "OrderId";

        //    ddlSalesOrder.DataSource = dt;
        //    ddlSalesOrder.DataBind();

        //    pnlSalesOrder.Visible = true;
        //}

        //protected void GetDeliveryReceiptList(int customerId, int orderId)
        //{
        //    DataTable dt = _delivery.GetNotBilledDeliveryReceiptBySalesOrder(customerId, orderId);

        //    if (dt.Rows.Count == 0)
        //    {
        //        AppNotification.MessageBoxWarning("No available Delivery Receipts");
        //        pnlDeliveryReceipt.Visible = false;
        //        return;
        //    }

        //    cblDeliveryReceipts.DataValueField = "ReceiptId";
        //    cblDeliveryReceipts.DataTextField = "ReceiptNumber";

        //    cblDeliveryReceipts.DataSource = dt;
        //    cblDeliveryReceipts.DataBind();

        //    pnlDeliveryReceipt.Visible = true;
        //}

        //protected void rcbCustomer_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    int customerId = rcbCustomer.SelectedValue.ToInt();

        //    if (customerId > 0)
        //    {
        //        ddlSalesOrder.Items.Clear();
        //        GetSalesOrderList(customerId);
        //    }
        //}

        //protected void ddlSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int customerId = rcbCustomer.SelectedValue.ToInt();
        //    int orderId = ddlSalesOrder.SelectedValue.ToInt();

        //    if (customerId > 0 && orderId > 0)
        //    {
        //        cblDeliveryReceipts.Items.Clear();
        //        GetDeliveryReceiptList(customerId, orderId);
        //    }
        //}

        ////************************************** Properties ************************************//

        //public string ValidationGroup
        //{
        //    set
        //    {
        //        rfvCustomer.ValidationGroup = value;
        //    }
        //}

        //public int CustomerId
        //{
        //    get { return rcbCustomer.SelectedValue.ToInt(); }
        //    set { rcbCustomer.SelectedValue = value.ToString(); }
        //}
    }
}