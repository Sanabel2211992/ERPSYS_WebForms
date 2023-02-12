<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerSB.ascx.cs" Inherits="ERPSYS.Controls.SearchBox.UCCustomerSB" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="AjaxPanel1" runat="server">
    <table width="400">
        <tr>
            <td>Customer :</td>
            <td>
                <telerik:RadSearchBox runat="server" ID="rsbCustomer"
                    DataKeyNames="Phone,Email"
                    DataTextField="Name"
                    DataValueField="CustomerId"
                    EnableAutoComplete="true"
                    ShowSearchButton="false"
                    EmptyMessage="Search"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    OnSearch="rsbCustomer_Search" OnDataSourceSelect="rsbCustomer_DataSourceSelect" OnLoad="rsbCustomer_Load" Width="300px">
                    <DropDownSettings Width="300" />
                </telerik:RadSearchBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCustomerId" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCustomerName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblPhone" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
