<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-item-op.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteItemOp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/HierarchyItems/EST/Quote/UCItemMarginUpdate.ascx" TagName="UCItemMarginUpdate" TagPrefix="uc1" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Quotation Information</legend>
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
                            <td class="ft-view">Quote # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblQuoteNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Sales Engineer :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblSalesEngineer" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Currency (View): </td>
                            <td class="fv-view">
                                <asp:Label ID="lblCurrencyView" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Template :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTemplate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Inquiry # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInquiryNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Inquiry Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInquiryDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
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
                            <td class="ft-view" style="width: 100px">Expenses :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblExpenses" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Discount :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Grand Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server" ID="pnlGroupItemMargin" Visible="False">
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Update (Profit / Discount) Margin in all Products</legend>
                        <uc1:UCItemMarginUpdate ID="UCItemMarginItem" ValidationGroup="save" runat="server" />
                        <div>
                            <asp:Button ID="btnUpdateMargin" runat="server" Text="Update" ValidationGroup="save" CssClass="fs-inner btn-add btn-op-updatedis-es-grp" Visible="True" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to change (Profit & Discount) for all Products ?'); } else return;};" OnClick="btnUpdateMargin_Click" />
                        </div>
                    </fieldset>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgQuotes" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                            AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgQuote_NeedDataSource" OnDetailTableDataBind="rgQuote_DetailTableDataBind" OnPreRender="rgQuote_PreRender" OnItemDataBound="rgQuote_ItemDataBound">
                                            <ClientSettings>
                                                <ClientEvents OnGridCreated="main.GridCreated" OnHierarchyExpanded="main.HierarchyExpanded" OnHierarchyCollapsed="main.HierarchyCollapsed"></ClientEvents>
                                            </ClientSettings>
                                            <MasterTableView DataKeyNames="QuoteLineId,ItemId" Name="MainItem" HierarchyLoadMode="Client">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No records to display.</td>
                                                        </tr>
                                                    </table>
                                                </NoRecordsTemplate>
                                                <DetailTables>
                                                    <telerik:GridTableView DataKeyNames="ParentId,QuoteLineId,ItemId" Name="SubItems" BorderWidth="0" Width="100%">
                                                        <ParentTableRelation>
                                                            <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="QuoteLineId"></telerik:GridRelationFields>
                                                        </ParentTableRelation>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderStyle-Width="20px"></telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                                <ItemTemplate>
                                                                    <%#  Container.DataSetIndex + 1%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="600px" />
                                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
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
                                                    <telerik:GridBoundColumn DataField="QuoteId" HeaderText="QuoteId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="675px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
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
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-cancel" Visible="True" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
