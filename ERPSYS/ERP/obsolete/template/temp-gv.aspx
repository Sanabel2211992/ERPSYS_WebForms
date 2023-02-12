<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="temp-gv.aspx.cs" Inherits="ERPSYS.ERP.template.temp_gv" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div>
        <telerik:RadGrid ID="xx" runat="server"
            ShowFooter="true" Width="100%"
            AutoGenerateColumns="False">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table style="width: 100%" class="rgvEmptyData">
                        <tr>
                            <td>No Data Found
                            </td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="xxx" HeaderText="xxx" SortExpression="xxx" ItemStyle-Width="200px" />
                    <telerik:GridTemplateColumn HeaderText="XXX">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("x.aspx?o=update&uid={0}", Eval("x")) %>'>XXXX </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" />
        </telerik:RadGrid>
    </div>
</asp:Content>
