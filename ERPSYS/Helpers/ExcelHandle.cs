using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Web;
using ERPSYS.BLL;

namespace ERPSYS.Helpers
{
    public class ExcelHandle
    {
        public void ExportExcel(DataTable dt, ExcelType excelType, string excelName, string sheetName)
        {
            string fileName = string.Format("{0}_{1}", excelName, DateTime.Now.ToString("yyyyMMdd"));

            IWorkbook workbook;

            if (excelType == ExcelType.Xlsx)
            {
                workbook = new XSSFWorkbook();
            }
            else if (excelType == ExcelType.Xls)
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet(sheetName);

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            //Create style

            ICellStyle FontCellStyle = workbook.CreateCellStyle();
            IFont Font = workbook.CreateFont();
            Font.IsBold = true;
            //Font.Color = IndexedColors.Blue.Index;
            FontCellStyle.SetFont(Font);

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
                cell.CellStyle = FontCellStyle;
                cell.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                //SetColumnWidth
                //switch (j)
                //{
                //    case 0:
                //        sheet1.SetColumnWidth(j, 7000);
                //        break;
                //    case 1:
                //        sheet1.SetColumnWidth(j, 7000);
                //        break;
                //    case 2:
                //        sheet1.SetColumnWidth(j, 25000);
                //        break;                       
                //}
              
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                HttpContext.Current.Response.Clear();
                workbook.Write(exportData);
                if (excelType == ExcelType.Xlsx) //xlsx file format
                {
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName + ".xlsx"));
                    HttpContext.Current.Response.BinaryWrite(exportData.ToArray());
                }
                else if (excelType == ExcelType.Xls)  //xls file format
                {
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName +".xls"));
                    HttpContext.Current.Response.BinaryWrite(exportData.GetBuffer());
                }
                HttpContext.Current.Response.End();
            }
        }
    }
}