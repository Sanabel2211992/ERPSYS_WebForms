using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSYS.BLL;
using Telerik.Web.UI;

namespace ERPSYS.Controls.SearchBox
{
    public partial class UCCustomerSB : System.Web.UI.UserControl
    {
        //readonly ClsCustomer _clsCustomer = new ClsCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }

        protected void rsbCustomer_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
        {
            lblCustomerId.Text = e.Value;
            lblCustomerName.Text = e.Text;


            string phone = ((Dictionary<string, object>)e.DataItem)["Phone"].ToString();
            string email = ((Dictionary<string, object>)e.DataItem)["Email"].ToString();

            lblPhone.Text = phone;
            lblEmail.Text = email;



            //if(e.DataItem != null)
            //{
            //    var dataItem = ((Dictionary<string, object>)e.DataItem);
            //    var birthDay = dataItem["birthday"].ToString();
            //    FullName.Text = e.Text;
            //    LabelBirthday.Text = string.IsNullOrEmpty(birthDay) ? "-" : birthDay.Substring(0, 10);
            //    var id = e.Value;
            //    var countryText = dataItem["country"].ToString();
            //    var sportText = dataItem["sport"].ToString();
            //    string select = "SELECT " +
            //                    "P.[name] AS [Sport],C.[name] AS [Country] ," +
            //                    "COUNT(CASE WHEN [medal]=1 THEN 1 END) AS 'Gold'," +
            //                    "COUNT(CASE WHEN [medal]=2 THEN 2 END) AS 'Silver'," +
            //                    "COUNT(CASE WHEN [medal]=3 THEN 3 END) AS 'Bronze' " +
            //                    "FROM [results] R " +
            //                    "JOIN [sports] P " +
            //                    "ON " + sportText + "=P.[ID] " +
            //                    "JOIN [countries] C " +
            //                    "ON " + countryText + "=C.[id] " +
            //                    "WHERE R.[athlete]=" + id + " Group By R.[athlete],P.[name],C.[name]";

            //    using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OlympicsConnectionString"].ConnectionString))
            //    {
            //        var cmd = new SqlCommand(select, con);
            //        cmd.Connection.Open();
            //        var sqlReader = cmd.ExecuteReader();
            //        while(sqlReader.Read())
            //        {
            //            LabelCountry.Text = sqlReader["Country"].ToString();
            //            LabelSport.Text = sqlReader["Sport"].ToString();
            //            Gold.Text = sqlReader["Gold"].ToString();
            //            Silver.Text = sqlReader["Silver"].ToString();
            //            Bronze.Text = sqlReader["Bronze"].ToString();
            //            }

            //        sqlReader.Close();
            //        cmd.Connection.Close();
            //        cmd.Dispose();
            //     }

            //}
        }

        protected void rsbCustomer_DataSourceSelect(object sender, Telerik.Web.UI.SearchBoxDataSourceSelectEventArgs e)
        {
            //rsbCustomer.DataSource =_clsCustomer.GetCustomerDDL(e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
            
            //SqlDataSource source = (SqlDataSource)e.DataSource;
            //RadSearchBox searchBox = (RadSearchBox)sender;
            //string likeCondition = string.Format("'{0}' + @filterString + '%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "");
            //string countCondition = e.ShowAllResults ? " " : " TOP " + searchBox.MaxResultCount + 1;
            //if(e.SelectedContextItem != null)
            //{
            //    likeCondition = string.Format("{0} AND sport={1}", likeCondition, e.SelectedContextItem.Key);
            //}
            //source.SelectCommand = string.Format("SELECT {0} * FROM [athletes] WHERE [fullName] LIKE {1}", countCondition, likeCondition);
            //source.SelectParameters.Add("filterString", e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        }

        protected void rsbCustomer_Load(object sender, EventArgs e)
        {
            rsbCustomer.DataSource =  new DataTable();
        }
        //protected void rsbCustomer_Load(object sender, EventArgs e)
        //{
        //    rsbCustomer.DataSource =  new DataTable();
        //   //sbCustomer.DataSource = _clsCustomer.GetCustomerDDL("");
        //}
    }
}