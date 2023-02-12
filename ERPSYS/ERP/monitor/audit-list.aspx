<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="audit-list.aspx.cs" Inherits="ERPSYS.ERP.monitor.audit_list" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            ClearDate();
            $('#<%= txtAction.ClientID %>').val("");
            $('#<%= ddlUsersNames.ClientID %>').val("");
            $('#<%= ddlAuditType.ClientID %>').val("");
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
                            <td class="ft-search">Action :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtAction" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Date Period :</td>
                            <td class="fv-search" colspan="3">
                                <uc1:UCDateRange ID="UCDateRange" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">User Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlUsersNames" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Audit Type # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlAuditType" runat="server" Width="150px">
                                    <asp:ListItem Enabled="true" Text="--All--" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Create" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="Update" Value="U"></asp:ListItem>
                                    <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                                </asp:DropDownList>
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
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgAudit" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgAudit_NeedDataSource" OnInit="rgAudit_Init">
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
                                        <telerik:GridBoundColumn DataField="AuditId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="Type" HeaderStyle-Width="125px">
                                            <ItemTemplate>
                                                <div>
                                                    <a class="grdlink" href='<%# string.Format("audit-preview.aspx?id={0}", Eval("AuditId")) %>'><%# Eval("Type") %></a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="TableName" HeaderText="Table Name" HeaderStyle-Width="200px" />
                                        <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Date & Time" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="AuditId" HeaderText="Entity" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="TableName" HeaderText="Action" HeaderStyle-Width="300px" />
                                        <telerik:GridBoundColumn DataField="EntryUser" HeaderText="User Name" HeaderStyle-Width="100px" />
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
                    <telerik:AjaxUpdatedControl ControlID="rgAudit" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgAudit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgAudit" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
