<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-production-store-details.aspx.cs" Inherits="ERPSYS.ERP.inventory.goods_production_store_details" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Product Information</legend>
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
                            <td class="ft-view">Description :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Catalog Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Part Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
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
                            <telerik:RadGrid ID="rgGoodsProItem" runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgGoodsProItem_NeedDataSource" OnInit="rgGoodsProItem_Init">
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
                                        <telerik:GridTemplateColumn HeaderText="Material Transfer #" HeaderStyle-Width="125px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("../scm/goods-receipt-preview.aspx?id={0}", Eval("MaterialTransferId")) %>'><%# Eval("MaterialTransferNumber") %></a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ProductionDate" HeaderText="Production Date" HeaderStyle-Width="115px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="TotalQuantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="UOM" HeaderText="Unit" HeaderStyle-Width="50px" />
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
            <telerik:AjaxSetting AjaxControlID="rgGoodsReceivedItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodsReceivedItem" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
