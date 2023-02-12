using DAL;
using ERPSYS.Members;
using System.Data;

namespace ERPSYS.DAL
{
    public class UserEventDB : CommonDB
    {
        ////**************************************************************************************************************************//SELECT

        //public DataTable GetEventLogList(int userId)
        //{
        //    var paramCollection = new DBParameterCollection();
        //    paramCollection.Add(new DBParameter("@UserId", userId));

        //    return Dbhelper.ExecuteDataTable("GLOBAL_EventLog_List_GET", paramCollection, CommandType.StoredProcedure);
        //}

        ////**************************************************************************************************************************//INSERT

        //public int AddEventLog(EventLog eventLog)
        //{
        //    var paramCollection = new DBParameterCollection();

        //    paramCollection.Add(new DBParameter("@UserId", eventLog.UserId, DbType.Int32));
        //    paramCollection.Add(new DBParameter("@UserName", eventLog.UserName));
        //    paramCollection.Add(new DBParameter("@MachineName", eventLog.MachineName));
        //    paramCollection.Add(new DBParameter("@IpAddress", eventLog.IpAddress));
        //    paramCollection.Add(new DBParameter("@BrowserType", eventLog.BrowserType));
        //    paramCollection.Add(new DBParameter("@Message", eventLog.Message));
        //    paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));

        //    IDbCommand command = Dbhelper.GetCommand("GLOBAL_EventLog_ADD", paramCollection, CommandType.StoredProcedure);
        //    command.ExecuteNonQuery();

        //    int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
        //    command.Dispose();

        //    return newId;
        //}
    }
}