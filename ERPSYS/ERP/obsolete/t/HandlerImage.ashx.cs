using DAL;
using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.t
{
    /// <summary>
    /// Summary description for HandlerImage
    /// </summary>
    public class HandlerImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //TestBLL _File = new TestBLL();

            //int id = context.Request.QueryString["id"].ToInt();

            //ImageClass image = _File.GetImage(id);

            //context.Response.BinaryWrite(image.Data);
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}