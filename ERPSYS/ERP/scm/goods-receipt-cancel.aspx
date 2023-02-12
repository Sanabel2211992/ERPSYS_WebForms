<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-receipt-cancel.aspx.cs" Inherits="ERPSYS.ERP.scm.GoodsReceiptCancel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <div class="note">
                    <span>notice: </span>Material Receipt will be canceled if you continue, and this will require you to correct mistakes that have occurred !
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Material Receipt Information</legend>
                    <table class="tbl-view" style="width: 1180px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Material Receipt # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Receipt Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Received Date :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMaterialReceiptDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Location :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Purchase Order # :</td>
                            <td class="fv-view">
                                <asp:HyperLink ID="hlnkPurchaseOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view">Prepared By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPreparedBy" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Posted By :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostedBy" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="ft-view">Supplier Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:HyperLink ID="hlnkSupplierName" ToolTip="preview Supplier Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks : </td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgGoodsReceipt" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                                AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False" OnNeedDataSource="rgGoodsReceipt_NeedDataSource">
                                <MasterTableView DataKeyNames="LineId">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="600px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="45px" />
                                        <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="125px" />
                                        <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Cancellation Information</legend>
                    <table class="tbl-edit" style="width: 650px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 525px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Purchase Order :</td>
                            <td class="fv-edit">
                                <asp:CheckBox ID="cbUpdatePurchaseOrderStatus" runat="server" Text="Reflect Changes To Purchase Order Status" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCancelRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCancelRemarks" runat="server" ControlToValidate="txtCancelRemarks" ValidationGroup="save"
                                    ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Continue" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to cancel the material receipt ? ?'); } else return;};" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
