<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPendingDelievryReceipts.ascx.cs" Inherits="ERPSYS.Controls.Custom.SM.DeliveryReceipt.UCPendingDelievryReceipts" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock runat="server" ID="rdbScripts">
</telerik:RadCodeBlock>
<telerik:RadAjaxPanel runat="server" ID="rjpCustomer" EnableTheming="True">
    <table class="tbl-inner" style="width: 600px">
        <tr>
            <td class="uc-ft-view" style="width: 125px"></td>
            <td class="uc-field-val" style="width: 475px"></td>
        </tr>
        <tr>
            <td class="uc-ft-view">Customer Name</td>
            <td class="uc-field-val">
                <telerik:RadComboBox ID="rcbCustomer" runat="server" Height="200px" Width="450px" RenderMode="Lightweight" EnableVirtualScrolling="true" EmptyMessage="Choose a Customer"
                    DataTextField="Name" DataValueField="CustomerId" AutoPostBack="True" OnSelectedIndexChanged="rcbCustomer_SelectedIndexChanged">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="rcbCustomer" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <asp:Panel ID="pnlSalesOrder" Visible="False" runat="server">
            <tr>
                <td class="uc-ft-view">Sales Order</td>
                <td class="uc-field-val">
                    <asp:DropDownList ID="ddlSalesOrder" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesOrder_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlDeliveryReceipt" Visible="False" runat="server">
            <tr>
                <td class="uc-ft-view">Delivery Receipts</td>
                <td class="uc-field-val">
                    <asp:CheckBoxList ID="cblDeliveryReceipts" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </asp:Panel>
    </table>
</telerik:RadAjaxPanel>