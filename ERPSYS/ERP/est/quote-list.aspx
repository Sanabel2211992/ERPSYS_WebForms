<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-list.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Window/Common/UCCustomer.ascx" TagName="UCCustomer" TagPrefix="uc2" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function OnCustomerClosefun(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var displaycustomername = arg.name;
                $('#<%= txtCustomerName.ClientID %>').val(displaycustomername);
            }
        }
        function ClearFields() {
            ClearDate();
            $('#<%= txtCustomerName.ClientID %>').val("");
            $('#<%= txtQuoteNumber.ClientID %>').val("");
            $('#<%= ddlQuoteStatus.ClientID %>').val("-1");
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
                            <td class="ft-search">Customer Name :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtCustomerName" runat="server" Width="350px"></asp:TextBox>
                                <uc2:UCCustomer ID="WinCustomer" runat="server" />
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Quote # :</td>
                            <td class="fv-search" colspan="3">
                                <asp:TextBox ID="txtQuoteNumber" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Quote Status :</td>
                            <td class="fv-search" colspan="3">
                                <asp:DropDownList ID="ddlQuoteStatus" runat="server" Width="150px"></asp:DropDownList>
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
    </table>
    <div>
        <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
            <Items>
                <telerik:RadToolBarButton runat="server" CommandName="add" Text="Create Sales Quote" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="140px" />
                <telerik:RadToolBarButton runat="server" CommandName="export" OuterCssClass="pull-right" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgQuoteList" runat="server" RenderMode="Lightweight" ShowFooter="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnNeedDataSource="rgQuoteList_NeedDataSource" OnInit="rgQuoteList_Init" OnItemDataBound="rgQuoteList_ItemDataBound">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table class="rgEmptyData">
                        <tr>
                            <td>No Data Found</td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="QuoteId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("quote-preview.aspx?id={0}", Eval("QuoteId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="View" title="View" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Sales Quote #" HeaderStyle-Width="150px">
                        <ItemTemplate>
                            <div>
                                <a class="grdlink" href='<%# string.Format("quote-preview.aspx?id={0}", Eval("QuoteId")) %>'><%# Eval("QuoteNumber") %></a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CustomerName" HeaderText="Customer Name" HeaderStyle-Width="350px" />
                    <telerik:GridBoundColumn DataField="ProjectName" HeaderText="Project Name" HeaderStyle-Width="250px" />
                    <telerik:GridDateTimeColumn DataField="QuoteDate" HeaderText="Quote Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="SalesEngineer" HeaderText="Engineer Name" HeaderStyle-Width="175px" />
                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                    <telerik:GridBoundColumn DataField="StatusQuote" Display="False" />
                    <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                        <HeaderStyle Width="25px"></HeaderStyle>
                        <ItemTemplate>
                            <div>
                                <asp:Image ID="imgStatus" runat="server" Height="13px" Width="13px" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" />
        </telerik:RadGrid>
    </div>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuoteList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgQuoteList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuoteList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
