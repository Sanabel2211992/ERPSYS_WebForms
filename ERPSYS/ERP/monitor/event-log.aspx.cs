using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Helpers.Ext;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace ERPSYS.ERP.monitor
{
    public partial class EventLog : System.Web.UI.Page
    {
        readonly MonitorBLL _monitor = new MonitorBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeForm();
                GetLookupTables();
            }
        }

        protected void InitializeForm()
        {
            GetEventLogFile();

            UCDateRangeSys.StartDate = DateTime.Now.AddDays(-7).ToDate();
            UCDateRangeSys.EndDate = DateTime.Now.ToDate();
            UCDateRangeDB.StartDate = DateTime.Now.AddDays(-7).ToDate();
            UCDateRangeDB.EndDate = DateTime.Now.ToDate();
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlSystemLogType.DataTextField = "Level";
            ddlSystemLogType.DataValueField = "Level";
            ddlSystemLogType.DataSource = lookup.GetEventLogType();
            ddlSystemLogType.DataBind();
            ddlSystemLogType.Items.Insert(0, new ListItem("-- All --", ""));
        }

        //----- Event Log System--------//

        private void BindDataLogSystem()
        {
            rgEventLogSystem.Rebind();
        }

        protected void rgEventLogSystem_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgEventLogSystem_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEventLogSystem();
        }

        private void GetEventLogSystem()
        {
            try
            {
                rgEventLogSystem.DataSource = _monitor.GetEventLog(DateStart, DateEnd, EventLogType);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearchSystem_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRangeSys.StartDate;
                DateEnd = UCDateRangeSys.EndDate;
                EventLogType = ddlSystemLogType.SelectedValue;

                BindDataLogSystem();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //----- Event Log File--------//

        public void GetEventLogFile()
        {
            try
            {
                FileInfo[] files = new DirectoryInfo(LogFolderPath).GetFiles().OrderByDescending(f => f.CreationTime).ToArray();

                if (files.Length == 0)
                {
                    ddlLogFiles.Items.Insert(0, new ListItem("Log folder is empty", ""));
                    return;
                }

                foreach (FileInfo t in files)
                {
                    ddlLogFiles.Items.Add(t.ToString());
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = LogFolderPath + ddlLogFiles.SelectedValue;
                string content = "";

                using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    content += sr.ReadToEnd();
                }

                txtLog.Text = content;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        //----- Event Log Database--------//

        private void BindDataLogDatabase()
        {
            rgEventLogDB.Rebind();
        }

        private void GetEventLogDatabase()
        {
            try
            {
                rgEventLogDB.DataSource = _monitor.GetErrorDatabaseLog(DateStart, DateEnd);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgEventLogDB_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgEventLogDB_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetEventLogDatabase();
        }

        protected void btnSearchDB_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRangeDB.StartDate;
                DateEnd = UCDateRangeDB.EndDate;

                BindDataLogDatabase();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgEventLogSystem_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                item["Level"].ForeColor = MonitorBLL.LogColor(item["Level"].Text);
            }
        }

        //************************************** Properties ************************************//

        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : DateTime.Now.AddDays(-7).ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : DateTime.Now.ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

        private string LogFolderPath
        {
            get
            {
                var rootAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<FileAppender>().FirstOrDefault();
                return rootAppender != null ? string.Format("{0}{1}", Path.GetDirectoryName(rootAppender.File), "\\") : string.Empty;
            }
        }

        public string EventLogType
        {
            get { return ViewState["EventLogType"] != null ? ViewState["EventLogType"].ToString() : ""; }
            set { ViewState["EventLogType"] = value; }
        }
    }
}