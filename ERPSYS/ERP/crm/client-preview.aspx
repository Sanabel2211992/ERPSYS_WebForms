<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="client-preview.aspx.cs" Inherits="ERPSYS.ERP.crm.ClientPreview" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Client Information</legend>
                    <table class="tbl-view" style="width: 1160px">
                        <tr>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                            <th class="ft-view" style="width: 120px"></th>
                            <th class="fv-view" style="width: 170px"></th>
                        </tr>
                        <tr>
                            <td class="ft-view">Client Name :</td>
                            <td colspan="3" class="fv-view">
                                <asp:Label ID="lblClientName" runat="server" Width="465px"></asp:Label>
                            </td>
                            <td class="ft-view">Status :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Country :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">City :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>

                            <td class="ft-view">Address :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Fax :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblFax" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Postal Code :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Phone :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Mobile :&nbsp;</td>
                            <td class="fv-view">
                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-view">Email </td>
                            <td class="fv-view">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Website :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                        <tr>
                            <td class="ft-view">Remarks :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                            <td class="ft-view"></td>
                            <td class="fv-view"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkbtnAdd" runat="server" CssClass="lnkbtn-add" OnClick="lnkbtnAdd_Click">Add New Contact</asp:LinkButton></td>
        </tr>
        <tr>
            <td>
                <table class="tbl-grid">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="rgContactList" runat="server" ShowFooter="true" AllowPaging="True" AllowSorting="true" Width="100%" AutoGenerateColumns="False" OnNeedDataSource="rgContactList_NeedDataSource">
                                <MasterTableView ShowHeadersWhenNoRecords="true">
                                    <NoRecordsTemplate>
                                        <table class="rgEmptyData">
                                            <tr>
                                                <td>No Data Found</td>
                                            </tr>
                                        </table>
                                    </NoRecordsTemplate>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ContactId" HeaderText="ID" HeaderStyle-Width="45px" Display="false" />
                                        <telerik:GridTemplateColumn HeaderText="No." HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <%#  Container.DataSetIndex + 1%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="ContactName" HeaderText="Name" HeaderStyle-Width="250px" />
                                        <telerik:GridBoundColumn DataField="Country" HeaderText="Country" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="City" HeaderText="City" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Phone" HeaderText="Phone" HeaderStyle-Width="150px" />
                                        <telerik:GridBoundColumn DataField="Email1" HeaderText="Email1" HeaderStyle-Width="150px" />
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <img title="Status" width="12" height="12" runat="server" src='<%# (bool)Eval("IsActive") ? "~/Controls/resources/images/grid/ico_active.png" : "~/Controls/resources/images/grid/ico_inactive.png" %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <div>
                                                    <a href='<%# string.Format("contact-form.aspx?o=edit&id={0}", Eval("ContactId")) %>'>
                                                        <img alt="Edit" width="12" height="12" runat="server" src="~/Controls/resources/images/grid/Edit.gif" />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <div>
                                                    <asp:LinkButton ID="lbDelete" CommandArgument='<%# Eval("ContactId") %>' CommandName="delete" OnClick="LinkButton_Click" runat="server" CausesValidation="false">
                                                        <img alt="Delete" width="11" height="11" runat="server" src="~/Controls/resources/images/grid/Delete.gif" onclick="return confirm('Are you sure ?');" />
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                          <telerik:GridTemplateColumn></telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-op" OnClick="btnEdit_Click" CausesValidation="false" />
                        </td>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn-op" OnClick="btnBack_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
