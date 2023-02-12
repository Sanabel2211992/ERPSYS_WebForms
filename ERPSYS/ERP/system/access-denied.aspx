<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Public.Master" AutoEventWireup="true" CodeBehind="access-denied.aspx.cs" Inherits="ERPSYS.ERP.system.AccessDeniedPage" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div class="system-message">
        <img src="../resources/images/img_access_denied.png" width="80" height="80" alt="Access Denied" />
        <div class="title">Access Denied ...!</div>
        <hr />
        <p>You do not have access to the page you requested</p>
        <a href="../main/home.aspx">Go to the Home page </a>
    </div>
</asp:Content>


