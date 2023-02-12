using ERPSYS.BLL;
using System;
using System.Web;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.files
{
    public partial class FileForm : System.Web.UI.Page
    {
        readonly FilesBLL _file = new FilesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkbtnOpenFile_Click(object sender, EventArgs e)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = TempContentType;
            response.AddHeader("Content-Disposition", "attachment; filename=" + TempFileName + ";");
            response.TransmitFile(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.AttachmentUploadTempFolderPath, TempFileName)));
            response.Flush();
            response.End();
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fuFile.HasFile)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("file_upload_failed"));
                    return;
                }

                FileHandle fileHandle = new FileHandle();

                fileHandle.FileAllowedSize = CommonMember.MaxUploadFileSizeMb;

                FileAttachment file = fileHandle.SaveFileToTempFolder(fuFile);

                TempFileName = file.FileName;
                TempContentType = file.ContentType;

                lnkbtnOpenFile.Text = string.Format("{0} ({1})", "Open file", TempFileName);
                lnkbtnOpenFile.Enabled = true;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void AddAttachmentFile()
        {
            FileHandle fileHandle = new FileHandle();

            fileHandle.IsPrivate = cbIsPrivate.Checked;
            fileHandle.SaveFileDataOnDatabase = _file.SaveFileDataDb;

            FileAttachment file = fileHandle.SaveFileFromTempFolder(TempFileName, txtFileDescription.Text.ToTrimString());

            string rMessage;
            int fileId = _file.AddAttachmentFile(file, out rMessage);

            if (rMessage != string.Empty || fileId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("file-list.aspx?o={0}", 1));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TempFileName))
                {
                    AppNotification.MessageBoxWarning(Notifications.GetMessage("file_not_upload"));
                    return;
                }

                AddAttachmentFile();

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("file-list.aspx");
        }

        //************************************** Properties ************************************//

        private string TempFileName
        {
            get { return ViewState["TempFileName"] != null ? ViewState["TempFileName"].ToString() : ""; }
            set { ViewState["TempFileName"] = value; }
        }

        private string TempContentType
        {
            get { return ViewState["TempContentType"] != null ? ViewState["TempContentType"].ToString() : ""; }
            set { ViewState["TempContentType"] = value; }
        }
    }
}