using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSYS.ERP.item
{
    public partial class ItemImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (fileuploader.FileContent.Length > 0)
            {
                string filename = Path.GetFileName(fileuploader.PostedFile.FileName.ToString());
                ImportFromExcel(filename);
            }
           
        }


        public DataSet ImportFromExcel(string file)
        {
            // Create new dataset
            DataSet ds = new DataSet();

            // -- Start of Constructing OLEDB connection string to Excel file
            Dictionary<string, string> props = new Dictionary<string, string>();

            // For Excel 2007/2010
            if (file.EndsWith(".xlsx"))
            {
                props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
                props["Extended Properties"] = "Excel 12.0 XML";
            }
            // For Excel 2003 and older
            else if (file.EndsWith(".xls"))
            {
                props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
                props["Extended Properties"] = "Excel 8.0";
            }
            else
                return null;

            props["Data Source"] = file;

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            string connectionString = sb.ToString();
            // -- End of Constructing OLEDB connection string to Excel file

            // Connecting to Excel File
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    // you can choose the colums you want.
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    DataTable dt = new DataTable();
                    dt.TableName = sheetName.Replace("$", string.Empty);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    // Add table into DataSet
                    ds.Tables.Add(dt);

                    RadGrid1.DataSource = ds;
                    RadGrid1.DataBind();
                }

                cmd = null;
                conn.Close();
            }

            return ds;
        }
    }
}