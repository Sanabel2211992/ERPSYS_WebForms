<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.INV.StockTransfer.UCItemEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

 <table class="tbl-uc-gedit" style="width: 900px">
        <tr>
            <td class="ft-gedit" style="width: 125px"></td>
            <td class="fv-gedit" style="width: 175px"></td>
            <td class="ft-gedit" style="width: 125px"></td>
            <td class="fv-gedit" style="width: 175px"></td>
            <td class="ft-gedit" style="width: 125px"></td>
            <td class="fv-gedit" style="width: 175px"></td>
        </tr>
    <tr>
        <td class="ft-gedit">Quantity :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtgItemQuantity" Text='<%# Bind("Quantity") %>' runat="server" Width="100px" MinValue="1" MaxValue="999999">
                <NumberFormat DecimalDigits="3"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvgItemQuantity" runat="server" ControlToValidate="txtgItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvgItemQuantity" runat="server" ControlToValidate="txtgItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="save" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
        </td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
    </tr>
    <tr>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
    </tr>
</table>
<div class="d-grid-op">
    <div class="inv-st-e-p">
        <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="save" CssClass="btn-Add-edit m-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit m-edit-Cancel" CommandName="Cancel"></asp:Button>
    </div>
</div>
<asp:HiddenField ID="hfItemID" Value='<%# Bind("ItemId") %>' runat="server" />
