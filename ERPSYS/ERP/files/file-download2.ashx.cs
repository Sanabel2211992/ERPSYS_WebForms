using System;
using System.Threading;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.files
{
    public class FileDownload2 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        readonly FilesBLL _file = new FilesBLL();

        public void ProcessRequest(HttpContext context)
        {
            //try
            //{
            //    int fileId = context.Request.QueryString["id"].ToInt();
            //    FileAttachment file = _file.GetAttachmentFile(fileId);

            //    HttpContext.Current.Response.ClearContent();
            //    HttpContext.Current.Response.Clear();
            //    //HttpContext.Current.Response.Buffer = true;
            //    //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //    HttpContext.Current.Response.ContentType = file.ContentType;
            //    HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.ActualFileName);
            //    HttpContext.Current.Response.BinaryWrite(file.FileData);
            //    HttpContext.Current.Response.Flush();
            //    HttpContext.Current.Response.End();
            //}
            //catch (ThreadAbortException)
            //{
            //}
            //catch (Exception ex)
            //{
            //    AppNotification.WriteExceptionLog(ex);
            //}
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