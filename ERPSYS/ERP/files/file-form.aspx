<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="file-form.aspx.cs" Inherits="ERPSYS.ERP.files.FileForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">File Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">File Description:</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtFileDescription" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFileDescription" runat="server" ControlToValidate="txtFileDescription" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Private File :</td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbIsPrivate" runat="server" Text="Yes" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit" colspan="3">
                                <asp:LinkButton ID="lnkbtnOpenFile" runat="server" CausesValidation="False" Enabled="False" OnClick="lnkbtnOpenFile_Click">File not found</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit"></td>
                            <td class="fv-edit" colspan="3">
                                <asp:FileUpload ID="fuFile" runat="server" Width="375px" />
                                <asp:Button ID="btnUploadFile" runat="server" CssClass="btn-upload" Text="Upload" CausesValidation="False" Width="75" OnClick="btnUploadFile_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
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
</asp:Content>
