<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerList.ascx.cs" Inherits="ERPSYS.Controls.ComboBox.UCCustomerList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpCustomer" EnableTheming="True">
    <table class="tbl-inner" style="width: 600px">
        <tr>
            <td class="uc-field-title" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 475px"></td>
        </tr>
        <tr>
            <td class="uc-field-title">Customer Name</td>
            <td class="uc-field-val">
                <telerik:RadComboBox ID="rcbCustomer" runat="server" Height="200px" Width="450px" RenderMode="Lightweight" EnableVirtualScrolling="true" EmptyMessage="Choose a Customer"
                    DataTextField="Name" DataValueField="CustomerId">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="rcbCustomer" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
