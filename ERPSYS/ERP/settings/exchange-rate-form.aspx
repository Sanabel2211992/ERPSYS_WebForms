<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="exchange-rate-form.aspx.cs" Inherits="ERPSYS.ERP.settings.ExchangeRateForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                            <td class="field-title">Currency Code</td>
                            <td class="field-val" colspan="3">
                                <asp:Label ID="lblCurrencyCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Description</td>
                            <td class="field-val" colspan="3">
                                <asp:Label ID="lblCurrencyDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Exchange Rate</td>
                            <td class="field-val" colspan="3">
                                <telerik:RadNumericTextBox ID="txtExchangeRate" runat="server" Width="100px" MinValue="0.00001" MaxValue="999999" >
                                    <NumberFormat DecimalDigits="5"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExchangeRate" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
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
