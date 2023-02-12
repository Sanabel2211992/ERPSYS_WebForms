using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Hosting;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.BLL
{
    public class RegisteredUser
    {
        public static int UserId
        {
            get { return UserSession.UserId; }
        }

        public static string UserDisplayName
        {
            get { return UserSession.UserDisplayName; }
        }

        public static string UserName
        {
            get { return UserSession.UserName; }
        }

        public static int RoleId
        {
            get { return UserSession.RoleId; }
        }

        public static string Role
        {
            get { return UserSession.Role; }
        }

        public static bool HasAdministratorView
        {
            get { return UserSession.RoleId == 1; } // Is System Admin ( permission to view some data)
        }

        public static bool HasCostView
        {
            get { return UserSession.HasCostView; }
        }

        public static int DepartmentId
        {
            get { return UserSession.DepartmentId; }
        }

        public static string Department
        {
            get { return UserSession.Department; }
        }

        public static string EmailAddress
        {
            get { return UserSession.EmailAddress; }
        }

        public static string UserTitle
        {
            get { return UserSession.UserTitle; }
        }

        public static bool HasProfilePicture
        {
            get { return UserSession.HasProfilePicture; }
        }

        public static bool HasProfilePictureCache
        {
            get { return File.Exists(HttpContext.Current.Server.MapPath(ProfilePictureCacheUrl)); }
        }

        public static string ProfilePictureCacheUrl
        {
            get { return string.Format("{0}{1}", CommonMember.SystemProfilePictrureCachePath, UserSession.UserId + ".jpg"); }
        }

        public static string ProfileSmallPicture()
        {
            try
            {
                string userPicturePath = string.Format("{0}{1}.png", CommonMember.SystemProfilePictrureSmallCachePath, RegisteredUser.UserId);
                return File.Exists(HostingEnvironment.MapPath(userPicturePath)) ? userPicturePath : "~/Site/resources/images/default-profile-s.png";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}