using System;
using System.Web;
using System.Web.Services;

namespace ERPSYS.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class KeepAlive : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]

        public void KeepMeAlive()
        {
            HttpContext.Current.Session["SessionRenew"] = DateTime.Now;
            //ClsLogging.WriteInfoMessage(string.Format("User Session Renewal", ""));
        }
    }
}
