<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-close-partial.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderPartialClose" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Production Order Information</legend>
                    <table class="tbl-view" style="width: 1160px">
                        <tr>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Prod Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblProductionOrder" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Order Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUserDisplayName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Start Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">End Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Estimated Time :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEstimatedTime" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
