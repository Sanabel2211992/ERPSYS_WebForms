<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="proj-create.aspx.cs" Inherits="ERPSYS.ERP.proj.ProjCreate" %>

<%--<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc1" %>--%>
<%@ Register Src="../../Controls/UCDatePickerX.ascx" TagName="UCDatePickerX" TagPrefix="uc1" %>
<%@ Register Src="../../Controls/Window/Common/UCCustomer.ascx" TagName="UCCustomer" TagPrefix="uc2" %>

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
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
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
                        <%--<tr>
                            <td class="ft-edit">Start Date :</td>
                            <td class="fv-edit">
                                <uc1:UCDatePickerX ID="UCStartDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                            <td class="ft-edit">End Date :</td>
                            <td class="fv-edit">
                                <uc1:UCDatePickerX ID="UCEndDatePicker" ValidationGroup="save" runat="server" />
                            </td>
                        </tr>--%>
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
                            <td class="fv-edit" colspan="3">
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
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 200px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure you want to save Project changes ?'); } else return;};"
                                OnClick="btnSave_Click1" />
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
