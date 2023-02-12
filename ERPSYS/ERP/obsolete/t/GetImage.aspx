<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetImage.aspx.cs" Inherits="ERPSYS.ERP.t.GetImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       Image ID:
    <asp:TextBox ID="id" runat="server">  
</asp:TextBox>  
<br />  
<asp:Button ID="txtGetImage" runat="server"  
Text="Convert" OnClick="txtGetImage_Click" />  
        <br />
<asp:Image ID="Image1" runat="server" length="100px" Height="410px" Width="321px" />  
    </div>
    </form>
</body>
</html>
