namespace ERPSYS.Reports.Inventory
{
    partial class GoodsReceiptRpt
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodsReceiptRpt));
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Drawing.PictureWatermark pictureWatermark1 = new Telerik.Reporting.Drawing.PictureWatermark();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.goodsReceiptDetailsRpt1 = new ERPSYS.Reports.Inventory.GoodsReceiptDetailsRpt();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.pictureBox3 = new Telerik.Reporting.PictureBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.panel3 = new Telerik.Reporting.Panel();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.panel4 = new Telerik.Reporting.Panel();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.srGRNLines = new Telerik.Reporting.SubReport();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.Text8 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pictureBox4 = new Telerik.Reporting.PictureBox();
            this.sdsGRNHeader = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.goodsReceiptDetailsRpt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // goodsReceiptDetailsRpt1
            // 
            this.goodsReceiptDetailsRpt1.Name = "GoodsReceiptDetailsRpt";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3000000715255737D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.pictureBox2,
            this.pictureBox3,
            this.textBox11});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(198D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(128D), Telerik.Reporting.Drawing.Unit.Pixel(100.99622344970703D));
            this.pictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Justify;
            this.pictureBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.5521225929260254D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox3.MimeType = "image/png";
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(198D), Telerik.Reporting.Drawing.Unit.Pixel(101D));
            this.pictureBox3.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox3.Value = ((object)(resources.GetObject("pictureBox3.Value")));
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(1.0521621704101563D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3333333730697632D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Italic = false;
            this.textBox11.Style.Font.Name = "Segoe UI";
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "Material Receipt ";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.7999999523162842D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel3});
            this.detail.Name = "detail";
            // 
            // panel3
            // 
            this.panel3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2,
            this.panel4,
            this.srGRNLines,
            this.panel1});
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05D), Telerik.Reporting.Drawing.Unit.Inch(7.8996024967636913E-05D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.6145830154418945D), Telerik.Reporting.Drawing.Unit.Inch(2.6999213695526123D));
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox14,
            this.textBox9});
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.3999210596084595D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.68352282047271729D));
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034058332443237305D), Telerik.Reporting.Drawing.Unit.Inch(0.10000038146972656D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox14.Style.Font.Name = "Segoe UI";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "Remarks :";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.73413699865341187D), Telerik.Reporting.Drawing.Unit.Inch(0.10000038146972656D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.1657843589782715D), Telerik.Reporting.Drawing.Unit.Cm(1.2699998617172241D));
            this.textBox9.Style.Font.Bold = false;
            this.textBox9.Style.Font.Italic = false;
            this.textBox9.Style.Font.Name = "Segoe UI";
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox9.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox9.Value = "=Fields.Remarks";
            // 
            // panel4
            // 
            this.panel4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.textBox15,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox1,
            this.textBox2,
            this.textBox3});
            this.panel4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.35303497314453125D));
            this.panel4.Name = "panel4";
            this.panel4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.94905179738998413D));
            this.panel4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.91862154006958D), Telerik.Reporting.Drawing.Unit.Inch(0.041667461395263672D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.88114166259765625D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox13.Style.Font.Bold = false;
            this.textBox13.Style.Font.Italic = false;
            this.textBox13.Style.Font.Name = "Segoe UI";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Store Keeper :";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.799842357635498D), Telerik.Reporting.Drawing.Unit.Inch(0.041667420417070389D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5811716318130493D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox15.Style.Font.Italic = false;
            this.textBox15.Style.Font.Name = "Segoe UI";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox15.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "=Fields.StoreKeeper";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1340192556381226D), Telerik.Reporting.Drawing.Unit.Inch(0.435565322637558D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6999213695526123D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox5.Style.Font.Italic = false;
            this.textBox5.Style.Font.Name = "Segoe UI";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "=Fields.Location";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1340190172195435D), Telerik.Reporting.Drawing.Unit.Inch(0.041706722229719162D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6999213695526123D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox6.Style.Font.Italic = false;
            this.textBox6.Style.Font.Name = "Segoe UI";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=Fields.CompanyName";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1340192556381226D), Telerik.Reporting.Drawing.Unit.Inch(0.23863601684570313D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6999213695526123D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox7.Style.Font.Italic = false;
            this.textBox7.Style.Font.Name = "Segoe UI";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox7.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "=Fields.InvoiceNumber";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034058332443237305D), Telerik.Reporting.Drawing.Unit.Inch(0.23863601684570313D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998818874359131D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox1.Style.Font.Bold = false;
            this.textBox1.Style.Font.Italic = false;
            this.textBox1.Style.Font.Name = "Segoe UI";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Invoice No:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034058332443237305D), Telerik.Reporting.Drawing.Unit.Inch(0.041706722229719162D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998817682266235D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.Style.Font.Italic = false;
            this.textBox2.Style.Font.Name = "Segoe UI";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Company Name :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034058332443237305D), Telerik.Reporting.Drawing.Unit.Inch(0.435565322637558D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998818874359131D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.Style.Font.Italic = false;
            this.textBox3.Style.Font.Name = "Segoe UI";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Location :";
            // 
            // srGRNLines
            // 
            this.srGRNLines.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(2.1999208927154541D));
            this.srGRNLines.Name = "srGRNLines";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("grnId", "= Parameters.grnId.Value"));
            instanceReportSource1.ReportDocument = this.goodsReceiptDetailsRpt1;
            this.srGRNLines.ReportSource = instanceReportSource1;
            this.srGRNLines.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.49999988079071045D));
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox12,
            this.textBox17,
            this.Text8,
            this.textBox10});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.35291668772697449D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034176748245954514D), Telerik.Reporting.Drawing.Unit.Inch(0.07652648538351059D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69996058940887451D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Italic = false;
            this.textBox12.Style.Font.Name = "Segoe UI";
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "GRN NO :";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.73421597480773926D), Telerik.Reporting.Drawing.Unit.Inch(0.07652648538351059D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0998034477233887D), Telerik.Reporting.Drawing.Unit.Cm(0.5D));
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Font.Name = "Segoe UI";
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "=Fields.GRNNumber";
            // 
            // Text8
            // 
            this.Text8.CanGrow = false;
            this.Text8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.493500709533691D), Telerik.Reporting.Drawing.Unit.Cm(0.19756141304969788D));
            this.Text8.Name = "Text8";
            this.Text8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.2380993366241455D), Telerik.Reporting.Drawing.Unit.Inch(0.19559687376022339D));
            this.Text8.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.Text8.Style.Font.Bold = true;
            this.Text8.Style.Font.Name = "Segoe UI";
            this.Text8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text8.Style.Visible = true;
            this.Text8.StyleName = "Header";
            this.Text8.Value = "Date:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.79992151260376D), Telerik.Reporting.Drawing.Unit.Inch(0.0777800902724266D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5811716318130493D), Telerik.Reporting.Drawing.Unit.Cm(0.49681583046913147D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Italic = false;
            this.textBox10.Style.Font.Name = "Segoe UI";
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "=Fields.GRNDate";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.60003942251205444D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox4});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.pictureBox4.MimeType = "image/png";
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Pixel(731D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.pictureBox4.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox4.Value = ((object)(resources.GetObject("pictureBox4.Value")));
            // 
            // sdsGRNHeader
            // 
            this.sdsGRNHeader.ConnectionString = "dbconstrx";
            this.sdsGRNHeader.Name = "sdsGRNHeader";
            this.sdsGRNHeader.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@GRNId", System.Data.DbType.Int32, "= Parameters.grnId.Value")});
            this.sdsGRNHeader.SelectCommand = "Report_INV_GRNHeader";
            this.sdsGRNHeader.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // GoodsReceiptRpt
            // 
            this.DataSource = this.sdsGRNHeader;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "GoodsReceiptRpt";
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            pictureWatermark1.Image = ((object)(resources.GetObject("pictureWatermark1.Image")));
            pictureWatermark1.Opacity = 0.1D;
            this.PageSettings.Watermarks.Add(pictureWatermark1);
            reportParameter1.Name = "grnId";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "1033";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Pixel;
            this.Width = Telerik.Reporting.Drawing.Unit.Pixel(731.007568359375D);
            ((System.ComponentModel.ISupportInitialize)(this.goodsReceiptDetailsRpt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.PictureBox pictureBox3;
        private Telerik.Reporting.PictureBox pictureBox4;
        private Telerik.Reporting.SqlDataSource sdsGRNHeader;
        private Telerik.Reporting.Panel panel3;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.SubReport srGRNLines;
        private GoodsReceiptDetailsRpt goodsReceiptDetailsRpt1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox Text8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.Panel panel4;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.PictureBox pictureBox2;
    }
}