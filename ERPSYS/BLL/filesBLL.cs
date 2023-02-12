using ERPSYS.DAL;
using System.Data;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class FilesBLL
    {
        private readonly FilesDB _file = new FilesDB();

        //**************************************************************************************************************************//

        public bool SaveFileDataDb
        {
            get { return AppSettings.SaveFileDataDb; }
        }

        //******************************************************************************************//SELECT

        public DataTable GetAttachmentFilesList(string description)
        {
            return _file.GetAttachmentFilesList(description);
        }

        public FileAttachment GetAttachmentFile(int fileId)
        {
            DataTable dt = _file.GetAttachmentFile(fileId);

            FileAttachment file = new FileAttachment();

            if (dt.Rows.Count == 0)
            {
                file.FileId = -1;
                return file;
            }

            DataRow dr = dt.Rows[0];

            file.FileId = dr["FileId"].ToInt();
            file.FileName = dr["FileName"].ToString();
            file.ActualFileName = dr["ActualFileName"].ToString();
            file.FileType = dr["FileType"].ToString();
            file.Description = dr["Description"].ToString();
            file.ContentType = dr["ContentType"].ToString();
            file.Extension = dr["Extension"].ToString();
            file.FileData = dr["FileData"].ToBytes();
            file.Size = dr["Size"].ToDecimal();
            file.IsPrivate = dr["IsPrivate"].ToBool();
            file.OnDisk = dr["IsOnDisk"].ToBool();
            file.OnDatabase = dr["IsOnDatabase"].ToBool();
            file.RelativeDiskPath = dr["RelativeDiskPath"].ToString();
            file.AttachmentTypeId = dr["AttachmentTypeId"].ToInt();
            file.EntryUserId = dr["EntryUserId"].ToInt();
            file.EntryUserName = dr["DisplayName"].ToString();
            file.EntryDate = dr["EntryDate"].ToDate();

            return file;
        }

        //******************************************************************************************//INSERT

        public int AddAttachmentFile(FileAttachment file, out string rMsg)
        {
           return _file.AddAttachmentFile(file, out rMsg);
        }

        //*********************************************************************************************//DELETE

        public void DeleteAttachmentFile(int fileId, out string rMsg, out int rMessageId)
        {
            _file.DeleteAttachmentFile(fileId, out rMsg, out rMessageId);
        }
    }
}