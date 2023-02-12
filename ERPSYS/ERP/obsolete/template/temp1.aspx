<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="temp1.aspx.cs" Inherits="ERPSYS.ERP.template.Temp1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
       
        <tr>
            <td class="sec-title">Title 1</td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Legend Name</legend>
                    <table class="tbl-inner">
                        <tr>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                            <td class="field-title" style="width: 125px"></td>
                            <td class="field-val" style="width: 175px"></td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                        <tr>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                            <td class="field-title"></td>
                            <td class="field-val"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="grid-title">Title 2</td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sec-title">Title 2</td>
        </tr>
        <tr>
            <td>
                <table class="tbl-inner">
                    <tr>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                    </tr>
                    <tr>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                    </tr>
                    <tr>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-op">
                    <tr>
                        <td>Button 1</td>
                        <td>Button 2</td>
                        <td>Button 3</td>
                        <td>Button 4</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
