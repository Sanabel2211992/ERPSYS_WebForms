using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;
using ERPSYS.Members;


namespace ERPSYS.ERP.settings
{
    public partial class CurrencyList : System.Web.UI.Page
    {
        readonly CurrencyBLL _currency = new CurrencyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                        AppNotification.MessageBoxFailed(GeneralResources.GetStringFromResources("currency_id_not_exist"));
                        break;
                }
                switch (Request.QueryString["o"])
                {
                    case "1":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("currency_add_success"));
                        break;
                    case "2":
                        AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("currency_update_success"));
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
            rgCurrencyList.Rebind();
        }
        protected void rgCurrencyList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void rgCurrencyList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            GetCurrencyList();
        }
        private void GetCurrencyList()
        {
            try
            {
                rgCurrencyList.DataSource = _currency.GetCurrencyList(Code);
            }
            catch(Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Code = txtCurrencyCode.Text.ToTrimString();

                BindData();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("currency-form.aspx");

        }
        //************************************** Properties ************************************//
        public string Code
        {
            get { return ViewState["Code"] != null ? ViewState["Code"].ToString() : ""; }
            set { ViewState["Code"] = value; }
        }
    }
}