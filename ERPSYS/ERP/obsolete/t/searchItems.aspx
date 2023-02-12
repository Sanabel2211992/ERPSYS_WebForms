<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchItems.aspx.cs" Inherits="ERPSYS.ERP.t.searchItems" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 212px">
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <%--   <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />--%>

        <%--        <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="RadSearchBox1"
            CssClass="searchBox" Skin="Silk"
            Width="460" DropDownSettings-Height="300"
            DataSourceID="SqlDataSource1"
            DataTextField="fullName"
            DataValueField="id"
            DataKeyNames="sport,birthday,country"
            EmptyMessage="Search"
            Filter="StartsWith"
            MaxResultCount="20"
            OnDataSourceSelect="RadSearchBox1_DataSourceSelect"
            OnSearch="RadSearchBox1_Search">
            <SearchContext DataTextField="name" DataKeyField="id" DropDownCssClass="contextDropDown"></SearchContext>
        </telerik:RadSearchBox>--%>

        <%--
        <telerik:RadSearchBox runat="server" ID="rsbItem"
            DataKeyNames="ItemCode,PartNumber,Description"
            DataTextField="DisplayName"
            DataValueField="ItemId"
            EnableAutoComplete="true"
            ShowSearchButton="true"
            Filter="StartsWith"
            MaxResultCount="20"
            Width="685px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
            <DropDownSettings Width="685px" />
        </telerik:RadSearchBox>--%>

        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />


        <telerik:RadNotification ID="rnMessage" runat="server" Overlay="true" VisibleOnPageLoad="False" Height="140px" Width="350px" ContentIcon="~/ERP/resources/images/ico_save_16.gif"
            Animation="Slide" EnableRoundedCorners="true" EnableShadow="true" AutoCloseDelay="1300" 
            Position="BottomRight" ShowCloseButton="true" Title="My Notification" TitleIcon="~/ERP/resources/images/message_logos.png" />

        <telerik:RadButton runat="server" ID="RadButton1" Text="Show Notification" OnClick="MyBtn_Click" />


        <telerik:RadGrid ID="RadGrid1" runat="server" DataSourceID="SqlDataSource1" GroupPanelPosition="Top">
            <MasterTableView EditMode="InPlace"
                DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridEditCommandColumn />
                    <telerik:GridBoundColumn DataField="First_Name" FilterControlAltText="Filter First_Name column" HeaderText="First_Name" SortExpression="First_Name" UniqueName="First_Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Last_Name" FilterControlAltText="Filter Last_Name column" HeaderText="Last_Name" SortExpression="Last_Name" UniqueName="Last_Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Email" FilterControlAltText="Filter Email column" HeaderText="Email" SortExpression="Email" UniqueName="Email">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Birthday" FilterControlAltText="Filter Birthday column" HeaderText="Birthday" SortExpression="Birthday" UniqueName="Birthday">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT * FROM [Employees]"></asp:SqlDataSource>
    </form>
</body>
</html>
