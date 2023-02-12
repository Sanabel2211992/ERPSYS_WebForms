<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="email-template-type-list.aspx.cs" Inherits="ERPSYS.ERP.settings.EmailTemplateTypeList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgEmailTemplateType" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" OnInit="rgEmailTemplateType_Init" OnNeedDataSource="rgEmailTemplateType_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No Data Found</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="TemplateTypeId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                        <telerik:GridHyperLinkColumn SortExpression="Name" DataTextFormatString="{0}" ItemStyle-CssClass="grdlink"
                                            DataNavigateUrlFields="TemplateTypeId" UniqueName="Name" DataNavigateUrlFormatString="email-template-list.aspx?tid={0}"
                                            HeaderText="Type" DataTextField="Name" HeaderStyle-Width="250px">
                                        </telerik:GridHyperLinkColumn>
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="300px" />
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
