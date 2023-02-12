using DAL;
using ERPSYS.BLL;
using System.Data;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class FilesDB : CommonDB
    {
        //*****************************************************************************************************//SELECT

        public DataTable GetAttachmentFilesList(string description)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Description", description));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("DM_FileAttachment_List_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetAttachmentFile(int fileId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@FileId", fileId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            
            return Dbhelper.ExecuteDataTable("DM_FileAttachment_GET", paramCollection, CommandType.StoredProcedure);
        }

        //*****************************************************************************************************//INSERT

        public int AddAttachmentFile(FileAttachment file, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FileName", file.FileName));
            paramCollection.Add(new DBParameter("@ActualFileName", file.ActualFileName));
            paramCollection.Add(new DBParameter("@Description", file.Description));
            paramCollection.Add(new DBParameter("@ContentType", file.ContentType));
            paramCollection.Add(new DBParameter("@Extension", file.Extension));
            paramCollection.Add(new DBParameter("@FileData", file.FileData, DbType.Binary));
            paramCollection.Add(new DBParameter("@Size", file.Size, DbType.Decimal));
            paramCollection.Add(new DBParameter("@IsPrivate", file.IsPrivate, DbType.Boolean));
            paramCollection.Add(new DBParameter("@OnDisk", file.OnDisk, DbType.Boolean));
            paramCollection.Add(new DBParameter("@OnDatabase", file.OnDatabase, DbType.Boolean));
            paramCollection.Add(new DBParameter("@RelativeDiskPath", file.RelativeDiskPath));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("DM_FileAttachment_ADD", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();

            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == -1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        //******************************************************************************************************//DELETE

        public void DeleteAttachmentFile(int fileId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@FileId", fileId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("DM_FileAttachment_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("file_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}