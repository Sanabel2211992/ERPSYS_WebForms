<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-setting.aspx.cs" Inherits="ERPSYS.ERP.item.ItemSetting" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Products Search Criteria</legend>
                    <table class="tbl-search" style="width: 900px">
                        <tr>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Category :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-search">Sub Category</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search">&nbsp;</td>
                            <td class="fv-search">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">New Settings</legend>
                    <table class="tbl-edit" style="width: 750px">
                        <tr>
                            <th class="ft-edit" style="width: 200px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 200px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit"><strong>Description</strong></td>
                            <td class="ft-edit"><strong>Value</strong></td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="ft-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbUpdateIsSold" runat="server" Text="Update Can Be Solde Field" />
                            </td>
                            <td class="fv-edit">
                                <asp:RadioButtonList ID="rbtnlstSold" runat="server" RepeatDirection="Horizontal" Width="100px">
                                         <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbIsManufacture" runat="server" Text="Update Manufacture Field" />
                            </td>
                            <td class="fv-edit">
                                <asp:RadioButtonList ID="rbtnlstManufactur" runat="server" RepeatDirection="Horizontal" Width="100px">
                                                      <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbHasBOM" runat="server" Text="Update Enable BOM Field" />
                            </td>
                            <td class="fv-edit">
                                <asp:RadioButtonList ID="rbtnlstBOM" runat="server" RepeatDirection="Horizontal" Width="100px">
                                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 100px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                                OnClick="btnSave_Click" />
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
                    <telerik:AjaxUpdatedControl ControlID="ddlSubCategory" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

