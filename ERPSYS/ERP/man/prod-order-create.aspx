<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="prod-order-create.aspx.cs" Inherits="ERPSYS.ERP.man.ProductionOrderCreate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "create") {
                args.set_cancel(!confirm("Are you sure you want to Create Order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Job Order Information</legend>
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
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
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
                        <telerik:RadToolBarButton runat="server" CommandName="back" Text="Back to job order" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="135px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Job Order Manufacture Products List</h3>
                    <telerik:RadGrid ID="rgManufactureItem" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" Skin="Default" OnItemCommand="rgManufactureItem_ItemCommand">
                        <MasterTableView DataKeyNames="ItemId">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No Manufacture Products found in Job Order to start Production Order.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <ColumnGroups>
                                <telerik:GridColumnGroup Name="Quantity" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center" />
                            </ColumnGroups>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="select" Text="Select" UniqueName="Select" HeaderStyle-Width="50px" />
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="OrderQty" HeaderText="ORDER" HeaderStyle-Width="75px" DataFormatString="{0:F0}" ColumnGroupName="Quantity" />
                                <telerik:GridBoundColumn DataField="WIPQty" HeaderText="WIP" HeaderStyle-Width="75px" DataFormatString="{0:F0}" ColumnGroupName="Quantity" />
                                <telerik:GridBoundColumn DataField="FinishedQty" HeaderText="FINISHED" HeaderStyle-Width="75px" DataFormatString="{0:F0}" ColumnGroupName="Quantity" />
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <asp:Panel ID="pnlItemSelection" runat="server" Visible="False">
            <tr>
                <td>
                    <div class="grid-container no-bg">
                        <h3>Order Product Details</h3>
                        <telerik:RadGrid ID="rgProductionItem" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False">
                            <MasterTableView DataKeyNames="ItemId">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>Please Select a Product from above list to Proceed.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="600px" />
                                    <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <table style="width: 100px">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Width="75px" MinValue="1">
                                                            <NumberFormat DecimalDigits="0"></NumberFormat>
                                                        </telerik:RadNumericTextBox>
                                                        <asp:RequiredFieldValidator ID="rvfQuantity" runat="server" CssClass="val-error" ValidationGroup="save" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtQuantity" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="center-btn">
                    <table class="tbl-op-center" style="width: 200px">
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Continue" CssClass="btn-save" ValidationGroup="save"
                                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgManufactureItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgManufactureItem" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="rgProductionItem" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
