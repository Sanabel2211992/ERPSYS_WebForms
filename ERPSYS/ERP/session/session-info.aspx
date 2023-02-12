<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="session-info.aspx.cs" Inherits="ERPSYS.ERP.session.SessionInfo" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-view" style="width: 620px">
                    <tr>
                        <td class="ft-view" style="width: 135px"></td>
                        <td class="fv-view" style="width: 175px"></td>
                        <td class="ft-view" style="width: 135px"></td>
                        <td class="fv-view" style="width: 175px"></td>
                    </tr>
                    <tr>
                        <td class="ft-view">Session Id :</td>
                        <td class="fv-view" colspan="3">
                            <asp:Label ID="lblSessionId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ft-view">Display Name :</td>
                        <td class="fv-view" colspan="3">
                            <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ft-view">Username :</td>
                        <td class="fv-view">
                            <asp:Label ID="lblUsername" runat="server"></asp:Label>
                        </td>
                        <td class="ft-view">Machine Name :</td>
                        <td class="fv-view">
                            <asp:Label ID="lblMachineName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ft-view">Server IP Address :</td>
                        <td class="fv-view">
                            <asp:Label ID="lblServerIPAddress" runat="server"></asp:Label>
                        </td>
                        <td class="ft-view">Public IP Address :</td>
                        <td class="fv-view">
                            <asp:Label ID="lblPublicIPAddress" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ft-view">Version :</td>
                        <td class="fv-view">
                            <asp:Label ID="lblFrameWorkVersion" runat="server"></asp:Label>
                        </td>
                        <td class="ft-view">&nbsp;</td>
                        <td class="fv-view">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="ft-view">Browser :</td>
                        <td class="fv-view" colspan="3">
                            <asp:Label ID="lblBrowser" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ft-view">&nbsp;</td>
                        <td class="fv-view">&nbsp;</td>
                        <td class="ft-view">&nbsp;</td>
                        <td class="fv-view">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
