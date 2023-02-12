<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGroupSubItemDelete.ascx.cs" Inherits="ERPSYS.Controls.Obsolete.HierarchyItems.Quote.UCGroupSubItemDelete" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
    <table class="tbl-ucsearch" style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
        </tr>
        <tr>
            <td style="width: 125px"></td>
            <td colspan="3">
                <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="Please select a valid item !!"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Item Search</td>
            <td class="uc-field-val" colspan="3">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="ItemCode,PartNumber,Name,Description,UnitPrice"
                    DataTextField="DisplayName"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="true"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="450px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="450px" />
                </telerik:RadSearchBox>
                <asp:HiddenField ID="hfItemID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Description</td>
            <td class="uc-field-val read-only" colspan="3">
                <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="450px"></asp:TextBox>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>

