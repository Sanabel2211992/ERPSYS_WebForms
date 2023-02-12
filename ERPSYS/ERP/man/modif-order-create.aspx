<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="modif-order-create.aspx.cs" Inherits="ERPSYS.ERP.man.ModificationOrderCreate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/HierarchyItems/MAN/Modification/UCInputItemAdd.ascx" TagPrefix="uc1" TagName="UCInputItemAdd" %>
<%@ Register Src="~/Controls/HierarchyItems/MAN/Modification/UCOutputItemAdd.ascx" TagPrefix="uc2" TagName="UCOutputItemAdd" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
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
                <telerik:RadToolBar ID="rtbOperations" runat="server" CssClass="tb-main" RenderMode="Lightweight" EnableRoundedCorners="True" EnableShadows="True" SingleClick="None" Width="100%" EnableImageSprites="True" OnButtonClick="rtbOperations_ButtonClick" Skin="Metro">
                    <Items>
                        <telerik:RadToolBarButton runat="server" CommandName="back" Text="Back to job order" ImageUrl="~/ERP/resources/images/toolbar/ico_back2.png" Width="135px" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td class="fv-view">
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Modification Order Type</legend>
                    <asp:RequiredFieldValidator runat="server" ID="rfvrblModificationType" ControlToValidate="rblModificationType" Display="Dynamic" ErrorMessage="Please select Modification Type !!" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                    <asp:RadioButtonList ID="rblModificationType" runat="server" RepeatDirection="Vertical" Width="500px" AutoPostBack="true" OnSelectedIndexChanged="rblModificationType_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlOrderTypes" runat="server">
                    <fieldset class="fs-edit">
                        <legend class="fs-edit-legend">Products Information </legend>
                        <table class="tbl-edit" style="width: 950px">
                            <asp:Panel ID="pnlType1" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        <uc1:UCInputItemAdd runat="server" ID="UCItemType1" />
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlType2" runat="server" Visible="false">
                                <tr>
                                    <td class="ft-view">Input Product</td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">
                                        <uc1:UCInputItemAdd runat="server" ID="UCInputItemAdd" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ft-view">Output Product</td>
                                </tr>
                                <tr>
                                    <td class="fv-edit">
                                        <uc2:UCOutputItemAdd runat="server" ID="UCOutputItemAdd" />
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlType3" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        <uc1:UCInputItemAdd runat="server" ID="UCItemType3" />
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>

                    </fieldset>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="fv-view">
                <fieldset class="fs-inner">
                    <legend class="fs-inner-legend">Modification Order Information</legend>
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
                                <asp:DropDownList ID="ddlModificationLocation" runat="server" Width="150px"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvModificationLocation" ControlToValidate="ddlModificationLocation" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="val-error" ValidationGroup="save" SetFocusOnError="True" />
                            </td>
                            <td class="ft-edit">Materials Location :</td>
                            <td class="fv-edit">
                                <asp:DropDownList ID="ddlMaterialLocation" runat="server" Width="150px"></asp:DropDownList>
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
                <table class="tbl-op-center" style="width: 100px">
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
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default" />
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rblModificationType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rblModificationType" />
                    <telerik:AjaxUpdatedControl ControlID="pnlOrderTypes" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
