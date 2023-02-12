<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-preview.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Production Order ?"));
            }
            if (button.get_commandName() === "cancel") {
                args.set_cancel(!confirm("Are you sure you want to cancel Production Order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Production Order Information</legend>
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
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Prod Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblProductionOrder" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Order Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUserDisplayName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Start Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">End Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Estimated Time :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEstimatedTime" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit Order" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="100px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete Order" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post order" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="100px" />
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="Cancel Order" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel.png" Width="110px" />
                        <telerik:RadToolBarDropDown Text="Close Production Order" ToolTip="Finish" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png">
                            <Buttons>
                                <telerik:RadToolBarButton CommandName="fullclose" Value="fullclose" Text="Fully Close" ToolTip="Fully Close" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="150px" />
                                <telerik:RadToolBarButton CommandName="partclose" Value="partclose" Text="Partially Close" ToolTip="Partially Close" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="150px" />
                            </Buttons>
                        </telerik:RadToolBarDropDown>
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="requestrm" Value="requestrm" Text="Request Raw Materials" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="165px" />
                        <telerik:RadToolBarButton runat="server" CommandName="returnrm" Value="returnrm" Text="Return Raw Materials" ImageUrl="~/ERP/resources/images/toolbar/ico_return.png" Width="165px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="joborder" Value="joborder" Text="View job order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="130px" />
                        <telerik:RadToolBarButton Value="sep3" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print Order" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="100px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Products List</h3>
                    <telerik:RadGrid ID="rgProductionItems" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgProductionItems_NeedDataSource">
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
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="75px" DataFormatString="{0:F0}" />
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <asp:Panel ID="pnlRawMaterialReview" runat="server" Visible="False">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Bill of Raw Materials (BOM)</h3>
                    </div>
                    <telerik:RadGrid ID="rgBillofMaterialsReview" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True" OnNeedDataSource="rgBillofMaterialsReview_NeedDataSource" OnItemDataBound="rgBillofMaterialsReview_ItemDataBound">
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
                                <telerik:GridBoundColumn DataField="MaterialQuantity" HeaderText="Material QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                <telerik:GridBoundColumn DataField="RequiredQuantity" HeaderText="Required QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                <telerik:GridBoundColumn DataField="AvailableQuantity" HeaderText="Available QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                <telerik:GridBoundColumn DataField="ShortageQuantity" HeaderText="Shortage" HeaderStyle-Width="75px" DataFormatString="{0:F3}" />
                                <telerik:GridTemplateColumn UniqueName="Status" HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:Image ID="imgStatus" runat="server" Height="16px" Width="16px" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlRawMaterialsRequest" runat="server">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Raw Materials Transaction History</h3>
                        <telerik:RadGrid ID="rgRawMaterialsRequest" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgRawMaterialsRequest_NeedDataSource" OnItemDataBound="rgRawMaterialsRequest_ItemDataBound">
                            <MasterTableView>
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="MaterialTransferId" HeaderText="ID" HeaderStyle-Width="25px" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <div>
                                                <a href='<%# string.Format("m-trans-preview.aspx?id={0}", Eval("MaterialTransferId")) %>'>
                                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="View" style="border: 0" />
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="MaterialTransferNumber" HeaderText="Transfer #" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="TransferType" HeaderText="Transfer Type" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="LocationFrom" HeaderText="From Store" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="LocationTo" HeaderText="To Store" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="250px" />
                                    <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Prepare Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                                    <telerik:GridTemplateColumn UniqueName="Status" HeaderStyle-Width="20px">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Image ID="imgStatus" runat="server" Height="16px" Width="16px" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <div class="grid-container no-bg">
                            <h3>Bill of Raw Materials (BOM) Summary</h3>
                        </div>
                        <telerik:RadGrid ID="rgRawMaterials" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True" OnNeedDataSource="rgRawMaterials_NeedDataSource">
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
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="TotalQuantity" HeaderText="Total Quantity" HeaderStyle-Width="150px" DataFormatString="{0:F3}" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </asp:Panel>
    </table>
</asp:Content>
