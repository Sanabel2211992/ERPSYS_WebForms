using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;

namespace ERPSYS.ERP.item
{
    public partial class BrandList : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("brand_id_not_exist"));
                        break;
                    case "4":
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("brand_delete_failed"));
                        break;
                    
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("brand_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("brand_update_success"));
                        break;
                    case "3":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("brand_delete_success"));
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
            rgBrandList.Rebind();
        }
        protected void rgBrandList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgBrandList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetBrandList();
        }
        private void GetBrandList()
        {
            try
            {
                rgBrandList.DataSource = _item.GetBrandList(BrandName);
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
                BrandName = txtBrandName.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("brand-form.aspx");

        }
        //************************************** Properties ************************************//
        public string BrandName
        {
            get { return ViewState["BrandName"] != null ? ViewState["BrandName"].ToString() : ""; }
            set { ViewState["BrandName"] = value; }
        }
    }
}