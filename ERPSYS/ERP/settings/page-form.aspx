<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="page-form.aspx.cs" Inherits="ERPSYS.ERP.settings.PageForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Page Information</legend>
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
                            <td class="ft-edit">Page Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtPageName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPageName"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Display Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtDisplayName" runat="server" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Category :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:DropDownList ID="ddlPageCategory" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="val-error" Display="Dynamic" ErrorMessage="*" ControlToValidate="ddlPageCategory" InitialValue="-1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Operation :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:CheckBoxList ID="cblstOperation" runat="server" RepeatDirection="Horizontal" Width="300px">
                                    <asp:ListItem Value="View">View </asp:ListItem>
                                    <asp:ListItem>Add</asp:ListItem>
                                    <asp:ListItem>Update</asp:ListItem>
                                    <asp:ListItem>Delete</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Status :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fv-edit">Access Type :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:RadioButtonList ID="rblAccessType" runat="server"></asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Description :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtDescription" runat="server" Width="450px" Height="50px" TextMode="MultiLine"></asp:TextBox>
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
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
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
