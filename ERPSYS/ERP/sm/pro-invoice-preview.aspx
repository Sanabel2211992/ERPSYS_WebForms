<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="pro-invoice-preview.aspx.cs" Inherits="ERPSYS.ERP.sm.ProformaInvoicePreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Proforma Invoice ?"));
            }
            else if (button.get_commandName() === "cancel") {
                args.set_cancel(!confirm("Are you sure you want to cancel Proforma Invoice ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-view-legend">Proforma Invoice Information</legend>
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
                            <td class="ft-view">Invoice # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Invoice Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Invoice Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
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
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="Cancel" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel.png" Width="70px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="convertsalesinvoice" Value="convertsalesinvoice" Text="Convert to Invoice" ImageUrl="~/ERP/resources/images/toolbar/ico_replace.png" Width="140px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                    </Items>
                </telerik:RadToolBar>
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
                            <td class="ft-view" style="width: 100px">Grand Total :</td>
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
                    <h3>Proforma Invoice Details</h3>
                    <telerik:RadGrid ID="rgProInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnNeedDataSource="rgProInvoice_NeedDataSource" OnDetailTableDataBind="rgProInvoice_DetailTableDataBind" OnPreRender="rgProInvoice_PreRender" OnItemDataBound="rgProInvoice_ItemDataBound">
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
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No sub records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px"></telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                        <telerik:GridTemplateColumn UniqueName="IsService">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Image ID="imgService" runat="server" Height="16px" Width="16px" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="InvoiceId" HeaderText="InvoiceId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                <telerik:GridTemplateColumn UniqueName="IsService">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Image ID="imgService" runat="server" Height="16px" Width="16px" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="ramInvoice" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgProInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
