using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.crm
{
    public partial class ClientDelete : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //DeleteClient();
        }

        protected void DeleteClient()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int clientId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _client.DeleteClient(clientId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("client-list.aspx?id={0}&e={1}", clientId, rMessageId));
                    }

                    Response.Redirect(string.Format("client-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("client-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}