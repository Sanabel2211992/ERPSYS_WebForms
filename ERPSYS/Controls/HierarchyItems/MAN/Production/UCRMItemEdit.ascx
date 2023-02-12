<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRMItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.MAN.Production.UCRMItemEdit" %>
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
        <td class="ft-gedit">Description :</td>
        <td class="fv-gedit" colspan="5">
            <asp:Label ID="lblItemDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit">Quantity :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px" MinValue="0" MaxValue="999999">
                <NumberFormat DecimalDigits="3"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvsItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="update" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvsItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="update" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
    </tr>
</table>
<div class="d-grid-op">
    <div class="sm-so-me-p">
        <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="update" CssClass="btn-Add-edit" CommandName="Update"></asp:Button>&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
    </div>
</div>
<asp:HiddenField ID="hfItemID" Value='<%# Bind("ItemId") %>' runat="server" />
