<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-invoice-form.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseInvoiceForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/ComboBox/UCSupplierList.ascx" TagName="UCSupplierList" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
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
                            <td class="ft-edit">Invoice # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblPurchaseInvoiceNumber" runat="server"></asp:Label></td>
                            <td class="ft-edit">Invoice Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Supplier Name :</td>
                            <td class="fv-edit" colspan="3">
                                <uc1:UCSupplierList ID="UCSupplier" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Invoice Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCOrderDate" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Currency :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlCurrency" runat="server" Width="157px" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvCurrency" ControlToValidate="ddlCurrency" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="154px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Purchase Order # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPurchaseOrderNumber" runat="server" Width="148px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Supplier Invoice # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtSupplierInvoice" runat="server" Width="147px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-sc-pi1" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to update the information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
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
                    <div>
                        <asp:Button ID="btnUpdatePricing" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-sc-pi2" ValidationGroup="savepricing"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('savepricing'); if(Page_IsValid) { return confirm('Are you sure you want to update the pricing information ?'); } else return;};"
                            OnClick="btnUpdatePricing_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Purchase Invoice Details</h3>
                    <telerik:RadGrid ID="rgPurchaseInvoice" runat="server" ShowStatusBar="true" ShowFooter="false" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True"
                        OnInsertCommand="rgPurchaseInvoice_InsertCommand" OnUpdateCommand="rgPurchaseInvoice_UpdateCommand" OnItemCommand="rgPurchaseInvoice_ItemCommand"
                        OnNeedDataSource="rgPurchaseInvoice_NeedDataSource" OnDeleteCommand="rgPurchaseInvoice_DeleteCommand">
                        <MasterTableView DataKeyNames="LineId,ItemId" CommandItemDisplay="Top">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <CommandItemSettings AddNewRecordText="Add Product" />
                            <EditFormSettings EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommand" />
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="75px" Display="False" />
                                <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F3}" HeaderStyle-Width="75px" Display="False" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F3}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F3}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="PurchaseUomId" HeaderText="Unit" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="PurchaseUom" HeaderText="Unit" HeaderStyle-Width="45px" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridButtonColumn>
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
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
                    <table class="tbl-inner" style="width: 325px">
                        <tr>
                            <th class="ft-edit-sum" style="width: 125px"></th>
                            <th class="fv-edit-sum" style="width: 125px"></th>
                            <th style="width: 75px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit-sum">Sub Total</td>
                            <td class="fv-edit-sum read-only" colspan="2">
                                <asp:TextBox ID="txtSubTotal" runat="server" Width="100px" ReadOnly="True">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit-sum">Discount <span style="font-size: 8pt">(Amount)</span></td>
                            <td class="fv-edit-sum read-only" colspan="2">
                                <telerik:RadNumericTextBox ID="txtDiscount" runat="server" Width="100px" Value="0" MinValue="0" MaxValue="999999">
                                    <NumberFormat DecimalDigits="3"></NumberFormat>
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="rvfTotalDiscoun" runat="server" CssClass="val-error" ValidationGroup="applyChanges" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDiscount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvTotalDiscount" runat="server" ControlToValidate="txtDiscount" ValidationGroup="applyChanges" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" SetFocusOnError="True"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit-sum">Grand Total</td>
                            <td class="fv-edit-sum read-only">
                                <asp:TextBox ID="txtGrandTotal" runat="server" Width="100px" ReadOnly="True">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnApplyChanges" runat="server" ValidationGroup="applyChanges" Visible="False" Enabled="False" Text="Apply Changes" OnClick="btnApplyChanges_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 150px">
                    <tr>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn-save" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgPurchaseInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPurchaseInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="txtSubTotal" />
                    <telerik:AjaxUpdatedControl ControlID="txtGrandTotal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbIgnoreTax">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSalesTax" />
                    <telerik:AjaxUpdatedControl ControlID="txtGrandTotal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApplyChanges">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSubTotal" />
                    <telerik:AjaxUpdatedControl ControlID="txtGrandTotal" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
