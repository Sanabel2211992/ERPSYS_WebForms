<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="inv-form.aspx.cs" Inherits="ERPSYS.ERP.t.env_form" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/HierarchyItems/ITEM/BOM/UCItemAdd.ascx" TagName="UCItemAdd" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <telerik:RadScriptBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">

            function OpenItemSearchDialog() {
                var manager = window.$find("<%= rwmItemSearch.ClientID %>");
                manager.open("ItemSearch.aspx", "rwmItemSearch");
            }

            function OpenItemJobOrderDialog() {
                if ($('#<%= hfItemSearchId.ClientID %>').val() !== "") {
                    var manager = window.$find("<%= rwmItemJobOrder.ClientID %>");
                    manager.open("ItemSearchJobOrder.aspx", "rwmItemJobOrder");
                }
            }

            function OnItemSearchClosefun(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var id = arg.id,
                        displayname = arg.displayname,
                        description = arg.description,
                        partnumber = arg.partnumber,
                        itemcode = arg.itemcode;

                    $('#<%= hfItemSearchId.ClientID %>').val(id);
                    $('#<%= txtItemSearch.ClientID %>').val(description);
                }
            }

            function OnItemJobOrderClosefun(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var id = arg.id,
                        displayname = arg.displayname,
                        description = arg.description,
                        partnumber = arg.partnumber,
                        itemcode = arg.itemcode;

                    $('#<%= hftemJobOrder.ClientID %>').val(id);
                    $('#<%= txtItemJobOrder.ClientID %>').val(description);

                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset>
                    <legend class="fs-inner-legend">Job Order Convert</legend>
                    <table class="tbl-edit" style="width: 945px">
                        <tr>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 175px"></td>
                            <td class="ft-edit" style="width: 140px"></td>
                            <td class="fv-edit" style="width: 175px"></td>
                            <td class="ft-edit" style="width: 40px"></td>
                            <td class="fv-edit" style="width: 275px"></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="field-title">Select Item From Stock :</td>
                            <td colspan="2" class="field-val">
                                <asp:TextBox ID="txtItemSearch" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <img src="../../Controls/resources/images/ico_item_16.gif" onclick="OpenItemSearchDialog(); return false;" />&nbsp;&nbsp;
                            </td>
                            <td class="field-title">Quantity : 
                                <asp:TextBox ID="txtQuantityItem" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="field-title">Select Item to Convert From Job Order :</td>
                            <td colspan="2" class="field-val">
                                <asp:TextBox ID="txtItemJobOrder" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                <img src="../../Controls/resources/images/ico_item_16.gif" onclick="OpenItemJobOrderDialog(); return false;" style="height: 16px; width: 16px" />&nbsp;&nbsp;
                            </td>
                            <td class="field-title">Quantity : 
                                <asp:TextBox ID="txtQuantityJobOrder" runat="server" Width="100px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UCItemAdd ID="UCItemAddMaterial" ValidationGroup="add" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-uc-op" style="width: 100px">
                    <tr>
                        <td>
                            <asp:Button ID="btnAddItem" runat="server" ValidationGroup="add" Text="Add Product" CssClass="btn-uc-bom save-bom" OnClick="btnAddItem_Click" />
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
                            <telerik:RadGrid ID="rgBom" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                                AllowSorting="True" RetainExpandStateOnRebind="True" OnNeedDataSource="rgBom_NeedDataSource"
                                OnItemCommand="rgBom_ItemCommand" OnUpdateCommand="rgBom_UpdateCommand" OnDeleteCommand="rgBom_DeleteCommand">
                                <MasterTableView DataKeyNames="LineId,ItemBomId">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <EditFormSettings EditFormType="WebUserControl">
                                        <EditColumn UniqueName="EditCommand"></EditColumn>
                                    </EditFormSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1 %>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="LineId" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="ItemBomId" HeaderText="ItemBomId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="670px" />
                                        <telerik:GridBoundColumn DataField="Uom" HeaderText="Unit" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="SellingPrice" HeaderText="Unit Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>
                                        <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this item ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <asp:HiddenField ID="hfItemSearchId" runat="server" />
    <telerik:RadWindowManager ID="rwmItemSearch" runat="server" Title="Items Search" OnClientClose="OnItemSearchClosefun" ShowContentDuringLoad="false" ReloadOnShow="true"
        Width="810px" Height="550px" Behaviors="Close" IconUrl="../../Controls/resources/images/ico_item_16.gif" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwItemSearch" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <asp:HiddenField ID="hftemJobOrder" runat="server" />
    <telerik:RadWindowManager ID="rwmItemJobOrder" runat="server" Title="Item Job Order Search" OnClientClose="OnItemJobOrderClosefun" ReloadOnShow="true" ShowContentDuringLoad="false"
        Width="810px" Height="550px" Behaviors="Close" IconUrl="../../Controls/resources/images/ico_item_16.gif" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="rwItemJobOrder" runat="server"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>