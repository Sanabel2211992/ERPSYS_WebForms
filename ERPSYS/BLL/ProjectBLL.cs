using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class ProjectBLL
    {
        private readonly ProjectDB _project = new ProjectDB();

        //**************************************************************************************************************************//INSERT
        public void AddProject(Project project, out string rMessage)
        {
            _project.AddProject(project, out rMessage);
        }

        public void AddProjectFile(ProjectFiles project, out string rMessage)
        {
            _project.AddProjectFile(project, out rMessage);
        }

        public void AddProjectNote(ProjectNotes project, out string rMessage)
        {
            _project.AddProjectNote(project, out rMessage);
        }

        //**************************************************************************************************************************//SELECT
        public DataTable ProjectsList(string projectName)
        {
            return _project.ProjectsList(projectName);
        }

        internal Project GetProject(int projectId)
        {
            DataTable dt = _project.GetProject(projectId);

            Project project = new Project();

            if (dt.Rows.Count == 0)
            {
                project.ProjectId = -1;
                return project;
            }

            DataRow dr = dt.Rows[0];

            project.ProjectId = projectId;

            project.ProjectName = dr["ProjectName"].ToString();
            project.ProjectOwner = dr["Owner"].ToString();
            return project;
        }

        public DataTable GeFilesProjectList(int projectId)
        {
            return _project.GetAttachmentFilesList(projectId);
        }

        public DataTable GetNotesProjectList(int projectId)
        {
            return _project.GetNotesProjectList(projectId);
        }

        public ProjectFiles GetProjectFile(int fileId)
        {
            DataTable dt = _project.GetProjectFile(fileId);

            ProjectFiles file = new ProjectFiles();

            if (dt.Rows.Count == 0)
            {
                file.FileId = -1;
                return file;
            }

            DataRow dr = dt.Rows[0];

            file.FileId = dr["FileId"].ToInt();
            file.FileName = dr["FileName"].ToString();
            file.Extension = dr["Extension"].ToString();
            file.FileData = dr["Data"].ToBytes();
            file.Size = dr["Size"].ToDecimal();
            file.EntryDate = dr["EntryDate"].ToDate();
            file.DiskFileName = dr["DiskFileName"].ToString();

            return file;
        }

        //****************************************************************************************************************************//DELETE
        public void DeleteProject(int projectId, out string rMessage, out int rMessageId)
        {
            _project.DeleteProject(projectId, out rMessage, out rMessageId);
        }

        public void DeleteProjectFile(int fileId, out string rMessage)
        {
            _project.DeleteProjectFile(fileId, out rMessage);
        }

        public void DeleteProjectNote(int noteId, out string rMessage)
        {
            _project.DeleteProjectNote(noteId, out rMessage);
        }

        //****************************************************************************************************************************//MOVE

        public void Move(int movedItemId, int otherItemId, out string rMsg)
        {
            _project.Move(movedItemId, otherItemId, out rMsg);
        }
    }
}