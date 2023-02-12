using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class SalesOrderDelete : System.Web.UI.Page
    {
        readonly SalesOrderBLL _order = new SalesOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteSalesOrder();
        }

        protected void DeleteSalesOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int orderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId; 

                    _order.DeleteSalesOrder(orderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-order-preview.aspx?id={0}&e={1}", orderId, rMessageId));
                    }

                    Response.Redirect(string.Format("sales-order-list.aspx?o=3"), false);
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