<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.PROJ.UCEdit" %>
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
            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit">Amount :</td>
        <td class="fv-gedit">
            <telerik:RadNumericTextBox ID="txtAmount" runat="server" Text='<%# Bind("Amount") %>' Width="100px" MinValue="0" MaxValue="999999">
                <NumberFormat DecimalDigits="3"></NumberFormat>
            </telerik:RadNumericTextBox>
            <asp:RequiredFieldValidator ID="rfvsMainItemQuantity" runat="server" ControlToValidate="txtAmount" CssClass="val-error" Display="Dynamic" ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
    </tr>
    <tr>
        <td class="ft-gedit"></td>
        <td class="fv-gedit"></td>
        <td colspan="2">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="save" CssClass="btn-Add-edit" CommandName="Update" ></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>


