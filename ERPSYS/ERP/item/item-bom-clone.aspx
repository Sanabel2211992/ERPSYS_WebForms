<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-bom-clone.aspx.cs" Inherits="ERPSYS.ERP.item.ItemBomClone" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
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
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
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
                            <td class="ft-view">Brand :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblBrand" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="pt-view" colspan="6">Pricing</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Unit Price :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgItem" runat="server" CssClass="tbl-main img-item-pos1" Height="150px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgBom" runat="server" AllowPaging="False" AllowSorting="true" ShowFooter="true" AutoGenerateColumns="False" OnNeedDataSource="rgBom_NeedDataSource">
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="120" />
                                    <Resizing AllowRowResize="True" />
                                </ClientSettings>
                                <MasterTableView ShowHeadersWhenNoRecords="true">
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
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Clone The BOM To The Following Products</legend>
                    <table class="tbl-search" style="width: 900px">
                        <tr>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 175px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 175px"></td>
                            <td class="ft-search" style="width: 125px"></td>
                            <td class="fv-search" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Description :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtDescription" runat="server" Width="457px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Product Type :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Catalog Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Part Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtPartNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Category :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Brand :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlBrand" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="ft-search">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" /></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgItemList" runat="server" AllowPaging="False" AllowSorting="False" ShowFooter="true" AutoGenerateColumns="False" OnInit="rgItemList_Init">
                                <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="ItemId">
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
                                        <telerik:GridTemplateColumn HeaderStyle-Width="45px" UniqueName="CheckBoxTemplateColumn">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbItem" runat="server" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="600px" />
                                        <telerik:GridBoundColumn DataField="BrandName" HeaderText="Brand" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="CategoryName" HeaderText="Category" HeaderStyle-Width="175px" />
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnClone" runat="server" Text="Clone" CssClass="btn-save" OnClientClick="return confirm('Are you sure you want to clone this BOM to the selected Products ?');" OnClick="btnClone_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-cancel" OnClick="btnBack_Click" CausesValidation="False" />
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
            <telerik:AjaxSetting AjaxControlID="rgBom">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBom" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="lblBomPrice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItemList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
