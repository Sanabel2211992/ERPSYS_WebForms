using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.MAN.Production
{
    public partial class UCItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }


        public decimal Quantity
        {
            get { return txtQuantity.Text.ToInt(); }
        }

        public object DataItem { get; set; }
    }
}