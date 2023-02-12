using ERPSYS.BLL;
using ERPSYS.Helpers;
using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ERPSYS.Helpers.Ext;
using System.Data;
using System.Collections.Generic;
using ERPSYS.Members;
using System.Collections;
using System.Threading;
using System.Linq;

namespace ERPSYS.ERP.lab
{
    public partial class user_permission : System.Web.UI.Page
    {
        readonly UserBLL _user = new UserBLL();
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLookupTables();
                //BindData();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void GetLookupTables()
        {
            try
            {
                LookupBLL lookup = new LookupBLL();

                ddlUsersNames.DataTextField = "DisplayName";
                ddlUsersNames.DataValueField = "UserId";
                ddlUsersNames.DataSource = lookup.GetUsersList();
                ddlUsersNames.DataBind();
                ddlUsersNames.Items.Insert(0, new ListItem("-- Select One --", "-1"));

                ddlGroupPermission.DataTextField = "Name";
                ddlGroupPermission.DataValueField = "GroupId";
                ddlGroupPermission.DataSource = lookup.GetGroupPermission();
                ddlGroupPermission.DataBind();
                ddlGroupPermission.Items.Insert(0, new ListItem("-- Select One --", "-1"));

                ddlCategory.Items.Insert(0, new ListItem("Settings", "1"));//And Monitor
                //ddlCategory.Items.Insert(0, new ListItem("Products", "Product"));
                //ddlCategory.Items.Insert(0, new ListItem("Purchasing", "Purchase")); //Supplier and goods
                ddlCategory.Items.Insert(0, new ListItem("Inventory", "2"));
                ddlCategory.Items.Insert(0, new ListItem("Production", "3"));
                //ddlCategory.Items.Insert(0, new ListItem("Job Order", "JobOrder"));
                //ddlCategory.Items.Insert(0, new ListItem("Manufacturing", "Reports"));               
                //ddlCategory.Items.Insert(0, new ListItem("Projects", "Project"));
                ddlCategory.Items.Insert(0, new ListItem("Sales", "4"));
                ddlCategory.Items.Insert(0, new ListItem("Reporting", "5"));
                ddlCategory.Items.Insert(0, new ListItem("Retail", "6"));
                ddlCategory.Items.Insert(0, new ListItem("Estimation", "7"));
                ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                GetUserDetails(Request.QueryString["id"].ToInt());
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

            foreach (GridDataItem item in rgPermissionsList.MasterTableView.Items)
            {
                ((CheckBox)item.FindControl("cbPage")).Checked = IsAuthorize(item.GetDataKeyValue("PageId").ToInt(), autorizePages);
            }
        }
    
        private bool IsAuthorize(int pageId, string pageIds)
        {
            ArrayList alPageIDs = new ArrayList();
            alPageIDs.AddRange(pageIds.Split(Convert.ToChar(",")));

            return alPageIDs.Contains(pageId.ToString());
        }

        private DataTable GetPermissionPageList(int categoryId)
        {
            try
            {
                return _setting.GetPermissionPageList(categoryId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
            return null;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CategoryId = ddlCategory.SelectedValue.ToInt();

                rgPermissionsList.DataSource = GetPermissionPageList(CategoryId);
                rgPermissionsList.DataBind();

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rblstOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridDataItem item in rgPermissionsList.MasterTableView.Items)
                {
                    CheckBox cbPage = ((CheckBox)item.FindControl("cbPage"));
                    //1.View Only
                    if (rblstOperation.Items[0].Selected)
                    {
                        cbPage.Checked = item["ViewOnly"].Text.ToBool() == true && item["HasInsertOperation"].Text.ToBool() == false && item["HasUpdateOperation"].Text.ToBool() == false && item["HasDeleteOperation"].Text.ToBool() == false;
                    }
                    //2.Insert Only
                    else if (rblstOperation.Items[1].Selected)
                    {
                        cbPage.Checked = item["HasInsertOperation"].Text.ToBool() == true && item["ViewOnly"].Text.ToBool() == false && item["HasUpdateOperation"].Text.ToBool() == false && item["HasDeleteOperation"].Text.ToBool() == false;
                    }
                    //3.Update Only
                    else if (rblstOperation.Items[2].Selected)
                    {
                        cbPage.Checked = item["HasUpdateOperation"].Text.ToBool() == true && item["ViewOnly"].Text.ToBool() == false && item["HasInsertOperation"].Text.ToBool() == false && item["HasDeleteOperation"].Text.ToBool() == false;
                    }
                    //4.Update & Insert
                    if (rblstOperation.Items[3].Selected)
                    {
                        cbPage.Checked =( item["HasInsertOperation"].Text.ToBool() == true || item["HasUpdateOperation"].Text.ToBool() == true) && item["ViewOnly"].Text.ToBool() == false && item["HasDeleteOperation"].Text.ToBool() == false;
                    }
                    //5.Delete Only
                    else if (rblstOperation.Items[4].Selected)
                    {
                        cbPage.Checked = item["HasDeleteOperation"].Text.ToBool() == true && item["ViewOnly"].Text.ToBool() == false && item["HasInsertOperation"].Text.ToBool() == false && item["HasUpdateOperation"].Text.ToBool() == false;
                    }
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgPermissionsList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgPermissionsList.DataSource = GetPermissionPageList(CategoryId);
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox cbHeader = (sender as CheckBox);
            foreach (GridDataItem item in rgPermissionsList.MasterTableView.Items)
            {
                if (cbHeader != null)
                {
                    ((CheckBox)item.FindControl("cbPage")).Checked = cbHeader.Checked;
                    item.Selected = cbHeader.Checked;
                }
            }
        }

        protected void rgPermissionsList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;

                Image imgView = (Image)dataItem.FindControl("imgView");
                Image imgInsert = (Image)dataItem.FindControl("imgInsert");
                Image imgUpdate = (Image)dataItem.FindControl("imgUpdate");
                Image imgDelete = (Image)dataItem.FindControl("imgDelete");

                imgView.ImageUrl = dataItem["ViewOnly"].Text.ToBool() == true ? "~/ERP/resources/images/status/open.png" : "~/ERP/resources/images/status/refunded.png";
                imgInsert.ImageUrl = dataItem["HasInsertOperation"].Text.ToBool() == true ? "~/ERP/resources/images/status/open.png" : "~/ERP/resources/images/status/refunded.png";
                imgUpdate.ImageUrl = dataItem["HasUpdateOperation"].Text.ToBool() == true ? "~/ERP/resources/images/status/open.png" : "~/ERP/resources/images/status/refunded.png";
                imgDelete.ImageUrl = dataItem["HasDeleteOperation"].Text.ToBool() == true ? "~/ERP/resources/images/status/open.png" : "~/ERP/resources/images/status/refunded.png";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> LstItems = new List<string>();

                foreach (GridDataItem item in rgPermissionsList.Items)
                {
                    CheckBox chkBx = (CheckBox)item.FindControl("cbPage");
                    if (chkBx != null && chkBx.Checked)
                    {
                        string PageId = item["PageId"].Text;
                        LstItems.Add(PageId);
                    }
                }

                if (LstItems.Count == 0)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("no_items_selected"));
                    return;
                }

                var autorizePages = LstItems.Aggregate((i, j) => i + "," + j);

                var userAccount = new UserAccount();

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

                //Response.Redirect(string.Format("user-list.aspx?o={0}", 3));

            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnSaveFromUserPermission_Click(object sender, EventArgs e)
        {
           int userId = ddlUsersNames.SelectedValue.ToInt();


            // string rMsg;
            //_setting.CloneItemBom(UserId, String.Join(",", LstItems), BomTypeId, out rMsg);

            //if (rMsg != string.Empty)
            //{
            //    AppNotification.MessageBoxFailed(rMsg);
            //    return;
            //}
        }

        protected void btnSaveGroupPermission_Click(object sender, EventArgs e)
        {
            int groupId = ddlGroupPermission.SelectedValue.ToInt();


            // string rMsg;
            //_setting.CloneItemBom(UserId, String.Join(",", LstItems), BomTypeId, out rMsg);

            //if (rMsg != string.Empty)
            //{
            //    AppNotification.MessageBoxFailed(rMsg);
            //    return;
            //}
        }

        //************************************** Properties ************************************//

        public int UserId
        {
            get { return ViewState["UserId"] != null ? ViewState["UserId"].ToInt() : -1; }
            set { ViewState["UserId"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }
    }
}