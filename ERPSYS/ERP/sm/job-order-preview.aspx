<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="job-order-preview.aspx.cs" Inherits="ERPSYS.ERP.sm.JobOrderPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to Delete Job Order ?"));
            }
            else if (button.get_commandName() === "cancel") {
                args.set_cancel(!confirm("Are you sure you want to Cancel Job Order ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to Post Job Order ?"));
            }
            else if (button.get_commandName() === "close") {
                args.set_cancel(!confirm("Are you sure you want to Close Job Order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Job Order Information</legend>
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
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblJobOrderNumber" runat="server"></asp:Label>
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
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="Cancel" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel.png" Width="70px" />
                        <telerik:RadToolBarButton runat="server" CommandName="close" Value="close" Text="Close" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="60px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="compact" Value="compact" Text="Compact View" ImageUrl="~/ERP/resources/images/toolbar/ico_compact.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="groups" Value="groups" Text="Group View" ImageUrl="~/ERP/resources/images/toolbar/ico_group.png" Width="100px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="issuematerials" Value="issuematerials" Text="issue materials" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="120px" />
                        <%--                        <telerik:RadToolBarButton runat="server" CommandName="export" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" /> --%>
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Job Order Products Details</h3>
                    <asp:Panel ID="pnlGroupView" Visible="True" runat="server">
                        <telerik:RadGrid ID="rgJobOrderGroup" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                            AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgJobOrderGroup_NeedDataSource" OnDetailTableDataBind="rgJobOrderGroup_DetailTableDataBind" OnPreRender="rgJobOrderGroup_PreRender">
                            <ClientSettings EnableAlternatingItems="false">
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
                                    <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" BorderWidth="0" Width="100%" Caption="Bill Of Quantities (BOQ)" CssClass="grid-tbl-dtl">
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="LineId"></telerik:GridRelationFields>
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
                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="650px" />
                                            <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="125px" />
                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                            <telerik:GridTemplateColumn HeaderStyle-Width="80px"></telerik:GridTemplateColumn>
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
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="600px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                    <asp:Panel ID="pnlCompactView" Visible="False" runat="server">
                        <telerik:RadGrid ID="rgJobOrderLine" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" Skin="Default" OnNeedDataSource="rgJobOrderLine_NeedDataSource" OnItemDataBound="rgJobOrderLine_ItemDataBound">
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
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="600px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                                    <telerik:GridBoundColumn DataField="IsManufacture" Display="False" />
                                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Image ID="imgProduct" runat="server" Height="16px" Width="16px" />
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
        <asp:Panel ID="pnlOrderTransactions" runat="server">
            <tr>
                <td>
                    <telerik:RadToolBar ID="rtbOrders" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOrders_ButtonClick" Skin="Metro">
                        <Items>
                            <telerik:RadToolBarButton runat="server" CommandName="production" Text="Create Production Order" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="190px" />
                            <telerik:RadToolBarButton runat="server" CommandName="modification" Text="Create Modification Order" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="200px" />
                            <telerik:RadToolBarButton runat="server" CommandName="assembly" Text="Create Assemlby Order" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="180px" />
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Job Order Transactions</h3>
                        <telerik:RadGrid ID="rgJobOrderGroupTransactions" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False"
                            AutoGenerateColumns="False" OnNeedDataSource="rgJobOrderGroupTransactions_NeedDataSource" OnItemDataBound="rgJobOrderGroupTransactions_ItemDataBound">
                            <MasterTableView ShowHeadersWhenNoRecords="true">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="JobOrderId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridBoundColumn DataField="OrderId" HeaderStyle-Width="45px" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <div>
                                                <asp:ImageButton ID="imgbtnLink" ImageUrl="../../Controls/resources/images/ico_search_16_16.gif" Height="16px" Width="16px" runat="server" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="OrderType" HeaderText="Order Type" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="OrderNumber" HeaderText="Order #" HeaderStyle-Width="100px" />
                                    <telerik:GridDateTimeColumn DataField="StartDate" HeaderText="Start Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                    <telerik:GridDateTimeColumn DataField="EndDate" HeaderText="End Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                    <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Prepare Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="OrderTypeId" Display="False" />
                                    <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="125px">
                                        <HeaderStyle Width="125px"></HeaderStyle>
                                        <ItemTemplate>
                                            <div>
                                                <asp:Image ID="imgStatus" runat="server" Height="13px" Width="13px" />
                                                <span><%#  Eval("OrderStatus") %></span>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Percent Completed" HeaderStyle-Width="125px">
                                        <HeaderStyle Width="125px"></HeaderStyle>
                                        <ItemTemplate>
                                            <div>
                                                <%--<telerik:RadProgressBar ID="RadProgressBar1" Skin="Telerik" runat="server" Minimum="0" Maximum='<%#  Eval("Quantity") %>' Width="50" Height="20"></telerik:RadProgressBar>--%>
                                                <telerik:RadProgressBar ID="rpbPercentCompleted" Skin="Telerik" runat="server" Minimum="0" Maximum="100" Width="50" Height="20"></telerik:RadProgressBar>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgJobOrderGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgJobOrderGroup" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbOperations">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlGroupView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="pnlCompactView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

