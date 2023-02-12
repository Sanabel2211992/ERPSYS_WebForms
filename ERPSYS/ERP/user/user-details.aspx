<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="user-details.aspx.cs" Inherits="ERPSYS.ERP.user.UserDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            $(document).ready(function (e) {
                $('#<%=imgUserImage.ClientID %>').hover(function (e) {
                    $("#UpdatePicture").toggle();
                    $("#UpdatePicture").hover(function () { $(this).show(); }, function () { $(this).hide(); });
                });
            });

            function ImagePreview(input) {
                var file = input.files[0];
                if (!(/\.(png|jpeg|jpg)$/i).test(file.name)) {
                    return;
                }
                if (input.files && input.files[0]) {
                    var fildr = new FileReader();
                    fildr.onload = function (e) {
                        $('#<%=imgUserImage.ClientID %>').attr('src', e.target.result);
                    }
                    fildr.readAsDataURL(input.files[0]);
                    }
                }

                function OpenFiledialog() {
                    document.getElementById('<%= fuUserImage.ClientID  %>').click();
                }
        </script>
    </telerik:RadCodeBlock>
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">User Information</legend>
                    <table class="tbl-edit" style="width: 900px;">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Display Name :</td>
                            <td colspan="3" class="fv-edit">
                                <asp:TextBox ID="txtDisplayName" runat="server" Width="455px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server" ControlToValidate="txtDisplayName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Username :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtUsername" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">User Title :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtUsertitle" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsertitle" runat="server" ControlToValidate="txtUsername"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <asp:Panel runat="server" ID="pnlPassowrd">
                            <tr>
                                <td class="ft-edit">Password :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit"></td>
                                <td class="fv-edit"></td>
                                <td class="ft-edit"></td>
                                <td class="fv-edit"></td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td class="ft-edit">Status</td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" Text="Active" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="158px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Role :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlRole" runat="server" Width="158px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvRole" ControlToValidate="ddlRole" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" />
                            </td>
                            <td class="ft-edit">Department :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Width="158px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvDepartment" ControlToValidate="ddlDepartment" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Mobile Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMobile" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Email Address :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmail" runat="server" Width="150px" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email Signature :</td>
                            <td class="fv-edit" colspan="5">
                                <telerik:RadEditor ID="txtUserSignature" runat="server" Height="200px" Width="750px"
                                    RenderMode="Lightweight"
                                    EnableResize="False" EnableTheming="True">
                                </telerik:RadEditor>
                            </td>
                        </tr>
                    </table>
                    <div class="img-profile-user user-set-pos">
                        <asp:Image ID="imgUserImage" runat="server" Height="160px" Width="160px" onclick="OpenFiledialog(); return false;" />
                        <div id="UpdatePicture" class="img-profile-user-update" onclick="OpenFiledialog(); return false;">
                            <img src="../resources/images/ico_updte_profile.png" class="icon-update" height="16" width="16" /><span>Update Profile Picture</span>
                        </div>
                    </div>
                    <div style="position: absolute; top: 190px; right: 13px;">
                        <asp:RegularExpressionValidator ID="revUserImage" runat="server"
                            ControlToValidate="fuUserImage"
                            ErrorMessage="Only png, jpg, jpeg Files are allowed"
                            ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                    </div>
                    <asp:FileUpload ID="fuUserImage" runat="server" accept=".png,.jpg,.jpeg" onchange="ImagePreview(this)" Style="display: none;" />
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
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
