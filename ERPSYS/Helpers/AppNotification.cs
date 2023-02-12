using System;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Controls.Common;

namespace ERPSYS.Helpers
{
    public class AppNotification
    {
        protected static void ShowMessageBox(Exception exception, MessageBoxTypes msgType)
        {
            var pageHandler = HttpContext.Current.CurrentHandler;
            if (pageHandler is System.Web.UI.Page)
            {
                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
                if (masterPage != null)
                {
                    string innerException = "";
                    if ((exception.InnerException != null))
                    {
                        innerException = exception.InnerException.Message;
                    }

                    string message = string.Format("{0} {1}", exception.Message, innerException);

                    UCNotification notificationBox = (UCNotification)masterPage.FindControl("NotificationBox");
                    notificationBox.SetMessage(message);
                }
            }
        }

        protected static void ShowMessageBox(string message, MessageBoxTypes msgType)
        {
            var pageHandler = HttpContext.Current.CurrentHandler;
            if (pageHandler is System.Web.UI.Page)
            {
                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
                if (masterPage != null)
                {
                    UCNotification notificationBox = (UCNotification)masterPage.FindControl("NotificationBox");
                    notificationBox.SetMessage(message, msgType);
                }
            }
        }

        protected static void ShowMessagePanel(string message, string messageTitle, MessageBoxTypes msgType)
        {
            var pageHandler = HttpContext.Current.CurrentHandler;
            if (pageHandler is System.Web.UI.Page)
            {
                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
                if (masterPage != null)
                {
                    UCNotificationPanel notificationPanel = (UCNotificationPanel)masterPage.FindControl("NotificationPanel");
                    notificationPanel.SetMessage(message, messageTitle, msgType);
                }
            }
        }

        internal static void MessageBoxException(Exception exception, string fullexception)
        {
            ShowMessageBox(exception, MessageBoxTypes.Error);
            ClsLogging.WriteExceptionMessage(fullexception);
        }

        internal static void MessageBoxException(Exception exception)
        {
            ShowMessageBox(exception, MessageBoxTypes.Error);
            ClsLogging.WriteExceptionMessage(exception);
        }

        internal static void MessageBoxInformation(string messageString)
        {
            ShowMessageBox(messageString, MessageBoxTypes.Info);
        }

        internal static void MessageBoxSuccess(string messageString)
        {
            ShowMessageBox(messageString, MessageBoxTypes.Success);
        }

        internal static void MessageBoxWarning(string messageString)
        {
            ShowMessageBox(messageString, MessageBoxTypes.Warning);
        }

        internal static void MessageBoxFailed(string messageString)
        {
            ShowMessageBox(messageString, MessageBoxTypes.Error);
        }

        internal static void MessagePanel(string messageString, string messageTitle)
        {
            ShowMessagePanel(messageString, messageTitle, MessageBoxTypes.None);
        }

        internal static void MessagePanelInformation(string messageString, string messageTitle)
        {
            ShowMessagePanel(messageString, messageTitle, MessageBoxTypes.Info);
        }

        internal static void MessagePanelSuccess(string messageString, string messageTitle)
        {
            ShowMessagePanel(messageString, messageTitle, MessageBoxTypes.Success);
        }

        internal static void MessagePanelWarning(string messageString, string messageTitle)
        {
            ShowMessagePanel(messageString, messageTitle, MessageBoxTypes.Warning);
        }

        internal static void MessagePanelFailed(string messageString, string messageTitle)
        {
            ShowMessagePanel(messageString, messageTitle, MessageBoxTypes.Error);
        }

        internal static void WriteExceptionLog(Exception exception)
        {
            ClsLogging.WriteExceptionMessage(exception);
        }
    }
}