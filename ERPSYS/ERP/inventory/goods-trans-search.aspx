<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-trans-search.aspx.cs" Inherits="ERPSYS.ERP.inventory.GoodsTransSearch" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 600px">
                        <tr>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Description :</td>
                            <td class="ft-search" colspan="3">
                                <asp:TextBox ID="txtDescription" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Catalog Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Part Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtPartNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgGoodsList" runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgGoodsList_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table style="width: 100%" class="rgEmptyData">
                                            <tr>
                                                <td>No Data Found
                                                </td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("goods-trans.aspx?id={0}", Eval("ItemId")) %>'>View Product Card Report
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
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
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgGoodsList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
