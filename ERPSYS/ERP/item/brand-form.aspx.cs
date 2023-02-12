using ERPSYS.BLL;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using System;
using System.Threading;
using ERPSYS.Members;

namespace ERPSYS.ERP.item
{
    public partial class BrandForm : System.Web.UI.Page
    {
        readonly ItemBLL _brand = new ItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            try
            {
                if (Request.QueryString["o"] == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    Operation = "edit";
                    GetBrandDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Operation = "new";
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void GetBrandDetails(int brandId)
        {
            try
            {
                Brand brand = _brand.GetBrand(brandId);

                if (brand.BrandId <= 0)
                {
                    Response.Redirect(string.Format("brand.aspx?e={0}", 1));
                }

                BrandId = brandId;
                txtBrandName.Text = brand.Name;
                txtBrandCode.Text = brand.Code;
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void AddBrand()
        {
            Brand brand = new Brand();

            brand.Name = txtBrandName.Text.ToTrimString();
            brand.Code = txtBrandCode.Text.ToTrimString();

            string rMessage;
            _brand.AddBrand(brand, out rMessage);

            if (rMessage != string.Empty )
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }
            Response.Redirect(string.Format("brand-list.aspx?o={0}", 1), false);
        }
        protected void UpdateBrand()
        {
            Brand brand = new Brand();

            brand.BrandId = BrandId;
            brand.Name = txtBrandName.Text.ToTrimString();
            brand.Code = txtBrandCode.Text.ToTrimString();

            string rMessage;
            _brand.UpdateBrand(brand, out rMessage);

            if (rMessage != string.Empty)
            {
                AppNotification.MessageBoxFailed(rMessage);
                return;
            }

            Response.Redirect(string.Format("brand-list.aspx?o={0}", 2), false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid)
                    return;

                if (Operation == "new")
                {
                    AddBrand();
                }
                else if (Operation == "edit" && BrandId > 0)
                {
                    UpdateBrand();
                }
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("brand-list.aspx"), false);
        }

        //************************************** Properties ************************************//
        private string Operation
        {
            get { return ViewState["Opertaion"].ToString(); }
            set { ViewState["Opertaion"] = value; }
        }
        public int BrandId
        {
            get { return ViewState["BrandId"] != null ? ViewState["BrandId"].ToInt() : -1; }
            set { ViewState["BrandId"] = value; }
        }
    }
}