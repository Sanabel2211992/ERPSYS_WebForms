using System;

namespace ERPSYS.Controls.Date
{
    public partial class UCDatesRangeHor : System.Web.UI.UserControl
    {
        int _daysPeriod = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //calendarButtonExtender.Format = SystemDateFormat;
            //calendarButtonExtender2.Format = SystemDateFormat;

            txtDateFrom.Text = Request.Form[txtDateFrom.UniqueID];
            txtDateTo.Text = Request.Form[txtDateTo.UniqueID];
        }

        public int DaysPeriod
        {
            set { _daysPeriod = value; }
        }

        public void CheckRequiredDate()
        {
            //If txtDateFrom.Text = String.Empty Or txtDateTo.Text = String.Empty Then
            if(txtDateFrom.Text == string.Empty)
            {
                throw new Exception("You should select a valid Date Period");
            }
        }

        public string GetDateFrom
        {
            get { return (txtDateFrom.Text == string.Empty ? System.DateTime.Now.AddDays(-_daysPeriod).ToString("") : txtDateFrom.Text); }
        }

        public string GetDateTo
        {
            get
            {
                if(txtDateFrom.Text == string.Empty)
                {
                    return System.DateTime.Now.ToString("");
                }
                else
                {
                    return (txtDateTo.Text == string.Empty ? GetDateFrom : txtDateTo.Text);
                }
            }
        }

    }
}