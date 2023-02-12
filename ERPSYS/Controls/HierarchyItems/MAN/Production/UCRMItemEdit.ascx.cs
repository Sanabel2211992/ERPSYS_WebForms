using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.MAN.Production
{
    public partial class UCRMItemEdit : System.Web.UI.UserControl
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
            get { return txtItemQuantity.Text.ToDecimal(3); }
        }

        public object DataItem { get; set; }
    }
}