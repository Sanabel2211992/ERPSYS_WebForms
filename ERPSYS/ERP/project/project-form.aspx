<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="project-form.aspx.cs" Inherits="ERPSYS.ERP.project.project_form" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
     <fieldset class="fs-inner">
                <legend class="fs-inner-legend">Add New Project :</legend>
                <table class="tbl-main">
                    <tr>
                        <td class="field-title" style="width: 100px"></td>
                        <td class="field-val"></td>
                        <td class="field-title" ></td>
                        <td class="field-val"></td>
                    </tr>
                    <tr>
                        <td class="field-title">Project Name :</td>
                        <td class="field-val" colspan="3">
                            <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFileDescription" runat="server" ControlToValidate="txtProjectName" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="field-title">Owner: </td>
                        <td class="field-val" colspan="3">
                            <asp:TextBox ID="txtOwner" runat="server" Width="450px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOwner" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
         <table class="tbl-op-center" style="width: 200px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                    OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                    OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
            </fieldset>
</asp:Content>
