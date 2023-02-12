<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="modif-order-form.aspx.cs" Inherits="ERPSYS.ERP.man.ModificationOrderForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Modification Order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Modification Order Information</legend>
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
                            <td class="ft-view">Mod Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblModificationOrder" runat="server"></asp:Label>
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
                            <td class="fv-view">&nbsp;</td>

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

                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
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
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="jorder" Text="View Job Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="125px" />
                        <telerik:RadToolBarButton runat="server" CommandName="modiforder" Text="View Modification Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="200px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Modification Order Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlModificationLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvModificationLocation" ControlToValidate="ddlModificationLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="update" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Materials Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlMaterialLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvMaterialLocatio" ControlToValidate="ddlMaterialLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="update" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-st-mod" ValidationGroup="update"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('update'); if(Page_IsValid) { return confirm('Are you sure you want to save the Modification Order information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Input Product</h3>
                    <telerik:RadGrid ID="rgModificationInputItems" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgModificationInputItems_NeedDataSource" OnItemCommand="rgModificationInputItems_ItemCommand" OnUpdateCommand="rgModificationInputItems_UpdateCommand">
                        <MasterTableView DataKeyNames="LineId,InputItemId">
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
                                <telerik:GridBoundColumn DataField="InputPartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="InputItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="InputDescription" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="InputCategory" HeaderText="Category" HeaderStyle-Width="150px" />
                                <telerik:GridBoundColumn DataField="InputQuantity" HeaderText="Quantity" HeaderStyle-Width="75px" DataFormatString="{0:F0}" />
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
                <div class="grid-container no-bg">
                    <h3>Output Product</h3>
                    <telerik:RadGrid ID="rgModificationOutputItems" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False"
                        OnNeedDataSource="rgModificationOutputItems_NeedDataSource" OnItemCommand="rgModificationOutputItems_ItemCommand" OnUpdateCommand="rgModificationOutputItems_UpdateCommand">
                        <MasterTableView DataKeyNames="LineId,OutputItemId">
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
                                <telerik:GridBoundColumn DataField="OutputPartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="OutputItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="OutputDescription" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="OutputCategory" HeaderText="Category" HeaderStyle-Width="150px" />
                                <telerik:GridBoundColumn DataField="OutputQuantity" HeaderText="Quantity" HeaderStyle-Width="75px" DataFormatString="{0:F0}" />
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
                <div class="grid-container no-bg">
                    <h3>Bill of Materials (BOM)</h3>
                </div>
                <telerik:RadTabStrip ID="rtsModificationOrder" runat="server" MultiPageID="rmpBom" AutoPostBack="True" Skin="BlackMetroTouch" OnTabClick="rtsModificationOrder_TabClick" SelectedIndex="1">
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
                            <MasterTableView DataKeyNames="LineId,ItemBomId" CommandItemDisplay="Top">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <CommandItemSettings AddNewRecordText="Add Material" />
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
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F3}" HeaderStyle-Width="100px" />
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
                                        <HeaderStyle Width="20px" />
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this Material ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommand">
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
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="MaterialQuantity" HeaderText="Material QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="RequiredQuantity" HeaderText="Required QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="AvailableQuantity" HeaderText="Available QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="ShortageQuantity" HeaderText="Shortage" HeaderStyle-Width="75px" DataFormatString="{0:F3}" />
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgModificationInputItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgModificationInputItems" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgModificationOutputItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgModificationOutputItems" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
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
            <telerik:AjaxSetting AjaxControlID="rtsModificationOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsModificationOrder" />
                    <telerik:AjaxUpdatedControl ControlID="rmpBom" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
