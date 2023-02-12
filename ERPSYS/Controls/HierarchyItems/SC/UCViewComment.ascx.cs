using ERPSYS.Members;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPSYS.Controls.HierarchyItems.SC
{
    public partial class UCViewComment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void UserImage(int userId)
        {
            if (File.Exists(Server.MapPath(CommonMember.SystemProfilePictrureSmallCachePath + userId + ".png")))
            {
                Image1.ImageUrl = CommonMember.SystemProfilePictrureSmallCachePath + userId + ".png";
            }
            else
            {
                Image1.ImageUrl = "../resources/images/default-profile-s.png";
            }
        }

        public void ViewAtt(string fileName, string actualFileName, string ticketId, string ticketLineId)
        {
            pnlAttachment.Visible = true;
            string attTypeUrl;

            if (actualFileName.Contains(".png") || actualFileName.Contains(".jpg") || actualFileName.Contains(".jpeg") || actualFileName.Contains(".gif"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_image_16.png";
            }
            else if (actualFileName.Contains(".doc") || actualFileName.Contains(".docx"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_word_16.png";
            }
            else if (actualFileName.Contains(".xls") || actualFileName.Contains(".xlsx"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_excel_16.png";
            }
            else if (actualFileName.Contains(".ppt") || actualFileName.Contains(".pptx"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_powerpoint_16.png";
            }
            else if (actualFileName.Contains(".pdf"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_pdf_16.png";
            }
            else if (actualFileName.Contains(".txt"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_text_16.png";
            }
            else if (actualFileName.Contains(".rar") || actualFileName.Contains(".zip"))
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_zipfile_16.png";
            }
            else
            {
                attTypeUrl = "../../Controls/resources/images/extensions/ico_file_16.png";
            }

            phviewLink.Controls.Add(new Literal() { Text = " <li><img src='" + attTypeUrl +
                "' height='16' width='16' />&nbsp;<a href='" + CommonMember.AttachmentUploadFolderPathTicket + ticketId + "/" + ticketLineId + "/" + 
                actualFileName + "' target='blank'>" + fileName + "</a> </li>" });
        }

        //************************************** Properties ************************************//

        public string User
        {
            get { return lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        public string Date
        {
            get { return lblDate.Text; }
            set { lblDate.Text = value; }
        }

        public string Body
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }
    }
}