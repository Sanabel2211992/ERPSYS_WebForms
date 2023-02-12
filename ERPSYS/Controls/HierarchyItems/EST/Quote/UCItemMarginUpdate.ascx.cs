using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.EST.Quote
{
    public partial class UCItemMarginUpdate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeComponent();
            }
        }

        protected void InitializeComponent()
        {
            txtItemProfit.Text = "0".ToDecimalFormat();
            txtItemDiscount.Text = "0".ToDecimalFormat();
        }

        public void ClearFields()
        {
            txtItemProfit.Text = "0".ToDecimalFormat();
            txtItemDiscount.Text = "0".ToDecimalFormat();
        }

        //************************************** Properties ************************************//

        public string ValidationGroup
        {
            set
            {
                rfvItemProfit.ValidationGroup = value;
                cvItemProfit1.ValidationGroup = value;
                cvItemProfit2.ValidationGroup = value;
                rfvItemDiscount.ValidationGroup = value;
                cvItemDiscount1.ValidationGroup = value;
                cvItemDiscount2.ValidationGroup = value;
            }
        }

        public decimal Profit
        {
            get { return txtItemProfit.Text.ToDecimal(); }
        }

        public decimal Discount
        {
            get { return txtItemDiscount.Text.ToDecimal(); }
        }

        public bool IsPercentDiscount
        {
            get { return true; }
        }
    }
}