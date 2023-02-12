<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="system-settings.aspx.cs" Inherits="ERPSYS.ERP.settings.SystemSettingsForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <div>
                    <telerik:RadTabStrip ID="rtsSettings" runat="server" RenderMode="Lightweight" MultiPageID="rmpSettings" Width="100%" Skin="MetroTouch" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab PageViewID="rpvGeneral" Text="General" Selected="True" />
                            <telerik:RadTab PageViewID="rpvSecurity" Text="Security" />
                        </Tabs>
                    </telerik:RadTabStrip>
                </div>
                <div>
                    <telerik:RadMultiPage ID="rmpSettings" runat="server" Width="100%" SelectedIndex="0">
                        <telerik:RadPageView ID="rpvGeneral" runat="server" Selected="true">
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
                                            <NumberFormat GroupSeparator="" DecimalDigits="0" />
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
                            <div>
                                <asp:Button ID="btnGeneralSettings" runat="server" Text="Save" CssClass="btn-save"
                                    OnClientClick="return confirm('Are you sure you want to update settings ?');"
                                    OnClick="btnGeneralSettings_Click" />
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="rpvSecurity" runat="server">

                            <table class="tbl-edit" style="width: 500px">
                                <tr>
                                    <th class="ft-edit" style="width: 200px"></th>
                                    <th class="fv-edit" style="width: 300px"></th>
                                </tr>
                                <tr>
                                    <td class="fv-edit" colspan="2">
                                        <asp:CheckBox ID="cbEnableComplexPassword" runat="server" Text="Enable Complex Password" />
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
                            <div>
                                <asp:Button ID="btnSecuritySettings" runat="server" Text="Save" CssClass="btn-save"
                                    OnClientClick="return confirm('Are you sure you want to update settings ?');"
                                    OnClick="btnSecuritySettings_Click" />
                            </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
