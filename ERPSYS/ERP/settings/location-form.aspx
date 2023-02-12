<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="location-form.aspx.cs" Inherits="ERPSYS.ERP.settings.LocationForm" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-inner-legend">Location Information</legend>
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
                            <td class="ft-edit">Store Name :</td>
                            <td class="fv-edit" colspan="2">
                                <asp:TextBox ID="txtLocationName" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLocationName" runat="server" ControlToValidate="txtLocationName" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" />
                            </td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Store Code :</td>
                            <td class="fv-edit" colspan="2">
                                <asp:TextBox ID="txtStoreCode" runat="server" Width="300px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbHasCost" runat="server" Text="Has Cost" />
                            </td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbReceivedGoods" runat="server" Text="Received Goods" />
                            </td>
                            <td class="ft-edit"></td>

                        </tr>
                        <tr>
                            <td class="ft-edit">Store Keeper :</td>
                            <td class="fv-edit" colspan="2">
                                <asp:TextBox ID="txtStoreKeeper" runat="server" Width="300px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">
                                <asp:CheckBox ID="cbConsigned" runat="server" Text="Consigned Store" />
                            </td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbSellGoods" runat="server" Text="Sell Goods" />
                            </td>
                            <td class="ft-edit"></td>
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
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the information?'); } else return;};"
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

