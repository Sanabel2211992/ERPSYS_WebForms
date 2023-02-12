using System;
using ERPSYS.BLL;

namespace ERPSYS.ERP.session
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorizationBLL.LogOut();
        }
    }
}