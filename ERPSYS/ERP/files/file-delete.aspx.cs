using ERPSYS.BLL;
using System;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System.IO;

namespace ERPSYS.ERP.files
{
    public partial class FileDelete : System.Web.UI.Page
    {
        readonly FilesBLL _file = new FilesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteFile();
        }

        protected void DeleteFile()
        {
            try
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    int fileId = Request.QueryString["id"].ToInt();

                    FileAttachment file = _file.GetAttachmentFile(fileId);

                    string rMessage;
                    int rMessageId;

                    _file.DeleteAttachmentFile(fileId, out rMessage, out rMessageId);

                    //Move to trush folder
                    if (File.Exists(CommonMember.AttachmentUploadFolderPath + file.FileName))
                    {
                        string fileLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.AttachmentUploadFolderPath), file.FileName);
                        string trushLocation = string.Format("{0}{1}", Server.MapPath(CommonMember.TrashFolderPath), file.FileName);
                        File.Move(fileLocation, trushLocation);
                    }
                    if (rMessage != string.Empty)
                    {
                        Response.Redirect(string.Format("file-list.aspx?id={0}&e={1}", fileId, rMessageId));
                    }

                    Response.Redirect(string.Format("file-list.aspx?o={0}", 3));
                }
                else
                {
                    Response.Redirect(string.Format("file-list.aspx?e={0}", 1));
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}