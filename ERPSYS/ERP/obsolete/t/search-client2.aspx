<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="search-client2.aspx.cs" Inherits="ERPSYS.ERP.t.search_client2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function Validate(sender, args) {
                var combo = window.$find('<%=rcbClient.ClientID %>');
                var name = combo.get_text();
                if (name.length < 1) {
                    args.IsValid = false;
                }
            }
            function ValidateCon(sender, args) {
                var combo = window.$find('<%=rcbContact.ClientID %>');
                var name = combo.get_text();
                if (name.length < 1) {
                    args.IsValid = false;
                }
            }

            function AllowSelectionChange(sender, eventArgs) {
                var item = eventArgs.get_item();
            }

            function OnClientTextChangef(sender, eventArgs) {
                var val = sender.findItemByText(name);
                if (val != null) {
                    var item = eventArgs.get_value();
                    var id = item.get_value();
                    $('#<%= hfClientId.ClientID %>').val(id);
                    }
                    else {
                        $('#<%= hfClientId.ClientID %>').val("");
                    }
                }

                function OnClientSelectedIndexChangedf(sender, eventArgs) {
                    var item = eventArgs.get_item();
                    if (item != null) {
                        var id = item.get_value();
                        $('#<%= hfClientId.ClientID %>').val(id);
                    }
                }
                function OnContactTextChangef(sender, eventArgs) {
                    var val = sender.findItemByText(name);
                    if (val != null) {
                        var item = eventArgs.get_value();
                        var id = item.get_value();
                    }

                }

                function OnContactSelectedIndexChangedf(sender, eventArgs) {
                    var item = eventArgs.get_item();
                    if (item != null) {
                        var id = item.get_value();
                    }
                }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hfClientId" runat="server" />
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
                                        <td style="width: 440px;">Client Name</td>
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
                    </td>
                </tr>
                <tr>
                    <td class="field-title">Contact Name :</td>
                    <td colspan="3" class="field-val">
                        <telerik:RadComboBox ID="rcbContact" runat="server" Height="200" Width="450px" MarkFirstMatch="true" CheckBoxes="true"
                            DropDownWidth="468px" HighlightTemplatedItems="true"
                            OnClientTextChange="OnContactTextChangef"
                            OnClientSelectedIndexChanged="OnContactSelectedIndexChangedf"
                            EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbContact_ItemsRequested">
                            <HeaderTemplate>
                                <table style="width: 450px; padding: 0; margin: 0">
                                    <tr>
                                        <td style="width: 440px;">Client Name</td>
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
                        <asp:CustomValidator ID="cvContact" runat="server" ClientValidationFunction="ValidateCon" OnServerValidate="cvContact_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
</asp:Content>