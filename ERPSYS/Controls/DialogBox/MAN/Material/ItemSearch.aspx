<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/DialogBox/Dialog.Master" AutoEventWireup="true" CodeBehind="ItemSearch.aspx.cs" Inherits="ERPSYS.Controls.DialogBox.MAN.Material.ItemSearch" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
        }

        .rgAdvPart {
            display: none;
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
                oArg.partnumber = master.getCellByColumnUniqueName(row, "PartNumber").innerHTML.replace(/&nbsp;/g, '');
                oArg.itemcode = master.getCellByColumnUniqueName(row, "ItemCode").innerHTML.replace(/&nbsp;/g, '');
                oArg.description = master.getCellByColumnUniqueName(row, "Description").innerHTML;
                oArg.quantity = master.getCellByColumnUniqueName(row, "StockQuantity").innerHTML;

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
                        <td class="field-title">Description</td>
                        <td class="field-val" colspan="3">
                            <asp:TextBox ID="txtDescription" runat="server" Width="445px"></asp:TextBox>
                        </td>
                        <td class="field-title" colspan="2">&nbsp;</td>
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
                                        <telerik:GridBoundColumn DataField="UomId" Display="False" />
                                        <telerik:GridBoundColumn DataField="StockQuantity" Display="False"/>
                                        <telerik:GridTemplateColumn HeaderText="Part Number" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <a href="javascript:RowSelected();"><%# Eval("PartNumber") %></a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="425px" />
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
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItems" UpdatePanelCssClass="" LoadingPanelID="ralp" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgItems">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgItems" UpdatePanelCssClass="" LoadingPanelID="ralp" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
