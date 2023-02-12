using System;

namespace ERPSYS.Controls
{
    public partial class AddTicket : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public string Name
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }

        public string Date
        {
            get { return lbDate.Text;  }
            set { lbDate.Text = value; }
        }

        public string Note
        {
            get { return lbNote.Text; }
            set { lbNote.Text = value; }
        }
    }
}