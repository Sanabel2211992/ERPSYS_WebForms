<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTicket.ascx.cs" Inherits="ERPSYS.Controls.AddTicket" %>
<table class="tbl-main">
    <tr>
        <td class="ft-view" style="width: 100px"></td>
        <td class="field-val"></td>
    </tr>
    <tr>
        <td class="ft-view">
            <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="ft-view">
            <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="field-val">
           <asp:Label ID="lbNote" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
