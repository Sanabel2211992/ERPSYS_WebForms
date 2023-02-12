using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderPost : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            PostSalesOrder();
        }

        protected void PostSalesOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int orderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _order.PostSalesOrder(orderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-order-preview.aspx?id={0}&e={1}", orderId, rMessageId));
                    }

                    Response.Redirect(string.Format("sales-order-preview.aspx?id={0}&o=2", orderId), false);
                }
                else
                {
                    Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1), false);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}