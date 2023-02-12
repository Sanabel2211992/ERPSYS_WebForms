<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/SearchBoxDialog/Dialog.Master" AutoEventWireup="true" CodeBehind="SupplierSearchDialog.aspx.cs" Inherits="ERPSYS.Controls.SearchBoxDialog.SupplierSearchDialog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
</asp:Content>
<asp:Content ID="cMain" ContentPlaceHolderID="dcphMain" runat="server">
    <telerik:RadCodeBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function RowSelected(sender, args) {
                var master = $find("<%=rgvSupplier.ClientID %>").get_masterTableView();
                var row = master.get_dataItems()[master.get_selectedItems()[0]._itemIndexHierarchical];
                var oArg = new Object();
                oArg.id = master.getCellByColumnUniqueName(row, "SupplierId").innerHTML;
                oArg.name = master.getCellByColumnUniqueName(row, "SupplierName").innerHTML;

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
        <table width="650">
            <tr>
                <td>
                    <table width="100%">

                        <tr>
                            <td>
                                <asp:TextBox ID="txtSupplierName" Width="550" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="75" OnClick="btnSearch_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgvSupplier" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="True" Width="645px"
                        CellSpacing="0" GridLines="None" OnNeedDataSource="rgvSupplier_NeedDataSource" OnItemCreated="rgvSupplier_ItemCreated" OnInit="rgvSupplier_Init">
                        <MasterTableView Name="Master" Width="100%" ClientDataKeyNames="SupplierId" DataKeyNames="SupplierId" ShowHeadersWhenNoRecords="true">
                            <NoRecordsTemplate>
                                <table width="100%" class="rgvEmptyData">
                                    <tr>
                                        <td>No Data Found
                                        </td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <Columns>
                                <telerik:GridBoundColumn DataField="SupplierId" />
                                <telerik:GridClientSelectColumn HeaderStyle-Width="25px"></telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="SupplierName" UniqueName="SupplierName" HeaderText="Name" HeaderStyle-Width="250px" ItemStyle-Width="260px" />
                                <telerik:GridBoundColumn DataField="SupplierNameAr" HeaderText="Name (AR)" HeaderStyle-Width="250px" ItemStyle-Width="260px" />
                                <telerik:GridBoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Width="80px" ItemStyle-Width="100px" />
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="True" />
                            <ClientEvents OnRowSelected="RowSelected" />
                            <Scrolling AllowScroll="True" ScrollHeight="305px" UseStaticHeaders="true" SaveScrollPosition="True"></Scrolling>
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>
