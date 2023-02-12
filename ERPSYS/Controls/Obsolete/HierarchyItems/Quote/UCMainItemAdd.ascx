<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemAdd.ascx.cs" Inherits="ERPSYS.Controls.Obsolete.HierarchyItems.Quote.UCMainItemAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
    <table class="tbl-gedit" style="width: 600px">
        <tr>
            <td class="gedit-field-title" style="width: 125px"></td>
            <td class="gedit-field-val" style="width: 175px"></td>
            <td class="gedit-field-title" style="width: 125px"></td>
            <td class="gedit-field-val" style="width: 175px"></td>
        </tr>
        <tr>
            <td class="gedit-field-title">Item Type</td>
            <td class="gedit-field-val" colspan="3">
                <asp:RadioButtonList ID="rblMainItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblMainItemType_SelectedIndexChanged" RepeatDirection="Horizontal" Width="250px">
                    <asp:ListItem Selected="True" Value="Single">Single Item</asp:ListItem>
                    <asp:ListItem Value="Group">Group Of Items</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <asp:Panel ID="pnlSingle" runat="server" Visible="True">
            <tr>
                <td style="width: 125px"></td>
                <td colspan="3">
                    <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="Please select a valid item !!"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Item Search</td>
                <td class="gedit-field-val" colspan="3">
                    <telerik:RadSearchBox runat="server" ID="rsbItem"
                        DataKeyNames="ItemCode,PartNumber,Name,Description,UnitPrice"
                        DataTextField="DisplayName"
                        DataValueField="ItemId"
                        EnableAutoComplete="true"
                        ShowSearchButton="true"
                        Filter="StartsWith"
                        MaxResultCount="20"
                        Width="450px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                        <DropDownSettings Width="450px" />
                    </telerik:RadSearchBox>
                    <asp:HiddenField ID="hfItemID" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Description</td>
                <td class="gedit-field-val read-only" colspan="3">
                    <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Part Number </td>
                <td class="gedit-field-val read-only">
                    <asp:TextBox ID="txtItemPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
                <td class="gedit-field-title">Item Code</td>
                <td class="gedit-field-val read-only">
                    <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Show As</td>
                <td class="gedit-field-val" colspan="3">
                    <asp:TextBox ID="txtItemDescriptionAs" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemdescriptionAs" runat="server" ControlToValidate="txtItemDescriptionAs" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Unit Price</td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtItemUnitPrice" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="gedit-field-title">Quantity </td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtItemQuantity" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="gedit-field-title">Profit</td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtItemProfit" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

                </td>
                <td class="gedit-field-title">Discount</td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtItemDiscount" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlGroup" runat="server" Visible="False">
            <tr>
                <td class="gedit-field-title">Description</td>
                <td class="gedit-field-val" colspan="3">
                    <asp:TextBox ID="txtGroupItemDescription" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvGroupItemDescription" runat="server" ControlToValidate="txtGroupItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <%--<tr>
                <td class="gedit-field-title">Unit Price</td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtGroupItemUnitPrice" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGroupItemUnitPrice" runat="server" ControlToValidate="txtGroupItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvGroupItemUnitPrice" runat="server" ControlToValidate="txtGroupItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>--%>
            <tr>
                <td class="gedit-field-title">Quantity</td>
                <td class="gedit-field-val">
                    <asp:TextBox ID="txtGroupItemQuantity" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvGroupItemQuantity" runat="server" ControlToValidate="txtGroupItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvGroupItemQuantity" runat="server" ControlToValidate="txtGroupItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </asp:Panel>
    </table>
</telerik:RadAjaxPanel>
<table class="tbl-ucsearch" style="width: 600px">
    <tr>
        <td class="gedit-field-title" style="width: 125px">&nbsp;</td>
        <td class="gedit-field-val" style="width: 175px">&nbsp;</td>
        <td style="width: 125px">&nbsp;</td>
        <td style="width: 175px" class="relative">
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="addMainItem" CssClass="m-add-save btn-Add-edit" CommandName="PerformInsert" />&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="m-add-Cancel btn-Add-edit" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>

