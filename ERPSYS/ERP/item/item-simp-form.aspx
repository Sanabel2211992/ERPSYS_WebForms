<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-simp-form.aspx.cs" Inherits="ERPSYS.ERP.item.ItemSempForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
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
                                <asp:DropDownList ID="ddlItemType" runat="server" Width="158px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                            <td class="ft-edit" colspan="2">&nbsp;</td>
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
                                <asp:CheckBox ID="cbBeSold" runat="server" Text="Can be Sold" Checked="true" />
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
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
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
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
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
                            <asp:Image ID="imgItem" runat="server" Height="150px" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="fuItemImage" runat="server" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="revUserImage" runat="server" ControlToValidate="fuItemImage" ErrorMessage="Only jpg, png, jpeg Files are allowed"
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
