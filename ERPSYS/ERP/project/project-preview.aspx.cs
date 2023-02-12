using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ERPSYS.ERP.project
{
    public partial class project_preview : System.Web.UI.Page
    {
        readonly ProjectBLL _project = new ProjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetProjectDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("project-list.aspx?e={0}", 1));
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

         protected void GetProjectDetails(int projectId)
        {
            Project project = _project.GetProject(projectId);

            if (project.ProjectId <= 0)
            {
                Response.Redirect("project-list.aspx?e=1", false);
            }

            ProjectId = project.ProjectId;

            lbProjectName.Text = project.ProjectName;
            lbOwner.Text = project.ProjectOwner;

            //UCAddFile.ProjectId = projectId;
            //UCAddNote.ProjectId = projectId;
             
        }

        protected void rgFilesAttList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgFilesAttList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GeFilesProjectList(ProjectId);
        }

        private void GeFilesProjectList(int projectId)
        {
            try
            {
                rgFilesAttList.DataSource = _project.GeFilesProjectList(projectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgNotesList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgNotesList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GeNotesProjectList(ProjectId);
        }

        private void GeNotesProjectList(int projectId)
        {
            try
            {
                rgNotesList.DataSource = _project.GetNotesProjectList(projectId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("project-list.aspx"), false);
        }

        protected void DownloadFileDisk(object sender, EventArgs e)
        {
            try
            {
                var lnkbtnDownloadDisk = sender as LinkButton;
                if (lnkbtnDownloadDisk != null)
                {
                     FileId = lnkbtnDownloadDisk.CommandArgument.ToInt();
                    ProjectFiles file = _project.GetProjectFile(lnkbtnDownloadDisk.CommandArgument.ToInt());
                    string filePath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.AttachmentUploadProjectFolderPath, file.DiskFileName));

                    if (!File.Exists(filePath))
                    {
                        throw new Exception(Notifications.GetMessage("file_not_exist"));
                    }
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "text/plain";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.FileName + ";");
                    HttpContext.Current.Response.TransmitFile(filePath);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void DeleteProjectFile(int FileId)
        {
            try
            {
                string rMessage;
                _project.DeleteProjectFile(FileId, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                }
                else
                {
                    rgFilesAttList.Rebind();
                    AppNotification.MessageBoxSuccess("File deleted successfully.");
                }

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void DeleteProjectNote(int noteId)
        {
            try
            {
                string rMessage;
                _project.DeleteProjectNote(noteId, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                }
                else
                {
                    rgNotesList.Rebind();
                    AppNotification.MessageBoxSuccess("Note deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void DeleteLinkButton_Click(Object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (button.CommandName.ToString() == "DeletdNote")
            {
                DeleteProjectNote(button.CommandArgument.ToInt());
            }
            else if (button.CommandName.ToString() == "DeletdFile")
            {
                DeleteProjectFile(button.CommandArgument.ToInt());
            }
        }
        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            ProjectFiles file = new ProjectFiles();
            file.ProjectId = ProjectId;

            if (fuProjectFile.HasFile)
            {
                string ProjrctFolderPath = "";
                string relativePath = ProjrctFolderPath == string.Empty ? CommonMember.AttachmentUploadProjectFolderPath : ProjrctFolderPath;
                string filename = Path.GetFileName(fuProjectFile.PostedFile.FileName);
                file.FileName = filename;

                string guid = Guid.NewGuid().ToString();
                string fileNameGuid = string.Format("{0}{1}", guid, Path.GetExtension(filename));
                fuProjectFile.SaveAs(HttpContext.Current.Server.MapPath(relativePath + fileNameGuid));

                file.DiskFileName = fileNameGuid;
                file.Extension = ContentTypeHelper.GetContentType(Path.GetExtension(filename));
                file.Size = fuProjectFile.PostedFile.ContentLength;

                if (AppSettings.SaveFileDataDb == true)
                {
                    Stream fs = fuProjectFile.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    file.FileData = bytes;
                }
            }
            string rMessage;
            _project.AddProjectFile(file, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
            else
            {
                rgFilesAttList.Rebind();
                AppNotification.MessageBoxSuccess("File Added successfully.");
            }
        }

        protected void btnSaveNote_Click(object sender, EventArgs e)
        {
            ProjectNotes file = new ProjectNotes();

            file.ProjectId = ProjectId;
            file.NoteText = txtProjectNote.Text;

            string rMessage;
            _project.AddProjectNote(file, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
            else
            {
                rgNotesList.Rebind();
                AppNotification.MessageBoxSuccess("File Added successfully.");
            }
        }
        //protected void AddFile_FinishClicked(object sender, EventArgs e)
        //{
        //    rgFilesAttList.Rebind();
        //    //AppNotification.MessageBoxSuccess("File Added successfully.");
        //}
        //protected void AddNote_FinishClicked(object sender, EventArgs e)
        //{
        //    rgNotesList.Rebind();
        //    //AppNotification.MessageBoxSuccess("Note Added successfully.");
        //}

       
        //************************************** Properties ************************************//
        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }

        public int FileId
        {
            get { return ViewState["FileId"] != null ? ViewState["FileId"].ToInt() : -1; }
            set { ViewState["FileId"] = value; }
        }
    }
}