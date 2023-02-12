using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ERPSYS.Helpers
{
    public static class ContentTypeHelper
    {
        public static string GetContentType(string extension)
        {
            var registryKey = Registry.ClassesRoot.OpenSubKey(extension);

            if (registryKey == null)
            {
                return null;
            }

            var value = registryKey.GetValue("Content Type") as string;

            return String.IsNullOrWhiteSpace(value) ? null : value;
        }

        public static string GetContentType2(string extension)
        {
            string contentType = "";

            switch (extension)
            {
                case ".doc":
                    contentType = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contentType = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contentType = "image/jpg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            return contentType;
        }

        public static string GetContentType3(string extension)
        {
            var mimeTypes = new Dictionary<String, String>
            {
                {".bmp", "image/bmp"},
                {".gif", "image/gif"},
                {".jpeg", "image/jpeg"},
                {".jpg", "image/jpeg"},
                {".png", "image/png"},
                {".tif", "image/tiff"},
                {".tiff", "image/tiff"},
                {".doc", "application/msword"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".pdf", "application/pdf"},
                {".ppt", "application/vnd.ms-powerpoint"},
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".xls", "application/vnd.ms-excel"},
                {".csv", "text/csv"},
                {".xml", "text/xml"},
                {".txt", "text/plain"},
                {".zip", "application/zip"},
                {".ogg", "application/ogg"},
                {".mp3", "audio/mpeg"},
                {".wma", "audio/x-ms-wma"},
                {".wav", "audio/x-wav"},
                {".wmv", "audio/x-ms-wmv"},
                {".swf", "application/x-shockwave-flash"},
                {".avi", "video/avi"},
                {".mp4", "video/mp4"},
                {".mpeg", "video/mpeg"},
                {".mpg", "video/mpeg"},
                {".qt", "video/quicktime"}
            };

            return mimeTypes.ContainsKey(extension) ? mimeTypes[extension] : "application/octet-stream";
        }
    }
}

