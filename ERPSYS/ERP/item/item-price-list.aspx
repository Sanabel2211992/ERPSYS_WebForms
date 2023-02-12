<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-price-list.aspx.cs" Inherits="ERPSYS.ERP.item.ItemPriceList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtDescription.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtPartNumber.ClientID %>').val("");
            $('#<%= ddlCategory.ClientID %>').val("");
            $('#<%= ddlType.ClientID %>').val("");
            $('#<%= ddlBrand.ClientID %>').val("");
            $('#<%= cbAvailableOnly.ClientID %>').removeAttr('checked');
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 1180px">

                        <tr>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 170px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 170px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 170px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 170px"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Description :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtDescription" runat="server" Width="455px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Product Type :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search" colspan="2">
                                <asp:CheckBox ID="cbAvailableOnly" runat="server" Text="Only available products." />
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
                            <td class="ft-search">Category :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Brand :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlBrand" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-search" OnClientClick="ClearFields(); return false;" />
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
                <telerik:RadToolBarButton runat="server" CommandName="export" Value="export" OuterCssClass="pull-right" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgItemList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="True" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgItemList_NeedDataSource" OnInit="rgItemList_Init">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table class="rgEmptyData">
                        <tr>
                            <td>No Data Found</td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("item-preview-x.aspx?id={0}", Eval("ItemId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Product Details" title="Product Details" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="650px" />
                    <telerik:GridBoundColumn DataField="BrandCode" HeaderText="Brand" HeaderStyle-Width="75px" />
                    <telerik:GridBoundColumn DataField="CategoryCode" HeaderText="Category" HeaderStyle-Width="50px" />
                    <telerik:GridBoundColumn DataField="SellingPrice" DataFormatString="{0:F2}" HeaderText="Unit Price" HeaderStyle-Width="75px" />
                    <telerik:GridBoundColumn DataField="AvailableQuantity" DataFormatString="{0:F0}" HeaderText="Store QTY" HeaderStyle-Width="75px" />
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
                    <telerik:AjaxUpdatedControl ControlID="rgItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgItemList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
