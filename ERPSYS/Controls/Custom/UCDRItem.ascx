<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDRItem.ascx.cs" Inherits="ERPSYS.Controls.Custom.UCDRItem" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function Validate(sender, args) {
            if ($('#<%= hfItemID.ClientID %>').val() === "") {
                args.IsValid = false;
            }
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpDRItem" LoadingPanelID="lpLoading">
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Add Item</legend>
        <table class="tbl-ucsearch" style="width: 600px">
            <tr>
                <td class="uc-ft-view" style="width: 125px"></td>
                <td class="uc-field-val" style="width: 175px"></td>
                <td class="uc-ft-view" style="width: 125px"></td>
                <td class="uc-field-val" style="width: 175px"></td>
            </tr>
            <tr>
                <td style="width: 125px"></td>
                <td colspan="3">
                    <asp:CustomValidator ID="cvItem" runat="server" ClientValidationFunction="Validate" CssClass="val-error" Display="Dynamic" ErrorMessage="Please select a valid item !"></asp:CustomValidator>
                    <asp:CompareValidator ID="cvCheck" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="You don't have enough Quantity in the store !" Operator="LessThanEqual" Type="Double" ValueToCompare="0" ControlToCompare="txtAvailableQuantity"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view">Item Search</td>
                <td class="uc-field-val" colspan="3">
                    <telerik:RadSearchBox runat="server" ID="rsbItem"
                        DataKeyNames="ItemCode,PartNumber,Name,Description,AvailableQuantity,Uom,Category"
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
                    <asp:HiddenField ID="hfLocationId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view">Description</td>
                <td class="uc-field-val read-only" colspan="3">
                    <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view">Part Number </td>
                <td class="uc-field-val read-only">
                    <asp:TextBox ID="txtPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
                <td class="uc-ft-view">Item Code</td>
                <td class="uc-field-val read-only">
                    <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view">Show As</td>
                <td class="uc-field-val" colspan="3">
                    <asp:TextBox ID="txtDescriptionAs" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvdescriptionAs" runat="server" ControlToValidate="txtDescriptionAs" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view">Available Qty</td>
                <td class="uc-field-val read-only">
                    <asp:TextBox ID="txtAvailableQuantity" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="uc-ft-view">Quantity</td>
                <td class="uc-field-val">
                    <asp:TextBox ID="txtQuantity" runat="server" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="uc-ft-view"></td>
                <td class="uc-field-val">&nbsp;</td>
                <td class="uc-ft-view"></td>
                <td class="uc-field-val">&nbsp;</td>
            </tr>
            <tr>
                <td class="uc-ft-view"></td>
                <td class="uc-field-val">&nbsp;</td>
                <td class="uc-ft-view"></td>
                <td class="uc-field-val">&nbsp;</td>
            </tr>
        </table>
    </fieldset>
</telerik:RadAjaxPanel>
