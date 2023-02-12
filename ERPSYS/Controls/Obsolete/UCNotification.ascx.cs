using System;
using ERPSYS.BLL;

namespace ERPSYS.Controls.Obsolete
{
    public partial class UCNotification : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(litMessage.Text == string.Empty)
            //{
            //    ClearMessage();
            //}
        }

        //public void SetMessage(string sMessage)
        //{
        //    SetMessage(sMessage, MessageBoxTypes.Error);
        //}

        //public void SetMessage(string sMessage, MessageBoxTypes msgType)
        //{
        //    pnlMessage.CssClass = "messages messages-error";
        //    litMessageTitle.Text = @"Failed";

        //    if(msgType == MessageBoxTypes.Warning)
        //    {
        //        pnlMessage.CssClass = "messages messages-warning";
        //        litMessageTitle.Text = @"Warning";
        //    }
        //    else if(msgType == MessageBoxTypes.Success)
        //    {
        //        pnlMessage.CssClass = "messages messages-success";
        //        litMessageTitle.Text = @"Successful";
        //    }

        //    pnlMessage.Visible = (sMessage.Length > 0);
        //    litMessage.Text = sMessage;
        //    litMessage.Visible = true;
        //    litSpace.Text = @"<br />";
        //}

        //public void ClearMessage()
        //{
        //    litMessage.Text = "";
        //    litSpace.Text = "";
        //    pnlMessage.Visible = false;
        //}
    }
}