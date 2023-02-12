using System;
using System.Data;
using ERPSYS.BLL;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.Controls.ComboBox
{
    public partial class UCSupplierListAdvanced : System.Web.UI.UserControl
    {
        readonly SupplierBLL _supplier = new SupplierBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rcbSupplier_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            DataTable dtSupplierList = _supplier.GetSupplierSearchBox(e.Text);

            foreach (DataRow dataRow in dtSupplierList.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();

                item.Text = (string)dataRow["Name"];
                item.Value = dataRow["SupplierId"].ToString();
                string country = dataRow["Country"].ToString();
                item.Attributes.Add("Country", country);
                rcbSupplier.Items.Add(item);
                item.DataBind();
            }
        }

        protected void rcbSupplier_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int supplierId = e.Value.ToInt();
            if ((e.OldText != e.Text) && (supplierId > 0))
            {
                Members.Supplier supplier = _supplier.GetSupplier(supplierId);
                txtContactName.Text = supplier.ContactName;
                txtPhone.Text = supplier.Phone;
                txtAddress.Text = supplier.Address1;
            }
        }

        protected void cvSupplier_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rcbSupplier.SelectedValue.ToInt() <= 0)
            {
                args.IsValid = false;
            }
        }

        //************************************** Properties ************************************//

        public string ValidationGroup
        {
            set
            {
                rfvSupplier.ValidationGroup = value;
                cvSupplier.ValidationGroup = value;
            }
        }

        public bool CausesValidation
        {
            set { rfvSupplier.Enabled = value; }
        }

        public int SupplierId
        {
            get { return rcbSupplier.SelectedValue.ToInt(); }
            set { rcbSupplier.SelectedValue = value.ToString(); }
        }

        public string SupplierName
        {
            get { return rcbSupplier.Text; }
            set { rcbSupplier.Text = value; }
        }

        public string ContactName
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }
    }
}