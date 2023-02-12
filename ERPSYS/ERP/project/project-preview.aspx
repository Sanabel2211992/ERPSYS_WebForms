<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="project-preview.aspx.cs" Inherits="ERPSYS.ERP.project.project_preview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Src="~/ERP/t/Projects/AddProjectFile.ascx" TagPrefix="uc1" TagName="UCAddFile" %>
<%@ Register Src="~/ERP/t/Projects/AddProjectNote.ascx" TagPrefix="uc2" TagName="UCAddNote" %>--%>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <telerik:RadScriptBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function getRadWindowProjectFile() {
                return $find("<%=rwProjectFile.ClientID%>");
            }
            function OpenDialogProjectFile() {
                getRadWindowProjectFile().show();
            }
            function closeDialogProjectFile() {
                getRadWindowProjectFile().close();
            }
            //Note
            function getRadWindowNote() {
                return $find("<%=rwNote.ClientID%>");
            }
            function OpenDialogNote() {
                $('#<%= txtProjectNote.ClientID %>').val("");
                getRadWindowNote().show();
            }
            function closeDialogNote() {
                getRadWindowNote().close();
            }
        </script>
    </telerik:RadScriptBlock>

</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Project Information:</legend>
        <table class="tbl-view" style="width: 1160px">
            <tr>
                <th class="ft-view" style="width: 120px"></th>
                <th class="fv-view" style="width: 170px"></th>
                <th class="ft-view" style="width: 120px"></th>
                <th class="fv-view" style="width: 170px"></th>
                <th class="ft-view" style="width: 120px"></th>
                <th class="fv-view" style="width: 170px"></th>
                <th class="ft-view" style="width: 120px"></th>
                <th class="fv-view" style="width: 170px"></th>
            </tr>
            <tr>
                <td class="ft-view">Project Name :</td>
                <td class="fv-view" colspan="3">
                    <asp:Label ID="lbProjectName" runat="server"></asp:Label>
                </td>
                <td class="ft-view">Owner: </td>
                <td class="fv-view" colspan="3">
                    <asp:Label ID="lbOwner" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="ft-view"></td>
                <td class="fv-view"></td>
                <td class="ft-view"></td>
                <td class="fv-view"></td>
                <td class="ft-view"></td>
                <td class="fv-view"></td>
                <td class="ft-view"></td>
                <td class="fv-view"></td>
            </tr>
        </table>
        <table class="tbl-main">
            <tr>
                <td>
                    <table class="tbl-grid">
                        <tr>
                            <td class="fv-view">
                                <asp:LinkButton ID="lbAddNewFile" runat="server" CssClass="lnkbtn-add" OnClientClick="OpenDialogProjectFile(); return false;">Add New File</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%-- <uc1:UCAddFile ID="UCAddFile" runat="server" OnFinishClickedFile="AddFile_FinishClicked" />--%>
                                <telerik:RadGrid ID="rgFilesAttList" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False"
                                    AllowSorting="True" AllowPaging="True" OnNeedDataSource="rgFilesAttList_NeedDataSource" OnInit="rgFilesAttList_Init">
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
                                            <telerik:GridBoundColumn DataField="fileName" HeaderText="File Name" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="EntryUserName" HeaderText="Uploded by" HeaderStyle-Width="75px" />
                                            <telerik:GridBoundColumn DataField="Size" HeaderText="Size" HeaderStyle-Width="75px" />
                                            <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Entry Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="150px" />
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
                                                        <asp:LinkButton ID="lnkbtnDeleteFile" runat="server" CommandArgument='<%# Eval("FileId") %>' CommandName="DeletdFile" OnClick="DeleteLinkButton_Click" CausesValidation="false">
                                                        <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tbl-grid">
                        <tr>
                            <td class="fv-view">
                                <%-- <uc2:UCAddNote ID="UCAddNote" runat="server" OnFinishClickedNote="AddNote_FinishClicked" />--%>
                                <asp:LinkButton ID="lbAddNewNote" runat="server" CssClass="lnkbtn-add" OnClientClick="OpenDialogNote(); return false;">Add New Note</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="rgNotesList" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnNeedDataSource="rgNotesList_NeedDataSource" OnInit="rgNotesList_Init">
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
                                            <telerik:GridBoundColumn DataField="NoteId" HeaderText="ID" Display="False" />
                                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                                <ItemTemplate>
                                                    <%#  Container.DataSetIndex + 1%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="NoteText" HeaderText="Text" HeaderStyle-Width="175px" />
                                            <telerik:GridBoundColumn DataField="EntryUserName" HeaderText="Added by" HeaderStyle-Width="75px" />
                                            <telerik:GridDateTimeColumn DataField="EntryDate" HeaderText="Entry Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="150px" />
                                            <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:LinkButton ID="lnkbtnDeleteNote" runat="server" CommandArgument='<%# Eval("NoteId") %>' CommandName="DeletdNote" OnClick="DeleteLinkButton_Click" CausesValidation="false">
                                                        <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
                                                        </asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="tbl-op-center" style="width: 200px">
            <tr>
                <td colspan="2">
                    <asp:Button ID="btBack" runat="server" Text="Back" CssClass="btn-op" OnClick="btBack_Click" />
                </td>
            </tr>
        </table>
    </fieldset>

    <telerik:RadWindow ID="rwProjectFile" Height="150px" Width="320px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New File">
        <ContentTemplate>
            <table class="tbl-main">
                <tr>
                    <td>
                        <asp:FileUpload ID="fuProjectFile" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUploadFile" runat="server" Text="Upload" CssClass="btn-upload" OnClick="btnUploadFile_Click" />
                        <input class="btn-save" id="btnCancelFile" type="button" value="Cancel" onclick="closeDialogProjectFile(); return false;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindow ID="rwNote" Height="180px" Width="290px" runat="server" Modal="True" Behaviors="Move, Close" IconUrl="~/ERP/t/icons/round_add.ico" Title="Add New Note">
        <ContentTemplate>
            <table class="tbl-main">
                <tr>
                    <td style="width: 250px">
                        <asp:TextBox ID="txtProjectNote" runat="server" Width="230px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProjectNote" runat="server" ErrorMessage="*" ControlToValidate="txtProjectNote"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSaveNote" runat="server" CssClass="btn-save" Text="Save" OnClick="btnSaveNote_Click" />
                        <input class="btn-save" id="btnCancelNote" type="button" value="Cancel" onclick="closeDialogNote(); return false;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>
