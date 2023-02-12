<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemAdd.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SCM.PurchaseInvoice.UCItemAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function Validate(sender, args) {
            if ($('#<%= hfItemID.ClientID %>').val() === "") {
                args.IsValid = false;
            }
        }

        function OpenDialog() {
            var manager = window.$find("<%= rwmItem.ClientID %>");
            manager.open("../../Controls/DialogBox/SCM/PurchaseInvoice/ItemSearch.aspx", "rwItemSearch");
        }

        function OnItemClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    displayname = arg.displayname,
                    description = arg.description,
                    partnumber = arg.partnumber,
                    itemcode = arg.itemcode,
                    uomid = arg.uomid;

                $('#<%= hfItemID.ClientID %>').val(id);
                $('#<%= txtDescription.ClientID %>').val(description);
                $('#<%= txtPartNumber.ClientID %>').val(partnumber);
                $('#<%= txtItemCode.ClientID %>').val(itemcode);
                $('#<%= txtUnitPrice.ClientID %>').val("0");
                $('#<%= ddlUOM.ClientID %>').val(uomid);
                $('#<%= txtQuantity.ClientID %>').val(1);

                var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                    inputElement = window.$telerik.$(searchBox.get_inputElement());
                inputElement.val(displayname);
            }
        }

        function ClearFields() {
            $('#<%= hfItemID.ClientID %>').val("");
            $('#<%= txtDescription.ClientID %>').val("");
            $('#<%= txtPartNumber.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtUnitPrice.ClientID %>').val("0");
            $('#<%= ddlUOM.ClientID %>').val("1");
            $('#<%= txtQuantity.ClientID %>').val("1");

            var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                inputElement = window.$telerik.$(searchBox.get_inputElement());
            inputElement.val("");
        }
    </script>
</telerik:RadScriptBlock>

<telerik:RadAjaxPanel runat="server" ID="rjpPurchaseItem" LoadingPanelID="lpLoading">
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
            <td colspan="6">
                <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="add" ErrorMessage="Please select a valid Product !!"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Product Search :</td>
            <td class="fv-gedit" style="position: relative" colspan="5">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="Description,PartNumber,ItemCode,PurchaseUomId,PurchaseUom"
                    DataTextField="DisplayName"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="true"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="700px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="700px" />
                </telerik:RadSearchBox>
                <asp:HiddenField ID="hfItemID" runat="server" />
                <asp:HiddenField ID="hfPurchaseUomId" runat="server" />
                <asp:HiddenField ID="hfPurchaseUom" runat="server" />
                <div style="position: absolute; left: 710px; top: 5px">
                    <img alt="catalog" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_item_16.gif" onclick="OpenDialog(); return false;" />
                </div>
                <div style="position: absolute; left: 732px; top: 5px">
                    <img alt="clear" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_clear_16_16.png" onclick="ClearFields(); return false;" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Description :</td>
            <td class="fv-gedit read-only" colspan="5">
                <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True" Width="700px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Part Number :</td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtPartNumber" ReadOnly="True" runat="server" Width="150px"></asp:TextBox></td>
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
                <telerik:RadNumericTextBox ID="txtUnitPrice" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                    <NumberFormat DecimalDigits="3"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtUnitPrice" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvUnitPrice" runat="server" ControlToValidate="txtUnitPrice" CssClass="val-error" ErrorMessage="*" Display="Dynamic" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit">Unit :</td>
            <td class="fv-gedit read-only">
                <asp:DropDownList ID="ddlUOM" runat="server" Enabled="False" Width="150px">
                </asp:DropDownList>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Quantity :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Width="100px" MinValue="1" MaxValue="999999">
                    <NumberFormat DecimalDigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvQuanitiy" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvQuantity1" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" ErrorMessage="*" Display="Dynamic" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<div class="d-grid-op">
    <div class="sm-so-ma-p">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" CssClass="btn-Add-edit" CommandName="PerformInsert" />&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit" CommandName="Cancel"></asp:Button>
    </div>
</div>
<telerik:RadWindowManager ID="rwmItem" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" RenderMode="Lightweight" runat="server">
    <Windows>
        <telerik:RadWindow ID="rwItemSearch" RenderMode="Lightweight" runat="server" Modal="True"
            AutoSize="False" Width="835px" Height="550px" MaxWidth="835px" MaxHeight="550" OnClientClose="OnItemClose"
            Behaviors="Move, Close" Title="Product Search">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
