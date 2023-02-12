<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="imp-excel.aspx.cs" Inherits="ERPSYS.ERP.import.imp_excel" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Import Settings</legend>
                    <table class="tbl-view" style="width: 750px">
                        <tr>
                            <th class="ft-view" style="width: 100px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 100px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                            <th class="ft-view" style="width: 100px"></th>
                            <th class="fv-view" style="width: 150px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view" colspan="2">
                                <asp:RadioButton ID="rbCustomers" runat="server" Text="Customers" GroupName="rbTableName" Checked="true" />
                            </td>
                            <td class="fv-view" colspan="2">
                                <asp:HyperLink ID="hlCustomers" Text=" Download Sample " runat="server" NavigateUrl="~/Files/Samples/Customers.xls" />
                            </td>
                            <td class="ft-view" colspan="2"></td>
                        </tr>
                        <tr>
                            <td class="ft-view" colspan="2">
                                <asp:RadioButton ID="rbSuppliers" runat="server" Text="Suppliers" GroupName="rbTableName" />
                            </td>
                            <td class="fv-view" colspan="2">
                                <asp:HyperLink ID="hlSuppliers" Text=" Download Sample " runat="server" NavigateUrl="~/Files/Samples/Suppliers.xls" />
                            </td>
                            <td class="ft-view" colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="6" class="ft-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view" colspan="2">Select a Excel file to import :</td>
                            <td class="ft-view" colspan="2">
                                <asp:FileUpload ID="fuSampleUpload" runat="server" Width="300px" accept=".xls,.xlsx" />
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnImport" runat="server" Text="Load File" OnClick="btnImport_Click" />
                                <asp:RegularExpressionValidator ID="revSampleUpload" runat="server"
                                    ControlToValidate="fuSampleUpload"
                                    ErrorMessage="Only .xls or .xlsx Files are allowed"
                                    ValidationExpression="(.*?)\.(xls|jpeg|xlsx)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="plInteredData" runat="server" Visible="false">
                    <div class="grid-container no-bg">
                        <h3>Intered Data</h3>
                        <telerik:RadGrid ID="rgInteredData" AutoGenerateColumns="true" runat="server" ClientSettings-Scrolling-AllowScroll="true">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="130" />
                                <Resizing AllowRowResize="True" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <table class="tbl-op-center" style="width: 100px">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAnalyzes" runat="server" Text="Analyzes" OnClick="btnAnalyzes_Click" CssClass="btn-save" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="plSavedData" runat="server" Visible="false">
                    <div class="grid-container no-bg">
                        <h3>Saved Data</h3>
                        <telerik:RadGrid ID="rgSavedData" AutoGenerateColumns="true" runat="server" ClientSettings-Scrolling-AllowScroll="true">
                            <ClientSettings>
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" ScrollHeight="130" />
                                <Resizing AllowRowResize="True" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <table class="tbl-op-center" style="width: 100px">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn-save" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgTrueTable">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgTrueTable" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgSampleView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgSampleView" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
