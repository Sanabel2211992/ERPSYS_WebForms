<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="mail-settings-list.aspx.cs" Inherits="ERPSYS.ERP.settings.MailSettingsList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-link">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Email</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgMailSettingsList" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" OnNeedDataSource="rgMailSettingsList_NeedDataSource" OnInit="rgMailSettingsList_Init">
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
                                        <telerik:GridBoundColumn DataField="EmailId" HeaderText="ID" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="EmailName" HeaderText="Email Name" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="SenderName" HeaderText="Sender Name" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="SenderAddress" HeaderText="Email Address" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="SMTPServer" HeaderText="Mail Server" HeaderStyle-Width="175px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("mail-settings-form.aspx?o=edit&id={0}", Eval("EmailId")) %>'>
                                                        <img alt="Edit" width="12" height="12" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("mail-settings-delete.aspx?o=edit&id={0}", Eval("EmailId")) %>'>
                                                        <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
                                                    </a>
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
    <telerik:RadAjaxLoadingPanel ID="rlLoading" runat="server" Skin="Default" EnableEmbeddedSkins="False" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgMailSettingsList" UpdatePanelCssClass="" LoadingPanelID="rlLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
