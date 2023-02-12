using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;


namespace ERPSYS.ERP.project
{
    public partial class project_form : System.Web.UI.Page
    {
        readonly ProjectBLL _project = new ProjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
          private void AddProject()
        {
            Project project = new Project();

            project.ProjectName = txtProjectName.Text.ToTrimString();
            project.ProjectOwner = txtOwner.Text.ToTrimString();
            

            string rMessage;
            _project.AddProject(project, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
            Response.Redirect(string.Format("project-list.aspx?o={0}", 1));
        }

          protected void btnSave_Click(object sender, EventArgs e)
          {
              try
              {
                  AddProject();
              }
              catch (Exception ex)
              {
                  AppNotification.MessageBoxException(ex);
              }
          }

          protected void btnCancel_Click(object sender, EventArgs e)
          {
              Response.Redirect("project-list.aspx");
          }
    }
   
}
