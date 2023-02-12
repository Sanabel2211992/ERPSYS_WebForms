using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace ERPSYS.BLL
{
    public class UserState
    {
        public static string SessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static string PublicIpAddress()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string ServerIpAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
                {
                    return ip.ToString();
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string MachineName()
        {
            try
            {
                string ip = PublicIpAddress();
                IPAddress myIp = IPAddress.Parse(ip);
                IPHostEntry getIpHost = Dns.GetHostEntry(myIp);
                List<string> compName = getIpHost.HostName.Split('.').ToList();
                return compName.First();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string BrowserInformation()
        {
            try
            {
                HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                string info = "Browser Capabilities<br />"
                    + "Type = " + browser.Type + "<br />"
                    + "Name = " + browser.Browser + "<br />"
                    + "Version = " + browser.Version + "<br />"
                    + "Major Version = " + browser.MajorVersion + "<br />"
                    + "Minor Version = " + browser.MinorVersion + "<br />"
                    + "Platform = " + browser.Platform + "<br />"
                    + "Is Beta = " + browser.Beta + "<br />"
                    + "Is Crawler = " + browser.Crawler + "<br />"
                    + "Is AOL = " + browser.AOL + "<br />"
                    + "Is Win16 = " + browser.Win16 + "<br />"
                    + "Is Win32 = " + browser.Win32 + "<br />"
                    + "Supports Frames = " + browser.Frames + "<br />"
                    + "Supports Tables = " + browser.Tables + "<br />"
                    + "Supports Cookies = " + browser.Cookies + "<br />"
                    + "Supports VBScript = " + browser.VBScript + "<br />"
                    + "Supports JavaScript = " +
                        browser.EcmaScriptVersion + "<br />"
                    + "Supports Java Applets = " + browser.JavaApplets + "<br />"
                    + "Supports ActiveX Controls = " + browser.ActiveXControls
                          + "<br />"
                    + "Supports JavaScript Version = " +
                        browser["JavaScriptVersion"] + "<br />";

                return info;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string BrowserType()
        {
            try
            {
                HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                return browser.Type;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string BrowserName()
        {
            try
            {
                HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                return browser.Browser;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}