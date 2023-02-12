<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="sales-invoice-pro.aspx.cs" Inherits="ERPSYS.ERP.sm.SalesInvoicePro" %>

<%@ Register Src="../../Controls/ComboBox/SM/UCCustomerList.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Proforma Invoice Information</legend>
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
                            <td class="ft-edit">Pro Invoice # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit">Customer P.O :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtCustomerPO" runat="server" Width="140px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit" style="width: 125px">Customer :</td>
                            <td class="fv-edit" colspan="3">
                                <uc1:UCCustomerList ID="UCCustomerList" runat="server" ValidationGroup="save" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="field-title">Location :</td>
                            <td class="field-val">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLocation" ControlToValidate="ddlLocation" ValidationGroup="save"
                                    Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Payment Method :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPaymentMethod" ControlToValidate="ddlPaymentMethod" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Payment Terms :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlPaymentTerms" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPaymentTerms" ControlToValidate="ddlPaymentTerms"
                                    Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
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
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Total Summary</legend>
                    <table class="tbl-inner-view" style="width: 900px">
                        <tr>
                            <td class="ft-view" style="width: 100px">Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Expenses :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblExpenses" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Discount :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view" style="width: 100px">Grand Total :</td>
                            <td class="fv-view" style="width: 125px">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgProInvoice" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                    AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False"
                    AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                    OnNeedDataSource="rgProInvoice_NeedDataSource" OnDetailTableDataBind="rgProInvoice_DetailTableDataBind" OnPreRender="rgProInvoice_PreRender">
                    <ClientSettings>
                        <ClientEvents OnGridCreated="main.GridCreated" OnHierarchyExpanded="main.HierarchyExpanded" OnHierarchyCollapsed="main.HierarchyCollapsed"></ClientEvents>
                    </ClientSettings>
                    <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem" HierarchyLoadMode="Client">
                        <NoRecordsTemplate>
                            <table class="rgEmptyData">
                                <tr>
                                    <td>No records to display.</td>
                                </tr>
                            </table>
                        </NoRecordsTemplate>
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="ParentId,LineId,ItemId" Name="SubItems" Width="100%">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="LineId"></telerik:GridRelationFields>
                                </ParentTableRelation>
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No sub records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="20px"></telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                    <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="650px" />
                                    <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                    <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                    <telerik:GridTemplateColumn HeaderStyle-Width="80px"></telerik:GridTemplateColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                <ItemTemplate>
                                    <%#  Container.DataSetIndex + 1%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="InvoiceId" HeaderText="InvoiceId" HeaderStyle-Width="45px" Visible="False" />
                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                            <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Visible="False" />
                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                            <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="650px" />
                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="75px" />
                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                            <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 300px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Sales Invoice ?'); } else return;};"
                                OnClick="btnUpdate_Click" />
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
            <telerik:AjaxSetting AjaxControlID="rgProInvoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgProInvoice" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
