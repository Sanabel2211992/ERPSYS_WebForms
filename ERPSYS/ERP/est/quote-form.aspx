<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="quote-form.aspx.cs" Inherits="ERPSYS.ERP.est.QuoteForm" %>

<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/ComboBox/SM/UCCustomerList.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "InitClone") {
                args.set_cancel(!confirm("Are you sure you want to copy this product with all BOQ ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Quotation Information</legend>
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
                            <td class="ft-edit">Quote # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit" style="width: 125px">Status :</td>
                            <td class="fv-edit" style="width: 175px">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer Name :</td>
                            <td class="fv-edit" colspan="3">
                                <uc1:UCCustomerList ID="UCCustomer" runat="server" ValidationGroup="save" />
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit" style="width: 125px">Quote Date :</td>
                            <td class="fv-edit" style="width: 175px">
                                <uc2:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">Sales Engineer :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlSalesEngineer" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Inquiry Date :</td>
                            <td class="fv-edit">
                                <uc2:UCDatePickerX ID="UCInquiryDate" runat="server" />
                            </td>
                            <td class="ft-edit">Inquiry # :</td>
                            <td class="fv-edit">
                                <asp:TextBox ID="txtInquiryNumber" Width="142px" runat="server"></asp:TextBox>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Template :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlCompanyCode" runat="server" Width="160px"></asp:DropDownList>
                            </td>
                            <td class="ft-edit">Currency View :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlCurrencyView" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
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
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-es-qut" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Quote information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>

        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="remarks" Value="remarks" Text="Terms & Conditions" ImageUrl="~/ERP/resources/images/toolbar/ico_order.png" Width="190px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbGroupOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbGroupOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="addg" Value="addg" Text="Add Products" ImageUrl="~/ERP/resources/images/toolbar/ico_add.png" Width="110px" />
                        <telerik:RadToolBarButton runat="server" CommandName="updateg" Value="updateg" Text="Update Products" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="135px" />
                        <telerik:RadToolBarButton runat="server" CommandName="replaceg" Value="replaceg" Text="Replace Products" ImageUrl="~/ERP/resources/images/toolbar/ico_replace.png" Width="135px" />
                        <telerik:RadToolBarButton runat="server" CommandName="deleteg" Value="deleteg" Text="Delete Products" ImageUrl="~/ERP/resources/images/toolbar/ico_delete.png" Width="135px" />
                        <telerik:RadToolBarButton runat="server" CommandName="pd" Value="pd" Text="Profit / Discount" ImageUrl="~/ERP/resources/images/toolbar/ico-calculator.png" Width="135px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Quotation Details</h3>
                    <telerik:RadGrid ID="rgQuote" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None"
                        AllowMultiRowSelection="False" AllowPaging="False" AllowSorting="False" RetainExpandStateOnRebind="True"
                        AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                        OnDetailTableDataBind="rgQuote_DetailTableDataBind" OnItemCommand="rgQuote_ItemCommand"
                        OnInsertCommand="rgQuote_InsertCommand" OnUpdateCommand="rgQuote_UpdateCommand"
                        OnNeedDataSource="rgQuote_NeedDataSource" OnPreRender="rgQuote_PreRender" OnDeleteCommand="rgQuote_DeleteCommand" OnItemCreated="rgQuote_ItemCreated" OnItemDataBound="rgQuote_ItemDataBound">
                        <MasterTableView DataKeyNames="QuoteLineId,LineSeqId,ItemId" Name="MainItem" CommandItemDisplay="Top">
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <CommandItemSettings AddNewRecordText="Add Product" />
                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ParentId,QuoteLineId,ItemId" Name="SubItems"
                                    ShowFooter="true" AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowAutomaticDeletes="False"
                                    CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <telerik:RadToolBar ID="rtbGrid" runat="server" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" Width="100%" OnClientButtonClicking="onClientButtonClicking" AutoPostBack="true">
                                            <Items>
                                                <telerik:RadToolBarButton Text="Add Sub Product" CommandName="InitInsert" ImageUrl="~/ERP/resources/images/toolbar/ico-add.png">
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton Text="Copy This Product" CommandName="InitClone" ImageUrl="~/ERP/resources/images/toolbar/ico_clone.png">
                                                </telerik:RadToolBarButton>
                                                <%-- <telerik:RadToolBarButton Text='<%# rgQuote.MasterTableView.DetailTables.Count %>'>--%>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </CommandItemTemplate>
                                    <NoRecordsTemplate>
                                        <table class="rginnerEmptyData">
                                            <tr>
                                                <td>No records to display.</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <EditFormSettings EditFormType="WebUserControl">
                                        <EditColumn UniqueName="EditCommandSubColumn">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <ParentTableRelation>
                                        <telerik:GridRelationFields DetailKeyField="ParentId" MasterKeyField="QuoteLineId"></telerik:GridRelationFields>
                                    </ParentTableRelation>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="10px"></telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                        <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                        <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                        <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="550px" />
                                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="Profit" HeaderText="Profit" DataFormatString="{0:F2}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F2}" HeaderStyle-Width="50px" />
                                        <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Net Price" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                        <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="75px" />
                                        <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandSubColumn">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridEditCommandColumn>
                                        <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~/Controls/resources/images/grid/Replace.png" CommandName="Edit" CommandArgument="Replace" Text="Replace" UniqueName="ReplaceColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn ConfirmText="Delete this Product?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                            <HeaderStyle Width="20px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <EditFormSettings EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommandMainColumn">
                                </EditColumn>
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="QuoteId" HeaderText="QuoteId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="QuoteLineId" HeaderText="QuoteLineId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="LineSeqId" HeaderText="LineSeqId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ParentId" HeaderText="ParentId" HeaderStyle-Width="45px" Visible="False" />
                                <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="DescriptionAs" HeaderText="Description" HeaderStyle-Width="670px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:F0}" HeaderStyle-Width="50px" />
                                <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:N}" HeaderStyle-Width="100px" />
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandMainColumn">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                    <ItemStyle CssClass="MyImageButton"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this Product?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
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
            <td>
                <fieldset class="fs-inner" style="width: 325px">
                    <legend class="fs-inner-legend">Total Summary</legend>
                    <asp:Panel ID="pnlTotalSummary" runat="server">
                        <table class="tbl-inner" style="width: 325px">
                            <tr>
                                <td class="ft-edit-sum" style="width: 125px"></td>
                                <td class="fv-edit-sum" style="width: 125px"></td>
                                <td style="width: 75px"></td>
                            </tr>
                            <tr>
                                <td class="ft-edit-sum">Sub Total</td>
                                <td class="fv-edit-sum read-only" colspan="2">
                                    <telerik:RadNumericTextBox ID="txtSubTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit-sum">Discount <span style="font-size: 8pt">(Amount)</span></td>
                                <td class="fv-edit-sum read-only" colspan="2">
                                    <telerik:RadNumericTextBox ID="txtDiscount" runat="server" Width="100px" Value="0" MinValue="0" MaxValue="999999">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rvfTotalDiscoun" runat="server" CssClass="val-error" ValidationGroup="applyChanges" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDiscount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvTotalDiscount" runat="server" ControlToValidate="txtDiscount" ValidationGroup="applyChanges" CssClass="val-error" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0" SetFocusOnError="True"></asp:CompareValidator>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlSalesTax" Visible="False" runat="server">
                                <tr>
                                    <td class="ft-edit-sum">Sales Tax<span style="font-size: 8pt"> (
                                    <asp:Label ID="lblSalesTaxValue" runat="server"></asp:Label>
                                        )</span></td>
                                    <td class="fv-edit-sum read-only">
                                        <telerik:RadNumericTextBox ID="txtSalesTax" runat="server" ReadOnly="True" Width="100px" Value="0" MinValue="0">
                                            <NumberFormat DecimalDigits="2"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </td>
                                    <td class="fv-edit-sum">
                                        <asp:CheckBox ID="cbIgnoreTax" Text="Ignore Tax" Font-Size="8" runat="server" AutoPostBack="True" OnCheckedChanged="cbIgnoreTax_CheckedChanged" />
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td class="ft-edit-sum">Grand Total</td>
                                <td class="fv-edit-sum read-only">
                                    <telerik:RadNumericTextBox ID="txtGrandTotal" runat="server" Width="100px" Value="0" ReadOnly="True">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnApplyChanges" runat="server" Width="70px" ValidationGroup="applyChanges" Text="Apply" OnClick="btnApplyChanges_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 100px">
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
            <telerik:AjaxSetting AjaxControlID="rgQuote">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgQuote" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="rtbGroupOperations" />
                    <telerik:AjaxUpdatedControl ControlID="pnlTotalSummary" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbIgnoreTax">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlTotalSummary" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApplyChanges">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlTotalSummary" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
