using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.ComboBox.SM
{
    public partial class UCCustomerList : System.Web.UI.UserControl
    {
        readonly CustomerBLL _customer = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rcbCustomer_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dtCustomerList = _customer.GetCustomerAdvancedSearchBox(e.Text);

            foreach (DataRow dataRow in dtCustomerList.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["Name"];
                item.Value = dataRow["CustomerId"].ToString();
                rcbCustomer.Items.Add(item);
                item.DataBind();
            }
        }

        protected void cvCustomer_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rcbCustomer.SelectedValue.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public string ValidationGroup
        {
            set
            {
                cvCustomer.ValidationGroup = value;
            }
        }

        public bool CausesValidation
        {
            set { cvCustomer.Enabled = value; }
        }

        public int CustomerId
        {
            get { return rcbCustomer.SelectedValue.ToInt(); }
            set { rcbCustomer.SelectedValue = value.ToString(); }
        }

        public string CustomerName
        {
            set { rcbCustomer.Text = value; }
        }
    }
}