<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-preview-x.aspx.cs" Inherits="ERPSYS.ERP.item.ItemPreviewx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Value="back" Text="Back" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="55px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="bom" Value="bom" Text="bom" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton runat="server" CommandName="delete" Value="delete" Text="Delete" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="60px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="copy" Value="copy" Text="Copy Product" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png" Width="110px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTabStrip ID="rtsProduct" runat="server" RenderMode="Lightweight" CssClass="ts-view" MultiPageID="RadMultiPage1" Width="250px" Align="Justify" AutoPostBack="True" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab PageViewID="rpvInformation" Text="Product Information" Selected="True" />
                        <telerik:RadTab PageViewID="rpvBOM" Text="Product BOM" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="mp-view" RenderSelectedPageOnly="True" Width="100%">
                    <telerik:RadPageView ID="rpvInformation" runat="server" Selected="true">
                        <table class="tbl-view" style="width: 900px">
                            <tr>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                                <th class="ft-view" style="width: 125px"></th>
                                <th class="fv-view" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-view">Product Type :</td>
                                <td class="fv-view" colspan="5">
                                    <asp:Label ID="lblItemType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Product Name :</td>
                                <td class="fv-view" colspan="5">
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">Product Name (AR):</td>
                                <td class="fv-view" colspan="5">
                                    <asp:Label ID="lblDescriptionAr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
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
                                <td class="ft-view">Additional Code :</td>
                                <td class="fv-view"><asp:Label ID="lblAdditionalCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="ft-view">Category :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Sub Category :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblSubCategory" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Brand :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblBrand" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-view">UOM :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblUom" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Bar Code :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblBarCode" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view"></td>
                                <td class="fv-view"></td>
                            </tr>
                             <tr>
                               <td class="ft-view">Unit Price :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">Minimum Price :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblMinPrice" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view"></td>
                                <td class="fv-view"></td>
                            </tr>
                            <tr>
                                <td class="ft-view">Status :</td>
                                <td class="fv-view">
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
                                <td class="ft-view">&nbsp;</td>
                                <td class="fv-view">&nbsp;</td>
                            </tr>
                            <tr>
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
                                    <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="img-item-pos2">
                            <asp:Image ID="imgItem" runat="server" Height="150px" Width="150px" />
                        </div>
                        <table runat="server" id="tblItemView" class="item-view-prop2">
                            <tr>
                                <td>
                                    <asp:Label ID="lblManufacture" CssClass="highlighte" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStandard" CssClass="highlighte" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCanBeSold" CssClass="highlighte" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvBOM" runat="server">
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgBom" runat="server" ShowStatusBar="True" AutoGenerateColumns="False" GridLines="None" AllowMultiRowSelection="False"
                                        AllowPaging="False" AllowSorting="False" ShowFooter="True" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False">
                                        <MasterTableView DataKeyNames="LineId,ItemBomId">
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
                                                <telerik:GridBoundColumn DataField="LineId" Visible="False" />
                                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                                <telerik:GridBoundColumn DataField="ItemBomId" HeaderText="ItemBomId" HeaderStyle-Width="45px" Display="False" />
                                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="670px" />
                                                <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="50px" />
                                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                                <telerik:GridBoundColumn DataField="SellingPrice" HeaderText="Unit Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgBom">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBom" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtsProduct">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProduct" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProduct" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
