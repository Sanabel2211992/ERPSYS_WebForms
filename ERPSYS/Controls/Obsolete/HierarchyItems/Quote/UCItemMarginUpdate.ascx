<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemMarginUpdate.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.Quote.UCItemMarginUpdate" %>
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
            <td class="uc-field-title">Profit</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtItemProfit" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

            </td>
            <td class="uc-field-title">Discount</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtItemDiscount" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>