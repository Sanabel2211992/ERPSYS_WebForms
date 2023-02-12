<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-bom-form.aspx.cs" Inherits="ERPSYS.ERP.item.ItemBomForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/HierarchyItems/ITEM/BOM/UCItemAdd.ascx" TagName="UCItemAdd" TagPrefix="uc1" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "deletebom") {
                args.set_cancel(!confirm("Are you sure ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Product Information</legend>
                    <table class="tbl-view" style="width: 930px">
                        <tr>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="pt-view" colspan="6">General Information</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Manufacturing :</td>
                            <td class="highlighte" colspan="5">
                                <asp:Label ID="lblStandard" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Product Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Brand :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblBrand" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Catalog Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Part Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Category :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="pt-view" colspan="6">Pricing</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Unit Price :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="productdetails" Value="productdetails" Text="Product Details" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="125px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="clone" Value="clone" Text="clone" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png" Width="65px" />
                        <telerik:RadToolBarButton runat="server" CommandName="deletebom" Value="deletebom" Text="Delete All BOM" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="115px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgItem" runat="server" CssClass="tbl-main img-item-pos1" Height="150px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UCItemAdd ID="UCItemAddMaterial" ValidationGroup="add" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-uc-op" style="width: 100px">
                    <tr>
                        <td>
                            <asp:Button ID="btnAddItem" runat="server" ValidationGroup="add" Text="Add Product" CssClass="btn-uc-bom save-bom" OnClick="btnAddItem_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgBom" runat="server" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None"
                                AllowSorting="True" RetainExpandStateOnRebind="True" OnNeedDataSource="rgBom_NeedDataSource"
                                OnItemCommand="rgBom_ItemCommand" OnUpdateCommand="rgBom_UpdateCommand" OnDeleteCommand="rgBom_DeleteCommand">
                                <MasterTableView DataKeyNames="LineId,ItemBomId">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <EditFormSettings EditFormType="WebUserControl">
                                        <EditColumn UniqueName="EditCommand"></EditColumn>
                                    </EditFormSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="ItemBomId" HeaderText="ItemBomId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                        <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="110px" />
                                        <telerik:GridBoundColumn DataField="SubCategory" HeaderText="SubCategory" HeaderStyle-Width="110px" />
                                        <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F3}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="SellingPrice" HeaderText="Unit Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>
                                        <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
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
            <telerik:AjaxSetting AjaxControlID="btnAddItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="UCItemAddMaterial" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="rgBom" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
