<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="active-session.aspx.cs" Inherits="ERPSYS.ERP.monitor.ActiveSession" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Search Criteria</legend>
                    <table class="tbl-inner" style="width: 600px">
                        <tr>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
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
                        <td>Online Users :  
                            <asp:Label ID="lblOnlineUserCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgActiveSession" runat="server" ShowFooter="true" AllowPaging="False" AllowSorting="False" Width="100%" AutoGenerateColumns="False">
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
                                        <telerik:GridBoundColumn DataField="SessionStart" HeaderText="Session Start" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="SessionRenew" HeaderText="Session Renew" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="UserName" HeaderText="UserName" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Display Name" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="IPAddress" HeaderText="IP Address" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="MacAddress" HeaderText="Mac Address" ItemStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="RoleName" HeaderText="Role Name" />
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgActiveSession2" runat="server">
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgActiveSession3" runat="server">
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

