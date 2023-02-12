using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System;
using Telerik.Web.UI;

namespace ERPSYS.Controls.DialogBox.Projects
{
    public partial class AddProjectNote : System.Web.UI.UserControl
    {
        readonly ProjectBLL _project = new ProjectBLL();
        public event ClickEventHandler FinishClickedNote;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveNote_Click(object sender, EventArgs e)
        {
            ProjectNotes file = new ProjectNotes();

            file.ProjectId = ProjectId;
            file.NoteText = txtProjectNote.Text;

            string rMessage;
            _project.AddProjectNote(file, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
            FinishButton_Click(sender, e);
        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            if (FinishClickedNote != null)
            {
                FinishClickedNote(sender, e);
            }
        }

        //************************************** Properties ************************************//
        public int ProjectId
        {
            get { return ViewState["ProjectId"] != null ? ViewState["ProjectId"].ToInt() : -1; }
            set { ViewState["ProjectId"] = value; }
        }
    }
}