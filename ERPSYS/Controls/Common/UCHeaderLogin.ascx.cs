using System;
using ERPSYS.Helpers;

namespace ERPSYS.Controls.Common
{
    public partial class UCHeaderLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = AppSettings.SystemTitle;
                lblVersion.Text = AppSettings.SystemVersion;
            }
        }
    }
}