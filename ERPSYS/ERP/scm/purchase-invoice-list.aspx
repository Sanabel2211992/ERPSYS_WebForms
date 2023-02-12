<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-invoice-list.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseInvoiceList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            ClearDate();
            $('#<%= txtSupplierName.ClientID %>').val("");
            $('#<%= txtInvoiceNumber.ClientID %>').val("");
            $('#<%= txtSupplierInvoiceNumber.ClientID %>').val("");
            $('#<%= txtRemarks.ClientID %>').val("");
            $('#<%= ddlInvoiceStatus.ClientID %>').val("-1");
            $('#<%= txtReceiptNumber.ClientID %>').val("");
            $('#<%= txtItemSearch.ClientID %>').val("");
        }
    </script>
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
                            <td class="ft-search">Supplier Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtSupplierName" runat="server" Width="350px"></asp:TextBox></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Purchase INV # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Material Receipt # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtReceiptNumber" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Supplier INV # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtSupplierInvoiceNumber" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Remarks :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Status :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlInvoiceStatus" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Product Search :</td>
                            <td class="fv-search" colspan="5">
                                <asp:TextBox ID="txtItemSearch" runat="server" Width="350px"></asp:TextBox>
                                &nbsp;(Part Number, Catalog No or Description).</td>
                        </tr>
                        <tr>
                            <td colspan="6">
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
                <telerik:RadToolBarButton runat="server" CommandName="add" Text="New Purchase Invoice" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="160px" />
                <telerik:RadToolBarButton runat="server" CommandName="export" Value="export" OuterCssClass="pull-right" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgPurchaseInvoiceList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="true" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgPurchaseInvoiceList_NeedDataSource" OnInit="rgPurchaseInvoiceList_Init" OnItemDataBound="rgPurchaseInvoiceList_ItemDataBound">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table class="rgEmptyData">
                        <tr>
                            <td>No Data Found</td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="PurchaseInvoiceId" HeaderText="ID" HeaderStyle-Width="45px" Visible="False" />
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("purchase-invoice-preview.aspx?id={0}", Eval("PurchaseInvoiceId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Purchase Invoice" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Invoice #" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <div>
                                <a class="grdlink" href='<%# string.Format("purchase-invoice-preview.aspx?id={0}", Eval("PurchaseInvoiceId")) %>'><%# Eval("InvoiceNumber") %></a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Receipt #" HeaderStyle-Width="125px">
                        <ItemTemplate>
                            <div>
                                <a class="grdlink" href='<%# string.Format("goods-receipt-preview.aspx?id={0}", Eval("GoodsReceiptId")) %>'><%# Eval("ReceiptNumber") %></a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="SupplierName" HeaderText="Supplier Name" HeaderStyle-Width="350px" />
                    <telerik:GridBoundColumn DataField="SupplierInvoiceNumber" HeaderText="S Invoice #" HeaderStyle-Width="150px" />
                    <%--<telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="175px" />--%>
                    <telerik:GridBoundColumn DataField="Location" HeaderText="Store" HeaderStyle-Width="100px" />
                    <telerik:GridDateTimeColumn DataField="InvoiceDate" HeaderText="Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="75px" />
                    <telerik:GridBoundColumn DataField="GrandTotal" HeaderText=" Total" HeaderStyle-Width="100px" DataFormatString="{0:N}" />
                    <telerik:GridBoundColumn DataField="CurrencyCode" HeaderText="CUR" HeaderStyle-Width="75px" />
                    <telerik:GridBoundColumn DataField="UserName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                    <telerik:GridBoundColumn DataField="InvoiceStatus" Display="False" />
                    <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <div>
                                <asp:Image ID="imgStatus" runat="server" Height="13px" Width="13px" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
                    <telerik:AjaxUpdatedControl ControlID="rgPurchaseInvoiceList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgPurchaseInvoiceList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPurchaseInvoiceList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
