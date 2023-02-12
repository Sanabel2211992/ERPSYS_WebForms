<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContactEdit.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.CRM.UCContactEdit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table class="tbl-main" style="width: 600px">
    <tr>
        <td class="field-title" style="width: 25px"></td>
        <td class="field-title" style="width: 100px"></td>
        <td class="field-val" style="width: 175px"></td>
        <td class="field-title" style="width: 125px"></td>
        <td class="field-val" style="width: 175px"></td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Contact Name : &nbsp;
        </td>
        <td colspan="3" class="field-val">
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
        <td class="field-title"></td>
        <td class="field-title">Job Title :</td>
        <td colspan="3" class="field-val">
            <asp:TextBox ID="txtJobTitle" runat="server" Width="455px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Contact Type :</td>
        <td class="field-val">
            <asp:DropDownList ID="ddlType" Width="150px" runat="server"></asp:DropDownList>
        </td>
        <td class="field-title">Status :</td>
        <td class="field-val">
            <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" Text="Active" />
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Country :</td>
        <td class="field-val">
            <asp:TextBox ID="txtCountry" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td class="field-title">City :</td>
        <td class="field-val">
            <asp:TextBox ID="txtCity" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Address :</td>
        <td class="field-val" colspan="3">
            <asp:TextBox ID="txtAddress" runat="server" Width="450px" Height="50px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Fax :</td>
        <td class="field-val">
            <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td class="field-title">Postal Code :</td>
        <td class="field-val">
            <asp:TextBox ID="txtPostalCode" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Phone :</td>
        <td class="field-val">
            <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
        </td>
        <td class="field-title">Mobile :</td>
        <td class="field-val">
            <asp:TextBox ID="txtMobile" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">First Email :</td>
        <td class="field-val">
            <asp:TextBox ID="txtEmail1" runat="server" Width="150px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revEmailText1" CssClass="val-error" runat="server" ControlToValidate="txtEmail1" ErrorMessage="Invalid Email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
        </td>
        <td class="field-title">Second Email :</td>
        <td class="field-val">
            <asp:TextBox ID="txtEmail2" runat="server" Width="150px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revEmailText2" CssClass="val-error" runat="server" ControlToValidate="txtEmail2" ErrorMessage="Invalid Email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="field-title"></td>
        <td class="field-title">Remarks :</td>
        <td class="field-val" colspan="3">
            <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4"></td>
    </tr>
</table>
<table class="tbl-inner" style="width: 600px">
    <tr>
        <td class="field-title" style="width: 125px"></td>
        <td class="field-val" style="width: 175px"></td>
        <td class="field-title" style="width: 125px"></td>
        <td class="field-val" style="width: 175px"></td>
    </tr>
    <tr>
        <td colspan="3"></td>
        <td class="relative">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" ValidationGroup="SubItem" CssClass="btn-Add-edit s-edit-save" CommandName="Update"></asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="btn-Add-edit s-edit-Cancel" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>
