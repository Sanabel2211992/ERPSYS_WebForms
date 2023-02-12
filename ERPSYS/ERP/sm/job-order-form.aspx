<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="job-order-form.aspx.cs" Inherits="ERPSYS.ERP.sm.JobOrderForm" %>

<%@ Register Src="../../Controls/ComboBox/SM/UCCustomerList.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Job Order Information</legend>
                    <table class="tbl-edit" style="width: 1160px">
                        <tr>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 120px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Job Order # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit">Order Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit">Order Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer :</td>
                            <td class="fv-edit" colspan="5">
                                <uc1:UCCustomerList ID="UCCustomer" runat="server" ValidationGroup="save" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name:</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-sm-jo" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to update Job Order information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Job Order Products Details</h3>
                    <telerik:RadGrid ID="rgJobOrder" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnDetailTableDataBind="rgJobOrder_DetailTableDataBind" OnItemCommand="rgJobOrder_ItemCommand"
                        OnInsertCommand="rgJobOrder_InsertCommand" OnUpdateCommand="rgJobOrder_UpdateCommand"
                        OnNeedDataSource="rgJobOrder_NeedDataSource" OnPreRender="rgJobOrder_PreRender" OnDeleteCommand="rgJobOrder_DeleteCommand" OnItemCreated="rgJobOrder_ItemCreated" OnItemDataBound="rgJobOrder_ItemDataBound">
                        <MasterTableView DataKeyNames="LineId,LineSeqId,ItemId" Name="MainItem" CommandItemDisplay="Top">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <CommandItemSettings AddNewRecordText="Add Product" />
                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems"
                                    ShowFooter="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                                    CommandItemDisplay="Top" Width="100%">
                                    <NoRecordsTemplate>
                                        <table class="rginnerEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <CommandItemSettings AddNewRecordText="Add Sub Product" ShowRefreshButton="false" />
                                    <EditFormSettings UserControlName="" EditFormType="WebUserControl">
                                        <EditColumn UniqueName="EditCommandSub">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <ParentTableRelation>
                                        <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="LineId"></telerik:GridRelationFields>
                                    </ParentTableRelation>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="10px"></telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandSub">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>
                                        <telerik:GridButtonColumn ConfirmText="Are you sure ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <EditFormSettings UserControlName="" EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommandMain">
                                </EditColumn>
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="JobOrderId" HeaderText="OrderId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineSeqId" HeaderText="LineSeqId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="670px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandMain">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this product ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgJobOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgJobOrder" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
