using System;
using ERPSYS.BLL;

namespace ERPSYS.Controls.Common
{
    public partial class UCNotificationPanel : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMessage(string sMessage, string messageTitle, MessageBoxTypes msgType)
        {

            switch (msgType)
            {
                case MessageBoxTypes.Info:
                    rnMessage.TitleIcon = "info";
                    rnMessage.ContentIcon = "info";
                    rnMessage.Title = messageTitle == "" ? "Information" : messageTitle; 
                    rnMessage.Show(sMessage);
                    break;

                case MessageBoxTypes.Success:
                    rnMessage.TitleIcon = "ok";
                    rnMessage.ContentIcon = "ok";
                    rnMessage.Title = messageTitle == "" ? "Success" : messageTitle; 
                    rnMessage.Show(sMessage);
                    break;

                case MessageBoxTypes.Warning:
                    rnMessage.TitleIcon = "info";
                    rnMessage.ContentIcon = "info";
                    rnMessage.Title = messageTitle == "" ? "Warning" : messageTitle; 
                    rnMessage.Show(sMessage);
                    break;

                case MessageBoxTypes.Error:
                    rnMessage.TitleIcon = "delete";
                    rnMessage.ContentIcon = "delete";
                    //rnMessage.TitleIcon = "none";
                    //rnMessage.ContentIcon = "none";
                    rnMessage.Title = messageTitle == "" ? "Error" : messageTitle; 
                    rnMessage.Show(sMessage);
                    break;

                default:
                    rnMessage.TitleIcon = "deny";
                    rnMessage.ContentIcon = "deny";
                    rnMessage.Title = messageTitle == "" ? "Error" : messageTitle; 
                    rnMessage.Show(sMessage);
                    break;
            }
        }
    }
}