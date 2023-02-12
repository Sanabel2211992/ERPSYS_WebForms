<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSupplierSearch.ascx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.UCSupplierSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function OnSupplierClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    name = arg.name;
                $('#<%= hfSupplierID.ClientID %>').val(id);
                $('#<%= hfSupplierName.ClientID %>').val(name);

                var searchBox = $find("<%= rsbSupplier.ClientID %>"),
                    inputElement = $telerik.$(searchBox.get_inputElement());
                inputElement.val(name);
            }
        }
        function showSupplierDialog() {
            var manager = $find("<%= rwmSupplier.ClientID %>");
            manager.open("../Controls/SearchBoxDialog/SupplierSearchDialog.aspx", "rwSupplierSearch");
        }
        function Validate(sender, args) {
            if ($('#<%= hfSupplierID.ClientID %>').val() === "") {
                args.IsValid = false;
            } else {
                args.IsValid = true;
            }
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpSupplier" LoadingPanelID="lpLoading">
    <table width="325px">
        <tr>
            <td nowrap="nowrap">
                <telerik:RadSearchBox runat="server" ID="rsbSupplier"
                    DataKeyNames="Name"
                    DataTextField="Name"
                    DataValueField="SupplierId"
                    EnableAutoComplete="true"
                    ShowSearchButton="false"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="300px" OnDataSourceSelect="rsbSupplier_DataSourceSelect" OnLoad="rsbSupplier_Load" OnSearch="rsbSupplier_Search">
                    <DropDownSettings Width="300px" />
                </telerik:RadSearchBox>
                <%--<img alt="Suppliers" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_account_16.gif" onclick="showSupplierDialog(); return false;" />--%>
                <asp:CustomValidator ID="rfvSupplier" runat="server" CssClass="val-error" ErrorMessage="*" ClientValidationFunction="Validate"></asp:CustomValidator>
                <asp:HiddenField ID="hfSupplierID" runat="server" />
                <asp:HiddenField ID="hfSupplierName" runat="server" />
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="rwmSupplier" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" runat="server" EnableShadow="true">
    <Windows>
        <telerik:RadWindow ID="rwSupplierSearch" runat="server" Modal="True" Width="700px" Height="500px" OnClientClose="OnSupplierClose"
            Behaviors="Close, Move" Title="Suppliers"
            NavigateUrl="~/Controls/SearchBoxDialog/SupplierSearchDialog.aspx">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>

