<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.Quote.UCMainItemEdit" %>
<asp:Panel ID="pnlSingle" runat="server" Visible="false">
    <table style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
        </tr>
        <tr>
            <td class="uc-field-title">Description</td>
            <td class="uc-field-val" colspan="3">
                <asp:TextBox ID="txtsMainItemDescription" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvsMainItemDescription" runat="server" ControlToValidate="txtsMainItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Unit Price</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtsMainItemUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvsMainItemUnitPrice" runat="server" ControlToValidate="txtsMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsMainItemUnitPrice" runat="server" ControlToValidate="txtsMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="uc-field-title">Profit</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtsMainItemProfit" runat="server" Text='<%# Bind("Profit") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvsItemProfit" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsItemProfit1" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvsItemProfit2" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Discount</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtsMainItemDiscount" runat="server" Text='<%# Bind("Discount") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvsItemDiscount" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsItemDiscount1" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvsItemDiscount2" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Quantity</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtsMainItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvsMainItemQuantity" runat="server" ControlToValidate="txtsMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsMainItemQuantity" runat="server" ControlToValidate="txtsMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlGroup" runat="server" Visible="false">
    <table style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
        </tr>
        <tr>
            <td class="uc-field-title">Description</td>
            <td class="uc-field-val" colspan="3">
                <asp:TextBox ID="txtgMainItemDescription" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvgMainItemDescription" runat="server" ControlToValidate="txtgMainItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="uc-field-title">Unit Price</td>
            <td class="uc-field-val read-only">
                <asp:TextBox ID="txtgMainItemUnitPrice" Enabled="False" runat="server" Text='<%# Bind("NetPrice") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvgMainItemUnitPrice" runat="server" ControlToValidate="txtgMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvgMainItemUnitPrice" runat="server" ControlToValidate="txtgMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="uc-field-title">Quantity</td>
            <td class="uc-field-val">
                <asp:TextBox ID="txtgMainItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvgMainItemQuantity" runat="server" ControlToValidate="txtgMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvgMainItemQuantity" runat="server" ControlToValidate="txtgMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<table class="tbl-ucsearch" style="width: 600px">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td colspan="2" class="relative">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="MainItem" CssClass="btn-Add-edit m-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit m-edit-Cancel" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>
<asp:HiddenField ID="hfItemID" Value='<%# Bind("ItemId") %>' runat="server" />
