using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class ProductionOrderDelete : System.Web.UI.Page
    {
        readonly ProductionOrderBLL _porder = new ProductionOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteProductionOrder();
        }

        protected void DeleteProductionOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["jid"] != null && Request.QueryString["jid"] != string.Empty)
                {
                    int orderId = Request.QueryString["id"].ToInt();
                    int jobOrderId = Request.QueryString["jid"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _porder.DeleteProductionOrder(orderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("prod-order-preview.aspx?id={0}&e={1}", orderId, rMessageId));
                    }

                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}&o={1}", jobOrderId, 31));
                }
                else
                {
                    Response.Redirect(string.Format("prod-order-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}