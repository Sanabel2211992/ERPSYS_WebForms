<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="user-pass-reset.aspx.cs" Inherits="ERPSYS.ERP.user.UserPassReset" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Reset Password</legend>
                    <table class="tbl-edit" style="width: 680px">
                        <tr>
                            <th class="ft-edit" style="width: 140px"></th>
                            <th class="fv-edit" style="width: 200px"></th>
                            <th class="ft-edit" style="width: 140px"></th>
                            <th class="fv-edit" style="width: 200px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Display Name :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblDisplayUsername" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Username :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:Label ID="lblUsername" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">New Password :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfNewPassword" runat="server" ControlToValidate="txtNewPassword" CssClass="val-error" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Confirm Password :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="val-error" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" CssClass="val-error" ErrorMessage="The password you entered does not match"></asp:CompareValidator>
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
                            <asp:Button ID="btnSave" runat="server" Text="Reset" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
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
