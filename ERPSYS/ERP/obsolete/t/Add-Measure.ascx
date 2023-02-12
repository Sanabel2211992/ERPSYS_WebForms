<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add-Measure.ascx.cs" Inherits="ERPSYS.ERP.t.Add_Measure" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock runat="server" ID="rdbScripts">
    <script type="text/javascript">
        function getRadWindowMeasure() {
            return $find("<%=rwMeasure.ClientID%>");
        }
        function OpenDialogMeasure() {
            getRadWindowMeasure().show();
        }
        function closeDialogMeasure() {
            $('#<%= txtNameMeasure.ClientID %>').val("");
            getRadWindowMeasure().close();
        }
    </script>
</telerik:RadScriptBlock>
<img alt="catalog" src="icons/round_add.ico" onclick="OpenDialogMeasure(); return false;" />

<telerik:RadWindow ID="rwMeasure" Height="150px" Width="350px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Unit of Measure">
    <ContentTemplate>
        <table class="tbl-main">
            <tr>
                <td class="field-title" style="width: 150px"></td>
                <td class="field-val" style="width: 200px"></td>
            </tr>
            <tr>
                <td class="field-title">Unit of Measure Name :</td>
                <td class="field-val">
                    <asp:TextBox ID="txtNameMeasure" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNameMeasure" runat="server" ControlToValidate="txtNameMeasure" ErrorMessage="*" CssClass="val-error" ValidationGroup="vgMeasure" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveMeasure" runat="server" Text="Save" CssClass="btn-save" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('vgMeasure'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSaveMeasure_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancelMeasure" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClientClick="closeDialogMeasure(); return false;" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</telerik:RadWindow>
