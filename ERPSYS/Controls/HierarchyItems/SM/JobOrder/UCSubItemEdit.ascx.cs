using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SM.JobOrder
{
    public partial class UCSubItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //************************************** Properties ************************************//

        public string DescriptionAs
        {
            get { return txtItemDescriptionAs.Text.ToTrimString(); }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(); }
        }

        public object DataItem { get; set; }
    }
}