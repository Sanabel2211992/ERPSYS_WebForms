<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="ERPSYS.ERP.settings.Profile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            $(document).ready(function (e) {
                $('#<%=imgLogo.ClientID %>').hover(function (e) {
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
                        $('#<%=imgLogo.ClientID %>').attr('src', e.target.result);
                    }
                    fildr.readAsDataURL(input.files[0]);
                    }
                }

                function OpenFiledialog() {
                    document.getElementById('<%= fuLogo.ClientID  %>').click();
                }
        </script>
    </telerik:RadCodeBlock>
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Company Information</legend>
                    <table class="tbl-inner" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Company Name : </td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Address :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtAddress1" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress1"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtAddress2" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Country :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCountry"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">City :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCity" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">State :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtState" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Zip/Postal Code :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPostalCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Phone :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Fax :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFax"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtEmail" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Website :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtWebsite" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtWebsite"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Tax Number :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtTaxNumber" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="img-profile-user user-set-pos">
                        <asp:Image ID="imgLogo" runat="server" Height="160px" Width="160px" onclick="OpenFiledialog(); return false;" />
                        <div id="UpdatePicture" class="img-profile-user-update" onclick="OpenFiledialog(); return false;">
                            <img src="../resources/images/ico_updte_profile.png" class="icon-update" height="16" width="16" /><span>Update Company Logo</span>
                        </div>
                    </div>
                    <div style="position: absolute; top: 190px; right: 13px;">
                        <asp:RegularExpressionValidator ID="revLogoImage" runat="server"
                            ControlToValidate="fuLogo"
                            ErrorMessage="Only png, jpg, jpeg Files are allowed"
                            ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                    </div>
                    <asp:FileUpload ID="fuLogo" runat="server" accept=".png,.jpg,.jpeg" onchange="ImagePreview(this)" Style="display: none;" />
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
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
