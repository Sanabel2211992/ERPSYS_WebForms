using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.user
{
    public partial class UserPassReset : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

        private void GetData()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetUserDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetUserDetails(int userId)
        {

            UserAccount userAccount = _user.GetUser(userId);

            if (userAccount.UserId <= 0)
            {
                Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
            }

            UserId = userAccount.UserId;
            lblUsername.Text = userAccount.DisplayName;
            lblDisplayUsername.Text = userAccount.DisplayName;
        }

        protected void ResetUserPassword()
        {
            string rMessage;
            string newPassword = txtNewPassword.Text;

            _user.ResetUserPassword(UserId, newPassword, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("user-list.aspx?o={0}", 5));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                ResetUserPassword();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-list.aspx");
        }

        //************************************** Properties ************************************//

        public int UserId
        {
            get { return ViewState["UserId"] != null ? ViewState["UserId"].ToInt() : -1; }
            set { ViewState["UserId"] = value; }
        }
    }
}