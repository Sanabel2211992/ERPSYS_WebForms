<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="uom-conversion-details.aspx.cs" Inherits="ERPSYS.ERP.settings.UnitOfMeasureConversionDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset class="fs-edit">
        <legend class="fs-inner-legend">Conversion Rule</legend>
        <table class="tbl-edit" style="width: 900px">
            <tr>
                <th class="ft-edit" style="width: 125px"></th>
                <th class="fv-edit" style="width: 175px"></th>
                <th class="ft-edit" style="width: 125px"></th>
                <th class="fv-edit" style="width: 175px"></th>
                <th class="ft-edit" style="width: 125px"></th>
                <th class="fv-edit" style="width: 175px"></th>
            </tr>
            <tr>
                <td class="ft-edit">From Unit : </td>
                <td class="fv-edit">
                    <asp:DropDownList ID="ddlUOMFrom" runat="server" Width="150px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvUOMFrom" runat="server" ControlToValidate="ddlUOMFrom" ErrorMessage="*" ValidationGroup="save" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
                <td class="ft-edit">To Unit :</td>
                <td class="fv-edit">
                    <asp:DropDownList ID="ddlUOMTo" runat="server" Width="150px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvUOMTo" runat="server" ControlToValidate="ddlUOMTo" ErrorMessage="*" ValidationGroup="save" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                </td>
                <td class="ft-edit">Factor :</td>
                <td class="fv-edit">
                    <telerik:RadNumericTextBox ID="txtFactor" runat="server" Width="150px" MinValue="0" MaxValue="999">
                        <NumberFormat DecimalDigits="3"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvFactor" runat="server" ControlToValidate="txtFactor" ErrorMessage="*" ValidationGroup="save" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </fieldset>
    <table class="tbl-op-center" style="width: 200px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                    OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
