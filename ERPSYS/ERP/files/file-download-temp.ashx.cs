using System;
using System.IO;
using System.Threading;
using System.Web;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.files
{
    public class FileDownloadTemp : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //HttpResponse response = HttpContext.Current.Response;

            //try
            //{
            //    string fileName = context.Request.QueryString["id"].ToTrimString();

            //    response.ClearContent();
            //    response.Clear();
            //    response.ContentType = ContentTypeHelper.GetContentType(Path.GetExtension(fileName));
            //    response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
            //    response.TransmitFile(HttpContext.Current.Server.MapPath(string.Format("{0}{1}", CommonMember.AttachmentUploadTempFolderPath, fileName)));
            //    response.Flush();
            //    response.End();
            //}
            //catch (ThreadAbortException)
            //{
            //}
            //catch (Exception ex)
            //{
            //    AppNotification.WriteExceptionLog(ex);
            //    response.Redirect("file-list.aspx");
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