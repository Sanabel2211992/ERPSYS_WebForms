<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="proj-list.aspx.cs" Inherits="ERPSYS.ERP.proj.ProjList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/Date/UCDateRange.ascx" TagName="UCDateRange" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            ClearDate();
            $('#<%= txtProjectName.ClientID %>').val("");
            $('#<%= ddlProjectStatus.ClientID %>').val("-1");
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
<%--    <telerik:RadNotification ID="rnMessage3333" runat="server" RenderMode="Lightweight" Skin="WebBlue"
    Overlay="false"
    VisibleOnPageLoad="true"
    Animation="Fade"
    EnableRoundedCorners="True"
    EnableShadow="True"
    AutoCloseDelay="2000"
    Position="BottomRight"
    ShowCloseButton="True"
    OffsetX="-78" OffsetY="-480" 
    Height="80px" Width="600px" ShowTitleMenu="false"
    Text="updated successfully." BackColor="Green" ContentIcon="ok" TitleIcon="ok"/>--%>
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
                                <uc1:UCDateRange ID="UCDateRange" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Project Name :</td>
                            <td class="fv-search" colspan="5">
                                <asp:TextBox ID="txtProjectName" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-search">Status :</td>
                            <td class="fv-search" colspan="5">
                                <asp:DropDownList ID="ddlProjectStatus" runat="server" Width="150px"></asp:DropDownList>
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
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Project</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgProjectList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" AutoGenerateColumns="False"
                                OnNeedDataSource="rgProjectList_NeedDataSource" OnInit="rgProjectList_Init" OnItemDataBound="rgProjectList_ItemDataBound">
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
                                        <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" HeaderStyle-Width="25px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("proj-preview.aspx?id={0}", Eval("ProjectId")) %>'>
                                                        <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Project Details" style="border: 0" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Project Name" HeaderStyle-Width="400px" />
                                        <telerik:GridDateTimeColumn DataField="StartDate" HeaderText="Start Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                        <telerik:GridDateTimeColumn DataField="EndDate" HeaderText="End Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Prepared By" HeaderStyle-Width="125px" />
                                        <telerik:GridBoundColumn DataField="StatusId" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="125px">
                                            <HeaderStyle Width="125px"></HeaderStyle>
                                            <ItemTemplate>
                                                <div>
                                                    <asp:Image ID="imgStatus" runat="server" Height="13px" Width="13px" />
                                                    <span><%#  Eval("ProjectStatus") %></span>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("proj-form.aspx?o=edit&id={0}", Eval("ProjectId")) %>'>
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
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProjectList" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgProjectList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProjectList" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
