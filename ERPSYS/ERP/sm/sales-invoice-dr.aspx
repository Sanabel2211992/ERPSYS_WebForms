<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-dr.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoiceDelievryReceipt" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Delivery Receipt Selection</legend>
                    <table class="tbl-view" style="width: 600px">
                        <tr>
                            <td class="ft-view" style="width: 125px">Delivery Receipt :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:DropDownList ID="ddlDeliveryReceiptList" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvDeliveryReceipt" ControlToValidate="ddlDeliveryReceiptList" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="getorder" SetFocusOnError="True" />

                            </td>
                            <td class="ft-view" style="width: 125px">
                                <asp:Button ID="btnDeliveryReceipt" runat="server" OnClick="btnDeliveryReceipt_Click" Text="Get Delivery Receipt" Width="175px" ValidationGroup="getorder" />
                            </td>
                            <td class="fv-view" style="width: 175px"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <asp:Panel ID="pnlSalesInvoice" Visible="False" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-view">
                        <legend class="fs-view-legend">Sales Invoice Information</legend>
                        <table class="tbl-view" style="width: 600px">
                            <tr>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-view" style="width: 125px">Customer :</td>
                                <td class="fv-view" colspan="3">
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Customer L.P.O :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCustomerPO" runat="server"></asp:Label></td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-view">Receipt #:</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblReceiptNumber" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Receipt Status :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblReceiptStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Sales Order # :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblSalesOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Job Order # :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblJobOrderNumber" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="ft-view">Invoice Date :</td>
                                <td class="fv-view">
                                    <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                                </td>
                                <td class="ft-view">Currency View :</td>
                                <td class="fv-view">
                                    <asp:DropDownList ID="ddlCurrencyView" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Payment Method :</td>
                                <td class="fv-view">
                                    <asp:DropDownList ID="ddlPaymentMethod" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaymentMethod" ControlToValidate="ddlPaymentMethod" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                </td>
                                <td class="ft-view">Payment Terms :</td>
                                <td class="fv-view">
                                    <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaymentTerms" ControlToValidate="ddlPaymentTerms"
                                        Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Remarks :</td>
                                <td class="fv-view" colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <asp:Panel ID="pnlIndividualDiscount" Visible="False" runat="server">
                <tr>
                    <td>
                        <div class="note">
                            <span>notice: </span>Discount is applied in Sales Order, Discount Value :
                            <asp:Label ID="lblIndividualDiscount" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Sales Invoice Details</h3>
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
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderStyle-Width="10px"></telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                <ItemTemplate>
                                                    <%#  Container.DataSetIndex + 1%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" ItemStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="450px" />
                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
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
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="450px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="fs-inner" style="width: 325px">
                        <legend class="fs-inner-legend">Total Summary</legend>
                        <asp:Panel ID="pnlTotalSummary" runat="server">
                            <table class="tbl-inner" style="width: 325px">
                                <tr>
                                    <td class="ft-edit-sum" style="width: 125px"></td>
                                    <td class="fv-edit-sum" style="width: 125px"></td>
                                    <td style="width: 75px"></td>
                                </tr>
                                <tr>
                                    <td class="ft-edit-sum">Sub Total</td>
                                    <td class="fv-edit-sum read-only" colspan="2">
                                        <telerik:RadNumericTextBox ID="txtSubTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                            <NumberFormat DecimalDigits="2"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ft-edit-sum">Discount <span style="font-size: 8pt">(Amount)</span></td>
                                    <td class="fv-edit-sum read-only" colspan="2">
                                        <telerik:RadNumericTextBox ID="txtDiscount" runat="server" Width="100px" Value="0" MinValue="0" MaxValue="999999">
                                            <NumberFormat DecimalDigits="2"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator ID="rvfTotalDiscoun" runat="server" CssClass="val-error" ValidationGroup="applyChanges" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDiscount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cvTotalDiscount" runat="server" ControlToValidate="txtDiscount" ValidationGroup="applyChanges" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" SetFocusOnError="True"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlSalesTax" Visible="False" runat="server">
                                    <tr>
                                        <td class="ft-edit-sum">Sales Tax<span style="font-size: 8pt"> (
                                    <asp:Label ID="lblSalesTaxValue" runat="server"></asp:Label>
                                            )</span></td>
                                        <td class="fv-edit-sum read-only">
                                            <telerik:RadNumericTextBox ID="txtSalesTax" runat="server" ReadOnly="True" Width="100px" Value="0" MinValue="0">
                                                <NumberFormat DecimalDigits="2"></NumberFormat>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td class="fv-edit-sum"></td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="ft-edit-sum">Grand Total</td>
                                    <td class="fv-edit-sum read-only">
                                        <telerik:RadNumericTextBox ID="txtGrandTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                            <NumberFormat DecimalDigits="2"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnApplyChanges" runat="server" Width="70px" ValidationGroup="applyChanges" Text="Apply" OnClick="btnApplyChanges_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 100px">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Post" CssClass="btn-save" ValidationGroup="save"
                                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Sales Invoice ?'); } else return;};"
                                    OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgSalesInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSalesInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApplyChanges">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlTotalSummary" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

