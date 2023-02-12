<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewComment.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SC.UCViewComment" %>
<asp:Panel ID="pnlComment" runat="server">
    <table class="tbl-uc-gedit" style="width: 100%; font-size: medium; border: groove; border-color: gray; border-width: 0.01px">
        <tr>
            <td>
                <div style="background-color: ActiveCaption">
                    <table>
                        <tr>
                            <td style="width: 40px">
                                <asp:Image ID="Image1" runat="server" CssClass="user-pic" Height="30px" ToolTip="user" Width="30px" />
                            </td>
                            <td style="width: 1100px; font-size: small">
                                <asp:Label ID="lblUserName" runat="server" Width="470px" Text="User"></asp:Label>
                            </td>
                            <td style="width: 150px; font-size: 13px">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblText" runat="server" Width="550px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlAttachment" Visible="false">
                                <div style="background-color: #ffffe6; border: dotted; border-width: thin; font-size:small; width:1160px">
                                    <u ><b>
                                        <img src="../../Controls/resources/images/attachment16x16.png" alt="Attachment" height="16" width="16" />
                                        Files Attachment</b></u>
                                    <ul style="list-style-type: square;">
                                        <asp:PlaceHolder ID="phviewLink" runat="server"></asp:PlaceHolder>
                                    </ul>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
