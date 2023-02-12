<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGroupSubItemUpdate.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.EST.Quote.UCGroupSubItemUpdate" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function ClearFieldsD() {
            $('#<%= hfItemID.ClientID %>').val("");
            $('#<%= rsbItem.ClientID %>').val("");
            $('#<%= txtItemPartNumber.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtItemDescription.ClientID %>').val("");

            $('#<%= txtItemUnitPrice.ClientID %>').val("0.00");
            $('#<%= txtItemProfit.ClientID %>').val("0.00");
            $('#<%= txtItemDiscount.ClientID %>').val("0.00");

            var searchBox = window.$find("<%= rsbItem.ClientID %>"),
            inputElement = window.$telerik.$(searchBox.get_inputElement());
            inputElement.val("");
        }
    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
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
            <td></td>
            <td colspan="5">
                <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="Please select a valid Product !!"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Product Search :</td>
            <td class="fv-gedit" colspan="5">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="ItemCode,PartNumber,Name,Description,UnitPrice"
                    DataTextField="DisplayName"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="true"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="680px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="680px" />
                </telerik:RadSearchBox>
                <img alt="clear" title="Clear Fields" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_clear_16_16.png" onclick="ClearFieldsD(); return false;" />
                <asp:HiddenField ID="hfItemID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Description :</td>
            <td class="fv-gedit read-only" colspan="5">
                <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="675px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Part Number :</td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtItemPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit">Catalog Number :</td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Unit Price :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemUnitPrice" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">Profit :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemProfit" runat="server" Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Discount :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtItemDiscount" runat="server" Width="100px" MinValue="0" MaxValue="1">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
