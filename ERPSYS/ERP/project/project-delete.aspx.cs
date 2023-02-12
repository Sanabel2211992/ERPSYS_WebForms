using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.project
{
    public partial class project_delete : System.Web.UI.Page
    {
        readonly ProjectBLL _project = new ProjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteProject();
        }

        protected void DeleteProject()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int projectId = Request.QueryString["id"].ToInt();

                    string rMessage;
                    int rMessageId;

                    _project.DeleteProject(projectId, out rMessage, out rMessageId);

                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("page-list.aspx?id={0}&e={1}", projectId, rMessageId));
                    }

                    Response.Redirect(string.Format("project-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("project-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}