<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCImageUpload.ascx.cs" Inherits="ERPSYS.Controls.FileUpload.UCImageUpload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="300px">
    <tr>
        <td>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="imgPreview" runat="server" Height="150px" Width="150px" /></td>
    </tr>
    <tr>
        <td>
            <table width="150px">
                <tr>
                    <td width="75px" style="vertical-align: top">
                        <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server"
                            OnClientFilesUploaded="OnClientFilesUploaded"
                            OnFileUploaded="AsyncUpload1_FileUploaded"
                            HideFileInput="true"
                            MaxFileSize="2097152"
                            AllowedFileExtensions="jpg,png,gif,bmp"
                            AutoAddFileInputs="false"
                            Localization-Select="Add" Width="75px" />
                    </td>
                    <td width="75px" style="vertical-align: top">
                        <telerik:RadButton ID="btnRemove" runat="server" Text="Remove"></telerik:RadButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            window.$find("<%= raManager.ClientID %>").ajaxRequest();
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="raManager" runat="server" EnablePageHeadUpdate="false">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="raManager">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="imgPreview" />
                <telerik:AjaxUpdatedControl ControlID="AsyncUpload1" />
                <telerik:AjaxUpdatedControl ControlID="lblMessage" />
                <telerik:AjaxUpdatedControl ControlID="btnRemove" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

</telerik:RadAjaxManager>




