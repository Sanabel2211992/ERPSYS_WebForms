<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="search-client.aspx.cs" Inherits="ERPSYS.ERP.t.search_clinte" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <telerik:RadScriptBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function OpenClientDialog() {
                var manager = window.$find("<%= rwmClient.ClientID %>");
                manager.open("../../Controls/DialogBox/CRM/ClientSearch.aspx", "rwmClient");
            }

            function OpenContactDialog() {
                if ($('#<%= hfClientId.ClientID %>').val() !== "") {
                    var clientId = $('#<%= hfClientId.ClientID %>').val();
                    var manager = window.$find("<%= rwmContact.ClientID %>");
                    manager.open("../../Controls/DialogBox/CRM/ContactSearch.aspx?id=" + clientId, "rwmContact");
                }
            }

            function OnClientClosefun(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var id = arg.id;
                    var displayclientname = arg.name;
                    $('#<%= hfClientId.ClientID %>').val(id);
                    $('#<%= txtClientName.ClientID %>').val(displayclientname);
                    $('#<%= txtContactName.ClientID %>').val("");
                }
            }
            function OnContactClosefun(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var displaycontactname = arg.name;
                    $('#<%= txtContactName.ClientID %>').val(displaycontactname);
                }
            }
            function ClearClient() {
                $('#<%= txtClientName.ClientID %>').val("");
                  $('#<%= txtContactName.ClientID %>').val("");
                  $('#<%= hfClientId.ClientID %>').val("");
              }
              function ClearContact() {
                  $('#<%= txtContactName.ClientID %>').val("");
                }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset>
        <legend class="fs-inner-legend">Client Information</legend>
        <table class="tbl-main" style="width: 600px">
            <tr>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
            </tr>
            <tr>
                <td class="field-title">Client Name :</td>
                <td colspan="2" class="field-val">
                    <asp:TextBox ID="txtClientName" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <img src="icons/User-blue-icon.png" onclick="OpenClientDialog(); return false;" />&nbsp;
                    <img src="../../Controls/resources/images/ico_clear_16_16.png" alt="clear" onclick="ClearClient(); return false;" />
                </td>
            </tr>
            <tr>
                <td class="field-title">Contact Name :</td>
                <td colspan="2" class="field-val">
                    <asp:TextBox ID="txtContactName" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <img src="icons/User-black-icon.png" onclick="OpenContactDialog(); return false;" style="height: 16px; width: 16px" />&nbsp;
                    <img src="../../Controls/resources/images/ico_clear_16_16.png" alt="clear" onclick="ClearContact(); return false;" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:HiddenField ID="hfClientId" runat="server" />
    <telerik:RadWindowManager ID="rwmClient" runat="server" Title="Client Search" OnClientClose="OnClientClosefun" ShowContentDuringLoad="false" ReloadOnShow="true"
        Width="580px" Height="260px" Behaviors="Close" IconUrl="icons/User-blue-icon.png" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwClient" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadWindowManager ID="rwmContact" runat="server" Title="Contact Search" OnClientClose="OnContactClosefun" ReloadOnShow="true" ShowContentDuringLoad="false"
        Width="580px" Height="260px" Behaviors="Close" IconUrl="icons/User-black-icon.png" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwContact" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
