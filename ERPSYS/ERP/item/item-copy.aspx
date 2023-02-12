<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-copy.aspx.cs" Inherits="ERPSYS.ERP.item.item_copy" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Product Information</legend>
                    <table class="tbl-view" style="width: 930px">
                        <tr>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 135px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="pt-view" colspan="6">General Information</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Manufacturing :</td>
                            <td class="highlighte" colspan="5">
                                <asp:Label ID="lblStandard" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Product Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Catalog Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Part Number :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Category :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Brand :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblBrand" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="pt-view" colspan="6">Pricing</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Unit Price :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgItem" runat="server" CssClass="tbl-main img-item-pos1" Height="150px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">New Product Information</legend>
                    <table class="tbl-edit" style="width: 640px">
                        <tr>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 180px"></td>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 180px"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Catalog Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemCode" runat="server" ControlToValidate="txtItemCode" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">Part Number :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtPartNumber" runat="server" Width="155px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtPartNumber" runat="server" ControlToValidate="txtPartNumber" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemName" runat="server" Width="480px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemName" runat="server" ControlToValidate="txtItemName" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Name (AR):</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemNameAr" runat="server" Width="480px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Show As :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtItemNameShowAs" runat="server" Width="480px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItemNameShowAs" runat="server" ControlToValidate="txtItemNameShowAs" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="item-view-prop3" style="width: 250px">
                    <tr>
                        <td>
                            <fieldset class="fs-edit">
                                <legend class="fs-edit-legend">Copy Settings </legend>
                                <table>
                                    <tr>
                                        <td class="ft-edit">
                                            <asp:CheckBox ID="cbBom" runat="server" Text="Copy BOM" /></td>
                                    </tr>
                                    <tr>
                                        <td class="ft-edit">
                                            <asp:CheckBox ID="cbImage" runat="server" Text="Copy Image" /></td>
                                    </tr>
                                    <tr>
                                        <td class="ft-edit">
                                            <asp:CheckBox ID="cbPrice" runat="server" Text="Copy Sale Price" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn-op" OnClientClick="return confirm('Are you sure you want to copy this product?');" ValidationGroup="save" OnClick="btnConfirm_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-op" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>