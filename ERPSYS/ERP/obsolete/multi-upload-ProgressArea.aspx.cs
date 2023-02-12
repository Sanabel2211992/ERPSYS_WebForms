using ERPSYS.Members;
using System;
using System.Web;
using Telerik.Web.UI;

namespace ERPSYS.ERP.obsolete
{
    public partial class upload_telerik_drag_drop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (UploadedFile f in AsyncUpload1.UploadedFiles)
            {
                string FileName = f.GetName();
                string fileExtension = f.GetExtension();
                string ActualFileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), fileExtension);

                f.SaveAs(HttpContext.Current.Server.MapPath(CommonMember.AttachmentUploadFolderPathTicket + "/10/" + ActualFileName));
            }
        }
    }
}