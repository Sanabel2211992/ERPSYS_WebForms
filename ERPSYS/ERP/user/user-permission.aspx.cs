using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;
using System.Threading;

namespace ERPSYS.ERP.user
{
    public partial class UserPermission : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLookupTables();
                BindData();
            }
        }

        protected void GetLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlGroupPermission.DataTextField = "Name";
            ddlGroupPermission.DataValueField = "GroupId";
            ddlGroupPermission.DataSource = lookup.GetGroupPermission();
            ddlGroupPermission.DataBind();
            ddlGroupPermission.Items.Insert(0, new ListItem("--Custom --", "-1"));
        }

        private void BindData()
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                GetPages();
                GetUserDetails(Request.QueryString["id"].ToInt());
            }
        }

        private void GetPages()
        {
            try
            {
                cblPageNames.DataTextField = "FullPageDescription";
                cblPageNames.DataValueField = "PageId";

                cblPageNames.DataSource = _setting.GetPageDetailsList();
                cblPageNames.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetUserDetails(int userId)
        {
            UserAccount userAccount = _user.GetUser(userId);

            if (userAccount.UserId <= 0)
            {
                Response.Redirect(string.Format("user-list.aspx?e={0}", 1));
            }

            UserId = userId;
            lblDisplayName.Text = userAccount.DisplayName;
            lblUserName.Text = userAccount.UserName;
            lblUserTitle.Text = userAccount.UserTitle;
            cbViewCost.Checked = userAccount.HasCostView;
            string autorizePages = userAccount.AuthorizePages;

            foreach (ListItem item in cblPageNames.Items)
            {
                item.Selected = IsAuthorize(item.Value.ToInt(), autorizePages);
            } 
        }

        private  bool IsAuthorize(int pageId, string pageIds)
        {
            ArrayList alPageIDs = new ArrayList();
            alPageIDs.AddRange(pageIds.Split(Convert.ToChar(",")));

            return alPageIDs.Contains(pageId.ToString());
        }

        protected void ddlGroupPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int groupId = ddlGroupPermission.SelectedValue.ToInt();

                if (groupId > 0)
                {
                    GetPermissionGroup(groupId);
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void GetPermissionGroup(int groupId)
        {
            GroupPermission permission = _setting.GetGroupPermission(groupId);

            cbViewCost.Checked = permission.HasCostView;
            string autorizePages = permission.AuthorizePages;

            foreach (ListItem item in cblPageNames.Items)
            {
                item.Selected = IsAuthorize(item.Value.ToInt(), autorizePages);
            }
        }

        private void UpdateUserPermission()
        {
            try
            {
                var autorizePages = cblPageNames.Items.Cast<ListItem>().Where(item => item.Selected).Aggregate(string.Empty, (current, item) => current + (item.Value + ","));         
                if (autorizePages != "") autorizePages = autorizePages.Remove(autorizePages.Length - 1, 1);

                var userAccount = new UserAccount() ;

                userAccount.UserId = UserId;
                userAccount.AuthorizePages = autorizePages;
                userAccount.HasCostView = cbViewCost.Checked;

                string rMessage;
                _user.UpdateUserPermission(userAccount, out rMessage);

                if (rMessage != string.Empty || UserId <= 0)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                Response.Redirect(string.Format("user-list.aspx?o={0}", 3));

            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in cblPageNames.Items)
            {
                item.Selected = true;
            } 
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in cblPageNames.Items)
            {
                item.Selected = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateUserPermission();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("user-list.aspx"));
        }

        //************************************** Properties ************************************//

        public int UserId
        {
            get { return ViewState["UserId"] != null ? ViewState["UserId"].ToInt() : -1; }
            set { ViewState["UserId"] = value; }
        }
    }
}