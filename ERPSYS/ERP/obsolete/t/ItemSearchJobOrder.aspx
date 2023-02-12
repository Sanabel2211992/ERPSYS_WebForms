<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/DialogBox/Dialog.Master" AutoEventWireup="true" CodeBehind="ItemSearchJobOrder.aspx.cs" Inherits="ERPSYS.ERP.t.ItemSearchJobOrder" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }

        .auto-style1 {
            color: #151515;
            font-weight: 500;
            font-size: 13px;
            height: 25px;
        }

        .auto-style2 {
            font-size: 12px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="cMain" ContentPlaceHolderID="dcphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            var index;
            function RowMouseOver(sender, eventArgs) {
                index = eventArgs.get_itemIndexHierarchical();
            }

            function RowSelected() {
                var master = window.$find("<%=rgItems.ClientID %>").get_masterTableView();
                var row = master.get_dataItems()[index];
                var oArg = new Object();
                oArg.id = master.getCellByColumnUniqueName(row, "ItemId").innerHTML;
                oArg.displayname = master.getCellByColumnUniqueName(row, "DisplayName").innerHTML;
                oArg.partnumber = master.getCellByColumnUniqueName(row, "PartNumber").innerHTML;
                oArg.itemcode = master.getCellByColumnUniqueName(row, "ItemCode").innerHTML;
                oArg.description = master.getCellByColumnUniqueName(row, "Description").innerHTML;

                var oWnd = getRadWindow();
                if (oArg.id) {
                    oWnd.close(oArg);
                } else {
                    alert("Somthing Missed");
                    oWnd.close(oArg);
                }
            }

            function getRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                return oWindow;
            }
        </script>
    </telerik:RadCodeBlock>
    <table style="width: 810px">
        <tr>
            <td>
                <table class="tbl-inner" style="width: 800px">
                    <tr>
                        <td class="field-title" style="width: 115px"></td>
                        <td class="field-val" style="width: 175px"></td>
                        <td class="field-title" style="width: 115px"></td>
                        <td class="field-val" style="width: 175px"></td>
                        <td class="field-title" style="width: 115px"></td>
                        <td class="field-val" style="width: 105px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Description</td>
                        <td class="auto-style2" colspan="3">
                            <asp:TextBox ID="txtDescription" runat="server" Width="445px"></asp:TextBox>
                        </td>
                        <td class="auto-style1" colspan="2">
                            <asp:CheckBox ID="cbAvailableOnly" runat="server" Text="Only available items in stock" />
                        </td>
                    </tr>
                    <tr>
                        <td class="field-title">Part Number</td>
                        <td class="field-val">
                            <asp:TextBox ID="txtPartNumber" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="field-title">Catalog Number </td>
                        <td class="field-val">
                            <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="field-title" colspan="2">
                            <telerik:RadButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search">
                                <Icon PrimaryIconCssClass="rbSearch" PrimaryIconLeft="4" PrimaryIconTop="3" />
                            </telerik:RadButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                        <td class="field-title"></td>
                        <td class="field-val"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgItems" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="True" PageSize="35" Width="800px" Height="435px"
                                CellSpacing="0" GridLines="None" OnNeedDataSource="rgItems_NeedDataSource">
                                <MasterTableView DataKeyNames="ItemId" TableLayout="Fixed" ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ItemId" Display="False" />
                                        <telerik:GridBoundColumn DataField="DisplayName" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="Part Number" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <a href="javascript:RowSelected();"><%# Eval("PartNumber") %></a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="400px" />
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" SaveScrollPosition="true" UseStaticHeaders="True"></Scrolling>
                                    <ClientEvents OnRowMouseOver="RowMouseOver" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItems" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItems" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>