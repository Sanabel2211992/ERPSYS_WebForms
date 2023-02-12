<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-consigned-store.aspx.cs" Inherits="ERPSYS.ERP.inventory.GoodsConsignedStore" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtDescription.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtPartNumber.ClientID %>').val("");
        }
    </script>
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
                            <td class="fv-search" colspan="3">
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
    </table>
    <div>
        <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="export" OuterCssClass="pull-right" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgInvItemList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgInvItemList_NeedDataSource" OnInit="rgInvItemList_Init">
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
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <%-- <a href='<%# string.Format("goods-Consigned-store-details.aspx?id={0}", Eval("ItemId")) %>'>--%>
                                <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="View Product" style="border: 0" />
                                <%-- </a>--%>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="650px" />
                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                    <telerik:GridBoundColumn DataField="UOM" HeaderText="Unit" HeaderStyle-Width="50px" />
                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" />
        </telerik:RadGrid>
    </div>
    <%--<telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgInvItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgInvItemList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgInvItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
