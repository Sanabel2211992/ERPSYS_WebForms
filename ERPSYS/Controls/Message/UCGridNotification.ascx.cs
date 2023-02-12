using System;

using ERPSYS.BLL;

namespace ERPSYS.Controls.Message
{
    public partial class UCGridNotification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (litMessage.Text == string.Empty)
            {
                ClearMessage();
            }
        }

        public void SetMessage(string sMessage)
        {
            SetMessage(sMessage, MessageBoxTypes.Error);
        }

        public void SetMessage(string sMessage, MessageBoxTypes msgType)
        {
            pnlMessage.CssClass = "messages messages-error";

            if (msgType == MessageBoxTypes.Warning)
            {
                pnlMessage.CssClass = "messages messages-warning";
            }
            else if (msgType == MessageBoxTypes.Success)
            {
                pnlMessage.CssClass = "messages messages-success";
            }

            pnlMessage.Visible = (sMessage.Length > 0);
            litMessage.Text = sMessage;
            litMessage.Visible = true;
            litSpace.Text = @"<br />";
        }

        public void ClearMessage()
        {
            litMessage.Text = "";
            litSpace.Text = "";
            pnlMessage.Visible = false;
        }
    }
}