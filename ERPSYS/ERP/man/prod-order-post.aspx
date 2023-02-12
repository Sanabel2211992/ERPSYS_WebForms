<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-post.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderPost" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post Production Order ?"));
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
                    <table class="tbl-view" style="width: 1120px">
                        <tr>
                            <th class="ft-view" style="width: 110px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 110px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 110px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 110px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Estimated Days :</td>
                            <td class="fv-view">
                                <asp:TextBox ID="txtEstimatedDays" runat="server" Width="50px"></asp:TextBox></td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="5">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="fv-view" colspan="8">
                                <b>☞
                                <asp:Label ID="lblProductionNote" runat="server"></asp:Label></b>
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
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Text="Post Production order" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="180px" />
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
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Bill of Raw Materials Review (BOM)</h3>
                </div>
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
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                            <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
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
            </td>
        </tr>
    </table>
</asp:Content>
