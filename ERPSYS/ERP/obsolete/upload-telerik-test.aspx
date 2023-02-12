<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload-telerik-test.aspx.cs" Inherits="ERPSYS.ERP.obsolete.upload_telerik_test" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Telerik ASP.NET Upload Example</title>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
        <div class="attachment-container">
            <telerik:RadAsyncUpload RenderMode="Lightweight" runat="server" CssClass="async-attachment" ID="AsyncUpload1"
                HideFileInput="true" MaxFileSize="20000000"
                AllowedFileExtensions=".jpeg,.jpg,.png,.doc,.docx,.xls,.xlsx,.pdf,.ppt,.pptx,.rar" />
            Select files to upload 
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>