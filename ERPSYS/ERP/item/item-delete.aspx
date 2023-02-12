<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-delete.aspx.cs" Inherits="ERPSYS.ERP.item.ItemDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Product Information</legend>
        <table class="tbl-view" style="width: 930px">
            <tr>
                <td class="ft-view" style="width: 135px"></td>
                <td class="fv-view" style="width: 175px"></td>
                <td class="ft-view" style="width: 135px"></td>
                <td class="fv-view" style="width: 175px"></td>
                <td class="ft-view" style="width: 135px"></td>
                <td class="fv-view" style="width: 175px"></td>
            </tr>
            <tr>
                <td class="ft-view">Product Name :</td>
                <td colspan="5" class="fv-view">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="ft-view">Catalog Number :</td>
                <td class="fv-view">
                    <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                </td>
                <td class="ft-view" style="width: 110px">Part Number :</td>
                <td class="fv-view">
                    <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Important Note </legend>
        <table class="tbl-view" style="width: 100%">
            <tr>
                <td class="lnote">You can delete the Product records where there is has been no open transaction or Stock in inventory and not used in any business transaction and not included in any Bill of material.
                </td>
            </tr>
        </table>
    </fieldset>
    <table class="tbl-op-center" style="width: 200px">
        <tr>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn-op" OnClientClick="return confirm('Are you sure you want to delete this product??');" OnClick="btnConfirm_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-op" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
