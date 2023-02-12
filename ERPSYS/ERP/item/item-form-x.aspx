<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-form-x.aspx.cs" Inherits="ERPSYS.ERP.item.ItemFormX" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <%--
    <table class="tbl-main">
        <tr>
            <td>
                <telerik:RadTabStrip ID="rtsProduct" runat="server" CssClass="ts-view" MultiPageID="RadMultiPage1" Width="250px" Align="Justify" AutoPostBack="True" SelectedIndex="0" CausesValidation="false">
                    <Tabs>
                        <telerik:RadTab PageViewID="RadPageView1" Text="Product Information" Selected="True" />
                        <telerik:RadTab PageViewID="RadPageView2" Text="Product BOM" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="mp-view" RenderSelectedPageOnly="True" Width="100%">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                        <table class="tbl-edit" style="width: 945px">
                            <tr>
                                <th class="ft-edit" style="width: 140px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                                <th class="ft-edit" style="width: 140px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                                <th class="ft-edit" style="width: 140px"></th>
                                <th class="fv-edit" style="width: 175px"></th>
                            </tr>
                            <tr>
                                <td class="ft-edit">Product Type :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlItemType" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                                <td class="ft-edit" colspan="2">
                                    <asp:CheckBox ID="cbIsNonStandard" runat="server" Text="Non Standard Product" />
                                </td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Catalog Number :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtItemCode" runat="server" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtItemCode" runat="server" ControlToValidate="txtItemCode" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">Part Number :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtPartNumber" runat="server" Width="155px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtPartNumber" runat="server" ControlToValidate="txtPartNumber" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">
                                    <asp:CheckBox ID="cbBeSold" runat="server" Text="Can be Sold" />
                                </td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Product Name :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtItemName" runat="server" Width="480px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtItemName" runat="server" ControlToValidate="txtItemName" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">
                                    <asp:CheckBox ID="cbManufacture" runat="server" Text="Manufacture" />
                                </td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Product Name (AR):</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtItemNameAr" runat="server" Width="480px"></asp:TextBox>
                                </td>
                                <td class="ft-edit">
                                    <asp:CheckBox ID="cbHasBom" runat="server" Text="Enable BOM" />
                                </td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Product Show As :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtItemNameShowAs" runat="server" Width="480px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtItemNameShowAs" runat="server" ControlToValidate="txtItemNameShowAs" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">
                                    <asp:CheckBox ID="cbIsActive" runat="server" Text="Active" Checked="True" />
                                </td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit" colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Category :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">Sub Category :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlSubCategory" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSubCategory" runat="server" ControlToValidate="ddlSubCategory" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Brand :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlBrand" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlBrand" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">Unit of Measure :</td>
                                <td class="fv-edit">
                                    <asp:DropDownList ID="ddlUom" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvUOM" runat="server" ControlToValidate="ddlUom" ValidationGroup="save"
                                        ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True" InitialValue="-1"></asp:RequiredFieldValidator>
                                </td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Bar Code :</td>
                                <td class="fv-edit">
                                    <asp:TextBox ID="txtBarCode" runat="server" Width="140px"></asp:TextBox>
                                </td>
                                <td class="ft-edit">Unit Price :</td>
                                <td class="fv-edit">
                                    <telerik:RadNumericTextBox ID="txtUnitPrice" runat="server" Width="150px" MinValue="0" MaxValue="999999" EnableTheming="False">
                                        <NumberFormat DecimalDigits="2"></NumberFormat>
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">Remarks :</td>
                                <td class="fv-edit" colspan="3">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="465px"></asp:TextBox>
                                </td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                                <td class="ft-edit">&nbsp;</td>
                                <td class="fv-edit">&nbsp;</td>
                            </tr>
                        </table>
                        <div class="img-item-pos3">
                            <asp:Image ID="imgItem" runat="server" Height="150px" Width="150px" />
                            <table>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="fuItemImage" runat="server" Width="150px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RegularExpressionValidator ID="revUserImage" runat="server" ControlToValidate="fuItemImage" ErrorMessage="Only jpg, png, jpeg Files are allowed"
                                            ValidationExpression="(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$" Display="Dynamic" CssClass="val-error"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">
                                        <asp:CheckBox ID="cbRemoveImage" runat="server" Text="Remove picture" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <table class="tbl-op-center">
                            <tr>
                                <td>
                                    <asp:Label ID="lblBOM" runat="server" Visible="false" Text="To enable this content, save the product."></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="tbl-grid">
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="rgBom" runat="server" Visible="false" ShowStatusBar="true" ShowFooter="True" AutoGenerateColumns="False" GridLines="None"
                                        AllowSorting="True" RetainExpandStateOnRebind="True"
                                        OnNeedDataSource="rgBom_NeedDataSource" OnItemCommand="rgBom_ItemCommand"
                                        OnInsertCommand="rgBom_InsertCommand" OnUpdateCommand="rgBom_UpdateCommand" OnDeleteCommand="rgBom_DeleteCommand">
                                        <MasterTableView DataKeyNames="LineId,ItemBomId" CommandItemDisplay="Top">
                                            <NoRecordsTemplate>
                                                <table class="rgEmptyData">
                                                    <tr>
                                                        <td>No records to display.</td>
                                                    </tr>
                                                </table>
                                            </NoRecordsTemplate>
                                            <CommandItemSettings AddNewRecordText="Add Product" />
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
                                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
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
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
        <tr>
            <td>
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgBom">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgBom" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rtsProduct">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProduct" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProduct" />
                    <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager> --%>
</asp:Content>
