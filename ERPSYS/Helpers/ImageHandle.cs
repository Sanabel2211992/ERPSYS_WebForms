using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ERPSYS.Helpers
{
    public class ImageHandle
    { 
        public static byte[] CreateThumbnail(byte[] passedImage, int largestSide)
        {
            byte[] returnedThumbnail;

            using (MemoryStream startMemoryStream = new MemoryStream(), newMemoryStream = new MemoryStream())
            {

                startMemoryStream.Write(passedImage, 0, passedImage.Length);
                Bitmap startBitmap = new Bitmap(startMemoryStream);
                    
                int newHeight;
                int newWidth;
                double hwRatio;
                if (startBitmap.Height > startBitmap.Width)
                {
                    newHeight = largestSide;
                    hwRatio = largestSide / (double)startBitmap.Height;
                    newWidth = (int)(hwRatio * startBitmap.Width);
                }
                else
                {
                    newWidth = largestSide;
                    hwRatio = (double)largestSide / startBitmap.Width;
                    newHeight = (int)(hwRatio * startBitmap.Height);
                }   
                var newBitmap = ResizeImage(startBitmap, newWidth, newHeight); 
                newBitmap.Save(newMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                returnedThumbnail = newMemoryStream.ToArray();
            }
            return returnedThumbnail;
        }

        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        public static byte[] ImageToByte(string sPath)
        {
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            return br.ReadBytes((int)numBytes);
        }

        public static byte[] ImageToByte(System.Web.HttpPostedFile postedFile)
        {
            Stream str = postedFile.InputStream;
            BinaryReader br = new BinaryReader(str);
            return br.ReadBytes((int)str.Length);
        }

        public static string ImageFromByte(byte[] imageData, string imgExt)
        {
            string base64String = System.Convert.ToBase64String(imageData, 0, imageData.Length);
            return string.Format("data:image/mypicture{0};base64,{1}", imgExt, base64String);
        }

        public static Bitmap SmartResize(string strImageFile, Size objMaxSize, ImageFormat enuType)
        {
            Bitmap objImage = null;
            objImage = new Bitmap(strImageFile);

            if (objImage.Width > objMaxSize.Width || objImage.Height > objMaxSize.Height)
            {
                double dblWidthRatio = objMaxSize.Width / (double)objImage.Width;
                double dblHeightRatio = objMaxSize.Height / (double)objImage.Height;
                var dblRatio = dblWidthRatio < dblHeightRatio ? dblWidthRatio : dblHeightRatio;
                var objSize = new Size((int)(objImage.Width * dblRatio), (int)(objImage.Height * dblRatio));

                Bitmap objNewImage = Resize(objImage, objSize, enuType);

                objImage.Dispose();
                return objNewImage;
            }

            return objImage;
        }

        public static Bitmap Resize(Bitmap imgPhoto, Size objSize, ImageFormat enuType)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            const int sourceX = 0;
            const int sourceY = 0;

            const int destX = 0;
            const int destY = 0;
            int destWidth = objSize.Width;
            int destHeight = objSize.Height;

            Bitmap bmPhoto;
            if (Equals(enuType, ImageFormat.Png))
                bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
            else if (Equals(enuType, ImageFormat.Gif))
                bmPhoto = new Bitmap(destWidth, destHeight); //PixelFormat.Format8bppIndexed should be the right value for a GIF, but will throw an error with some GIF images so it's not safe to specify.
            else
                bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}