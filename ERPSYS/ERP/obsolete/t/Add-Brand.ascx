<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add-Brand.ascx.cs" Inherits="ERPSYS.ERP.t.Add_Brand" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowBrand() {
            return $find("<%=rwBrand.ClientID%>");
        }
        function OpenDialogBrand() {
            getRadWindowBrand().show();
        }
        function closeDialogBrand() {
            $('#<%= txtNameBrand.ClientID %>').val("");
            getRadWindowBrand().close();
        }
    </script>
</telerik:RadScriptBlock>
<img alt="catalog" src="icons/round_add.ico" onclick="OpenDialogBrand(); return false;" />
<%--<telerik:RadWindowManager ID="rwmItem" runat="server">
    <Windows>--%>
        <telerik:RadWindow ID="rwBrand" Height="150px" Width="320px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Brand">
            <ContentTemplate>
                <table class="tbl-main">
                    <tr>
                        <td class="field-title" style="width: 100px"></td>
                        <td class="field-val" style="width: 100px"></td>
                    </tr>
                    <tr>
                        <td class="field-title">Brand Name :</td>
                        <td class="field-val">
                            <asp:TextBox ID="txtNameBrand" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNameBrand" runat="server" ControlToValidate="txtNameBrand" ErrorMessage="*" CssClass="val-error" ValidationGroup="vgbrand" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Button ID="btnSaveBrand" runat="server" Text="Save" CssClass="btn-save" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('vgbrand'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSaveBrand_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelBrand" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClientClick="closeDialogBrand(); return false;" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
<%--    </Windows>
</telerik:RadWindowManager>--%>

