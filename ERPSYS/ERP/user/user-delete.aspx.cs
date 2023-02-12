using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.user
{
    public partial class user_delete : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteUser();
        }

        protected void DeleteUser()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int userId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _user.DeleteUser(userId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("user-list.aspx?id={0}&e={1}", userId, rMessageId));
                    }

                    Response.Redirect(string.Format("user-list.aspx?o={0}", 6));
                }
                else
                {
                    Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}