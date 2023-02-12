<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveUserImage.aspx.cs" Inherits="ERPSYS.Controls.Obsolete.SaveUserImage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 212px">
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <asp:Button ID="Button1" runat="server" Text="Save User Image" OnClick="Button1_Click" />
        <h5 style="color:green">
        <asp:Label ID="Label1" runat="server"  Visible="false" Text="Users Images Saved In Folder Path (~/Files/System/Profile;)"></asp:Label>
        </h5>
    </form>
</body>
</html>
