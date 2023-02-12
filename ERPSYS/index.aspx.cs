using System;
using System.Web;

namespace ERPSYS
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session != null && HttpContext.Current.Session.Contents["UserSessionData"] != null)
            {
                Response.Redirect("~/ERP/main/home.aspx");
            }
            else
            {
                Response.Redirect("~/ERP/session/login.aspx");
            }
        }
    }
}