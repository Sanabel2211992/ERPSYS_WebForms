<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="goods-receipt-form.aspx.cs" Inherits="ERPSYS.ERP.scm.GoodsReceiptForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/ComboBox/UCSupplierList.ascx" TagName="UCSupplierList" TagPrefix="uc3" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Material Receipt Information</legend>
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
                            <td class="ft-edit">Material Receipt # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblGoodsReceiptNumber" runat="server"></asp:Label></td>
                            <td class="ft-edit">Receipt Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblGoodsReceiptStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Supplier Name :</td>
                            <td class="fv-edit" colspan="3">
                                <uc3:UCSupplierList ID="UCSupplier" runat="server" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Received Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDate" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit read-only">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px" Enabled="False"></asp:DropDownList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit" colspan="3">
                                <asp:CheckBox ID="cbConsignedGoods" runat="server" Enabled="False" Text="Mark as Consigned Goods (Goods will added to Consigned Store)" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-sc-mr" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to update the information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Material Receipt Details</h3>
                    <telerik:RadGrid ID="rgGoodReceipt" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnItemCommand="rgGoodReceipt_ItemCommand" OnInsertCommand="rgGoodReceipt_InsertCommand" OnUpdateCommand="rgGoodReceipt_UpdateCommand"
                        OnNeedDataSource="rgGoodReceipt_NeedDataSource" OnDeleteCommand="rgGoodReceipt_DeleteCommand">
                        <MasterTableView DataKeyNames="LineId,ItemId" CommandItemDisplay="Top">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <CommandItemSettings AddNewRecordText="Add Product" />
                            <EditFormSettings EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommand" />
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" ReadOnly="True" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" ReadOnly="True" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                <telerik:GridBoundColumn DataField="UomId" HeaderText="UnitId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="45px" />
                                <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="125px" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this product?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 150px">
                    <tr>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn-save" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="radAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgGoodReceipt">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgGoodReceipt" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
