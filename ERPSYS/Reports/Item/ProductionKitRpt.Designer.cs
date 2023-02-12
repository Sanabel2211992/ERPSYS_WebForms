namespace ERPSYS.Reports.Item
{
    partial class ProductionKitRpt
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionKitRpt));
            Telerik.Reporting.Drawing.PictureWatermark pictureWatermark1 = new Telerik.Reporting.Drawing.PictureWatermark();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.productionKitDetailsRpt1 = new ERPSYS.Reports.Item.ProductionKitDetailsRpt();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.sdsProductionKit = new Telerik.Reporting.SqlDataSource();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox3 = new Telerik.Reporting.PictureBox();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.pictureBox4 = new Telerik.Reporting.PictureBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.productionKitDetailsRpt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // productionKitDetailsRpt1
            // 
            this.productionKitDetailsRpt1.Name = "ProductionKitDetailsRpt";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(4.318000316619873D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1,
            this.subReport1});
            this.detail.Name = "detail";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox11,
            this.textBox8,
            this.textBox9,
            this.textBox13,
            this.textBox7,
            this.textBox5,
            this.textBox4,
            this.textBox6,
            this.textBox3,
            this.textBox1,
            this.textBox2,
            this.textBox12});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(1.0999604463577271D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.09375D), Telerik.Reporting.Drawing.Unit.Inch(0.29472780227661133D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox11.Style.Font.Bold = false;
            this.textBox11.Style.Font.Name = "Segoe UI";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "Estimated Time (H)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.09375D), Telerik.Reporting.Drawing.Unit.Inch(0.097798503935337067D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox8.Style.Font.Bold = false;
            this.textBox8.Style.Font.Name = "Segoe UI";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox8.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "Type";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:d}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3938288688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.097798503935337067D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6998813152313232D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox9.Style.Font.Name = "Segoe UI";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox9.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "=Fields.TypeDescription";
            // 
            // textBox13
            // 
            this.textBox13.Format = "{0:d}";
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3938288688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.29472780227661133D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6998813152313232D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox13.Style.Font.Name = "Segoe UI";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox13.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.93802100419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.688586413860321D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.961939811706543D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox7.Style.Font.Name = "Segoe UI";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox7.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "=Fields.Remarks";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.93802100419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.49165710806846619D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.961939811706543D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox5.Style.Font.Name = "Segoe UI";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "=Fields.ItemCode";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.93802100419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.097798503935337067D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.961939811706543D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox4.Style.Font.Name = "Segoe UI";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "=Fields.Name";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.93802100419998169D), Telerik.Reporting.Drawing.Unit.Inch(0.29472780227661133D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.961939811706543D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox6.Style.Font.Name = "Segoe UI";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=Fields.PartNumber";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.031770866364240646D), Telerik.Reporting.Drawing.Unit.Inch(0.29472780227661133D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90617132186889648D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.Style.Font.Name = "Segoe UI";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "PartNumber";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.031731445342302322D), Telerik.Reporting.Drawing.Unit.Inch(0.097798503935337067D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90617132186889648D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Name = "Segoe UI";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.031731445342302322D), Telerik.Reporting.Drawing.Unit.Inch(0.49165710806846619D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90617114305496216D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Name = "Segoe UI";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Item Code";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.031771104782819748D), Telerik.Reporting.Drawing.Unit.Inch(0.688586413860321D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90617096424102783D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox12.Style.Font.Bold = false;
            this.textBox12.Style.Font.Name = "Segoe UI";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "Remarks";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D), Telerik.Reporting.Drawing.Unit.Cm(3.0479998588562012D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("KitId", "= Parameters.KitId.Value"));
            instanceReportSource1.ReportDocument = this.productionKitDetailsRpt1;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Cm(1.2700004577636719D));
            // 
            // sdsProductionKit
            // 
            this.sdsProductionKit.ConnectionString = "dbconstrx";
            this.sdsProductionKit.Name = "sdsProductionKit";
            this.sdsProductionKit.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@KitId", System.Data.DbType.Int32, "= Parameters.KitId.Value")});
            this.sdsProductionKit.SelectCommand = "Report_Item_KitHeader";
            this.sdsProductionKit.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.89999991655349731D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.30000019073486328D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.599999725818634D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3000000715255737D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox3,
            this.pictureBox2,
            this.pictureBox4,
            this.textBox10});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5520439147949219D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox3.MimeType = "image/png";
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(198D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pictureBox3.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox3.Value = ((object)(resources.GetObject("pictureBox3.Value")));
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(128.38862609863281D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Justify;
            this.pictureBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox4.MimeType = "image/png";
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(198D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pictureBox4.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox4.Value = ((object)(resources.GetObject("pictureBox4.Value")));
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:d}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(1.0521621704101563D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3373813629150391D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Italic = false;
            this.textBox10.Style.Font.Name = "Segoe UI";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox10.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "Production Kit";
            // 
            // ProductionKitRpt
            // 
            this.DataSource = this.sdsProductionKit;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1,
            this.pageHeaderSection1});
            this.Name = "ProductionKitRpt";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            pictureWatermark1.Image = ((object)(resources.GetObject("pictureWatermark1.Image")));
            pictureWatermark1.Opacity = 0.1D;
            this.PageSettings.Watermarks.Add(pictureWatermark1);
            reportParameter1.AllowBlank = false;
            reportParameter1.Name = "KitId";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "8";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Pixel;
            this.Width = Telerik.Reporting.Drawing.Unit.Pixel(731D);
            ((System.ComponentModel.ISupportInitialize)(this.productionKitDetailsRpt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.SqlDataSource sdsProductionKit;
        private Telerik.Reporting.SubReport subReport1;
        private ProductionKitDetailsRpt productionKitDetailsRpt1;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.PictureBox pictureBox3;
        private Telerik.Reporting.PictureBox pictureBox2;
        private Telerik.Reporting.PictureBox pictureBox4;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox10;
    }
}