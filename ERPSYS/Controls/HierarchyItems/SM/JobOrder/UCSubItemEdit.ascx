<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSubItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SM.JobOrder.UCSubItemEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        <td class="ft-gedit">Show As :</td>
        <td class="fv-gedit" colspan="5">
            <asp:TextBox ID="txtItemDescriptionAs" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="645px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvItemdescriptionAs" runat="server" ControlToValidate="txtItemDescriptionAs" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
        <td class="ft-gedit">Quantity :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px" MinValue="1" MaxValue="999999">
                <NumberFormat DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="SubItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
    </tr>
</table>
<div class="d-grid-op">
    <div class="sm-so-se-p">
        <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="SubItem" CssClass="btn-Add-edit" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
    </div>
</div>
