<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-trans.aspx.cs" Inherits="ERPSYS.ERP.inventory.GoodsTrans" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Product Information</legend>
                    <table class="tbl-inner" style="width: 600px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-viewe">Description :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-viewe">Catalog Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label></td>
                            <td class="ft-viewe">Part Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPartNumber" runat="server"></asp:Label></td>
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
                            <telerik:RadGrid ID="rgGoodsTransaction" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgGoodsTransaction_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No Data Found
                                                </td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="TransactionDate" HeaderText="Date" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="VoucherType" HeaderText="Voucher Type" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="VoucherId" HeaderText="VoucherId" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="LocationId" HeaderText="LocationId" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="QTY" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="QuantityBefore" HeaderText="QTY (B)" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="QuantityAfter" HeaderText="QTY (A)" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="AverageCostBefore" HeaderText="Cost (B)" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="AverageCostAfter" HeaderText="Cost (A)" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
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
            <telerik:AjaxSetting AjaxControlID="rgGoodsTransaction">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodsTransaction" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
