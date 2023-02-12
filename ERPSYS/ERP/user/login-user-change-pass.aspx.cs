using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.user
{
    public partial class LoginUserChangePass : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateUserPassword()
        {
            string rMessage;
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;

             _user.UpdateUserPassword(currentPassword, newPassword, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            AppNotification.MessageBoxSuccess(Notifications.GetMessage("user_change_password_success"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                UpdateUserPassword();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);    
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../main/home.aspx"));
        }
    }
}