<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="location-assign.aspx.cs" Inherits="ERPSYS.ERP.settings.LocationAssignment" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Locations Assignment</legend>
                    <table class="tbl-edit" style="width: 300px">
                        <tr>
                            <th class="ft-edit" style="width: 200px"></th>
                            <th class="fv-edit" style="width: 100px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Raw Material Store:
                            </td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlRawMaterialStore" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Production Store:
                            </td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlProductionStore" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Finish Material Store:
                            </td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlFinishMaterial" runat="server" Width="150px"></asp:DropDownList>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" OnClientClick="return confirm('Are you sure you want to save Locations Assignment?');" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>