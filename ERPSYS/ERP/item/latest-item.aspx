<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="latest-item.aspx.cs" Inherits="ERPSYS.ERP.item.latest_item" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 775px">
                        <tr>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 175px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 175px"></td>
                            <td class="ft-search" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Product Search :</td>
                            <td class="fv-search" colspan="4">
                                <asp:TextBox ID="txtProductSearch" runat="server" Width="400px"></asp:TextBox>
                                (Part Number, Catalog No or Description)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
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
                            <telerik:RadGrid ID="rgItemList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="True" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgItemList_NeedDataSource" OnInit="rgItemList_Init" OnItemDataBound="rgItemList_ItemDataBound">
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
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                        <telerik:GridBoundColumn DataField="EntryUser" HeaderText="Prepared By" HeaderStyle-Width="150px" />
                                        <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Entry Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="ModifyUser" HeaderText="Modified By" HeaderStyle-Width="150px" />
                                        <telerik:GridDateTimeColumn DataField="ModifyDate" HeaderText="Modify Date"  DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true" />
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
                    <telerik:AjaxUpdatedControl ControlID="rgItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgItemList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
