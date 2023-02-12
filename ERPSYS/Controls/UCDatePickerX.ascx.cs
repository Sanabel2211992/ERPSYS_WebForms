using System;
using System.Globalization;
using ERPSYS.Members;

namespace ERPSYS.Controls
{
    public partial class UCDatePickerX : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                cbeDate.Format = CommonMember.DefaultDateFormat;
            }
        }

        public DateTime DateValue
        {
            get { return DateTime.ParseExact(txtDate.Text, CommonMember.DefaultDateFormat, CultureInfo.InvariantCulture); }
            set { txtDate.Text = value.ToString(CommonMember.DefaultDateFormat); }
        }

        public string ValidationGroup
        {
            set { rfvDate.ValidationGroup = value; }
        }
    }
}