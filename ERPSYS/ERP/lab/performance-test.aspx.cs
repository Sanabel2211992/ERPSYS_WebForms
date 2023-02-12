using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.ERP.lab
{
    public partial class PerformanceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //SystemBLL system = new SystemBLL();
            //object o = system.GetSystemPages();

            stopwatch.Stop();
            Label1.Text = stopwatch.Elapsed.TotalMilliseconds.ToString();

            long size = 0;

            //using (Stream s = new MemoryStream())
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(s, o);
            //    size = s.Length;
            //}

            //Label3.Text = size.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //SettingsBLL setting = new SettingsBLL();
            //object o = setting.GetSystemPageList();

            stopwatch.Stop();
            Label2.Text = stopwatch.Elapsed.TotalMilliseconds.ToString();

            //long size = 0;
            //using (Stream s = new MemoryStream())
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(s, o);
            //    size = s.Length;
            //}

            //Label4.Text = size.ToString();
        }

        protected void btntxtRoundUp_Click(object sender, EventArgs e)
        {
            //lbltxtRoundUp.Text = txtRoundUp.Text.RoundUp().ToString();
        }
    }
}