<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="document-template.aspx.cs" Inherits="ERPSYS.ERP.settings.DocumentTemplate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Document Template Remarks</legend>
                    <table class="tbl-edit" style="width: 900px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view" style="width: 125px">Company Name :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view" style="width: 125px">Document Type :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:DropDownList ID="ddlDocumentTypes" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDocumentTypes_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-edit" style="width: 1160px">
                    <tr>
                        <th style="width: 1160px"></th>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Terms and Conditions) </h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark1" runat="server" Height="150px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Additional Notes)</h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark2" runat="server" Height="150px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 150px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the information?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCompanyCode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtRemark1" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="txtRemark2" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlDocumentTypes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtRemark1" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="txtRemark2" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
