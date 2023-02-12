using System;
using ERPSYS.Helpers.Ext;

namespace ERPSYS.Controls.HierarchyItems.SM.JobOrder
{
    public partial class UCMainItemEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Type == "Single")
            {
                pnlSingle.Visible = true;
                pnlGroup.Visible = false;

            }
            else if (Type == "Group")
            {
                pnlSingle.Visible = false;
                pnlGroup.Visible = true;
            }
        }

        //************************************** Properties ************************************//

        private string Type
        {
            get { return hfItemID.Value.ToInteger() == -1 ? "Group" : "Single"; }
        }

        public int ItemId
        {
            get { return hfItemID.Value.ToInteger(); }
        }

        public string DescriptionAs
        {
            get { return Type == "Single" ? txtsMainItemDescription.Text.ToTrimString() : txtgMainItemDescription.Text.ToTrimString(); }
        }

        public decimal Quantity
        {
            get { return Type == "Single" ? txtsMainItemQuantity.Text.ToDecimal() : txtgMainItemQuantity.Text.ToDecimal(2); }
        }

        public object DataItem { get; set; }
    }
}