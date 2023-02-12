<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="job-order-create.aspx.cs" Inherits="ERPSYS.ERP.sm.JobOrderCreate" %>

<%@ Register Src="../../Controls/ComboBox/SM/UCCustomerList.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Job Order Information</legend>
                    <table class="tbl-edit" style="width: 1160px">
                        <tr>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer :</td>
                            <td class="fv-edit" colspan="5">
                                <uc1:UCCustomerList ID="UCCustomer" runat="server" ValidationGroup="save" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">
                                &nbsp;</td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save Job Order ?'); } else return;};"
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
