<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-mdr2.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoiceMdr2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc1" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <asp:Panel ID="pnlDeliveryReceiptsCustomer" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Delivery Receipts Information</legend>
                        <table class="tbl-inner" style="width: 600px">
                            <tr>
                                <td class="uc-field-title" style="width: 125px"></td>
                                <td class="uc-field-val" style="width: 475px"></td>
                            </tr>
                            <tr>
                                <td class="uc-field-title">Customer Name :</td>
                                <td class="uc-field-val">
                                    <telerik:RadComboBox ID="rcbCustomer" runat="server" Height="200px" Width="450px" RenderMode="Lightweight" EnableVirtualScrolling="true" EmptyMessage="Choose a Customer"
                                        DataTextField="Name" DataValueField="CustomerId" AutoPostBack="True" OnSelectedIndexChanged="rcbCustomer_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvCustomer" ControlToValidate="rcbCustomer" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="val-error"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlSalesOrder" Visible="False" runat="server">
                                <tr>
                                    <td class="uc-field-title">Sales Order :</td>
                                    <td class="uc-field-val">
                                        <asp:DropDownList ID="ddlSalesOrder" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlSalesOrder_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlDeliveryReceipt" Visible="False" runat="server">
                                <tr>
                                    <td class="uc-field-title">Delivery Receipts :</td>
                                    <td class="uc-field-val">
                                        <asp:CheckBoxList ID="cblDeliveryReceipts" runat="server" RepeatColumns="4">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="uc-field-title"></td>
                                    <td class="uc-field-val">
                                        <asp:Button ID="btnDeliveryReceipts" runat="server" OnClick="btnDeliveryReceipts_Click" Text="Get Delivery Receipts" Width="175px" ValidationGroup="getorder" />
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>

                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlDeliveryReceipts" Visible="False" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Sales Invoice Information</legend>
                        <table class="tbl-inner-view" style="width: 600px">
                            <tr>
                                <td class="field-title" style="width: 125px"></td>
                                <td class="field-val" style="width: 175px"></td>
                                <td class="field-title" style="width: 125px"></td>
                                <td class="field-val" style="width: 175px"></td>
                            </tr>
                            <tr>
                                <td class="field-title" style="width: 125px">Customer :</td>
                                <td class="field-val" colspan="3">
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="field-title">Sales Order # :</td>
                                <td class="field-val">
                                    <asp:Label ID="lblSalesOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="field-title">&nbsp;</td>
                                <td class="field-val">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="field-title">Job Order # :</td>
                                <td class="field-val">
                                    <asp:Label ID="lblJobOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="field-title">&nbsp;</td>
                                <td class="field-val">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="field-title">Date :</td>
                                <td class="field-val">
                                    <uc1:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                                </td>
                                <td class="field-title">&nbsp;</td>
                                <td class="field-val">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="field-title">Payment Method :</td>
                                <td class="field-val">
                                    <asp:DropDownList ID="ddlPaymentMethod" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaymentMethod" ControlToValidate="ddlPaymentMethod" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                </td>
                                <td class="field-title">Payment Terms :</td>
                                <td class="field-val">
                                    <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPaymentTerms" ControlToValidate="ddlPaymentTerms"
                                        Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="field-title">Remarks :</td>
                                <td class="field-val" colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="100px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="field-title"></td>
                                <td class="field-val"></td>
                                <td class="field-title"></td>
                                <td class="field-val"></td>
                            </tr>
                        </table>
                        <div style="position: relative">
                            <div style="position: absolute; top: -250px; left: 620px">
                                <telerik:RadListBox ID="rlbDeliveryReceipts" runat="server" Height="235px" Width="150px"></telerik:RadListBox>
                            </div>
                        </div>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="grid-title">Sales Invoice Details</td>
            </tr>
            <tr>
                <td>

                    <asp:Button ID="btnMerge" runat="server" Text="Merge Groups" OnClick="btnMerge_Click" />
                </td>
            </tr>
            <tr>
                <td>
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
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderStyle-Width="10px"></telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="450px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                                </Columns>
                                            </telerik:GridTableView>
                                        </DetailTables>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                                <ItemTemplate>
                                                    <%#  Container.DataSetIndex + 1%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-Width="45px" UniqueName="CheckBoxTemplateColumn">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="cbItem" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="ReceiptId" HeaderText="ReceiptId" HeaderStyle-Width="45px" Display="False" />
                                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="fs-inner" style="width: 325px">
                        <legend class="fs-inner-legend">Total Summary</legend>
                        <table class="tbl-inner" style="width: 325px">
                            <tr>
                                <td class="sum-field-title" style="width: 125px"></td>
                                <td class="sum-field-val" style="width: 125px"></td>
                                <td class="sum-field-val" style="width: 75px"></td>
                            </tr>
                            <tr>
                                <td class="sum-field-title">Sub Total</td>
                                <td class="sum-field-val read-only" colspan="2">
                                    <telerik:RadNumericTextBox ID="txtSubTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="sum-field-title">Discount <span style="font-size: 8pt">(Amount)</span></td>
                                <td class="sum-field-val read-only" colspan="2">
                                    <telerik:RadNumericTextBox ID="txtDiscount" runat="server" Width="100px" Value="0" MinValue="0" MaxValue="999999">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rvfTotalDiscoun" runat="server" CssClass="val-error" ValidationGroup="applyChanges" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDiscount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvTotalDiscount" runat="server" ControlToValidate="txtDiscount" ValidationGroup="applyChanges" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" SetFocusOnError="True"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="sum-field-title">Grand Total</td>
                                <td class="sum-field-val read-only">
                                    <telerik:RadNumericTextBox ID="txtGrandTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnApplyChanges" runat="server" Width="70px" ValidationGroup="applyChanges" Text="Apply" OnClick="btnApplyChanges_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 200px">
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgSalesInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSalesInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApplyChanges">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtGrandTotal" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
