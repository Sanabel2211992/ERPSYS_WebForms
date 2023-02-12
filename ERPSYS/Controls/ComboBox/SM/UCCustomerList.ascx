<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerList.ascx.cs" Inherits="ERPSYS.Controls.ComboBox.SM.UCCustomerList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function Validate(sender, args) {
            var combo = window.$find('<%=rcbCustomer.ClientID %>');
            var name = combo.get_text();
            if (name.length < 1) {
                args.IsValid = false;
            }
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpCustomer" EnableTheming="True">
    <div>
        <telerik:RadComboBox ID="rcbCustomer" runat="server" Height="200" Width="460px" MarkFirstMatch="true"
            DropDownWidth="458px" HighlightTemplatedItems="true"
            EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbCustomer_ItemsRequested">
            <HeaderTemplate>
                <table style="width: 430px; padding: 0; margin: 0">
                    <tr>
                        <td style="width: 420px;">Customer Name</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table style="width: 420px; padding: 0; margin: 0">
                    <tr>
                        <td style="width: 420px;">
                            <%# DataBinder.Eval(Container, "Text")%>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </telerik:RadComboBox>
        <asp:CustomValidator ID="cvCustomer" runat="server" ClientValidationFunction="Validate" OnServerValidate="cvCustomer_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>
    </div>
</telerik:RadAjaxPanel>
