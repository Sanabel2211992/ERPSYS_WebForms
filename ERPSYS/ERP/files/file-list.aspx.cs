using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using System;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI;
using System.Drawing;

namespace ERPSYS.ERP.files
{
    public partial class FileList : System.Web.UI.Page
    {
        readonly FilesBLL _file = new FilesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("file_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("file_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("file_add_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("file_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgFileList.Rebind();
        }

        protected void rgFile_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
            rgFileList.Columns.FindByUniqueName("DBColumn").Visible = _file.SaveFileDataDb;
        }

        protected void rgFile_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            GetFilesList();
        }

        private void GetFilesList()
        {
            try
            {
                rgFileList.DataSource = _file.GetAttachmentFilesList(Description);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void DownloadFileDisk(object sender, EventArgs e)
        {
            try
            {
                var lnkbtnDownloadDisk = sender as LinkButton;
                if (lnkbtnDownloadDisk != null)
                {
                    FileHandle fileHandle = new FileHandle();

                    int fileId = lnkbtnDownloadDisk.CommandArgument.ToInt();
                    fileHandle.OpenFileFromDisk(fileId);
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void DownloadFileDb(object sender, EventArgs e)
        {
        //    try
        //    {
        //        var lnkbtnDownloadDb = sender as LinkButton;
        //        if (lnkbtnDownloadDb != null)
        //        {
        //            FileHandle fileHandle = new FileHandle();

        //            int fileId = lnkbtnDownloadDb.CommandArgument.ToInt();
        //            fileHandle.OpenFileFromDatabase(fileId);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Description = txtDescription.Text.ToTrimString();
                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("file-form.aspx");
        }

      //************************************** Properties ************************************//
        public string Description
        {
            get { return ViewState["Description"] != null ? ViewState["Description"].ToString() : ""; }
            set { ViewState["Description"] = value; }
        }
    }
}