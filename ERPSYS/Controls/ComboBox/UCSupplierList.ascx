<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSupplierList.ascx.cs" Inherits="ERPSYS.Controls.ComboBox.UCSupplierList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpSupplier" LoadingPanelID="lpLoading" EnableTheming="True">
    <table style="width: 350px">
        <tr>
            <td nowrap="nowrap">
                <telerik:RadComboBox ID="rcbSupplier" runat="server" Height="200" Width="450px" MarkFirstMatch="true"
                    DropDownWidth="450px" EmptyMessage="Choose a Supplier" HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbSupplier_ItemsRequested">
                    <HeaderTemplate>
                        <table style="width: 425px; padding: 0; margin: 0">
                            <tr>
                                <td style="width: 350px;">Supplier Name
                                </td>
                                <td style="width: 75px;">Country
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 425px; padding: 0; margin: 0">
                            <tr>
                                <td style="width: 350px;">
                                    <%# DataBinder.Eval(Container, "Text")%>
                                </td>
                                <td style="width: 75px;">
                                    <%# DataBinder.Eval(Container, "Attributes['Country']")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvSupplier" ControlToValidate="rcbSupplier" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvSupplier" runat="server" OnServerValidate="cvSupplier_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>

                <asp:HiddenField ID="hfSupplierID" runat="server" />
                <asp:HiddenField ID="hfSupplierName" runat="server" />
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>

