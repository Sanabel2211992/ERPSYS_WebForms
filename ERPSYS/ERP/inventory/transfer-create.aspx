<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="transfer-create.aspx.cs" Inherits="ERPSYS.ERP.inventory.TransferCreate" %>

<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Stock Transfer Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Description :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtTransferDescription" runat="server" Width="460px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfTransferDescription" runat="server" ControlToValidate="txtTransferDescription" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Job Order # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtJobOrderNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Locations :</td>
                            <td class="fv-edit" colspan="3">
                                <table style="width: 470px">
                                    <tr>
                                        <td style="width: 60px">From </td>
                                        <td style="width: 175px">
                                            <asp:DropDownList ID="ddlFromLocation" runat="server" Width="160px"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvFromLocation" runat="server" ControlToValidate="ddlFromLocation" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="-1" />
                                        </td>
                                        <td style="width: 60px">To </td>
                                        <td style="width: 175px">
                                            <asp:DropDownList ID="ddlToLocation" runat="server" Width="160px"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvToLocation" runat="server" ControlToValidate="ddlToLocation" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="-1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="460px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Transfer ?'); } else return;};"
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
