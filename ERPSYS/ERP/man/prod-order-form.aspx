<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-form.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "fillrm") {
                args.set_cancel(!confirm("Are you sure?"));
            }
            else if (button.get_commandName() === "deleterm") {
                args.set_cancel(!confirm("Are you sure?"));
            }
        }
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Production Order ?"));
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
                            <td class="ft-view">Order Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">
                                &nbsp;</td>

                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">
                                &nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">
                                &nbsp;</td>
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
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete Order" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post order" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="100px" />
                        <telerik:RadToolBarButton IsSeparator="true"/>
                        <telerik:RadToolBarButton runat="server" CommandName="jorder" Text="View Job Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="125px" />
                        <telerik:RadToolBarButton runat="server" CommandName="porder" Text="View Production Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="175px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Product List</h3>
                    <telerik:RadGrid ID="rgProductionItems" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgProductionItems_NeedDataSource" OnItemCommand="rgProductionItems_ItemCommand" OnUpdateCommand="rgProductionItems_UpdateCommand">
                        <MasterTableView DataKeyNames="LineId,ItemId">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <EditFormSettings EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommand" />
                            </EditFormSettings>
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
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
                                    <HeaderStyle Width="20px" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbBOMOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbBOMOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="fillrm" Text="Fill Raw Materials" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="150px" ValidationGroup="save" />
                        <telerik:RadToolBarButton runat="server" CommandName="deleterm" Text="Delete All Raw Materials" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="175px" ValidationGroup="save" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Bill of Raw Materials (BOM)</h3>
                </div>
                <telerik:RadTabStrip ID="rtsProductionOrder" runat="server" MultiPageID="rmpBom" AutoPostBack="True" Skin="BlackMetroTouch" OnTabClick="rtsProductionOrder_TabClick" SelectedIndex="1">
                    <Tabs>
                        <telerik:RadTab PageViewID="pvBom" Width="125px" Text="BOM" Selected="True" />
                        <telerik:RadTab PageViewID="pvStock" Width="135px" Text="Quantity Check" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="rmpBom" runat="server" CssClass="TabMultiPage" Width="100%" SelectedIndex="1">
                    <telerik:RadPageView ID="pvBom" runat="server" Selected="true">
                        <telerik:RadGrid ID="rgBillofMaterials" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True"
                            OnNeedDataSource="rgBillofMaterials_NeedDataSource" OnItemCommand="rgBillofMaterials_ItemCommand"
                            OnInsertCommand="rgBillofMaterials_InsertCommand" OnUpdateCommand="rgBillofMaterials_UpdateCommand" OnDeleteCommand="rgBillofMaterials_DeleteCommand">
                            <MasterTableView DataKeyNames="LineId,ItemId" CommandItemDisplay="Top">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <CommandItemSettings AddNewRecordText="Add Raw Material" />
                                <EditFormSettings EditFormType="WebUserControl">
                                    <EditColumn UniqueName="EditCommand" />
                                </EditFormSettings>
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
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
                                        <HeaderStyle Width="20px" />
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommand">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvStock" runat="server">
                        <telerik:RadGrid ID="rgBillofMaterialsReview" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True" OnNeedDataSource="rgBillofMaterialsReview_NeedDataSource" OnItemDataBound="rgBillofMaterialsReview_ItemDataBound">
                            <MasterTableView CommandItemDisplay="Top">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <CommandItemSettings ShowAddNewRecordButton="False" />
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="MaterialQuantity" HeaderText="Material QTY" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="RequiredQuantity" HeaderText="Required QTY" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="AvailableQuantity" HeaderText="Available QTY" HeaderStyle-Width="100px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="ShortageQuantity" HeaderText="Shortage" HeaderStyle-Width="50px" DataFormatString="{0:F3}" />
                                    <telerik:GridTemplateColumn UniqueName="Status" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="imgStatus" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgProductionItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProductionItems" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgBillofMaterials">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBillofMaterials" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgBillofMaterialsReview">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBillofMaterialsReview" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtbBOMOperations">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBillofMaterials" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="rgBillofMaterialsReview" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtsProductionOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProductionOrder" />
                    <telerik:AjaxUpdatedControl ControlID="rmpBom" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
