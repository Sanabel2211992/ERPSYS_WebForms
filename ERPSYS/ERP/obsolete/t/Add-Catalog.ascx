<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add-Catalog.ascx.cs" Inherits="ERPSYS.ERP.t.Add_Catalog" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowCategory() {
            return $find("<%=rwCategory.ClientID%>");
        }
        function OpenDialogCategory() {
            getRadWindowCategory().show();
        }
        function closeDialogCategory() {
            $('#<%= txtName.ClientID %>').val("");
            getRadWindowCategory().close();
        }
    </script>
</telerik:RadScriptBlock>
<img alt="catalog" src="icons/round_add.ico" onclick="OpenDialogCategory(); return false;" />
        <telerik:RadWindow ID="rwCategory" Height="150px" Width="320px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Category">
            <ContentTemplate>
                <table class="tbl-main">
                    <tr>
                        <td class="field-title" style="width: 100px"></td>
                        <td class="field-val" style="width: 100px"></td>
                    </tr>
                    <tr>
                        <td class="field-title">Category Name :</td>
                        <td class="field-val">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ValidationGroup="vgCategory" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"> <br /> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('vgCategory'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClientClick="closeDialogCategory(); return false;" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
  