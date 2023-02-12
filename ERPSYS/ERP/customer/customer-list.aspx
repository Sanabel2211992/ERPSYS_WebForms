<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="customer-list.aspx.cs" Inherits="ERPSYS.ERP.customer.CustomerList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtName.ClientID %>').val("");
            $('#<%= txtContactName.ClientID %>').val("");
            $('#<%= txtCountry.ClientID %>').val("");
            $('#<%= txtCity.ClientID %>').val("");
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
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search" style="width: 125px">Customer Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtName" runat="server" Width="440px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search" style="width: 125px">Contact Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtContactName" runat="server" Width="440px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Country :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">City :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtCity" runat="server" Width="145px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search" colspan="4">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-search" OnClientClick="ClearFields(); return false;" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <div>
        <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="add" Text="Add New Customer" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="140px" />
                <telerik:RadToolBarButton runat="server" CommandName="export" Value="export" OuterCssClass="pull-right" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgCustomerList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgCustomerList_NeedDataSource" OnInit="rgCustomerList_Init">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table style="width: 100%" class="rgEmptyData">
                        <tr>
                            <td>No Data Found
                            </td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1 %>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CustomerId" HeaderText="ID" HeaderStyle-Width="45px" Display="false" />
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <a href='<%#string.Format("customer-view.aspx?o=edit&id={0}", Eval("CustomerId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Item Details" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" HeaderStyle-Width="352.5px" />
                    <telerik:GridBoundColumn DataField="NameAr" HeaderText="Arabic Name" HeaderStyle-Width="352.5px" />
                    <telerik:GridBoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="City" HeaderText="City" HeaderStyle-Width="75px" />
                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" />
        </telerik:RadGrid>
    </div>
    <%--<telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCustomerList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgCustomerList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgCustomerList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
