<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="ContextMenu.aspx.cs" Inherits="ERPSYS.ERP.t.Grid.ContextMenu" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadGrid ID="rgUserList" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
        AllowPaging="True" PagerStyle-AlwaysVisible="True" 
        EnableHeaderContextMenu="true" EnableHeaderContextFilterMenu="true"
        OnNeedDataSource="rgUserList_NeedDataSource" OnInit="rgUserList_Init" OnPreRender="rgUserList_PreRender">
        <MasterTableView ShowHeadersWhenNoRecords="true">
            <NoRecordsTemplate>
                <table class="rgEmptyData">
                    <tr>
                        <td>No Data Found</td>
                    </tr>
                </table>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridBoundColumn UniqueName="UserId" DataField="UserId" HeaderText="ID" Display="False" />
                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                    <ItemTemplate>
                        <%#  Container.DataSetIndex + 1%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn UniqueName="DisplayName" DataField="DisplayName" HeaderText="Display Name" HeaderStyle-Width="100px" />
                <telerik:GridBoundColumn UniqueName="UserName" DataField="UserName" HeaderText="User Name" HeaderStyle-Width="150px" />
                <telerik:GridBoundColumn UniqueName="Role" DataField="Role" HeaderText="Role" HeaderStyle-Width="150px" />
                <telerik:GridBoundColumn UniqueName="Department" DataField="Department" HeaderText="Department" HeaderStyle-Width="150px" />
                <telerik:GridTemplateColumn UniqueName="Permissions" HeaderText="Permissions" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <div>
                            <a>Update</a>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Reset Password" HeaderStyle-Width="175px">
                    <ItemTemplate>
                        <div>
                            <a>Reset Password</a>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Edit" HeaderStyle-Width="25px">
                    <ItemTemplate>
                        <div>
                            <img alt="Edit" width="12" height="12" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Delete" HeaderStyle-Width="25px">
                    <ItemTemplate>
                        <div>
                            <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
