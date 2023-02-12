<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="email-template-form.aspx.cs" Inherits="ERPSYS.ERP.settings.EmailTemplateForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Template Details</legend>
                    <table class="tbl-edit" style="width: 935px">
                        <tr>
                            <td class="ft-edit" style="width: 135px"></td>
                            <td class="fv-edit" style="width: 800px"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Template Name :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblTemplateName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Subject :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmailSubject" runat="server" Width="780px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Body :</td>
                            <td class="fv-edit">
                                <telerik:RadEditor ID="txtEmailBody" runat="server" EnableResize="False" Height="300px" ContentFilters="DefaultFilters,MakeUrlsAbsolute" RenderMode="Lightweight" NewLineMode="Br" Width="775px">
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Enabled :</td>
                            <td class="fv-edit">
                                <asp:RadioButtonList ID="rblIsActive" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" Width="120px">
                                    <asp:ListItem Value="true">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="false">No</asp:ListItem>
                                </asp:RadioButtonList>
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