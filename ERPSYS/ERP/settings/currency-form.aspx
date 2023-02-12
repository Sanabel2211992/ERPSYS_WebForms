<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="currency-form.aspx.cs" Inherits="ERPSYS.ERP.settings.CurrencyForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Currency Information</legend>
                    <table class="tbl-inner" style="width: 600px">
                        <tr>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="field-title">Code :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtCurrencyCode" runat="server" Width="129px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Description :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtDescription" runat="server" Width="127px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Symbol :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtSymbol" runat="server" Width="129px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSymbol" runat="server" ControlToValidate="txtSymbol" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Decimal Places :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtDecimalPlaces" runat="server" Width="130px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDecimalPlaces" runat="server" ControlToValidate="txtDecimalPlaces" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Status :</td>
                            <td class="field-val" colspan="3">
                                <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
