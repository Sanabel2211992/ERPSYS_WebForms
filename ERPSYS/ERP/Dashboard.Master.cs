using System;
using System.Web.Security;

namespace ERPSYS.ERP
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }
        }
    }
}