<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemSearchAdvanced.ascx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.UCItemSearchAdvanced" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function OnItemClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    name = arg.name,
                    partnumber = arg.partnumber,
                    catalognumber = arg.catalognumber,
                    sku = arg.sku,
                    storageunit = arg.storageunit,
                    brand = arg.brand,
                    type = arg.type;
                $('#<%= hfItemID.ClientID %>').val(id);
                $('#<%= lblPartNumber.ClientID %>').html(partnumber);
                $('#<%= lblCatalogNumber.ClientID %>').html(catalognumber);
                $('#<%= lblSKU.ClientID %>').html(sku);
                $('#<%= lblStorageUnit.ClientID %>').html(storageunit);
                $('#<%= lblBrand.ClientID %>').html(brand);
                $('#<%= lblMainType.ClientID %>').html(type);

                var searchBox = $find("<%= rsbItem.ClientID %>"),
                    inputElement = $telerik.$(searchBox.get_inputElement());
                inputElement.val(name);
            }
        }
        function showItemDialog() {
            var manager = $find("<%= rwmItem.ClientID %>");
            manager.open("../../Controls/SearchBoxDialog/ItemSearchDialog.aspx", "rwItemSearch");
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpItem" LoadingPanelID="lpLoading">
    <table width="100%">
        <tr>
            <td>Item</td>
            <td colspan="5" nowrap="nowrap">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="PartNumber,CatalogNumber,SKU,Brand,StorageUnit,MainType"
                    DataTextField="ItemDescription"
                    DataValueField="ItemId"
                    EnableAutoComplete="true"
                    ShowSearchButton="false"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="400px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                    <DropDownSettings Width="400px" />
                </telerik:RadSearchBox>
                <img alt="Items" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_item_16.gif" onclick="showItemDialog(); return false;" />
                <asp:HiddenField ID="hfItemID" runat="server" />
            </td>
        </tr>
        <tr>
            <td>PartNumber</td>
            <td>
                <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
            <td>Catalog#</td>
            <td>
                <asp:Label ID="lblCatalogNumber" runat="server"></asp:Label>
            </td>
            <td>SKU#</td>
            <td>
                <asp:Label ID="lblSKU" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Storage Unit</td>
            <td>
                <asp:Label ID="lblStorageUnit" runat="server"></asp:Label>
            </td>
            <td>Brand</td>
            <td>
                <asp:Label ID="lblBrand" runat="server"></asp:Label>
            </td>
            <td>Type</td>
            <td>
                <asp:Label ID="lblMainType" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="rwmItem" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" runat="server" EnableShadow="true">
    <Windows>
        <telerik:RadWindow ID="rwItemSearch" runat="server" Modal="True" Width="820px" Height="650px" OnClientClose="OnItemClose"
            Behaviors="Close, Move" Title="Item Search"
            NavigateUrl="~/Controls/SearchBoxDialog/ItemSearchDialog.aspx">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
