<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomer.ascx.cs" Inherits="ERPSYS.Controls.Window.Common.UCCustomer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function OpenCustomerDialog() {
            var manager = window.$find("<%= rwmCustomer.ClientID %>");
            manager.open("../../Controls/DialogBox/Common/CustomerSearch.aspx", "rwmClient");
        }
    </script>
</telerik:RadCodeBlock>
<img src="../resources/images/ico_cus_search.png" alt="search" title="search" onclick="OpenCustomerDialog(); return false;" />
<telerik:RadWindowManager ID="rwmCustomer" runat="server" Title="Customer Search" ShowContentDuringLoad="false" ReloadOnShow="true" OnClientClose="OnCustomerClosefun"
    Width="765px" Height="400px" Behaviors="Close" IconUrl="../resources/images/ico_cus_search.png" VisibleStatusbar="false" Modal="true">
    <Windows>
        <telerik:RadWindow ID="rwCustomer" runat="server">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
