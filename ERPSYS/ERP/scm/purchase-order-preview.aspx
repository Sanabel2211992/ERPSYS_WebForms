<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-order-preview.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseOrderPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete the purchase order ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post the purchase order ?"));
            }
            else if (button.get_commandName() === "cancel") {
                args.set_cancel(!confirm("Are you sure you want to cancel the purchase order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Purchase Order Information</legend>
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
                            <td class="ft-view">Purchase Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPurchaseOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPurchaseOrderStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPurchaseOrderDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Currency : </td>
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
                            <asp:Panel ID="pnlCancel" runat="server" Visible="false">
                                <td class="ft-view">Canceled By :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCanceledBy" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Canceled Date :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCanceledDate" runat="server"></asp:Label>
                                </td>
                            </asp:Panel>
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
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="Cancel Purchase Order" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel_red.png" Width="170px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Total Summary</legend>
                    <table class="tbl-inner-view" style="width: 900px">
                        <tr>
                            <td class="ft-view" style="width: 100px">Sub Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
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
                    <h3>Purchase Order Details</h3>
                </div>
                <telerik:RadTabStrip RenderMode="Lightweight" ID="rtsOrder" runat="server" MultiPageID="rmpOrder" Width="250px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab PageViewID="RadPageView1" Width="125px" Text="Purchase Order" Selected="True" />
                        <telerik:RadTab PageViewID="RadPageView2" Width="125px" Text="Material Receipt" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="rmpOrder" runat="server" CssClass="TabMultiPage" RenderSelectedPageOnly="True" Width="100%">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgPurchaseOrder" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False" OnNeedDataSource="rgPurchaseOrder_NeedDataSource">
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
                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                                <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="100px" Display="False" />
                                                <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F3}" HeaderStyle-Width="100px" Display="False" />
                                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="PurchaseUom" HeaderText="Unit" HeaderStyle-Width="45px" />
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
                                    <telerik:RadGrid ID="rgMaterialReceipt" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False" AutoGenerateColumns="False" OnNeedDataSource="rgMaterialReceipt_NeedDataSource">
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
                                                <telerik:GridTemplateColumn HeaderText="Material Receipt #" HeaderStyle-Width="125px">
                                                    <ItemTemplate>
                                                        <div>
                                                            <a href='<%# string.Format("goods-receipt-preview.aspx?id={0}", Eval("ReceiptId")) %>'><%# Eval("ReceiptNumber") %></a>
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
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsOrder" />
                    <telerik:AjaxUpdatedControl ControlID="rmpOrder" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
