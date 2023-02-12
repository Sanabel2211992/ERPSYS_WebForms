using DAL;
using System;
using System.Data;

namespace ERPSYS.DAL
{
    public class MonitorDB : CommonDB
    {
        public DataTable GetEventLog(DateTime dateStart, DateTime dateEnd, string eventLogType)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));
            paramCollection.Add(new DBParameter("@EventLogType", eventLogType));

            return Dbhelper.ExecuteDataTable("Monitor_Event_Log_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetErrorDatabaseLog(DateTime dateStart, DateTime dateEnd)
        {
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DateStart", dateStart, DbType.Date));
            paramCollection.Add(new DBParameter("@DateEnd", dateEnd, DbType.Date));

            return Dbhelper.ExecuteDataTable("Monitor_Error_DB_Log_GET", paramCollection, CommandType.StoredProcedure);
        }
    }
}