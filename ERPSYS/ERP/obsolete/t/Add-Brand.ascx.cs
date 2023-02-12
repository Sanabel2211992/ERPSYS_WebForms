using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Helpers.Ext;
using ERPSYS.BLL;
using ERPSYS.Members;
using ERPSYS.Helpers;

namespace ERPSYS.ERP.t
{
    public partial class Add_Brand : System.Web.UI.UserControl
    {
        readonly ItemBLL _brand = new ItemBLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                btnSaveBrand.Click += new EventHandler(btnSaveBrand_Click);
            }
        }
        private void AddBrand()
        {
            Brand brand = new Brand();

            brand.Name = txtNameBrand.Text.ToTrimString();
           
            string rMessage;
            _brand.AddBrand(brand, out rMessage);

            txtNameBrand.Text = string.Empty;
            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
        }
        protected void btnSaveBrand_Click(object sender, EventArgs e)
        {
            try
            {
                AddBrand();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        
    }
}