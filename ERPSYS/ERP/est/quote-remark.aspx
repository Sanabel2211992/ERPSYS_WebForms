<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-remark.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteRemark" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-view">
                    <legend class="fs-view-legend">Quotation Information</legend>
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
                            <td class="ft-view">Quote # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblQuoteNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Quote Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Sales Engineer :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblSalesEngineer" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Currency (View): </td>
                            <td class="fv-view">
                                <asp:Label ID="lblCurrencyView" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Template :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblTemplate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Inquiry # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInquiryNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Inquiry Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblInquiryDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-edit" style="width: 1160px">
                    <tr>
                        <th style="width: 1160px"></th>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Terms and Conditions)</h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark1" runat="server" Height="150px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="par-container no-bg">
                                <h3>Remark (Additional Notes)</h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="fv-edit">
                            <asp:TextBox ID="txtRemark2" runat="server" Height="150px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" OnClientClick="return confirm('Are you sure ?');" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="back" CssClass="btn-save" OnClick="btnBack_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
