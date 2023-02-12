<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="transfer-list.aspx.cs" Inherits="ERPSYS.ERP.inventory.TransferList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtTransferNumber.ClientID %>').val("");
            $('#<%= txtJobOrderNumber.ClientID %>').val("");
            $('#<%= ddlTransferStatus.ClientID %>').val("-1");
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
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                            <th class="ft-search" style="width: 100px"></th>
                            <th class="fv-search" style="width: 200px"></th>
                        </tr>
                        <tr>
                            <td class="ft-search">Transfer No :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtTransferNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Job Order No :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtJobOrderNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Status :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlTransferStatus" runat="server" Width="150px"></asp:DropDownList>
                            </td>
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
                <telerik:RadToolBarButton runat="server" CommandName="add" Text="Create Stock Transfer" ImageUrl="~/ERP/resources/images/toolbar/ico_new.png" Width="160px" />
                <telerik:RadToolBarButton runat="server" CommandName="export" OuterCssClass="pull-right" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgTransferList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnNeedDataSource="rgTransferList_NeedDataSource" OnInit="rgTransferList_Init" OnItemDataBound="rgTransferList_ItemDataBound">
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
                    <telerik:GridBoundColumn DataField="TransferId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <%#  Container.DataSetIndex + 1%>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                        <ItemTemplate>
                            <div>
                                <a href='<%# string.Format("transfer-preview.aspx?id={0}", Eval("TransferId")) %>'>
                                    <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Purchase Order" style="border: 0" />
                                </a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Transfer #" HeaderStyle-Width="125px">
                        <ItemTemplate>
                            <div>
                                <a class="grdlink" href='<%# string.Format("transfer-preview.aspx?id={0}", Eval("TransferId")) %>'><%# Eval("TransferNumber") %></a>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="JobOrderNumber" HeaderText="Job Order #" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="FromLocation" HeaderText="From Stock" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="ToLocation" HeaderText="To Stock" HeaderStyle-Width="125px" />
                    <telerik:GridDateTimeColumn DataField="TransferDate" HeaderText="Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="PostedUserName" HeaderText="Posted By" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                    <telerik:GridBoundColumn DataField="TransferStatus" Display="False" />
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
    <%--<telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTransferList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgTransferList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTransferList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
