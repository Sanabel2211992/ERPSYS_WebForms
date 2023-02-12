<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainItemAdd.ascx.cs" Inherits="ERPSYS.Controls.HierarchyItems.SM.ProformaInvoice.UCMainItemAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel runat="server" ID="rapItem" LoadingPanelID="RadAjaxLoadingPanel">
    <telerik:RadScriptBlock runat="server" ID="rdbScripts">
        <script type="text/javascript">
            function Validate(sender, args) {
                if ($('#<%= hfItemID.ClientID %>').val() === "") {
                    args.IsValid = false;
                }
            }

            function OpenDialog() {
                var manager = window.$find("<%= rwmItem.ClientID %>");
                manager.open("../../Controls/DialogBox/SM/ProformaInvoice/ItemSearch.aspx", "rwItemSearch");
            }

            function OnItemClose(oWnd, args) {
                var arg = args.get_argument();
                if (arg) {
                    var id = arg.id,
                        displayname = arg.displayname,
                        description = arg.description,
                        partnumber = arg.partnumber,
                        itemcode = arg.itemcode,
                        price = arg.price,
                        stockqty = arg.stockqty;

                    $('#<%= hfItemID.ClientID %>').val(id);
                    $('#<%= txtItemDescription.ClientID %>').val(description);
                    $('#<%= txtItemPartNumber.ClientID %>').val(partnumber);
                    $('#<%= txtItemCode.ClientID %>').val(itemcode);
                    $('#<%= txtItemDescriptionAs.ClientID %>').val(description);
                    $('#<%= txtItemUnitPrice.ClientID %>').val(price);
                    $('#<%= txtStockQuantity.ClientID %>').val(stockqty);
                    $('#<%= txtItemProfit.ClientID %>').val(0);
                    $('#<%= txtItemDiscount.ClientID %>').val(0);
                    $('#<%= txtItemQuantity.ClientID %>').val(1);

                    var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                        inputElement = window.$telerik.$(searchBox.get_inputElement());
                    inputElement.val(displayname);
                }
            }

            function ClearFields() {
                $('#<%= hfItemID.ClientID %>').val("");

        <%--    $('#<%= ddlItemType.ClientID %>').val("");
            $('#<%= ddlItemCategory.ClientID %>').val("");
            $('#<%= ddlSubCategory.ClientID %>').val("");
            $('#<%= ddlBrand.ClientID %>').val("");--%>

                $('#<%= txtItemDescription.ClientID %>').val("");
                $('#<%= txtItemPartNumber.ClientID %>').val("");
                $('#<%= txtItemCode.ClientID %>').val("");
                $('#<%= txtItemDescriptionAs.ClientID %>').val("");
                $('#<%= txtItemUnitPrice.ClientID %>').val("");
                $('#<%= txtStockQuantity.ClientID %>').val("");
                $('#<%= txtItemProfit.ClientID %>').val("");
                $('#<%= txtItemDiscount.ClientID %>').val("");
                $('#<%= txtItemQuantity.ClientID %>').val("");

                var searchBox = window.$find("<%= rsbItem.ClientID %>"),
                    inputElement = window.$telerik.$(searchBox.get_inputElement());
                inputElement.val("");
            }

            function OpenStoreDialog() {
                if ($('#<%= hfItemID.ClientID %>').val() !== "") {
                    var itemId = $('#<%= hfItemID.ClientID %>').val();
                    var manager = window.$find("<%= rwmItemInfo.ClientID %>");
                    manager.open("../../Controls/DialogBox/INV/Stock/inv-item-qty.aspx?id=" + itemId, "rwmItemInfo");
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <table class="tbl-uc-gedit" style="width: 900px">
        <tr>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
            <th class="ft-gedit" style="width: 125px"></th>
            <th class="fv-gedit" style="width: 175px"></th>
        </tr>
        <tr>
            <td class="ft-gedit">Type :</td>
            <td class="fv-gedit" colspan="5">
                <asp:RadioButtonList ID="rblMainItemType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblMainItemType_SelectedIndexChanged" RepeatDirection="Horizontal" Width="250px">
                    <asp:ListItem Selected="True" Value="Single">Product</asp:ListItem>
                    <asp:ListItem Value="Group">Group Of Products</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <asp:Panel ID="pnlSingle" runat="server" Visible="True">
            <tr>
                <td style="width: 125px"></td>
                <td colspan="5">
                    <asp:CustomValidator ID="cvItem" runat="server" OnServerValidate="cvItem_ServerValidate" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="Please select a valid Product !!"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Search Criteria :</td>
                <td colspan="5">
                    <table style="width: 700px">
                        <tr>
                            <td class="ft-gedit" style="width: 175px">Type :</td>
                            <td class="ft-gedit" style="width: 175px">Category :</td>
                            <td class="ft-gedit" style="width: 175px">SubCategory :</td>
                            <td class="ft-gedit" style="width: 175px">Brand :</td>
                        </tr>
                        <tr>
                            <td class="fv-gedit">
                                <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="True" Width="150px">
                                </asp:DropDownList></td>
                            <td class="fv-gedit">
                                <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="True" Width="150px" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td class="fv-gedit">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" AutoPostBack="True" Width="150px">
                                </asp:DropDownList></td>
                            <td class="fv-gedit">
                                <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="True" Width="150px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Product Search :</td>
                <td class="fv-gedit" style="position: relative" colspan="5">
                    <telerik:RadSearchBox runat="server" ID="rsbItem"
                        DataKeyNames="ItemCode,PartNumber,Name,Description,UnitPrice,StockQuantity"
                        DataTextField="DisplayName"
                        DataValueField="ItemId"
                        EnableAutoComplete="true"
                        ShowSearchButton="true"
                        Filter="StartsWith"
                        MaxResultCount="20"
                        Width="650px" OnDataSourceSelect="rsbItem_DataSourceSelect" OnLoad="rsbItem_Load" OnSearch="rsbItem_Search">
                        <DropDownSettings Width="650px" />
                    </telerik:RadSearchBox>
                    <asp:HiddenField ID="hfItemID" runat="server" />
                    <div style="position: absolute; left: 660px; top: 5px">
                        <img alt="catalog" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_item_16.gif" onclick="OpenDialog(); return false;" />
                    </div>
                    <div style="position: absolute; left: 682px; top: 5px">
                        <img alt="clear" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_clear_16_16.png" onclick="ClearFields(); return false;" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Description :</td>
                <td class="fv-gedit read-only" colspan="4">
                    <asp:TextBox ID="txtItemDescription" runat="server" ReadOnly="True" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Part Number :</td>
                <td class="fv-gedit read-only">
                    <asp:TextBox ID="txtItemPartNumber" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
                <td class="ft-gedit">Catalog Number :</td>
                <td class="fv-gedit read-only">
                    <asp:TextBox ID="txtItemCode" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                </td>
                <td class="ft-gedit"></td>
                <td class="fv-gedit"></td>
            </tr>
            <tr>
                <td class="ft-gedit">Stock Quantity :</td>
                <td class="fv-gedit read-only" colspan="5">
                    <asp:TextBox ID="txtStockQuantity" runat="server" ReadOnly="True" Width="150px"></asp:TextBox>
                    <img src="../../ERP/resources/images/ico_store_16x16.png" width="16" height="16" alt="Store" title="Quantity Details" onclick="OpenStoreDialog(); return false;" />
                (Available Quantity in all stores)           
            </tr>
            <tr>
                <td class="ft-gedit">Show As :</td>
                <td class="fv-gedit" colspan="5">
                    <asp:TextBox ID="txtItemDescriptionAs" runat="server" Width="550px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvItemdescriptionAs" runat="server" ControlToValidate="txtItemDescriptionAs" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Unit Price :</td>
                <td class="fv-gedit">
                    <telerik:RadNumericTextBox ID="txtItemUnitPrice" runat="server" Width="100px" MinValue="0" MaxValue="999999">
                        <NumberFormat DecimalDigits="2"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemUnitPrice" runat="server" ControlToValidate="txtItemUnitPrice" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="ft-gedit">Quantity :</td>
                <td class="fv-gedit">
                    <telerik:RadNumericTextBox ID="txtItemQuantity" runat="server" Width="100px" MinValue="1" MaxValue="999999">
                        <NumberFormat DecimalDigits="0"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemQuantity" runat="server" ControlToValidate="txtItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="ft-gedit"></td>
                <td class="fv-gedit"></td>
            </tr>
            <tr>
                <td class="ft-gedit">Profit :</td>
                <td class="fv-gedit">
                    <telerik:RadNumericTextBox ID="txtItemProfit" runat="server" Width="100px" MinValue="0" MaxValue="1">
                        <NumberFormat DecimalDigits="2"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvItemProfit" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemProfit1" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvItemProfit2" runat="server" ControlToValidate="txtItemProfit" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
                </td>
                <td class="ft-gedit">Discount :</td>
                <td class="fv-gedit">
                    <telerik:RadNumericTextBox ID="txtItemDiscount" runat="server" Width="100px" MinValue="0" MaxValue="1">
                        <NumberFormat DecimalDigits="2"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvItemDiscount1" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                    <asp:CompareValidator ID="cvItemDiscount2" runat="server" ControlToValidate="txtItemDiscount" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="LessThan" Type="Double" ValueToCompare="1"></asp:CompareValidator>
                </td>
                <td class="ft-gedit"></td>
                <td class="fv-gedit"></td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlGroup" runat="server" Visible="False">
            <tr>
                <td class="ft-gedit">Description :</td>
                <td class="fv-gedit" colspan="4">
                    <asp:TextBox ID="txtGroupItemDescription" runat="server" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvGroupItemDescription" runat="server" ControlToValidate="txtGroupItemDescription" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="ft-gedit">Quantity :</td>
                <td class="fv-gedit">
                    <telerik:RadNumericTextBox ID="txtGroupItemQuantity" runat="server" Width="100px" MinValue="1" MaxValue="999999">
                        <NumberFormat DecimalDigits="0"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="rfvGroupItemQuantity" runat="server" ControlToValidate="txtGroupItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvGroupItemQuantity" runat="server" ControlToValidate="txtGroupItemQuantity" CssClass="val-error" Display="Dynamic" ValidationGroup="addMainItem" ErrorMessage="*" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="fv-gedit"></td>
            </tr>
        </asp:Panel>
    </table>
</telerik:RadAjaxPanel>
<table class="tbl-ucsearch" style="width: 700px">
    <tr>
        <td class="ft-gedit" style="width: 125px">&nbsp;</td>
        <td class="fv-gedit" style="width: 175px">&nbsp;</td>
        <td class="ft-gedit" style="width: 125px">&nbsp;</td>
        <td class="fv-gedit" style="width: 100px">&nbsp;</td>
        <td style="width: 175px" class="relative">
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="addMainItem" CssClass="m-add-save btn-Add-edit" CommandName="PerformInsert" />&nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False" CssClass="m-add-Cancel btn-Add-edit" CommandName="Cancel"></asp:Button>
        </td>
    </tr>
</table>
<telerik:RadWindowManager ID="rwmItem" ShowContentDuringLoad="false" VisibleStatusbar="false" ReloadOnShow="true" RenderMode="Lightweight" runat="server">
    <Windows>
        <telerik:RadWindow ID="rwItemSearch" RenderMode="Lightweight" runat="server" Modal="True"
            AutoSize="False" Width="835px" Height="550px" MaxWidth="835px" MaxHeight="550" OnClientClose="OnItemClose"
            Behaviors="Move, Close" Title="Catalog Product Search">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadWindowManager ID="rwmItemInfo" runat="server" Title="Stock Information" RenderMode="Lightweight" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true"
    Width="250px" Height="220px" Behaviors="Close" IconUrl="../../ERP/resources/images/ico_store_16x16.png" VisibleStatusbar="false">
    <Windows>
        <telerik:RadWindow ID="RadWindow1" runat="server"></telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
