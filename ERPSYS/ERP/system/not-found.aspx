<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Public.Master" AutoEventWireup="true" CodeBehind="not-found.aspx.cs" Inherits="ERPSYS.ERP.system.NotFoundPage" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div class="system-message">
        <img src="../resources/images/img_page_not_found.png" width="80" height="80" alt="Page not found" />
        <div class="title">Page Not Found ...!</div>
        <hr />
        <p>The resource you are looking for might have been removed, had its name changed, or is temporarily unavailable.</p>
        <a href="../main/home.aspx">Go to the Home page </a>
    </div>
</asp:Content>

