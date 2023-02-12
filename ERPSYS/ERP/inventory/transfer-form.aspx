<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="transfer-form.aspx.cs" Inherits="ERPSYS.ERP.inventory.TransferForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/HierarchyItems/INV/StockTransfer/UCItemAdd.ascx" TagName="UCItemAdd" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Stock Transfer Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Transfer #: </td>
                            <td class="fv-edit">
                                <asp:Label ID="lblTransferNumber" runat="server"></asp:Label></td>
                            <td class="ft-edit">Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Description :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtTransferDescription" runat="server" Width="460px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfTransferDescription" runat="server" ControlToValidate="txtTransferDescription" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Job Order # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtJobOrderNumber" runat="server" Width="150px"></asp:TextBox>
                            </td>
                            <td class="ft-edit">Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Location :</td>
                            <td class="fv-edit" colspan="3">
                                <table style="width: 470px">
                                    <tr>
                                        <td style="width: 60px">From </td>
                                        <td style="width: 175px">
                                            <asp:DropDownList ID="ddlFromLocation" runat="server" Width="170px"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLocation1" runat="server" ControlToValidate="ddlFromLocation" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="-1" />
                                        </td>
                                        <td style="width: 60px">To </td>
                                        <td style="width: 175px">
                                            <asp:DropDownList ID="ddlToLocation" runat="server" Width="170px"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvLocation2" runat="server" ControlToValidate="ddlToLocation" ValidationGroup="save" CssClass="val-error" Display="Dynamic" ErrorMessage="*" InitialValue="-1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="460px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-in-trns" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Stock Transfer Information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UCItemAdd ID="UCStockItem" ValidationGroup="add-item" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-uc-op" style="width: 100px">
                    <tr>
                        <td>
                            <asp:Button ID="btnAddItem" runat="server" ValidationGroup="add" Text="Add Product" CssClass="btn-uc-st btn-op-add-st-pos" OnClick="btnAddItem_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Stock Transfer Details</h3>
                    <telerik:RadGrid ID="rgStockTransfer" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" OnDeleteCommand="rgStockTransfer_DeleteCommand" OnNeedDataSource="rgStockTransfer_NeedDataSource" OnUpdateCommand="rgStockTransfer_UpdateCommand">
                        <MasterTableView DataKeyNames="LineId,ItemId">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <EditFormSettings UserControlName="~/Controls/HierarchyItems/INV/StockTransfer/UCItemEdit.ascx" EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommand">
                                </EditColumn>
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="75px" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
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
                <table class="tbl-op-center" style="width: 100px">
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
    <telerik:RadAjaxManager ID="ramInvoice" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgStockTransfer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgStockTransfer" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgStockTransfer" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="UCStockItem" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>

