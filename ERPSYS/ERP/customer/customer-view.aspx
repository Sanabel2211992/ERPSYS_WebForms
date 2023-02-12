<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="customer-view.aspx.cs" Inherits="ERPSYS.ERP.customer.CustomerView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Value="back" Text="Back" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="55px" />
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Customer Information</legend>
                    <table class="tbl-view" style="width: 1180px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td colspan="3" class="fv-view">
                                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Arabic Name :</td>
                            <td colspan="3" class="fv-view">
                                <asp:Label ID="lblCustomerNameAr" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Contact Name :</td>
                            <td colspan="3" class="fv-view">
                                <asp:Label ID="lblContact" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Country :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">City :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">State :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Address 1 :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Address 2 :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Postal Code :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Phone :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Fax :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblFax" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Email :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Payment Methods :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Payment Terms :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPaymentTerms" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
