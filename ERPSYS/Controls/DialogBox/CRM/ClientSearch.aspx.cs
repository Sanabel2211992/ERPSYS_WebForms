using System;
using System.Collections.Generic;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using ERPSYS.Helpers;

namespace ERPSYS.Controls.DialogBox.CRM
{
    public partial class ClientSearch : System.Web.UI.Page
    {
        readonly CRMBLL _client = new CRMBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetData()
        {
            try
            {
                rgClient.DataSource = _client.GetClientList(Name);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void BindData()
        {
            rgClient.Rebind();
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

        protected void rgClient_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GetData();
        }

      //************************************** Properties ************************************//
        public string Name
        {
            get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
            set { ViewState["Name"] = value; }
        }
    }
}