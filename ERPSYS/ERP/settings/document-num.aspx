<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="document-num.aspx.cs" Inherits="ERPSYS.ERP.settings.DocumentNum" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgDocumentsFormat" runat="server" RenderMode="Lightweight" ShowFooter="true" Width="99%" AutoGenerateColumns="False" OnNeedDataSource="rgDocumentsFormat_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="DocTypeId" Display="False" />
                                        <telerik:GridBoundColumn DataField="DocNoFormatId" HeaderText="ID" HeaderStyle-Width="25px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Doc Name" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="NextNumber" HeaderText="Next Number" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="MinDigits" HeaderText="Min Digits" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Prefix" HeaderText="Prefix" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="Suffix" HeaderText="Suffix" HeaderStyle-Width="100px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("document-num-form.aspx?o=edit&id={0}", Eval("DocTypeId"))%>'>
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
            <telerik:AjaxSetting AjaxControlID="rgDocumentsFormat">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgDocumentsFormat" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

