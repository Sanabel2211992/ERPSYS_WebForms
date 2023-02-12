using System;
using System.Threading;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class PageForm : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                GetItemLookupTables();

                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetPageDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlPageCategory.DataTextField = "Name";
            ddlPageCategory.DataValueField = "PageCategoryId";
            ddlPageCategory.DataSource = lookup.GetPageCategory();
            ddlPageCategory.DataBind();
            ddlPageCategory.Items.Insert(0, new ListItem("-- Select One --", "-1"));

            rblAccessType.DataTextField = "DisplayName";
            rblAccessType.DataValueField = "AccessTypeId";
            rblAccessType.DataSource = lookup.GetPageAccessType();
            rblAccessType.DataBind();

            rblAccessType.SelectedIndex = 1;
        }

        protected void GetPageDetails(int pageId)
        {
            SysPageFrom page = _setting.GetPage(pageId);

            if (page.PageId <= 0)
            {
                Response.Redirect(string.Format("page-list.aspx?e={0}", 1));
            }

            PageId = page.PageId;
            txtPageName.Text = page.Name;
            txtDisplayName.Text = page.DisplayName;
            txtDescription.Text = page.Description;
            ddlPageCategory.SelectedValue = page.CategoryId.ToString();
            cblstOperation.Items[0].Selected = page.ViewOnly;
            cblstOperation.Items[1].Selected = page.HasInsertOperation;
            cblstOperation.Items[2].Selected = page.HasUpdateOperation;
            cblstOperation.Items[3].Selected = page.HasDeleteOperation;
            cbIsActive.Checked = page.IsActive;
            rblAccessType.SelectedValue = page.AccessTypeId.ToString();
        }

        protected void AddPage()
        {
            SysPageFrom page = new SysPageFrom();

            page.Name = txtPageName.Text.ToTrimString();
            page.DisplayName = txtDisplayName.Text.ToTrimString();
            page.Description = txtDescription.Text.ToTrimString();
            page.CategoryId = ddlPageCategory.SelectedValue.ToInt();
            page.ViewOnly = cblstOperation.Items[0].Selected;
            page.HasInsertOperation = cblstOperation.Items[1].Selected;
            page.HasUpdateOperation = cblstOperation.Items[2].Selected;
            page.HasDeleteOperation = cblstOperation.Items[3].Selected;
            page.IsActive = cbIsActive.Checked;
            page.AccessTypeId = rblAccessType.SelectedValue.ToInt(); ;

            string rMessage;
            int pageId = _setting.AddPage(page, out rMessage);

            if (rMessage != string.Empty || pageId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            ApplicationSettings.ResetSystemPages();

            Response.Redirect(string.Format("page-list.aspx?o={0}", 1), false);
        }

        protected void UpdatePage()
        {
            SysPageFrom page = new SysPageFrom();

            page.PageId = PageId;
            page.Name = txtPageName.Text.ToTrimString();
            page.DisplayName = txtDisplayName.Text.ToTrimString();
            page.Description = txtDescription.Text.ToTrimString();
            page.CategoryId = ddlPageCategory.SelectedValue.ToInt();
            page.ViewOnly = cblstOperation.Items[0].Selected;
            page.HasInsertOperation = cblstOperation.Items[1].Selected;
            page.HasUpdateOperation = cblstOperation.Items[2].Selected;
            page.HasDeleteOperation = cblstOperation.Items[3].Selected;
            page.IsActive = cbIsActive.Checked;
            page.AccessTypeId = rblAccessType.SelectedValue.ToInt(); ;

            string rMessage;
            _setting.UpdatePage(page, out rMessage);

            if (rMessage != string.Empty || PageId <= 0)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            ApplicationSettings.ResetSystemPages();

            Response.Redirect(string.Format("page-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddPage();
                }
                else if (Operation == "edit" && PageId > 0)
                {
                    UpdatePage();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("page-list.aspx"), false);
        }

        //************************************** Properties ************************************//

        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }

        public int PageId
        {
            get { return ViewState["PageId"] != null ? ViewState["PageId"].ToInt() : -1; }
            set { ViewState["PageId"] = value; }
        }
    }
}