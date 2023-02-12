using ERPSYS.Helpers.Ext;
using ERPSYS.BLL;
using System;
using ERPSYS.Helpers;
using Telerik.Web.UI;
using ERPSYS.Members;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;

namespace ERPSYS.ERP.item
{
    public partial class ItemBomClone : System.Web.UI.Page
    {
        readonly ItemBLL _item = new ItemBLL();

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
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    GetManufactureItemDetails(Request.QueryString["id"].ToInt());
                }
                else
                {
                    Response.Redirect(string.Format("item-bom-form.aspx?id={0}&e={1}", ItemId, 1));
                }

                GetItemLookupTables();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetItemLookupTables()
        {
            try
            {
                DataSet ds = _item.GetItemLookupTables();

                ddlType.DataTextField = "Name";
                ddlType.DataValueField = "ItemTypeId";
                ddlType.DataSource = ds.Tables[0];
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataSource = ds.Tables[1];
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));

                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandId";
                ddlBrand.DataSource = ds.Tables[2];
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-- All --", "-1"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void GetManufactureItemDetails(int itemId)
        {
            Item item = _item.GetManufactureItem(itemId);

            if (item.ItemId <= 0)
            {
                Response.Redirect("item-list.aspx?e=1", false);
            }

            ItemId = item.ItemId;
            lblItemCode.Text = item.ItemCode.ReplaceWhenNullOrEmpty("N/A");
            lblPartNumber.Text = item.PartNumber.ReplaceWhenNullOrEmpty("N/A");
            lblDescription.Text = item.Description.ReplaceWhenNullOrEmpty("N/A");
            lblCategory.Text = string.Format("{0}{1}", item.Category.ReplaceWhenNullOrEmpty("N/A"), item.SubCategory.ReplaceWhenNullOrEmpty("N/A") != "N/A" ? string.Format("/ {0}", item.SubCategory) : string.Empty);
            lblBrand.Text = item.Brand.ReplaceWhenNullOrEmpty("N/A");
            lblUnitPrice.Text = item.UnitPrice.ToDecimalFormat();
            lblStandard.Text = item.IsNonStandard ? "Product Is Non Standard" : "Product Is Standard";
            imgItem.ImageUrl = item.ItemImage.ImageData.Length > 0 ? ImageHandle.ImageFromByte(item.ItemImage.ImageData, item.ItemImage.ImageType) : "~/ERP/resources/images/default-product.png";

            InitrgItemList();
        }

        protected void rgBom_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgBom.DataSource = _item.GetItemBomLines(ItemId, BomTypeId);
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void rgItemList_Init(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            grid.PageSize = CommonMember.GridPageSize;
        }

        protected void InitrgItemList()
        {
            rgItemList.DataSource = new List<string>();
            rgItemList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Description = txtDescription.Text.ToTrimString();
                ItemCode = txtItemCode.Text.ToTrimString();
                PartNumber = txtPartNumber.Text.ToTrimString();
                TypeId = ddlType.SelectedValue.ToInt();
                CategoryId = ddlCategory.SelectedValue.ToInt();
                BrandId = ddlBrand.SelectedValue.ToInt();

                rgItemList.DataSource = _item.GetItemsNoBomList(Description, ItemCode, PartNumber, TypeId, CategoryId, BrandId);
                rgItemList.DataBind();
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnClone_Click(object sender, EventArgs e)
        {
            try 
            {
                foreach (GridDataItem item in rgItemList.Items)
                {
                    CheckBox chkBx = (CheckBox)item.FindControl("cbItem");
                    if (chkBx != null && chkBx.Checked)
                    {
                        string toItemId = item["ItemId"].Text;
                        LstItems.Add(toItemId);
                    }
                }

                if(LstItems.Count == 0)
                {
                    AppNotification.MessageBoxWarning(GeneralResources.GetStringFromResources("no_items_selected"));
                    return;
                }

                string rMsg;
                _item.CloneItemBom(ItemId, String.Join(",", LstItems), BomTypeId, out rMsg);

                if (rMsg != string.Empty)
                {
                    AppNotification.MessageBoxFailed(rMsg);
                    return;
                }

                InitrgItemList();
                AppNotification.MessageBoxSuccess(GeneralResources.GetStringFromResources("item_bom_clone_success"));
            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("item-bom-form.aspx?id={0}", ItemId), false);
        }

        //************************************** Properties ************************************//

        public int ItemId
        {
            get { return ViewState["ItemId"] != null ? ViewState["ItemId"].ToInt() : -1; }
            set { ViewState["ItemId"] = value; }
        }

        public string Description
        {
            get { return ViewState["Description"] != null ? ViewState["Description"].ToString() : ""; }
            set { ViewState["Description"] = value; }
        }

        public string ItemCode
        {
            get { return ViewState["ItemCode"] != null ? ViewState["ItemCode"].ToString() : ""; }
            set { ViewState["ItemCode"] = value; }
        }

        public string PartNumber
        {
            get { return ViewState["PartNumber"] != null ? ViewState["PartNumber"].ToString() : ""; }
            set { ViewState["PartNumber"] = value; }
        }

        public int TypeId
        {
            get { return ViewState["TypeId"] != null ? ViewState["TypeId"].ToInt() : -1; }
            set { ViewState["TypeId"] = value; }
        }

        public int CategoryId
        {
            get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
            set { ViewState["CategoryId"] = value; }
        }

        public int BrandId
        {
            get { return ViewState["BrandId"] != null ? ViewState["BrandId"].ToInt() : -1; }
            set { ViewState["BrandId"] = value; }
        }

        public List<string> LstItems = new List<string>();

        private int BomTypeId
        {
            get { return 1; } // BOM Type 1 - 'A' - Assembly BOM
        } 
    }
}