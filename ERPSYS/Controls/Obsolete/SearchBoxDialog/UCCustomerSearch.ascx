<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerSearch.ascx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.UCCustomerSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function OnCustomerClose(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var id = arg.id,
                    name = arg.name;
                $('#<%= hfCustomerID.ClientID %>').val(id);
                $('#<%= hfCustomerName.ClientID %>').val(name);

                var searchBox = $find("<%= rsbCustomer.ClientID %>"),
                    inputElement = $telerik.$(searchBox.get_inputElement());
                inputElement.val(name);
            }
        }
        function showCustomerDialog() {
            var manager = $find("<%= rwmCustomer.ClientID %>");
            manager.open("../Controls/SearchBoxDialog/CustomerSearchDialog.aspx", "rwCustomerSearch");
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpCustomer" LoadingPanelID="lpLoading">
    <table width="425px">
        <tr>
            <td nowrap="nowrap">
                <telerik:RadSearchBox runat="server" ID="rsbCustomer"
                    DataKeyNames="CustomerName"
                    DataTextField="CustomerName"
                    DataValueField="CustomerId"
                    EnableAutoComplete="true"
                    ShowSearchButton="false"
                    Filter="StartsWith"
                    MaxResultCount="20"
                    Width="400px" OnDataSourceSelect="rsbCustomer_DataSourceSelect" OnLoad="rsbCustomer_Load" OnSearch="rsbCustomer_Search">
                    <DropDownSettings Width="400px" />
                </telerik:RadSearchBox>
                <img alt="Customers" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_account_16.gif" onclick="showCustomerDialog(); return false;" />
                <asp:HiddenField ID="hfCustomerID" runat="server" />
                <asp:HiddenField ID="hfCustomerName" runat="server" />
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="rwmCustomer" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" runat="server" EnableShadow="true">
    <Windows>
        <telerik:RadWindow ID="rwCustomerSearch" runat="server" Modal="True" Width="700px" Height="500px" OnClientClose="OnCustomerClose"
            Behaviors="Close, Move" Title="Customers"
            NavigateUrl="~/Controls/SearchBoxDialog/CustomerSearchDialog.aspx">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>

