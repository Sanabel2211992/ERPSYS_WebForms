using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using ERPSYS.Helpers;
using ERPSYS.Members;

namespace ERPSYS.ERP.monitor
{
    public partial class ActiveSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private DataTable ActiveSessionTable(string tableName = "")
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add(new DataColumn("SessionStart", typeof(string)));
            dt.Columns.Add(new DataColumn("SessionRenew", typeof(string)));
            dt.Columns.Add(new DataColumn("UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("DisplayName", typeof(string)));
            dt.Columns.Add(new DataColumn("IPAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("MacAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("RoleName", typeof(string)));

            return dt;
        }

        private DataTable GetActiveSession()
        {
            DataTable dt = ActiveSessionTable();

            object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
            var fieldInfo = obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                object[] obj2 = (object[])fieldInfo.GetValue(obj);
                for (int i = 0; i <= obj2.Length - 1; i++)
                {
                    var info = obj2[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (info != null)
                    {
                        Hashtable c2 = (Hashtable)info.GetValue(obj2[i]);
                        foreach (DictionaryEntry entry in c2)
                        {
                            object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
                            if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
                            {
                                var field = o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance);
                                if (field != null)
                                {
                                    SessionStateItemCollection sess = (SessionStateItemCollection)field.GetValue(o1);
                                    if (sess != null)
                                    {
                                        if (sess["UserSessionData"] != null)
                                        {
                                            var dr = dt.NewRow();

                                            dr["SessionStart"] = ((SessionValues)sess["UserSessionData"]).UserName;
                                            dr["SessionRenew"] = sess["SessionRenew"];
                                            dr["UserName"] = ((SessionValues)sess["UserSessionData"]).UserName;
                                            dr["DisplayName"] = ((SessionValues)sess["UserSessionData"]).DisplayName;
                                            dr["IPAddress"] = ((SessionValues)sess["UserSessionData"]).UserName;
                                            dr["MacAddress"] = ((SessionValues)sess["UserSessionData"]).UserName;
                                            dr["RoleName"] = ((SessionValues)sess["UserSessionData"]).Role;

                                            dt.Rows.Add(dr);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return dt;
        }

        public int CalculateLoggedinUserForLocal()
        {
            int loggedinUserCount = 0;

            object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);

            var fieldInfo = obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                object[] obj2 = (object[])fieldInfo.GetValue(obj);

                loggedinUserCount += (from t in obj2 let field = t.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance) where field != null select (Hashtable)field.GetValue(t) into c2 select (from DictionaryEntry entry in c2 select entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null) into o1 where o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState" let info = o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance) where info != null select (SessionStateItemCollection)info.GetValue(o1) into sess where sess != null select sess).Count(sess => sess["User"] != null)).Sum();
            }
            return loggedinUserCount;
        }

        public int CalculateLoggedinUserForServer()
        {
            int loggedinUserCount = 0;

            object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);

            var fieldInfo = obj.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                Hashtable c2 = (Hashtable)fieldInfo.GetValue(obj);

                loggedinUserCount += (from DictionaryEntry entry in c2 select entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null) into o1 where o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState" let field = o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance) where field != null select (SessionStateItemCollection)field.GetValue(o1) into sess where sess != null select sess).Count(sess => sess["User"] != null);
            }
            return loggedinUserCount;
        }

        protected void BindData()
        {
            if (IsLocalIpAddress(HttpContext.Current.Request.UserHostAddress))
            {
                lblOnlineUserCount.Text = CalculateLoggedinUserForLocal().ToString();
                rgActiveSession.DataSource = GetActiveSession();
                rgActiveSession.DataBind();
            }
            else
            {
                lblOnlineUserCount.Text = CalculateLoggedinUserForServer().ToString();
                rgActiveSession.DataSource = GetActiveSession();
                rgActiveSession.DataBind();
            }
        }

        public bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIp in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIp)) return true;
                    // is local address
                    if (localIPs.Contains(hostIp))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // ignored
            }
            return false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}