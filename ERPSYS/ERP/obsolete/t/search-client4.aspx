<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="search-client4.aspx.cs" Inherits="ERPSYS.ERP.t.search_client4" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
     <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">

            function Validate(sender, args) {
                var combo = window.$find('<%=rcbClient.ClientID %>');
                var name = combo.get_text();
                if (name.length < 1) {
                    args.IsValid = false;
                }
            }

            function OnClientClosefun(oWnd, args) {
                var combo = $find('<%= rcbClient.ClientID %>');
                combo.clearSelection();
                var arg = args.get_argument();
                if (arg) {
                    var id = arg.id;
                    var displayclientname = arg.name;
                    $('#<%= hfClientId.ClientID %>').val(id);
                    combo.set_emptyMessage(displayclientname);
                    $('#<%= txtContactName.ClientID %>').val("");
                }
            }

            function OpenClientDialog() {
                var combo = window.$find('<%=rcbClient.ClientID %>');
                combo.set_emptyMessage("");
                var manager = window.$find("<%= rwmClient.ClientID %>");
                manager.open("../../Controls/DialogBox/CRM/ClientSearch.aspx", "rwmClient");
            }

            function OpenContactDialog() {

                var combo = $find('<%=rcbClient.ClientID %>');
                if (combo.get_selectedItem()) {
                    $('#<%= txtContactName.ClientID %>').val("");
                    var id = combo.get_selectedItem().get_value();
                    $('#<%= hfClientId.ClientID %>').val(id);

                    if (id != "") {
                        var manager = window.$find("<%= rwmContact.ClientID %>");
                        manager.open("../../Controls/DialogBox/CRM/ContactSearch.aspx?id=" + id, "rwmContact");
                    }
                }
            }
            function OnContactClosefun(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var displayclientname = arg.name;
                    $('#<%= txtContactName.ClientID %>').val(displayclientname);
                }
            }

            function AllowSelectionChange(sender, eventArgs) {
                $('#<%= txtContactName.ClientID %>').val("");
                var item = eventArgs.get_item();
                //sender.set_text("You selected " + item.get_text());
                alert(item.get_text());
                alert(item.get_value());

            }
            function OnClientTextChangef(sender, eventArgs) {
                var val = sender.findItemByText(name);
                if (val != null) {
                    var item = eventArgs.get_value();
                    var id = item.get_value();
                    $('#<%= hfClientId.ClientID %>').val(id);
                } else {
                    $('#<%= hfClientId.ClientID %>').val("");
                }
            }
            //function OnClientSelectedIndexChangingf(sender, eventArgs) {
            //    var item = eventArgs.get_item();
            //    if (item != null) {
            //        alert('OnClientSelectedIndexChangingf');
            //    }
            //}
            function OnClientSelectedIndexChangedf(sender, eventArgs) {
                var item = eventArgs.get_item();
                if (item != null) {
                    var id = item.get_value();
                    $('#<%= hfClientId.ClientID %>').val(id);
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxPanel runat="server" ID="rjpClient" EnableTheming="True">
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
                    <td colspan="3" class="field-val">
                        <telerik:RadComboBox ID="rcbClient" runat="server" Height="200" Width="450px" MarkFirstMatch="true"
                            DropDownWidth="468px" HighlightTemplatedItems="true"
                            OnClientTextChange="OnClientTextChangef"
                            OnClientSelectedIndexChanged="OnClientSelectedIndexChangedf"
                            EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbClient_ItemsRequested">
                            <HeaderTemplate>
                                <table style="width: 450px; padding: 0; margin: 0">
                                    <tr>
                                        <td style="width: 440px;">Customer Name</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 440px; padding: 0; margin: 0">
                                    <tr>
                                        <td style="width: 440px;">
                                            <%# DataBinder.Eval(Container, "Text")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:CustomValidator ID="cvClient" runat="server" ClientValidationFunction="Validate" OnServerValidate="cvClient_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>
<%--                        <img src="icons/User-blue-icon.png" onclick="OpenClientDialog(); return false;" />--%>
                    </td>
                </tr>
                <tr>
                    <td class="field-title">Contact Name :</td>
                    <td colspan="2" class="field-val">
                        <asp:TextBox ID="txtContactName" runat="server" Width="300px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <img src="icons/User-black-icon.png" onclick="OpenContactDialog(); return false;" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>

    <telerik:RadWindowManager ID="rwmClient" runat="server" Title="Client Search" OnClientClose="OnClientClosefun"
        Width="580px" Height="260px" Behaviors="Close" IconUrl="icons/User-blue-icon.png" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwClient" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:HiddenField ID="hfClientId" runat="server" />
    <telerik:RadWindowManager ID="rwmContact" runat="server" Title="Contact Search" OnClientClose="OnContactClosefun" ShowContentDuringLoad="true" 
        Width="580px" Height="260px" Behaviors="Close" IconUrl="icons/User-black-icon.png" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwContact" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>