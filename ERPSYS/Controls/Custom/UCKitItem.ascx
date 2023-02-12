<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCKitItem.ascx.cs" Inherits="ERPSYS.Controls.Custom.UCKitItem" %>
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
<telerik:RadAjaxPanel runat="server" ID="rjpPurchaseItem" LoadingPanelID="lpLoading">
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Add Item</legend>
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
                    <asp:CustomValidator ID="cvItem" runat="server" ClientValidationFunction="Validate" CssClass="val-error" Display="Dynamic" ErrorMessage="Please select a valid item !!"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="uc-field-title">Item Search</td>
                <td class="uc-field-val" colspan="3">
                    <telerik:RadSearchBox runat="server" ID="rsbItem"
                        DataKeyNames="ItemCode,PartNumber,Name,Description,Category,UOM"
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
                    <asp:HiddenField ID="hfCategory" runat="server" />
                    <asp:HiddenField ID="hfUOM" runat="server" />

                </td>
            </tr>
            <tr>
                <td class="uc-field-title">Description</td>
                <td class="uc-field-val read-only" colspan="3">
                    <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uc-field-title">Part Number </td>
                <td class="uc-field-val read-only ">
                    <asp:TextBox ID="txtPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
                <td class="uc-field-title">Item Code</td>
                <td class="uc-field-val read-only">
                    <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uc-field-title">Quantity </td>
                <td class="uc-field-val">
                    <asp:TextBox ID="txtQuantity" runat="server" Width="125px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuanitiy" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvQuantity1" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" ErrorMessage="*" Display="Dynamic" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="uc-field-title"></td>
                <td class="uc-field-val">&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="uc-field-title"></td>
                <td class="uc-field-val">&nbsp;</td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </fieldset>
</telerik:RadAjaxPanel>
