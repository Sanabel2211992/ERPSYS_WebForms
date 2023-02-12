<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-cost.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteCost" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Quotation Information</legend>
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
                            <td class="ft-view">Quote # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblQuoteNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Value="back" Text="Back" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="55px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Total Summary</legend>
                    <table class="tbl-inner-view" style="width: 1125px">
                        <tr>
                            <td class="ft-view" style="width: 100px">Sub Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                            </td>
                            <%--                            <td class="ft-view" style="width: 100px">Expenses :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblExpenses" runat="server"></asp:Label>
                            </td>--%>
                            <td class="ft-view" style="width: 100px">Discount :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                            </td>
                            <asp:Panel ID="pnlSalesTax" Visible="False" runat="server">
                                <td class="ft-view" style="width: 100px">Sales Tax :</td>
                                <td class="fv-view" style="width: 125px">
                                    <asp:Label ID="lblSalesTaxAmount" runat="server"></asp:Label></td>
                            </asp:Panel>
                            <td class="ft-view" style="width: 100px">Grand Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Total Cost :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Quotation Details</h3>
                    <telerik:RadGrid ID="rgQuoteGroup" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgQuoteGroup_NeedDataSource" OnDetailTableDataBind="rgQuoteGroup_DetailTableDataBind" OnPreRender="rgQuoteGroup_PreRender" OnItemDataBound="rgQuoteGroup_ItemDataBound">
                        <ClientSettings>
                            <ClientEvents OnGridCreated="main.GridCreated" OnHierarchyExpanded="main.HierarchyExpanded" OnHierarchyCollapsed="main.HierarchyCollapsed"></ClientEvents>
                        </ClientSettings>
                        <MasterTableView DataKeyNames="QuoteLineId,ItemId" Name="MainItem" HierarchyLoadMode="Client">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ParentId,QuoteLineId,ItemId" Name="SubItems" BorderWidth="0" Width="100%">
                                    <ParentTableRelation>
                                        <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="QuoteLineId"></telerik:GridRelationFields>
                                    </ParentTableRelation>
                                    <NoRecordsTemplate>
                                        <table class="rginnerEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px"></telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Unit Price" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="80px"></telerik:GridTemplateColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="QuoteId" HeaderText="QuoteId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Unit Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgQuoteGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuoteGroup" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
