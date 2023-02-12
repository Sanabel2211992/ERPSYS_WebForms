using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.Controls.FileUpload
{
    public partial class UCImageUpload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AsyncUpload1_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            const string relativePath = "~/Files/UploadTemp/";
            string filePath = relativePath + e.File.FileName;

            e.File.SaveAs(MapPath(relativePath) + e.File.FileName);
            imgPreview.ImageUrl = filePath;
            lblMessage.Text = "upload successfully";
        }
    }
}