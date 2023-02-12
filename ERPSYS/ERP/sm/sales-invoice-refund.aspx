<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-refund.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoiceRefund" %>

<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Sales Invoice Information</legend>
                    <table class="tbl-edit" style="width: 900px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Invoice Number :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer Name :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Invoice Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" ValidationGroup="save"
                                    Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <asp:Panel ID="pnlWhole" Visible="False" runat="server">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Sales Invoice Details</h3>
                        <telerik:RadGrid ID="rgRefundWholeSalesInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                            AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                            OnNeedDataSource="rgRefundWholeSalesInvoice_NeedDataSource" OnDetailTableDataBind="rgRefundWholeSalesInvoice_DetailTableDataBind" OnPreRender="rgRefundWholeSalesInvoice_PreRender">
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
                                            <table class="rgEmptyData">
                                                <tr>
                                                    <td>No sub records to display.</td>
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
                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
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
                                    <telerik:GridBoundColumn DataField="InvoiceId" HeaderText="InvoiceId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlIndividual" Visible="False" runat="server">
            <asp:Panel ID="pnlIndividualDiscount" Visible="False" runat="server">
                <tr>
                    <td>
                        <div class="note"><span>notice: </span>Discount is applied for this invoice, Discount Value :
                            <asp:Label ID="lblIndividualDiscount" runat="server"></asp:Label></div>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlIndividualExpenses" Visible="False" runat="server">
                <tr>
                    <td>
                        <div class="note"><span>notice: </span>Expenses is applied for this invoice, Expenses Value :
                            <asp:Label ID="lblIndividualExpenses" runat="server"></asp:Label></div>
                    </td>
                </tr>
            </asp:Panel>

            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Sales Invoice Details</h3>
                        <telerik:RadGrid ID="rgRefundSalesInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgRefundSalesInvoice_NeedDataSource">
                            <MasterTableView DataKeyNames="ItemId" Name="MainItem">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="25px" UniqueName="CheckBoxTemplateColumn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbItem" runat="server" ValidationGroup="RefundQuantity" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="Price" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <table style="width: 100px">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <telerik:RadNumericTextBox ID="txtNetPrice" runat="server" Width="75px" MinValue="0" MaxValue='<%# Convert.ToDouble(Eval("NetPrice")) %>' DbValue='<%# Bind("NetPrice") %>' ShowSpinButtons="false">
                                                            <NumberFormat DecimalDigits="2"></NumberFormat>
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Hide Price" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <table style="width: 50px">
                                                <tr>
                                                    <td style="width: 50px">
                                                        <asp:CheckBox ID="cbHidePrice" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Invocie QTY" DataFormatString="{0:F0}" HeaderStyle-Width="65px" />
                                    <telerik:GridBoundColumn DataField="RefundQuantity" HeaderText="Refunded QTY" DataFormatString="{0:F0}" HeaderStyle-Width="65px" />
                                    <telerik:GridBoundColumn DataField="RemainingQuantity" HeaderText="QTY" DataFormatString="{0:F0}" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="QTY" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <table style="width: 100px">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <telerik:RadNumericTextBox ID="txtRefundQuantity" runat="server" Width="75px" MinValue="1" MaxValue='<%# Convert.ToDouble(Eval("RemainingQuantity")) %>' DbValue='<%# Bind("RemainingQuantity") %>' ShowSpinButtons="true">
                                                            <NumberFormat DecimalDigits="0"></NumberFormat>
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Total" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <table style="width: 100px">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </asp:Panel>
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
                            <tr>
                                <td class="ft-edit-sum">Expenses :</td>
                                <td class="fv-edit-sum read-only" colspan="2">
                                    <telerik:RadNumericTextBox ID="txtExpenses" runat="server" Width="100px" Value="0" MinValue="0" MaxValue="999999">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rvfTotalExpenses" runat="server" CssClass="val-error" ValidationGroup="applyChanges" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtExpenses" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvTotalExpenses" runat="server" ControlToValidate="txtExpenses" ValidationGroup="applyChanges" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" SetFocusOnError="True"></asp:CompareValidator>
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
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to Post the refund Invoice ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRefundSalesInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRefundSalesInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="pnlTotalSummary" LoadingPanelID="lpLoading" />
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

