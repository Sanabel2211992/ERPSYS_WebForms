<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProjectFile.ascx.cs" Inherits="ERPSYS.Controls.DialogBox.Projects.AddProjectFile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowProjectFile() {
            return $find("<%=rwProjectFile.ClientID%>");
        }
        function OpenDialogProjectFile() {
            getRadWindowProjectFile().show();
        }
        function closeDialogProjectFile() {
            getRadWindowProjectFile().close();
        }
    </script>
</telerik:RadScriptBlock>

<asp:LinkButton ID="lbAddNewFile" runat="server"  CssClass="lnkbtn-add" OnClientClick="OpenDialogProjectFile(); return false;">Add New File</asp:LinkButton>

<telerik:RadWindow ID="rwProjectFile" Height="150px" Width="320px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New File">
    <ContentTemplate>
        <table class="tbl-main">
            <tr>
                <td>
                    <asp:FileUpload ID="fuProjectFile" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUploadFile" runat="server" Text="Upload" CssClass="btn-upload" OnClick="btnUploadFile_Click" />
                    <input class="btn-save" id="Cancel" type="button" value="Cancel" onclick="closeDialogProjectFile(); return false;" />

                </td>
            </tr>
        </table>
    </ContentTemplate>
</telerik:RadWindow>
