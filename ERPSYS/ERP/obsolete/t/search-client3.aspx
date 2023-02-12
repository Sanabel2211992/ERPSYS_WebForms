<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="search-client3.aspx.cs" Inherits="ERPSYS.ERP.t.search_client3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxPanel runat="server" ID="rjpClient" EnableTheming="True">
        <fieldset>
            <legend class="fs-inner-legend">Client Information</legend>
            <table class="tbl-main" style="width: 600px">
                <tr>
                    <td class="field-title" style="width: 125px"></td>
                    <td class="field-val" style="width: 175px"></td>
                    <td class="field-title" style="width: 100px"></td>
                </tr>
                <tr>
                    <td class="field-title">Client Name :</td>
                    <td colspan="2">
                        <telerik:RadSearchBox runat="server" ID="rsbClient"
                            DataKeyNames="Name,Country,City"
                            DataTextField="Name"
                            DataValueField="ClientId"
                            EnableAutoComplete="true"
                            ShowSearchButton="false"
                            Filter="StartsWith"
                            MaxResultCount="20"
                            Width="350px" OnDataSourceSelect="rsbClient_DataSourceSelect" OnLoad="rsbClient_Load" OnSearch="rsbClient_Search">
                            <DropDownSettings Width="350px" />
                        </telerik:RadSearchBox>
                    </td>
                </tr>
                <tr>
                    <td class="field-title">Contact Name :</td>
                    <td colspan="2">
                        <telerik:RadSearchBox runat="server" ID="rsbContact"
                            DataKeyNames="ContactName,Country,City,JobTitle"
                            DataTextField="ContactName"
                            DataValueField="ContactId"
                            EnableAutoComplete="true"
                            ShowSearchButton="false"
                            Filter="StartsWith"
                            MaxResultCount="20"
                            Width="350px" OnDataSourceSelect="rsbContact_DataSourceSelect" OnLoad="rsbContact_Load">
                            <DropDownSettings Width="350px" />
                        </telerik:RadSearchBox>
                    </td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
</asp:Content>
