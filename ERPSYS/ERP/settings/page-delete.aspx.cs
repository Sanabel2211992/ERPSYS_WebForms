using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.settings
{
    public partial class PageDelete : System.Web.UI.Page
    {
        readonly SettingsBLL _settings= new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeletePage();
        }

        protected void DeletePage()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int pageId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _settings.DeletePage(pageId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("page-list.aspx?id={0}&e={1}", pageId, rMessageId));
                    }

                    Response.Redirect(string.Format("page-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("page-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}