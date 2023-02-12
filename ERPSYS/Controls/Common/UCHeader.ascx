<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="ERPSYS.Controls.Common.UCHeader" %>
<%@ Import Namespace="ERPSYS.BLL" %>
<%@ Register Src="UCMenu.ascx" TagName="UCMenu" TagPrefix="uc1" %>
<table class="header-table">
    <tbody>
        <tr>
            <td>
                <div class="logo">
                    <a href="../main/home.aspx">
                        <img src="../../ERP/resources/images/header-logo.png" onerror="this.style.display='none'" /></a>
                </div>
            </td>
            <td class="name_co">
                <asp:Label ID="lblTitle" runat="server"></asp:Label><span class="version_co"><asp:Label ID="lblVersion" runat="server"></asp:Label></span></td>
            <td id="ddmenu">
                <ul>
                    <li><span class="top-heading">
                        <asp:Image ID="smallProfileImage" runat="server" Height="46px" Width="46px" />
                    </span>
                        <div class="dropdown offset300">
                            <div class="dd-inner">
                                <div class="column mayHide">
                                    <br />
                                    <asp:Image ID="header_user_big" runat="server" Height="140px" Width="140px" />
                                </div>
                                <div class="column">
                                    <h3><%= UserSession.UserDisplayName %></h3>
                                    <h4><%= UserSession.UserTitle %></h4>
                                    <h4><%= UserSession.EmailAddress %></h4>
                                    <div>
                                        <a href="../user/login-user-details.aspx">Account Settings</a>
                                        <a href="../user/login-user-change-pass.aspx">Change Password</a>
                                    </div>
                                    <h3><a href="../session/logout.aspx">Logout</a></h3>
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </td>
        </tr>
    </tbody>
</table>
<div class="line">
    <div class="position-menu">
        <div class="line-menu">
            <uc1:UCMenu ID="UCMenu" runat="server" />
        </div>
    </div>
</div>
