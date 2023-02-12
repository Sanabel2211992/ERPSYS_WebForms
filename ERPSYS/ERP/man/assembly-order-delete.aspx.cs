using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.man
{
    public partial class AssemblyOrderDelete : System.Web.UI.Page
    {
        readonly AssemblyOrderBLL _assembly = new AssemblyOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteAssemblyOrder();
        }

        protected void DeleteAssemblyOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["jid"] != null && Request.QueryString["jid"] != string.Empty)
                {
                    int orderId = Request.QueryString["id"].ToInt();
                    int jobOrderId = Request.QueryString["jid"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _assembly.DeleteAssemblyOrderX(orderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("assembly-order-preview.aspx?id={0}&e={1}", orderId, rMessageId));
                    }

                    Response.Redirect(string.Format("../sm/job-order-preview.aspx?id={0}&o={1}", jobOrderId, 51));
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