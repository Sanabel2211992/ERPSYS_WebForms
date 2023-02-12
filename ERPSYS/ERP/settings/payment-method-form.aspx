<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="payment-method-form.aspx.cs" Inherits="ERPSYS.ERP.settings.PaymentMethodForm" %>

<asp:Content ID="Cheader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Cmain" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Payment Method Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Method Name :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtMethodName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMethodName" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="field-val"></td>
                            <td class="ft-edit"></td>
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
