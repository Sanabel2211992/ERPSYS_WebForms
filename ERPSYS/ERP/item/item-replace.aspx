<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-replace.aspx.cs" Inherits="ERPSYS.ERP.item.item_replace" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>

<asp:Content ID="chMain" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <telerik:RadAjaxPanel runat="server" ID="rjpReplaceItem" LoadingPanelID="lpLoading">
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Search Product To Replace</legend>
                        <table class="tbl-view" style="width: 900px">
                            <tr>
                                <th class="ft-search" style="width: 125px"></th>
                                <th class="fv-search" style="width: 175px"></th>
                                <th class="ft-search" style="width: 125px"></th>
                                <th class="fv-search" style="width: 175px"></th>
                                <th class="ft-search" style="width: 125px"></th>
                                <th class="fv-search" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div class="grid-container no-bg">
                                        <h3>Replace This Product</h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-search">Product Search :</td>
                                <td class="fv-search" colspan="5" style="position: relative">
                                    <telerik:RadSearchBox ID="rsbItemRep" runat="server"
                                        DataKeyNames="ItemCode,PartNumber,Description"
                                        DataTextField="DisplayName"
                                        DataValueField="ItemId"
                                        EnableAutoComplete="true"
                                        ShowSearchButton="true"
                                        Filter="StartsWith"
                                        MaxResultCount="20"
                                        Width="675px" OnDataSourceSelect="rsbItemRep_DataSourceSelect" OnLoad="rsbItemRep_Load" OnSearch="rsbItemRep_Search">
                                        <DropDownSettings Width="675px" />
                                    </telerik:RadSearchBox>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlOldItem" runat="server" Visible="false">
                                <tr>
                                    <td class="ft-search">Product Name :</td>
                                    <td class="fv-search" colspan="5">
                                        <asp:Label ID="lblDescriptionRep" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ft-search">Catalog Number :</td>
                                    <td class="fv-search">
                                        <asp:Label ID="lblItemCodeRep" runat="server"></asp:Label>
                                    </td>
                                    <td class="ft-search">Part Number :</td>
                                    <td class="fv-search">
                                        <asp:Label ID="lblPartNumberRep" runat="server"></asp:Label>
                                    </td>
                                    <td class="ft-search"></td>
                                    <td class="fv-search"></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <div class="grid-container no-bg">
                                        <h3>With this Product </h3>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-search">Product Search :</td>
                                <td class="fv-search" colspan="5" style="position: relative">
                                    <telerik:RadSearchBox ID="rsbItemAlt" runat="server"
                                        DataKeyNames="ItemCode,PartNumber,Description"
                                        DataTextField="DisplayName"
                                        DataValueField="ItemId"
                                        EnableAutoComplete="true"
                                        ShowSearchButton="true"
                                        Filter="StartsWith"
                                        MaxResultCount="20"
                                        Width="675px" OnDataSourceSelect="rsbItemAlt_DataSourceSelect" OnLoad="rsbItemAlt_Load" OnSearch="rsbItemAlt_Search">
                                        <DropDownSettings Width="675px" />
                                    </telerik:RadSearchBox>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlNewItem" runat="server" Visible="false">
                                <tr>
                                    <td class="ft-search">Product Name :</td>
                                    <td class="fv-search" colspan="5">
                                        <asp:Label ID="lblDescriptionAlt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ft-search">Catalog Number :</td>
                                    <td class="fv-search">
                                        <asp:Label ID="lblItemCodeAlt" runat="server"></asp:Label>
                                    </td>
                                    <td class="ft-search">Part Number :</td>
                                    <td class="fv-search">
                                        <asp:Label ID="lblPartNumberAlt" runat="server"></asp:Label>
                                    </td>
                                    <td class="ft-search"></td>
                                    <td class="fv-search"></td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                                <td class="ft-search">&nbsp;</td>
                                <td class="fv-search">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-search">Remarks :</td>
                                <td class="fv-search" colspan="5">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="455px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </telerik:RadAjaxPanel>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnReplace" runat="server" Text="Replace" CssClass="btn-op" OnClientClick="return confirm('Are you sure you want to replace this product?');" ValidationGroup="save" OnClick="btnReplace_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-op" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
