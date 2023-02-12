<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.EST.Quote.UCMainItemEdit" %>
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
            <td class="ft-gedit">Unit Price :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtsMainItemUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="100px" MinValue="0" MaxValue="999999">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvsMainItemUnitPrice" runat="server" ControlToValidate="txtsMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsMainItemUnitPrice" runat="server" ControlToValidate="txtsMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
        </tr>
        <tr>
            <td class="ft-gedit">Profit :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtsMainItemProfit" runat="server" Text='<%# Bind("Profit") %>' Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvsItemProfit" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsItemProfit1" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvsItemProfit2" runat="server" ControlToValidate="txtsMainItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
        </tr>
        <tr>
            <td class="ft-gedit">Discount :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtsMainItemDiscount" runat="server" Text='<%# Bind("Discount") %>' Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvsItemDiscount" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvsItemDiscount1" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvsItemDiscount2" runat="server" ControlToValidate="txtsMainItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
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
                <asp:TextBox ID="txtgMainItemDescription" runat="server" Text='<%# Bind("DescriptionAs") %>' Width="450px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvgMainItemDescription" runat="server" ControlToValidate="txtgMainItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Unit Price :</td>
            <td class="fv-gedit read-only">
                <telerik:RadNumericTextBox ID="txtgMainItemUnitPrice" Enabled="False" runat="server" Width="100px" Text='<%# Bind("NetPrice") %>' MinValue="0" MaxValue="999999">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvgMainItemUnitPrice" runat="server" ControlToValidate="txtgMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvgMainItemUnitPrice" runat="server" ControlToValidate="txtgMainItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="MainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
            <td class="ft-gedit">&nbsp;</td>
            <td class="fv-gedit">&nbsp;</td>
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
        <tr>
            <td class="ft-gedit"></td>
            <td class="fv-gedit" colspan="3">
                <asp:CheckBox ID="cbEnableRoundUp" runat="server" Checked='<%# Bind("IsRoundUp") %>' ForeColor="Maroon" Text="Enable Round Up Group Price" />
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
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

