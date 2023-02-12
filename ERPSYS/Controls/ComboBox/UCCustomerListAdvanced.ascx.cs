using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.ComboBox
{
    public partial class UCCustomerListAdvanced : System.Web.UI.UserControl
    {
        readonly CustomerBLL _customer = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // to delete this control
        protected void rcbCustomer_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dtCustomerList = _customer.GetCustomerAdvancedSearchBox(e.Text);

            foreach (DataRow dataRow in dtCustomerList.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["Name"];
                item.Value = dataRow["CustomerId"].ToString();
                string country = dataRow["Country"].ToString();
                item.Attributes.Add("Country", country);
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
                rfvCustomer.ValidationGroup = value;
                cvCustomer.ValidationGroup = value;
            }
        }

        public bool CausesValidation
        {
            set { rfvCustomer.Enabled = value; }
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