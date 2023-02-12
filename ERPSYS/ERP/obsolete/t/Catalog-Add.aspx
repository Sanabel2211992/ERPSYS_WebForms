<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="Catalog-Add.aspx.cs" Inherits="ERPSYS.ERP.t.sendbttClick" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <%--    <asp:Button ID="btSend" runat="server" Text="Send" CssClass="btn-save" OnClick="btSend_Click" />--%>

    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Uom Conversion</legend>
        <table class="tbl-inner-view" style="width: 600px">
            <tr>
                <td class="uc-field-title">Select From Unit : 
                    <asp:DropDownList ID="ddlUOMFrom" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="uc-field-title">Select TO Unit
                    <asp:DropDownList ID="ddlUOMTo" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="uc-field-title">Factor: 
                <asp:TextBox ID="txtFactor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uc-field-title" colspan="4">
                    <asp:Button ID="btnConvert" CssClass="btn-cancel" runat="server" Text="Convert" OnClick="btnConvert_Click" />
                </td>
            </tr>
            <tr>
                <td class="uc-field-title">
                    <asp:Label ID="lbvalue" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>

    <fieldset class="fs-inner">
        <legend class="fs-inner-legend">Choose or Add Category</legend>
        <table class="tbl-inner-view" style="width: 600px">
            <tr>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
                <td class="field-title" style="width: 125px"></td>
                <td class="field-val" style="width: 175px"></td>
            </tr>

            <tr>
                <td class="field-title">Category :</td>
                <td class="field-title">
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="150px"></asp:DropDownList>
                </td>
                <td class="field-val" colspan="3">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="OpenDialog">
                    <img alt="catalog" width="16" height="16" runat="server" src="~/Controls/resources/images/ico_item_16.gif"/>
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
    </fieldset>

    <telerik:RadWindow ID="rwCategory" Height="300px" Width="500px" runat="server" VisibleOnPageLoad="true" Visible="false">
        <ContentTemplate>
            <table class="tbl-main">
                <tr>
                    <td class="field-title" style="width: 100px"></td>
                    <td class="field-val"></td>
                    <td class="field-title"></td>
                    <td class="field-val"></td>
                </tr>
                <tr>
                    <td class="field-title">Name :</td>
                    <td class="field-val">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="field-title">Code: </td>
                    <td class="field-val">
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtCode" runat="server" ControlToValidate="txtCode" ErrorMessage="*" CssClass="val-error" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="field-title">Is Active: </td>
                    <td class="field-val">
                        <asp:CheckBox ID="cbIsActive" runat="server" Text="Is Active" />
                    </td>
                </tr>
            </table>

            <table class="tbl-op-center" style="width: 200px">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-save"
                            OnClientClick="if (typeof(Page_ClientValidate) == 'function') { Page_ClientValidate(); if(Page_IsValid) { return confirm('Are you sure ?'); } else return;};" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-cancel" CausesValidation="False" OnClick="btnCancel_Click1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
    Catalog 
      <asp:PlaceHolder ID="phBrend" runat="server"></asp:PlaceHolder>
    <br />
    phMeasure
      <asp:PlaceHolder ID="phMeasure" runat="server"></asp:PlaceHolder>
    <br />
    phSubCat
      <asp:PlaceHolder ID="phSubCat" runat="server"></asp:PlaceHolder>
    <br />
    phCatalog
    <asp:PlaceHolder ID="phCatalog" runat="server"></asp:PlaceHolder>
</asp:Content>
