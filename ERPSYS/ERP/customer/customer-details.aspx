<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="customer-details.aspx.cs" Inherits="ERPSYS.ERP.customer.CustomerDetails" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Customer Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 130px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer Name :</td>
                            <td colspan="3" class="fv-edit">
                                <asp:TextBox ID="txtCustomerName" runat="server" Width="455px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Arabic Name :</td>
                            <td colspan="3" class="fv-edit">
                                <asp:TextBox ID="txtCustomerNameAr" runat="server" Width="455px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Address 1 :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtAddress1" runat="server" Width="150px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress1"
                                   Enabled="false" ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Address 2 :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtAddress2" runat="server" Height="50px" TextMode="MultiLine" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Country :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCountry"
                                    Enabled="false" ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">City :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCity" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">State :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtState" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Postal Code :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPostalCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Payment Methods :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" Width="160px"></asp:DropDownList>
                            </td>
                            <td class="ft-edit">Payment Terms :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="160px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlPaymentTerms"
                                    Enabled="false" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" SetFocusOnError="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Contact Name :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtContactName" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Phone :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone"
                                    Enabled="false" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Fax :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Email :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbIsActive" Text="Active" runat="server" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                &nbsp;<asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="455px"></asp:TextBox>
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
