<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-receipt-create.aspx.cs" Inherits="ERPSYS.ERP.scm.GoodsReceiptCreate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/ComboBox/UCSupplierList.ascx" TagName="UCSupplierList" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Material Receipt Information</legend>
                    <table class="tbl-edit" style="width: 590px">
                        <tr>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Supplier :</td>
                            <td class="fv-edit" colspan="3">
                                <uc1:UCSupplierList ID="UCSupplier" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Received Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCOrderDate" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit" colspan="3">
                                <asp:CheckBox ID="cbConsignedGoods" runat="server" AutoPostBack="True" Text="Mark as Consigned Goods (Goods will added to Consigned Store)" OnCheckedChanged="cbConsignedGoods_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="446px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" Width="100px" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the material receipt?'); } else return;};"
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
    <telerik:RadAjaxManager ID="radAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cbConsignedGoods">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlLocation" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
