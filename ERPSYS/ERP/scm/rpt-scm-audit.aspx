<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="rpt-scm-audit.aspx.cs" Inherits="ERPSYS.ERP.scm.RptScmAudit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 900px">
                        <tr>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Date Period :</td>
                            <td class="fv-search" colspan="3">
                                <uc1:UCDateRange ID="UCDateRange" runat="server" />
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Report Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlReports" runat="server" Width="350px">
                                    <asp:ListItem Text="Different Prices (Purchase Order / Purchase Invoice)" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Different Quantities (Material Received / Purchase Invoice)" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpReports" runat="server" RenderSelectedPageOnly="true" Width="100%">
                    <telerik:RadPageView ID="rpvType1" runat="server" Selected="true">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgReport1" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="true" Width="100%" AutoGenerateColumns="False"
                                        OnNeedDataSource="rgReport1_NeedDataSource" OnInit="rgReport1_Init">
                                        <MasterTableView ShowHeadersWhenNoRecords="true">
                                            <NoRecordsTemplate>
                                                <table class="rgEmptyData">
                                                    <tr>
                                                        <td>No Data Found</td>
                                                    </tr>
                                                </table>
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="PurchaseInvoiceId" HeaderText="InvoiceID" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridBoundColumn DataField="PurchaseOrderId" HeaderText="OrderID" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                    <ItemTemplate>
                                                        <%#  Container.DataSetIndex + 1%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="400px" />
                                                <telerik:GridTemplateColumn HeaderText="Invoice #" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <div>
                                                            <a class="grdlink" href='<%# string.Format("purchase-invoice-preview.aspx?id={0}", Eval("PurchaseInvoiceId")) %>'><%# Eval("InvoiceNumber") %></a>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridDateTimeColumn DataField="Invoice_Date" HeaderText="Invoice Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="Invoice_Price" HeaderText="Invoice Price" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                                <telerik:GridTemplateColumn HeaderText="Order #" HeaderStyle-Width="125px">
                                                    <ItemTemplate>
                                                        <div>
                                                            <a class="grdlink" href='<%# string.Format("purchase-order-preview.aspx?id={0}", Eval("PurchaseOrderId")) %>'><%# Eval("Order_Number") %></a>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridDateTimeColumn DataField="Order_Date" HeaderText="Order Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="Order_Price" HeaderText="Order Price" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvType2" runat="server">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgReport2" runat="server" RenderMode="Lightweight" ShowFooter="True" AllowSorting="True" Width="100%" AutoGenerateColumns="False"
                                        OnNeedDataSource="rgReport2_NeedDataSource" OnDetailTableDataBind="rgReport2_DetailTableDataBind">
                                        <MasterTableView DataKeyNames="GoodsReceiptId" HierarchyLoadMode="Client">
                                            <NoRecordsTemplate>
                                                <table class="rgEmptyData">
                                                    <tr>
                                                        <td>No Data Found</td>
                                                    </tr>
                                                </table>
                                            </NoRecordsTemplate>
                                            <DetailTables>
                                                <telerik:GridTableView Width="100%">
                                                    <NoRecordsTemplate>
                                                        <table class="rgEmptyData">
                                                            <tr>
                                                                <td>No Invoice to display.</td>
                                                            </tr>
                                                        </table>
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="GoodsReceiptId" HeaderText="ID" HeaderStyle-Width="45px" Visible="False" />
                                                        <telerik:GridBoundColumn DataField="PurchaseInvoiceId" HeaderText="InvoiceID" HeaderStyle-Width="45px" Visible="False" />
                                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                            <ItemTemplate>
                                                                <%#  Container.DataSetIndex + 1%>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Purchase Invoice #" HeaderStyle-Width="175px">
                                                            <ItemTemplate>
                                                                <div>
                                                                    <a class="grdlink" href='<%# string.Format("purchase-invoice-preview.aspx?id={0}", Eval("PurchaseInvoiceId")) %>'><%# Eval("InvoiceNumber") %></a>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="SupplierName" HeaderText="Supplier Name" HeaderStyle-Width="400px" />
                                                        <telerik:GridDateTimeColumn DataField="InvoiceDate" HeaderText="Invoice Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                                        <telerik:GridBoundColumn DataField="ProductsQuantity" HeaderText="Invoice Products Qty" DataFormatString="{0:N0}" Aggregate="Sum" HeaderStyle-Width="150px" />
                                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                    </Columns>
                                                </telerik:GridTableView>
                                            </DetailTables>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="GoodsReceiptId" HeaderText="ID" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                    <ItemTemplate>
                                                        <%#  Container.DataSetIndex + 1%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Material Receipt #" HeaderStyle-Width="175px">
                                                    <ItemTemplate>
                                                        <div>
                                                            <a class="grdlink" href='<%# string.Format("goods-receipt-preview.aspx?id={0}", Eval("GoodsReceiptId")) %>'><%# Eval("ReceiptNumber") %></a>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="SupplierName" HeaderText="Supplier Name" HeaderStyle-Width="400px" />
                                                <telerik:GridDateTimeColumn DataField="ReceiptDate" HeaderText="Receipt Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="ProductsQuantity" HeaderText="Receipt Products Qty" DataFormatString="{0:N0}" HeaderStyle-Width="150px" />
                                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <%--    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rmpReports" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgReport1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgReport1" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgReport2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgReport2" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
