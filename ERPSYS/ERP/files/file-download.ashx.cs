using System;
using System.Threading;
using System.Web;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.files
{
    public class FileDownload : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {
        readonly FilesBLL _file = new FilesBLL();

        public void ProcessRequest(HttpContext context)
        {
            int fileId = context.Request.QueryString["id"].ToInt();
            FileAttachment file = _file.GetAttachmentFile(fileId);
            HttpResponse response = HttpContext.Current.Response;

            try
            {
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "attachment; filename=" + file.ActualFileName + ";");
                response.TransmitFile(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", file.RelativeDiskPath, file.FileName)));
                response.Flush();
                response.End();
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.WriteExceptionLog(ex);
            }         
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