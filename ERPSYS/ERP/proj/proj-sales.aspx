<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="proj-sales.aspx.cs" Inherits="ERPSYS.ERP.proj.ProjSalesForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/HierarchyItems/PROJ/UCItemAdd.ascx" TagPrefix="uc1" TagName="UCItemAdd" %>


<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Project Information</legend>
                    <table class="tbl-view" style="width: 900px">
                        <tr>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                            <th class="ft-view" style="width: 125px"></th>
                            <th class="fv-view" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Start Date : </td>
                            <td class="fv-view">
                                <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">End Date : </td>
                            <td class="fv-view">
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Customer Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:HyperLink ID="hlnkCustomerName" ToolTip="preview Customer Information" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lbProjectName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="5">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="ft-view">Select Sales Type : </td>
                        <td class="fv-view">
                            <asp:RadioButtonList ID="rblSalesType" runat="server" RepeatDirection="Horizontal" Width="275px" AutoPostBack="true" OnSelectedIndexChanged="rblSalesType_SelectedIndexChanged">
                                <asp:ListItem Value="Product" Text="Product" Selected="True" />
                                <asp:ListItem Value="Sales" Text="Sales Invoice" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSales" runat="server">
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Sales Information </legend>
                        <table class="tbl-edit" style="width: 1100px">
                            <asp:Panel ID="pnlProduct" runat="server">
                                <tr>
                                    <td>
                                        <uc1:UCItemAdd runat="server" ID="UCItemAdd" />
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlSalesInvoiceSearch" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td class="ft-view" style="width: 125px">Sales Invoice # :</td>
                                                <td class="fv-view" style="width: 300px">
                                                    <telerik:RadSearchBox runat="server" ID="rsbSalesInvoice"
                                                        DataKeyNames="InvoiceId,InvoiceDate,CustomerName"
                                                        DataTextField="InvoiceNumber"
                                                        DataValueField="InvoiceId"
                                                        EnableAutoComplete="true"
                                                        ShowSearchButton="true"
                                                        Filter="StartsWith"
                                                        MaxResultCount="20"
                                                        Width="250px" OnDataSourceSelect="rsbSalesInvoice_DataSourceSelect" OnLoad="rsbSalesInvoice_Load" OnSearch="rsbSalesInvoice_Search">
                                                        <DropDownSettings Width="250px" />
                                                    </telerik:RadSearchBox>
                                                    <asp:HiddenField ID="hfItemID" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="pnlSalesInvoiceDetails" runat="server" Visible="false">
                                            <table>
                                                <tr>
                                                    <td class="ft-view" style="width: 125px">Invoice Date :</td>
                                                    <td class="fv-view" style="width: 175px">
                                                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="ft-view" style="width: 125px">Customer Name:</td>
                                                    <td class="fv-view" style="width: 425px">
                                                        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="grid-container no-bg">
                                                <%-- <h4>Sales Invoice Details</h4>--%>
                                                <telerik:RadGrid ID="rgSalesInvoice" runat="server" ShowStatusBar="True" AutoGenerateColumns="False" AllowMultiRowSelection="true" ShowFooter="True">
                                                    <MasterTableView DataKeyNames="LineId,ItemId" Name="MainItem">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbItem" runat="server" ValidationGroup="billqty" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" Checked="true" />
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="cbAllItems" runat="server" ValidationGroup="billqty" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle Width="25px"></HeaderStyle>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="45px">
                                                                <ItemTemplate>
                                                                    <%#  Container.DataSetIndex + 1%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="LineId" HeaderText="LineId" HeaderStyle-Width="45px" Visible="False" />
                                                            <telerik:GridBoundColumn DataField="ItemId" HeaderText="ItemId" HeaderStyle-Width="45px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="PartNumber" HeaderText="PartNumber" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="550px" />
                                                            <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="Quantity" HeaderText="M.R Qty" DataFormatString="{0:F2}" HeaderStyle-Width="75px" />
                                                            <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:F2}" HeaderStyle-Width="100px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="NetPrice" HeaderText="Price" DataFormatString="{0:F2}" HeaderStyle-Width="100px" />
                                                            <telerik:GridBoundColumn DataField="UomId" HeaderText="Unit" HeaderStyle-Width="45px" Display="False" />
                                                            <telerik:GridBoundColumn DataField="StatusId" HeaderText="StatusId" HeaderStyle-Width="25px" Display="False" />
                                                            <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                        <Selecting AllowRowSelect="True"></Selecting>
                                                    </ClientSettings>
                                                </telerik:RadGrid>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                    </fieldset>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" OnClick="btnSave_Click" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save the Sales ?'); } else return;};" /></td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rblSalesType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rblSalesType" />
                    <telerik:AjaxUpdatedControl ControlID="pnlSales" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
