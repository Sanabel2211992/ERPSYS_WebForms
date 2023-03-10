<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SCM.GoodsReceipt.UCItemEdit" %>
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
        <td class="ft-gedit">Unit :</td>
        <td class="fv-gedit read-only">
            <asp:DropDownList ID="ddlUOM" runat="server" Enabled="False" Width="150px">
            </asp:DropDownList>
        </td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
    </tr>
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
        <td class="ft-gedit">Remarks :</td>
        <td class="fv-gedit" colspan="3">
            <asp:TextBox ID="txtItemRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="400px"></asp:TextBox></td>
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
