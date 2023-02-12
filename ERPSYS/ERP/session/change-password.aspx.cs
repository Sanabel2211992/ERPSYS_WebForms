using System;
using System.Threading;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.session
{
    public partial class change_password : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSystemPreferences();
            }
        }

        protected void GetSystemPreferences()
        {
            try
            {
                SystemSettings preferences = _setting.GetSystemSettings();

                if (preferences.CompanyId <= 0)
                {
                    Response.Redirect(string.Format("company-list.aspx?e={0}", 1));
                }

                int minLength = preferences.MinPasswordLength.ToInt();
                revPassword.ValidationExpression = "^[\\s\\S]{" + minLength + ",}$";

                if (preferences.EnableComplexPassword == true)
                {
                    rtxtPassword.PasswordStrengthSettings.MinimumLowerCaseCharacters = 1;
                    rtxtPassword.PasswordStrengthSettings.MinimumUpperCaseCharacters = 1;
                    rtxtPassword.PasswordStrengthSettings.MinimumSymbolCharacters = 1;
                    rtxtPassword.PasswordStrengthSettings.MinimumNumericCharacters = 1;
                    revPassword.ErrorMessage = "Minimum " + minLength +
                        " characters required and it's have at lest one (Small letter/ Capital Letter/ Symbol/ Number).";
                }
               else
                {
                    revPassword.ErrorMessage = "Minimum " + minLength + " characters required.";
                }
                //preferences.MinPasswordAge.ToInt();
                //preferences.MaxPasswordAge.ToInt();

            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}