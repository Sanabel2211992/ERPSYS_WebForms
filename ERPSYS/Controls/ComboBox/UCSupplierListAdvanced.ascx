<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSupplierListAdvanced.ascx.cs" Inherits="ERPSYS.Controls.ComboBox.UCSupplierListAdvanced" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpSupplier" LoadingPanelID="lpLoading" EnableTheming="True">
    <table class="tbl-edit" style="width: 600px">
        <tr>
            <th class="ft-edit" style="width: 125px"></th>
            <th class="fv-edit" style="width: 175px"></th>
            <th class="ft-edit" style="width: 125px"></th>
            <th class="fv-edit" style="width: 175px"></th>
        </tr>
        <tr>
            <td class="ft-edit">Supplier :</td>
            <td class="fv-edit" nowrap="nowrap" colspan="3">
                <telerik:RadComboBox ID="rcbSupplier" runat="server" Height="200" Width="455px" MarkFirstMatch="true"
                    DropDownWidth="450px" EmptyMessage="Choose a Supplier" HighlightTemplatedItems="true" AutoPostBack="True"
                    EnableLoadOnDemand="true" Filter="StartsWith" OnItemsRequested="rcbSupplier_ItemsRequested" OnSelectedIndexChanged="rcbSupplier_SelectedIndexChanged">
                    <HeaderTemplate>
                        <table style="width: 420px; padding: 0; margin: 0">
                            <tr>
                                <td style="width: 345px;">Supplier Name :
                                </td>
                                <td style="width: 75px;">Country :
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
                <asp:RequiredFieldValidator runat="server" ID="rfvSupplier" ControlToValidate="rcbSupplier" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvSupplier" runat="server" OnServerValidate="cvSupplier_ServerValidate" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="ft-edit">Attention :</td>
            <td class="fv-edit">
                <asp:TextBox ID="txtContactName" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td class="ft-edit">Phone :</td>
            <td class="fv-edit">
                <asp:TextBox ID="txtPhone" runat="server" Width="145px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="ft-edit">Supplier Address :</td>
            <td class="fv-edit" colspan="3">
                <asp:TextBox ID="txtAddress" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
