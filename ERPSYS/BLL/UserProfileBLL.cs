using System;
using System.Drawing;
using System.IO;
using System.Web;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System.Drawing.Imaging;
using System.Web.Hosting;

namespace ERPSYS.BLL
{
    public class UserProfileBLL
    {
        public static string GetProfileSmallPicture(string userId)
        {
            try
            {
                string userPicturePath = string.Format("{0}{1}.png", CommonMember.SystemProfilePictrureSmallCachePath, userId);
                return File.Exists(HostingEnvironment.MapPath(userPicturePath)) ? userPicturePath : "~/Site/resources/images/default-profile-s.png";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void UpdateProfilePictureToCache(byte[] pictureData, string pictureName)
        {
            try
            {
                string filepath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureCachePath, pictureName + ".jpg"));
                var fs = new BinaryWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write));
                fs.Write(pictureData);
                fs.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void UpdateProfileSmallPictureToCache(byte[] pictureData, string pictureName, int width, int height)
        {
            try
            {
                String strImageFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureCachePath, pictureName + ".jpg"));
                Size objMaxSize = new Size(width, height);
                Bitmap objNewImage = ImageHandle.SmartResize(strImageFile, objMaxSize, ImageFormat.Png);
                objNewImage.Save(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png")));
                objNewImage.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void UpdateProfileSmallPictureToCache(string pictureName, int width, int height)
        {
            try
            {
                String strImageFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureCachePath, pictureName + ".jpg"));
                Size objMaxSize = new Size(width, height);
                Bitmap objNewImage = ImageHandle.SmartResize(strImageFile, objMaxSize, ImageFormat.Png);
                objNewImage.Save(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png")));
                objNewImage.Dispose();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void RemoveProfilePictureFromCache(string pictureName)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureCachePath, pictureName + ".jpg"));
                File.Delete(filePath);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void RemoveProfileSmallPictureFromCache(string pictureName)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png"));
                File.Delete(filePath);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}