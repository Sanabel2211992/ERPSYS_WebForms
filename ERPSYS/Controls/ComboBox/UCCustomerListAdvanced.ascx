<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerListAdvanced.ascx.cs" Inherits="ERPSYS.Controls.ComboBox.UCCustomerListAdvanced" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpCustomer" LoadingPanelID="lpLoading" EnableTheming="True">
    <table class="tbl-inner" style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 175px"></td>
        </tr>
        <tr>
            <td class="uc-field-title">Customer </td>
            <td class="uc-field-val" colspan="3">
                <telerik:RadComboBox ID="rcbCustomer" runat="server" Height="200" Width="450px" MarkFirstMatch="true"
                    DropDownWidth="450px" EmptyMessage="Choose a Customer" HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbCustomer_ItemsRequested">
                    <HeaderTemplate>
                        <table style="width: 420px; padding: 0; margin: 0">
                            <tr>
                                <td style="width: 345px;">Customer Name
                                </td>
                                <td style="width: 75px;">Country
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 420px; padding: 0; margin: 0">
                            <tr>
                                <td style="width: 345px;">
                                    <%# DataBinder.Eval(Container, "Text")%>
                                </td>
                                <td style="width: 75px;">
                                    <%# DataBinder.Eval(Container, "Attributes['Country']")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="rcbCustomer" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvCustomer" runat="server" OnServerValidate="cvCustomer_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
