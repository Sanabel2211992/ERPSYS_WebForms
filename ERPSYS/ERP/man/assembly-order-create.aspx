<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="assembly-order-create.aspx.cs" Inherits="ERPSYS.ERP.man.AssemblyOrderCreate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Controls/HierarchyItems/MAN/Assembly/UCItemSearch.ascx" TagName="UCAssemblyItem" TagPrefix="uc1" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <script type="text/javascript">
        function onClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() === "create") {
                args.set_cancel(!confirm("Are you sure you want to Create Order ?"));
            }
        }
    </script>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Job Order Information</legend>
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
                            <td class="ft-view">Job Order # :</td>
                            <td class="fv-view">
                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">Project Name :</td>
                            <td class="fv-view" colspan="3">
                                <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                            </td>
                            <td class="ft-view">&nbsp;</td>
                            <td class="fv-view">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Text="Back to job order" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="135px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Assembly Product Information</legend>
                    <uc1:UCAssemblyItem ID="UCAssembly" ValidationGroup="save" runat="server" />
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Assembly Order Information</legend>
                    <table class="tbl-edit" style="width: 600px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 175px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Product Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlAssemblyLocation" runat="server" Width="140px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvAssemblyLocation" ControlToValidate="ddlAssemblyLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Materials Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlMaterialLocation" runat="server" Width="140px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvMaterialLocatio" ControlToValidate="ddlMaterialLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
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
                <table class="tbl-op-center" style="width: 250px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Continue" CssClass="btn-save" ValidationGroup="save"
                                OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate('save'); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
