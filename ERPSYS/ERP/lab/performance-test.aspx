<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="performance-test.aspx.cs" Inherits="ERPSYS.ERP.lab.PerformanceTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-grid">
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
                &nbsp;List</td>
            <td>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
                &nbsp;Table</td>
            <td>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Enter Number To Round Up :
            </td>
            <td>
                <asp:TextBox ID="txtRoundUp" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btntxtRoundUp" runat="server" Text="RoundUp" OnClick="btntxtRoundUp_Click" />
            </td>
            <td>
                <asp:Label ID="lbltxtRoundUp" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
