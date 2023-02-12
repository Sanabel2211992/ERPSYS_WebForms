using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ERPSYS.Helpers.Ext
{
    public static class ByteExtensions
    {
        //public static byte[] ToBytes(this string fileName)
        //{
        //    if (!File.Exists(fileName))
        //        throw new FileNotFoundException(fileName);

        //    return File.ReadAllBytes(fileName);
        //}

        //public static byte[] XXToBytes(this string str)
        //{
        //    byte[] bytes = new byte[str.Length * sizeof(char)];
        //    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        //    return bytes;
        //}

        public static byte[] ToBytes(this object imageData)
        {
            if (!string.IsNullOrEmpty(imageData.ToString()))
            {
                return (byte[])imageData;
            }
            return new byte[] { };
        }
    }

}