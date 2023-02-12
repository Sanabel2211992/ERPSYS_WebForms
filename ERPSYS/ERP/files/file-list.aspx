<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="file-list.aspx.cs" Inherits="ERPSYS.ERP.files.FileList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearFields() {
            $('#<%= txtDescription.ClientID %>').val("");
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset class="fs-search">
        <legend class="fs-search-legend">Search Criteria</legend>
        <table class="tbl-search" style="width: 600px">
            <tr>
                <th class="ft-search" style="width: 125px"></th>
                <th class="fv-search" style="width: 175px"></th>
                <th class="ft-search" style="width: 125px"></th>
                <th class="fv-search" style="width: 175px"></th>
            </tr>
            <tr>
                <td class="ft-search">File Description :</td>
                <td class="fv-search" colspan="3">
                    <asp:TextBox ID="txtDescription" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn-search" OnClientClick="ClearFields(); return false;" />
                </td>
            </tr>
        </table>
    </fieldset>
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" OnClick="lnkbtnAdd_Click" CssClass="lnkbtn-add" runat="server">Add New File </asp:LinkButton>
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
                            <telerik:RadGrid ID="rgFileList" runat="server" RenderMode="Lightweight" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnNeedDataSource="rgFile_NeedDataSource" OnInit="rgFile_Init">
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
                                        <telerik:GridBoundColumn DataField="FileId" HeaderText="ID" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ActualFileName" HeaderText="File Name" HeaderStyle-Width="450px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="File Description" HeaderStyle-Width="250px" />
                                        <telerik:GridBoundColumn DataField="Size" HeaderText="File Size" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="DisplayName" HeaderText="Uploaded By" HeaderStyle-Width="150px" />
                                        <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Uploaded On" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="IsPrivate" Display="False" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <img height="16" width="16" runat="server" title='<%# Eval("IsPrivate").ToString() == "True" ? "Private" : "Public" %>' src='<%# Eval("IsPrivate").ToString() == "True" ? "../resources/images/ico_private.ico" : "../resources/images/ico_public.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <asp:LinkButton ID="lnkbtnDownloadDisk" OnClick="DownloadFileDisk" runat="server" CommandArgument='<%# Eval("FileId") %>'>
                                                         <img  src="../resources/images/ico_download_16x16_3.png" title="Download" height="16" width="16" />
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <asp:HyperLink runat="Server" ID="hlLink" NavigateUrl='<%# "~/Files/TempUpload/" + Eval("ActualFileName")  %>'>
                                                       <img  src="../resources/images/ico_download_16x16.png" title="Download" height="16" width="16" />
                                                    </asp:HyperLink>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="DBColumn" HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <asp:LinkButton ID="lnkbtnDownloadDb" OnClick="DownloadFileDb" runat="server" CommandArgument='<%# Eval("FileId") %>'>
                                                         <img  src="../resources/images/ico_download_16x16_3.png" title="Download" height="16" width="16" />
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("file-delete.aspx?id={0}", Eval("FileId")) %>'>
                                                        <img title="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
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
    <%-- <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgFileList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
