<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="delivery-receipt-preview.aspx.cs" Inherits="ERPSYS.ERP.sm.DeliveryReceiptPreview" %>

<%@ Import Namespace="ERPSYS.Helpers.Ext" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClickingOperations(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "delete") {
                args.set_cancel(!confirm("Are you sure you want to delete the Delivery Receipt ?"));
            }
            if (button.get_commandName() === "post") {
                args.set_cancel(!confirm("Are you sure you want to post the Delivery Receipt ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Delivery Receipt Information</legend>
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
                            <td class="ft-view">Receipt # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Receipt Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Delivery Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Location :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="ft-view">Sales Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkSalesOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Sales Invoice # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkSalesInvoiceNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">Customer L.P.O :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCustomerPO" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="7">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
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
                    <h3>Delivery Receipt Details</h3>
                    <telerik:RadTabStrip RenderMode="Lightweight" ID="rtsDelivery" runat="server" MultiPageID="RadMultiPage1" Width="125px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab PageViewID="RadPageView1" Width="125px" Text="Delivery" Selected="True" />
                            <telerik:RadTab PageViewID="RadPageView2" Width="125px" Text="Stock" Visible="False" />
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="TabMultiPage" RenderSelectedPageOnly="True" Width="100%">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="gvDeliveryReceiptLines" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False"
                                            OnNeedDataSource="gvDeliveryReceiptLines_NeedDataSource" OnItemDataBound="gvDeliveryReceiptLines_ItemDataBound">
                                            <MasterTableView ShowHeadersWhenNoRecords="true">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No Data Found
                                                            </td>
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
                                                    <telerik:GridTemplateColumn HeaderText="Description" HeaderStyle-Width="550px">
                                                        <ItemTemplate>
                                                            <div>
                                                                <%# String.Format(("{1} {0}"), Eval("DescriptionAs") ,Eval("IsSpecialRecord").ToBool() ? "*": "" ) %>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="100px" />
                                                    <telerik:GridTemplateColumn HeaderText="Remarks" HeaderStyle-Width="175px">
                                                        <ItemTemplate>
                                                            <div>
                                                                <%# Eval("IsSpecialRecord").ToBool() ? String.Format(("{0}{1} Store"), "** ", Eval("Location")): ""  %>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                    <telerik:GridTemplateColumn UniqueName="IsService">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgService" runat="server" Height="16px" Width="16px" />
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
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="gvDeliveryReceiptLinesStock" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False"
                                            OnItemDataBound="gvDeliveryReceiptLinesStock_ItemDataBound" OnNeedDataSource="gvDeliveryReceiptLinesStock_NeedDataSource">
                                            <MasterTableView ShowHeadersWhenNoRecords="true">
                                                <NoRecordsTemplate>
                                                    <table class="rgEmptyData">
                                                        <tr>
                                                            <td>No Data Found
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </NoRecordsTemplate>
                                                <Columns>
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" Visible="False" HeaderStyle-Width="45px" />
                                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                                    <telerik:GridBoundColumn DataField="Location" HeaderText="Location" HeaderStyle-Width="125px" />
                                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="StoreQuantity" HeaderText="Store QTY" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="IsServiceItem" Display="false" />
                                                    <telerik:GridTemplateColumn UniqueName="Status">
                                                        <HeaderStyle Width="20px"></HeaderStyle>
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
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsDelivery">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsDelivery" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsDelivery" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
