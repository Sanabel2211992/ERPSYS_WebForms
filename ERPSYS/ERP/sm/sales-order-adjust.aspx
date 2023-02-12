<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-order-adjust.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesOrderAdjust" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Sales Order Information</legend>
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
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Order Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer L.P.O :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCustomerPO" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblJobOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
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
                    <h3>Sales Order Details</h3>
                    <telerik:RadGrid ID="rgSalesOrder" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnDetailTableDataBind="rgSalesOrder_DetailTableDataBind" OnItemCommand="rgSalesOrder_ItemCommand"
                        OnNeedDataSource="rgSalesOrder_NeedDataSource" OnPreRender="rgSalesOrder_PreRender" OnItemDataBound="rgSalesOrder_ItemDataBound">
                        <MasterTableView DataKeyNames="LineId,LineSeqId,ItemId" Name="MainItem">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" ShowFooter="true"
                                    AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                                    Width="100%">
                                    <NoRecordsTemplate>
                                        <table class="rginnerEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
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
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" Display="False" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Net Price" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~/Controls/resources/images/grid/Exclude.gif" CommandName="Exclude" Text="Exclude Item from Group" UniqueName="UpColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="OrderId" HeaderText="OrderId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineSeqId" HeaderText="LineSeqId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" Display="False" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="670px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
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
