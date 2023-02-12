<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-cat-list.aspx.cs" Inherits="ERPSYS.ERP.item.ItemCategoryList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtCategory.ClientID %>').val("");
            $('#<%= txtSubCategory.ClientID %>').val("");
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
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Main Category :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCategory" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Sub Category :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtSubCategory" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-search" OnClientClick="ClearFields(); return false;" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" CssClass="lnkbtn-add" runat="server" OnClick="lnkbtnAdd_Click">Add Category</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgCategoryList" RenderMode="Lightweight" runat="server" AllowPaging="False" ShowFooter="true" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgCategoryList_NeedDataSource" OnInit="rgCategoryList_Init">
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
                                        <telerik:GridBoundColumn DataField="CategoryId" HeaderText="Id" HeaderStyle-Width="25px" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Main Category" HeaderStyle-Width="250px" />
                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="SubCategoryList" HeaderText="Sub Category" HeaderStyle-Width="650px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("item-cat-sub-list.aspx?id={0}", Eval("CategoryId")) %>'>
                                                        <img alt="Edit" width="12" height="12" title="Subcategory List" runat="server" src="~/Controls/resources/images/grid/subcat.png" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("item-cat-form.aspx?o=edit&id={0}", Eval("CategoryId")) %>'>
                                                        <img alt="Edit" width="12" height="12" title="Edit" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("item-cat-delete.aspx?id={0}", Eval("CategoryId")) %>'>
                                                        <img alt="Delete" width="11" height="11" title="Delete" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true" />
                            </telerik:RadGrid>
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
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCategoryList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgCategoryList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCategoryList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
