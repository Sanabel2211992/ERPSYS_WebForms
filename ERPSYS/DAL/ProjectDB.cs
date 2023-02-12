using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class ProjectDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        internal DataTable ProjectsList(string projectName)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ProjectName", projectName));

            return Dbhelper.ExecuteDataTable("MNG_Project_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetProject(int projectId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("MNG_ProjectDetails_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetAttachmentFilesList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("MNG_ProjectFilesList_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetNotesProjectList(int projectId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("MNG_ProjectNotesList_GET", paramCollection, CommandType.StoredProcedure);
        }

        internal DataTable GetProjectFile(int fileId)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FileId", fileId, DbType.Int32));
            return Dbhelper.ExecuteDataTable("MNG_ProjectFile_GET", paramCollection, CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public void AddProject(Project project, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectName", project.ProjectName));
            paramCollection.Add(new DBParameter("@ProjectOwner", project.ProjectOwner));
            paramCollection.Add(new DBParameter("@UserName", UserSession.UserName));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_Project_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);

            command.Dispose();

            if (errorId == 1)
            {
                rMessage = GeneralResources.GetStringFromResources("user_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMessage = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void AddProjectFile(ProjectFiles file, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FileName", file.FileName));
            paramCollection.Add(new DBParameter("@Extension", file.Extension));
            paramCollection.Add(new DBParameter("@DiskFileName", file.DiskFileName));
            paramCollection.Add(new DBParameter("@FileData", file.FileData, DbType.Binary));
            paramCollection.Add(new DBParameter("@Size", file.Size, DbType.Decimal));
            paramCollection.Add(new DBParameter("@UserName", UserSession.UserName));
            paramCollection.Add(new DBParameter("@ProjectId", file.ProjectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_ProjectFiles_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void AddProjectNote(ProjectNotes note, out string rMessage)
        {
            rMessage = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@NoteText", note.NoteText));
            paramCollection.Add(new DBParameter("@ProjectId", note.ProjectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserName", UserSession.UserName));

            IDbCommand command = Dbhelper.GetCommand("MNG_ProjectNote_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        //****************************************************************************************************************************//DELETE

        public void DeleteProject(int projectId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ProjectId", projectId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_Project_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("page_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteProjectFile(int fileId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FileId", fileId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_Project_File_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("file_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        public void DeleteProjectNote(int noteId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@NoteId", noteId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_Project_Note_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("note_delete_failed");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }

        //****************************************************************************************************************************//MOVE

        public void Move(int movedItemId, int otherItemId, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@MovedItemId", movedItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@OtherItemId", otherItemId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("MNG_Project_Move", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("");
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}