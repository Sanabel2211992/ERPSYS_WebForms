<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProjectNote.ascx.cs" Inherits="ERPSYS.Controls.DialogBox.Projects.AddProjectNote" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowNote() {
            return $find("<%=rwNote.ClientID%>");
        }
        function OpenDialogNote() {
            $('#<%= txtProjectNote.ClientID %>').val("");
            getRadWindowNote().show();
        }
        function closeDialogNote() {
            getRadWindowNote().close();
        }
    </script>
</telerik:RadScriptBlock>

<asp:LinkButton ID="lbAddNewNote" runat="server"  CssClass="lnkbtn-add" OnClientClick="OpenDialogNote(); return false;">Add New Note</asp:LinkButton>
<telerik:RadWindow ID="rwNote" Height="180px" Width="290px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Note">
    <ContentTemplate>
        <table class="tbl-main">
            <tr>
                <td style="width:250px">
                    <asp:TextBox ID="txtProjectNote" runat="server" Width="230px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProjectNote" runat="server" ErrorMessage="*" ControlToValidate="txtProjectNote"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="btnSaveNote" runat="server" CssClass="btn-save" Text="Save" OnClick="btnSaveNote_Click" />
                    <input class="btn-save" id="Cancel" type="button" value="Cancel" onclick="closeDialogNote(); return false;"/>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</telerik:RadWindow>
