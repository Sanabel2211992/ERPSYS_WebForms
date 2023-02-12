<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-preview.aspx.cs" Inherits="ERPSYS.ERP.item.ItemPreview" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Product Information</legend>
                    <table class="tbl-view" style="width: 900px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Product Type :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblItemType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Product Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Product Name (AR):</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblDescriptionAr" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
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
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Category :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Sub Category :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblSubCategory" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Brand :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblBrand" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">UOM :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUom" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Unit Price :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Bar Code :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblBarCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlBom" runat="server">
                            <tr>
                                <td class="ft-view">BOM :</td>
                                <td class="fv-view" colspan="5">
                                    <asp:LinkButton ID="lnkbtnBom" runat="server" Text="Show Product Bill Of Materials" OnClick="btnBom_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </asp:Panel>
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
                <table class="item-view-prop">
                    <tr>
                        <td>
                            <asp:Label ID="lblManufacture" CssClass="highlighte" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblStandard" CssClass="highlighte" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCanBeSold" CssClass="highlighte" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-save" OnClick="btnEdit_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-delete" OnClick="btnDelete_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-op" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
