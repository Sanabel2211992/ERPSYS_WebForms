<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multi-upload-ProgressArea.aspx.cs" Inherits="ERPSYS.ERP.obsolete.upload_telerik_drag_drop" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html>

<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Telerik ASP.NET Example</title>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <div>
            
            <telerik:RadAsyncUpload RenderMode="Lightweight" runat="server" ID="AsyncUpload1" 
                MultipleFileSelection="Automatic" Width="500px" Skin="Metro" />
            <telerik:RadProgressArea RenderMode="Lightweight" runat="server" ID="RadProgressArea1" Skin="Metro" />
            <i style="color:blue; font-size:11px">You may attach up to 20mb in files to the Email.</i>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>
