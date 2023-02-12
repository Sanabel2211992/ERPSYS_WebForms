using ERPSYS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using ERPSYS.BLL;
using ERPSYS.Helpers;
using Telerik.Web.UI;

namespace ERPSYS.ERP.t
{
    public partial class Add_Catalog : System.Web.UI.UserControl
    {
        readonly ItemBLL _item = new ItemBLL();
        public event ClickEventHandler FinishClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ItemCatAdd()
        {
            ItemCategory category = new ItemCategory();

            category.Name = txtName.Text.ToTrimString();
            //category.Code = txtCode.Text.ToTrimString();
            //category.IsActive = cbIsActive.Checked.ToBool();

            string rMessage;
            _item.AddCategory(category, out rMessage);

            txtName.Text = string.Empty;
            //txtCode.Text = string.Empty;


            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCatAdd();
              FinishButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            if (FinishClicked != null)
            {
                FinishClicked(sender, e);
            }
        }
       
    }
}