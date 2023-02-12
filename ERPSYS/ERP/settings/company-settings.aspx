<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="company-settings.aspx.cs" Inherits="ERPSYS.ERP.settings.CompanySettings" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <div>
                    <telerik:RadTabStrip ID="rtsSettings" runat="server" RenderMode="Lightweight" MultiPageID="rmpSettings" Width="100%" Align="Left" Skin="MetroTouch">
                        <Tabs>
                            <telerik:RadTab PageViewID="rpvGeneralSettings" Text="General Settings" Selected="True" />
                            <telerik:RadTab PageViewID="rpvPassword" Text="Security Policy" />
                        </Tabs>
                    </telerik:RadTabStrip>
                </div>
                <div>
                    <telerik:RadMultiPage ID="rmpSettings" runat="server" Width="100%">
                        <telerik:RadPageView ID="rpvGeneralSettings" runat="server" Selected="true">
                            <table class="tbl-edit" style="width: 900px">
                                <tr>
                                    <th class="ft-edit" style="width: 125px"></th>
                                    <th class="fv-edit" style="width: 175px"></th>
                                    <th class="ft-edit" style="width: 125px"></th>
                                    <th class="fv-edit" style="width: 175px"></th>
                                    <th class="ft-edit" style="width: 125px"></th>
                                    <th class="fv-edit" style="width: 175px"></th>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbEnableSalesTax" runat="server" Text="Activate Sales Tax" AutoPostBack="True" OnCheckedChanged="cbEnableSalesTax_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">Sales Tax Value :</td>
                                    <td class="fv-edit">
                                        <telerik:RadNumericTextBox ID="txtSalesTaxValue" MinValue="0" MaxValue="0.99" runat="server" LabelWidth="50px" Width="75px" EmptyMessage="0-0.99" Value="0">
                                        </telerik:RadNumericTextBox></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="sec-title" colspan="6">Print Template</td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbSalesInvoiceHeader" runat="server" Text="Show Sales Invoice Header and Footer" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbProInvoiceHeader" runat="server" Text="Show Pro Invoice Header and Footer" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbDeliveryReceiptHeader" runat="server" Text="Show Delivery Receipt Header and Footer" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbShowWatermarkInReports" runat="server" Text="Show Watermark In Reports" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbHidePOQuantityInMR" runat="server" Text="Hide Purchase Order Quantity In Materials Receipt" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbAddExpensesValueToTotal" runat="server" Text="Add Expenses Value To Total" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6"></td>
                                </tr>
                                <tr>
                                    <td class="sec-title" colspan="6">Job Order</td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbJobOrderSalesOrderPost" runat="server" Text="Create Job Order Automatically when Post Sales Order" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbJobOrderSalesInvoicePost" runat="server" Text="Create Job Order Automatically when Post Sales Invoice" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="sec-title" colspan="6">Sales Invoice</td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbSalesInvoiceSetReferenceManually" runat="server" Text="Enable set the reference of Sales Invoice manually" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="6">
                                        <asp:CheckBox ID="cbShowOnlyRetailUserLocationInvoices" runat="server" Text="Show Only Retail User Location Invoices" />
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-left: 1050px">
                                <asp:Button ID="btnSysSave" runat="server" Text="Save" CssClass="btn-save"
                                    OnClientClick="return confirm('Are you sure you want to update company settings ?');"
                                    OnClick="btnSysSave_Click" />
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="rpvPassword" runat="server">

                            <table class="tbl-edit" style="width: 500px">
                                <tr>
                                    <th class="ft-edit" style="width: 200px"></th>
                                    <th class="fv-edit" style="width: 300px"></th>
                                </tr>
                                <tr>
                                    <td class="fv-edit">Enable Complex Password </td>
                                    <td class="fv-edit">
                                        <asp:RadioButtonList ID="rblEnableComplexPassword" runat="server" CssClass="inline-rb" RepeatDirection="Horizontal" Width="120px">
                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="false">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">Minimum Password Length :</td>
                                    <td class="fv-edit">
                                        <telerik:RadNumericTextBox ID="txtMinPasswordLength" MinValue="0" MaxValue="100" runat="server" LabelWidth="50px" Width="75px" EmptyMessage="0" Value="0">
                                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">Minimum Password Age :</td>
                                    <td class="fv-edit">
                                        <telerik:RadNumericTextBox ID="txtMinPasswordAge" MinValue="0" MaxValue="100" runat="server" LabelWidth="50px" Width="75px" EmptyMessage="0" Value="0">
                                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">Maximum Password Age :</td>
                                    <td class="fv-edit">
                                        <telerik:RadNumericTextBox ID="txtMaxPasswordAge" MinValue="0" MaxValue="100" runat="server" LabelWidth="50px" Width="75px" EmptyMessage="0" Value="0">
                                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
                                        </telerik:RadNumericTextBox></td>
                                </tr>
                            </table>
                            <div style="margin-left: 1050px">
                                <asp:Button ID="btnPasswordSave" runat="server" Text="Save" CssClass="btn-save"
                                    OnClientClick="return confirm('Are you sure you want to update password policy settings ?');"
                                    OnClick="btnPasswordSave_Click" />
                            </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <%--    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsSettings">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsSettings" />
                    <telerik:AjaxUpdatedControl ControlID="rmpSettings" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
</asp:Content>
