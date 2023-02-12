using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderPost : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _order = new AssemblyOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostAssemblyOrder();
        }

        protected void PostAssemblyOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int orderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _order.PostAssemblyOrderX(orderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("assembly-order-preview.aspx?id={0}&e={1}", orderId, rMessageId));
                    }

                    Response.Redirect(string.Format("assembly-order-preview.aspx?id={0}&o={1}", orderId, 2));
                }
                else
                {
                    Response.Redirect(string.Format("assembly-order-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }
        }
    }
}