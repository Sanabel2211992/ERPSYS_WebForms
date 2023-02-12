<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-order-preview.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesOrderPreview" %>

<%@ Import Namespace="ERPSYS.Helpers.Ext" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">

        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Sales Order ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post Sales Order?"));
            }
            else if (button.get_commandName() === "clone") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
            else if (button.get_commandName() === "jorderc") {
                args.set_cancel(!confirm("Are you sure you want to create Job Order?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Sales Order Information</legend>
                    <table class="tbl-view" style="width: 1080px">
                        <tr>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer L.P.O :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCustomerPO" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
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
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete Order" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="100px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post order" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="100px" />
                        <telerik:RadToolBarButton runat="server" CommandName="adjust" Value="adjust" Text="Adjust order" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="clone" Value="clone" Text="clone" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png" Width="62px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="cost" Value="cost" Text="sales order cost" ImageUrl="~/ERP/resources/images/toolbar/ico-cost.png" Width="135px" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="jorderc" Value="jorderc" Text="Create Job Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="135px" />
                        <telerik:RadToolBarButton runat="server" CommandName="jorderv" Value="jorderv" Text="View Job Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="125px" />
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
                            <td class="ft-view" style="width: 100px">Expenses :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblExpenses" runat="server"></asp:Label>
                            </td>
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
                            <td class="fv-view">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Sales Order Details</h3>
                    <telerik:RadTabStrip RenderMode="Lightweight" ID="rtsOrder" runat="server" MultiPageID="RadMultiPage1" Width="250px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab PageViewID="RadPageView1" Width="125px" Text="Order" Selected="True" />
                            <telerik:RadTab PageViewID="RadPageView2" Width="125px" Text="Group Overview" Visible="False" />
                            <telerik:RadTab PageViewID="RadPageView3" Width="125px" Text="Overview" Visible="False" />
                            <telerik:RadTab PageViewID="RadPageView4" Width="125px" Text="Delivery" Visible="False" />
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="TabMultiPage" RenderSelectedPageOnly="True" Width="100%">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgSalesOrder" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="False" AllowSorting="False"
                                            OnNeedDataSource="rgSalesOrder_NeedDataSource" OnDetailTableDataBind="rgSalesOrder_DetailTableDataBind" OnPreRender="rgSalesOrder_PreRender" OnItemDataBound="rgSalesOrder_ItemDataBound">
                                            <ClientSettings>
                                                <ClientEvents OnGridCreated="main.GridCreated" OnHierarchyExpanded="main.HierarchyExpanded" OnHierarchyCollapsed="main.HierarchyCollapsed"></ClientEvents>
                                            </ClientSettings>
                                            <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem" HierarchyLoadMode="Client">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No records to display.</td>
                                                        </tr>
                                                    </table>
                                                </NoRecordsTemplate>
                                                <DetailTables>
                                                    <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" BorderWidth="0" Width="100%">
                                                        <ParentTableRelation>
                                                            <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="LineId"></telerik:GridRelationFields>
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
                                                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="600px" />
                                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                                            <telerik:GridTemplateColumn HeaderStyle-Width="80px"></telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                            <telerik:GridTemplateColumn UniqueName="IsService">
                                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                                <ItemTemplate>
                                                                    <asp:Image ID="imgService" runat="server" Height="16px" Width="16px" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </telerik:GridTableView>
                                                </DetailTables>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="OrderId" HeaderText="OrderId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="675px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                    <telerik:GridTemplateColumn UniqueName="IsService">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgService" runat="server" Height="16px" Width="16px" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgSalesOrderMasterLineStatus" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False"
                                            OnNeedDataSource="rgSalesOrderMasterLineStatus_NeedDataSource">
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
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Order QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="DeliveredQuantity" HeaderText="Delivered QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="RemainingQuantity" HeaderText="Remaining QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgSalesOrderCombinedLineStatus" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False"
                                            OnNeedDataSource="rgSalesOrderCombinedLineStatus_NeedDataSource" OnItemDataBound="rgSalesOrderCombinedLineStatus_ItemDataBound">
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
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Order QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="DeliveredQuantity" HeaderText="Delivered QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                    <telerik:GridBoundColumn DataField="RemainingQuantity" HeaderText="Remaining QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                    <telerik:GridBoundColumn DataField="StockQuantity" HeaderText="Stock QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" Display="False" />
                                                    <telerik:GridTemplateColumn HeaderText="Stock QTY*" HeaderStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <div>
                                                                <%# Convert.ToDecimal(Eval("RemainingQuantity")) > 0 ? Eval("StockQuantity").ToDecimalFormat(0) : "-"  %>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                    <telerik:GridTemplateColumn UniqueName="Status">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgStatus" runat="server" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="grid-note">*Available Quantity in all stores</td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView4" runat="server">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgDelivery" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" OnNeedDataSource="rgDelivery_NeedDataSource">
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
                                                    <telerik:GridBoundColumn DataField="ReceiptId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                                                    <telerik:GridBoundColumn DataField="ReceiptStatus" HeaderText="Status" HeaderStyle-Width="75px" />
                                                    <telerik:GridTemplateColumn HeaderText="Receipt #" HeaderStyle-Width="125px">
                                                        <ItemTemplate>
                                                            <div>
                                                                <a href='<%# string.Format("delivery-receipt-preview.aspx?id={0}", Eval("ReceiptId")) %>'><%# Eval("ReceiptNumber") %></a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridDateTimeColumn DataField="ReceiptDate" HeaderText="Receipt Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" />
                                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsOrder" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsOrder" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

