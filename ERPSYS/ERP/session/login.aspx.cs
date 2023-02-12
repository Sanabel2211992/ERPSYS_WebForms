using System;
using System.Web.Security;
using ERPSYS.BLL;

namespace ERPSYS.ERP.session
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if ((Request.Cookies["FTMERPX"] != null))
                    {
                        string userName = Request.Cookies["FTMERPX"]["username"];
                        txtLoginUsername.Attributes.Add("value", string.Concat(userName));
                        string password = Request.Cookies["FTMERPX"]["password"];
                        txtLoginPassword.Attributes.Add("value", string.Concat(password));
                        cbRememberMe.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //bool isRememberMe = cbRememberMe.Checked;
                //string userLoginName = txtLoginUsername.Text;
                //string userPassword = txtLoginPassword.Text;

                //AuthenticationBLL authentication = new AuthenticationBLL();

                //if (!authentication.AuthenticateUser(userLoginName, userPassword, isRememberMe))
                //{
                //    lblErrorMessage.Text = @"Invalid Username or Password";
                //}
                //else
                //{
                //    Response.Redirect("~/ERP/main/home.aspx", false);
                //}

                bool isRememberMe = cbRememberMe.Checked;
                string userLoginName = txtLoginUsername.Text;
                string userPassword = txtLoginPassword.Text;

                AuthenticationBLL authentication = new AuthenticationBLL();

                bool isAuthenticated = authentication.AuthenticateUser(userLoginName, userPassword, isRememberMe);

                if (!isAuthenticated)
                {
                    lblErrorMessage.Text = @"Invalid Username or Password";
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(userLoginName, isRememberMe);
                }
            }
            catch (Exception ex)
            {
                // write error to log
                //ClsLogging.WriteExceptionError(ex);
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}