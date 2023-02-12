<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="ERPSYS.ERP.t.TestPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        // $(function () {
        //     RadHtmlChartData();
        // });

        // function RadHtmlChartData() {

        //     $.ajax({
        //         type: "POST",
        //         dataType: "json",
        //         contentType: "application/json; charset=utf-8",
        //         url: "TestPage.aspx/Chart",
        //         data: "{}"
        //     });
        //}


        //$(function () {
        //    GetCustomers();
        //});

        //function GetCustomers() {
            $.ajax({
                type: "POST",
                url: "TestPage.aspx/Chart",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(":)");
                },
                failure: function (response) {
                    alert(":(");
                },
                error: function (response) {
                    alert(":(");
                }
            });
        //}
    </script>

</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
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


    <telerik:RadClientDataSource ID="ClientDataSource2" runat="server">
        <SortExpressions>
            <telerik:ClientDataSourceSortExpression FieldName="execution-time" />
        </SortExpressions>
        <DataSource>
            <WebServiceDataSourceSettings ServiceType="GeoJSON">
                <Select Url="http://query.yahooapis.com/v1/public/yql?q=select%20%2a%20from%20yahoo.finance.quotes%20WHERE%20symbol%3D%27WRC%27&format=json&diagnostics=true&env=store://datatables.org/alltableswithkeys&callback" DataType="JSON" ContentType="application/json" />
            </WebServiceDataSourceSettings>
        </DataSource>
    </telerik:RadClientDataSource>

    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart2" Width="100%" ClientDataSourceID="ClientDataSource2">
        <Legend>
            <Appearance Position="Top"></Appearance>
        </Legend>
        <PlotArea>
            <Series>
                <telerik:LineSeries DataFieldY="execution-start-time" Name="start">
                    <LabelsAppearance Visible="false"></LabelsAppearance>
                </telerik:LineSeries>
                <telerik:LineSeries DataFieldY="execution-stop-time" Name="stop">
                    <LabelsAppearance Visible="false"></LabelsAppearance>
                </telerik:LineSeries>
            </Series>
            <XAxis DataLabelsField="execution-time">
                <LabelsAppearance RotationAngle="-90"></LabelsAppearance>
            </XAxis>
            <YAxis Step="10000"></YAxis>
            <CommonTooltipsAppearance Shared="true" Visible="true"></CommonTooltipsAppearance>
        </PlotArea>
    </telerik:RadHtmlChart>



    <telerik:RadClientDataSource ID="ClientDataSource1" runat="server">
        <SortExpressions>
            <telerik:ClientDataSourceSortExpression FieldName="year" SortOrder="Asc" />
        </SortExpressions>
        <DataSource>
            <WebServiceDataSourceSettings ServiceType="GeoJSON">
                <Select Url="spain-electricity.json" DataType="JSON" ContentType="application/json" />
            </WebServiceDataSourceSettings>
        </DataSource>
    </telerik:RadClientDataSource>

    <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Width="100%" ClientDataSourceID="ClientDataSource1">
        <ChartTitle Text="Spain electricity production (GWh)"></ChartTitle>
        <Legend>
            <Appearance Position="Top"></Appearance>
        </Legend>
        <PlotArea>
            <Series>
                <telerik:LineSeries DataFieldY="nuclear" Name="nuclear">
                    <LabelsAppearance Visible="false"></LabelsAppearance>
                </telerik:LineSeries>
                <telerik:LineSeries DataFieldY="hydro" Name="hydro">
                    <LabelsAppearance Visible="false"></LabelsAppearance>
                </telerik:LineSeries>
                <telerik:LineSeries DataFieldY="wind" Name="wind">
                    <LabelsAppearance Visible="false"></LabelsAppearance>
                </telerik:LineSeries>
            </Series>
            <XAxis DataLabelsField="year">
                <LabelsAppearance RotationAngle="-90"></LabelsAppearance>
            </XAxis>
            <YAxis Step="10000"></YAxis>
            <CommonTooltipsAppearance Shared="true" Visible="true"></CommonTooltipsAppearance>
        </PlotArea>
    </telerik:RadHtmlChart>
</asp:Content>
