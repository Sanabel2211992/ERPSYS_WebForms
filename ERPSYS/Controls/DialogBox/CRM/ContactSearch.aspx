<%@ Page Title="" Language="C#" MasterPageFile="~/Controls/DialogBox/Dialog.Master" AutoEventWireup="true" CodeBehind="ContactSearch.aspx.cs" Inherits="ERPSYS.Controls.DialogBox.CRM.ContactSearch" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="CHeader" ContentPlaceHolderID="dcpHead" runat="server">
    <style type="text/css">
        html {
            overflow: hidden;
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
                var master = window.$find("<%=rgContact.ClientID %>").get_masterTableView();
                var row = master.get_dataItems()[index];
                var oArg = new Object();
                oArg.id = master.getCellByColumnUniqueName(row, "ContactId").innerHTML;
                oArg.name = master.getCellByColumnUniqueName(row, "ContactName").innerHTML;

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
                <table class="tbl-inner" style="width: 600px">
                    <tr>
                        <td class="field-title" style="width: 125px"></td>
                        <td class="field-val" style="width: 175px"></td>
                        <td class="field-title" style="width: 125px"></td>
                        <td class="field-val" style="width: 175px"></td>
                    </tr>
                    <tr>
                        <td class="field-title">Name :</td>
                        <td class="field-val" colspan="2">
                            <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
                        </td>
                        <td class="field-title">
                            <telerik:RadButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search">
                                <Icon PrimaryIconCssClass="rbSearch" PrimaryIconLeft="4" PrimaryIconTop="3" />
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgContact" runat="server" ShowFooter="false" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" Width="550px" Height="180px" CellSpacing="0" GridLines="None" OnNeedDataSource="rgContact_NeedDataSource">
                                <MasterTableView DataKeyNames="ContactId" TableLayout="Fixed" ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ContactId" Display="False" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ContactName" Display="false" />
                                        <telerik:GridTemplateColumn HeaderText="Name" HeaderStyle-Width="400">
                                            <ItemTemplate>
                                                <a href="javascript:RowSelected();"><%# Eval("ContactName") %></a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Width="125px" />
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="true"></Scrolling>
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
            <telerik:AjaxSetting AjaxControlID="rgContact">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgContact" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgContact" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
