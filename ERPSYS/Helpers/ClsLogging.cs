using System;
using System.Reflection;
using ERPSYS.BLL;
using log4net;

namespace ERPSYS.Helpers
{
    public class ClsLogging
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteInfoMessage(string message)
        {
            WriteInfoToLog(message);
        }

        public static void WriteWarnMessage(string message)
        {
            WriteWarnToLog(message);
        }

        public static void WriteExceptionMessage(string exceptionMessage)
        {
            WriteErrorToLog(exceptionMessage);
        }

        public static void WriteExceptionMessage(Exception exception)
        {
            WriteErrorToLog(exception);
        }

        public static void WriteFatalMessage(string message)
        {
            WriteFatalToLog(message);
        }

        private static void WriteInfoToLog(string message)
        {
            LogicalThreadContext.Properties["userid"] = UserSession.UserId;
            Log.Info(message);
        }

        private static void WriteErrorToLog(Exception exception)
        {
            LogicalThreadContext.Properties["userid"] = UserSession.UserId;
            Log.Error(exception);
        }

        private static void WriteWarnToLog(string message)
        {
            LogicalThreadContext.Properties["userid"] = UserSession.UserId;
            Log.Warn(message);
        }

        private static void WriteErrorToLog(string message)
        {
            LogicalThreadContext.Properties["userid"] = UserSession.UserId;
            Log.Error(message);
        }

        private static void WriteFatalToLog(string message)
        {
            LogicalThreadContext.Properties["userid"] = UserSession.UserId;
            Log.Fatal(message);
        }

        //ILog logger = LogManager.GetLogger("File");
        //Log.Error("Error");
        //Log.Error("ERP Error ", new Exception("test"));
        //Log.Debug("Debug");
        //Log.Info("Info");
        //Log.InfoFormat("CurrentTime is [{0}]", DateTime.Now.ToString("yyyy.MM.dd-hh.mm.ss~fff"));
    }
}