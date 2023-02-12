<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="project-list.aspx.cs" Inherits="ERPSYS.ERP.project.project_list" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Search Criteria</legend>
        <table class="tbl-inner" style="width: 600px">
            <tr>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
            </tr>
            <tr>
                <td class="field-title">Project Name :</td>
                <td class="field-val" colspan="3">
                    <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" /></td>
            </tr>
        </table>
    </fieldset>
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" OnClick="lnkbtnAdd_Click" CssClass="lnkbtn-add" runat="server">Add New Project</asp:LinkButton>
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
                            <telerik:RadGrid ID="rgProjectsList" runat="server" RenderMode="Lightweight" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnNeedDataSource="rgProject_NeedDataSource" OnInit="rgProject_Init">
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
                                        <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("project-preview.aspx?id={0}", Eval("ProjectId")) %>'>
                                                        <img src="../../Controls/resources/images/ico_search_16_16.gif" alt="Item Details" style="border: 0" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ProjectName" HeaderText="Project Name" HeaderStyle-Width="450px" />
                                        <telerik:GridBoundColumn DataField="Owner" HeaderText="Owner" HeaderStyle-Width="250px" />
                                        <telerik:GridBoundColumn DataField="UserName" HeaderText="Uploaded By" HeaderStyle-Width="100px" />
                                        <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Entry Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="150px" />
                                        <%-- <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("file-delete.aspx?id={0}", Eval("FileId")) %>'>
                                                        <img title="Delete" height="16" width="16" runat="server" src="../resources/images/ico_delete_16x16.ico" onclick="return confirm('Are you sure ?');" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
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
                    <telerik:AjaxUpdatedControl ControlID="rgProjectsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="rgProjectsList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProjectsList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
