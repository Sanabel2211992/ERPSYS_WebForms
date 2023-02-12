<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="GrideEditInPlace.aspx.cs" Inherits="ERPSYS.ERP.obsolete.GrideEditInPlace" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Search Criteria</legend>
                    <table class="tbl-inner" style="width: 300px">
                        <tr>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="field-title">Department Name :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtDepartmentName" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
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
                            <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Department</asp:LinkButton>
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
                            <telerik:RadGrid ID="rgDepartmentList" runat="server" RenderMode="Lightweight" AllowPaging="False" ShowFooter="true" Width="100%" AutoGenerateColumns="False" 
                                OnNeedDataSource="rgDepartmentList_NeedDataSource" OnInit="rgDepartmentList_Init" OnUpdateCommand="rgDepartmentList_UpdateCommand">
                                <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="DepartmentId,Name" EditMode="InPlace">
                                    <NoRecordsTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>No Data Found
                                                </td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridEditCommandColumn HeaderStyle-Width="60px" />
                                        <telerik:GridBoundColumn DataField="DepartmentId" HeaderText="ID" HeaderStyle-Width="35px" Display="false" />                
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Department Name" ReadOnly="true" HeaderStyle-Width="200px" />
                                       <telerik:GridTemplateColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="300px" >
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <telerik:RadNumericTextBox ID="txtDescription" DisplayText='<%#Eval("Description") %>' runat="server" Width="150px" MinValue="1" MaxValue="999999">
                                                    <NumberFormat DecimalDigits="0" />
                                                </telerik:RadNumericTextBox>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                         <telerik:GridBoundColumn DataField="Remark" HeaderText="Remark" HeaderStyle-Width="200px" DataType="System.Decimal" DataFormatString="{0:F2}" EmptyDataText="1" AllowFiltering="true" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="16px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("department-form.aspx?o=edit&id={0}", Eval("DepartmentId")) %>'>
                                                        <img alt="Edit" width="12" height="12" title="Edit" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("department-delete.aspx?id={0}", Eval("DepartmentId")) %>'>
                                                        <img alt="Delete" width="11" height="11" title="Delete" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
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
    <telerik:RadAjaxManager ID="ramDepartment" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgDepartmentList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgUnitMeasure">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgDepartmentList" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

