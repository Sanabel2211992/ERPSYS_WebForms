<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/DialogBox/Dialog.Master" AutoEventWireup="true" CodeBehind="inv-item-qty.aspx.cs" Inherits="ERPSYS.Controls.DialogBox.INV.Stock.InvItemQty" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="cMain" ContentPlaceHolderID="dcphMain" runat="server">
    <table class="tbl-grid" style="width: 253px">
        <tr>
            <td>
                <telerik:RadGrid ID="rgInventoryQty" runat="server" AllowPaging="False" Width="253px" AutoGenerateColumns="False" OnNeedDataSource="rgInventoryQty_NeedDataSource">
                    <MasterTableView ShowHeadersWhenNoRecords="true">
                        <NoRecordsTemplate>
                            <table class="rgEmptyData">
                                <tr>
                                    <td>No records to display.</td>
                                </tr>
                            </table>
                        </NoRecordsTemplate>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Store Name" HeaderStyle-Width="150px" />
                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="100px" DataFormatString="{0:F2}" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgInventoryQty">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgInventoryQty" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
