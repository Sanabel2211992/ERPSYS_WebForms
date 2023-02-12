<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRItemAdd.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.MAN.Material.UCRItemAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
    <table class="tbl-uc-gedit" style="width: 900px">
        <tr>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
        </tr>
        <tr>
            <td style="width: 125px"></td>
            <td colspan="5">
                <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="add" ErrorMessage="Please select a valid Product !!"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Product Search :</td>
            <td class="fv-gedit" style="position: relative" colspan="5">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="ItemCode,PartNumber,Description,StockQuantity"
                    DataTextField="DisplayName"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="true"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="675px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="675px" />
                </telerik:RadSearchBox>
                <asp:HiddenField ID="hfItemID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Description :</td>
            <td class="fv-gedit read-only" colspan="5">
                <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="675px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Part Number : </td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtItemPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit">Catalog Number :</td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Store Quantity :</td>
            <td class="fv-gedit read-only" colspan="5">
                <asp:TextBox ID="txtStockQuantity" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                (Quantity in Production store)
        </tr>
        <tr>
            <td class="ft-gedit">Quantity :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" MaxValue="999999" MinValue="0" Width="100px">
                    <NumberFormat DecimalDigits="3" />
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValidationGroup="add" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<div class="d-grid-op">
    <div class="sm-so-ma-p">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" CssClass="btn-Add-edit" CommandName="PerformInsert" />&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
    </div>
</div>
