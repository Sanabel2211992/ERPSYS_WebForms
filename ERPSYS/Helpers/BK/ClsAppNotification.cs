//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using ERPSYS.BLL;
//using ERPSYS.Controls;
//using ERPSYS.Members;

//namespace ERPSYS.Helpers
//{
//    public class ClsAppNotification
//    {
//        protected static void ShowMessageBox(Exception exception, MessageBoxTypes msgType)
//        {
//            var pageHandler = HttpContext.Current.CurrentHandler;
//            if(pageHandler is System.Web.UI.Page)
//            {
//                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
//                if(masterPage != null)
//                {
//                    string innerException = "";
//                    if((exception.InnerException != null))
//                    {
//                        //innerException = exception.InnerException.ToString();
//                        innerException = exception.InnerException.Message;
//                    }

//                    string message = string.Format("{0} {1}", exception.Message, innerException);
                    
//                    UCNotification notificationBox = (UCNotification)masterPage.FindControl("NotificationBox");
//                    notificationBox.SetMessage(message);
//                }
//            }
//        }

//        protected static void ShowMessageBox(string message, MessageBoxTypes msgType)
//        {
//            var pageHandler = HttpContext.Current.CurrentHandler;
//            if(pageHandler is System.Web.UI.Page)
//            {
//                var masterPage = ((System.Web.UI.Page)pageHandler).Master;
//                if(masterPage != null)
//                {
//                    UCNotification notificationBox = (UCNotification)masterPage.FindControl("NotificationBox");
//                    notificationBox.SetMessage(message);
//                }
//            }
//        }

//        internal static void MessageBoxExceptionError(string classTypeName, string methodName, Exception exception)
//        {
//            try
//            {
//                MessageBoxExceptionError(exception, string.Format("{0}-{1}\r\n{2}", classTypeName, methodName, exception.Message));
//            }
//            catch
//            {
//                // ignored
//            }
//        }

//        internal static void MessageBoxExceptionError(Exception exception, string fullexception)
//        {
//            try
//            {
//                ShowMessageBox(exception, MessageBoxTypes.Error);
//                ClsLogging.WriteExceptionError(fullexception);
//            }
//            catch(Exception)
//            {
//                //if(!ex.Message.Contains(EventLogFill))
//                // MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.ConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
//            }
//        }
//        internal static void MessageBoxExceptionError(Exception exception)
//        {
//            try
//            {
//                //ShowMessageBox(exception.Message, Enums.MessageBoxTypes.Error);
//                ShowMessageBox(exception, MessageBoxTypes.Error);
//                ClsLogging.WriteExceptionError(exception);
//            }
//            catch(Exception)
//            {
//                //if(!ex.Message.Contains(EventLogFill))
//                // MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.ConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
//            }
//        }
//        internal static void MessageBoxSuccess(string messageString)
//        {
//            try
//            {
//                ShowMessageBox(messageString, MessageBoxTypes.Success);
//            }
//            catch(Exception ex)
//            {
//                MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.XConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }
//        internal static void MessageBoxInformation(string messageString)
//        {
//            try
//            {
//                ShowMessageBox(messageString, MessageBoxTypes.Info);
//            }
//            catch(Exception ex)
//            {
//                MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.XConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        internal static void MessageBoxWarning(string messageString)
//        {
//            try
//            {
//                ShowMessageBox(messageString, MessageBoxTypes.Warning);
//            }
//            catch(Exception ex)
//            {
//                MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.XConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }

//        internal static void MessageBoxError(string messageString)
//        {
//            try
//            {
//                ShowMessageBox(messageString, MessageBoxTypes.Error);
//            }
//            catch(Exception ex)
//            {
//                MessageBoxExceptionError(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.XConvertToTrimString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
//            }
//        }
//    }
//}