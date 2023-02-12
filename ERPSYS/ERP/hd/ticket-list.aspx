<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="ticket-list.aspx.cs" Inherits="ERPSYS.ERP.hd.ticket_list" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            ClearDate();
            $('#<%= txtTicketNumber.ClientID %>').val("");
            $('#<%= ddlTicketStatus.ClientID %>').val("");
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
                            <td class="ft-search">Date Period :</td>
                            <td class="fv-search" colspan="3">
                                <uc1:UCDateRange ID="UCDateRange" runat="server" />
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Ticket # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtTicketNumber" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Ticket Status :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlTicketStatus" runat="server" Width="150px"></asp:DropDownList>
                            </td>
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
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Create New Ticket</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgTicketList" runat="server" ShowStatusBar="true" ShowFooter="false" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="True"
                    OnNeedDataSource="rgTicketList_NeedDataSource" OnInit="rgTicketList_Init" OnItemDataBound="rgTicketList_ItemDataBound">
                    <MasterTableView>
                        <NoRecordsTemplate>
                            <table class="rgEmptyData">
                                <tr>
                                    <td>No comment to display.</td>
                                </tr>
                            </table>
                        </NoRecordsTemplate>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                <ItemTemplate>
                                    <%#  Container.DataSetIndex + 1%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="TicketId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                            <telerik:GridTemplateColumn HeaderStyle-Width="30px">
                                <HeaderStyle Width="30px"></HeaderStyle>
                                <ItemTemplate>
                                    <div>
                                        <asp:Image ID="imgUser" CssClass="user-pic" runat="server" ImageUrl="~/ERP/resources/images/default-profile.png" Height="30px" Width="30px" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EntryUserId" Display="false" />
                            <telerik:GridBoundColumn DataField="DisplayName" HeaderStyle-Width="125px" />
                            <%--                            <telerik:GridTemplateColumn HeaderText="Ticket #" HeaderStyle-Width="125px">
                                <ItemTemplate>
                                    <div>
                                        <a class="grdlink" href='<%# string.Format("ticket-form.aspx?id={0}", Eval("TicketId")) %>'><%# Eval("TicketNumber") %></a>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridHyperLinkColumn DataTextField="TicketNumber" HeaderStyle-Width="125px" />
                            <telerik:GridBoundColumn DataField="Subject" HeaderText="Subject" HeaderStyle-Width="550px" />
                            <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                            <telerik:GridBoundColumn DataField="TicketStatus" HeaderText="Status" HeaderStyle-Width="100px" />
                            <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTicketList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgTicketList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTicketList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

