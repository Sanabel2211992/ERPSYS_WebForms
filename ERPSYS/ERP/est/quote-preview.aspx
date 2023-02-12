<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-preview.aspx.cs" Inherits="ERPSYS.ERP.est.QuotePreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
            else if (button.get_commandName() === "cancel") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
            else if (button.get_commandName() === "clone") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("are you sure you want to post ?"));
            }
            else if (button.get_commandName() === "termsandconditions") {
                OpenTermsConditionsDialog();
            }
        }

        function OpenTermsConditionsDialog() {
            if ($('#<%= hfquoteId.ClientID %>').val() !== "") {
                var quoteId = $('#<%= hfquoteId.ClientID %>').val();
                var manager = window.$find("<%= rwmTermsConditions.ClientID %>");
                manager.open("../../Controls/DialogBox/EST/Quote/terms-conditions-preview.aspx?id=" + quoteId, "rwmTermsConditions");
            }
        }
    </script>
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" CssClass="tb-main" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="45px" />
                        <telerik:RadToolBarButton runat="server" CommandName="revise" Value="revise" Text="revise" ImageUrl="~/ERP/resources/images/toolbar/ico_revise.png" Width="57px" />
                        <telerik:RadToolBarButton runat="server" CommandName="clone" Value="clone" Text="clone" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png" Width="62px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="65px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="65px" />
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="cancel" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel.png" Width="63px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="compact" Value="compact" Text="Compact View" ImageUrl="~/ERP/resources/images/toolbar/ico_compact.png" Width="108px" />
                        <telerik:RadToolBarButton runat="server" CommandName="groups" Value="groups" Text="group view" ImageUrl="~/ERP/resources/images/toolbar/ico_group.png" Width="95px" />
                        <telerik:RadToolBarButton runat="server" CommandName="pivot" Value="pivot" Text="estimation view" ImageUrl="~/ERP/resources/images/toolbar/ico_group.png" Width="125px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="cost" Value="cost" Text="quote cost" ImageUrl="~/ERP/resources/images/toolbar/ico-cost.png" Width="97px" />
                        <telerik:RadToolBarButton runat="server" CommandName="stock" Value="stock" Text="stock check" ImageUrl="~/ERP/resources/images/toolbar/ico_store.png" Width="100px" />
                        <telerik:RadToolBarButton Value="sep3" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="57px" />
                        <telerik:RadToolBarButton Value="sep4" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="invoicev" Value="invoicev" Text="View Sales Invoice" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="137px" />
                        <telerik:RadToolBarButton runat="server" CommandName="orderv" Value="orderv" Text="View Sales Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="130px" />
                        <telerik:RadToolBarDropDown Text="Create" ToolTip="Create" DropDownWidth="192px" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png">
                            <Buttons>
                                <telerik:RadToolBarButton runat="server" CommandName="orderc" Value="orderc" Text="Create Sales Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="130px" />
                                <telerik:RadToolBarButton Value="sep5" IsSeparator="true" />
                                <telerik:RadToolBarButton runat="server" CommandName="invoicec" Value="invoicec" Text="Create Sales Invoice" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="130px" />
                            </Buttons>
                        </telerik:RadToolBarDropDown>
                        <telerik:RadToolBarDropDown Text="More" ToolTip="More" DropDownWidth="192px" Width="60px" ImageUrl="~/ERP/resources/images/toolbar/ico-add.png">
                            <Buttons>
                                <telerik:RadToolBarButton CommandName="termsandconditions" Value="termsandconditions" Text="View Terms & Conditions" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="190px" />
                            </Buttons>
                        </telerik:RadToolBarDropDown>
                        <telerik:RadToolBarButton></telerik:RadToolBarButton>
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
                    <h3>Quotation Details</h3>
                    <asp:Panel ID="pnlGroupView" Visible="True" runat="server">
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
                                    <telerik:GridTableView DataKeyNames="ParentId,QuoteLineId,ItemId" Name="SubItems" BorderWidth="0" Width="100%">
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="QuoteLineId"></telerik:GridRelationFields>
                                        </ParentTableRelation>
                                        <NoRecordsTemplate>
                                            <table class="rginnerEmptyData">
                                                <tr>
                                                    <td>No records to display.</td>
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
                    </asp:Panel>
                    <asp:Panel ID="pnlCompactView" Visible="False" runat="server">
                        <telerik:RadGrid ID="rgQuoteLine" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" Skin="Default" OnNeedDataSource="rgQuoteLine_NeedDataSource">
                            <MasterTableView>
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="600px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                    <asp:Panel ID="pnlStockView" Visible="False" runat="server">
                        <telerik:RadGrid ID="rgQuoteReview" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True" OnNeedDataSource="rgQuoteReview_NeedDataSource" OnItemDataBound="rgQuoteReview_ItemDataBound">
                            <MasterTableView>
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="RequiredQuantity" HeaderText="Quote QTY" HeaderStyle-Width="115px" DataFormatString="{0:0}" />
                                    <telerik:GridBoundColumn DataField="AvailableQuantity" HeaderText="Available QTY" HeaderStyle-Width="115px" DataFormatString="{0:0}" />
                                    <telerik:GridBoundColumn DataField="ShortageQuantity" HeaderText="Shortage" HeaderStyle-Width="75px" DataFormatString="{0:0}" />
                                    <telerik:GridTemplateColumn UniqueName="Status" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="imgStatus" runat="server" Height="16px" Width="16px" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfquoteId" runat="server" />
    <telerik:RadWindowManager ID="rwmTermsConditions" runat="server" Title="View Terms & Conditions" RenderMode="Lightweight" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true"
        Width="815px" Height="380px" Behaviors="Close" IconUrl="~/ERP/resources/images/toolbar/ico_order.png" VisibleStatusbar="false">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgQuoteGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuoteGroup" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbOperations">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlGroupView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="pnlCompactView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="pnlStockView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
