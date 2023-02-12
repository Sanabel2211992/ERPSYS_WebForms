using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.settings
{
    public partial class UnitOfMeasureList : System.Web.UI.Page
    {
        readonly SettingsBLL _setting = new SettingsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            try
            {
                switch (Request.QueryString["e"])
                {
                    case "1":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("uom_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("uom_delete_failed"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("uom_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("uom_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("uom_delete_success"));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        private void BindData()
        {
            rgUnitMeasure.Rebind();
        }

        protected void rgUnitList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgUnitList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetUnitOfMeasureList();
        }

        private void GetUnitOfMeasureList()
        {
            try
            {
                rgUnitMeasure.DataSource = _setting.GetUnitOfMeasureList(UomName);
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
                UomName = txtUnitName.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("uom-details.aspx", false);
        }    
   
        //************************************** Properties ************************************//
        public string UomName
        {
            get { return ViewState["UomName"] != null ? ViewState["UomName"].ToString() : ""; }
            set { ViewState["UomName"] = value; }
        }
    }
}