<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SM.JobOrder.UCMainItemEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlSingle" runat="server" Visible="false">
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
                <asp:TextBox ID="txtsMainItemDescription" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvsMainItemDescription" runat="server" ControlToValidate="txtsMainItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Quantity :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtsMainItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px" MinValue="1" MaxValue="999999">
                    <NumberFormat DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvsMainItemQuantity" runat="server" ControlToValidate="txtsMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsMainItemQuantity" runat="server" ControlToValidate="txtsMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlGroup" runat="server" Visible="false">
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
            <td class="ft-gedit">Description :</td>
            <td class="fv-gedit" colspan="5">
                <asp:TextBox ID="txtgMainItemDescription" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvgMainItemDescription" runat="server" ControlToValidate="txtgMainItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Quantity :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtgMainItemQuantity" runat="server" Text='<%# Bind("Quantity") %>' Width="100px" MinValue="1" MaxValue="999999">
                    <NumberFormat DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvgMainItemQuantity" runat="server" ControlToValidate="txtgMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvgMainItemQuantity" runat="server" ControlToValidate="txtgMainItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
<div class="d-grid-op">
    <div class="sm-so-me-p">
        <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="MainItem" CssClass="btn-Add-edit" CommandName="Update"></asp:Button>&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
    </div>
</div>
<asp:HiddenField ID="hfItemID" Value='<%# Bind("ItemId") %>' runat="server" />