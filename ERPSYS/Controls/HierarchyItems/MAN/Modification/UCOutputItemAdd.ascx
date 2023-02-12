<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOutputItemAdd.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.MAN.Modification.UCOutputItemAdd" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function Validate(sender, args) {
            if ($('#<%= hfItemID.ClientID %>').val() === "") {
                args.IsValid = false;
            }
        }

        function OpenDialogO() {
            var manager = window.$find("<%= rwManager.ClientID %>");
            manager.open("../../Controls/DialogBox/MAN/Modification/ItemSearch.aspx", "rwItemSearch");
        }

        function OnItemCloseO(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    displayname = arg.displayname,
                    description = arg.description,
                    partnumber = arg.partnumber,
                    itemcode = arg.itemcode,
                    quantity = arg.quantity;

                $('#<%= hfItemID.ClientID %>').val(id);
                $('#<%= txtDescription.ClientID %>').val(description);
                $('#<%= txtPartNumber.ClientID %>').val(partnumber);
                $('#<%= txtItemCode.ClientID %>').val(itemcode);
                $('#<%= txtStockQuantity.ClientID %>').val(quantity);
                $('#<%= txtQuantity.ClientID %>').val(1);

                var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                    inputElement = window.$telerik.$(searchBox.get_inputElement());
                inputElement.val(displayname);
            }
        }

        function ClearFieldsO() {
            $('#<%= hfItemID.ClientID %>').val(-1);
            $('#<%= txtDescription.ClientID %>').val("");
            $('#<%= txtPartNumber.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtQuantity.ClientID %>').val("");
            $('#<%= txtStockQuantity.ClientID %>').val("");

            var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                inputElement = window.$telerik.$(searchBox.get_inputElement());
            inputElement.val("");
        }

        function OpenStoreDialogO() {
            if ($('#<%= hfItemID.ClientID %>').val() !== "") {
                var itemId = $('#<%= hfItemID.ClientID %>').val();
                var manager = window.$find("<%= rwManager.ClientID %>");
                manager.open("../../Controls/DialogBox/INV/Stock/inv-item-qty.aspx?id=" + itemId, "rwmItemInfo");
            }
        }
    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpItem" LoadingPanelID="lpLoading">
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
            <th></th>
            <th colspan="5">
                <asp:CustomValidator ID="cvItem" ValidationGroup="save" runat="server" ClientValidationFunction="Validate" CssClass="val-error" Display="Dynamic" ErrorMessage="Please select a valid Product !!"></asp:CustomValidator>
            </th>
        </tr>
        <tr>
            <td class="ft-gedit">Product Search :</td>
            <td class="fv-gedit" colspan="5" style="position: relative">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="ItemCode,PartNumber,Description,StockQuantity"
                    DataTextField="DisplayName"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="true"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="675px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="675px" />
                </telerik:RadSearchBox>
                <asp:HiddenField ID="hfItemID" runat="server" />
                <div class="img-search">
                    <img alt="catalog" title="Advanced Search" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_item_16.gif" onclick="OpenDialogO(); return false;" />
                </div>
                <div class="img-clear">
                    <img alt="clear" title="Clear Fields" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_clear_16_16.png" onclick="ClearFieldsO(); return false;" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Description :</td>
            <td class="fv-gedit read-only" colspan="5">
                <asp:TextBox ID="txtDescription" runat="server" ReadOnly="True" Width="675px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ft-gedit">Part Number :</td>
            <td class="fv-gedit read-only ">
                <asp:TextBox ID="txtPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit">Catalog Number :</td>
            <td class="fv-gedit read-only">
                <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Stock Quantity :</td>
            <td class="fv-gedit read-only" colspan="3">
                <asp:TextBox ID="txtStockQuantity" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                <img src="../../ERP/resources/images/ico_store_16x16.png" width="16" height="16" alt="Store" title="Quantity Details" onclick="OpenStoreDialogO(); return false;" />
                (Available Quantity in all stores)
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
        <tr>
            <td class="ft-gedit">Quantity :</td>
            <td class="fv-gedit">
                <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Width="150px" MinValue="1" MaxValue="999999">
                    <NumberFormat DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvQuanitiy" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" Display="Dynamic" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" CssClass="val-error" ErrorMessage="*" Display="Dynamic" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
            </td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
            <td class="ft-gedit"></td>
            <td class="fv-gedit"></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="rwManager" runat="server" ShowContentDuringLoad="false" ReloadOnShow="true" RenderMode="Lightweight" Behaviors="Close" VisibleStatusbar="false" Modal="true">
    <Windows>
        <telerik:RadWindow ID="rwItemSearch" runat="server" Title="Product Search" Width="835px" Height="550px" OnClientClose="OnItemCloseO"  />
        <telerik:RadWindow ID="rwmItemInfo" runat="server" Title="Stock Information" Width="250px" Height="220px" IconUrl="../../ERP/resources/images/ico_store_16x16.png"/>
    </Windows>
</telerik:RadWindowManager>

