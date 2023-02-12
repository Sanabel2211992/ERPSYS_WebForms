<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="m-trans-create.aspx.cs" Inherits="ERPSYS.ERP.man.MaterialTransferCreate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Order Information</legend>
                    <table class="tbl-edit" style="width: 1120px">
                        <tr>
                            <th class="ft-edit" style="width: 110px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 110px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 110px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                            <th class="ft-edit" style="width: 110px"></th>
                            <th class="fv-edit" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Job Order # :</td>
                            <td class="fv-edit">
                                <asp:HyperLink ID="hlnkJobOrderNumber" runat="server" CssClass="visit-link" Enabled="False"></asp:HyperLink>
                            </td>
                            <td class="ft-edit">Order # :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>

                            <td class="ft-edit">Order Type :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblOrderType" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit">Order Status :</td>
                            <td class="fv-edit">
                                <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Transfer Type :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:Label ID="lblTransferType" runat="server"></asp:Label>
                            </td>

                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">
                                &nbsp;</td>
                            <td class="ft-edit">&nbsp;</td>
                            <td class="fv-edit">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Project Name :</td>
                            <td class="fv-edit" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                            <td class="ft-edit"></td>
                            <td class="fv-edit"></td>
                        </tr>
                        <tr>
                            <td class="field-title">Remarks</td>
                            <td class="field-val" colspan="7">
                                <asp:TextBox ID="txtRemarks" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <div class="grid-container no-bg">
                    <h3>Products List</h3>
                    <telerik:RadGrid ID="rgProductionItems" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="None" AllowPaging="False" AllowSorting="False" OnNeedDataSource="rgProductionItems_NeedDataSource">
                        <MasterTableView>
                            <NoRecordsTemplate>
                                <table class="rgEmptyData">
                                    <tr>
                                        <td>No records to display.</td>
                                    </tr>
                                </table>
                            </NoRecordsTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <%#  Container.DataSetIndex + 1%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="PartNumber" HeaderText="Part Number" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Catalog No" HeaderStyle-Width="175px" />
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" HeaderStyle-Width="500px" />
                                <telerik:GridBoundColumn DataField="Category" HeaderText="Category" HeaderStyle-Width="100px" />
                                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="75px" DataFormatString="{0:F0}" />
                                <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Continue" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};"
                                OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" OnClick="btnCancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

