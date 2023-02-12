<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/DialogBox/Dialog.Master" AutoEventWireup="true" CodeBehind="terms-conditions-preview.aspx.cs" Inherits="ERPSYS.Controls.DialogBox.EST.Quote.terms_conditions_preview" %>

<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }

        .rgAdvPart {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="cMain" ContentPlaceHolderID="dcphMain" runat="server">
    <table style="width: 810px">
        <tr>
            <td>
                <table class="tbl-edit" style="width: 810px">
                    <tr>
                        <th style="width: 800px"></th>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Terms and Conditions)</h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark1" runat="server" Height="110px" ReadOnly="true" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Additional Notes)</h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark2" runat="server" Height="110px" ReadOnly="true" TextMode="MultiLine" Width="800px"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <%--
                    <table class="tbl-op-center" style="width: 200px">
                        <tr>
                            <td>
                                <asp:Button ID="btnBack" runat="server" Text="Close" CssClass="btn-save" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                --%>
            </td>
        </tr>
    </table>
</asp:Content>
