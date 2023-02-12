<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-invoice-preview.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseInvoicePreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete the purchase invoice ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post the purchase invoice ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Purchase Invoice Information</legend>
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
                            <td class="ft-view" style="width: 125px">Invoice # :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 125px">Invoice Status :</td>
                            <td class="fv-view" style="width: 175px">
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
                            <td class="ft-view">Purchase Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkPurchaseOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Material Receipt # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkGoodsReceiptNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Supplier Invoice # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblSupplierInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Currency :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Supplier Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkSupplierName" ToolTip="preview Supplier Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Posted By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks : </td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Pricing and delivery Information</legend>
                    <table class="tbl-view" style="width: 1160px">
                        <tr>
                            <th class="ft-view" style="width: 170px"></th>
                            <th class="fv-view" style="width: 120px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view" style="width: 125px">Currency Exchange :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:Label ID="lblCurrencyExchange" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 125px">Exchange Rate :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:Label ID="lblExchangeRate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 125px">Grand Total :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblGrandTotalCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                            <td class="ft-view" style="width: 125px">&nbsp;</td>
                            <td class="fv-view" style="width: 175px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Freight :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblFreightExpenses" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblFreightExpensesCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                            <td class="ft-view">Clearance :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblClearanceExpenses" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblClearanceExpensesCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                            <td class="ft-view">Other Expenses :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOtherExpensesCurrency" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblOtherExpensesCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                            <td class="ft-view">Other Expenses :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOtherExpensesLocalCurrency" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblOtherExpensesLocalCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="ft-view">Sub Total :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblSubTotalCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                            <td class="ft-view">Discount :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblDiscountCurrencyCode" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Grand Total :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                <span class="curr-code">
                                    <asp:Label ID="lblGrandTotalCurrencyCode" runat="server"></asp:Label></span></td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>--%>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Purchase Invoice Details</h3>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgPurchaseInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                                AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False" OnNeedDataSource="rgPurchaseInvoice_NeedDataSource">
                                <MasterTableView DataKeyNames="LineId,ItemId">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                        <telerik:GridBoundColumn DataField="PurchaseUom" HeaderText="Unit" HeaderStyle-Width="45px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="100px" Display="False" />
                                        <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F3}" HeaderStyle-Width="100px" Display="False" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="UnitCost" HeaderText="Cost" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="TotalCost" HeaderText="Total" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
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
</asp:Content>
