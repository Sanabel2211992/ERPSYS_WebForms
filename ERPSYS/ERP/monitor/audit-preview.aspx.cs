using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Members;
using Telerik.Web.UI;
using ERPSYS.Helpers.Ext;
using System.Threading;

namespace ERPSYS.ERP.monitor
{
    public partial class audit_preview : System.Web.UI.Page
    {
        //readonly AuditBLL _audit = new AuditBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindData();
            //}
        }

        //private void BindData()
        //{
        //    try
        //    {
        //        if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
        //        {
        //            GetAuditLines(Request.QueryString["id"].ToInt());
        //            GetAuditHeader(Request.QueryString["id"].ToInt());
        //        }
        //        else
        //        {
        //            Response.Redirect(string.Format("audit-list.aspx?e={0}", 1));
        //        }

        //        rgAudit.Rebind();

        //    }
        //    catch (ThreadAbortException)
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}
        //protected void GetAuditHeader(int auditId)
        //{
        //    Audit auditInfo = _audit.GetAuditHeader(auditId);

        //    if (auditInfo.AuditId <= 0)
        //    {
        //        Response.Redirect(string.Format("audit-list.aspx?e={0}", 1));
        //    }

        //    AuditId = auditId;
        //    lblType.Text = auditInfo.Type.ReplaceWhenNullOrEmpty("N/A");
        //    lblTableName.Text = auditInfo.TableName.ReplaceWhenNullOrEmpty("N/A");
        //    lblAction.Text = auditInfo.Action.ReplaceWhenNullOrEmpty("N/A");
        //    lblEntity.Text = auditInfo.Entity.ReplaceWhenNullOrEmpty("N/A");
        //    lblUserName.Text = auditInfo.UserName.ReplaceWhenNullOrEmpty("N/A");
        //    lblAuditDate.Text = auditInfo.EntryDate.ReplaceDateWhenNullOrEmpty("N/A");
        //}

        //protected void rgAudit_Init(object sender, EventArgs e)
        //{
        //    var grid = (RadGrid)sender;
        //    grid.PageSize = CommonMember.GridPageSize;
        //}

        //protected void rgAudit_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    GetAuditLines(AuditId);
        //}

        //private void GetAuditLines(int auditId)
        //{
        //    try
        //    {
        //        rgAudit.DataSource = _audit.GetAuditLine(auditId);
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
        //        BindData();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}
        ////************************************** Properties ************************************//

        //public int AuditId
        //{
        //    get { return ViewState["AuditId"] != null ? ViewState["AuditId"].ToInt() : -1; }
        //    set { ViewState["AuditId"] = value; }
        //}
    }
}