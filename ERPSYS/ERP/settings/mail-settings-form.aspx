<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="mail-settings-form.aspx.cs" Inherits="ERPSYS.ERP.settings.MailSettingsForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <asp:Panel ID="pnlEmailInfo" runat="server">
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Mail Settings Information</legend>
                        <table class="tbl-edit" style="width: 935px">
                            <tr>
                                <th class="ft-edit" style="width: 135px"></th>
                                <th class="fv-edit" style="width: 800px"></th>
                            </tr>
                            <tr>
                                <td class="ft-edit">Email Name :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtEmailName" runat="server" Width="450px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailName" runat="server" ControlToValidate="txtEmailName" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Sender Name :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtSenderName" runat="server" Width="450px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSenderName" runat="server" ControlToValidate="txtSenderName" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Sender Address :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtSenderAddress" runat="server" Width="450px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSenderAddress" runat="server" ControlToValidate="txtSenderAddress" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">SMTP Server :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtSMTPServer" runat="server" Width="450px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSMTPServer" runat="server" ControlToValidate="txtSMTPServer" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">SMTP Port :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtSMTPPort" runat="server" Width="75px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">SMTP Timeout :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtTimeout" runat="server" Width="75px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">SSL Protocol :</td>
                                <td class="fv-edit">
                                    <asp:RadioButtonList ID="rblSSL" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" Width="120px">
                                        <asp:ListItem Value="true">ON</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="false">OFF</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">TLS Protocol :</td>
                                <td class="fv-edit">
                                    <asp:RadioButtonList ID="rblTLS" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" Width="120px">
                                        <asp:ListItem Value="true">ON</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="false">OFF</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Ignore Certificate :</td>
                                <td class="fv-edit">
                                    <asp:RadioButtonList ID="rblIgnoreCertificate" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" Width="120px">
                                        <asp:ListItem Value="true">ON</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="false">OFF</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Authentication :</td>
                                <td class="fv-edit">
                                    <asp:CheckBox ID="cbAuthentication" runat="server" CssClass="inline-rb" Text="Use SMTP Authentication" AutoPostBack="true" OnCheckedChanged="cbAuthentication_CheckedChanged" />
                                </td>
                            </tr>
                            <asp:Panel ID="pnlAuthentication" runat="server" Visible="false">
                                <tr>
                                    <td class="ft-edit">User Name :</td>
                                    <td class="fv-edit">
                                        <asp:TextBox ID="txtSmtpUserName" runat="server" AutoCompleteType="Disabled" Width="450px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ft-edit">Password :</td>
                                    <td class="fv-edit">
                                        <asp:TextBox ID="txtSmtpPassword" runat="server" AutoCompleteType="Disabled" TextMode="Password" Width="450px"></asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                    </fieldset>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table class="tbl-op-center" style="width: 200px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                    OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbAuthentication">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlEmailInfo" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

