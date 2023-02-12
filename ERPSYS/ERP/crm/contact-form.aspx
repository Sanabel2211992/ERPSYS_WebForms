<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="contact-form.aspx.cs" Inherits="ERPSYS.ERP.crm.ContactForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Contact Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Contact Name : &nbsp;
                            </td>
                            <td colspan="3" class="fv-edit">
                                <asp:DropDownList ID="ddlNameTitle" Width="50px" runat="server">
                                    <asp:ListItem Text="Mr" Value="Mr"></asp:ListItem>
                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:TextBox ID="txtContactName" runat="server" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Job Title :</td>
                            <td colspan="3" class="fv-edit">
                                <asp:TextBox ID="txtJobTitle" runat="server" Width="455px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Contact Type :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlType" Width="150px" runat="server"></asp:DropDownList>
                            </td>
                            <td class="ft-edit">Status :</td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Country :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">City :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCity" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Address :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" Width="450px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Fax :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Postal Code :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPostalCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Phone :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Mobile :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMobile" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">First Email :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmail1" runat="server" Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmailText1" CssClass="val-error" runat="server" ControlToValidate="txtEmail1" ErrorMessage="Invalid Email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <td class="ft-edit">Second Email :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmail2" runat="server" Width="150px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmailText2" CssClass="val-error" runat="server" ControlToValidate="txtEmail2" ErrorMessage="Invalid Email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
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
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSaveContact" runat="server" Text="Save" CssClass="btn-save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                                OnClick="btnSaveContact_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Cancel" runat="server" CssClass="btn-cancel" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
