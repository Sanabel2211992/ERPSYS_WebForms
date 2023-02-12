<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGroupSubItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.Quote.UCGroupSubItemEdit" %>
<table style="width: 750px">
    <tr>
        <td style="width: 75px">&nbsp;</td>
        <td style="width: 110px"></td>
        <td style="width: 75px"></td>
        <td style="width: 110px"></td>
        <td style="width: 75px"></td>
        <td style="width: 110px"></td>
        <td style="width: 110px"></td>
    </tr>
    <tr>
        <td class="uc-field-title">Unit Price</td>
        <td class="uc-field-val">
            <asp:TextBox ID="txtItemUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="90px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="uc-field-title">Profit</td>
        <td class="uc-field-val">
            <asp:TextBox ID="txtItemProfit" runat="server" Text='<%# Bind("Profit") %>' Width="90px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

        </td>
        <td>Discount</td>
        <td>
            <asp:TextBox ID="txtItemDiscount" runat="server" Text='<%# Bind("Discount") %>' Width="90px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

        </td>
        <td class="relative">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="SubItem" CssClass="qg-edit-save btn-Add-edit" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="qg-edit-cancel btn-Add-edit" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
