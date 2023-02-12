<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="transfer-preview.aspx.cs" Inherits="ERPSYS.ERP.inventory.TransferPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete Stock Transfer ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to Post Stock Transfer ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Stock Transfer Information</legend>
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
                            <td class="ft-view">Transfer # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTransferNumber" runat="server"></asp:Label></td>
                            <td class="ft-view">Status : </td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblJobOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Description :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblTransferDescription" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">From Stock :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblFromLocation" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">To Stock :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblToLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Posted By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Posted Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                            </td>
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClickingOperations" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="post" Value="post" Text="Post" ImageUrl="~/ERP/resources/images/toolbar/ico_post2.png" Width="60px" />
                        <telerik:RadToolBarButton runat="server" CommandName="print" Value="print" Text="Print" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="60px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Stock Transfer Details
                    </h3>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTabStrip RenderMode="Lightweight" ID="rts" runat="server" MultiPageID="RadMultiPage1" Width="125px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab PageViewID="RadPageView1" Width="125px" Text="Transfer" Selected="True" />
                        <telerik:RadTab PageViewID="RadPageView2" Width="125px" Text="Stock Overview" Visible="False" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="TabMultiPage" RenderSelectedPageOnly="True" Width="100%">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgStockTransfer" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="rgStockTransfer_NeedDataSource">
                                        <MasterTableView DataKeyNames="LineId,ItemId">
                                            <NoRecordsTemplate>
                                                <table class="rgEmptyData">
                                                    <tr>
                                                        <td>No records to display.</td>
                                                    </tr>
                                                </table>
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                                    <ItemTemplate>
                                                        <%#  Container.DataSetIndex + 1%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="TransferId" HeaderText="TransferId" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="650px" />
                                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="75px" />
                                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgStockTransferStatus" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" OnItemDataBound="rgStockTransferStatus_ItemDataBound" OnNeedDataSource="rgStockTransferStatus_NeedDataSource">
                                        <MasterTableView DataKeyNames="ItemId">
                                            <NoRecordsTemplate>
                                                <table class="rgEmptyData">
                                                    <tr>
                                                        <td>No records to display.</td>
                                                    </tr>
                                                </table>
                                            </NoRecordsTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                                    <ItemTemplate>
                                                        <%#  Container.DataSetIndex + 1%>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="125px" Display="False" />
                                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="450px" />
                                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Request QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="FromLocation" HeaderText="From" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="FromLocationQuantity" HeaderText="Source QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="ToLocation" HeaderText="To" HeaderStyle-Width="125px" />
                                                <telerik:GridBoundColumn DataField="ToLocationQuantity" HeaderText="Des QTY" DataFormatString="{0:F0}" HeaderStyle-Width="125px" />
                                                <telerik:GridTemplateColumn UniqueName="Status">
                                                    <HeaderStyle Width="20px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgStatus" runat="server" Height="13px" Width="14px"  />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>                    

                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxManager ID="ram" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rts">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rts" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rts" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
