using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.PROJ
{
    public partial class UCEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //************************************** Properties ************************************//

        public decimal Amount
        {
            get { return txtAmount.Text.ToDecimal(); }
        }

        public string Description
        {
            get { return txtDescription.Text.ToTrimString(); }
        }
    }
}