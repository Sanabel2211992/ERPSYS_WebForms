using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace ERPSYS.Helpers
{
    public class ClsHtmlBuilder
    {
        DataView _exportData = new DataView();
        private const string CHttpHeaderContent = "Content-Disposition";
        private const string CHttpAttachment = "attachment;filename=";
        public static string RenderPage(Page page, bool showSignFooter = false)
        {
            try
            {
                const int countDelimeter = 1;
                string finalHtmlToExport = "";
                string signFooter = "";
                int counter = 0;
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                page.RenderControl(htmlWrite);
                var pageInfo = stringWrite.ToString();

                for(counter = 1; counter <= countDelimeter; counter++)
                {
                    finalHtmlToExport = finalHtmlToExport + pageInfo.Substring(pageInfo.IndexOf("<!--BeginDelimiter" + counter + "-->", StringComparison.Ordinal), pageInfo.LastIndexOf("<!--EndDelimiter" + counter + "-->", StringComparison.Ordinal) - pageInfo.IndexOf("<!--BeginDelimiter" + counter + "-->", StringComparison.Ordinal));
                }
                while  (finalHtmlToExport.ToLower().IndexOf("<a href", StringComparison.Ordinal)> 0)
                {
                    var startA = finalHtmlToExport.ToLower().IndexOf("<a href", 0, StringComparison.Ordinal);
                    var closedA = finalHtmlToExport.IndexOf(">", startA + 1, StringComparison.Ordinal);
                    finalHtmlToExport = finalHtmlToExport.Remove(startA, closedA - startA + 1);
                }

                finalHtmlToExport.ToLower().Replace("</a>", " ");

                var cuPath = HttpContext.Current.Server.MapPath("~/ui/resources/css/report.css");
                var styles = ReadServerFile(cuPath);
                pageInfo = null;

                if(showSignFooter)
                {
                    signFooter = GetFileContents(HttpContext.Current.Server.MapPath("~/Files/Html/SignFooter.htm"));
                }

                return "<head> <style> " + styles + "</style> </head>" + finalHtmlToExport;
                //return "<head> <style> " + styles + "</style></head><body><center><div class=\"page\"> <div class=\"main\">" + finalHtmlToExport + "</div></div><div>" + signFooter + "</div></center></body>";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadServerFile(string path)
        {
            string functionReturnValue = null;
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("windows-1256");
            System.IO.StreamReader myStreamReader = new System.IO.StreamReader(path, encode);
            functionReturnValue = myStreamReader.ReadToEnd();
            if(functionReturnValue.Length <= 0)
            {
                return "0";
            }
            myStreamReader.Close();
            return functionReturnValue;
        }

        private static string GetFileContents(string fullPath)
        {
            try
            {
                var objReader = new System.IO.StreamReader(fullPath);
                var strContents = objReader.ReadToEnd();
                objReader.Close();
                return strContents;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}