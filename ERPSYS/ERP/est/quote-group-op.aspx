<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-group-op.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteGroupOp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/HierarchyItems/EST/Quote/UCGroupSubItemAdd.ascx" TagName="UCGroupSubItemAdd" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/HierarchyItems/EST/Quote/UCGroupSubItemUpdate.ascx" TagName="UCGroupSubItemUpdate" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/HierarchyItems/EST/Quote/UCGroupSubItemDelete.ascx" TagName="UCGroupSubItemDelete" TagPrefix="uc3" %>
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
        <asp:Panel runat="server" ID="pnlGroupItemAdd" Visible="False">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Add Product To all Groups</legend>
                        <uc1:UCGroupSubItemAdd ID="UCGroupItemAdd" ValidationGroup="save" runat="server" />
                        <div>
                            <asp:Button ID="btnAdd" runat="server" Text="Add Product" ValidationGroup="addItem" CssClass="fs-inner btn-add btn-op-add-es-grp" Visible="True" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('addItem'); if(Page_IsValid) { return confirm('Are you sure you want to add this Product to all groups ?'); } else return;};" OnClick="btnAdd_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlGroupItemUpdate" Visible="False">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Update Products in all Groups</legend>
                        <uc2:UCGroupSubItemUpdate ID="UCGroupItemUpdate" ValidationGroup="save" runat="server" />
                        <div>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="save" CssClass="fs-inner btn-add btn-op-update-es-grp" Visible="True" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to update this Product  in all groups ?'); } else return;};" OnClick="btnUpdate_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlGroupItemReplace" Visible="False">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Replace This Product </legend>
                        <uc3:UCGroupSubItemDelete ID="UCGroupSubItemReplaceOld" ValidationGroup="save" runat="server" />
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">With this Product </legend>
                        <uc1:UCGroupSubItemAdd ID="UCGroupSubItemReplaceNew" ValidationGroup="save" runat="server" />
                        <div>
                            <asp:Button ID="btnReplace" runat="server" Text="Replace" ValidationGroup="save" CssClass="fs-inner btn-add btn-op-replace-es-grp" Visible="True" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to replace this Product  in all groups ?'); } else return;};" OnClick="btnReplace_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlGroupItemDelete" Visible="False">
            <tr>
                <td>
                    <fieldset class="fs-inner">
                        <legend class="fs-inner-legend">Delete Product From all Groups</legend>
                        <uc3:UCGroupSubItemDelete ID="UCGroupItemDelete" ValidationGroup="save" runat="server" />
                        <div>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" ValidationGroup="save" CssClass="fs-inner btn-add btn-op-delete-es-grp" Visible="True" OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to delete this Product  from all groups ?'); } else return;};" OnClick="btnDelete_Click" />
                        </div>
                    </fieldset>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgSalesQuote" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgSalesQuote_NeedDataSource" OnDetailTableDataBind="rgSalesQuote_DetailTableDataBind" OnPreRender="rgSalesQuote_PreRender" OnItemDataBound="rgSalesQuote_ItemDataBound">
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
                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550" />
                                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
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
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 100px">
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
