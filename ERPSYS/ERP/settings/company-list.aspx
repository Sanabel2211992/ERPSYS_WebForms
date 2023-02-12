<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="company-list.aspx.cs" Inherits="ERPSYS.ERP.settings.CompanyList" %>

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
                            <telerik:RadGrid ID="rgCompanyList" runat="server" RenderMode="Lightweight" AllowPaging="False" ShowFooter="true" AutoGenerateColumns="False" OnNeedDataSource="rgCompanyList_NeedDataSource">
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
                                        <telerik:GridBoundColumn DataField="CompanyId" HeaderText="ID" HeaderStyle-Width="45px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Company Name" ItemStyle-Width="300px" />
                                        <telerik:GridBoundColumn DataField="Country" HeaderText="Country" ItemStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="City" HeaderText="City" ItemStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Phone" HeaderText="Phone" ItemStyle-Width="100px" />
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
