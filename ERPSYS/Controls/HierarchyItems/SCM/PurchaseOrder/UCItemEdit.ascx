<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SCM.PurchaseOrder.UCItemEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="tbl-uc-gedit" style="width: 600px">
    <tr>
        <th class="ft-gedit" style="width: 125px"></th>
        <th class="fv-gedit" style="width: 175px"></th>
        <th class="ft-gedit" style="width: 125px"></th>
        <th class="fv-gedit" style="width: 175px"></th>
    </tr>
    <tr>
        <td class="ft-gedit">Description :</td>
        <td class="fv-gedit" colspan="3">
            <asp:Label ID="lblItemDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit">Unit Price :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtItemUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="100px" MinValue="0" MaxValue="999999">
                <NumberFormat DecimalDigits="3"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="ft-gedit">Unit :</td>
        <td class="fv-gedit">
            <asp:DropDownList ID="ddlUOM" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
    </tr>
    <%--    <tr>
        <td class="ft-gedit">Discount</td>
        <td class="fv-gedit">

            <asp:TextBox ID="txtItemDiscount" runat="server" Text='<%# Bind("Discount") %>' Width="100px" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

        </td>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>--%>
    <tr>
        <td class="ft-gedit">Quantity :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" Width="100px" text='<%# Bind("Quantity") %>' MinValue="1" MaxValue="999999">
                <NumberFormat DecimalDigits="2"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
    </tr>
    <tr>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
        <td colspan="2" class="relative">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="SubItem" CssClass="btn-Add-edit s-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit s-edit-Cancel" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>
