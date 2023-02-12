<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNotification.ascx.cs" Inherits="ERPSYS.Controls.Common.UCNotification" %>
<asp:Panel ID="pnlMessage" runat="server" Visible="False">

    <div id="divMessagesLogo" runat="server" class="messages-logo">
    </div>
    <div class="messages-title">
        <asp:Literal ID="litMessageTitle" runat="server" EnableViewState="False"></asp:Literal>
    </div>
    <div class="messages-text">
        <asp:Literal ID="litMessage" runat="server" EnableViewState="False"></asp:Literal>
    </div>

</asp:Panel>
<asp:Literal ID="litSpace" runat="server"></asp:Literal>