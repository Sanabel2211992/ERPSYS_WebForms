<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="delivery-receipt-adjust.aspx.cs" Inherits="ERPSYS.ERP.sm.DeliveryReceiptAdjustment" %>

<%@ Import Namespace="ERPSYS.Helpers.Ext" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
               <fieldset class="fs-view">
                    <legend class="fs-view-legend">Delivery Receipt Information</legend>
                    <table class="tbl-view" style="width: 1080px">
                        <tr>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Receipt # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Receipt Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Delivery Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Location :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkSalesOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Sales Invoice # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkSalesInvoiceNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Customer L.P.O :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCustomerPO" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
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
                    <telerik:RadGrid ID="gvDeliveryReceipt" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnDetailTableDataBind="gvDeliveryReceipt_DetailTableDataBind" OnItemCommand="gvDeliveryReceipt_ItemCommand"
                        OnUpdateCommand="gvDeliveryReceipt_UpdateCommand" OnDeleteCommand="gvDeliveryReceipt_DeleteCommand"
                        OnNeedDataSource="gvDeliveryReceipt_NeedDataSource" OnPreRender="gvDeliveryReceipt_PreRender" OnItemDataBound="gvDeliveryReceipt_ItemDataBound">
                        <MasterTableView DataKeyNames="LineId,LineSeqId,ItemId" Name="MainItem">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <CommandItemSettings AddNewRecordText="Add Item" />
                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems"
                                    ShowFooter="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False" Width="100%">
                                    <NoRecordsTemplate>
                                        <table class="rginnerEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <EditFormSettings UserControlName="~/Controls/HierarchyItems/DeliveryReceipt/UCSubItemAdjust.ascx" EditFormType="WebUserControl">
                                        <EditColumn UniqueName="SubEditCommandColumn">
                                        </EditColumn>
                                    </EditFormSettings>
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
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="IsSpecialRecord" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="LocationId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="175px">
                                            <ItemTemplate>
                                                <div>
                                                    <%# Eval("IsSpecialRecord").ToBool() ? String.Format(("{0}{1} Store"), "** ", Eval("Location")): ""  %>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <EditFormSettings UserControlName="~/Controls/HierarchyItems/DeliveryReceipt/UCMainItemAdjust.ascx" EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommandColumn1">
                                </EditColumn>
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="OrderId" HeaderText="OrderId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineSeqId" HeaderText="LineSeqId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="IsSpecialRecord" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="LocationId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="175px">
                                    <ItemTemplate>
                                        <div>
                                            <%# Eval("IsSpecialRecord").ToBool() ? String.Format(("{0}{1} Store"), "** ", Eval("Location")): ""  %>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 100px">
                    <tr>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn-save" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvDeliveryReceipt">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvDeliveryReceipt" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

