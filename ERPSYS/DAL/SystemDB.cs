using System.Data;

namespace ERPSYS.DAL
{
    public class SystemDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetSystemPages()
        {
            return Dbhelper.ExecuteDataTable("GLOBAL_Pages_GET", CommandType.StoredProcedure);
        }
    }
}