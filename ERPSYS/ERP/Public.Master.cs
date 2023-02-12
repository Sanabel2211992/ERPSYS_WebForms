using System;
using System.Threading;
using System.Web.Security;
using ERPSYS.BLL;

namespace ERPSYS.ERP
{
    public partial class PublicMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }

            try
            {
                if (UserSession.SessionId == null)
                {
                    AuthorizationBLL.KickOut();
                }
            }
            catch (ThreadAbortException)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}