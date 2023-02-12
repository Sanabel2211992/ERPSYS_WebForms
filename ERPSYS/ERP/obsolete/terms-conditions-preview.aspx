<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="terms-conditions-preview.aspx.cs" Inherits="ERPSYS.ERP.obsolete.terms_conditions_preview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tbl-main">
            <tr>
                <td>
                    <table class="tbl-edit" style="width: 820px">
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
                                <asp:TextBox ID="txtRemark2" runat="server" Height="110px" ReadOnly="true"  TextMode="MultiLine" Width="800px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--<tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 200px">
                        <tr>
                            <td>
                                <asp:Button ID="btnBack" runat="server" Text="Close" CssClass="btn-save" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </form>
</body>
</html>
