<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-form.aspx.cs" Inherits="ERPSYS.ERP.item.ItemForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">

    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            $(document).ready(function (e) {
                $('#<%=imgItem.ClientID %>').hover(function (e) {
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
                        $('#<%=imgItem.ClientID %>').attr('src', e.target.result);
                    }
                    fildr.readAsDataURL(input.files[0]);
                    }
                }

                function OpenFiledialog() {
                    document.getElementById('<%= fuItemImage.ClientID  %>').click();
                }
        </script>

    </telerik:RadCodeBlock>
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Product Information</legend>
                    <table class="tbl-edit" style="width: 945px">
                        <tr>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 175px"></td>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 175px"></td>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Type :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlItemType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-edit">Additional Code :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtAdditionalCode" runat="server" Width="158px"></asp:TextBox>
                            </td>
                            <td class="ft-edit" colspan="2">
                                <asp:CheckBox ID="cbIsNonStandard" runat="server" Text="Non Standard Product" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Catalog Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemCode" runat="server" ControlToValidate="txtItemCode"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Part Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPartNumber" runat="server" Width="158px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtPartNumber" runat="server" ControlToValidate="txtPartNumber"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbBeSold" runat="server" Text="Can be Sold" />
                            </td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemName" runat="server" Width="480px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemName" runat="server" ControlToValidate="txtItemName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbManufacture" runat="server" Text="Manufacture" />
                            </td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Name (AR):</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemNameAr" runat="server" Width="480px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbHasBom" runat="server" Text="Enable BOM" />
                            </td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Show As :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemNameShowAs" runat="server" Width="480px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemNameShowAs" runat="server" ControlToValidate="txtItemNameShowAs"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" Checked="True" />
                            </td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit" colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Category :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Sub Category :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSubCategory" runat="server" ControlToValidate="ddlSubCategory"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Brand :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlBrand" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlBrand"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Unit of Measure :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlUom" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvUOM" runat="server" ControlToValidate="ddlUom"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Bar Code :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtBarCode" runat="server" Width="140px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Unit Price :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtUnitPrice" runat="server" Width="150px" MinValue="0" MaxValue="999999" EnableTheming="False">
                                    <NumberFormat DecimalDigits="2"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="ft-edit">Minimum Price :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtMinPrice" runat="server" Width="150px" MinValue="0" MaxValue="999999" EnableTheming="False">
                                    <NumberFormat DecimalDigits="2"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="465px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="img-item-pos1">
                    <tr>
                        <td>
                            <asp:Image ID="imgItem" runat="server" Height="160px" Width="160px" onclick="OpenFiledialog(); return false;" />
                            <div id="UpdatePicture" class="img-profile-user-update" onclick="OpenFiledialog(); return false;">
                                <img src="../resources/images/ico_updte_profile.png" class="icon-update" height="16" width="16" /><span>Update Product Picture</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="fuItemImage" runat="server" Width="150px" accept=".png,.jpg,.jpeg" onchange="ImagePreview(this)" Style="display: none;" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="revItemImage" runat="server" ControlToValidate="fuItemImage" ErrorMessage="Only jpg, png, jpeg Files are allowed"
                                ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:CheckBox ID="cbRemoveImage" runat="server" Text="Remove picture" />
                        </td>
                    </tr>
                </table>
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlSubCategory" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
