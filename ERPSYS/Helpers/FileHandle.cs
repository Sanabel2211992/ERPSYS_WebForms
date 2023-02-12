using System;
using System.IO;
using System.Web;
using System.Linq;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using ERPSYS.BLL;

namespace ERPSYS.Helpers
{
    public class FileHandle
    {
        private bool _saveFileDataOnDisk = true;
        private bool _saveFileOnDatabase = false;
        private bool _isPrivate = false;
        private string[] _allowedExtenstions = { };
        private decimal _allowedSize = 0;

        public bool SaveFileDataOnDisk
        {
            get { return _saveFileDataOnDisk; }
            set { _saveFileDataOnDisk = value; }
        }

        public bool SaveFileDataOnDatabase
        {
            get { return _saveFileOnDatabase; }
            set { _saveFileOnDatabase = value; }
        }

        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }

        public string[] FileAllowedExtenstions
        {
            get { return _allowedExtenstions; }
            set { _allowedExtenstions = value; }
        }

        public decimal FileAllowedSize
        {
            get { return _allowedSize; }
            set { _allowedSize = value; }
        }

        public FileAttachment SaveFileToTempFolder(System.Web.UI.WebControls.FileUpload fuFile, string tempFolderPath = "")
        {
            try
            {
                if (_allowedExtenstions.Length > 0)
                {
                    string ext = Path.GetExtension(fuFile.FileName);
                    if (!_allowedExtenstions.Contains(ext))
                    {
                        throw new Exception((Notifications.GetMessage("file_ext_not_allowed")));
                    }
                }

                if (_allowedSize > 0)
                {
                    var fileSizeMb = (fuFile.PostedFile.ContentLength.ToDecimal() / 1048576);
                    if (fileSizeMb > _allowedSize)
                    {
                        throw new Exception((Notifications.GetMessage("file_size_exceed")));
                    }
                }

                string relativePath = tempFolderPath == string.Empty ? CommonMember.AttachmentUploadTempFolderPath : tempFolderPath;
                string filename = Path.GetFileName(fuFile.PostedFile.FileName);
                 
                fuFile.SaveAs(HttpContext.Current.Server.MapPath(relativePath + filename));

                FileAttachment file = new FileAttachment();

                file.FileName = filename;
                file.ContentType = ContentTypeHelper.GetContentType(Path.GetExtension(filename));

                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FileAttachment SaveFileFromTempFolder(string fileName, string fileDescription)
        {
            try
            {
                FileAttachment file = new FileAttachment();

                FileInfo uploadFile = new FileInfo(string.Format("{0}{1}", HttpContext.Current.Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), fileName));

                string actualFilename = Path.GetFileName(fileName);
                string fileExtension = Path.GetExtension(actualFilename);
                decimal fileSize = (uploadFile.Length.ToDecimal() / 1024);
                string fileContentType = ContentTypeHelper.GetContentType(fileExtension);
                string guid = Guid.NewGuid().ToString();
                string fileNameGuid = string.Format("{0}{1}", guid, fileExtension);
                byte[] fileData = { };
                string relativeDiskPath = "";

                if (_saveFileOnDatabase)
                {
                    FileStream fs = new FileStream(uploadFile.FullName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    fileData = br.ReadBytes((Int32)fs.Length);
                }

                if (_saveFileDataOnDisk)
                {
                    relativeDiskPath = CommonMember.AttachmentUploadFolderPath;
                    string tempfileLocation = string.Format("{0}{1}", HttpContext.Current.Server.MapPath(CommonMember.AttachmentUploadTempFolderPath), fileName);
                    string fileLocation = string.Format("{0}{1}", HttpContext.Current.Server.MapPath(CommonMember.AttachmentUploadFolderPath), fileNameGuid);
                    File.Copy(tempfileLocation, fileLocation);
                }

                file.FileName = fileNameGuid;
                file.ActualFileName = actualFilename;
                file.Description = fileDescription;
                file.ContentType = fileContentType;
                file.Extension = fileExtension;
                file.FileData = fileData;
                file.Size = fileSize;
                file.IsPrivate = _isPrivate;
                file.OnDisk = _saveFileOnDatabase;
                file.OnDatabase = _saveFileDataOnDisk;
                file.RelativeDiskPath = relativeDiskPath;

                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FileAttachment SaveFileFromUploadControl(System.Web.UI.WebControls.FileUpload fuFile, string fileDescription)
        {
            try
            {
                FileAttachment file = new FileAttachment();

                string actualFileName = Path.GetFileName(fuFile.FileName);
                string fileExtension = Path.GetExtension(actualFileName);
                decimal fileSize = (fuFile.PostedFile.ContentLength.ToDecimal() / 1024);
                string fileContentType = ContentTypeHelper.GetContentType(fileExtension);
                string guid = Guid.NewGuid().ToString();
                string fileNameGuid = string.Format("{0}{1}", guid, fileExtension);
                byte[] fileData = { };
                string relativeDiskPath = "";

                if (_saveFileOnDatabase)
                {
                    Stream fs = fuFile.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                }

                if (_saveFileDataOnDisk)
                {
                    relativeDiskPath = CommonMember.AttachmentUploadFolderPath;
                    fuFile.SaveAs(HttpContext.Current.Server.MapPath(relativeDiskPath + fileNameGuid));
                }

                file.FileName = fileNameGuid;
                file.ActualFileName = actualFileName;
                file.Description = fileDescription;
                file.ContentType = fileContentType;
                file.Extension = fileExtension;
                file.FileData = fileData;
                file.Size = fileSize;
                file.OnDisk = _saveFileDataOnDisk;
                file.OnDatabase = _saveFileOnDatabase;
                file.RelativeDiskPath = relativeDiskPath;

                return file;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenFileFromTempFolder(string fileName)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.AttachmentUploadTempFolderPath, fileName));

                if (!File.Exists(filePath))
                {
                    throw new Exception(Notifications.GetMessage("file_not_exist"));
                }

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = ContentTypeHelper.GetContentType(Path.GetExtension(fileName));
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
                HttpContext.Current.Response.TransmitFile(filePath);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenFileFromDisk(int fileId)
        {
            try
            {
                FilesBLL fileBLL = new FilesBLL();
                FileAttachment file = fileBLL.GetAttachmentFile(fileId);

                string filePath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", file.RelativeDiskPath, file.FileName));

                if (!File.Exists(filePath))
                {
                    throw new Exception(Notifications.GetMessage("file_not_exist"));
                }

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.ActualFileName + ";");
                HttpContext.Current.Response.TransmitFile(filePath);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenFileFromDatabase(int fileId)
        {
            try
            {
                FilesBLL fileBLL = new FilesBLL();
                FileAttachment file = fileBLL.GetAttachmentFile(fileId);

                if (file.FileData.Length == 0)
                {
                    throw new Exception(Notifications.GetMessage("file_not_exist"));
                }

                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = file.ContentType;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.ActualFileName);
                HttpContext.Current.Response.BinaryWrite(file.FileData);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}