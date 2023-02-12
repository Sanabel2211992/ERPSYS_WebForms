<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="report-template.aspx.cs" Inherits="ERPSYS.ERP.settings.ReportTemplate" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Template Information</legend>
                    <table class="tbl-inner" style="width: 900px">
                        <tr>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                        </tr>

                        <tr>
                            <td class="field-title" style="width: 125px">Company :</td>
                            <td class="field-val" colspan="5">
                                <asp:DropDownList ID="ddlCompanyList" runat="server" Width="450px" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td class="field-title" style="width: 125px">&nbsp;</td>
                            <td class="field-val" colspan="5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="field-title" colspan="6"><strong><em>Header Template</em></strong></td>
                        </tr>
                        <tr>
                            <td class="field-title">Arabic Details</td>
                            <td colspan="5" class="field-val">
                                <asp:FileUpload ID="fuHeaderRight" runat="server" Width="450px" />
                                <asp:Button ID="btnUploadHeaderRight" runat="server" CssClass="btn-upload" Text="Upload" CausesValidation="False" Width="75" OnClick="btnUploadHeaderRight_Click" />
                                <asp:Button ID="btnSubmitHeaderRight" runat="server" CssClass="btn-upload" Text="Submit" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to change this picture ?');" OnClick="btnSubmitHeaderRight_Click" />
                                <asp:Button ID="btnRemoveHeaderRight" runat="server" CssClass="btn-upload" Text="Remove" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to remove this picture ?');" OnClick="btnRemoveHeaderRight_Click" />

                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val" colspan="5">
                                <asp:Image ID="imgHeaderRight" runat="server" AlternateText="Image Size It's must be (198px x 101px)" Height="101px" Width="198px" ImageAlign="Middle" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">Logo</td>
                            <td class="field-val" colspan="5">
                                <asp:FileUpload ID="fuHeaderCenter" runat="server" Width="450px" />
                                <asp:Button ID="btnUploadHeaderCenter" runat="server" CssClass="btn-upload" Text="Upload" CausesValidation="False" Width="75" OnClick="btnUploadHeaderCenter_Click" />
                                <asp:Button ID="btnSubmitHeaderCenter" runat="server" CssClass="btn-upload" Text="Submit" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to change this picture ?');" OnClick="btnSubmitHeaderCenter_Click" />
                                <asp:Button ID="btnRemoveHeaderCenter" runat="server" CssClass="btn-upload" Text="Remove" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to remove this picture ?');" OnClick="btnRemoveHeaderCenter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val" colspan="5">
                                <asp:Image ID="imgHeaderCenter" runat="server" AlternateText="Image Size It's must be (128px x 101px)" Height="101px" Width="128px"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">English Details</td>
                            <td class="field-val" colspan="5">
                                <asp:FileUpload ID="fuHeaderLeft" runat="server" Width="450px" />
                                <asp:Button ID="btnUploadHeaderLeft" runat="server" CssClass="btn-upload" Text="Upload" CausesValidation="False" Width="75" OnClick="btnUploadHeaderLeft_Click" />
                                <asp:Button ID="btnSubmitHeaderLeft" runat="server" CssClass="btn-upload" Text="Submit" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to change this picture ?');" OnClick="btnSubmitHeaderLeft_Click" />
                                <asp:Button ID="btnRemoveHeaderLeft" runat="server" CssClass="btn-upload" Text="Remove" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to remove this picture ?');" OnClick="btnRemoveHeaderLeft_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val" colspan="5">
                                <asp:Image ID="imgHeaderLeft" runat="server" AlternateText="Image Size It's must be (198px x 101px)" Height="101px" Width="198px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="field-title" colspan="6"><strong><em>Footer Template</em></strong></td>
                        </tr>
                        <tr>
                            <td class="field-title">Footer Details</td>
                            <td class="field-val" colspan="5">

                                <asp:FileUpload ID="fuFooter" runat="server" Width="450px" />
                                <asp:Button ID="btnUploadFooter" runat="server" CssClass="btn-upload" Text="Upload" CausesValidation="False" Width="75" OnClick="btnUploadFooter_Click" />
                                <asp:Button ID="btnSubmitFooter" runat="server" CssClass="btn-upload" Text="Submit" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to change this picture ?');" OnClick="btnSubmitFooter_Click" />
                                <asp:Button ID="btnRemoveFooter" runat="server" CssClass="btn-upload" Text="Remove" CausesValidation="False" Width="75" OnClientClick="return confirm('Are you sure you want to remove this picture ?');" OnClick="btnRemoveFooter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val" colspan="5">
                                <asp:Image ID="imgFooter" runat="server" AlternateText="Image Size It's must be (727px x 52px)" Height="52px" Width="727px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-title">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                            <td class="field-val">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
