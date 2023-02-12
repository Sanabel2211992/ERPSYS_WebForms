<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="purchase-invoice-create.aspx.cs" Inherits="ERPSYS.ERP.scm.PurchaseInvoiceCreate" %>

<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/ComboBox/UCSupplierList.ascx" TagName="UCSupplierList" TagPrefix="uc1" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Purchase Invoice Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Supplier :</td>
                            <td class="fv-edit" colspan="3">
                                <uc1:UCSupplierList ID="UCSupplier" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"> Invoice Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Currency :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlCurrency" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvCurrency" ControlToValidate="ddlCurrency" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="154px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Purchase Order # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPurchaseOrderNumber" runat="server" Width="142px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Supplier Invoice # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtSupplierInvoice" runat="server" Width="146px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" Width="100px" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Purchase Invoice ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
