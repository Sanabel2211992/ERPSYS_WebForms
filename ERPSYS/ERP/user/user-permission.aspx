<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="user-permission.aspx.cs" Inherits="ERPSYS.ERP.user.UserPermission" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">User Information</legend>
                    <table class="tbl-view" style="width: 1160px">
                        <tr>
                            <th class="ft-view" style="width: 170px"></th>
                            <th class="fv-view" style="width: 120px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Display Name :</td>
                            <td class="fv-view" colspan="2">
                                <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Username :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">User Title :</td>
                            <td class="fv-view" colspan="2">
                                <asp:Label ID="lblUserTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Permission Template :</td>
                            <td class="fv-view">
                                <asp:DropDownList ID="ddlGroupPermission" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupPermission_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="sec-title">Permission To view Items Cost
            </td>
        </tr>
        <tr>
            <td class="fv-view">
                <asp:CheckBox ID="cbViewCost" Text="View Cost" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="right-btn">
                <asp:Button ID="btnSelectAll" runat="server" CssClass="btn-op" Text="Select All" OnClick="btnSelectAll_Click" />
                <asp:Button ID="btnClearAll" runat="server" CssClass="btn-op" Text="Clear All" OnClick="btnClearAll_Click" />
            </td>
        </tr>
        <tr>
            <td class="sec-title">Pages Permissions
            </td>
        </tr>
        <tr>
            <td class="fv-view">
                <asp:CheckBoxList ID="cblPageNames" runat="server" Width="100%" RepeatColumns="3">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" OnClientClick="return confirm('Are you sure you want to update user permission?');" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default"/>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlGroupPermission">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cblPageNames" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSelectAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cblPageNames" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnClearAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cblPageNames" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
