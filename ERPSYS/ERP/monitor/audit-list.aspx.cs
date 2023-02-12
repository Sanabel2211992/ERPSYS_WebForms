using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Helpers.Ext;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.monitor
{
    public partial class audit_list : System.Web.UI.Page
    {
        //readonly AuditBLL _audit = new AuditBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    ShowMessages();
            //    GetLookupTables();
            //}
        }

        //protected void GetLookupTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlUsersNames.DataTextField = "DisplayName";
        //    ddlUsersNames.DataValueField = "UserId";
        //    ddlUsersNames.DataSource = lookup.GetUsersList();
        //    ddlUsersNames.DataBind();
        //    ddlUsersNames.Items.Insert(0, new ListItem("-- All --", "-1"));
        //}
        //private void ShowMessages()
        //{
        //    try
        //    {
        //        switch (Request.QueryString["e"])
        //        {
        //            case "1":
        //                AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("audit_id_not_exist"));
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //private void BindData()
        //{
        //    rgAudit.Rebind();
        //}

        //protected void rgAudit_Init(object sender, EventArgs e)
        //{
        //    var grid = (RadGrid)sender;
        //    grid.PageSize = CommonMember.GridPageSize;
        //}

        //protected void rgAudit_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    GetAuditList();
        //}

        //private void GetAuditList()
        //{
        //    try
        //    {
        //        rgAudit.DataSource = _audit.GetAuditList(DateStart, DateEnd, Action, AuditType, UserId);
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DateStart = UCDateRange.StartDate;
        //        DateEnd = UCDateRange.EndDate;
        //        Action = txtAction.Text.ToTrimString();
        //        AuditType = ddlAuditType.SelectedValue.ToString();
        //        UserId = ddlUsersNames.SelectedValue.ToInt();

        //        BindData();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}
        ////************************************** Properties ************************************//

        //public DateTime DateStart
        //{
        //    get { return ViewState["DateStart"] != null ? ViewState["DateStart"].ToDate() : "1/1/1900".ToDate(); }
        //    set { ViewState["DateStart"] = value; }
        //}

        //public DateTime DateEnd
        //{
        //    get { return ViewState["DateEnd"] != null ? ViewState["DateEnd"].ToDate() : "1/1/2900".ToDate(); }
        //    set { ViewState["DateEnd"] = value; }
        //}

        //public string Action
        //{
        //    get { return ViewState["Action"] != null ? ViewState["Action"].ToString() : ""; }
        //    set { ViewState["Action"] = value; }
        //}

        //public string AuditType
        //{
        //    get { return ViewState["AuditType"] != null ? ViewState["AuditType"].ToString() : "-1"; }
        //    set { ViewState["AuditType"] = value; }
        //}

        //public int UserId
        //{
        //    get { return ViewState["UserId"] != null ? ViewState["UserId"].ToInt() : -1; }
        //    set { ViewState["UserId"] = value; }
        //}
    }
}