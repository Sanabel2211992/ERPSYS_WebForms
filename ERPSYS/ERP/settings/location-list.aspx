<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="location-list.aspx.cs" Inherits="ERPSYS.ERP.settings.LocationList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Location</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgLocationList" runat="server" RenderMode="Lightweight" AllowPaging="False" ShowFooter="true" Width="100%" AutoGenerateColumns="False">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>No Data Found
                                                </td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="LocationId" HeaderText="ID" HeaderStyle-Width="25px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Store Name" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="IsReceivedGoods" HeaderText="Allow Receving Goods" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="IsDeliveryGoods" HeaderText="Allow Sell Goods" HeaderStyle-Width="110px" />
                                        <telerik:GridBoundColumn DataField="IsConsigned" HeaderText="Consigned Store" HeaderStyle-Width="110px" />
                                        <telerik:GridBoundColumn DataField="HasCost" HeaderText="Has Cost" HeaderStyle-Width="75px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <img title="Status" width="12" height="12" runat="server" src='<%# (bool)Eval("IsActive") ? "~/Controls/resources/images/grid/ico_active.png" : "~/Controls/resources/images/grid/ico_inactive.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("location-form.aspx?o=edit&id={0}", Eval("LocationId")) %>'>
                                                        <img alt="Edit" width="12" height="12" title="Edit" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
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
</asp:Content>

