<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeaderLogin.ascx.cs" Inherits="ERPSYS.Controls.Common.UCHeaderLogin" %>
<table class="header-table ">
    <tbody>
        <tr>
            <td>
                <div class="logo">
                    <a href="../main/home.aspx">
                        <img src="../../ERP/resources/images/header-logo.png" onerror=" this.style.display = 'none' " alt=""/>
                    </a>
                </div>
            </td>
            <td class="name_co">
                <asp:Label ID="lblTitle" runat="server"></asp:Label><span style="color: #cbbb09; font-size: 13pt; padding-left: 5px"><asp:Label ID="lblVersion" runat="server"></asp:Label></span></td>
            <td class="right-box "></td>
        </tr>
    </tbody>
</table>
