using System.Data;
using ERPSYS.DAL;
using System;
using System.Drawing;

namespace ERPSYS.BLL
{
    public class MonitorBLL
    {
        readonly MonitorDB _eventLog = new MonitorDB();

        //**************************************************************************************************************************//SELECT

        public DataTable GetEventLog(DateTime dateStart, DateTime dateEnd, string eventLogType)
        {
            return _eventLog.GetEventLog(dateStart, dateEnd, eventLogType);
        }

        public DataTable GetErrorDatabaseLog(DateTime dateStart, DateTime dateEnd)
        {
            return _eventLog.GetErrorDatabaseLog(dateStart, dateEnd);
        }

        //**************************************************************************************************************************//STATIC

        public static Color LogColor(string logType)
        {
            switch (logType)
            {
                case "INFO":
                    return Color.Green;
                case "WARN":
                    return Color.Orange;
                case "ERROR":
                    return Color.Red;
                case "FATAL":
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }
    }
}