using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.sm
{
    public partial class JobOrderPost : System.Web.UI.Page
    {
        readonly JobOrderBLL _order = new JobOrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            PostJobOrder();
        }

        protected void PostJobOrder()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int jobOrderId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _order.PostJobOrder(jobOrderId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("job-order-preview.aspx?id={0}&e={1}", jobOrderId, rMessageId));
                    }

                    Response.Redirect(string.Format("job-order-preview.aspx?id={0}&o={1}", jobOrderId, 2));
                }
                else
                {
                    Response.Redirect(string.Format("job-order-list.aspx?e={0}", 1));
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