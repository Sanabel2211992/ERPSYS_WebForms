<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-invoice-grn.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseInvoiceGRN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Material Receipt Note</legend>
                    <table class="tbl-view" style="width: 600px">
                        <tr>
                            <td class="ft-view" style="width: 125px">Material Receipt # :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:DropDownList ID="ddlGoodsReceiptList" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvGoodsReceipt" ControlToValidate="ddlGoodsReceiptList" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="getgrn" SetFocusOnError="True" />
                            </td>
                            <td class="ft-view" style="width: 125px">
                                <asp:Button ID="btnMaterialReceipt" runat="server" OnClick="btnMaterialReceipt_Click" Text="Get Data" Width="100px" ValidationGroup="getgrn" />
                            </td>
                            <td class="fv-view" style="width: 175px"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <asp:Panel ID="pnlPurchaseInvoice" Visible="False" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Purchase Invoice Information</legend>
                        <table class="tbl-edit" style="width: 600px">
                            <tr>
                                <th class="ft-edit" style="width: 125px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                                <th class="ft-edit" style="width: 125px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-edit" style="width: 125px">Supplier Name :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Purchase Order #:</td>
                                <td class="fv-edit">
                                    <asp:Label ID="lblPurchaseOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="ft-edit">Material Receipt :</td>
                                <td class="fv-edit">
                                    <asp:Label ID="lblGoodsReceiptNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Currency :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvCurrency" ControlToValidate="ddlCurrency" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                </td>
                                <td class="ft-edit">Location :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Invoice Date :</td>
                                <td class="fv-edit">
                                    <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                                </td>
                                <td class="ft-edit">Supplier Invoice :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtSupplierInvoice" runat="server" Width="145px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Remarks :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Pricing and delivery Information</legend>
                      <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Freight Expenses :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtFreightExpenses" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                                    <NumberFormat DecimalDigits="3"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <span class="curr-code">
                                    <asp:Label ID="lblFreightExpensesCurrency" runat="server"></asp:Label></span>
                                <asp:CompareValidator ID="cvFreightExpenses" runat="server" ControlToValidate="txtFreightExpenses" CssClass="val-error" ValidationGroup="savepricing" ErrorMessage="*" Display="Dynamic" Operator="GreaterThanEqual"
                                    Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td class="ft-edit">Other Expenses :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtOtherExpenses" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                                    <NumberFormat DecimalDigits="3"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <span class="curr-code">
                                    <asp:CompareValidator ID="cvOtherExpenses" runat="server" ControlToValidate="txtOtherExpenses" CssClass="val-error" ValidationGroup="savepricing" ErrorMessage="*" Display="Dynamic" Operator="GreaterThanEqual"
                                        Type="Double" ValueToCompare="0"></asp:CompareValidator>
                                    <asp:Label ID="lblOtherExpenses" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Clearance Expenses :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtClearanceExpenses" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                                    <NumberFormat DecimalDigits="3"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <span class="curr-code">
                                    <asp:Label ID="lblClearanceExpensesCurrency" runat="server"></asp:Label></span>
                                <asp:CompareValidator ID="cvClearanceExpenses" runat="server" ControlToValidate="txtClearanceExpenses" CssClass="val-error" ValidationGroup="savepricing" ErrorMessage="*" Display="Dynamic" Operator="GreaterThanEqual"
                                    Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td class="ft-edit">Other Expenses :</td>
                            <td class="fv-edit">
                                <telerik:RadNumericTextBox ID="txtOtherExpensesLocalCurrency" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                                    <NumberFormat DecimalDigits="3"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <span class="curr-code">
                                    <asp:Label ID="lblOtherExpensesLocalCurrency" runat="server"></asp:Label></span>
                                <asp:CompareValidator ID="cvOtherExpensesLocalCurrency" runat="server" ControlToValidate="txtOtherExpensesLocalCurrency" CssClass="val-error" ValidationGroup="savepricing" ErrorMessage="*" Display="Dynamic" Operator="GreaterThanEqual"
                                    Type="Double" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Purchase Invoice Details</h3>
                        <telerik:RadGrid ID="rgPurchaseInvoice" runat="server" ShowStatusBar="True" AutoGenerateColumns="False" AllowMultiRowSelection="true" ShowFooter="True" OnItemDataBound="rgPurchaseInvoice_ItemDataBound">
                            <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbItem" runat="server" ValidationGroup="billqty" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbAllItems" runat="server" ValidationGroup="billqty" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="25px"></HeaderStyle>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                    <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                    <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="M.R Qty" DataFormatString="{0:F2}" HeaderStyle-Width="75px" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtQuantity" Text='<%# Bind("RemainingQuantity") %>' ValidationGroup="billqty" runat="server" Width="65px" MinValue="1" MaxValue="99999">
                                                <NumberFormat DecimalDigits="2"></NumberFormat>
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                    <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="Price" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtNetPrice" Text='<%# Bind("NetPrice") %>' ValidationGroup="billqty" runat="server" Width="65px" MinValue="0" MaxValue="99999">
                                                <NumberFormat DecimalDigits="3"></NumberFormat>
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="UomId" HeaderText="Unit" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="StatusId" HeaderText="StatusId" HeaderStyle-Width="25px" Display="False" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true">
                                <Selecting AllowRowSelect="True"></Selecting>
                            </ClientSettings>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 250px">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the purchase invoice ?'); } else return;};"
                                    OnClick="btnSave_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
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
            <telerik:AjaxSetting AjaxControlID="rgPurchaseInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPurchaseInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
