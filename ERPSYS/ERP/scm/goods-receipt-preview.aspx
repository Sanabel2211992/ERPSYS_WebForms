<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-receipt-preview.aspx.cs" Inherits="ERPSYS.ERP.scm.GoodsReceiptPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete the material receipt ?"));
            }
            else if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post the material receipt ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Material Receipt Information</legend>
                    <table class="tbl-view" style="width: 1180px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Material Receipt # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Receipt Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Received Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Location :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Purchase Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkPurchaseOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Posted By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Supplier Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkSupplierName" ToolTip="preview Supplier Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks : </td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlCancelRemarks" runat="server" Visible="false">
                            <tr>
                                <td class="ft-view">Cancel Remarks :</td>
                                <td class="fv-view" colspan="3">
                                    <asp:Label ID="lblCancelRemarks" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Canceled By :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCanceledBy" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Canceled Date :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCanceledDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </asp:Panel>
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
                        <telerik:RadToolBarButton runat="server" CommandName="cancel" Value="cancel" Text="Cancel Material Receipt" ImageUrl="~/ERP/resources/images/toolbar/ico_cancel_red.png" Width="175px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Material Receipt Details</h3>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgGoodsReceipt" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                                AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False" OnNeedDataSource="rgGoodsReceipt_NeedDataSource">
                                <MasterTableView DataKeyNames="LineId">
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
                                        <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="600px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="45px" />
                                        <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="125px" />
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

