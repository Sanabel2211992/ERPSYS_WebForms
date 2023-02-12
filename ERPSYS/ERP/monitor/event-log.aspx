<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="event-log.aspx.cs" Inherits="ERPSYS.ERP.monitor.EventLog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRangeSys" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRangeDB" TagPrefix="uc2" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div>
        <telerik:RadTabStrip ID="rtsEventLog" runat="server" RenderMode="Lightweight" MultiPageID="rmpEventLog" Width="100%" AutoPostBack="True" SelectedIndex="0" Align="Left" Skin="MetroTouch">
            <Tabs>
                <telerik:RadTab PageViewID="rpvSystemLog" Text="System" Selected="True" />
                <telerik:RadTab PageViewID="rpvFileLog" Text="Files" />
                <telerik:RadTab PageViewID="rpvDatabaseLog" Text="Database" />
            </Tabs>
        </telerik:RadTabStrip>
    </div>
    <div>
        <telerik:RadMultiPage ID="rmpEventLog" runat="server" RenderSelectedPageOnly="True" Width="100%" SelectedIndex="0">
            <telerik:RadPageView ID="rpvSystemLog" runat="server" Selected="true">
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
                                        <td class="fv-search" colspan="5">
                                            <uc1:UCDateRangeSys ID="UCDateRangeSys" runat="server" />
                                            <div class="date-note-po date-note">
                                                * Default period is one week ago
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ft-search">Log Type :</td>
                                        <td class="fv-search" colspan="5">
                                            <asp:DropDownList ID="ddlSystemLogType" runat="server" Width="150">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Button ID="btnSearchSystem" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearchSystem_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgEventLogSystem" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False"
                                            OnInit="rgEventLogSystem_Init" OnNeedDataSource="rgEventLogSystem_NeedDataSource" OnItemDataBound="rgEventLogSystem_ItemDataBound">
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
                                                    <telerik:GridBoundColumn DataField="ErrorId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                                    <telerik:GridBoundColumn DataField="EventId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="Level" HeaderText="Level" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="Date" HeaderText="Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="IPAddress" HeaderText="IP Address" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="Exception" HeaderText="Details" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="UserName" HeaderText="UserName" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="Message" HeaderText="Message" HeaderStyle-Width="450px" />
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvFileLog" runat="server">
                <table class="tbl-main">
                    <tr>
                        <td>
                            <fieldset class="fs-search">
                                <legend class="fs-search-legend">Search Criteria</legend>
                                <table class="tbl-search" style="width: 600px">
                                    <tr>
                                        <td class="ft-search" style="width: 125px"></td>
                                        <td class="fv-search" style="width: 175px"></td>
                                        <td class="ft-search" style="width: 125px"></td>
                                        <td class="fv-search" style="width: 175px"></td>
                                    </tr>
                                    <tr>
                                        <td class="ft-search">File Name :
                                        </td>
                                        <td class="fv-search">
                                            <asp:DropDownList ID="ddlLogFiles" runat="server" Width="150"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLogFiles" runat="server" ControlToValidate="ddlLogFiles" InitialValue=""
                                                ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="ft-search"></td>
                                        <td class="fv-search"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Button runat="server" ID="btnReadFile" Text="Search" CssClass="btn-search" OnClick="btnReadFile_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLog" runat="server" Height="570" Width="1200" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="rpvDatabaseLog" runat="server">
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
                                        <td class="fv-search" colspan="5">
                                            <uc2:UCDateRangeDB ID="UCDateRangeDB" runat="server" />
                                            <div class="date-note-po date-note">
                                                * Default period is one week ago
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Button ID="btnSearchDB" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearchDB_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="tbl-grid">
                                <tr>
                                    <td>
                                        <telerik:RadGrid ID="rgEventLogDB" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnInit="rgEventLogDB_Init" OnNeedDataSource="rgEventLogDB_NeedDataSource">
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
                                                    <telerik:GridBoundColumn DataField="ErrorId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                        <ItemTemplate>
                                                            <%#  Container.DataSetIndex + 1%>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="ErrorDate" HeaderText="Date" HeaderStyle-Width="145px" />
                                                    <telerik:GridBoundColumn DataField="SPName" HeaderText="SP Name" HeaderStyle-Width="200px" />
                                                    <telerik:GridBoundColumn DataField="ErrorLine" HeaderText="Line #" HeaderStyle-Width="100px" />
                                                    <telerik:GridBoundColumn DataField="ErrorMessage" HeaderText="Message" HeaderStyle-Width="500px" />
                                                    <telerik:GridBoundColumn DataField="DisplayName" HeaderText="UserName" HeaderStyle-Width="100px" />
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsEventLog">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsEventLog" />
                    <telerik:AjaxUpdatedControl ControlID="rmpEventLog" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
