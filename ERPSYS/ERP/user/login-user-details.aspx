<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="login-user-details.aspx.cs" Inherits="ERPSYS.ERP.user.LoginUserDetails" %>

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
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">User Information</legend>
                    <table class="tbl-edit" style="width: 935px">
                        <tr>
                            <th class="ft-edit" style="width: 135px"></th>
                            <th class="fv-edit" style="width: 800px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit" style="height: 170px">Profile Picture :</td>
                            <td>
                                <div class="img-profile-user user-prof-pos">
                                    <asp:Image ID="imgUserImage" runat="server" Height="160px" Width="160px" onclick="OpenFiledialog(); return false;" />
                                    <div id="UpdatePicture" class="img-profile-user-update" onclick="OpenFiledialog(); return false;">
                                        <img src="../resources/images/ico_updte_profile.png" class="icon-update" height="16" width="16" /><span>Update Profile Picture</span>
                                    </div>
                                </div>
                                <div style="position: absolute; top: 155px; left: 310px;">
                                    <asp:RegularExpressionValidator ID="revUserImage" runat="server"
                                        ControlToValidate="fuUserImage"
                                        ErrorMessage="Only png, jpg, jpeg Files are allowed."
                                        ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                                </div>
                                <asp:FileUpload ID="fuUserImage" runat="server" Width="300px" accept=".png,.jpg,.jpeg" onchange="ImagePreview(this)" Style="display: none;" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbRemoveImage" runat="server" Text="Remove profile picture" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Mobile Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMobile" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email Address :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmailText" CssClass="val-error" runat="server" ControlToValidate="txtEmail" ErrorMessage="Your email address is invalid, Please enter a valid address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email Signature :</td>
                            <td class="fv-edit">
                                <telerik:RadEditor ID="txtUserSignature" runat="server" Height="200px" Width="775px"
                                    RenderMode="Lightweight"
                                    EnableResize="False" EnableTheming="True">
                                </telerik:RadEditor>
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
