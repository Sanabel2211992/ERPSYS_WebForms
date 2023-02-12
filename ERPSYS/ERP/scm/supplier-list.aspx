<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="supplier-list.aspx.cs" Inherits="ERPSYS.ERP.scm.SupplierList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtSupplierName.ClientID %>').val("");
            $('#<%= txtContactName.ClientID %>').val("");
            $('#<%= txtCountry.ClientID %>').val("");
            $('#<%= txtCity.ClientID %>').val("");
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 600px">
                        <tr>
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Supplier Name</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtSupplierName" runat="server" Width="440px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search" style="width: 125px">Contact Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtContactName" runat="server" Width="440px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Country :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">City :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCity" runat="server" Width="145px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-search" OnClientClick="ClearFields(); return false;" /></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <div>
        <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="add" Text="Add New Supplier" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="150px" />
                <telerik:RadToolBarButton runat="server" OuterCssClass="pull-right" CommandName="export" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgSupplierList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgSupplierList_NeedDataSource" OnInit="rgSupplierList_Init">
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
                    <telerik:GridBoundColumn DataField="SupplierId" HeaderText="ID" HeaderStyle-Width="25px" Visible="false" />
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("supplier-view.aspx?o=edit&id={0}", Eval("SupplierId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Supplier Details" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" HeaderStyle-Width="300px" />
                    <telerik:GridBoundColumn DataField="NameAr" HeaderText="Arabic Name" HeaderStyle-Width="300px" />
                    <telerik:GridBoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="City" HeaderText="City" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="ContactName" HeaderText="Contact Name" HeaderStyle-Width="125px" />
                    <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("supplier-delete.aspx?id={0}", Eval("SupplierId")) %>'>
                                    <img title="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" /></a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" />
        </telerik:RadGrid>
    </div>
    <%--<telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSupplierList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgSupplierList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSupplierList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
