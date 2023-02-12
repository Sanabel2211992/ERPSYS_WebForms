<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-quote.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoiceQuote" %>

<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer :</td>
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
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Sales Invoice Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Invoice Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Payment Method :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPaymentMethod" ControlToValidate="ddlPaymentMethod" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Payment Terms :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPaymentTerms" ControlToValidate="ddlPaymentTerms"
                                    Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
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
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Total Summary</legend>
                    <table class="tbl-inner-view" style="width: 1125px">
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
                            <asp:Panel ID="pnlSalesTax" Visible="False" runat="server">
                                <td class="ft-view" style="width: 100px">Sales Tax :</td>
                                <td class="fv-view" style="width: 125px">
                                    <asp:Label ID="lblSalesTaxAmount" runat="server"></asp:Label></td>
                            </asp:Panel>
                            <td class="ft-view" style="width: 110px">Grand Total :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Products Details</h3>
                    <telerik:RadGrid ID="rgQuoteGroup" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgQuoteGroup_NeedDataSource" OnDetailTableDataBind="rgQuoteGroup_DetailTableDataBind" OnPreRender="rgQuoteGroup_PreRender">
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
                                <telerik:GridTableView DataKeyNames="ParentId,QuoteLineId,ItemId" Name="SubItems" BInvoiceWidth="0" Width="100%">
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
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
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
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="500px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Create Invoice" Width="135px" CssClass="btn-op"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to create Sales Invoice ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-print" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
