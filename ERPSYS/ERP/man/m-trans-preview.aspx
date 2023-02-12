<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="m-trans-preview.aspx.cs" Inherits="ERPSYS.ERP.man.MaterialTransferPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure want Post the Transfer ?"));
            }
            else if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want Delete the Transfer ?"));
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
                            <td class="ft-view">M Transfer # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialTransferNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialTransferStatus" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Order Type :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderType" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">From Store :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblFromLocation" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">To Store :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblToLocation" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Trans Type :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTransactionType" runat="server"></asp:Label>
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
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="55px" />
                        <telerik:RadToolBarButton Value="sep1" IsSeparator="true" />                        
                        <telerik:RadToolBarButton runat="server" CommandName="order" Value="order" Text="View Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="100" />
                        <telerik:RadToolBarButton runat="server" CommandName="joborder" Value="joborder" Text="View Job Order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="125px" />
                        <telerik:RadToolBarButton Value="sep2" IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="70px" />
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
        <asp:Panel ID="pnlRawMaterialsReview" runat="server" Visible="False">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Bill of Raw Materials (BOM)</h3>
                        <telerik:RadGrid ID="rgRawMaterialsReview" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="rgRawMaterialsReview_NeedDataSource">
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
                                            <%#  Container.DataSetIndex + 1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="150px" />
                                    <telerik:GridBoundColumn DataField="MaterialQuantity" HeaderText="Material QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="RequiredQuantity" HeaderText="Required QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="AvailableQuantity" HeaderText="Available QTY" HeaderStyle-Width="115px" DataFormatString="{0:F3}" />
                                    <telerik:GridBoundColumn DataField="ShortageQuantity" HeaderText="Shortage" HeaderStyle-Width="75px" DataFormatString="{0:F3}" />
                                    <telerik:GridTemplateColumn UniqueName="Status" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:Image ID="imgStatus" runat="server" Width="16" Height="16" />
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
        <asp:Panel ID="pnlRawMaterials" runat="server">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Bill of Raw Materials (BOM)</h3>
                        <telerik:RadGrid ID="rgRawMaterials" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="rgRawMaterials_NeedDataSource">
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
                                            <%#  Container.DataSetIndex + 1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="200px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F3}" HeaderStyle-Width="50px" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgRawMaterialsReview">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgRawMaterialsReview" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
