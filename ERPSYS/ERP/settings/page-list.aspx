<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="page-list.aspx.cs" Inherits="ERPSYS.ERP.settings.PageList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtPageName.ClientID %>').val("");
            $("#<%=ddlAccessType.ClientID%>").val("-1");
            $('#<%= ddlPageStatus.ClientID %>').val("-1");
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 900px">
                        <tr>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                            <th class="ft-search" style="width: 125px"></th>
                            <th class="fv-search" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Page Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtPageName" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Page Status : </td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlPageStatus" runat="server" Width="150px">
                                    <asp:ListItem Selected="True" Text="-- All --" Value="-1" />
                                    <asp:ListItem Text="Enabled" Value="1" />
                                    <asp:ListItem Text="Disabled" Value="0" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Access Type :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlAccessType" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td colspan="6">
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
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Page</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgPageList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="true" Width="100%" AutoGenerateColumns="False"
                                OnNeedDataSource="rgPageList_NeedDataSource" OnInit="rgPageList_Init" OnItemDataBound="rgPageList_ItemDataBound">
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
                                        <telerik:GridBoundColumn DataField="PageId" HeaderText="ID" Visible="false" ItemStyle-Width="25px" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="PageName" HeaderText="Page Name" ItemStyle-Width="275px" />
                                        <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Display Name" ItemStyle-Width="300px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" ItemStyle-Width="400px" />
                                        <telerik:GridBoundColumn DataField="AccessType" HeaderText="Access Type" ItemStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="AccessTypeId" HeaderText="AccessTypeId" Display="false" ItemStyle-Width="25px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <img title="Status" width="12" height="12" runat="server" src='<%# (bool)Eval("IsActive") ? "~/Controls/resources/images/grid/ico_active.png" : "~/Controls/resources/images/grid/ico_inactive.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("page-form.aspx?o=edit&id={0}", Eval("PageId")) %>'>
                                                        <img title="Edit" width="12" height="12" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("page-delete.aspx?id={0}", Eval("PageId")) %>'>
                                                        <img title="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" /></a>
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPageList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgPageList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPageList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
