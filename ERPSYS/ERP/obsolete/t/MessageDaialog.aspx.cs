using ERPSYS.Controls;
using ERPSYS.Controls.HierarchyItems.SCM.PurchaseOrder;
using ERPSYS.Helpers;
using ERPSYS.Members;
using ERPSYS.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.t
{
    public partial class MessageDaialog : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            btnTicket.Attributes.Add("onClick", "return true;");
            //Control myCtrl = LoadControl("~/Controls/AddTicket.ascx");
            //Page.FindControl("Content1").Controls.Add(myCtrl);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //string radalertscript = "<script language='javascript'>function f(){radalert('Welcome to RadWindow for <strong>ASP.NET AJAX</strong>!', 330, 210); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
            rwLogin.Visible = true;   
        }

        protected void btnTicket_Click(object sender, EventArgs e)
        {
           
            //AddTicket Ticketcontrol = new AddTicket();

            for(int i=0; i<=5 ; i++)
            {
                AddTicket myUserControl = (AddTicket)Page.LoadControl("~/Controls/AddTicket.ascx");
               // myUserControl.SetData("User" + i, DateTime.Now.ToString("h:mm:ss tt"), "Welcome " + i);
                myUserControl.Name = "Sanabel" + i;
                myUserControl.Date = DateTime.Now.ToString("h:mm:ss tt");
                myUserControl.Note = "Welcome " + i;
                phviewUC.Controls.Add(myUserControl);
                //rwLogin.Controls.Add(myUserControl);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            pWelcome.Visible = true;
            pLogIn.Visible = false;
            lbname.Text = " Welcome  " + txtname.Text;
            lbemail.Text = "Email : " + txtemail.Text;
        }

        protected void Unnamed1_Click1(object sender, EventArgs e)
        {

            //UCItemAdd myUserControl = (UCItemAdd)Page.LoadControl("~/Controls/HierarchyItems/SCM/PurchaseOrder/UCItemAdd.ascx");
            //// myUserControl.SetData("User" + i, DateTime.Now.ToString("h:mm:ss tt"), "Welcome " + i);
            //PlaceHolder1.Controls.Add(myUserControl);

            try
            {
            //    if (!IsValid)
            //    {
            //        return;
            //    }

            //    int itemId = myUserControl.ItemId;
            //    string description = myUserControl.Description;
            //    decimal quantity = myUserControl.Quantity;
            //    decimal unitPrice = myUserControl.UnitPrice;
            //    decimal discount = myUserControl.Discount;
            //    bool isPercentDiscount = myUserControl.IsPercentDiscount;
            //    int uomId = myUserControl.UomId;

            //    if (itemId <= 0)
            //    {
            //        AppNotification.MessageBoxWarning("Please select a valid Item");
            //        return;
            //    }

            //    //AddLine(itemId, description, quantity, unitPrice, discount, isPercentDiscount, uomId);
            //    myUserControl.ResetFields();

            }
            catch (Exception ex)
            {
                AppNotification.MessageBoxException(ex);
            }
        }
    }
}