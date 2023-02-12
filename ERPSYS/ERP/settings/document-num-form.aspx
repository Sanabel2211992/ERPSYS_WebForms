<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="document-num-form.aspx.cs" Inherits="ERPSYS.ERP.settings.DocumentNumForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Documents Information</legend>
                  <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Doc Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:Label ID="lblDocumentName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Next Number : </td>
                            <td class="fv-edit" colspan="3">
                                <telerik:RadNumericTextBox ID="txtNextNumber" runat="server" Width="100px" MinValue="1" MaxValue="999999">
                                    <NumberFormat DecimalDigits="0"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNextNumber" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Min Digits :</td>
                            <td class="fv-edit" colspan="3">
                                <telerik:RadNumericTextBox ID="txtMinDigits" runat="server" Width="100px" MinValue="1" MaxValue="999999">
                                    <NumberFormat DecimalDigits="0"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMinDigits" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Prefix :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtPrefix" runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Suffix :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtSuffix" runat="server" Width="100px"></asp:TextBox>
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

