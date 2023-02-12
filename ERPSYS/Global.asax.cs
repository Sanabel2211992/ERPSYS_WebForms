using System;
using System.Web;
using log4net.Config;

namespace ERPSYS
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //// Get last error from the server
            //Exception ex = Server.GetLastError();

            //if(ex != null)
            //{
            //    if(ex is HttpException && ((HttpException)ex).GetHttpCode() != 500)
            //        return; // the usual yellow error screen appears with the normal HTTP error code

            //    if(ex is HttpUnhandledException)
            //    {
            //        if(ex.InnerException != null)
            //        {
            //            ex = new Exception(ex.InnerException.Message);
            //            Server.Transfer("~/ui/error/ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
            //        }
            //    }
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}