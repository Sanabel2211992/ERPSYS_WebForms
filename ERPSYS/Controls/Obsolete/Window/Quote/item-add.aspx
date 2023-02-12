﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/Window/Window.Master" AutoEventWireup="true" CodeBehind="item-add.aspx.cs" Inherits="ERPSYS.Controls.Window.Quote.ItemAdd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="dcpHead" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="wcphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function Validate(sender, args) {
                if ($('#<%= hfItemID.ClientID %>').val() === "") {
                    args.IsValid = false;
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
        <fieldset class="fs-inner">
            <legend class="fs-inner-legend">ِِ</legend>
            <table class="tbl-ucsearch" style="width: 600px">
                <tr>
                    <td class="uc-field-title" style="width: 125px"></td>
                    <td class="uc-field-val" style="width: 175px"></td>
                    <td class="uc-field-title" style="width: 125px"></td>
                    <td class="uc-field-val" style="width: 175px"></td>
                </tr>
                <tr>
                    <td style="width: 125px"></td>
                    <td colspan="3">
                        <asp:CustomValidator ID="cvItem" runat="server" ClientValidationFunction="Validate" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" Enabled="False" ErrorMessage="Please select a valid item !!"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Category</td>
                    <td class="uc-field-val">
                        <asp:DropDownList ID="ddlItemCategory" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td class="uc-field-title">Brand</td>
                    <td class="uc-field-val">
                        <asp:DropDownList ID="ddlItemBrand" runat="server" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Item Search</td>
                    <td class="uc-field-val" colspan="3">
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
                    <td class="uc-field-title">Description</td>
                    <td class="uc-field-val read-only" colspan="3">
                        <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Part Number </td>
                    <td class="uc-field-val read-only">
                        <asp:TextBox ID="txtItemPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                    </td>
                    <td class="uc-field-title">Item Code</td>
                    <td class="uc-field-val read-only">
                        <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Show As</td>
                    <td class="uc-field-val" colspan="3">
                        <asp:TextBox ID="txtItemDescriptionAs" runat="server" Width="450px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvItemdescriptionAs" runat="server" ControlToValidate="txtItemDescriptionAs" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Unit Price</td>
                    <td class="uc-field-val">
                        <asp:TextBox ID="txtItemUnitPrice" runat="server" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    </td>
                    <td class="uc-field-title">Quantity </td>
                    <td class="uc-field-val">
                        <asp:TextBox ID="txtItemQuantity" runat="server" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">Profit</td>
                    <td class="uc-field-val">
                        <asp:TextBox ID="txtItemProfit" runat="server" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

                    </td>
                    <td class="uc-field-title">Discount</td>
                    <td class="uc-field-val">
                        <asp:TextBox ID="txtItemDiscount" runat="server" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>

                    </td>
                </tr>
                <tr>
                    <td class="uc-field-title">&nbsp;</td>
                    <td class="uc-field-val">&nbsp;</td>
                    <td class="uc-field-title">&nbsp;</td>
                    <td class="uc-field-val">&nbsp;</td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
    <table class="tbl-ucsearch" style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px">&nbsp;</td>
            <td class="uc-field-val" style="width: 175px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="addItem" CssClass="btn-Add-edit" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>