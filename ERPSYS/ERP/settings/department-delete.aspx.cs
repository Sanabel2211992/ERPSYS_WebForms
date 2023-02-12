using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System.IO;

namespace ERPSYS.ERP.settings
{
    public partial class department_delete : System.Web.UI.Page
    {
        readonly SettingsBLL _department = new SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteDepartment();
        }
        protected void DeleteDepartment()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int departmentId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _department.DeleteDepartment(departmentId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("department-list.aspx?id={0}&e={1}", departmentId, rMessageId));
                    }

                    Response.Redirect(string.Format("department-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("department-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}