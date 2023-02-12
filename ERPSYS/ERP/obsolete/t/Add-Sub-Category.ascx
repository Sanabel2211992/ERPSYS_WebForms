<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add-Sub-Category.ascx.cs" Inherits="ERPSYS.ERP.t.Add_Sub_Category" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowSubCategory() {
            return $find("<%=rwSubCategory.ClientID%>");
        }
        function OpenDialogSubCategory() {
            getRadWindowSubCategory().show();
        }
        function closeDialogSubCategory() {
            $('#<%= txtNameSubCategory.ClientID %>').val("");
            getRadWindowSubCategory().close();
        }
    </script>
</telerik:RadScriptBlock>
<img alt="catalog" src="icons/round_add.ico" onclick="OpenDialogSubCategory(); return false;" />
<telerik:RadWindow ID="rwSubCategory" Height="170px" Width="320px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Sub Category">
    <ContentTemplate>
        <table class="tbl-main">
            <tr>
                <td class="field-title" style="width: 100px"></td>
                <td class="field-val" style="width: 100px"></td>
            </tr>
            <tr>
                <td class="field-title">Category :</td>
                <td class="field-title">
                    <asp:DropDownList ID="ddlCategoryGet" runat="server" Width="150px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="field-title">Sub Category Name :</td>
                <td class="field-val">
                    <asp:TextBox ID="txtNameSubCategory" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNameSubCategory" runat="server" ControlToValidate="txtNameSubCategory" ValidationGroup="vgSubCategory" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveSubCategory" runat="server" Text="Save" CssClass="btn-save"
                        OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('vgSubCategory'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSaveSubCategory_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancelSubCategory" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClientClick="closeDialogSubCategory(); return false;" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</telerik:RadWindow>
