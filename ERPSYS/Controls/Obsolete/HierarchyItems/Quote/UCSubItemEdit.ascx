<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSubItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.Quote.UCSubItemEdit" %>
<table style="width: 600px">
    <tr>
        <td style="width: 125px"></td>
        <td style="width: 175px"></td>
        <td style="width: 125px"></td>
        <td style="width: 175px"></td>
    </tr>
    <tr>
        <td class="uc-field-title">Show As</td>
        <td class="uc-field-val" colspan="3">
            <asp:TextBox ID="txtItemDescriptionAs" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemdescriptionAs" runat="server" ControlToValidate="txtItemDescriptionAs" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="uc-field-title">Unit Price</td>
        <td class="uc-field-val">
            <asp:TextBox ID="txtItemUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td>Quantity </td>
        <td>
            <asp:TextBox ID="txtItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="uc-field-title">Profit</td>
        <td class="uc-field-val">
            <asp:TextBox ID="txtItemProfit" runat="server" Text='<%# Bind("Profit") %>' Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

        </td>
        <td>Discount</td>
        <td>
            <asp:TextBox ID="txtItemDiscount" runat="server" Text='<%# Bind("Discount") %>' Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td colspan="2" class="relative">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="SubItem" CssClass="btn-Add-edit s-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit s-edit-Cancel" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>
