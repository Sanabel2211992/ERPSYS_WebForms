using ERPSYS.BLL;
using ERPSYS.Members;
namespace ERPSYS.Reports.SCM
{
    partial class GoodsReceipt
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.Drawing.PictureWatermark pictureWatermark1 = new Telerik.Reporting.Drawing.PictureWatermark();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceipt));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector1 = new Telerik.Reporting.Drawing.DescendantSelector();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.DescendantSelector descendantSelector2 = new Telerik.Reporting.Drawing.DescendantSelector();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pbHeaderRight = new Telerik.Reporting.PictureBox();
            this.pbHeaderCenter = new Telerik.Reporting.PictureBox();
            this.pbHeaderLeft = new Telerik.Reporting.PictureBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.sdsGoodsReceiptLines = new Telerik.Reporting.SqlDataSource();
            this.Field6 = new Telerik.Reporting.TextBox();
            this.Text8 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.Id1 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.pnlCancelRemarks = new Telerik.Reporting.Panel();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.pnlStatus = new Telerik.Reporting.Panel();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pbFooter = new Telerik.Reporting.PictureBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.sdsGoodsReceiptHedaer = new Telerik.Reporting.SqlDataSource();
            this.txtStatusId = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.30154481530189514D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Segoe UI";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.StyleName = "Normal.TableHeader";
            this.textBox1.Value = "No.";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(100D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Segoe UI";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox6.StyleName = "Normal.TableHeader";
            this.textBox6.Value = "Part Number";
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(96.333320617675781D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Font.Name = "Segoe UI";
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.StyleName = "Normal.TableHeader";
            this.textBox18.Value = "Catalog No";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3428201675415039D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Segoe UI";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.StyleName = "Normal.TableHeader";
            this.textBox3.Value = "Description";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.46897795796394348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "Segoe UI";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.StyleName = "Normal.TableHeader";
            this.textBox4.Value = "QTY\r\n";
            // 
            // textBox26
            // 
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(40.999935150146484D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Name = "Segoe UI";
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox26.StyleName = "Normal.TableHeader";
            this.textBox26.Value = "Unit";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.5964498519897461D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pbHeaderRight,
            this.pbHeaderCenter,
            this.pbHeaderLeft,
            this.textBox13});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pbHeaderRight
            // 
            this.pbHeaderRight.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5416274070739746D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pbHeaderRight.MimeType = "image/png";
            this.pbHeaderRight.Name = "pbHeaderRight";
            this.pbHeaderRight.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(198D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pbHeaderRight.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            // 
            // pbHeaderCenter
            // 
            this.pbHeaderCenter.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0937106609344482D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pbHeaderCenter.MimeType = "image/png";
            this.pbHeaderCenter.Name = "pbHeaderCenter";
            this.pbHeaderCenter.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(128.17726135253906D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pbHeaderCenter.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pbHeaderCenter.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Justify;
            this.pbHeaderCenter.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // pbHeaderLeft
            // 
            this.pbHeaderLeft.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pbHeaderLeft.MimeType = "image/png";
            this.pbHeaderLeft.Name = "pbHeaderLeft";
            this.pbHeaderLeft.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(197.78863525390625D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pbHeaderLeft.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(1.2000001668930054D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.587975025177002D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox13.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "MATERIAL RECEIPT";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.5035502910614014D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1,
            this.Field6,
            this.Text8,
            this.textBox15,
            this.textBox16,
            this.textBox5,
            this.textBox8,
            this.textBox2,
            this.textBox11,
            this.textBox14,
            this.textBox19,
            this.textBox17,
            this.textBox20,
            this.Id1,
            this.textBox44,
            this.pnlCancelRemarks,
            this.pnlStatus,
            this.txtStatusId});
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.3015446662902832D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Pixel(99.9999771118164D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Pixel(96.333335876464844D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.3428201675415039D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.46897777915000916D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Pixel(40.999935150146484D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox7);
            this.table1.Body.SetCellContent(0, 3, this.textBox9);
            this.table1.Body.SetCellContent(0, 4, this.textBox10);
            this.table1.Body.SetCellContent(0, 2, this.textBox21);
            this.table1.Body.SetCellContent(0, 5, this.textBox22);
            this.table1.Body.SetCellContent(0, 1, this.textBox24);
            tableGroup1.ReportItem = this.textBox1;
            tableGroup2.Name = "group2";
            tableGroup2.ReportItem = this.textBox6;
            tableGroup3.Name = "group1";
            tableGroup3.ReportItem = this.textBox18;
            tableGroup4.ReportItem = this.textBox3;
            tableGroup5.ReportItem = this.textBox4;
            tableGroup6.Name = "group";
            tableGroup6.ReportItem = this.textBox26;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.ColumnGroups.Add(tableGroup4);
            this.table1.ColumnGroups.Add(tableGroup5);
            this.table1.ColumnGroups.Add(tableGroup6);
            this.table1.DataSource = this.sdsGoodsReceiptLines;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox9,
            this.textBox10,
            this.textBox21,
            this.textBox22,
            this.textBox24,
            this.textBox1,
            this.textBox6,
            this.textBox18,
            this.textBox3,
            this.textBox4,
            this.textBox26});
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.5035501718521118D));
            this.table1.Name = "table1";
            tableGroup7.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup7.Name = "Detail";
            this.table1.RowGroups.Add(tableGroup7);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(728.214111328125D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.table1.StyleName = "Normal.TableNormal";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.30154481530189514D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Normal.TableBody";
            this.textBox7.Value = "= Fields.SeqId";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3428201675415039D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox9.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "Normal.TableBody";
            this.textBox9.Value = "= Fields.Description";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:N2}";
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.46897795796394348D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox10.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox10.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "Normal.TableBody";
            this.textBox10.Value = "= Fields.Quantity";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(96.333320617675781D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox21.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.StyleName = "Normal.TableBody";
            this.textBox21.Value = "= Fields.ItemCode";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:N2}";
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(40.999935150146484D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox22.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox22.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox22.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.StyleName = "Normal.TableBody";
            this.textBox22.Value = "= Fields.Uom";
            // 
            // textBox24
            // 
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(100D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox24.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox24.Style.Font.Bold = false;
            this.textBox24.Style.Font.Name = "Segoe UI";
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox24.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.StyleName = "Normal.TableBody";
            this.textBox24.Value = "= Fields.PartNumber";
            // 
            // sdsGoodsReceiptLines
            // 
            this.sdsGoodsReceiptLines.ConnectionString = "dbconstrx";
            this.sdsGoodsReceiptLines.Name = "sdsGoodsReceiptLines";
            this.sdsGoodsReceiptLines.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@GoodsReceiptId", System.Data.DbType.Int32, "= Parameters.GoodsReceiptId.Value")});
            this.sdsGoodsReceiptLines.SelectCommand = "Report_SCM_GoodsReceipt_Lines";
            this.sdsGoodsReceiptLines.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // Field6
            // 
            this.Field6.CanGrow = false;
            this.Field6.Format = "{0:d}";
            this.Field6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.233908653259277D), Telerik.Reporting.Drawing.Unit.Cm(0.2740013599395752D));
            this.Field6.Name = "Field6";
            this.Field6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8205811977386475D), Telerik.Reporting.Drawing.Unit.Inch(0.19559687376022339D));
            this.Field6.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.Field6.Style.Font.Bold = false;
            this.Field6.Style.Font.Name = "Segoe UI";
            this.Field6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.Field6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Field6.StyleName = "Header";
            this.Field6.Value = "= Fields.ReceiptDate";
            // 
            // Text8
            // 
            this.Text8.CanGrow = false;
            this.Text8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.202109336853027D), Telerik.Reporting.Drawing.Unit.Cm(0.2740013599395752D));
            this.Text8.Name = "Text8";
            this.Text8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0315983295440674D), Telerik.Reporting.Drawing.Unit.Inch(0.19478307664394379D));
            this.Text8.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.Text8.Style.Font.Bold = true;
            this.Text8.Style.Font.Italic = false;
            this.Text8.Style.Font.Name = "Segoe UI";
            this.Text8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.Text8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.Text8.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.Text8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Text8.Style.Visible = true;
            this.Text8.StyleName = "Header";
            this.Text8.Value = "Date :";
            // 
            // textBox15
            // 
            this.textBox15.CanGrow = false;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012743084691464901D), Telerik.Reporting.Drawing.Unit.Cm(0.78985852003097534D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5398998260498047D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox15.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Name = "Segoe UI";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox15.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.StyleName = "Header";
            this.textBox15.Value = "Supplier Name :";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = false;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5528430938720703D), Telerik.Reporting.Drawing.Unit.Cm(0.78975838422775269D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6807346343994141D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox16.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox16.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.Font.Bold = false;
            this.textBox16.Style.Font.Italic = false;
            this.textBox16.Style.Font.Name = "Segoe UI";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.StyleName = "Header";
            this.textBox16.Value = "= Fields.CompanyName";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(2.2004797458648682D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.651799201965332D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "= Fields.UserTitle";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(2.0035502910614014D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.651799201965332D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox8.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.PostedBy";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.3147425651550293D), Telerik.Reporting.Drawing.Unit.Cm(0.29274255037307739D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.9188351631164551D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Italic = false;
            this.textBox2.Style.Font.Name = "Segoe UI";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.StyleName = "Header";
            this.textBox2.Value = "= Fields.ReceiptNumber";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = false;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012642961926758289D), Telerik.Reporting.Drawing.Unit.Cm(0.29274255037307739D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.3018999099731445D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Italic = false;
            this.textBox11.Style.Font.Name = "Segoe UI";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "Header";
            this.textBox11.Value = "Material Receipt No :";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = false;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012642961926758289D), Telerik.Reporting.Drawing.Unit.Cm(1.2868739366531372D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox14.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Italic = false;
            this.textBox14.Style.Font.Name = "Segoe UI";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox14.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.StyleName = "Header";
            this.textBox14.Value = "Location :";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = false;
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5528430938720703D), Telerik.Reporting.Drawing.Unit.Cm(1.2868739366531372D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.6807346343994141D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox19.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox19.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox19.Style.Font.Bold = false;
            this.textBox19.Style.Font.Italic = false;
            this.textBox19.Style.Font.Name = "Segoe UI";
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.StyleName = "Header";
            this.textBox19.Value = "= Fields.Location";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = false;
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5528430938720703D), Telerik.Reporting.Drawing.Unit.Cm(1.7986531257629395D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.501544952392578D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox17.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.Font.Bold = false;
            this.textBox17.Style.Font.Italic = false;
            this.textBox17.Style.Font.Name = "Segoe UI";
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.StyleName = "Header";
            this.textBox17.Value = "= Fields.Remarks";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = false;
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.012642961926758289D), Telerik.Reporting.Drawing.Unit.Cm(1.7986531257629395D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399997234344482D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.textBox20.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox20.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Italic = false;
            this.textBox20.Style.Font.Name = "Segoe UI";
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox20.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox20.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.StyleName = "Header";
            this.textBox20.Value = "Remarks :";
            // 
            // Id1
            // 
            this.Id1.CanGrow = false;
            this.Id1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.202108383178711D), Telerik.Reporting.Drawing.Unit.Cm(0.77101761102676392D));
            this.Id1.Name = "Id1";
            this.Id1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0376908779144287D), Telerik.Reporting.Drawing.Unit.Inch(0.19559676945209503D));
            this.Id1.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.Id1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Id1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Id1.Style.Font.Bold = true;
            this.Id1.Style.Font.Italic = false;
            this.Id1.Style.Font.Name = "Segoe UI";
            this.Id1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.Id1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.Id1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.Id1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.Id1.StyleName = "Header";
            this.Id1.Value = "PO Number :";
            // 
            // textBox44
            // 
            this.textBox44.CanGrow = false;
            this.textBox44.Format = "{0:d}";
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.239999771118164D), Telerik.Reporting.Drawing.Unit.Cm(0.77101761102676392D));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.8144900798797607D), Telerik.Reporting.Drawing.Unit.Inch(0.19559687376022339D));
            this.textBox44.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox44.Style.Font.Bold = false;
            this.textBox44.Style.Font.Name = "Segoe UI";
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox44.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox44.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox44.StyleName = "Header";
            this.textBox44.Value = "= Fields.PurchaseOrderNumber";
            // 
            // pnlCancelRemarks
            // 
            this.pnlCancelRemarks.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox12,
            this.textBox25});
            this.pnlCancelRemarks.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0D), Telerik.Reporting.Drawing.Unit.Pixel(86.76544189453125D));
            this.pnlCancelRemarks.Name = "pnlCancelRemarks";
            this.pnlCancelRemarks.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(720.1658935546875D), Telerik.Reporting.Drawing.Unit.Cm(0.75898265838623047D));
            this.pnlCancelRemarks.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlCancelRemarks.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlCancelRemarks.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlCancelRemarks.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pnlCancelRemarks.Style.Font.Bold = true;
            this.pnlCancelRemarks.Style.Font.Name = "Segoe UI";
            this.pnlCancelRemarks.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.pnlCancelRemarks.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pnlCancelRemarks.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pnlCancelRemarks.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pnlCancelRemarks.Style.Visible = true;
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = false;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5399997234344482D), Telerik.Reporting.Drawing.Unit.Inch(0.21725884079933167D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox12.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Italic = false;
            this.textBox12.Style.Font.Name = "Segoe UI";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "Header";
            this.textBox12.Value = "Cancel Remarks :";
            // 
            // textBox25
            // 
            this.textBox25.CanGrow = false;
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5528430938720703D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(15.994655609130859D), Telerik.Reporting.Drawing.Unit.Inch(0.21725884079933167D));
            this.textBox25.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox25.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox25.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox25.Style.Font.Bold = false;
            this.textBox25.Style.Font.Italic = false;
            this.textBox25.Style.Font.Name = "Segoe UI";
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.StyleName = "Header";
            this.textBox25.Value = "= Fields.CancelRemarks";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox27,
            this.textBox28});
            this.pnlStatus.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(498.97735595703125D), Telerik.Reporting.Drawing.Unit.Pixel(49.195724487304688D));
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(221.19235229492188D), Telerik.Reporting.Drawing.Unit.Cm(0.49681603908538818D));
            this.pnlStatus.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlStatus.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlStatus.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pnlStatus.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pnlStatus.Style.Font.Bold = true;
            this.pnlStatus.Style.Font.Name = "Segoe UI";
            this.pnlStatus.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.pnlStatus.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pnlStatus.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pnlStatus.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pnlStatus.Style.Visible = true;
            // 
            // textBox27
            // 
            this.textBox27.CanGrow = false;
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0060924356803298D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0315983295440674D), Telerik.Reporting.Drawing.Unit.Inch(0.18155306577682495D));
            this.textBox27.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox27.Style.Font.Bold = true;
            this.textBox27.Style.Font.Italic = false;
            this.textBox27.Style.Font.Name = "Segoe UI";
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox27.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox27.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Style.Visible = true;
            this.textBox27.StyleName = "Header";
            this.textBox27.Value = "Status :";
            // 
            // textBox28
            // 
            this.textBox28.CanGrow = false;
            this.textBox28.Format = "{0:d}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.0379908084869385D), Telerik.Reporting.Drawing.Unit.Cm(0.00010052680590888485D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.814389705657959D), Telerik.Reporting.Drawing.Unit.Inch(0.19559687376022339D));
            this.textBox28.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.textBox28.Style.Font.Bold = false;
            this.textBox28.Style.Font.Name = "Segoe UI";
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox28.StyleName = "Header";
            this.textBox28.Value = "= Fields.Status";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.89999991655349731D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pbFooter,
            this.textBox23});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pbFooter
            // 
            this.pbFooter.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D), Telerik.Reporting.Drawing.Unit.Inch(0.3229166567325592D));
            this.pbFooter.MimeType = "image/png";
            this.pbFooter.Name = "pbFooter";
            this.pbFooter.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(727D), Telerik.Reporting.Drawing.Unit.Pixel(52D));
            this.pbFooter.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pbFooter.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox23
            // 
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9375D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65313166379928589D), Telerik.Reporting.Drawing.Unit.Cm(0.494507372379303D));
            this.textBox23.Style.Font.Bold = false;
            this.textBox23.Style.Font.Italic = false;
            this.textBox23.Style.Font.Name = "Segoe UI";
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox23.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox23.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Bottom;
            this.textBox23.Value = "= \'Page \' + PageNumber + \' of \' + PageCount";
            // 
            // sdsGoodsReceiptHedaer
            // 
            this.sdsGoodsReceiptHedaer.ConnectionString = "dbconstrx";
            this.sdsGoodsReceiptHedaer.Name = "sdsGoodsReceiptHedaer";
            this.sdsGoodsReceiptHedaer.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@GoodsReceiptId", System.Data.DbType.Int32, "= Parameters.GoodsReceiptId.Value")});
            this.sdsGoodsReceiptHedaer.SelectCommand = "Report_SCM_GoodsReceipt_Header";
            this.sdsGoodsReceiptHedaer.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // txtStatusId
            // 
            this.txtStatusId.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9375D), Telerik.Reporting.Drawing.Unit.Inch(2.3002090454101562D));
            this.txtStatusId.Name = "txtStatusId";
            this.txtStatusId.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70000022649765015D), Telerik.Reporting.Drawing.Unit.Inch(0.20330174267292023D));
            this.txtStatusId.Style.Visible = false;
            this.txtStatusId.Value = "= Fields.StatusId";
            // 
            // GoodsReceipt
            // 
            this.DataSource = this.sdsGoodsReceiptHedaer;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "GoodsReceipt";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            pictureWatermark1.Image = ((object)(resources.GetObject("pictureWatermark1.Image")));
            pictureWatermark1.Opacity = 0.1D;
            pictureWatermark1.PrintOnFirstPage = true;
            pictureWatermark1.PrintOnLastPage = true;
            this.PageSettings.Watermarks.Add(pictureWatermark1);
            reportParameter1.Name = "GoodsReceiptId";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "1";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.Table), "Normal.TableNormal")});
            styleRule2.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            descendantSelector1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableHeader")});
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector1});
            styleRule3.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            descendantSelector2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.Table)),
            new Telerik.Reporting.Drawing.StyleSelector(typeof(Telerik.Reporting.ReportItem), "Normal.TableBody")});
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            descendantSelector2});
            styleRule4.Style.BorderColor.Default = System.Drawing.Color.Black;
            styleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            styleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Pixel;
            this.Width = Telerik.Reporting.Drawing.Unit.Pixel(739D);
            this.ItemDataBound += new System.EventHandler(this.GoodsReceipt_ItemDataBound);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sdsGoodsReceiptHedaer;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.SqlDataSource sdsGoodsReceiptLines;
        private Telerik.Reporting.PictureBox pbHeaderRight;
        private Telerik.Reporting.PictureBox pbHeaderCenter;
        private Telerik.Reporting.PictureBox pbHeaderLeft;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox Field6;
        private Telerik.Reporting.TextBox Text8;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox Id1;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.PictureBox pbFooter;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.Panel pnlCancelRemarks;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.Panel pnlStatus;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox txtStatusId;
    }
}