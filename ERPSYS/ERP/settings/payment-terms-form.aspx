<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="payment-terms-form.aspx.cs" Inherits="ERPSYS.ERP.settings.PaymentTermsForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Cheader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Cmain" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Payment Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Payment Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtPaymentName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaymentName" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Days Due :</td>
                            <td class="fv-edit" colspan="3">
                                <telerik:RadNumericTextBox ID="txtDaysDue" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="rfvDaysDue" runat="server" ControlToValidate="txtDaysDue" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvsDaysDue" runat="server" ControlToValidate="txtDaysDue" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit" colspan="3">
                                <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
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
