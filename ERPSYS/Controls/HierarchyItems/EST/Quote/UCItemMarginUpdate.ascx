<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemMarginUpdate.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.EST.Quote.UCItemMarginUpdate" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
    <table class="tbl-uc-gedit" style="width: 500px">
        <tr>
            <th class="ft-gedit" style="width: 100px"></th>
            <th class="fv-gedit" style="width: 150px"></th>
            <th class="ft-gedit" style="width: 100px"></th>
            <th class="fv-gedit" style="width: 150px"></th>
        </tr>
        <tr>
            <td class="ft-gedit">Profit :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemProfit" runat="server" Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>                <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">Discount :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemDiscount" runat="server" Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>                <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>