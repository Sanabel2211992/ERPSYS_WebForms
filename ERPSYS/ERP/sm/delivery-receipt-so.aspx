<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="delivery-receipt-so.aspx.cs" Inherits="ERPSYS.ERP.sm.DeliveryReceiptSO" %>

<%@ Import Namespace="ERPSYS.Helpers.Ext" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Sales Order Selection</legend> 
                    <table class="tbl-view" style="width: 600px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:DropDownList ID="ddlSalesOrderList" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPurchaseOrder" ControlToValidate="ddlSalesOrderList" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="getorder" SetFocusOnError="True" />

                            </td>
                            <td class="ft-view" colspan="2">
                                <asp:Button ID="btnGetSalesOrder" runat="server" OnClick="btnGetSalesOrder_Click" Text="Get Order" Width="100px" ValidationGroup="getorder" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <asp:Panel ID="pnlDeliveryReceipt" Visible="False" runat="server">
            <tr>
                <td>
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Delivery Receipt Information</legend>
                        <table class="tbl-edit" style="width: 600px">
                            <tr>
                                <th class="ft-edit" style="width: 125px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                                <th class="ft-edit" style="width: 125px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-edit" style="width: 125px">Customer Name :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Sales Order # :</td>
                                <td class="fv-edit">
                                    <asp:Label ID="lblSalesOrderNumber" runat="server"></asp:Label>
                                </td>
                                <td class="ft-edit">Status :</td>
                                <td class="fv-edit">
                                    <asp:Label ID="lblSalesOrderStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Delivery Date :</td>
                                <td class="fv-edit">
                                    <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                                </td>
                                <td class="ft-edit">Location :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Remarks :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="50" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Delivery Receipt Details</h3>
                        <telerik:RadGrid ID="rgSalesOrder" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                            AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                            OnDetailTableDataBind="rgSalesOrder_DetailTableDataBind" OnNeedDataSource="rgSalesOrder_NeedDataSource" OnItemDataBound="rgSalesOrder_ItemDataBound" OnPreRender="rgSalesOrder_PreRender">
                            <ClientSettings>
                                <ClientEvents OnGridCreated="main.GridCreated" OnHierarchyExpanded="main.HierarchyExpanded" OnHierarchyCollapsed="main.HierarchyCollapsed"></ClientEvents>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem" HierarchyLoadMode="Conditional">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No Data Found
                                            </td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" Width="100%" HierarchyLoadMode="Client">
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
                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" Display="False" />
                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                            <telerik:GridBoundColumn DataField="StockQuantity" HeaderText="Stock QTY*" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="45px" UniqueName="CheckBoxTemplateColumn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbItem" runat="server" ValidationGroup="OrderQuantity" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbAllItems" runat="server" ValidationGroup="OrderQuantity" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" />
                                        </HeaderTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="OrderId" HeaderText="OrderId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Order Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="DeliveredQuantity" HeaderText="Delivered Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="RemainingQuantity" HeaderText="Remaining Quantity" DataFormatString="{0:F0}" Visible="False" />
                                    <telerik:GridTemplateColumn HeaderText="Delivery Quantity" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <table style="width: 75px">
                                                <tr>
                                                    <td style="width: 75px">
                                                        <telerik:RadNumericTextBox ID="txtDeliveredQuantity" runat="server" Width="65px" MinValue="1" MaxValue='<%# Convert.ToDouble(Eval("RemainingQuantity")) %>' DbValue='<%# Bind("RemainingQuantity") %>' ShowSpinButtons="true">
                                                            <NumberFormat DecimalDigits="0"></NumberFormat>
                                                        </telerik:RadNumericTextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Stock Quantity *">
                                        <ItemTemplate>
                                            <div>
                                                <%# Convert.ToInt32(Eval("ItemId")) == -1 ? "-" : Eval("StockQuantity").ToDecimalFormat(0) %>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                    <div class="grid-note">
                        *Available Quantity in all stores
                    </div>
                </td>
            </tr>
            <tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 200px">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Delivery Receipt ?'); } else return;};"
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgSalesOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSalesOrder" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

