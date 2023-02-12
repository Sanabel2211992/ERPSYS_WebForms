using System;
using System.Web.UI;
using ERPSYS.BLL;

namespace ERPSYS.ERP.main
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var hours = DateTime.Now.Hour;

                if (hours >= 0 && hours < 12)
                {
                    lblwelcome.Text = @"Good morning, " + RegisteredUser.UserDisplayName;
                }
                else if (hours >= 12 && hours < 18)
                {
                    lblwelcome.Text = @"Good afternoon, " + RegisteredUser.UserDisplayName;
                }
                else if (hours >= 18 && hours < 24)
                {
                    lblwelcome.Text = @"Good evening, " + RegisteredUser.UserDisplayName;
                }

                SetTiles();
            }

            //ClsLogging.WriteInfoMessage("Info");
            //ClsLogging.WriteWarnMessage("Warn");
            //ClsLogging.WriteExceptionMessage("Error");
            //ClsLogging.WriteFatalMessage("Fatal"); 
        }

        private void SetTiles()
        {
            switch (UserSession.RoleId)
            {
                case 1: // Sales
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    switch (UserSession.DepartmentId)
                    {
                        case 1:  // Sales
                            ritSalesInvoice.Visible = false;
                            break;
                        case 2: // Estimation
                            ritSalesOrder.Visible = false;
                            break;
                        case 3: // Accounting
                            break;
                        case 4: // Store
                            ritQuote.Visible = false;
                            ritSalesOrder.Visible = false;
                            ritSalesInvoice.Visible = false;
                            ritJobOrder.Visible = false;
                            break;
                        case 5: // Production
                            ritQuote.Visible = false;
                            ritSalesOrder.Visible = false;
                            ritSalesInvoice.Visible = false;
                            break;
                        case 6: // Management
                            break;
                        case 7: // Operation
                            break;
                    }
                    break;
                case 5:
                    ritProducts.Visible = false;
                    ritPriceList.Visible = true;
                    ritQuote.Visible = true;
                    ritSalesOrder.Visible = false;
                    ritSalesInvoice.Visible = true;
                    ritJobOrder.Visible = false;
                    break;
            }
        }
    }
}