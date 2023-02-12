using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.MAN.Assembly
{
    public partial class UCMaterialEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //************************************** Properties ************************************//

        public int ItemBomId
        {
            get { return hfItemBomID.Value.ToInteger(); }
        }

        public decimal Quantity
        {
            get { return txtItemQuantity.Text.ToDecimal(3); }
        }

        public object DataItem { get; set; }
    }
}