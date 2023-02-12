<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="user-permission.aspx.cs" Inherits="ERPSYS.ERP.lab.user_permission" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <style>
        .ad-left {
            float: left;
            width: 675px;
        }

        .ad-right {
            float: right;
            margin-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">User Information</legend>
                    <table class="tbl-view" style="width: 1160px">
                        <tr>
                            <th class="ft-view" style="width: 170px"></th>
                            <th class="fv-view" style="width: 120px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Display Name :</td>
                            <td class="fv-view" colspan="2">
                                <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Username :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">User Title :</td>
                            <td class="fv-view" colspan="2">
                                <asp:Label ID="lblUserTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="ad-left">
                    <fieldset class="fs-view">
                        <legend class="fs-view-legend">Customiaz Permissions</legend>
                        <table>
                            <tr>
                                <td>Page Category :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Check Operation : 
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblstOperation" runat="server" RepeatDirection="Horizontal" Width="450px" AutoPostBack="true" OnSelectedIndexChanged="rblstOperation_SelectedIndexChanged">
                                        <asp:ListItem>View Only</asp:ListItem>
                                        <asp:ListItem>Add</asp:ListItem>
                                        <asp:ListItem>Update</asp:ListItem>
                                        <asp:ListItem> Update & Insert</asp:ListItem>
                                        <asp:ListItem>Delete</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="rgPermissionsList" runat="server" AllowPaging="False" AllowSorting="False" ShowFooter="false" AutoGenerateColumns="False" Width="600" PageSize="10"
                                        OnNeedDataSource="rgPermissionsList_NeedDataSource" OnItemDataBound="rgPermissionsList_ItemDataBound">
                                        <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="PageId">
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
                                                        <asp:CheckBox ID="cbPage" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cbAllPages" runat="server" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" />
                                                    </HeaderTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="PageId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                                                <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Name" HeaderStyle-Width="300px" />
                                                <telerik:GridBoundColumn DataField="ViewOnly" Display="False" />
                                                <telerik:GridTemplateColumn HeaderStyle-Width="50px" HeaderText="View">
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:Image ID="imgView" runat="server" Height="10px" Width="10px" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HasInsertOperation" Display="False" />
                                                <telerik:GridTemplateColumn HeaderStyle-Width="50px" HeaderText="Add">
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:Image ID="imgInsert" runat="server" Height="10px" Width="10px" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HasUpdateOperation" Display="False" />
                                                <telerik:GridTemplateColumn HeaderStyle-Width="50px" HeaderText="Update">
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:Image ID="imgUpdate" runat="server" Height="10px" Width="10px" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="HasDeleteOperation" Display="False" />
                                                <telerik:GridTemplateColumn HeaderStyle-Width="50px" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:Image ID="imgDelete" runat="server" Height="10px" Width="10px" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" SaveScrollPosition="true" UseStaticHeaders="True"></Scrolling>
                                            <%--                <ClientEvents OnRowMouseOver="RowMouseOver" />--%>
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                            <tr>
                                <td class="sec-title" colspan="2">Permission To view Items Cost</td>
                            </tr>
                            <tr>
                                <td class="fv-view" colspan="2">
                                    <asp:CheckBox ID="cbViewCost" Text="View Cost" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <div style="position: absolute;top: 620px; left: 510px;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Permissions ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </div>
                    </fieldset>
                </div>
                <div class="ad-right">


                    <fieldset class="fs-view">
                        <legend class="fs-view-legend">Clone Permissions From User</legend>
                        <table>
                            <tr>
                                <td style="width: 120px">User Name :</td>
                                <td>
                                    <asp:DropDownList ID="ddlUsersNames" runat="server" Width="180px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSaveFromUserPermission" runat="server" Text="Save" CssClass="btn-save"
                                        OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to clone the user permission?'); } else return;};"
                                        OnClick="btnSaveFromUserPermission_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fs-view">
                        <legend class="fs-view-legend">Choose Permissions From Group</legend>
                        <table>
                            <tr>
                                <td style="width: 120px">Group Name :</td>
                                <td>
                                    <asp:DropDownList ID="ddlGroupPermission" runat="server" Width="180px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSaveGroupPermission" runat="server" Text="Save" CssClass="btn-save"
                                        OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you ?'); } else return;};"
                                        OnClick="btnSaveGroupPermission_Click" /></td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>

    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rblstOperation">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPermissionsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgPermissionsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
