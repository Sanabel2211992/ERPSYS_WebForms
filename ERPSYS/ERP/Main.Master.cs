using System;
using System.Web.Security;
using ERPSYS.BLL;

namespace ERPSYS.ERP
{
    public partial class MainMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }

            string pageName = System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            AuthorizationBLL.CheckUserAuthorization(pageName);
            lblPageTitle.Text = ApplicationSettings.GetPageDisplayName(pageName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (lblPageTitle.Text == string.Empty)
            {
                divPageHeader.Attributes["class"] = "";
            }
        }
    }
}