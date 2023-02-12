<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.Production.Assembly.UCItemEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="tbl-uc-gedit" style="width: 700px">
    <tr>
        <td class="gedit-field-title" style="width: 125px"></td>
        <td class="gedit-field-val" style="width: 175px"></td>
        <td class="gedit-field-title" style="width: 125px"></td>
        <td class="gedit-field-val" style="width: 175px"></td>
        <td class="gedit-field-val" style="width: 100px"></td>
    </tr>
    <tr>
        <td class="gedit-field-title">Quantity :</td>
        <td class="gedit-field-val">
            <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px" MinValue="1" MaxValue="999999">
                <NumberFormat DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvsMainItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvsMainItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="gedit-field-title">&nbsp;</td>
        <td class="gedit-field-val">
            &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
<div class="d-grid-op">
    <div class="ma-a-e-p">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="MainItem" CssClass="btn-Add-edit m-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit m-edit-Cancel" CommandName="Cancel"></asp:Button>
    </div>
</div>
<asp:HiddenField ID="hfItemBomID" Value='<%# Bind("ItemBomId") %>' runat="server" />
