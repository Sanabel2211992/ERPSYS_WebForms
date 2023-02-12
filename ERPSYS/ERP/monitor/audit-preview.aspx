<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="audit-preview.aspx.cs" Inherits="ERPSYS.ERP.monitor.audit_preview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
<tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Audit Information</legend>
                    <table class="tbl-view" style="width: 1080px">
                        <tr>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Audit Type :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblType" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Table Name :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTableName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Audit Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblAuditDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Entity :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblEntity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Action :</td>
                            <td class="fv-view" colspan="2">
                                <asp:Label ID="lblAction" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">User Name:</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
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
                            <telerik:RadGrid ID="rgAudit" runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgAudit_NeedDataSource" OnInit="rgAudit_Init">
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
                                        <telerik:GridBoundColumn DataField="AuditLineId" HeaderText="ID" HeaderStyle-Width="50px" Visible="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Type" HeaderText="Type" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="TableName" HeaderText="Table Name" HeaderStyle-Width="200px" />
                                        <telerik:GridBoundColumn DataField="PK" HeaderText="PK" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="FieldName" HeaderText="Field Name" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="OldValue" HeaderText="Old Value" HeaderStyle-Width="250px" />
                                        <telerik:GridBoundColumn DataField="NewValue" HeaderText="New Value" HeaderStyle-Width="250px" />
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgAudit" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgAudit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgAudit" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

