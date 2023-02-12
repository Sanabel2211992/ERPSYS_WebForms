using System.Data;
using ERPSYS.DAL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class UserBLL
    {
        private readonly UserDB _user = new UserDB();

        //**************************************************************************************************************************//SELECT

        public UserAccount GetUser(int userId)
        {
            DataTable dt = _user.GetUser(userId);

            UserAccount user = new UserAccount();

            if (dt.Rows.Count == 0)
            {
                user.UserId = -1;
                return user;
            }

            DataRow dr = dt.Rows[0];

            user.UserId = userId;
            user.DisplayName = dr["DisplayName"].ToString();
            user.UserName = dr["UserName"].ToString();
            user.UserTitle = dr["UserTitle"].ToString();
            user.RoleId = dr["RoleId"].ToInt();
            user.DepratmentId = dr["DepartmentId"].ToInt();
            user.EmailAddress = dr["EmailAddress"].ToString();
            user.LocationId = dr["LocationId"].ToInt();
            user.IsActive = dr["IsActive"].ToBool();
            user.HasCostView = dr["HasCostView"].ToBool();
            user.AuthorizePages = dr["AuthorizePage"].ToString();
            user.Password = dr["Password"].ToString();
            user.Mobile = dr["Mobile"].ToString();
            user.UserSignature = dr["UserSignature"].ToString();

            FileImage profileimage = new FileImage();

            profileimage.ImageData = dr["UserImage"].ToBytes();
            profileimage.ImageType = dr["UserImageType"].ToString();
            user.UserImage = profileimage;

            return user;
        }

        public LoginUserAccount GetLoginUserAccount(int userId)
        {
            DataTable dt = _user.GetLoginUserAccount(userId);

            LoginUserAccount user = new LoginUserAccount();
            FileImage profileimage = new FileImage();

            if (dt.Rows.Count == 0)
            {
                user.UserId = -1;
                return user;
            }

            DataRow dr = dt.Rows[0];

            user.UserId = userId;
            user.Mobile = dr["Mobile"].ToString();
            user.Email = dr["EmailAddress"].ToString();
            user.UserSignature = dr["UserSignature"].ToString();
            profileimage.ImageData = dr["UserImage"].ToBytes();
            profileimage.ImageType =  dr["UserImageType"].ToString();
            user.UserImage = profileimage;

            return user;
        }

        public DataTable GetUserList(string name, int departmentId, int locationId,  int statusId)
        {
            return _user.GetUserList(name, departmentId, locationId, statusId);
        }

        public DataTable GetUsersProfilePictures()
        {
            return _user.GetUsersProfilePictures();
        }

        //**************************************************************************************************************************//INSERT

        public int AddUser(UserAccount user, out string rMsg)
        {
            return _user.AddUser(user, out rMsg);
        }

        //**************************************************************************************************************************//UPDATE

        public int UpdateUser(UserAccount user, out string rMsg)
        {
            return _user.UpdateUser(user, out rMsg);
        }

        public void UpdateUserPassword(string currentPassword, string newPassword, out string rMsg)
        {
            _user.UpdateUserPassword(currentPassword, newPassword, out rMsg);
        }

        public void UpdateUserPermission(UserAccount user, out string rMsg)
        {
            _user.UpdateUserPermission(user, out rMsg);
        }

        public void UpdateLoginUserAccount(LoginUserAccount loginUserAccount, out string rMsg)
        {
            _user.UpdateLoginUserAccount(loginUserAccount, out rMsg);
        }

        public void ResetUserPassword(int userId, string newPassword, out string rMsg)
        {
            _user.ResetUserPassword(userId, newPassword, out rMsg);
        }

        //**************************************************************************************************************************//DELETE
        public void DeleteUser(int userId, out string rMessage, out int rMessageId)
        {
            _user.DeleteUser(userId, out rMessage, out rMessageId);
        }
    }
}