using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class UserPermissionGroup : System.Web.UI.Page
    {
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
            try
            {
                LookupBLL lookup = new LookupBLL();

                ddlGroupPermission.DataTextField = "Name";
                ddlGroupPermission.DataValueField = "GroupId";
                ddlGroupPermission.DataSource = lookup.GetGroupPermission();
                ddlGroupPermission.DataBind();
                ddlGroupPermission.Items.Insert(0, new ListItem("--Select One--", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);             
            }
        }

        private void BindData()
        {
            GetPages();
        }

        private void GetPages()
        {
            try
            {
                SettingsBLL setting = new SettingsBLL();

                cblPageNames.DataTextField = "FullPageDescription";
                cblPageNames.DataValueField = "PageId";
                cblPageNames.DataSource = setting.GetPageDetailsList();
                cblPageNames.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
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

            GroupId = groupId;
            cbViewCost.Checked = permission.HasCostView;
            string autorizePages = permission.AuthorizePages;

            foreach (ListItem item in cblPageNames.Items)
            {
                item.Selected = IsAuthorize(item.Value.ToInt(), autorizePages);
            }
        }

        private bool IsAuthorize(int pageId, string pageIds)
        {
            ArrayList alPageIDs = new ArrayList();
            alPageIDs.AddRange(pageIds.Split(Convert.ToChar(",")));

            return alPageIDs.Contains(pageId.ToString());
        }

        private void UpdateGroupPermission()
        {
            try
            {
                var autorizePages = cblPageNames.Items.Cast<ListItem>().Where(item => item.Selected).Aggregate(string.Empty, (current, item) => current + (item.Value + ","));
                if (autorizePages != "") autorizePages = autorizePages.Remove(autorizePages.Length - 1, 1);

                GroupPermission permission = new GroupPermission();

                permission.GroupId = GroupId;
                permission.HasCostView = cbViewCost.Checked;
                permission.AuthorizePages = autorizePages;

                string rMessage;
                _setting.UpdateGroupPermission(permission, out rMessage);

                if (rMessage != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMessage);
                    return;
                }

                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("group_permission_update_success"));
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
            UpdateGroupPermission();
        }

        //************************************** Properties ************************************//

        public int GroupId
        {
            get { return ViewState["GroupId"] != null ? ViewState["GroupId"].ToInt() : -1; }
            set { ViewState["GroupId"] = value; }
        }
    }
}