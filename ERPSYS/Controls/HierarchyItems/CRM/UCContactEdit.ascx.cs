using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ERPSYS.Helpers.Ext;
using System.Web.UI.WebControls;

namespace ERPSYS.Controls.HierarchyItems.CRM
{
    public partial class UCContactEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLookupContactTypeTables();
            }
        }
        protected void GetLookupContactTypeTables()
        {
            LookupBLL lookup = new LookupBLL();

            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "ContactTypeId";
            ddlType.DataSource = lookup.ContactType();
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("-- Select Unit --", "-1"));
        }

        //************************************** Properties ************************************//
        public int ContactTypeId
        {
            get { return ddlType.Text.ToInt(); }
        }
        public string Name
        {
            get { return txtContactName.Text.ToTrimString(); }
        }
        public string NameTitle
        {
            get { return ddlNameTitle.SelectedValue.ToString(); }
        }
        public string JobTitle
        {
            get { return txtJobTitle.Text.ToTrimString(); }
        }
        public string City
        {
            get { return txtCity.Text.ToTrimString(); }
        }
        public string Country
        {
            get { return txtCountry.Text.ToTrimString(); }
        }
        public string Address
        {
            get { return txtAddress.Text.ToTrimString(); }
        }
        public string PostalCode
        {
            get { return txtPostalCode.Text.ToTrimString(); }
        }
        public string Phone
        {
            get { return txtPhone.Text.ToTrimString(); }
        }
        public string Mobile
        {
            get { return txtMobile.Text.ToTrimString(); }
        }
        public string Fax
        {
            get { return txtFax.Text.ToTrimString(); }
        }
        public string Email1
        {
            get { return txtEmail1.Text.ToTrimString(); }
        }
        public string Email2
        {
            get { return txtEmail2.Text.ToTrimString(); }
        }
        public string Remarks
        {
            get { return txtRemarks.Text.ToTrimString(); }
        }
        public bool IsActive
        {
            get { return cbIsActive.Checked; }
        }
    }
}