using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.ComboBox
{
    public partial class UCCustomerList : System.Web.UI.UserControl
    {
        readonly CustomerBLL _customer = new CustomerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rcbCustomer.DataSource = _customer.GetCustomerSearchBox("");
                rcbCustomer.DataBind();
            }
        }

        //************************************** Properties ************************************//

        public string ValidationGroup
        {
            set
            {
                rfvCustomer.ValidationGroup = value;
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