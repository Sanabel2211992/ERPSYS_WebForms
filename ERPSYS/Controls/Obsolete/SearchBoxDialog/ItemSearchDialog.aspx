<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/SearchBoxDialog/Dialog.Master" AutoEventWireup="true" CodeBehind="ItemSearchDialog.aspx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.ItemSearchDialog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
</asp:Content>
<asp:Content ID="cMain" ContentPlaceHolderID="dcphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function RowSelected(sender, args) {
                var master = $find("<%=rgvItems.ClientID %>").get_masterTableView();
                var row = master.get_dataItems()[master.get_selectedItems()[0]._itemIndexHierarchical];
                var oArg = new Object();
                oArg.id = master.getCellByColumnUniqueName(row, "ItemID").innerHTML;
                oArg.description = master.getCellByColumnUniqueName(row, "ItemDescription").innerHTML;
                oArg.cost = 0;
                oArg.price = 0;

                function getRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }

                var oWnd = getRadWindow();
                if (oArg.id && oArg.name) {
                    oWnd.close(oArg);
                } else {
                    alert("Somthing Missed");
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server" LoadingPanelID="lpLoading">
        <table width="750px">
            <tr>
                <td>
                    <telerik:RadDropDownList ID="ddlbrand" runat="server" Width="200"></telerik:RadDropDownList>
                </td>
                <td>
                    <telerik:RadDropDownList ID="ddlItemMainType" runat="server" Width="200"></telerik:RadDropDownList>
                </td>
                <td>
                    <telerik:RadDropDownList ID="ddlCategoryType" runat="server" Width="200"></telerik:RadDropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">N
                    <telerik:RadTextBox ID="txtItemName" runat="server" Width="600"></telerik:RadTextBox>
                    <telerik:RadButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click">
                        <Icon PrimaryIconCssClass="rbSearch" PrimaryIconLeft="4" PrimaryIconTop="3"></Icon>
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
        <table width="750px">
            <tr>
                <td>
                    <telerik:RadGrid ID="rgvItems" runat="server" ShowFooter="true" AutoGenerateColumns="False"
                        AllowPaging="True"
                        CellSpacing="0" GridLines="None" OnNeedDataSource="rgvItems_NeedDataSource" OnInit="rgvItems_Init">
                        <MasterTableView Width="750px" DataKeyNames="ItemID" ShowHeadersWhenNoRecords="true" TableLayout="Auto">
                            <NoRecordsTemplate>
                                <table width="100%" class="rgvEmptyData">
                                    <tr>
                                        <td>No Data Found
                                        </td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <Columns>
                                <telerik:GridBoundColumn DataField="ItemID" />
                                <telerik:GridClientSelectColumn HeaderStyle-Width="25px"></telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="150" ItemStyle-Width="150" />
                                <telerik:GridBoundColumn DataField="ItemDescription" HeaderText="Description" HeaderStyle-Width="200" ItemStyle-Width="200" />
                                <telerik:GridBoundColumn DataField="Brand" HeaderText="Brand" HeaderStyle-Width="75" ItemStyle-Width="75" />
                                <telerik:GridBoundColumn DataField="MainType" HeaderText="M Type" HeaderStyle-Width="75" ItemStyle-Width="75" />
                                <telerik:GridBoundColumn DataField="CategoryType" HeaderText="C Type" HeaderStyle-Width="75" ItemStyle-Width="75" />
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="True" />
                            <ClientEvents OnRowSelected="RowSelected" />
                            <Scrolling AllowScroll="True" ScrollHeight="430px" UseStaticHeaders="true" SaveScrollPosition="True"></Scrolling>
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <div>
            <asp:HiddenField ID="hfBrandId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfMainTypeId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfTypeId" runat="server" Value="-1" />
            <asp:HiddenField ID="hfPartNumber" runat="server" />
            <asp:HiddenField ID="hfsku" runat="server" />
            <asp:HiddenField ID="hfItemName" runat="server" />
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
