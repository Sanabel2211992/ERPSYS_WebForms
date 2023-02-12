<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="Catalog-Add2.aspx.cs" Inherits="ERPSYS.ERP.t.Catalog_Add2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register Src="Add-Catalog.ascx" TagName="Add" TagPrefix="uc1" %>
<%@ Register Src="~/ERP/t/Add-Brand.ascx" TagPrefix="uc2" TagName="AddBrand" %>
<%@ Register Src="~/ERP/t/Add-Measure.ascx" TagPrefix="uc3" TagName="AddMeasure" %>
<%@ Register Src="~/ERP/t/Add-Sub-Category.ascx" TagPrefix="uc4" TagName="AddSubCategory" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">

    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Choose or Add Category</legend>
        <table class="tbl-inner-view" style="width: 325px">
            <tr>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 200px"></td>
            </tr>
            <tr>
                <td class="field-title">Category :</td>
                <td class="field-title">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="150px"></asp:DropDownList>
                    &nbsp;
                    <uc1:Add ID="Add1" runat="server" OnFinishClicked="MyUserControl1_FinishClicked" />
                </td>
            </tr>
            <tr>
                <td class="field-title">AddBrand :</td>
                <td class="field-title">
                    <uc2:AddBrand runat="server" ID="AddBrand" />
                </td>
            </tr>
            <tr>
                <td class="field-title">AddMeasure :</td>
                <td class="field-title">
                    <uc3:AddMeasure runat="server" ID="AddMeasure" />
                </td>
            </tr>
            <tr>
                <td class="field-title">AddSubCategory :</td>
                <td class="field-title">
                    <uc4:AddSubCategory runat="server" ID="AddSubCategory" />
                </td>
            </tr>
        </table>
    </fieldset>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Add1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlCategory" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>