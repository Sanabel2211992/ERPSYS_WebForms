using System.Data;
using DAL;
using ERPSYS.BLL;
using ERPSYS.Members;

namespace ERPSYS.DAL
{
    public class UserDB : CommonDB
    {
        //**************************************************************************************************************************//SELECT

        public DataTable GetUser(int userId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@userId", userId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_User_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetUserList(string name, int departmentId, int locationId, int statusId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@Name", name));
            paramCollection.Add(new DBParameter("@DepartmentId", departmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@LocationId", locationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@StatusId", statusId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_UserList_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetLoginUserAccount(int userId)
        {
            var paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@userId", userId, DbType.Int32));

            return Dbhelper.ExecuteDataTable("BASE_User_LoginAccount_GET", paramCollection, CommandType.StoredProcedure);
        }

        public DataTable GetUsersProfilePictures()
        {
            return Dbhelper.ExecuteDataTable("BASE_User_Profile_Pictures_GET", CommandType.StoredProcedure);
        }

        //**************************************************************************************************************************//INSERT

        public int AddUser(UserAccount user, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DisplayName", user.DisplayName));
            paramCollection.Add(new DBParameter("@UserName", user.UserName));
            paramCollection.Add(new DBParameter("@UserTitle", user.UserTitle));
            paramCollection.Add(new DBParameter("@Password", user.Password));
            paramCollection.Add(new DBParameter("@PasswordHash", new byte[] { }, DbType.Binary));
            paramCollection.Add(new DBParameter("@PasswordSalt", new byte[] { }, DbType.Binary));
            paramCollection.Add(new DBParameter("@IsActive", user.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@RoleId", user.RoleId, DbType.Int32));
            paramCollection.Add(new DBParameter("@DepartmentId", user.DepratmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EmailAddress", user.EmailAddress));
            paramCollection.Add(new DBParameter("@Mobile", user.Mobile));
            paramCollection.Add(new DBParameter("@UserSignature", user.UserSignature));
            paramCollection.Add(new DBParameter("@LocationId", user.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserImage", user.UserImage.ImageData, DbType.Binary));
            paramCollection.Add(new DBParameter("@UserImageType", user.UserImage.ImageType));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@newId", 0, DbType.Int32, ParameterDirection.Output));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_ADD", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            int newId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 2, command);

            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("user_add_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return newId;
        }

        //**************************************************************************************************************************//UPDATE
        public int UpdateUser(UserAccount user, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@UserAccountId", user.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@DisplayName", user.DisplayName));
            paramCollection.Add(new DBParameter("@UserName", user.UserName));
            paramCollection.Add(new DBParameter("@UserTitle", user.UserTitle));
            paramCollection.Add(new DBParameter("@IsActive", user.IsActive, DbType.Boolean));
            paramCollection.Add(new DBParameter("@RoleId", user.RoleId, DbType.Int32));
            paramCollection.Add(new DBParameter("@DepartmentId", user.DepratmentId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EmailAddress", user.EmailAddress));
            paramCollection.Add(new DBParameter("@Mobile", user.Mobile));
            paramCollection.Add(new DBParameter("@UserSignature", user.UserSignature));
            paramCollection.Add(new DBParameter("@UserImage", user.UserImage.ImageData, DbType.Binary));
            paramCollection.Add(new DBParameter("@UserImageType", user.UserImage.ImageType));
            paramCollection.Add(new DBParameter("@LocationId", user.LocationId, DbType.Int32));
            paramCollection.Add(new DBParameter("@IsUpdated", user.UserImage.IsUpdated, DbType.Boolean));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("user_update_duplicate");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }

            return i;
        }

        public void UpdateUserPassword(string currentPassword, string newPassword, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@OldPassword", currentPassword));
            paramCollection.Add(new DBParameter("@NewPassword", newPassword));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_Password_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("user_change_password_failed");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void UpdateUserPermission(UserAccount user, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@UserId", user.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@HasCostView", user.HasCostView, DbType.Boolean));
            paramCollection.Add(new DBParameter("@AuthorizePages", user.AuthorizePages));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_Permission_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }

        public void UpdateLoginUserAccount(LoginUserAccount loginUserAccount, out string rMsg)
        {
            rMsg = string.Empty; 
            var paramCollection = new DBParameterCollection(); 

            paramCollection.Add(new DBParameter("@UserId", loginUserAccount.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@EmailAddress", loginUserAccount.Email));
            paramCollection.Add(new DBParameter("@Mobile", loginUserAccount.Mobile));
            paramCollection.Add(new DBParameter("@UserSignature", loginUserAccount.UserSignature));
            paramCollection.Add(new DBParameter("@UserImage", loginUserAccount.UserImage.ImageData, DbType.Binary));
            paramCollection.Add(new DBParameter("@UserImageType", loginUserAccount.UserImage.ImageType));
            paramCollection.Add(new DBParameter("@IsUpdated", loginUserAccount.UserImage.IsUpdated, DbType.Boolean));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_LoginAccount_UPDATE", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            command.Dispose();
        }

        public void ResetUserPassword(int userId, string newPassword, out string rMsg)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@AccountUserId", userId));
            paramCollection.Add(new DBParameter("@NewPassword", newPassword));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_Password_RESET", paramCollection, CommandType.StoredProcedure);
            int i = command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            command.Dispose();

            if (errorId == 1)
            {
                rMsg = GeneralResources.GetStringFromResources("user_change_password_failed");
            }
            else if (errorId > 1)
            {
                rMsg = GeneralResources.GetStringFromResources("error_not_defined");
            }
        }
        //**************************************************************************************************************************//DELETE
        public void DeleteUser(int userId, out string rMsg, out int rMsgId)
        {
            rMsg = string.Empty;
            var paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@DeleteUserId", userId, DbType.Int32));
            paramCollection.Add(new DBParameter("@UserId", UserSession.UserId, DbType.Int32));
            paramCollection.Add(new DBParameter("@errorId", 0, DbType.Int32, ParameterDirection.Output));

            IDbCommand command = Dbhelper.GetCommand("BASE_User_DELETE", paramCollection, CommandType.StoredProcedure);
            command.ExecuteNonQuery();
            int errorId = (int)Dbhelper.GetParameterValue(paramCollection.Count() - 1, command);
            rMsgId = errorId;
            command.Dispose();

            switch (errorId)
            {
                case 1:
                    rMsg = GeneralResources.GetStringFromResources("user_delete_failed");
                    rMsgId = 4;
                    break;
                case -1:
                    rMsg = GeneralResources.GetStringFromResources("error_not_defined");
                    break;
            }
        }
    }
}