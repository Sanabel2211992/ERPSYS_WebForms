<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-cat-form.aspx.cs" Inherits="ERPSYS.ERP.item.ItemCategoryForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Main Category Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Category Name :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMainCategory" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMainCategoryName" runat="server" ControlToValidate="txtMainCategory" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbBeSold" runat="server" Text="Can be Sold" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Category Code: </td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtMainCategoryCode" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbManufacture" runat="server" Text="Manufacture" />
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
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
