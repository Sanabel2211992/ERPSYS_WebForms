<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-preview.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoicePreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Sales Invoice ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post Sales Invoice ?"));
            }
            else if (button.get_commandName() === "clone") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Sales Invoice Information</legend>
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
                            <td class="ft-view">Invoice Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Invoice Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Invoice Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Location :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkSalesOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Customer L.P.O :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCustomerPO" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Currency (View): </td>
                            <td class="fv-view">
                                <asp:Label ID="lblCurrencyView" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="grid-note">
                <asp:CheckBox ID="cbSetRefrenceManually" runat="server" Visible="False" Text="Set custom reference number for the Sales Invoice." />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="clone" Value="clone" Text="clone" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png" Width="62px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="refund" Value="refund" Text="Refund Invoice" ImageUrl="~/ERP/resources/images/toolbar/ico_replace.png" Width="115px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="cost" Value="cost" Text="sales invoice cost" ImageUrl="~/ERP/resources/images/toolbar/ico-cost.png" Width="140px" />
                        <telerik:RadToolBarButton runat="server" CommandName="receipt" Value="receipt" Text="Stock Receipt" ImageUrl="~/ERP/resources/images/toolbar/ico_store.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
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
                    <h3>Sales Invoice Details</h3>
                    <telerik:RadTabStrip RenderMode="Lightweight" ID="rts" runat="server" MultiPageID="RadMultiPage1" Width="250px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab PageViewID="RadPageView1" Width="125px" Text="Invoice" Selected="True" />
                            <telerik:RadTab PageViewID="RadPageView2" Width="125px" Text="Stock" Visible="False" />
                            <telerik:RadTab PageViewID="RadPageView3" Width="125px" Text="Delivery" Visible="False" />
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="TabMultiPage" RenderSelectedPageOnly="True" Width="100%">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgSalesInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                            AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                                            AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                                            OnNeedDataSource="rgSalesInvoice_NeedDataSource" OnDetailTableDataBind="rgSalesInvoice_DetailTableDataBind" OnPreRender="rgSalesInvoice_PreRender" OnItemDataBound="rgSalesInvoice_ItemDataBound">
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
                                                    <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" Width="100%">
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
                                                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                            <telerik:GridBoundColumn DataField="IsLowMinPrice" Display="false" />
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
                                                    <telerik:GridBoundColumn DataField="InvoiceId" HeaderText="InvoiceId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="IsLowMinPrice" Display="false" />
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
                                        <telerik:RadGrid ID="gvInvoiceLinesStock" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False"
                                            OnItemDataBound="gvInvoiceLinesStock_ItemDataBound" OnNeedDataSource="gvInvoiceLinesStock_NeedDataSource">
                                            <MasterTableView ShowHeadersWhenNoRecords="true">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No records to display.</td>
                                                        </tr>
                                                    </table>
                                                </NoRecordsTemplate>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" ItemStyle-Width="45px" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" ItemStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" ItemStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" ItemStyle-Width="550px" />
                                                    <telerik:GridBoundColumn DataField="Location" HeaderText="Location" HeaderStyle-Width="125px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="QTY" DataFormatString="{0:F0}" ItemStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="StoreQuantity" HeaderText="Store QTY" DataFormatString="{0:F0}" ItemStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                    <telerik:GridTemplateColumn UniqueName="Status">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgStatus" runat="server" Height="16" Width="16" />
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
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgDelivery" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" OnNeedDataSource="rgDelivery_NeedDataSource">
                                            <MasterTableView ShowHeadersWhenNoRecords="true">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No records to display.</td>
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
                                                    <telerik:GridDateTimeColumn DataField="ReceiptDate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Receipt Date" HeaderStyle-Width="125px" />
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
            <telerik:AjaxSetting AjaxControlID="rts">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rts" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rts" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
