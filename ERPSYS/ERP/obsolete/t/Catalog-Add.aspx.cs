using ERPSYS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.Members;
using ERPSYS.Helpers;
using ERPSYS.Helpers.Ext;
using Telerik.Web.UI;

namespace ERPSYS.ERP.t
{
    public partial class sendbttClick : System.Web.UI.Page
    {
        //readonly MailBLL _mail = new MailBLL();
        //readonly ItemBLL _item = new ItemBLL();
        //readonly SanabelBLL _uom = new SanabelBLL();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        GetItemLookupTables();
        //        GetItemLookupUomFromTables();
        //        GetItemLookupUomToTables();
        //        GetUserControl();
        //    }
        //}
        //protected void GetItemLookupUomFromTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlUOMFrom.DataTextField = "Name";
        //    ddlUOMFrom.DataValueField = "UomId";
        //    ddlUOMFrom.DataSource = lookup.GetUom();
        //    ddlUOMFrom.DataBind();

        //    ddlUOMFrom.SelectedValue = "1";
        //}
        //protected void GetItemLookupUomToTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlUOMTo.DataTextField = "Name";
        //    ddlUOMTo.DataValueField = "UomId";
        //    ddlUOMTo.DataSource = lookup.GetUom();
        //    ddlUOMTo.DataBind();

        //    ddlUOMTo.SelectedValue = "1";
        //}
        ////protected void AddConvertUom()
        ////{
        ////    UnitMeasureClass unit = new UnitMeasureClass();

        ////   unit.FromUomId = ddlUOMFrom.SelectedValue.ToInt();
        ////   unit.ToUomId = ddlUOMTo.SelectedValue.ToInt();
        ////   unit.UomFactor = txtFactor.Text.ToDecimal();

        ////  string rMessage;
        ////  _uom.AddConvertUom(unit , out rMessage);

        ////  if (rMessage != string.Empty)
        ////    {
        ////        AppNotification.MessageBoxFailed(rMessage);
        ////        return;
        ////    }
        ////  AppNotification.MessageBoxSuccess("uom_conversion_add_success");
        ////}
        //protected void GetUserControl()
        //{
   
        //    Add_Brand ctrlBrand = (Add_Brand)LoadControl("~/ERP/t/Add-Brand.ascx");
        //    phBrend.Controls.Add(ctrlBrand);

        //    Add_Catalog ctrlCatalog = (Add_Catalog)LoadControl("~/ERP/t/Add-Catalog.ascx");
        //    phCatalog.Controls.Add(ctrlCatalog);

        //    Add_Measure ctrlMeasure = (Add_Measure)LoadControl("~/ERP/t/Add-Measure.ascx");
        //    phMeasure.Controls.Add(ctrlMeasure);

        //    Add_Sub_Category ctrlSub_Category = (Add_Sub_Category)LoadControl("~/ERP/t/Add-Sub-Category.ascx");
        //    phSubCat.Controls.Add(ctrlSub_Category);


        //}
        //protected void GetItemLookupTables()
        //{
        //    LookupBLL lookup = new LookupBLL();

        //    ddlCategory.DataTextField = "Name";
        //    ddlCategory.DataValueField = "CategoryId";
        //    ddlCategory.DataSource = lookup.GetItemCategory();
        //    ddlCategory.DataBind();
        //    ddlCategory.Items.Insert(0, new ListItem("-- All --", "-1"));
        //}
        //protected void OpenDialog(object sender, EventArgs e)
        //{
        //    rwCategory.Visible = true;
        //}
        //private void ItemCatAdd()
        //{
        //    ItemCategory category = new ItemCategory();

        //    category.Name = txtName.Text.ToTrimString();
        //    category.Code = txtCode.Text.ToTrimString();
        //    category.IsActive = cbIsActive.Checked.ToBool();

        //    string rMessage;
        //    _item.AddCategory(category, out rMessage);

        //    rwCategory.Visible = false;
        //    GetItemLookupTables();

        //    if (rMessage != string.Empty)
        //    {
        //        AppNotification.MessageBoxFailed(rMessage);
        //        return;
        //    }
        //}
        //protected void btnCancel_Click1(object sender, EventArgs e)
        //{
        //    rwCategory.Visible = false;
        //}
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ItemCatAdd();
        //    }
        //    catch (Exception ex)
        //    {
        //        AppNotification.MessageBoxException(ex);
        //    }
        //}
        //        //protected void btSend_Click(object sender, EventArgs e)
        ////{
        ////    EmailMessageHandle message = new EmailMessageHandle();
        ////    MailSettings settings = _mail.GetMailSettings(46);

        ////    message.SenderEmail = settings.SenderAddress;
        ////    List<string> mail = new List<string>( new string[] { settings.SenderAddress });
        ////    List<string> emptyList = new List<string>();

        ////    message.MailTo = mail;
        ////    message.MailCc = emptyList;
        ////    message.MailBcc = emptyList;
        ////    message.MailAttachments = emptyList;
        ////    message.Subject = "Click in the button";
        ////    message.Body = UserSession.UserDisplayName + " was Clicked on the button";
           
        ////    string rMessage = message.SendMessage();
        ////    if (rMessage != string.Empty)
        ////    {
        ////        AppNotification.MessageBoxFailed(rMessage);
        ////        return;
        ////    }
        ////}

        //protected void btnConvert_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    AddConvertUom();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    AppNotification.MessageBoxException(ex);
        //    //}
        //}

        ////************************************** Properties ************************************//

        //public string Name
        //{
        //    get { return ViewState["Name"] != null ? ViewState["Name"].ToString() : ""; }
        //    set { ViewState["Name"] = value; }
        //}

        //public int CategoryId
        //{
        //    get { return ViewState["CategoryId"] != null ? ViewState["CategoryId"].ToInt() : -1; }
        //    set { ViewState["CategoryId"] = value; }
        //}    
    }
}