using System;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.DialogBox.Common
{
    public partial class CustomerSearch : System.Web.UI.Page
    {
        readonly CustomerBLL _customer = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetData()
        {
            try
            {
                rgCustomer.DataSource = _customer.GetCustomerListDialog(Name);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void BindData()
        {
            rgCustomer.Rebind();
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

        protected void rgCustomer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
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