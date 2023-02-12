using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System.IO;

namespace ERPSYS.ERP.settings
{
    public partial class role_delete : System.Web.UI.Page
    {
        readonly SettingsBLL _role = new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteRole();
        }
        protected void DeleteRole()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int brandId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _role.DeleteRole(brandId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("role-list.aspx?id={0}&e={1}", brandId, rMessageId));
                    }

                    Response.Redirect(string.Format("role-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("role-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}