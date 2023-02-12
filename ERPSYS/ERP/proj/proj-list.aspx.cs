using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;

namespace ERPSYS.ERP.proj
{
    public partial class ProjList : System.Web.UI.Page
    {
        readonly ProjBLL _proj = new ProjBLL();
        private readonly SystemBLL _system = new SystemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetLookupTables();

                /////-----------------Start Test --------------//
                
                //_system.GetPageList();

                /////----------------- End Test --------------//
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("proj_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("proj_add_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlProjectStatus.DataTextField = "Name";
            ddlProjectStatus.DataValueField = "ProjectStatusId";
            ddlProjectStatus.DataSource = lookup.GetProjectStatus();
            ddlProjectStatus.DataBind();
            ddlProjectStatus.Items.Insert(0, new ListItem("-- All --", "-1"));
        }

        private void BindData()
        {
            rgProjectList.Rebind();
        }

        protected void rgProjectList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgProjectList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetProjectList();
        }

        private void GetProjectList()
        {
            try
            {
                rgProjectList.DataSource = _proj.GetProjectList(DateStart, DateEnd, ProjectName, ProjectStatusId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateStart = UCDateRange.StartDate;
                DateEnd = UCDateRange.EndDate;
                ProjectName = txtProjectName.Text.ToTrimString();
                ProjectStatusId = ddlProjectStatus.SelectedValue.ToInt();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("proj-create.aspx", false);
        }

        protected void rgProjectList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                Image imgStatus = (Image)dataItem.FindControl("imgStatus");
                int statusId = dataItem["StatusId"].Text.ToInt();

                switch (statusId)
                {
                    case 1: //Open
                        imgStatus.ImageUrl = "../resources/images/status/open.png";
                        break;
                    case 2: //Close
                        imgStatus.ImageUrl = "../resources/images/status/close.png";
                        break;
                }
            }
        }

        //************************************** Properties ************************************//
        public DateTime DateStart
        {
            get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : "1/1/1900".ToDate(); }
            set { ViewState["DateStart"] = value; }
        }

        public DateTime DateEnd
        {
            get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : "1/1/2900".ToDate(); }
            set { ViewState["DateEnd"] = value; }
        }

        public string ProjectName
        {
            get { return ViewState["ProjectName"] != null ? ViewState["ProjectName"].ToString() : ""; }
            set { ViewState["ProjectName"] = value; }
        }

        public int ProjectStatusId
        {
            get { return ViewState["ProjectStatusId"] != null ? ViewState["ProjectStatusId"].ToInt() : -1; }
            set { ViewState["ProjectStatusId"] = value; }
        }
    }
}