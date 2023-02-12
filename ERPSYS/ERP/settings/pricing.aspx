<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="pricing.aspx.cs" Inherits="ERPSYS.ERP.settings.Pricing" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">System Currency Information</legend>
                    <table class="tbl-view" style="width: 600px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Default Currency : </td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblDefaultCurrency" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="sec-title">Currency Exchange Rate </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgCurrencyRate" AutoGenerateColumns="False" Width="100%" ShowFooter="True" runat="server" AllowPaging="True" OnNeedDataSource="rgCurrencyRate_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CurrencyId" HeaderText="ID" HeaderStyle-Width="25px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="code" HeaderText="Code" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="ExchangeRate" HeaderText="Exchange Rate" DataFormatString="{0:F5}" HeaderStyle-Width="150px" />
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("exchange-rate-form.aspx?o=edit&id={0}", Eval("CurrencyId")) %>'>
                                                        <img alt="Edit" width="12" height="12" title="Edit" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
