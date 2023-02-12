using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderClone : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            CloneSalesOrder();
        }

        protected void CloneSalesOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int salesOrderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    var newSalesOrderId = _order.CloneSalesOrder(salesOrderId, out rMessage);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-order-list.aspx?e=2"));
                    }

                    Response.Redirect(string.Format("sales-order-preview.aspx?id={0}&o={1}", newSalesOrderId, 5));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}