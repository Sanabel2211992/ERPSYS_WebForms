using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using ERPSYS.Helpers.Ext;
using System.Data;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ERPSYS.Controls.Obsolete
{
    public partial class SaveUserImage : System.Web.UI.Page
    {
       
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable table = _user.GetUsersImagesList(); // Get the data table.
            //foreach (DataRow dr in table.Rows) // Loop over the rows.
            //{
            //    if (dr["UserImage"].ToBytes().Length > 0)
            //    {
            //        AddResizeProfilePictureToCache(dr["UserImage"].ToBytes(), dr["UserId"].ToString(), 35, 35);
            //    }
            //}
            //Label1.Visible = true;
        }

        //public static void AddResizeProfilePictureToCache(byte[] pictureData, string pictureName, int width, int height)
        //{
        //    try
        //    {
        //        string filepath = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png"));
        //        var fs = new BinaryWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write));
        //        fs.Write(pictureData);
        //        fs.Close();

        //        String strImageFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png"));
        //        System.Drawing.Size objMaxSize = new System.Drawing.Size(width, height);
        //        System.Drawing.Bitmap objNewImage = SmartResize(strImageFile, objMaxSize, ImageFormat.Png);
        //        objNewImage.Save(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.SystemProfilePictrureSmallCachePath, pictureName + ".png")));
        //        objNewImage.Dispose();

        //    }
        //    catch (Exception)
        //    {
        //        // ignored
        //    }
        //}

        //public static Bitmap SmartResize(string strImageFile, Size objMaxSize, ImageFormat enuType)
        //{
        //    Bitmap objImage = null;
        //    try
        //    {
        //        objImage = new Bitmap(strImageFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    if (objImage.Width > objMaxSize.Width || objImage.Height > objMaxSize.Height)
        //    {
        //        Size objSize;
        //        int intWidthOverrun = 0;
        //        int intHeightOverrun = 0;
        //        if (objImage.Width > objMaxSize.Width)
        //            intWidthOverrun = objImage.Width - objMaxSize.Width;
        //        if (objImage.Height > objMaxSize.Height)
        //            intHeightOverrun = objImage.Height - objMaxSize.Height;

        //        double dblRatio;
        //        double dblWidthRatio = (double)objMaxSize.Width / (double)objImage.Width;
        //        double dblHeightRatio = (double)objMaxSize.Height / (double)objImage.Height;
        //        if (dblWidthRatio < dblHeightRatio)
        //            dblRatio = dblWidthRatio;
        //        else
        //            dblRatio = dblHeightRatio;
        //        objSize = new Size((int)((double)objImage.Width * dblRatio), (int)((double)objImage.Height * dblRatio));

        //        Bitmap objNewImage = Resize(objImage, objSize, enuType);

        //        objImage.Dispose();
        //        return objNewImage;
        //    }
        //    else
        //    {
        //        return objImage;
        //    }
        //}

        //public static Bitmap Resize(Bitmap imgPhoto, Size objSize, ImageFormat enuType)
        //{
        //    int sourceWidth = imgPhoto.Width;
        //    int sourceHeight = imgPhoto.Height;
        //    int sourceX = 0;
        //    int sourceY = 0;

        //    int destX = 0;
        //    int destY = 0;
        //    int destWidth = objSize.Width;
        //    int destHeight = objSize.Height;

        //    Bitmap bmPhoto;
        //    if (enuType == ImageFormat.Png)
        //        bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
        //    else if (enuType == ImageFormat.Gif)
        //        bmPhoto = new Bitmap(destWidth, destHeight); //PixelFormat.Format8bppIndexed should be the right value for a GIF, but will throw an error with some GIF images so it's not safe to specify.
        //    else
        //        bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);

        //    Graphics grPhoto = Graphics.FromImage(bmPhoto);
        //    grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
        //    grPhoto.Dispose();
        //    return bmPhoto;
        //}
    }
}