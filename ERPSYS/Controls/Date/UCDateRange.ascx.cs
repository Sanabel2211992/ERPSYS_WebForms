using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.Date
{
    public partial class UCDateRange : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDateFrom.Attributes.Add("readonly", "readonly");
            txtDateTo.Attributes.Add("readonly", "readonly");

            //txtDateFrom.Text = Request.Form[txtDateFrom.UniqueID];
            //txtDateTo.Text = Request.Form[txtDateTo.UniqueID];
        }

        public void ResetDate()
        {
            txtDateFrom.Text = string.Empty;
            txtDateTo.Text = string.Empty;
        }

        public DateTime StartDate
        {
            get { return (txtDateFrom.Text == string.Empty ? DateTime.Now.AddYears(-100) : txtDateFrom.Text.ToDate()); }
            set { txtDateFrom.Text = value.ToShortDateString(); }
        }

        public DateTime EndDate
        {
            get { return txtDateTo.Text == string.Empty ? DateTime.Now.AddYears(100) : (txtDateTo.Text.ToDate()); }
            set { txtDateTo.Text = value.ToShortDateString(); }

        }
    }
}