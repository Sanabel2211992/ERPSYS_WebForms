<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-close.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderClose" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "close") {
                args.set_cancel(!confirm("Are you sure ?"));
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
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view" colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="close" Value="close" Text="close order" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="115px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="order" Value="order" Text="View Production order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="175px" />
                        <telerik:RadToolBarButton runat="server" CommandName="joborder" Value="joborder" Text="View job order" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="130px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Close Production Order Information</legend>
                    <table class="tbl-edit" style="width: 1160px">
                        <tr>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Close Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCCloseDate" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit" colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
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
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="600px" />
                                <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="150px" />
                                <telerik:GridBoundColumn DataField="TotalQuantity" HeaderText="Total Quantity" HeaderStyle-Width="150px" DataFormatString="{0:F3}" />
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
