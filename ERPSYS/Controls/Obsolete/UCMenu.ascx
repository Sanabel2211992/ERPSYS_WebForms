<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMenu.ascx.cs" Inherits="ERPSYS.Controls.Obsolete.UCMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style>
    .RadMenu_Default .rmRootGroup {
        border: 0 solid #828282;
        background-repeat: repeat-x;
        background-position: 0 -408px;
        background-color: #e6e6e6;
    }
</style>
<table>
    <tr>
        <td>
            <telerik:RadMenu ID="MainMenu" runat="server" EnableRoundedCorners="true" EnableShadows="true" Style="z-index: 3000" Width="100%"></telerik:RadMenu>
        </td>
    </tr>
</table>
