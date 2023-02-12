<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCItemSearch.ascx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.UCItemSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function OnItemClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    description = arg.description,
                    cost = arg.cost,
                    price = arg.price;
                $('#<%= hfItemID.ClientID %>').val(id);
                $('#<%= hfItemdescription.ClientID %>').val(description);

                var searchBox = $find("<%= rsbItem.ClientID %>"),
                    inputElement = $telerik.$(searchBox.get_inputElement());
                inputElement.val(description);
            }
        }
        function showItemDialog() {
            var manager = $find("<%= rwmItem.ClientID %>");
            manager.open("../../Controls/SearchBoxDialog/ItemSearchDialog.aspx", "rwItemSearch");
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpItem" LoadingPanelID="lpLoading">
    <table width="425px">
        <tr>
            <td nowrap="nowrap">
                <telerik:RadSearchBox runat="server" ID="rsbItem"
                    DataKeyNames="ItemDescription"
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
                <asp:HiddenField ID="hfItemdescription" runat="server" />
                <asp:HiddenField ID="hfSKU" runat="server" />
                <asp:HiddenField ID="hfCatalogNumber" runat="server" />
                <asp:HiddenField ID="hfPartNumber" runat="server" />
                <asp:HiddenField ID="hfStorageUnitID" runat="server" />
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

