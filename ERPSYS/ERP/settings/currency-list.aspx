<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="currency-list.aspx.cs" Inherits="ERPSYS.ERP.settings.CurrencyList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-search">
                    <legend class="fs-search-legend">Search Criteria</legend>
                    <table class="tbl-search" style="width: 350px">
                        <tr>
                            <th class="ft-search" style="width: 150px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Currency Code :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCurrencyCode" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
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
                            <asp:LinkButton ID="lnkbtnAdd" CssClass="lnkbtn-add" runat="server" OnClick="lnkbtnAdd_Click">Add New Currency</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgCurrencyList" runat="server" RenderMode="Lightweight" AllowPaging="False" ShowFooter="true" AutoGenerateColumns="False" OnNeedDataSource="rgCurrencyList_NeedDataSource" OnInit="rgCurrencyList_Init">
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
                                        <telerik:GridBoundColumn DataField="CurrencyId" HeaderText="CurrencyId" Visible="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Code" HeaderText="Code" ItemStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" ItemStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Symbol" HeaderText="Symbol" ItemStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="DecimalPlaces" HeaderText="Decimal Places" ItemStyle-Width="150px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <img title="Status" width="12" height="12" runat="server" src='<%# (bool)Eval("IsActive") ? "~/Controls/resources/images/grid/ico_active.png" : "~/Controls/resources/images/grid/ico_inactive.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("currency-form.aspx?o=edit&id={0}", Eval("CurrencyId")) %>'>
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="ramCurrency" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCurrencyList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgCurrencyList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCurrencyList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
