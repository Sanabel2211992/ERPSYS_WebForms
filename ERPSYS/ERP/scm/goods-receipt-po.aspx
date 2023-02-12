<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-receipt-po.aspx.cs" Inherits="ERPSYS.ERP.scm.GoodsReceiptPO" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Purchase Order</legend>
                    <table class="tbl-view" style="width: 600px">
                        <tr>
                            <td class="ft-view" style="width: 125px">Purchase Order # :</td>
                            <td class="fv-view" style="width: 175px">
                                <asp:DropDownList ID="ddlPurchaseOrderList" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPurchaseOrder" ControlToValidate="ddlPurchaseOrderList" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="getorder" SetFocusOnError="True" />
                            </td>
                            <td class="ft-view" style="width: 125px">
                                <asp:Button ID="btnGetPurchaseOrder" runat="server" OnClick="btnGetPurchaseOrder_Click" Text="Get Order" Width="100px" ValidationGroup="getorder" />
                            </td>
                            <td class="fv-view" style="width: 175px"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <asp:Panel ID="pnlGoodsReceipt" Visible="False" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-view">
                        <legend class="fs-view-legend">Material Receipt Information</legend>
                        <table class="tbl-view" style="width: 600px">
                            <tr>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-view" style="width: 125px">Supplier Name :</td>
                                <td class="fv-view" colspan="3">
                                    <asp:Label ID="lblSupplierName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Purchase Order :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblPurchaseOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Location :</td>
                                <td class="fv-view">
                                    <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Received Date :</td>
                                <td class="fv-view">
                                    <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                                </td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
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
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Material Receipt Details</h3>
                        <telerik:RadGrid ID="rgGoodReceipt" runat="server" ShowStatusBar="True" AutoGenerateColumns="False" AllowMultiRowSelection="true" ShowFooter="True" OnItemDataBound="rgGoodReceipt_ItemDataBound">
                            <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbItem" runat="server" ValidationGroup="receivedqty" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbAllItems" runat="server" ValidationGroup="receivedqty" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" />
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
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Order QTY" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="ReceivedQuantity" HeaderText="Rcpt QTY" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                    <telerik:GridTemplateColumn HeaderText="QTY" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtQuantity" Text='<%# Bind("RemainingQuantity") %>' runat="server" Width="50px" MinValue="1" MaxValue="99999">
                                                <NumberFormat DecimalDigits="2"></NumberFormat>
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="StatusId" HeaderText="StatusId" HeaderStyle-Width="25px" Visible="False" />
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
                                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Material receipt ?'); } else return;};"
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
            <telerik:AjaxSetting AjaxControlID="rgGoodReceipt">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodReceipt" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
