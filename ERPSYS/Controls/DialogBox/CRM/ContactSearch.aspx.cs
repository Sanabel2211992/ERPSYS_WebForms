using System;
using System.Collections.Generic;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.Controls.DialogBox.CRM
{
    public partial class ContactSearch : System.Web.UI.Page
    {
        readonly CRMBLL _contact = new CRMBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientId = Request.QueryString["id"].ToInt();
            }
        }

        protected void GetData()
        {
            try
            {
                rgContact.DataSource = _contact.GetContactList(ClientId, Name);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void BindData()
        {
            rgContact.Rebind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Name = txtName.Text.ToTrimString();
                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgContact_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GetData();
        }

        //************************************** Properties ************************************//

        public int ClientId
        {
            get { return ViewState["ClientId"] != null ? ViewState["ClientId"].ToInt() : -1; }
            set { ViewState["ClientId"] = value; }
        }

        public string Name
        {
            get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
            set { ViewState["Name"] = value; }
        }
    }
}