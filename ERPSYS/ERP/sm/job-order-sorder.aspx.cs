using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderSalesOrder : System.Web.UI.Page
    {
        readonly JobOrderBLL _order = new JobOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateJobOrder();
        }

        protected void CreateJobOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int salesOrderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    int jobOrderId = _order.CreateJobOrderFromSalesOrder(salesOrderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("sales-order-preview.aspx?id={0}&e={1}", salesOrderId, rMessageId));
                    }

                    Response.Redirect(string.Format("job-order-preview.aspx?id={0}&o={1}", jobOrderId, 2));
                }
                else
                {
                    Response.Redirect(string.Format("sales-order-list.aspx?e={0}", 1));
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
    }
}