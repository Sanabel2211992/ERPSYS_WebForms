<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="proj-preview.aspx.cs" Inherits="ERPSYS.ERP.proj.ProjPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Window/Common/UCCustomer.ascx" TagName="UCCustomer" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc3" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function ClearCustomerText() {
            $('#<%= txtCustomerName.ClientID %>').val("");
        }

        function OnCustomerClosefun(oWnd, args) {
            var arg = args.get_argument();
            if (arg) {
                var displaycustomername = arg.name;
                var customerid = arg.id;
                $('#<%=hfCustomerId.ClientID%>').val(customerid)
                $('#<%= txtCustomerName.ClientID %>').val(displaycustomername);
            }
        }

        //function ChangeUrl(page, url) {
        //    if (typeof (history.pushState) != "undefined") {
        //        var obj = { Page: page, Url: url };
        //        history.pushState(obj, obj.Page, obj.Url);
        //    } else {
        //        alert("Browser does not support HTML5.");
        //    }
        //}
        //$(function () {
        //    $("#button1").click(function () {
        //        ChangeUrl('Page1', 'Page1.htm');
        //    });
        //    $("#button2").click(function () {
        //        ChangeUrl('Page2', 'Page2.htm');
        //    });
        //    $("#button3").click(function () {
        //        ChangeUrl('Page3', 'Page3.htm');
        //    });
        //});

        //function ChangeUrl(url) {
        //    if (typeof (history.pushState) != "undefined") {
        //        var obj = { Url: url };
        //        history.pushState(obj, obj.Url);
        //    } else {
        //        alert("Browser does not support HTML5.");
        //    }
        //}
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
<%--    <input type="button" value="Page1" onclick="ChangeUrl('Page1.htm');" />--%>
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Project Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">End Date : </td>
                            <td class="fv-edit">
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit">Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Date :</td>
                            <td class="fv-edit">
                                <uc1:UCDatePickerX ID="UCDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Customer Name :</td>
                            <td class="fv-edit" colspan="5">
                                <asp:TextBox ID="txtCustomerName" runat="server" Width="350px"></asp:TextBox>
                                <uc2:UCCustomer ID="WinCustomer" runat="server" />
                                <img src="../../Controls/resources/images/ico_clear_16_16.png" alt="clear" onclick="ClearCustomerText(); return false;" />
                                <asp:HiddenField ID="hfCustomerId" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtProjectName" runat="server" Width="450px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvProjectName" runat="server" ControlToValidate="txtProjectName"
                                    Enabled="false" ErrorMessage="*" CssClass="val-error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Remarks :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fs-edit btn-save btn-save-sm-so" ValidationGroup="save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Sales Order information ?'); } else return;};"
                            OnClick="btnUpdate_Click" />
                    </div>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Value="back" Text="Back" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="55px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="edit" Value="edit" Text="Edit" ImageUrl="~/ERP/resources/images/toolbar/ico_edit.png" Width="50px" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton runat="server" CommandName="detailsreport" Value="detailsreport" Text="print all details" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="130px" />
                        <telerik:RadToolBarButton runat="server" CommandName="summaryreport" Value="summaryreport" Text="print summary" ImageUrl="~/ERP/resources/images/toolbar/ico_print.png" Width="120px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTabStrip ID="rtsProject" runat="server" RenderMode="Lightweight" MultiPageID="rmpProject" Width="100%" AutoPostBack="True" SelectedIndex="0" Align="Left" Skin="MetroTouch">
                    <Tabs>
                        <telerik:RadTab PageViewID="rpvProjectPurchaseList" Text="Purchases" Selected="True" Width="110px" />
                        <telerik:RadTab PageViewID="rpvProjectSalesList" Text="Sales" Width="110px" />
                        <telerik:RadTab PageViewID="rpvProjectExpenseList" Text="Expenses" Width="110px" />
                        <telerik:RadTab PageViewID="rpvProjectVisitsList" Text="Visits" Width="110px" />
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadMultiPage ID="rmpProject" runat="server" RenderSelectedPageOnly="True" Width="100%" SelectedIndex="0">
                    <telerik:RadPageView ID="rpvProjectPurchaseList" runat="server" Selected="true">
                        <table class="tbl-link">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnAddPurchase" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAddPurchase_Click">Add New Purchase</asp:LinkButton></td>
                            </tr>
                        </table>
                        <telerik:RadGrid ID="rgProjectPurchaseList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False"
                            OnNeedDataSource="rgProjectPurchaseList_NeedDataSource" OnUpdateCommand="rgProjectPurchaseList_UpdateCommand" OnDeleteCommand="rgProjectPurchaseList_DeleteCommand">
                            <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="PurchaseId,Quantity,UnitPrice" EditMode="InPlace">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No Data Found
                                            </td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="PurchaseId" HeaderText="ID" Display="False" />
                                    <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" ReadOnly="true" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" ReadOnly="true" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" ReadOnly="true" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total Price" ReadOnly="true" Aggregate="Sum" HeaderStyle-Width="100px" DataFormatString="{0:N}" />
                                    <telerik:GridTemplateColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtQuantity" DisplayText='<%#Eval("Quantity") %>' runat="server" Width="70px" MinValue="1" MaxValue="999999">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="UnitPrice" HeaderText="Unit Price" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtUnitPrice" DisplayText='<%#Eval("UnitPrice") %>' runat="server" Width="70px" MinValue="0" MaxValue="999999">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridEditCommandColumn HeaderStyle-Width="20px" />
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this product ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvProjectSalesList" runat="server">
                        <table class="tbl-link">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnAddSales" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAddSales_Click">Add New Sales</asp:LinkButton></td>
                            </tr>
                        </table>
                        <telerik:RadGrid ID="rgProjectSalesList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False"
                            OnNeedDataSource="rgProjectSalesList_NeedDataSource" OnUpdateCommand="rgProjectSalesList_UpdateCommand" OnDeleteCommand="rgProjectSalesList_DeleteCommand">
                            <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="SalesId,Quantity,UnitPrice" EditMode="InPlace">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No Data Found
                                            </td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="SalesId" HeaderText="ID" Display="False" />
                                    <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" ReadOnly="true" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" ReadOnly="true" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" ReadOnly="true" HeaderStyle-Width="500px" />
                                    <telerik:GridBoundColumn DataField="TotalPrice" HeaderText="Total Price" ReadOnly="true" Aggregate="Sum" HeaderStyle-Width="100px" DataFormatString="{0:N}" />
                                    <telerik:GridTemplateColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtQuantity" DisplayText='<%#Eval("Quantity") %>' runat="server" Width="70px" MinValue="1" MaxValue="999999">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="UnitPrice" HeaderText="Unit Price" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtUnitPrice" DisplayText='<%#Eval("UnitPrice") %>' runat="server" Width="70px" MinValue="0" MaxValue="999999">
                                                <NumberFormat DecimalDigits="0" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridEditCommandColumn HeaderStyle-Width="20px" />
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this product ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvProjectExpenseList" runat="server">
                        <telerik:RadGrid ID="rgProjectExpenseList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False"
                            OnNeedDataSource="rgProjectExpenseList_NeedDataSource" OnItemCommand="rgProjectExpenseList_ItemCommand"
                            OnInsertCommand="rgProjectExpenseList_InsertCommand" OnUpdateCommand="rgProjectExpenseList_UpdateCommand" OnDeleteCommand="rgProjectExpenseList_DeleteCommand">
                            <MasterTableView DataKeyNames="ExpenseLineId" CommandItemDisplay="Top">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No records to display.</td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <CommandItemSettings AddNewRecordText="Add New Expense" />
                                <EditFormSettings EditFormType="WebUserControl">
                                    <EditColumn UniqueName="EditCommand" />
                                </EditFormSettings>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ExpenseLineId" HeaderText="ID" Display="False" />
                                    <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="700px" />
                                    <telerik:GridBoundColumn DataField="Amount" HeaderText="Amount" Aggregate="Sum" DataFormatString="{0:F2}" HeaderStyle-Width="150px" />
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommand">
                                        <HeaderStyle Width="20px" />
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this expense ?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommand">
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="rpvProjectVisitsList" runat="server">
                        <table class="tbl-link">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnAddVisit" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAddVisit_Click">Add New Visit</asp:LinkButton></td>
                            </tr>
                        </table>
                        <telerik:RadGrid ID="rgProjectVisitList" runat="server" RenderMode="Lightweight" ShowFooter="true" AllowPaging="True" AllowSorting="False" Width="100%" AutoGenerateColumns="False"
                            OnNeedDataSource="rgProjectVisitList_NeedDataSource" OnUpdateCommand="rgProjectVisitList_UpdateCommand" OnDeleteCommand="rgProjectVisitList_DeleteCommand">
                            <MasterTableView ShowHeadersWhenNoRecords="true" DataKeyNames="VisitId" EditMode="InPlace">
                                <NoRecordsTemplate>
                                    <table class="rgEmptyData">
                                        <tr>
                                            <td>No Data Found
                                            </td>
                                        </tr>
                                    </table>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="VisitId" HeaderText="ID" Display="False" />
                                    <telerik:GridBoundColumn DataField="ProjectId" HeaderText="ID" Display="False" />
                                    <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                        <ItemTemplate>
                                            <%#  Container.DataSetIndex + 1%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridDateTimeColumn DataField="Date" HeaderText="Visit Date" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="125px" />
                                    <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-Width="300px" />
                                    <telerik:GridBoundColumn DataField="Remarks" HeaderText="Remarks" HeaderStyle-Width="400px" />
                                    <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    <telerik:GridEditCommandColumn HeaderStyle-Width="60px" />
                                    <telerik:GridButtonColumn ConfirmText="Are you sure you want to delete this visit?" ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteColumn1">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="MyImageButton"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true" />
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rtsProject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rtsProject" />
                    <telerik:AjaxUpdatedControl ControlID="rmpProject" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
