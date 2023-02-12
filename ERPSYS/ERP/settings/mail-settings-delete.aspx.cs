using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.settings
{
    public partial class MailSettingsDelete : System.Web.UI.Page
    {
        readonly MailBLL _mail = new MailBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteMailSettings();
        }

        protected void DeleteMailSettings()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int emailId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _mail.DeleteMailSettings(emailId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("mail-settings-list.aspx?id={0}&e={1}", emailId, rMessageId));
                    }

                    Response.Redirect(string.Format("mail-settings-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("mail-settings-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}