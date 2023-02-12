using System;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using Telerik.Web.UI;
using System.IO;

namespace ERPSYS.ERP.user
{
    public partial class UserList : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
                GetItemLookupTables();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("user_id_not_exist"));
                        break;
                  case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("user_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_update_permission_success"));
                        break;
                    case "4":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_pass_reset_success"));
                        break;
                    case "5":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_reset_password_success"));
                        break;
                    case "6":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("user_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "DepartmentId";
            ddlDepartment.DataSource = lookup.GetDepartmentList();
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-- All --", "-1"));


            ddlLocation.DataTextField = "Name";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataSource = lookup.GetLocation();
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("-- All --", "-1"));

        }

        private void BindData()
        {
            rgUserList.Rebind();
        }

        protected void rgUserList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgUserList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetUserList();
        }

        private void GetUserList()
        {
            try
            {
                rgUserList.DataSource = _user.GetUserList(Name, DepartmentId, LocationId, StatusId);
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Name = txtName.Text.ToTrimString();
                DepartmentId = ddlDepartment.SelectedValue.ToInt();
                StatusId = ddlStatus.SelectedValue.ToInt();
                LocationId = ddlLocation.SelectedValue.ToInt();
                BindData();
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgUserList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    Image imgUser = (Image)dataItem.FindControl("imgUser");

                    if (File.Exists(Server.MapPath(CommonMember.SystemProfilePictrureSmallCachePath + dataItem["UserId"].Text + ".png")))
                    {
                        imgUser.ImageUrl = CommonMember.SystemProfilePictrureSmallCachePath + dataItem["UserId"].Text + ".png";
                    }
                    else
                    {
                        imgUser.ImageUrl = "../resources/images/default-profile-s.png";
                    }
                
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ERP/user/user-details.aspx");
        }

        //************************************** Properties ************************************//

        public string Name
        {
            get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
            set { ViewState["Name"] = value; }
        }

        public int DepartmentId
        {
            get { return ViewState["DepartmentId"] != null ? ViewState["DepartmentId"].ToInt() : -1; }
            set { ViewState["DepartmentId"] = value; }
        }

        public int LocationId
        {
            get { return ViewState["LocationId"] != null ? ViewState["LocationId"].ToInt() : -1; }
            set { ViewState["LocationId"] = value; }
        }

        public int StatusId
        {
            get { return ViewState["StatusId"] != null ? ViewState["StatusId"].ToInt() : -1; }
            set { ViewState["StatusId"] = value; }
        }
    }
}