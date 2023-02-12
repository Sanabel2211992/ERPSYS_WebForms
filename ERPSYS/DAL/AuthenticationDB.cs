using System.Data;
using DAL;

namespace ERPSYS.DAL
{
    public class AuthenticationDB : CommonDB
    {
        public DataTable CheckUserAuthentication(string username, string password)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Username", username));
            paramCollection.Add(new DBParameter("@Password", password));

            return Dbhelper.ExecuteDataTable("BASE_Login_CheckUserAuthentication", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetLoginUserSetting(int userId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@UserId", userId));

            return Dbhelper.ExecuteDataSet("BASE_Login_UserSetting_GET", paramCollection, CommandType.StoredProcedure);
        }
    }
}