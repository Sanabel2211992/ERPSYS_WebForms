using System;
using System.Linq;
using System.Reflection;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.session
{
    public partial class SessionInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                lblSessionId.Text = UserState.SessionId();
                lblDisplayName.Text = RegisteredUser.UserDisplayName;
                lblUsername.Text = RegisteredUser.UserName;
                lblServerIPAddress.Text = UserState.ServerIpAddress();
                lblPublicIPAddress.Text = UserState.PublicIpAddress();
                lblMachineName.Text = UserState.MachineName();
                lblBrowser.Text = UserState.BrowserInformation();
                lblFrameWorkVersion.Text = Assembly.GetExecutingAssembly().GetReferencedAssemblies().First(x => x.Name == "System.Core").Version.ToString();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}