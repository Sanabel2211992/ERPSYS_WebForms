<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemAdjust.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SM.DeliveryReceipt.UCMainItemAdjust" %>
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
            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("DescriptionAs") %>'></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit">Catalog Number :</td>
        <td class="fv-gedit">
            <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
        </td>
        <td class="ft-gedit">Part Number :</td>
        <td class="fv-gedit">
            <asp:Label ID="lblPartNumber" runat="server" Text='<%# Bind("PartNumber") %>'></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="ft-gedit">Unit Quantity :</td>
        <td class="fv-gedit">
            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
        </td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
    </tr>
    <tr>
        <td class="ft-gedit">Location :</td>
        <td class="fv-gedit">
            <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
        </td>
        <td class="ft-gedit">&nbsp;</td>
        <td class="fv-gedit">&nbsp;</td>
    </tr>
</table>
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
