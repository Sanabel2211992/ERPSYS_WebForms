<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="mail-send.aspx.cs" Inherits="ERPSYS.ERP.mail.MailSend" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Email Information</legend>
                    <table class="tbl-edit" style="width: 900px">
                        <tr>
                            <th class="ft-edit" style="width: 100px"></th>
                            <th class="fv-edit" style="width: 800px"></th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ValidationSummary ID="ValidationSummary1" CssClass="val-error"
                                    HeaderText="Please check the following fields :"
                                    DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">From :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlEmailFrom" runat="server" Width="775px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">To :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMailTo" runat="server" Width="775px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMailTo" runat="server" ControlToValidate="txtMailTo" ErrorMessage="Please enter a valid email address." Text="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMailTo" CssClass="val-error" runat="server" ControlToValidate="txtMailTo" ErrorMessage="Invalid email address." Text="*" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*(;|,)\s*|\s*$))+"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Cc :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMailCc" runat="server" Width="775px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revMailCc" CssClass="val-error" runat="server" ControlToValidate="txtMailCc" ErrorMessage="Invalid CC email address list." Text="*" SetFocusOnError="True" Display="Dynamic"
                                    ValidationExpression="(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*(;|,)\s*|\s*$))*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Priority :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPriority" runat="server" Width="100px">
                                    <asp:ListItem Value="2">High</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">Normal</asp:ListItem>
                                    <asp:ListItem Value="1">Low</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Subject:</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMailSubject" runat="server" Width="775px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMailSubjects" runat="server" ControlToValidate="txtMailSubject" ErrorMessage="Please enter a valid email subject" Text="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Description :</td>
                            <td class="fv-edit">
                                <telerik:RadEditor ID="txtMailBody" runat="server" EnableResize="False" Height="250px" ContentFilters="DefaultFilters,MakeUrlsAbsolute" RenderMode="Lightweight" Width="775px">
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Attatchment :</td>
                            <td class="fv-edit">
                                <asp:FileUpload ID="fuMailAttatchment1" runat="server" Width="785px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Attatchment :</td>
                            <td class="fv-edit">
                                <asp:FileUpload ID="fuMailAttatchment2" runat="server" Width="785px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <table class="tbl-main">
        <tr>
            <td style="text-align: left">
                <asp:Button ID="btSend" runat="server" CssClass="btn-save" OnClick="btSend_Click" Text="Send" />
            </td>
        </tr>
    </table>
</asp:Content>
