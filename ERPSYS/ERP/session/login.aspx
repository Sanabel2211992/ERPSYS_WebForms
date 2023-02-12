<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Login.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ERPSYS.ERP.session.Login" %>

<asp:Content ID="cLoginHeader" ContentPlaceHolderID="cphLoginHeader" runat="server">
</asp:Content>
<asp:Content ID="cLoginMain" ContentPlaceHolderID="cphLoginMain" runat="server">
    <div class="min-container">
        <div class="login-contant">
            <h2>Log In</h2>
            <p>
                Please enter your username and password.
            </p>
            <div class="accountInfo">
                <fieldset class="login"> 
                    <p>
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                    </p>
                    <p class="Legend-P relative">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtLoginUsername">Username:</asp:Label>
                        <asp:TextBox ID="txtLoginUsername" runat="server" CssClass="textEntry"></asp:TextBox>
                        <span class="star">
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtLoginUsername"
                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator></span>
                    </p>
                    <p class="Legend-P relative">
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtLoginPassword">Password:</asp:Label>

                        <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <span class="star1">
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtLoginPassword"
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator></span>
                    </p>
                    <p class="Legend-P">
                        <asp:CheckBox ID="cbRememberMe" runat="server" />
                        <asp:Label ID="RememberMeLabel" runat="server" CssClass="inline" AssociatedControlID="cbRememberMe">Remember me</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton-login">
                    <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="btnLogin_Click" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
