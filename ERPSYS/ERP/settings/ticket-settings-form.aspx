<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="ticket-settings-form.aspx.cs" Inherits="ERPSYS.ERP.settings.TicketSettingsForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">General Settings</legend>
                    <table class="tbl-edit" style="width: 950px">
                        <tr>
                            <th class="ft-edit" style="width: 150px"></th>
                            <th class="fv-edit" style="width: 800px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Support Center URL :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtURL" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtURL" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Support Center Name :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtSiteName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSiteName" runat="server" ControlToValidate="txtSiteName" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Default System Email :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlSystemEmail" runat="server" Width="455px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email TO Address :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtToAddress" runat="server" Width="450px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvToAddress" CssClass="val-error" runat="server" ControlToValidate="txtToAddress" ErrorMessage="Invalid email address list" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email CC Address :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCCAddress" runat="server" Width="450px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvCCAddress" CssClass="val-error" runat="server" ControlToValidate="txtCCAddress" ErrorMessage="Invalid email address list" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email BCC Address :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtBCCAddress" runat="server" Width="450px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvBCCAddress" CssClass="val-error" runat="server" ControlToValidate="txtBCCAddress" ErrorMessage="Invalid email address list" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <table class="tbl-op-center" style="width: 100px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

