<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="MessageDaialog.aspx.cs" Inherits="ERPSYS.ERP.t.MessageDaialog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/ERP/t/Add-Sub-Category.ascx" TagPrefix="uc1" TagName="AddSubCategory" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">

    <script type="text/javascript">

    </script>

</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button runat="server" Text="Showitems" OnClick="Unnamed1_Click1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Button runat="server" Text="ShowMessage" OnClick="Unnamed1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnTicket" runat="server" Text="ShowUC" OnClick="btnTicket_Click"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:PlaceHolder ID="phviewUC" runat="server"></asp:PlaceHolder>

            </td>
        </tr>
    </table>

    <telerik:RadWindow ID="rwLogin" Height="300px" Width="500px" runat="server" VisibleOnPageLoad="true" Visible="false">
        <ContentTemplate>
            <asp:Panel ID="pWelcome" runat="server" Visible="false">
                <asp:Label ID="lbname" runat="server" Text="Label" Style="font-weight: 700; font-size: x-large"></asp:Label>
                <br />
                <asp:Label ID="lbemail" runat="server" Text="Label" Style="font-weight: 700; font-size: medium"></asp:Label>

            </asp:Panel>
            <asp:Panel ID="pLogIn" runat="server" Visible="true">
                <label>Name:</label>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <label>Email:</label>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtemail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Button1_Click" />

            </asp:Panel>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">

        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <uc1:AddSubCategory runat="server" ID="AddSubCategory" />
</asp:Content>
