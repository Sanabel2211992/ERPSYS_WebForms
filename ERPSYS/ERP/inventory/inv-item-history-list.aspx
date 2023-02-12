<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="inv-item-history-list.aspx.cs" Inherits="ERPSYS.ERP.inventory.InventoryItemHistoryList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            ClearDate();
            $('#<%= txtDescription.ClientID %>').val("");
            $('#<%= txtItemCode.ClientID %>').val("");
            $('#<%= txtPartNumber.ClientID %>').val("");
            $('#<%= ddlLocation.ClientID %>').val("-1");
        }

        function doCustomValidate(source, args) {
            args.IsValid = false;
            if (document.getElementById('<% =txtDescription.ClientID %>').value.length > 0) {
                args.IsValid = true;
            }
            if (document.getElementById('<% =txtItemCode.ClientID %>').value.length > 0) {
                args.IsValid = true;
            }
            if (document.getElementById('<% =txtPartNumber.ClientID %>').value.length > 0) {
                args.IsValid = true;
            }
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
                            <td class="grid-note" colspan="2">
                                <div class="date-note-po date-note">
                                    * Default period is one week ago
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Description :</td>
                            <td class="ft-search" colspan="5">
                                <asp:TextBox ID="txtDescription" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Catalog Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search">Part Number :</td>
                            <td class="fv-search">
                                <asp:TextBox ID="txtPartNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td class="ft-search">Location :</td>
                            <td class="fv-search">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-search" colspan="2">
                                <asp:CustomValidator ID="cvSearch" runat="server" ErrorMessage="have to fill at least 1 field" ControlToValidate="txtDescription" ValidationGroup="search"
                                    ClientValidationFunction="doCustomValidate" CssClass="val-error" ValidateEmptyText="true"></asp:CustomValidator>
                            </td>
                            <td class="ft-search"></td>
                            <td class="fv-search"></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" ValidationGroup="search" />
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
                <telerik:RadToolBarButton runat="server" CommandName="export" OuterCssClass="pull-right" Value="export" ToolTip="Export Excel" ImageUrl="~/ERP/resources/images/toolbar/ico_excel_20_20.png" Width="22px" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="grid-container no-bg">
        <telerik:RadGrid ID="rgInvItemHistoryList" RenderMode="Lightweight" runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="true" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgInvItemHistoryList_NeedDataSource" OnInit="rgInvItemHistoryList_Init">
            <MasterTableView ShowHeadersWhenNoRecords="true">
                <NoRecordsTemplate>
                    <table style="width: 100%" class="rgEmptyData">
                        <tr>
                            <td>No Data Found</td>
                        </tr>
                    </table>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="150px" />
                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="200px" />
                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="450px" />
                    <telerik:GridDateTimeColumn DataField="LogDate" HeaderText="Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                    <telerik:GridBoundColumn DataField="Location" HeaderText="Location" HeaderStyle-Width="125px" />
                    <telerik:GridBoundColumn DataField="UOM" HeaderText="Unit" HeaderStyle-Width="50px" />
                    <telerik:GridBoundColumn DataField="UnitCost" HeaderText="Unit Cost" UniqueName="Cost" HeaderStyle-Width="100px" DataFormatString="{0:F2}" Visible="false" />
                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
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
                    <telerik:AjaxUpdatedControl ControlID="rgInvItemHistoryList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgInvItemHistoryList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgInvItemHistoryList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
