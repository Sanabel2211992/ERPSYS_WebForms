<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="ERPSYS.ERP.obsolete.TestPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">

        function assignDataSource() {
            var masterTable = $find("<%= rhcBarSeries.ClientID %>").get_masterTableView();
            masterTable.set_dataSource(ChartData());
            masterTable.dataBind();
        }
        function ChartData() {
            $.ajax({
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                //url: "ShowTextJQ.aspx/AddCategory",
                data: "{'country': 'Spain','year': '2008','unit': 'GWh','solar': 2578, 'hydro': 26112,'wind': 32203,'nuclear': 58973}, { 'country': 'Spain', 'year': '2007', 'unit': 'GWh', 'solar': 508,  'hydro': 30522, 'wind': 27568,'nuclear': 55103}, {'country': 'Spain','year': '2006','unit': 'GWh','solar': 119,'hydro': 29831,'wind': 23297,	'nuclear': 60126 }, {'country': 'Spain','year': '2005','unit': 'GWh','solar': 41,'hydro': 23025,'wind': 21176,'nuclear': 57539},{'country': 'Spain','year': '2004','unit': 'GWh','solar': 56,'hydro': 34439,'wind': 15700,'nuclear': 63606},{'country': 'Spain','year': '2003','unit': 'GWh','solar': 41,'hydro': 43897,'wind': 12075,'nuclear': 61875},{'country': 'Spain','year': '2002','unit': 'GWh','solar': 30,'hydro': 26270,'wind': 9342,'nuclear': 63016},{'country': 'Spain','year': '2001','unit': 'GWh','solar': 24,'hydro': 43864,'wind': 6759,'nuclear': 63708},{	'country': 'Spain','year': '2000','unit': 'GWh','solar': 18,'hydro': 31807,'wind': 4727,'nuclear': 62206}",
                success: function (data) {
                    var RadHtmlChart1 = $find('<%=rhcBarSeries.ClientID%>');
                    RadHtmlChart1.set_dataSource(data.d);
                    RadHtmlChart1.set_transitions(true);
                    RadHtmlChart1.repaint();
                }
            });
            }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT * FROM [Items]"></asp:SqlDataSource>
                </div>
                <table>
                    <tr>
                        <td>
                            <div>
                                <telerik:RadHtmlChart runat="server" ID="rhcBarSeries" Width="600px" Height="400px" Skin="Silk"
                                    DataSourceID="SqlDataSource1">
                                    <PlotArea>
                                        <Series>
                                            <telerik:BarSeries Name="Products" DataFieldY="Cost">
                                                <TooltipsAppearance Color="White" DataFormatString="${0}"></TooltipsAppearance>
                                                <LabelsAppearance Visible="false">
                                                </LabelsAppearance>
                                            </telerik:BarSeries>
                                        </Series>

                                        <XAxis DataLabelsField="Name">
                                            <TitleAppearance Text="Products"></TitleAppearance>
                                        </XAxis>
                                        <YAxis>
                                            <LabelsAppearance DataFormatString="${0}"></LabelsAppearance>
                                            <TitleAppearance Text="Cost"></TitleAppearance>
                                        </YAxis>
                                    </PlotArea>
                                    <Legend>
                                        <Appearance Visible="false"></Appearance>
                                    </Legend>
                                    <ChartTitle Text="Cost for Products"></ChartTitle>
                                </telerik:RadHtmlChart>
                            </div>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadHtmlChart runat="server" ID="rhcAreaSeries" Width="1200px" Height="400px" Skin="Web20">
                                <PlotArea>
                                    <Series>
                                        <telerik:AreaSeries Name="Products" DataFieldY="BOMCounter">
                                            <TooltipsAppearance Color="White"></TooltipsAppearance>
                                            <LabelsAppearance Visible="false">
                                            </LabelsAppearance>
                                        </telerik:AreaSeries>
                                    </Series>

                                    <XAxis DataLabelsField="ItemId">
                                        <TitleAppearance Text="Bom Products"></TitleAppearance>
                                    </XAxis>
                                    <YAxis>
                                        <LabelsAppearance></LabelsAppearance>
                                        <TitleAppearance Text="Counter"></TitleAppearance>
                                    </YAxis>
                                </PlotArea>
                                <Legend>
                                    <Appearance Visible="false"></Appearance>
                                </Legend>
                                <ChartTitle Text="Counter for BOM Products"></ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <telerik:RadHtmlChart runat="server" ID="rhcLineSeries" Width="600px" Height="400px"
                                    Skin="Silk" DataSourceID="SqlDataSource1">
                                    <PlotArea>
                                        <Series>
                                            <telerik:LineSeries DataFieldY="Cost">
                                                <LabelsAppearance>
                                                    <ClientTemplate>
                                            #= value # JD for #= kendo.format(\'{0:d}\', category) #
                                                    </ClientTemplate>
                                                </LabelsAppearance>
                                                <TooltipsAppearance Color="White">
                                                    <ClientTemplate>
                                             #= value # JD for <br />#= kendo.format(\'{0:d}\', category) #
                                                    </ClientTemplate>
                                                </TooltipsAppearance>
                                            </telerik:LineSeries>
                                        </Series>
                                        <XAxis DataLabelsField="Name" Type="Auto">
                                            <TitleAppearance Text="Products"></TitleAppearance>
                                        </XAxis>
                                        <YAxis Step="100">
                                            <TitleAppearance Text="Cost"></TitleAppearance>
                                        </YAxis>
                                    </PlotArea>
                                    <ChartTitle Text="Cost for Products"></ChartTitle>
                                </telerik:RadHtmlChart>
                            </div>
                        </td>
                        <td>
                            <telerik:RadHtmlChart runat="server" ID="rhcFunnelSeries" Width="600px" Height="400px" Skin="Silk" DataSourceID="SqlDataSource1" Style="text-align: right">
                                <PlotArea>
                                    <Series>
                                        <telerik:FunnelSeries DynamicSlopeEnabled="false" DynamicHeightEnabled="true" SegmentSpacing="5" NeckRatio="0.4" DataFieldY="Cost" DataNameField="Name">
                                        </telerik:FunnelSeries>
                                    </Series>
                                </PlotArea>
                                <ChartTitle Text="Cost for Products">
                                </ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadHtmlChart runat="server" ID="rhcPieSeries" Width="600px" Height="400px" Skin="Silk" DataSourceID="SqlDataSource1" Style="text-align: right">
                                <PlotArea>
                                    <Series>
                                        <telerik:PieSeries StartAngle="90" DataFieldY="Cost" ExplodeField="Name" NameField="Name">
                                            <LabelsAppearance Position="OutsideEnd" DataFormatString="{0} %" />
                                            <TooltipsAppearance DataFormatString="{0} %" />

                                        </telerik:PieSeries>
                                    </Series>
                                </PlotArea>
                                <ChartTitle Text="Cost for Products">
                                </ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>
                        <td>
                            <telerik:RadHtmlChart runat="server" ID="rhcDonutSeries" Width="600px" Height="400px" Skin="Silk" DataSourceID="SqlDataSource1" Style="text-align: right">
                                <Appearance>
                                    <FillStyle BackgroundColor="White"></FillStyle>
                                </Appearance>
                                <PlotArea>
                                    <Series>
                                        <telerik:DonutSeries HoleSize="50" DataFieldY="Cost" NameField="Name" ExplodeField="Name">
                                            <LabelsAppearance DataField="Cost">
                                            </LabelsAppearance>
                                            <TooltipsAppearance DataFormatString="{0}%" BackgroundColor="White"></TooltipsAppearance>
                                        </telerik:DonutSeries>
                                    </Series>
                                </PlotArea>
                                <ChartTitle Text="Cost for Products">
                                </ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Width="600px" Height="400px" Skin="Silk" DataSourceID="SqlDataSource1" Style="text-align: right">
                                <PlotArea>
                                    <Series>
                                        <telerik:WaterfallSeries DataFieldY="Cost">

                                            <LabelsAppearance Visible="true"></LabelsAppearance>
                                        </telerik:WaterfallSeries>
                                    </Series>
                                    <XAxis DataLabelsField="Name" Type="Auto">
                                        <TitleAppearance Text="Products"></TitleAppearance>
                                    </XAxis>
                                    <YAxis Step="100">
                                        <TitleAppearance Text="Cost"></TitleAppearance>
                                    </YAxis>
                                </PlotArea>
                                <ChartTitle Text="Cost for Products">
                                </ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>
                        <td>
                            <telerik:RadHtmlChart runat="server" ID="rhcWaterfallSeries" Width="600px" Height="400px" Skin="Silk" DataSourceID="SqlDataSource1" Style="text-align: right">
                                <PlotArea>
                                    <Series>
                                        <telerik:LineSeries Name="Week 15" MissingValues="Interpolate" DataFieldY="">
                                            <Appearance>
                                                <FillStyle BackgroundColor="Blue" />
                                            </Appearance>
                                            <LabelsAppearance DataFormatString="{0}%" Position="Above" />
                                            <MarkersAppearance MarkersType="Square" BackgroundColor="Blue" />
                                            <SeriesItems>
                                                <telerik:CategorySeriesItem Y="15" />
                                                <telerik:CategorySeriesItem Y="23" />
                                                <telerik:CategorySeriesItem />
                                                <telerik:CategorySeriesItem Y="71" />
                                                <telerik:CategorySeriesItem Y="93" />
                                                <telerik:CategorySeriesItem Y="43" />
                                                <telerik:CategorySeriesItem Y="23" />
                                            </SeriesItems>
                                        </telerik:LineSeries>
                                        <telerik:LineSeries Name="Week 16" MissingValues="Gap">
                                            <Appearance>
                                                <FillStyle BackgroundColor="Red" />
                                            </Appearance>
                                            <LabelsAppearance DataFormatString="{0}%" Position="Above" />
                                            <MarkersAppearance MarkersType="Square" BackgroundColor="Red" />
                                            <SeriesItems>
                                                <telerik:CategorySeriesItem Y="35" />
                                                <telerik:CategorySeriesItem Y="42" />
                                                <telerik:CategorySeriesItem Y="18" />
                                                <telerik:CategorySeriesItem Y="39" />
                                                <telerik:CategorySeriesItem Y="64" />
                                                <telerik:CategorySeriesItem Y="10" />
                                                <telerik:CategorySeriesItem Y="6" />
                                            </SeriesItems>
                                        </telerik:LineSeries>
                                    </Series>
                                    <XAxis DataLabelsField="Name" Type="Auto">
                                        <TitleAppearance Text="Products"></TitleAppearance>
                                    </XAxis>
                                    <YAxis Step="100">
                                        <TitleAppearance Text="Cost"></TitleAppearance>
                                    </YAxis>
                                </PlotArea>
                                <ChartTitle Text="Cost for Products">
                                </ChartTitle>
                            </telerik:RadHtmlChart>
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
