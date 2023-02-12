using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.IO;
using System.Web;
using Telerik.Web.UI;

namespace ERPSYS.Controls.DialogBox.Projects
{
    public partial class AddProjectFile : System.Web.UI.UserControl
    {
        readonly ProjectBLL _project = new ProjectBLL();
        public event ClickEventHandler FinishClickedFile;

        protected void Page_Load(object sender, EventArgs e)
        {

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
            FinishButton_Click(sender, e);
        }
        protected void FinishButton_Click(object sender, EventArgs e)
        {
            if (FinishClickedFile != null)
            {
                FinishClickedFile(sender, e);
            }
        }

        //************************************** Properties ************************************//
        public int ProjectId { get; set; }
    }
}