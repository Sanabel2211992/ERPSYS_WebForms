<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="client-form.aspx.cs" Inherits="ERPSYS.ERP.crm.ClientForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <asp:LinkButton ID="lnkbtnFill" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnFill_Click" CausesValidation="false">Fill Information from Customer exist</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFill" runat="server" Visible="false">
                    <table class="tbl-edit" style="width: 400px">
                        <tr>
                            <td class="ft-edit" style="width: 150px">Customer Name :</td>
                            <td class="fv-edit" style="width: 150px">
                                <asp:DropDownList ID="ddlCustomerName" runat="server" Width="135px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnFill" runat="server" Text="Fill" CssClass="btn-save" CausesValidation="false" OnClick="btnFill_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Client Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Client Name :</td>
                            <td colspan="3" class="field-val">
                                <asp:TextBox ID="txtClientName" runat="server" Width="455px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvClientName" runat="server" ControlToValidate="txtClientName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Country :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="txtCountry"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">City :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtCity" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Address :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" Width="450px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Fax :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Postal Code :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtPostalCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Phone :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Mobile :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtMobile" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmailText" CssClass="val-error" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Website :</td>
                            <td class="field-val">
                                <asp:TextBox ID="txtWebsite" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Status :</td>
                            <td class="field-val">
                                <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="field-val" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
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
