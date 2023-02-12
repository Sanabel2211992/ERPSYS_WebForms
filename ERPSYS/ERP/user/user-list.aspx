<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="user-list.aspx.cs" Inherits="ERPSYS.ERP.user.UserList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtName.ClientID %>').val("");
            $('#<%= ddlDepartment.ClientID %>').val("-1");
            $('#<%= ddlDepartment.ClientID %>').val("-1");
            $('#<%= ddlLocation.ClientID %>').val("-1");
            $('#<%= ddlStatus.ClientID %>').val("-1");
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
                            <td class="ft-search">User Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtName" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Department :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-search">Location :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Status :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="150px">
                                    <asp:ListItem Selected="True" Value="-1">-- All --</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
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
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New User</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgUserList" runat="server" RenderMode="Lightweight" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PagerStyle-AlwaysVisible="True" OnNeedDataSource="rgUserList_NeedDataSource" OnInit="rgUserList_Init" OnItemDataBound="rgUserList_ItemDataBound">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No Data Found</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="UserId" HeaderText="ID" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="30px">
                                            <ItemTemplate>
                                                <div>
                                                    <asp:Image ID="imgUser" CssClass="user-pic" runat="server" Height="30px" Width="30px" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Display Name" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="UserName" HeaderText="User Name" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Role" HeaderText="Role" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Department" HeaderText="Department" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="UserStatus" Visible="false" />
                                        <telerik:GridBoundColumn DataField="Location" HeaderText="Location" HeaderStyle-Width="150px" />
                                        <telerik:GridTemplateColumn HeaderText="Permissions" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("user-permission.aspx?id={0}", Eval("UserId")) %>'>Update</a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="175px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("user-pass-reset.aspx?id={0}", Eval("UserId")) %>'>Reset Password</a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <img title='<%# Eval("UserStatus") %>' alt='<%# Eval("UserStatus") %>' width="12" height="12" runat="server" src='<%# (bool)Eval("IsActive") ? "~/Controls/resources/images/grid/ico_active.png" : "~/Controls/resources/images/grid/ico_inactive.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("user-details.aspx?o=edit&id={0}", Eval("UserId")) %>'>
                                                        <img alt="Edit" width="12" height="12" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("user-delete.aspx?id={0}", Eval("UserId")) %>'>
                                                        <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgUserList" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
